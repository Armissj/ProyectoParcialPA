using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoParcialPA.Controladores;
using ProyectoParcialPA.Visual;

namespace ProyectoParcialPA.Formularios
{
    public partial class frmLogin : Form
    {
        public frmLogin() { InitializeComponent(); RayaoTema.Aplicar(this, "fondo_login"); }
        private async void btnEntrar_Click(object sender, EventArgs e)
        {
            if (!btnEntrar.Enabled) return;
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtPassword.Text)) { Ui.Avisar(this, "Escribe tu usuario y tu contraseña."); return; }
            string usuario = txtUsuario.Text, password = txtPassword.Text;
            btnEntrar.Enabled = false; btnSalir.Enabled = false; txtUsuario.Enabled = false; txtPassword.Enabled = false;
            btnEntrar.Text = "Entrando..."; lblEstado.Text = "Comprobando tu cuenta...";
            try
            {
                var resultado = await Task.Run(() => TListaUsuario.Login(usuario, password));
                if (IsDisposed) return;
                if (resultado != null) { DialogResult = DialogResult.OK; Close(); }
                else { Ui.Avisar(this, "Usuario o contraseña incorrectos, o cuenta inactiva."); txtPassword.Clear(); txtPassword.Focus(); }
            }
            catch (Exception ex) { if (!IsDisposed) Ui.Avisar(this, "No se pudo iniciar sesión: " + ex.Message); }
            finally
            {
                if (!IsDisposed) { btnEntrar.Enabled = true; btnSalir.Enabled = true; txtUsuario.Enabled = true; txtPassword.Enabled = true; btnEntrar.Text = "ENTRAR A LA TIENDA"; lblEstado.Text = "Administrador / Vendedor"; }
            }
        }
        private void btnSalir_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; Close(); }
    }
}
