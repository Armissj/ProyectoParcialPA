using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoParcialPA.Entidades;
using ProyectoParcialPA.Sesiones;

namespace ProyectoParcialPA.Controladores
{
    public static class DatosEjemplo
    {
        private static bool cargados;
        private static readonly HashSet<string> codigosCreados = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private static readonly HashSet<string> pasos = new HashSet<string>();
        public static bool EstanCargados { get { lock (EstadoTienda.Sincronizacion) return cargados; } }
        internal static void ReiniciarParaPruebas() { lock (EstadoTienda.Sincronizacion) { cargados = false; codigosCreados.Clear(); pasos.Clear(); } }

        // Se prepara la demostración antes de habilitar el login. La sesión temporal
        // siempre se cierra; el usuario debe introducir una cuenta válida para entrar.
        internal static bool PrepararInicio(out string mensaje)
        {
            lock (EstadoTienda.Sincronizacion)
            {
                if (cargados) { mensaje = "Ejemplos listos para la demostración."; return true; }
                if (SesionActual.EstaAutenticado) { mensaje = "Conserva tu sesión y usa Cargar ejemplos como administrador."; return false; }
                try
                {
                    if (TListaUsuario.Login("admin", "Admin123*") == null) { mensaje = "No se pudo preparar la cuenta de demostración."; return false; }
                    return Cargar(out mensaje);
                }
                finally { TListaUsuario.CerrarSesion(); }
            }
        }

        public static bool Cargar(out string mensaje)
        {
            mensaje = "";
            if (!TListaUsuario.TienePermiso("GestionarProductos") || !TListaUsuario.TienePermiso("GestionarProveedores"))
            { mensaje = "Solo el administrador puede cargar los ejemplos."; return false; }
            lock (EstadoTienda.Sincronizacion)
            {
                if (cargados) { mensaje = "Los ejemplos ya están cargados. Tus cambios se conservan."; return true; }
                try
                {
                    PrepararPersonas(); PrepararUsuarios();
                    var existentes = new HashSet<string>(TListaProducto.ObtenerTodos().Concat(TListaProducto.ObtenerTodosInactivos()).Select(p => p.Codigo), StringComparer.OrdinalIgnoreCase);
                    foreach (var producto in CrearCatalogo())
                    {
                        if (existentes.Contains(producto.Codigo)) continue;
                        if (!TListaProducto.AgregarProducto(producto, out mensaje)) throw new InvalidOperationException(mensaje);
                        codigosCreados.Add(producto.Codigo);
                    }
                    var proveedores = TListaProveedor.ObtenerTodos().Where(p => p.Email.EndsWith("@rayao.example", StringComparison.OrdinalIgnoreCase)).ToList();
                    var clientes = TListaCliente.ObtenerTodos().Where(c => c.Email.EndsWith("@rayao.example", StringComparison.OrdinalIgnoreCase)).ToList();
                    if (proveedores.Count == 0 || clientes.Count == 0) throw new InvalidOperationException("Falta un cliente o proveedor activo para los movimientos de ejemplo.");
                    var productos = TListaProducto.ObtenerTodos().Where(p => codigosCreados.Contains(p.Codigo)).ToList();
                    Comprar("pc", productos.Where(p => !(p is Vinilo) && !(p is PerifericoConsola) && !(p is ProductoGaming)).ToList(), proveedores[0], DateTime.Today.AddDays(-3).AddHours(10));
                    Comprar("musica", productos.Where(p => p is Vinilo).ToList(), proveedores[Math.Min(1, proveedores.Count - 1)], DateTime.Today.AddDays(-3).AddHours(12));
                    Comprar("gaming", productos.Where(p => p is PerifericoConsola || p is ProductoGaming).ToList(), proveedores[Math.Min(2, proveedores.Count - 1)], DateTime.Today.AddDays(-3).AddHours(14));
                    Vender("pc-musica", clientes[0], DateTime.Today.AddDays(-2).AddHours(11), new[] { "PC001", "PC002", "VIN001" }, new[] { 2, 1, 1 });
                    Vender("consolas", clientes[Math.Min(1, clientes.Count - 1)], DateTime.Today.AddDays(-1).AddHours(16), new[] { "CON001", "SW001", "JUE001" }, new[] { 1, 2, 1 });
                    Vender("audio", clientes[Math.Min(2, clientes.Count - 1)], DateTime.Today.AddMinutes(1), new[] { "VIN005", "VIN002", "MIC001" }, new[] { 2, 1, 1 });
                    cargados = true;
                    mensaje = "Ejemplos cargados: catálogo, usuarios, clientes, proveedores, compras, ventas y stock. Datos de demostración.";
                    return true;
                }
                catch (InvalidOperationException ex) { mensaje = "No se completaron los ejemplos: " + ex.Message; return false; }
            }
        }

        private static void PrepararPersonas()
        {
            Cliente[] clientes = {
                new Cliente(0,"Mateo","Demo","Machala · Dirección de ejemplo 1","0990000101","mateo@rayao.example"),
                new Cliente(0,"Camila","Demo","Machala · Dirección de ejemplo 2","0990000102","camila@rayao.example"),
                new Cliente(0,"Andrés","Demo","Guayaquil · Dirección de ejemplo 3","0990000103","andres@rayao.example"),
                new Cliente(0,"Valeria","Demo","Pasaje · Dirección de ejemplo 4","0990000104","valeria@rayao.example"),
                new Cliente(0,"Diego","Demo","Santa Rosa · Dirección de ejemplo 5","0990000105","diego@rayao.example"),
                new Cliente(0,"Sofía","Demo","Machala · Dirección de ejemplo 6","0990000106","sofia@rayao.example")
            };
            foreach (var c in clientes)
            {
                if (TListaCliente.ObtenerTodos(true).Any(x => x.Email.Equals(c.Email, StringComparison.OrdinalIgnoreCase))) continue;
                string error; if (!TListaCliente.AgregarCliente(c, out error)) throw new InvalidOperationException(error);
            }
            Proveedor[] proveedores = {
                new Proveedor(0,"RAYAO PC Demo","Distribución PC de ejemplo","0990000201","pc@rayao.example"),
                new Proveedor(0,"RAYAO Música Demo","Distribución de discos de ejemplo","0990000202","musica@rayao.example"),
                new Proveedor(0,"RAYAO Gaming Demo","Distribución de consolas de ejemplo","0990000203","gaming@rayao.example"),
                new Proveedor(0,"RAYAO Audio Demo","Distribución de audio de ejemplo","0990000204","audio@rayao.example")
            };
            foreach (var p in proveedores)
            {
                if (TListaProveedor.ObtenerTodos(true).Any(x => x.Email.Equals(p.Email, StringComparison.OrdinalIgnoreCase))) continue;
                string error; if (!TListaProveedor.AgregarProveedor(p, out error)) throw new InvalidOperationException(error);
            }
        }

        private static void PrepararUsuarios()
        {
            if (!TListaUsuario.Usuarios.Any(u => u.NombreUsuario == "caja_demo"))
                if (!TListaUsuario.AgregarUsuario(new Usuario(0,"caja_demo","Caja123*",RolUsuario.Vendedor))) throw new InvalidOperationException("No se pudo crear caja_demo.");
            if (!TListaUsuario.Usuarios.Any(u => u.NombreUsuario == "encargado_demo"))
                if (!TListaUsuario.AgregarUsuario(new Usuario(0,"encargado_demo","Encargado123*",RolUsuario.Administrador))) throw new InvalidOperationException("No se pudo crear encargado_demo.");
        }

        internal static List<Producto> CrearCatalogo()
        {
            return new List<Producto> {
                new Teclado("PC001","Teclado RAYAO",25.50m,"Redragon","Mecánico"),
                new Mouse("PC002","Mouse gaming",19.90m,"Logitech",6400),
                new MonitorPC("MON001","Monitor para PC",199m,"LG",27m,144),
                new Procesador("CPU001","Procesador PC",149.90m,"AMD","AM4",6),
                new MemoriaRAM("RAM001","Memoria para PC",49.90m,"Kingston","16 GB","DDR4"),
                new TarjetaGrafica("GPU001","Tarjeta gráfica PC",299m,"NVIDIA","12 GB","NVIDIA"),
                new Microfono("MIC001","Micrófono de estudio",69.90m,"Fantech","Condensador"),
                new InterfazAudio("AUD001","Interfaz de audio",119.90m,"Focusrite",2,2),
                new Vinilo("VIN001","Thriller",35m,"Michael Jackson","Pop",1982),
                new Vinilo("VIN002","All Eyez on Me",39.90m,"Tupac","Hip hop",1996),
                new PerifericoPS5("PS5001","Control para PS5",59.90m,"Sony","Mando","PS5 / PC"),
                new PerifericoSwitch("SW001","Controles Joy-Con",59.90m,"Nintendo","Mandos","Switch"),
                new ProductoGaming("CON001","PlayStation 5",499m,"Sony","PS5","Consola",false),
                new ProductoGaming("CON002","Nintendo Switch",299m,"Nintendo","Switch","Consola",false),
                new ProductoGaming("RET001","Consola retro SNES",99m,"Nintendo","SNES","Consola",true),
                new ProductoGaming("JUE001","Videojuego de ejemplo para PC",29.90m,"Demo","PC","Videojuego",false),
                new Vinilo("VIN003","Bad",34.90m,"Michael Jackson","Pop",1987),
                new Vinilo("VIN004","Dangerous",36.90m,"Michael Jackson","Pop",1991),
                new Vinilo("VIN005","Selección underground · Demo",29.90m,"Zell","Trap",2026),
                new Vinilo("VIN006","Selección underground · Demo",29.90m,"Ceroasteriscos","Trap",2026),
                new Vinilo("VIN007","Selección underground · Demo",29.90m,"Blahg","Trap",2026),
                new Mouse("PC003","Mouse para estudio",39.90m,"Razer",12000),
                new ProductoGaming("JUE002","Videojuego de aventura · Demo",49.90m,"Demo","Switch","Videojuego",false),
                new ProductoGaming("RET002","PlayStation 2 retro",89.90m,"Sony","PS2","Consola",true)
            };
        }

        private static void Comprar(string paso, List<Producto> productos, Proveedor proveedor, DateTime fecha)
        {
            string clave = "compra-" + paso;
            if (pasos.Contains(clave)) return;
            if (productos.Count > 0)
            {
                var compra = new Compra(proveedor) { Fecha = fecha };
                foreach (var p in productos)
                    if (!TListaCompra.AgregarDetalleCompra(compra, p, 12, Math.Max(0.01m, decimal.Round(p.Precio * 0.65m, 2)))) throw new InvalidOperationException("No se pudo preparar la compra de " + p.Codigo);
                string error; if (!TListaCompra.RegistrarCompra(compra, out error)) throw new InvalidOperationException(error);
            }
            pasos.Add(clave);
        }

        private static void Vender(string paso, Cliente cliente, DateTime fecha, string[] codigos, int[] cantidades)
        {
            string clave = "venta-" + paso;
            if (pasos.Contains(clave)) return;
            var venta = new Venta(cliente) { Fecha = fecha };
            for (int i = 0; i < codigos.Length; i++)
            {
                if (!codigosCreados.Contains(codigos[i])) continue;
                var p = TListaProducto.BuscarPorCodigo(codigos[i]);
                if (p == null || p.Stock < cantidades[i]) continue;
                if (!TListaVenta.AgregarDetalleVenta(venta, p, cantidades[i], p.Precio)) throw new InvalidOperationException("No se pudo preparar la venta de " + p.Codigo);
            }
            if (venta.Detalles.Count > 0)
            {
                string error; if (!TListaVenta.RegistrarVenta(venta, out error)) throw new InvalidOperationException(error);
            }
            pasos.Add(clave);
        }
    }
}
