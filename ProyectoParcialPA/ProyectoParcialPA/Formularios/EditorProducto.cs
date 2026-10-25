using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ProyectoParcialPA.Entidades;
using ProyectoParcialPA.Visual;

namespace ProyectoParcialPA.Formularios
{
    internal static class EditorProducto
    {
        private static string V(Dictionary<string, string> d, string k) { string v; return d.TryGetValue(k, out v) ? v.Trim() : ""; }
        private static int I(Dictionary<string, string> d, string k)
        {
            int valor; if (!int.TryParse(V(d, k), NumberStyles.Integer, CultureInfo.InvariantCulture, out valor)) throw new FormatException(RayaoTema.EtiquetaCampo(k) + " debe ser un número entero."); return valor;
        }
        private static decimal D(Dictionary<string, string> d, string k)
        {
            decimal valor; if (!decimal.TryParse(V(d,k).Replace(',', '.'), NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out valor)) throw new FormatException(RayaoTema.EtiquetaCampo(k) + " debe ser un número válido."); return valor;
        }
        internal static Producto Crear(string tipo, string codigo, string nombre, decimal precio, Dictionary<string, string> d)
        {
            switch (tipo)
            {
                case "Teclado": return new Teclado(codigo,nombre,precio,V(d,"Marca"),V(d,"Tipo"));
                case "Mouse": return new Mouse(codigo,nombre,precio,V(d,"Marca"),I(d,"Dpi"));
                case "MonitorPC": return new MonitorPC(codigo,nombre,precio,V(d,"Marca"),D(d,"Pulgadas"),I(d,"Hz"));
                case "Procesador": return new Procesador(codigo,nombre,precio,V(d,"Marca"),V(d,"Socket"),I(d,"Nucleos"));
                case "MemoriaRAM": return new MemoriaRAM(codigo,nombre,precio,V(d,"Marca"),V(d,"Capacidad"),V(d,"Tipo"));
                case "TarjetaGrafica": return new TarjetaGrafica(codigo,nombre,precio,V(d,"Marca"),V(d,"Memoria"),V(d,"Chipset"));
                case "Microfono": return new Microfono(codigo,nombre,precio,V(d,"Marca"),V(d,"Tipo"));
                case "InterfazAudio": return new InterfazAudio(codigo,nombre,precio,V(d,"Marca"),I(d,"Entradas"),I(d,"Salidas"));
                case "Vinilo": return new Vinilo(codigo,nombre,precio,V(d,"Artista"),V(d,"Genero"),I(d,"Anio"));
                case "PerifericoPS5": return new PerifericoPS5(codigo,nombre,precio,V(d,"Marca"),V(d,"TipoAccesorio"),V(d,"Compatibilidad"));
                case "PerifericoSwitch": return new PerifericoSwitch(codigo,nombre,precio,V(d,"Marca"),V(d,"TipoAccesorio"),V(d,"Compatibilidad"));
                case "ProductoGaming": return new ProductoGaming(codigo,nombre,precio,V(d,"Marca"),V(d,"Plataforma"),V(d,"TipoArticulo"),string.Equals(V(d,"EsRetro"),"true",StringComparison.OrdinalIgnoreCase));
                default: throw new FormatException("Selecciona un tipo de producto.");
            }
        }
        internal static Dictionary<string, string> Leer(Producto producto)
        {
            string[] comunes = { "Codigo", "Nombre", "Precio", "Stock", "Activo" };
            return producto.GetType().GetProperties().Where(p => p.CanRead && !comunes.Contains(p.Name)).ToDictionary(p => p.Name, p => Convert.ToString(p.GetValue(producto), CultureInfo.InvariantCulture));
        }
    }
}
