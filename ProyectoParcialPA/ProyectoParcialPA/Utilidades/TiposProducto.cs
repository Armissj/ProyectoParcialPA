using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoParcialPA.Entidades;

namespace ProyectoParcialPA.Utilidades
{
    public static class TiposProducto
    {
        public static readonly string[] Todos = { "Todos", "PerifericoPC", "Teclado", "Mouse", "MonitorPC", "ComponentePC", "Procesador", "MemoriaRAM", "TarjetaGrafica", "EquipoMusical", "Microfono", "InterfazAudio", "Vinilo", "PerifericoConsola", "PerifericoPS5", "PerifericoSwitch", "ProductoGaming" };
        public static bool EsTipo(Producto p, string tipo)
        {
            if (p == null) return false;
            if (string.IsNullOrWhiteSpace(tipo) || tipo == "Todos") return true;
            for (Type t = p.GetType(); t != null; t = t.BaseType)
                if (string.Equals(t.Name, tipo.Trim(), StringComparison.OrdinalIgnoreCase)) return true;
            return false;
        }
        public static string Plataforma(Producto p)
        {
            if (p is ProductoGaming) return ((ProductoGaming)p).Plataforma;
            if (p is PerifericoPS5) return "PS5";
            if (p is PerifericoSwitch) return "Switch";
            if (p is PerifericoPC || p is ComponentePC) return "PC";
            if (p is EquipoMusical) return "Audio";
            if (p is Vinilo) return "Música";
            return "";
        }
        public static List<Producto> Filtrar(IEnumerable<Producto> origen, string texto, string tipo, string plataforma, bool? retro)
        {
            texto = ReglasDatos.Texto(texto);
            return origen.Where(p => EsTipo(p, tipo))
                .Where(p => string.IsNullOrWhiteSpace(plataforma) || plataforma == "Todas" || string.Equals(Plataforma(p), plataforma, StringComparison.OrdinalIgnoreCase))
                .Where(p => !retro.HasValue || (p is ProductoGaming && ((ProductoGaming)p).EsRetro) == retro.Value)
                .Where(p => ReglasDatos.Contiene(p.Codigo, texto) || ReglasDatos.Contiene(p.Nombre, texto) || (p is Vinilo && ReglasDatos.Contiene(((Vinilo)p).Artista, texto))).ToList();
        }
    }
}
