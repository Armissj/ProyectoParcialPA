using System;
using System.Linq;
using System.Windows.Forms;
using ProyectoParcialPA.Controladores;
using ProyectoParcialPA.Entidades;
using ProyectoParcialPA.Visual;

namespace ProyectoParcialPA.Formularios
{
    public partial class frmClientes : Form
    {
        private int idActual;
        private bool cargando;
        public frmClientes()
        {
            InitializeComponent(); RayaoTema.Aplicar(this, "fondo_clientes");
            Ui.AlCargar(this, "GestionarClientes", delegate
            {
                bool gestionar = TListaUsuario.TienePermiso("GestionarClientes");
                btnGuardar.Enabled = gestionar; btnNuevo.Enabled = gestionar; btnDesactivar.Enabled = gestionar; chkActivo.Enabled = gestionar;
                txtNombre.ReadOnly = !gestionar; txtApellido.ReadOnly = !gestionar; txtDireccion.ReadOnly = !gestionar; txtTelefono.ReadOnly = !gestionar; txtEmail.ReadOnly = !gestionar;
                CargarListado(); Nuevo(); lblSubtitulo.Text = "Ejemplos cargados. Nuevo prepara una ficha editable; Guardar confirma los cambios.";
            });
        }
        private void CargarListado()
        {
            cargando = true;
            Ui.Tabla(dgvClientes, TListaCliente.BuscarPorNombre(txtBuscar.Text).Select(x => new { Id = x.Id, Nombre = x.Nombre, Apellido = x.Apellido, Direccion = x.Direccion, Telefono = x.Telefono, Email = x.Email, Activo = x.Activo }).ToList());
            dgvClientes.ClearSelection(); dgvClientes.CurrentCell = null; cargando = false;
        }
        private void Nuevo()
        {
            cargando = true; dgvClientes.ClearSelection(); dgvClientes.CurrentCell = null; idActual = 0; chkActivo.Enabled = false;
            var ejemplo = EjemplosFormulario.Cliente(); txtNombre.Text = ejemplo.Nombre; txtApellido.Text = ejemplo.Apellido; txtDireccion.Text = ejemplo.Direccion; txtTelefono.Text = ejemplo.Telefono; txtEmail.Text = ejemplo.Email;
            chkActivo.Checked = true; txtNombre.Focus(); cargando = false;
        }
        internal bool GuardarActual(out string mensaje)
        {
            var registro = new Cliente
            {
                Id = idActual,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text,
                Activo = chkActivo.Checked
            };
            return idActual == 0 ? TListaCliente.AgregarCliente(registro, out mensaje) : TListaCliente.ActualizarCliente(registro, out mensaje);
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje; if (!GuardarActual(out mensaje)) { Ui.Avisar(this, mensaje); return; }
            CargarListado(); Nuevo();
        }
        private void btnNuevo_Click(object sender, EventArgs e) { if (Ui.Permitir(this, "GestionarClientes")) Nuevo(); }
        private void btnBuscar_Click(object sender, EventArgs e) { CargarListado(); }
        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (!Ui.Permitir(this, "GestionarClientes")) return;
            int id = Ui.IdSeleccionado(dgvClientes);
            if (id == 0) { Ui.Avisar(this, "Selecciona un registro de la tabla."); return; }
            if (!Ui.Preguntar(this, "¿Desactivar este registro? Su historial se conserva.")) return;
            string mensaje; if (!TListaCliente.DesactivarCliente(id, out mensaje)) Ui.Avisar(this, mensaje);
            CargarListado(); Nuevo();
        }
        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (cargando) return;
            int id = Ui.IdSeleccionado(dgvClientes); var actual = TListaCliente.BuscarPorId(id); if (actual == null) return;
            chkActivo.Enabled = TListaUsuario.TienePermiso("GestionarClientes"); idActual = actual.Id; txtNombre.Text = actual.Nombre; txtApellido.Text = actual.Apellido; txtDireccion.Text = actual.Direccion; txtTelefono.Text = actual.Telefono; txtEmail.Text = actual.Email; chkActivo.Checked = actual.Activo;
        }
        private void btnSalir_Click(object sender, EventArgs e) { Close(); }
    }
}
