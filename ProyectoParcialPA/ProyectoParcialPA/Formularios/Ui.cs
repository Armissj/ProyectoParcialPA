using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ProyectoParcialPA.Controladores;

namespace ProyectoParcialPA.Formularios
{
    internal static class Ui
    {
        internal static Action<IWin32Window, string> Avisar = (f, m) => MessageBox.Show(f, m, "RAYAO*", MessageBoxButtons.OK, MessageBoxIcon.Information);
        internal static Func<IWin32Window, string, bool> Preguntar = (f, m) => MessageBox.Show(f, m, "RAYAO*", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        internal static Action<IWin32Window, string> MostrarTicket = MostrarComprobante;
        internal static string Dinero(decimal valor) { return "$ " + valor.ToString("N2", CultureInfo.InvariantCulture); }
        internal static void PonerDinero(Label etiqueta, decimal valor, float tamano)
        {
            string texto = Dinero(valor); float ajuste = texto.Length > 22 ? 12F : texto.Length > 16 ? 17F : tamano;
            if (Math.Abs(etiqueta.Font.Size - ajuste) > 0.1F) etiqueta.Font = new Font("Segoe UI", ajuste, FontStyle.Bold);
            etiqueta.Text = texto;
        }
        internal static bool Permitir(Form f, string permiso)
        {
            if (TListaUsuario.TienePermiso(permiso)) return true;
            Avisar(f, "Tu sesión no permite realizar esta acción."); return false;
        }
        internal static void AlCargar(Form f, string permiso, Action cargar)
        {
            f.Load += delegate
            {
                if (!Permitir(f, permiso)) { f.Close(); return; }
                try { cargar(); }
                catch (Exception e) { Avisar(f, "No se pudo cargar la pantalla: " + e.Message); }
            };
        }
        internal static int IdSeleccionado(DataGridView tabla)
        {
            if (tabla.CurrentRow == null || !tabla.Columns.Contains("Id")) return 0;
            int id; return int.TryParse(Convert.ToString(tabla.CurrentRow.Cells["Id"].Value), out id) ? id : 0;
        }
        internal static void Tabla(DataGridView tabla, object datos)
        {
            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            tabla.DataSource = datos;
            foreach (DataGridViewColumn c in tabla.Columns)
            {
                if (c.Name == "Id" || c.Name == "Indice") c.Visible = false;
                if (c.Name == "Codigo") c.HeaderText = "Código";
                if (c.Name == "Operacion") c.HeaderText = "Operación";
                if (c.Name == "Precio") c.HeaderText = "Precio ($)";
                if (c.Name == "CostoUnitario") c.HeaderText = "Costo unitario ($)";
                if (c.Name == "PrecioUnitario") c.HeaderText = "Precio unitario ($)";
                if (c.Name == "Subtotal") c.HeaderText = "Subtotal ($)";
                if (c.Name == "Valor") c.HeaderText = "Valor ($)";
                if (c.Name == "Precio" || c.Name == "CostoUnitario" || c.Name == "PrecioUnitario" || c.Name == "Subtotal" || c.Name == "Valor")
                {
                    c.DefaultCellStyle.Format = "N2"; c.DefaultCellStyle.FormatProvider = CultureInfo.InvariantCulture;
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (c.Name == "Cantidad" || c.Name == "Stock") c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (c.Name == "Fecha") c.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabla.PerformLayout();
        }
        internal static void Combo(ComboBox control, object datos, string texto, string valor)
        {
            control.DataSource = null; control.DisplayMember = texto; control.ValueMember = valor; control.DataSource = datos;
        }
        private static void MostrarComprobante(IWin32Window propietario, string texto)
        {
            using (var f = new Form { Text = "RAYAO* | Comprobante", StartPosition = FormStartPosition.CenterParent, Size = new Size(620, 670), MinimizeBox = false })
            using (var vista = new RichTextBox { Dock = DockStyle.Fill, ReadOnly = true, Text = texto, Font = new Font("Consolas", 10F), BackColor = Color.White })
            using (var imprimir = new Button { Dock = DockStyle.Bottom, Height = 46, Text = "Imprimir comprobante", BackColor = Color.FromArgb(209, 255, 50), FlatStyle = FlatStyle.Flat })
            {
                imprimir.Click += delegate
                {
                    try
                    {
                    using (var documento = new PrintDocument())
                    using (var dialogo = new PrintDialog { Document = documento, UseEXDialog = true })
                    using (var fuente = new Font("Consolas", 10F))
                    {
                        var lineas = texto.Replace("\r", "").Split('\n'); int indice = 0;
                        documento.BeginPrint += delegate { indice = 0; };
                        documento.PrintPage += (s, e) =>
                        {
                            float y = e.MarginBounds.Top; float alto = fuente.GetHeight(e.Graphics) + 3;
                            while (indice < lineas.Length && y + alto <= e.MarginBounds.Bottom) { e.Graphics.DrawString(lineas[indice++], fuente, Brushes.Black, e.MarginBounds.Left, y); y += alto; }
                            e.HasMorePages = indice < lineas.Length;
                        };
                        if (dialogo.ShowDialog(f) == DialogResult.OK) documento.Print();
                    }
                    }
                    catch (Exception ex) { Avisar(f, "No se pudo imprimir el comprobante: " + ex.Message); }
                };
                f.Controls.Add(vista); f.Controls.Add(imprimir); f.ShowDialog(propietario);
            }
        }
    }
}
