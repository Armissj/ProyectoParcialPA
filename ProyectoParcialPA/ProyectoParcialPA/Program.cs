using System;
using System.Windows.Forms;
using ProyectoParcialPA.Controladores;
using ProyectoParcialPA.Formularios;
using ProyectoParcialPA.Sesiones;
using ProyectoParcialPA.Visual;

namespace ProyectoParcialPA
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles(); Application.SetCompatibleTextRenderingDefault(false);
            try { using (var contexto = new ContextoTienda()) Application.Run(contexto); }
            finally { RayaoTema.LiberarImagenes(); }
        }
    }
    internal sealed class ContextoTienda : ApplicationContext
    {
        internal ContextoTienda() { MostrarLogin(); }
        private void MostrarLogin()
        {
            TListaUsuario.CerrarSesion();
            var login = new frmLogin();
            login.FormClosed += delegate
            {
                if (login.DialogResult == DialogResult.OK && SesionActual.EstaAutenticado) MostrarPrincipal();
                else ExitThread();
            };
            login.Show();
        }
        private void MostrarPrincipal()
        {
            var principal = new frmAdmin();
            principal.FormClosed += delegate { if (principal.CambioUsuario) MostrarLogin(); else ExitThread(); };
            principal.Show();
        }
    }
}
