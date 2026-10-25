using System;
using System.Linq;
using System.Windows.Forms;
using ProyectoParcialPA.Controladores;
using ProyectoParcialPA.Entidades;
using ProyectoParcialPA.Visual;

namespace ProyectoParcialPA.Formularios
{
    public partial class frmProveedores : Form
    {
        private int idActual;
        private bool cargando;
        public frmProveedores()
        {
            InitializeComponent(); RayaoTema.Aplicar(this, "fondo_proveedores");
            Ui.AlCargar(this, "ConsultarProveedores", delegate
            {
                bool gestionar = TListaUsuario.TienePermiso("GestionarProveedores");
                btnGuardar.Enabled = gestionar; btnNuevo.Enabled = gestionar; btnDesactivar.Enabled = gestionar; chkActivo.Enabled = gestionar;
                txtNombre.ReadOnly = !gestionar; txtContacto.ReadOnly = !gestionar; txtTelefono.ReadOnly = !gestionar; txtEmail.ReadOnly = !gestionar;
                CargarListado();
                if (gestionar) Nuevo();
                else if (dgvProveedores.Rows.Count > 0) { dgvProveedores.CurrentCell = dgvProveedores.Rows[0].Cells["Nombre"]; dgvProveedores_SelectionChanged(this, EventArgs.Empty); }
                lblSubtitulo.Text = "Ejemplos cargados. Nuevo prepara una ficha editable; Guardar confirma los cambios.";
            });
        }
        private void CargarListado()
        {
            cargando = true;
            Ui.Tabla(dgvProveedores, TListaProveedor.BuscarPorNombre(txtBuscar.Text).Select(x => new { Id = x.Id, Nombre = x.Nombre, Contacto = x.Contacto, Telefono = x.Telefono, Email = x.Email, Activo = x.Activo }).ToList());
            dgvProveedores.ClearSelection(); dgvProveedores.CurrentCell = null; cargando = false;
        }
        private void Nuevo()
        {
            cargando = true; dgvProveedores.ClearSelection(); dgvProveedores.CurrentCell = null; idActual = 0; chkActivo.Enabled = false;
            var ejemplo = EjemplosFormulario.Proveedor(); txtNombre.Text = ejemplo.Nombre; txtContacto.Text = ejemplo.Contacto; txtTelefono.Text = ejemplo.Telefono; txtEmail.Text = ejemplo.Email;
            chkActivo.Checked = true; txtNombre.Focus(); cargando = false;
        }
        internal bool GuardarActual(out string mensaje)
        {
            var registro = new Proveedor
            {
                Id = idActual,
                Nombre = txtNombre.Text,
                Contacto = txtContacto.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text,
                Activo = chkActivo.Checked
            };
            return idActual == 0 ? TListaProveedor.AgregarProveedor(registro, out mensaje) : TListaProveedor.ActualizarProveedor(registro, out mensaje);
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje; if (!GuardarActual(out mensaje)) { Ui.Avisar(this, mensaje); return; }
            CargarListado(); Nuevo();
        }
        private void btnNuevo_Click(object sender, EventArgs e) { if (Ui.Permitir(this, "GestionarProveedores")) Nuevo(); }
        private void btnBuscar_Click(object sender, EventArgs e) { CargarListado(); }
        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (!Ui.Permitir(this, "GestionarProveedores")) return;
            int id = Ui.IdSeleccionado(dgvProveedores);
            if (id == 0) { Ui.Avisar(this, "Selecciona un registro de la tabla."); return; }
            if (!Ui.Preguntar(this, "¿Desactivar este registro? Su historial se conserva.")) return;
            string mensaje; if (!TListaProveedor.DesactivarProveedor(id, out mensaje)) Ui.Avisar(this, mensaje);
            CargarListado(); Nuevo();
        }
        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            if (cargando) return;
            int id = Ui.IdSeleccionado(dgvProveedores); var actual = TListaProveedor.BuscarPorId(id); if (actual == null) return;
            chkActivo.Enabled = TListaUsuario.TienePermiso("GestionarProveedores"); idActual = actual.Id; txtNombre.Text = actual.Nombre; txtContacto.Text = actual.Contacto; txtTelefono.Text = actual.Telefono; txtEmail.Text = actual.Email; chkActivo.Checked = actual.Activo;
        }
        private void btnSalir_Click(object sender, EventArgs e) { Close(); }
    }
}
