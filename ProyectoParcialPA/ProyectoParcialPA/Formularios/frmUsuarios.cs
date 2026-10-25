using System;
using System.Linq;
using System.Windows.Forms;
using ProyectoParcialPA.Controladores;
using ProyectoParcialPA.Entidades;
using ProyectoParcialPA.Sesiones;
using ProyectoParcialPA.Visual;

namespace ProyectoParcialPA.Formularios
{
    public partial class frmUsuarios : Form
    {
        private int idActual;
        private bool cargando;
        public frmUsuarios()
        {
            InitializeComponent(); RayaoTema.Aplicar(this, "fondo_usuarios");
            Ui.AlCargar(this, "GestionarUsuarios", delegate { CargarListado(); Nuevo(); });
        }
        private void CargarListado()
        {
            if (!TListaUsuario.TienePermiso("GestionarUsuarios")) { Close(); return; }
            string texto = txtBuscar.Text.Trim(); cargando = true;
            Ui.Tabla(dgvUsuarios, TListaUsuario.Usuarios.Where(u => u.NombreUsuario.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0).Select(u => new { Id = u.Id, Usuario = u.NombreUsuario, Rol = u.Rol.ToString(), Activo = u.Activo }).ToList());
            dgvUsuarios.ClearSelection(); dgvUsuarios.CurrentCell = null; cargando = false;
        }
        private void Nuevo() { cargando = true; dgvUsuarios.ClearSelection(); dgvUsuarios.CurrentCell = null; idActual = 0; chkActivo.Enabled = false; txtNombreUsuario.Clear(); txtPassword.Clear(); cboRol.SelectedItem = "Vendedor"; chkActivo.Checked = true; txtNombreUsuario.Focus(); cargando = false; }
        internal bool GuardarActual(out string mensaje)
        {
            mensaje = "";
            if (!TListaUsuario.TienePermiso("GestionarUsuarios")) { mensaje = "Solo el administrador gestiona usuarios."; return false; }
            RolUsuario rol;
            if (!Enum.TryParse(Convert.ToString(cboRol.SelectedItem), out rol) || string.IsNullOrWhiteSpace(txtNombreUsuario.Text)) { mensaje = "Completa el usuario y selecciona un rol."; return false; }
            try
            {
                bool resultado;
                if (idActual == 0)
                {
                    if (string.IsNullOrWhiteSpace(txtPassword.Text)) { mensaje = "Escribe la contraseña de la cuenta nueva."; return false; }
                    resultado = TListaUsuario.AgregarUsuario(new Usuario(0, txtNombreUsuario.Text, txtPassword.Text, rol));
                }
                else
                {
                    var usuario = TListaUsuario.Usuarios.FirstOrDefault(u => u.Id == idActual);
                    if (usuario == null) { mensaje = "La cuenta ya no existe."; return false; }
                    usuario.NombreUsuario = txtNombreUsuario.Text; usuario.Rol = rol; usuario.Activo = chkActivo.Checked;
                    if (!string.IsNullOrEmpty(txtPassword.Text)) usuario.CambiarPassword(txtPassword.Text);
                    resultado = TListaUsuario.ActualizarUsuario(usuario);
                }
                if (!resultado) mensaje = "No se pudo guardar. Revisa el nombre duplicado y conserva al menos un administrador activo.";
                return resultado;
            }
            catch (ArgumentException ex) { mensaje = ex.Message; return false; }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
            try
            {
                string mensaje; if (!GuardarActual(out mensaje)) { Ui.Avisar(this, mensaje); return; }
                if (!SesionActual.EstaAutenticado || !TListaUsuario.TienePermiso("GestionarUsuarios")) { Close(); return; }
                CargarListado(); Nuevo();
            }
            finally { if (!IsDisposed) btnGuardar.Enabled = true; }
        }
        private void btnNuevo_Click(object sender, EventArgs e) { if (Ui.Permitir(this, "GestionarUsuarios")) Nuevo(); }
        private void btnBuscar_Click(object sender, EventArgs e) { CargarListado(); }
        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (!Ui.Permitir(this, "GestionarUsuarios")) return;
            int id = Ui.IdSeleccionado(dgvUsuarios); if (id == 0) { Ui.Avisar(this, "Selecciona un usuario."); return; }
            if (!Ui.Preguntar(this, "¿Desactivar esta cuenta?")) return;
            if (!TListaUsuario.DesactivarUsuario(id)) Ui.Avisar(this, "No se pudo desactivar. Conserva al menos un administrador activo.");
            if (!SesionActual.EstaAutenticado) { Close(); return; }
            CargarListado(); Nuevo();
        }
        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (cargando || !TListaUsuario.TienePermiso("GestionarUsuarios")) return;
            int id = Ui.IdSeleccionado(dgvUsuarios); var usuario = TListaUsuario.Usuarios.FirstOrDefault(u => u.Id == id); if (usuario == null) return;
            chkActivo.Enabled = true; idActual = id; txtNombreUsuario.Text = usuario.NombreUsuario; txtPassword.Clear(); cboRol.SelectedItem = usuario.Rol.ToString(); chkActivo.Checked = usuario.Activo;
        }
        private void btnSalir_Click(object sender, EventArgs e) { Close(); }
    }
}
