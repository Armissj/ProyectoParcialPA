using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoParcialPA.Entidades;
using ProyectoParcialPA.Sesiones;
using ProyectoParcialPA.Utilidades;

namespace ProyectoParcialPA.Controladores
{
    public static class TListaCompra
    {
        private static List<Compra> _registros = new List<Compra>();
        private static HashSet<Guid> _operaciones = new HashSet<Guid>();
        internal static void ReiniciarEstado()
        {
            lock (EstadoTienda.Sincronizacion) { _registros = new List<Compra>(); _operaciones = new HashSet<Guid>(); }
        }

        public static List<Compra> ObtenerTodos()
        {
            if (!TListaUsuario.TienePermiso("ConsultarReportes")) return new List<Compra>();
            lock (EstadoTienda.Sincronizacion) return _registros.Select(x => x.Copiar()).ToList();
        }

        public static List<Compra> BuscarPorFechas(DateTime desde, DateTime hasta)
        {
            if (desde.Date > hasta.Date) return new List<Compra>();
            return ObtenerTodos().Where(x => x.Fecha.Date >= desde.Date && x.Fecha.Date <= hasta.Date).ToList();
        }

        public static List<Compra> BuscarPorProveedor(int id)
        {
            return ObtenerTodos().Where(x => x.Proveedor != null && x.Proveedor.Id == id).ToList();
        }

        public static bool AgregarDetalleCompra(Compra operacion, Producto producto, int cantidad, decimal importe)
        {
            if (!TListaUsuario.TienePermiso("RegistrarCompra") || operacion == null || operacion.Confirmada || producto == null || cantidad <= 0 || !ReglasDatos.ImporteValido(importe)) return false;
            lock (EstadoTienda.Sincronizacion)
            {
                var actual = TListaProducto.BuscarPorCodigo(producto.Codigo);
                if (actual == null || operacion.Detalles.Any(d => d == null)) return false;
                try
                {
                    int totalCantidad = checked(operacion.Detalles.Where(d => d.CodigoProducto == actual.Codigo).Sum(d => d.Cantidad) + cantidad);
                    checked { int stockFinal = actual.Stock + totalCantidad; if (stockFinal < 0) return false; }
                    decimal totalBorrador = checked(operacion.Detalles.Sum(d => d.Subtotal) + checked(cantidad * importe));
                    if (totalBorrador <= 0m) return false;
                    var repetido = operacion.Detalles.FirstOrDefault(d => d.CodigoProducto == actual.Codigo && d.CostoUnitario == importe);
                    if (repetido != null)
                    {
                        int nuevaCantidad = checked(repetido.Cantidad + cantidad);
                        checked { decimal subtotal = nuevaCantidad * importe; if (subtotal <= 0m) return false; }
                        repetido.Cantidad = nuevaCantidad;
                    }
                    else
                    {
                        checked { decimal subtotal = cantidad * importe; if (subtotal <= 0m) return false; }
                        operacion.Detalles.Add(new DetalleCompra(actual, cantidad, importe));
                    }
                    return true;
                }
                catch (OverflowException) { return false; }
            }
        }

        public static bool ValidarCompraAntesDeConfirmar(Compra operacion)
        {
            lock (EstadoTienda.Sincronizacion)
            {
                Proveedor participante; Usuario usuario; List<DetalleCompra> detalles; Dictionary<string, int> cantidades; string mensaje;
                return Preparar(operacion, out participante, out usuario, out detalles, out cantidades, out mensaje);
            }
        }

        private static bool Preparar(Compra operacion, out Proveedor participante, out Usuario usuario, out List<DetalleCompra> detalles, out Dictionary<string, int> cantidades, out string mensaje)
        {
            participante = null; usuario = null; detalles = new List<DetalleCompra>(); cantidades = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase); mensaje = "";
            if (!TListaUsuario.TienePermiso("RegistrarCompra")) { mensaje = "No tienes permiso para registrar esta operación."; return false; }
            usuario = SesionActual.UsuarioActual;
            if (usuario == null) { mensaje = "Inicia sesión para continuar."; return false; }
            if (operacion == null) { mensaje = "La operación es obligatoria."; return false; }
            if (operacion.Confirmada || _operaciones.Contains(operacion.IdOperacion)) { mensaje = "Esta operación ya fue confirmada."; return false; }
            if (operacion.Fecha == default(DateTime)) { mensaje = "La fecha no es válida."; return false; }
            if (operacion.Proveedor == null) { mensaje = "Selecciona un proveedor."; return false; }
            participante = TListaProveedor.BuscarPorId(operacion.Proveedor.Id);
            if (participante == null) { mensaje = "El proveedor no existe o está inactivo."; return false; }
            if (operacion.Detalles.Count == 0) { mensaje = "Agrega al menos un producto."; return false; }
            try
            {
                decimal total = 0m;
                foreach (var linea in operacion.Detalles)
                {
                    if (linea == null || linea.Cantidad <= 0 || !ReglasDatos.ImporteValido(linea.CostoUnitario)) { mensaje = "Hay una línea con cantidad o importe inválido."; return false; }
                    var producto = TListaProducto.BuscarPorCodigo(linea.CodigoProducto);
                    if (producto == null) { mensaje = "Un producto no existe o está inactivo."; return false; }
                    int anterior; cantidades.TryGetValue(producto.Codigo, out anterior);
                    cantidades[producto.Codigo] = checked(anterior + linea.Cantidad);
                    total = checked(total + checked(linea.Cantidad * linea.CostoUnitario));
                    detalles.Add(new DetalleCompra(producto, linea.Cantidad, linea.CostoUnitario) { FechaRegistro = operacion.Fecha });
                }
                foreach (var item in cantidades)
                {
                    var producto = TListaProducto.BuscarPorCodigo(item.Key);
                    checked { int final = producto.Stock + item.Value; if (final < 0) { mensaje = "La cantidad no es válida."; return false; } }
                }
                if (total <= 0m) { mensaje = "El total debe ser mayor a cero."; return false; }
            }
            catch (OverflowException) { mensaje = "Las cantidades o los importes exceden el límite permitido."; return false; }
            return true;
        }

        public static bool RegistrarCompra(Compra operacion, out string mensaje)
        {
            lock (EstadoTienda.Sincronizacion)
            {
                Proveedor participante; Usuario usuario; List<DetalleCompra> detalles; Dictionary<string, int> cantidades;
                if (!Preparar(operacion, out participante, out usuario, out detalles, out cantidades, out mensaje)) return false;
                if (_registros.Count == int.MaxValue) { mensaje = "Se alcanzó el límite de operaciones."; return false; }
                var guardada = operacion.Copiar(); guardada.Proveedor = participante; guardada.Usuario = usuario.Clonar();
                guardada.Id = _registros.Count + 1; guardada.Confirmada = true; guardada.Detalles.Clear(); guardada.Detalles.AddRange(detalles);
                var historialNuevo = new List<Compra>(_registros) { guardada };
                var idsNuevos = new HashSet<Guid>(_operaciones) { guardada.IdOperacion };
                var actorParaBorrador = usuario.Clonar();
                var variaciones = cantidades.ToDictionary(x => x.Key, x => 1 * x.Value, StringComparer.OrdinalIgnoreCase);
                if (!TListaProducto.AplicarVariacionesStock(variaciones, out mensaje)) return false;
                // Las asignaciones restantes no validan ni reservan memoria: todo está preparado.
                _registros = historialNuevo; _operaciones = idsNuevos;
                operacion.Id = guardada.Id; operacion.Usuario = actorParaBorrador; operacion.Confirmada = true;
                mensaje = "Compra registrada correctamente."; return true;
            }
        }
    }
}
