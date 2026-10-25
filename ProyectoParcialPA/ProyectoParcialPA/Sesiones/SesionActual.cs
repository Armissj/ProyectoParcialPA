using ProyectoParcialPA.Controladores;
using ProyectoParcialPA.Entidades;

namespace ProyectoParcialPA.Sesiones
{
    public static class SesionActual
    {
        private static Usuario _usuarioActual;

        public static Usuario UsuarioActual
        {
            get
            {
                if (_usuarioActual == null)
                {
                    return null;
                }

                if (!TListaUsuario.EsUsuarioRegistrado(_usuarioActual))
                {
                    _usuarioActual = null;
                    return null;
                }

                return _usuarioActual.Clonar();
            }
            private set { _usuarioActual = value == null ? null : value.Clonar(); }
        }

        public static bool EstaAutenticado
        {
            get
            {
                if (_usuarioActual == null)
                {
                    return false;
                }

                if (!TListaUsuario.EsUsuarioRegistrado(_usuarioActual) || !_usuarioActual.Activo)
                {
                    _usuarioActual = null;
                    return false;
                }

                return true;
            }
        }

        internal static void IniciarSesion(Usuario usuario)
        {
            if (usuario == null || !usuario.Activo)
            {
                _usuarioActual = null;
                return;
            }

            if (!TListaUsuario.EsUsuarioRegistrado(usuario))
            {
                _usuarioActual = null;
                return;
            }

            _usuarioActual = usuario.Clonar();
        }

        public static void CerrarSesion()
        {
            _usuarioActual = null;
        }
    }
}
