using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoParcialPA.Controladores;
using ProyectoParcialPA.Visual;

namespace ProyectoParcialPA.Formularios
{
    public partial class frmLogin : Form
    {
        private bool preparando;
        public frmLogin()
        {
            InitializeComponent(); RayaoTema.Aplicar(this, "fondo_login");
            Shown += PrepararDemostracion;
        }
        private void Habilitar(bool habilitado)
        {
            btnEntrar.Enabled = habilitado; btnSalir.Enabled = habilitado;
            txtUsuario.Enabled = habilitado; txtPassword.Enabled = habilitado;
            btnAdminDemo.Enabled = habilitado; btnVendedorDemo.Enabled = habilitado;
        }
        private async void PrepararDemostracion(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            preparando = true; Habilitar(false); lblEstado.Text = "Preparando los ejemplos de la tienda...";
            try
            {
                string mensaje = "";
                bool listo = await Task.Run(() => DatosEjemplo.PrepararInicio(out mensaje));
                if (IsDisposed) return;
                lblEstado.Text = listo ? "Demo lista · Datos en memoria" : "Puedes entrar con tu cuenta.";
                if (!listo) Ui.Avisar(this, mensaje);
                if (string.IsNullOrWhiteSpace(txtUsuario.Text) && string.IsNullOrEmpty(txtPassword.Text)) RellenarCuenta("admin", "Admin123*");
                lblAyuda.Text = "Ejemplos listos. Puedes usar admin o vendedor para probar los roles.";
            }
            catch (Exception ex) { if (!IsDisposed) { lblEstado.Text = "Entra para revisar la tienda."; Ui.Avisar(this, "No se pudo preparar la demo: " + ex.Message); } }
            finally { preparando = false; if (!IsDisposed) Habilitar(true); }
        }
        private void RellenarCuenta(string usuario, string password) { txtUsuario.Text = usuario; txtPassword.Text = password; }
        private void btnAdminDemo_Click(object sender, EventArgs e) { if (!preparando) RellenarCuenta("admin", "Admin123*"); }
        private void btnVendedorDemo_Click(object sender, EventArgs e) { if (!preparando) RellenarCuenta("vendedor", "Vendedor123*"); }
        private async void btnEntrar_Click(object sender, EventArgs e)
        {
            if (preparando || !btnEntrar.Enabled) return;
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtPassword.Text)) { Ui.Avisar(this, "Escribe tu usuario y tu contraseña."); return; }
            string usuario = txtUsuario.Text, password = txtPassword.Text;
            Habilitar(false); btnEntrar.Text = "Entrando..."; lblEstado.Text = "Comprobando tu cuenta...";
            try
            {
                var resultado = await Task.Run(() => TListaUsuario.Login(usuario, password));
                if (IsDisposed) return;
                if (resultado != null) { DialogResult = DialogResult.OK; Close(); }
                else { Ui.Avisar(this, "Usuario o contraseña incorrectos, o cuenta inactiva."); txtPassword.Clear(); }
            }
            catch (Exception ex) { if (!IsDisposed) Ui.Avisar(this, "No se pudo iniciar sesión: " + ex.Message); }
            finally
            {
                if (!IsDisposed) { Habilitar(true); btnEntrar.Text = "ENTRAR A LA TIENDA"; lblEstado.Text = "Administrador / Vendedor"; txtPassword.Focus(); }
            }
        }
        private void btnSalir_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; Close(); }
    }
}
