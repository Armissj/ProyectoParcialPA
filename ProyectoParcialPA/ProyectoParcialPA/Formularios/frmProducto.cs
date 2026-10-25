using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ProyectoParcialPA.Controladores;
using ProyectoParcialPA.Entidades;
using ProyectoParcialPA.Visual;

namespace ProyectoParcialPA.Formularios
{
    public partial class frmProducto : Form
    {
        private string codigoOriginal;
        public frmProducto()
        {
            InitializeComponent(); RayaoTema.Aplicar(this, "fondo_producto"); RayaoTema.FormatearTipos(cboTipoProducto);
            if (cboTipoProducto.Items.Count > 0) cboTipoProducto.SelectedIndex = 0;
            Ui.AlCargar(this, "GestionarProductos", delegate { });
        }
        public frmProducto(Producto producto) : this()
        {
            if (producto == null) throw new ArgumentNullException("producto");
            codigoOriginal = producto.Codigo; txtCodigo.Text = producto.Codigo; txtCodigo.ReadOnly = true;
            txtNombre.Text = producto.Nombre; numPrecio.Maximum = Math.Max(numPrecio.Maximum, producto.Precio); numPrecio.Value = producto.Precio;
            txtStock.Text = producto.Stock.ToString(); chkActivo.Checked = producto.Activo;
            cboTipoProducto.SelectedItem = producto.GetType().Name; CargarCamposEspecificos(EditorProducto.Leer(producto));
            cboTipoProducto.Enabled = !TListaProducto.TieneMovimientos(producto.Codigo);
            if (!cboTipoProducto.Enabled) lblAyuda.Text = "Este producto tiene movimientos. El tipo y el stock se conservan; puedes editar sus otros datos.";
            lblTitulo.Text = "Editar producto"; btnGuardar.Text = "Guardar cambios";
        }
        internal bool GuardarActual(out string mensaje)
        {
            mensaje = "";
            if (!TListaUsuario.TienePermiso("GestionarProductos")) { mensaje = "No tienes permiso para modificar productos."; return false; }
            try
            {
                var producto = EditorProducto.Crear(Convert.ToString(cboTipoProducto.SelectedItem), txtCodigo.Text, txtNombre.Text, numPrecio.Value, LeerCamposEspecificos());
                var errores = producto.Validar(); if (errores.Count > 0) { mensaje = errores[0]; return false; }
                return codigoOriginal == null ? TListaProducto.AgregarProducto(producto, out mensaje) : TListaProducto.ActualizarProducto(codigoOriginal, producto, out mensaje);
            }
            catch (FormatException e) { mensaje = e.Message; return false; }
            catch (ArgumentException e) { mensaje = e.Message; return false; }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!btnGuardar.Enabled) return; btnGuardar.Enabled = false;
            try { string mensaje; if (GuardarActual(out mensaje)) { DialogResult = DialogResult.OK; Close(); } else Ui.Avisar(this, mensaje); }
            finally { if (!IsDisposed) btnGuardar.Enabled = true; }
        }
        private void btnCancelar_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; Close(); }
        private void cboTipoProducto_SelectedIndexChanged(object sender, EventArgs e) { ActualizarCamposTipo(); }
        private void ActualizarImagen()
        {
            if (cboTipoProducto.SelectedItem == null) return;
            string tipo = cboTipoProducto.SelectedItem.ToString();
            if (tipo != "ProductoGaming") { RayaoTema.MostrarProducto(picProducto, tipo); return; }
            Control plataforma, articulo, retro;
            campos.TryGetValue("Plataforma", out plataforma); campos.TryGetValue("TipoArticulo", out articulo); campos.TryGetValue("EsRetro", out retro);
            string p = plataforma == null ? "" : plataforma.Text.ToLowerInvariant();
            string a = articulo == null ? "" : articulo.Text;
            string nombre = a == "Videojuego" ? "videojuego" : retro is CheckBox && ((CheckBox)retro).Checked ? "consola_retro" : p.Contains("switch") ? "switch" : "ps5";
            picProducto.Image = RayaoTema.Imagen("productos/" + nombre + ".png");
        }
        private readonly Dictionary<string, Control> campos = new Dictionary<string, Control>();

        private void ActualizarCamposTipo()
        {
            if (pnlCampos == null || cboTipoProducto.SelectedItem == null) return;
            var anteriores = new List<Control>();
            foreach (Control control in pnlCampos.Controls) anteriores.Add(control);
            pnlCampos.Controls.Clear();
            foreach (var control in anteriores) control.Dispose();
            campos.Clear();
            string tipo = cboTipoProducto.SelectedItem.ToString();
            string[] nombres;
            switch (tipo)
            {
                case "Teclado": nombres = new[] { "Marca", "Tipo" }; break;
                case "Mouse": nombres = new[] { "Marca", "Dpi" }; break;
                case "MonitorPC": nombres = new[] { "Marca", "Pulgadas", "Hz" }; break;
                case "Procesador": nombres = new[] { "Marca", "Socket", "Nucleos" }; break;
                case "MemoriaRAM": nombres = new[] { "Marca", "Capacidad", "Tipo" }; break;
                case "TarjetaGrafica": nombres = new[] { "Marca", "Memoria", "Chipset" }; break;
                case "Microfono": nombres = new[] { "Marca", "Tipo" }; break;
                case "InterfazAudio": nombres = new[] { "Marca", "Entradas", "Salidas" }; break;
                case "Vinilo": nombres = new[] { "Artista", "Genero", "Anio" }; break;
                case "PerifericoPS5":
                case "PerifericoSwitch": nombres = new[] { "Marca", "TipoAccesorio", "Compatibilidad" }; break;
                default: nombres = new[] { "Marca", "Plataforma", "TipoArticulo", "EsRetro" }; break;
            }
            foreach (string nombre in nombres)
            {
                Panel caja = new Panel { Width = 270, Height = 70, Margin = new Padding(0, 0, 12, 4) };
                Label etiqueta = new Label { Text = RayaoTema.EtiquetaCampo(nombre), Location = new Point(0, 0), Size = new Size(265, 22), Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(98, 103, 95) };
                Control entrada;
                if (nombre == "EsRetro") entrada = new CheckBox { Text = "Es retro", Size = new Size(265, 30) };
                else if (nombre == "TipoArticulo")
                {
                    ComboBox opciones = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Size = new Size(265, 32) };
                    opciones.Items.AddRange(new object[] { "Consola", "Videojuego", "Accesorio" });
                    opciones.SelectedIndex = 0; entrada = opciones;
                }
                else entrada = new TextBox { Size = new Size(265, 32), BorderStyle = BorderStyle.FixedSingle };
                entrada.TextChanged += delegate { ActualizarImagen(); };
                if (entrada is CheckBox) ((CheckBox)entrada).CheckedChanged += delegate { ActualizarImagen(); };
                entrada.Name = "campo" + nombre;
                entrada.Location = new Point(0, 25);
                caja.Controls.Add(etiqueta); caja.Controls.Add(entrada);
                pnlCampos.Controls.Add(caja); campos.Add(nombre, entrada);
            }
            Control compatibilidad;
            if (campos.TryGetValue("Compatibilidad", out compatibilidad)) compatibilidad.Text = tipo == "PerifericoPS5" ? "PS5" : "Switch";
            ActualizarImagen();
            txtStock.Text = string.IsNullOrEmpty(txtStock.Text) ? "0" : txtStock.Text;
        }

        public Dictionary<string, string> LeerCamposEspecificos()
        {
            var resultado = new Dictionary<string, string>();
            foreach (var campo in campos)
                resultado[campo.Key] = campo.Value is CheckBox ? ((CheckBox)campo.Value).Checked.ToString() : campo.Value.Text;
            return resultado;
        }

        public void CargarCamposEspecificos(Dictionary<string, string> valores)
        {
            if (valores == null) return;
            foreach (var campo in campos)
            {
                string valor;
                if (!valores.TryGetValue(campo.Key, out valor)) continue;
                if (campo.Value is CheckBox) ((CheckBox)campo.Value).Checked = string.Equals(valor, "true", StringComparison.OrdinalIgnoreCase);
                else campo.Value.Text = valor;
            }
        }


    }
}
