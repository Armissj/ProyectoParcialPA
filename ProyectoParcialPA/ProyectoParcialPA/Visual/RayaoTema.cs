using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProyectoParcialPA.Visual
{
    public static class RayaoTema
    {
        private static readonly Dictionary<string, Image> Imagenes = new Dictionary<string, Image>(StringComparer.OrdinalIgnoreCase);
        public static string RutaPng = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "png");

        public static Image Imagen(string relativa)
        {
            string ruta = Path.Combine(RutaPng, relativa.Replace('/', Path.DirectorySeparatorChar));
            Image imagen;
            if (Imagenes.TryGetValue(ruta, out imagen)) return imagen;
            if (!File.Exists(ruta)) return null;
            using (var archivo = File.OpenRead(ruta))
            using (var origen = Image.FromStream(archivo)) imagen = new Bitmap(origen);
            Imagenes.Add(ruta, imagen);
            return imagen;
        }

        public static void Aplicar(Form formulario, string fondo)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            formulario.BackgroundImage = Imagen("fondos/" + fondo + ".png");
            formulario.BackgroundImageLayout = ImageLayout.Stretch;
            Decorar(formulario);
        }

        private static void Decorar(Control padre)
        {
            foreach (Control control in padre.Controls)
            {
                string tag = control.Tag as string;
                if (control is PictureBox && tag != null && tag.StartsWith("asset:"))
                    ((PictureBox)control).Image = Imagen(tag.Substring(6));
                if (control is Button && tag != null && tag.StartsWith("icon:"))
                {
                    string nombre = tag.Substring(5);
                    string clave = "icono24:" + nombre;
                    Image original = Imagen("iconos/" + nombre + ".png"), reducido;
                    if (original != null)
                    {
                        if (!Imagenes.TryGetValue(clave, out reducido))
                        {
                            reducido = new Bitmap(original, new Size(24, 24));
                            Imagenes.Add(clave, reducido);
                        }
                        ((Button)control).Image = reducido;
                    }
                }
                if (control is DataGridView) EstiloTabla((DataGridView)control);
                if (control.HasChildren) Decorar(control);
            }
        }

        public static void EstiloTabla(DataGridView tabla)
        {
            tabla.EnableHeadersVisualStyles = false;
            tabla.ColumnHeadersHeight = 42;
            tabla.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(23, 25, 23);
            tabla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            tabla.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            tabla.DefaultCellStyle.BackColor = Color.White;
            tabla.DefaultCellStyle.ForeColor = Color.FromArgb(23, 25, 23);
            tabla.DefaultCellStyle.SelectionBackColor = Color.FromArgb(228, 249, 161);
            tabla.DefaultCellStyle.SelectionForeColor = Color.Black;
            tabla.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 247, 241);
            tabla.GridColor = Color.FromArgb(232, 233, 224);
            tabla.RowTemplate.Height = 38;
        }

        public static string NombreTipo(string tipo)
        {
            switch (tipo)
            {
                case "PerifericoPC": return "Periféricos de PC";
                case "ComponentePC": return "Componentes de PC";
                case "EquipoMusical": return "Equipos de audio";
                case "PerifericoConsola": return "Accesorios de consolas";
                case "ProductoGaming": return "Consolas, videojuegos y retro";
                case "MonitorPC": return "Monitor de PC";
                case "MemoriaRAM": return "Memoria RAM";
                case "TarjetaGrafica": return "Tarjeta gráfica";
                case "Microfono": return "Micrófono";
                case "InterfazAudio": return "Interfaz de audio";
                case "PerifericoPS5": return "Accesorios de PS5";
                case "PerifericoSwitch": return "Accesorios de Switch";
                default: return tipo;
            }
        }

        public static void FormatearTipos(ComboBox lista)
        {
            lista.FormattingEnabled = true;
            lista.Format += delegate(object sender, ListControlConvertEventArgs e)
            {
                e.Value = NombreTipo(Convert.ToString(e.ListItem));
            };
        }

        public static string EtiquetaCampo(string nombre)
        {
            switch (nombre)
            {
                case "Dpi": return "DPI";
                case "Nucleos": return "Núcleos";
                case "Genero": return "Género";
                case "Anio": return "Año";
                case "TipoArticulo": return "Tipo de artículo";
                case "TipoAccesorio": return "Tipo de accesorio";
                case "EsRetro": return "Retro";
                default: return nombre;
            }
        }

        public static void MostrarProducto(PictureBox visor, string tipo)
        {
            string nombre;
            switch (tipo)
            {
                case "Mouse": nombre = "mouse"; break;
                case "MonitorPC": nombre = "monitor"; break;
                case "Procesador": nombre = "procesador"; break;
                case "MemoriaRAM": nombre = "memoria_ram"; break;
                case "TarjetaGrafica": nombre = "tarjeta_grafica"; break;
                case "Microfono": nombre = "microfono"; break;
                case "InterfazAudio": nombre = "interfaz_audio"; break;
                case "Vinilo": nombre = "vinilo"; break;
                case "PerifericoPS5": nombre = "control_ps5"; break;
                case "PerifericoSwitch": nombre = "control_switch"; break;
                case "ProductoGaming": nombre = "ps5"; break;
                default: nombre = "teclado"; break;
            }
            visor.Image = Imagen("productos/" + nombre + ".png");
        }

        public static void LiberarImagenes()
        {
            foreach (Image imagen in Imagenes.Values) imagen.Dispose();
            Imagenes.Clear();
        }
    }
}
