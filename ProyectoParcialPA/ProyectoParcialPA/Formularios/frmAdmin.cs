using System;
using System.Linq;
using System.Windows.Forms;
using ProyectoParcialPA.Controladores;
using ProyectoParcialPA.Sesiones;
using ProyectoParcialPA.Utilidades;
using ProyectoParcialPA.Visual;

namespace ProyectoParcialPA.Formularios
{
    public partial class frmAdmin : Form
    {
        private bool cargando;
        public bool CambioUsuario { get; private set; }
        public frmAdmin()
        {
            InitializeComponent(); RayaoTema.Aplicar(this, "fondo_admin"); RayaoTema.FormatearTipos(cboFiltro);
            Ui.AlCargar(this, "ConsultarProductos", delegate
            {
                cargando = true; cboFiltro.Items.Clear(); cboFiltro.Items.AddRange(TiposProducto.Todos); cboFiltro.SelectedIndex = 0;
                cboRetro.Items.AddRange(new object[] { "Todos", "Retro", "Actual" }); cboRetro.SelectedIndex = 0; cargando = false;
                ActualizarInventario(true);
            });
        }
        internal void ActualizarInventario(bool plataformas)
        {
            if (!SesionActual.EstaAutenticado) { CambioUsuario = true; Close(); return; }
            var actual = TListaUsuario.BuscarPorNombreUsuario(SesionActual.UsuarioActual.NombreUsuario);
            lblUsuario.Text = actual.NombreUsuario + "\n" + actual.Rol;
            bool gestionar = TListaUsuario.TienePermiso("GestionarProductos");
            btnAgregar.Enabled = gestionar; btnEditar.Enabled = gestionar; btnDesactivar.Enabled = gestionar;
            btnUsuarios.Enabled = TListaUsuario.TienePermiso("GestionarUsuarios");
            btnEjemplo.Visible = gestionar; btnEjemplo.Enabled = gestionar && !DatosEjemplo.EstanCargados; btnEjemplo.Text = DatosEjemplo.EstanCargados ? "Ejemplos cargados" : "Cargar ejemplos";
            var todos = TListaProducto.ObtenerTodos();
            if (plataformas)
            {
                string anterior = Convert.ToString(cboPlataforma.SelectedItem); cargando = true;
                cboPlataforma.Items.Clear(); cboPlataforma.Items.Add("Todas");
                cboPlataforma.Items.AddRange(todos.Select(TiposProducto.Plataforma).Where(x => !string.IsNullOrWhiteSpace(x)).Distinct(StringComparer.OrdinalIgnoreCase).OrderBy(x => x).Cast<object>().ToArray());
                cboPlataforma.SelectedItem = cboPlataforma.Items.Contains(anterior) ? anterior : "Todas"; cargando = false;
            }
            bool? retro = cboRetro.SelectedIndex == 1 ? (bool?)true : cboRetro.SelectedIndex == 2 ? (bool?)false : null;
            var filtrados = TiposProducto.Filtrar(todos, txtBuscar.Text, Convert.ToString(cboFiltro.SelectedItem), Convert.ToString(cboPlataforma.SelectedItem), retro);
            Ui.Tabla(dgvInventario, filtrados.Select(p => new { Codigo = p.Codigo, Nombre = p.Nombre, Tipo = RayaoTema.NombreTipo(p.GetType().Name), Plataforma = TiposProducto.Plataforma(p), Precio = p.Precio, Stock = p.Stock, Retro = p is Entidades.ProductoGaming && ((Entidades.ProductoGaming)p).EsRetro }).ToList());
            lblProductos.Text = todos.Count.ToString(); lblUnidades.Text = todos.Sum(p => (long)p.Stock).ToString();
            try { Ui.PonerDinero(lblValor, TListaProducto.ObtenerResumenGeneral().ValorTotal, 26F); }
            catch (OverflowException) { lblValor.Text = "Fuera de rango"; }
            lblEstado.Text = "Mostrando " + filtrados.Count + " de " + todos.Count + " productos";
        }
        private void Abrir(Func<Form> crear)
        {
            try { using (var formulario = crear()) formulario.ShowDialog(this); }
            catch (Exception ex) { Ui.Avisar(this, "No se pudo abrir la pantalla: " + ex.Message); }
            finally { if (!IsDisposed) ActualizarInventario(true); }
        }
        private string CodigoSeleccionado() { return dgvInventario.CurrentRow == null ? null : Convert.ToString(dgvInventario.CurrentRow.Cells["Codigo"].Value); }
        private void btnEjemplo_Click(object sender, EventArgs e)
        {
            string mensaje;
            if (!DatosEjemplo.Cargar(out mensaje)) Ui.Avisar(this, mensaje);
            ActualizarInventario(true); lblEstado.Text = mensaje;
        }
        private void btnInicio_Click(object sender, EventArgs e) { cargando = true; txtBuscar.Clear(); cboFiltro.SelectedIndex = 0; cboPlataforma.SelectedItem = "Todas"; cboRetro.SelectedIndex = 0; cargando = false; ActualizarInventario(false); }
        private void btnProductos_Click(object sender, EventArgs e)
        {
            if (!Ui.Permitir(this, "ConsultarProductos")) return;
            var producto = TListaProducto.BuscarPorCodigo(CodigoSeleccionado());
            bool soloConsulta = !TListaUsuario.TienePermiso("GestionarProductos");
            if (producto == null)
            {
                if (soloConsulta) { Ui.Avisar(this, "Selecciona un producto para consultar su ficha."); return; }
                Abrir(() => new frmProducto());
            }
            else Abrir(() => new frmProducto(producto, soloConsulta));
        }
        private void btnAgregar_Click(object sender, EventArgs e) { if (Ui.Permitir(this, "GestionarProductos")) Abrir(() => new frmProducto()); }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!Ui.Permitir(this, "GestionarProductos")) return;
            var producto = TListaProducto.BuscarPorCodigo(CodigoSeleccionado());
            if (producto == null) { Ui.Avisar(this, "Selecciona un producto de la tabla."); return; }
            Abrir(() => new frmProducto(producto));
        }
        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (!Ui.Permitir(this, "GestionarProductos")) return;
            string codigo = CodigoSeleccionado(); if (codigo == null) { Ui.Avisar(this, "Selecciona un producto."); return; }
            if (!Ui.Preguntar(this, "¿Desactivar el producto " + codigo + "? Su historial se conserva.")) return;
            string mensaje; if (!TListaProducto.DesactivarProducto(codigo, out mensaje)) Ui.Avisar(this, mensaje); ActualizarInventario(true);
        }
        private void btnUsuarios_Click(object sender, EventArgs e) { if (Ui.Permitir(this, "GestionarUsuarios")) Abrir(() => new frmUsuarios()); }
        private void btnClientes_Click(object sender, EventArgs e) { if (Ui.Permitir(this, "GestionarClientes")) Abrir(() => new frmClientes()); }
        private void btnProveedores_Click(object sender, EventArgs e) { if (Ui.Permitir(this, "ConsultarProveedores")) Abrir(() => new frmProveedores()); }
        private void btnCompras_Click(object sender, EventArgs e) { if (Ui.Permitir(this, "RegistrarCompra")) Abrir(() => new frmCompra()); }
        private void btnVentas_Click(object sender, EventArgs e) { if (Ui.Permitir(this, "RegistrarVenta")) Abrir(() => new frmVenta()); }
        private void btnReportes_Click(object sender, EventArgs e) { if (Ui.Permitir(this, "ConsultarReportes")) Abrir(() => new frmReportes()); }
        private void btnCerrarSesion_Click(object sender, EventArgs e) { CambioUsuario = true; TListaUsuario.CerrarSesion(); Close(); }
        private void txtBuscar_TextChanged(object sender, EventArgs e) { if (!cargando && IsHandleCreated) ActualizarInventario(false); }
        private void cboFiltro_SelectedIndexChanged(object sender, EventArgs e) { if (!cargando && IsHandleCreated) ActualizarInventario(false); }
        private void cboPlataforma_SelectedIndexChanged(object sender, EventArgs e) { if (!cargando && IsHandleCreated) ActualizarInventario(false); }
        private void cboRetro_SelectedIndexChanged(object sender, EventArgs e) { if (!cargando && IsHandleCreated) ActualizarInventario(false); }
    }
}
