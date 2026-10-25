using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoParcialPA.Entidades;

namespace ProyectoParcialPA.Controladores
{
    public static class DatosEjemplo
    {
        private static bool cargados;
        public static bool EstanCargados { get { lock (EstadoTienda.Sincronizacion) return cargados; } }
        internal static void ReiniciarParaPruebas() { lock (EstadoTienda.Sincronizacion) cargados = false; }
        public static bool Cargar(out string mensaje)
        {
            mensaje = "";
            if (!TListaUsuario.TienePermiso("GestionarProductos") || !TListaUsuario.TienePermiso("GestionarProveedores")) { mensaje = "Solo el administrador puede cargar el ejemplo."; return false; }
            lock (EstadoTienda.Sincronizacion)
            {
                if (cargados) { mensaje = "El catálogo de ejemplo ya está cargado."; return true; }
                if (!TListaCliente.ObtenerTodos(true).Any(c => c.Email == "cliente@example.com"))
                    if (!TListaCliente.AgregarCliente(new Cliente(0,"Cliente","Demo","Dirección de ejemplo","0991234567","cliente@example.com"),out mensaje)) return false;
                if (!TListaProveedor.ObtenerTodos(true).Any(p => p.Email == "proveedor@example.com"))
                    if (!TListaProveedor.AgregarProveedor(new Proveedor(0,"Proveedor Demo","Contacto Demo","0997654321","proveedor@example.com"),out mensaje)) return false;
                Producto[] productos = {
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
                    new ProductoGaming("RET001","Consola retro",99m,"Nintendo","SNES","Consola",true),
                    new ProductoGaming("JUE001","Videojuego de ejemplo",29.90m,"Demo","PC","Videojuego",false)
                };
                var existentes = new HashSet<string>(TListaProducto.ObtenerTodos().Concat(TListaProducto.ObtenerTodosInactivos()).Select(p => p.Codigo),StringComparer.OrdinalIgnoreCase);
                foreach (var producto in productos)
                    if (!existentes.Contains(producto.Codigo) && !TListaProducto.AgregarProducto(producto,out mensaje)) return false;
                cargados = true; mensaje = "Ejemplo cargado. Los productos empiezan con stock cero; registra una compra para ingresar unidades."; return true;
            }
        }
    }
}
