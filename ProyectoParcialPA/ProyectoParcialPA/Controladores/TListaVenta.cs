using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoParcialPA.Entidades;
using ProyectoParcialPA.Sesiones;
using ProyectoParcialPA.Utilidades;

namespace ProyectoParcialPA.Controladores
{
    public static class TListaVenta
    {
        private static List<Venta> _registros = new List<Venta>();
        private static HashSet<Guid> _operaciones = new HashSet<Guid>();
        internal static void ReiniciarEstado()
        {
            lock (EstadoTienda.Sincronizacion) { _registros = new List<Venta>(); _operaciones = new HashSet<Guid>(); }
        }

        public static List<Venta> ObtenerTodos()
        {
            if (!TListaUsuario.TienePermiso("ConsultarReportes")) return new List<Venta>();
            lock (EstadoTienda.Sincronizacion) return _registros.Select(x => x.Copiar()).ToList();
        }

        public static List<Venta> BuscarPorFechas(DateTime desde, DateTime hasta)
        {
            if (desde.Date > hasta.Date) return new List<Venta>();
            return ObtenerTodos().Where(x => x.Fecha.Date >= desde.Date && x.Fecha.Date <= hasta.Date).ToList();
        }

        public static List<Venta> BuscarPorCliente(int id)
        {
            return ObtenerTodos().Where(x => x.Cliente != null && x.Cliente.Id == id).ToList();
        }

        public static bool AgregarDetalleVenta(Venta operacion, Producto producto, int cantidad, decimal importe)
        {
            if (!TListaUsuario.TienePermiso("RegistrarVenta") || operacion == null || operacion.Confirmada || producto == null || cantidad <= 0 || !ReglasDatos.ImporteValido(importe)) return false;
            lock (EstadoTienda.Sincronizacion)
            {
                var actual = TListaProducto.BuscarPorCodigo(producto.Codigo);
                if (actual == null || operacion.Detalles.Any(d => d == null)) return false;
                try
                {
                    int totalCantidad = checked(operacion.Detalles.Where(d => d.CodigoProducto == actual.Codigo).Sum(d => d.Cantidad) + cantidad);
                    if (totalCantidad > actual.Stock) return false;
                    decimal totalBorrador = checked(operacion.Detalles.Sum(d => d.Subtotal) + checked(cantidad * importe));
                    if (totalBorrador <= 0m) return false;
                    var repetido = operacion.Detalles.FirstOrDefault(d => d.CodigoProducto == actual.Codigo && d.PrecioUnitario == importe);
                    if (repetido != null)
                    {
                        int nuevaCantidad = checked(repetido.Cantidad + cantidad);
                        checked { decimal subtotal = nuevaCantidad * importe; if (subtotal <= 0m) return false; }
                        repetido.Cantidad = nuevaCantidad;
                    }
                    else
                    {
                        checked { decimal subtotal = cantidad * importe; if (subtotal <= 0m) return false; }
                        operacion.Detalles.Add(new DetalleVenta(actual, cantidad, importe));
                    }
                    return true;
                }
                catch (OverflowException) { return false; }
            }
        }

        public static bool ValidarVentaAntesDeConfirmar(Venta operacion)
        {
            lock (EstadoTienda.Sincronizacion)
            {
                Cliente participante; Usuario usuario; List<DetalleVenta> detalles; Dictionary<string, int> cantidades; string mensaje;
                return Preparar(operacion, out participante, out usuario, out detalles, out cantidades, out mensaje);
            }
        }

        private static bool Preparar(Venta operacion, out Cliente participante, out Usuario usuario, out List<DetalleVenta> detalles, out Dictionary<string, int> cantidades, out string mensaje)
        {
            participante = null; usuario = null; detalles = new List<DetalleVenta>(); cantidades = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase); mensaje = "";
            if (!TListaUsuario.TienePermiso("RegistrarVenta")) { mensaje = "No tienes permiso para registrar esta operación."; return false; }
            usuario = SesionActual.UsuarioActual;
            if (usuario == null) { mensaje = "Inicia sesión para continuar."; return false; }
            if (operacion == null) { mensaje = "La operación es obligatoria."; return false; }
            if (operacion.Confirmada || _operaciones.Contains(operacion.IdOperacion)) { mensaje = "Esta operación ya fue confirmada."; return false; }
            if (operacion.Fecha == default(DateTime)) { mensaje = "La fecha no es válida."; return false; }
            if (operacion.Cliente == null) { mensaje = "Selecciona un cliente."; return false; }
            participante = TListaCliente.BuscarPorId(operacion.Cliente.Id);
            if (participante == null) { mensaje = "El cliente no existe o está inactivo."; return false; }
            if (operacion.Detalles.Count == 0) { mensaje = "Agrega al menos un producto."; return false; }
            try
            {
                decimal total = 0m;
                foreach (var linea in operacion.Detalles)
                {
                    if (linea == null || linea.Cantidad <= 0 || !ReglasDatos.ImporteValido(linea.PrecioUnitario)) { mensaje = "Hay una línea con cantidad o importe inválido."; return false; }
                    var producto = TListaProducto.BuscarPorCodigo(linea.CodigoProducto);
                    if (producto == null) { mensaje = "Un producto no existe o está inactivo."; return false; }
                    int anterior; cantidades.TryGetValue(producto.Codigo, out anterior);
                    cantidades[producto.Codigo] = checked(anterior + linea.Cantidad);
                    total = checked(total + checked(linea.Cantidad * linea.PrecioUnitario));
                    detalles.Add(new DetalleVenta(producto, linea.Cantidad, linea.PrecioUnitario) { FechaRegistro = operacion.Fecha });
                }
                foreach (var item in cantidades)
                {
                    var producto = TListaProducto.BuscarPorCodigo(item.Key);
                    if (producto.Stock < item.Value) { mensaje = "Stock insuficiente para " + producto.Nombre + "."; return false; }
                }
                if (total <= 0m) { mensaje = "El total debe ser mayor a cero."; return false; }
            }
            catch (OverflowException) { mensaje = "Las cantidades o los importes exceden el límite permitido."; return false; }
            return true;
        }

        public static bool RegistrarVenta(Venta operacion, out string mensaje)
        {
            lock (EstadoTienda.Sincronizacion)
            {
                Cliente participante; Usuario usuario; List<DetalleVenta> detalles; Dictionary<string, int> cantidades;
                if (!Preparar(operacion, out participante, out usuario, out detalles, out cantidades, out mensaje)) return false;
                if (_registros.Count == int.MaxValue) { mensaje = "Se alcanzó el límite de operaciones."; return false; }
                var guardada = operacion.Copiar(); guardada.Cliente = participante; guardada.Usuario = usuario.Clonar();
                guardada.Id = _registros.Count + 1; guardada.Confirmada = true; guardada.Detalles.Clear(); guardada.Detalles.AddRange(detalles);
                var historialNuevo = new List<Venta>(_registros) { guardada };
                var idsNuevos = new HashSet<Guid>(_operaciones) { guardada.IdOperacion };
                var actorParaBorrador = usuario.Clonar();
                var variaciones = cantidades.ToDictionary(x => x.Key, x => -1 * x.Value, StringComparer.OrdinalIgnoreCase);
                if (!TListaProducto.AplicarVariacionesStock(variaciones, out mensaje)) return false;
                // Las asignaciones restantes no validan ni reservan memoria: todo está preparado.
                _registros = historialNuevo; _operaciones = idsNuevos;
                operacion.Id = guardada.Id; operacion.Usuario = actorParaBorrador; operacion.Confirmada = true;
                mensaje = "Venta registrada correctamente."; return true;
            }
        }
    }
}
