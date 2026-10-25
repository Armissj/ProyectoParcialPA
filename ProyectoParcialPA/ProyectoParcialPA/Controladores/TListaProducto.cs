using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ProyectoParcialPA.Entidades;

namespace ProyectoParcialPA.Controladores
{
    public static class TListaProducto
    {
        private static readonly object LockObject = new object();
        private static List<Producto> _productos;
        private static readonly HashSet<string> ProductosConMovimientos = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        private static void InicializarSiNecesario()
        {
            if (_productos == null)
            {
                lock (LockObject)
                {
                    if (_productos == null)
                    {
                        _productos = new List<Producto>();
                    }
                }
            }
        }

        internal static void ReiniciarEstado()
        {
            lock (LockObject)
            {
                _productos = new List<Producto>();
                ProductosConMovimientos.Clear();
            }
        }

        internal static void RegistrarMovimientoProducto(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                return;
            }

            lock (LockObject)
            {
                ProductosConMovimientos.Add(codigo.Trim());
            }
        }

        internal static bool TieneMovimientos(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                return false;
            }

            lock (LockObject)
            {
                return ProductosConMovimientos.Contains(codigo.Trim());
            }
        }

        public static bool TienePermisoConsultar()
        {
            return TListaUsuario.TienePermiso("ConsultarProductos");
        }

        public static bool TienePermisoGestionar()
        {
            return TListaUsuario.TienePermiso("GestionarProductos");
        }

        private static string NormalizarCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                return string.Empty;
            }

            return codigo.Trim().ToUpperInvariant();
        }

        private static string NormalizarTexto(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return string.Empty;
            }

            return texto.Trim();
        }

        private static Producto ClonarProducto(Producto producto)
        {
            if (producto == null)
            {
                return null;
            }

            var clone = Activator.CreateInstance(producto.GetType());
            if (clone == null)
            {
                return null;
            }

            var tipoActual = producto.GetType();
            while (tipoActual != null && tipoActual != typeof(object))
            {
                foreach (var campo in tipoActual.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly))
                {
                    campo.SetValue(clone, campo.GetValue(producto));
                }

                tipoActual = tipoActual.BaseType;
            }

            return (Producto)clone;
        }

        private static void CopiarCampos(object origen, object destino)
        {
            if (origen == null || destino == null)
            {
                return;
            }

            var tipoOrigen = origen.GetType();
            var tipoDestino = destino.GetType();
            if (tipoOrigen != tipoDestino)
            {
                return;
            }

            foreach (var propiedad in tipoOrigen.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                if (!propiedad.CanWrite || propiedad.GetIndexParameters().Length > 0)
                {
                    continue;
                }

                if (propiedad.Name == "Stock" || propiedad.Name == "Activo")
                {
                    continue;
                }

                var propiedadDestino = tipoDestino.GetProperty(propiedad.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (propiedadDestino != null && propiedadDestino.CanWrite && propiedadDestino.PropertyType == propiedad.PropertyType)
                {
                    propiedadDestino.SetValue(destino, propiedad.GetValue(origen));
                }
            }
        }

        private static void EstablecerStock(Producto producto, int stock)
        {
            if (producto == null)
            {
                return;
            }

            var campoStock = typeof(Producto).GetField("_stock", BindingFlags.Instance | BindingFlags.NonPublic);
            if (campoStock != null)
            {
                campoStock.SetValue(producto, stock);
            }
        }

        private static void EstablecerActivo(Producto producto, bool activo)
        {
            if (producto == null)
            {
                return;
            }

            var campoActivo = typeof(Producto).GetField("_activo", BindingFlags.Instance | BindingFlags.NonPublic);
            if (campoActivo != null)
            {
                campoActivo.SetValue(producto, activo);
            }
        }

        private static IEnumerable<string> ObtenerTiposProducto(Producto producto)
        {
            var tipos = new List<string>();
            var tipoActual = producto == null ? null : producto.GetType();

            while (tipoActual != null && tipoActual != typeof(object))
            {
                tipos.Add(tipoActual.Name);
                tipoActual = tipoActual.BaseType;
            }

            return tipos;
        }

        public static List<Producto> ObtenerTodos()
        {
            lock (LockObject)
            {
                InicializarSiNecesario();
                return _productos.Where(p => p.Activo).Select(p => ClonarProducto(p)).ToList();
            }
        }

        public static List<Producto> ObtenerTodosInactivos()
        {
            lock (LockObject)
            {
                InicializarSiNecesario();
                return _productos.Where(p => !p.Activo).Select(p => ClonarProducto(p)).ToList();
            }
        }

        public static Producto BuscarPorCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                return null;
            }

            lock (LockObject)
            {
                InicializarSiNecesario();
                var producto = _productos.FirstOrDefault(p => p.Activo && string.Equals(NormalizarCodigo(p.Codigo), NormalizarCodigo(codigo), StringComparison.OrdinalIgnoreCase));
                return producto == null ? null : ClonarProducto(producto);
            }
        }

        public static List<Producto> BuscarPorNombreOParte(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return ObtenerTodos();
            }

            var busqueda = NormalizarTexto(texto).ToLowerInvariant();

            lock (LockObject)
            {
                InicializarSiNecesario();
                return _productos
                    .Where(p => p.Activo)
                    .Where(p => p.Codigo.ToLowerInvariant().Contains(busqueda)
                        || p.Nombre.ToLowerInvariant().Contains(busqueda)
                        || (p is Vinilo && ((Vinilo)p).Artista.ToLowerInvariant().Contains(busqueda)))
                    .Select(p => ClonarProducto(p))
                    .ToList();
            }
        }

        public static List<Producto> BuscarPorTexto(string texto)
        {
            return BuscarPorNombreOParte(texto);
        }

        public static List<Producto> FiltrarPorTipo(string tipoProducto)
        {
            if (string.IsNullOrWhiteSpace(tipoProducto))
            {
                return ObtenerTodos();
            }

            var tipoSolicitado = tipoProducto.Trim();
            lock (LockObject)
            {
                InicializarSiNecesario();
                return _productos
                    .Where(p => p.Activo)
                    .Where(p => ObtenerTiposProducto(p).Any(t => string.Equals(t, tipoSolicitado, StringComparison.OrdinalIgnoreCase)))
                    .Select(p => ClonarProducto(p))
                    .ToList();
            }
        }

        public static bool AgregarProducto(Producto producto, out string mensaje)
        {
            mensaje = string.Empty;

            if (producto == null)
            {
                mensaje = "El producto es obligatorio.";
                return false;
            }

            if (!TienePermisoGestionar())
            {
                mensaje = "No tiene permisos para gestionar productos.";
                return false;
            }

            lock (LockObject)
            {
                InicializarSiNecesario();

                var copia = ClonarProducto(producto);
                if (copia == null)
                {
                    mensaje = "No se pudo preparar el producto.";
                    return false;
                }

                copia.Codigo = NormalizarCodigo(copia.Codigo);
                copia.Nombre = NormalizarTexto(copia.Nombre);
                copia.Activo = true;

                var errores = copia.Validar();
                if (errores.Any())
                {
                    mensaje = errores.First();
                    return false;
                }

                if (_productos.Any(p => string.Equals(NormalizarCodigo(p.Codigo), copia.Codigo, StringComparison.OrdinalIgnoreCase)))
                {
                    mensaje = "El código ya existe en el inventario.";
                    return false;
                }

                _productos.Add(copia);
                mensaje = "Producto agregado correctamente.";
                return true;
            }
        }

        public static bool ActualizarProducto(string codigoOriginal, Producto cambios, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(codigoOriginal) || cambios == null)
            {
                mensaje = "No se pudo actualizar el producto.";
                return false;
            }

            if (!TienePermisoGestionar())
            {
                mensaje = "No tiene permisos para gestionar productos.";
                return false;
            }

            lock (LockObject)
            {
                InicializarSiNecesario();

                var original = _productos.FirstOrDefault(p => string.Equals(NormalizarCodigo(p.Codigo), NormalizarCodigo(codigoOriginal), StringComparison.OrdinalIgnoreCase));
                if (original == null)
                {
                    mensaje = "El producto no existe.";
                    return false;
                }

                var codigoNuevo = NormalizarCodigo(cambios.Codigo);
                if (!string.Equals(NormalizarCodigo(original.Codigo), codigoNuevo, StringComparison.OrdinalIgnoreCase))
                {
                    mensaje = "El código no se puede cambiar.";
                    return false;
                }

                var errores = cambios.Validar();
                if (errores.Any())
                {
                    mensaje = errores.First();
                    return false;
                }

                if (_productos.Any(p => !string.Equals(NormalizarCodigo(p.Codigo), NormalizarCodigo(original.Codigo), StringComparison.OrdinalIgnoreCase)
                    && string.Equals(NormalizarCodigo(p.Codigo), codigoNuevo, StringComparison.OrdinalIgnoreCase)))
                {
                    mensaje = "El código ya existe en otro producto.";
                    return false;
                }

                if (TieneMovimientos(original.Codigo) && original.GetType() != cambios.GetType())
                {
                    mensaje = "No se puede cambiar el tipo de un producto que ya tiene movimientos.";
                    return false;
                }

                var copia = ClonarProducto(cambios);
                if (copia == null)
                {
                    mensaje = "No se pudo preparar el producto actualizado.";
                    return false;
                }

                copia.Codigo = NormalizarCodigo(original.Codigo);
                copia.Activo = original.Activo;
                EstablecerStock(copia, original.Stock);
                CopiarCampos(copia, original);
                mensaje = "Producto actualizado correctamente.";
                return true;
            }
        }

        public static bool DesactivarProducto(string codigo, out string mensaje)
        {
            mensaje = string.Empty;

            if (!TienePermisoGestionar())
            {
                mensaje = "No tiene permisos para gestionar productos.";
                return false;
            }

            lock (LockObject)
            {
                InicializarSiNecesario();
                var producto = _productos.FirstOrDefault(p => p.Activo && string.Equals(NormalizarCodigo(p.Codigo), NormalizarCodigo(codigo), StringComparison.OrdinalIgnoreCase));
                if (producto == null)
                {
                    mensaje = "El producto no existe o ya está inactivo.";
                    return false;
                }

                producto.Activo = false;
                mensaje = "Producto desactivado correctamente.";
                return true;
            }
        }

        public static bool ValidarStockDisponible(string codigo, int cantidadSolicitada)
        {
            if (cantidadSolicitada <= 0)
            {
                return false;
            }

            lock (LockObject)
            {
                InicializarSiNecesario();
                var producto = _productos.FirstOrDefault(p => p.Activo && string.Equals(NormalizarCodigo(p.Codigo), NormalizarCodigo(codigo), StringComparison.OrdinalIgnoreCase));
                return producto != null && producto.Stock >= cantidadSolicitada;
            }
        }

        public static decimal ObtenerValorInventarioVenta()
        {
            lock (LockObject)
            {
                InicializarSiNecesario();
                return _productos.Where(p => p.Activo).Sum(p => p.Precio * p.Stock);
            }
        }

        public static ResumenInventario ObtenerResumenGeneral()
        {
            lock (LockObject)
            {
                InicializarSiNecesario();
                var activos = _productos.Where(p => p.Activo).ToList();
                return new ResumenInventario
                {
                    CantidadProductos = activos.Count,
                    UnidadesTotales = activos.Sum(p => p.Stock),
                    ValorTotal = activos.Sum(p => p.Precio * p.Stock)
                };
            }
        }
    }
}
