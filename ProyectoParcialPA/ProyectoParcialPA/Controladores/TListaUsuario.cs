using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoParcialPA.Entidades;
using ProyectoParcialPA.Sesiones;
using ProyectoParcialPA.Utilidades;

namespace ProyectoParcialPA.Controladores
{
    public static class TListaUsuario
    {
        private static readonly object LockObject = new object();
        private static List<Usuario> _usuarios;

        private static void InicializarSiNecesario()
        {
            if (_usuarios == null)
            {
                lock (LockObject)
                {
                    if (_usuarios == null)
                    {
                        _usuarios = new List<Usuario>();
                        PrepararCuentasDemo();
                    }
                }
            }
        }

        private static bool SonNombresIguales(string nombre1, string nombre2)
        {
            return string.Equals(Usuario.NormalizarNombreUsuario(nombre1), Usuario.NormalizarNombreUsuario(nombre2), StringComparison.OrdinalIgnoreCase);
        }

        private static bool EsRolValido(RolUsuario rol)
        {
            return Enum.IsDefined(typeof(RolUsuario), rol);
        }

        internal static bool EsUsuarioRegistrado(Usuario usuario)
        {
            if (usuario == null)
            {
                return false;
            }

            lock (LockObject)
            {
                InicializarSiNecesario();
                return _usuarios.Any(u => u.Id == usuario.Id && u.Activo && SonNombresIguales(u.NombreUsuario, usuario.NombreUsuario));
            }
        }

        private static Usuario ObtenerUsuarioActualVigente()
        {
            var usuarioActual = SesionActual.UsuarioActual;
            if (usuarioActual == null)
            {
                return null;
            }

            lock (LockObject)
            {
                InicializarSiNecesario();
                return _usuarios.FirstOrDefault(u => u.Id == usuarioActual.Id && u.Activo && SonNombresIguales(u.NombreUsuario, usuarioActual.NombreUsuario));
            }
        }

        public static List<Usuario> Usuarios
        {
            get
            {
                lock (LockObject)
                {
                    InicializarSiNecesario();
                    return _usuarios.Select(u => u.Clonar()).ToList();
                }
            }
        }

        internal static void ReiniciarEstado()
        {
            lock (LockObject)
            {
                _usuarios = null;
                SesionActual.CerrarSesion();
                InicializarSiNecesario();
            }
        }

        private static void PrepararCuentasDemo()
        {
            if (_usuarios == null)
            {
                _usuarios = new List<Usuario>();
            }

            if (!_usuarios.Any(u => SonNombresIguales(u.NombreUsuario, "admin")))
            {
                _usuarios.Add(new Usuario(1, "admin", "Admin123*", RolUsuario.Administrador, true));
            }

            if (!_usuarios.Any(u => SonNombresIguales(u.NombreUsuario, "vendedor")))
            {
                _usuarios.Add(new Usuario(2, "vendedor", "Vendedor123*", RolUsuario.Vendedor, true));
            }
        }

        public static Usuario BuscarPorNombreUsuario(string nombreUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
            {
                return null;
            }

            lock (LockObject)
            {
                InicializarSiNecesario();
                var usuario = _usuarios.FirstOrDefault(u => SonNombresIguales(u.NombreUsuario, nombreUsuario));
                return usuario == null ? null : usuario.Clonar();
            }
        }

        public static bool AgregarUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                return false;
            }

            if (!TienePermiso("AgregarUsuario"))
            {
                return false;
            }

            lock (LockObject)
            {
                InicializarSiNecesario();

                var nombreNormalizado = Usuario.NormalizarNombreUsuario(usuario.NombreUsuario);
                if (string.IsNullOrWhiteSpace(nombreNormalizado) || !EsRolValido(usuario.Rol))
                {
                    return false;
                }

                var errores = usuario.Validar();
                if (errores.Count > 0)
                {
                    return false;
                }

                if (_usuarios.Any(u => SonNombresIguales(u.NombreUsuario, nombreNormalizado)))
                {
                    return false;
                }

                var copia = usuario.Clonar();
                copia.Id = _usuarios.Count == 0 ? 1 : _usuarios.Max(u => u.Id) + 1;
                _usuarios.Add(copia);
                return true;
            }
        }

        public static bool ActualizarUsuario(Usuario usuario)
        {
            if (usuario == null || !TienePermiso("ActualizarUsuario"))
            {
                return false;
            }

            lock (LockObject)
            {
                InicializarSiNecesario();
                var actual = _usuarios.FirstOrDefault(u => u.Id == usuario.Id);
                if (actual == null)
                {
                    return false;
                }

                var nombreNormalizado = Usuario.NormalizarNombreUsuario(usuario.NombreUsuario);
                if (string.IsNullOrWhiteSpace(nombreNormalizado) || !EsRolValido(usuario.Rol))
                {
                    return false;
                }

                if (_usuarios.Any(u => u.Id != usuario.Id && SonNombresIguales(u.NombreUsuario, nombreNormalizado)))
                {
                    return false;
                }

                if (actual.Rol == RolUsuario.Administrador && (usuario.Rol != RolUsuario.Administrador || !usuario.Activo) && ContarAdministradoresActivos() <= 1)
                {
                    return false;
                }

                var original = actual.Clonar();
                actual.NombreUsuario = nombreNormalizado;
                actual.Rol = usuario.Rol;
                actual.Activo = usuario.Activo;

                if (!string.IsNullOrWhiteSpace(usuario.PasswordHash) && !string.IsNullOrWhiteSpace(usuario.PasswordSalt) && usuario.PasswordIterations > 0)
                {
                    actual.AsignarCredenciales(usuario.PasswordHash, usuario.PasswordSalt, usuario.PasswordIterations);
                }

                if (actual.Validar().Count > 0)
                {
                    actual.NombreUsuario = original.NombreUsuario;
                    actual.Rol = original.Rol;
                    actual.Activo = original.Activo;
                    actual.AsignarCredenciales(original.PasswordHash, original.PasswordSalt, original.PasswordIterations);
                    return false;
                }

                return true;
            }
        }

        public static bool CambiarPassword(int idUsuario, string nuevaPassword)
        {
            if (string.IsNullOrWhiteSpace(nuevaPassword) || !TienePermiso("CambiarPassword"))
            {
                return false;
            }

            lock (LockObject)
            {
                InicializarSiNecesario();
                var usuario = _usuarios.FirstOrDefault(u => u.Id == idUsuario);
                if (usuario == null || !usuario.Activo)
                {
                    return false;
                }

                usuario.CambiarPassword(nuevaPassword);
                return true;
            }
        }

        public static bool DesactivarUsuario(int idUsuario)
        {
            if (!TienePermiso("DesactivarUsuario"))
            {
                return false;
            }

            lock (LockObject)
            {
                InicializarSiNecesario();
                var usuario = _usuarios.FirstOrDefault(u => u.Id == idUsuario);
                if (usuario == null || !usuario.Activo)
                {
                    return false;
                }

                if (usuario.Rol == RolUsuario.Administrador && ContarAdministradoresActivos() <= 1)
                {
                    return false;
                }

                usuario.Activo = false;

                if (SesionActual.UsuarioActual != null && SesionActual.UsuarioActual.Id == idUsuario)
                {
                    SesionActual.CerrarSesion();
                }

                return true;
            }
        }

        public static bool ActualizarRol(int idUsuario, RolUsuario nuevoRol)
        {
            if (!TienePermiso("ActualizarRol") || !EsRolValido(nuevoRol))
            {
                return false;
            }

            lock (LockObject)
            {
                InicializarSiNecesario();
                var usuario = _usuarios.FirstOrDefault(u => u.Id == idUsuario);
                if (usuario == null)
                {
                    return false;
                }

                if (usuario.Rol == RolUsuario.Administrador && nuevoRol == RolUsuario.Vendedor && ContarAdministradoresActivos() <= 1)
                {
                    return false;
                }

                usuario.Rol = nuevoRol;
                return true;
            }
        }

        public static bool ValidarCredenciales(string nombreUsuario, string password)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            var usuario = BuscarPorNombreUsuario(nombreUsuario);
            if (usuario == null || !usuario.Activo)
            {
                return false;
            }

            return usuario.VerificarPassword(password);
        }

        public static Usuario Login(string nombreUsuario, string password)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            Usuario usuarioAutenticado;
            lock (LockObject)
            {
                InicializarSiNecesario();
                usuarioAutenticado = _usuarios.FirstOrDefault(u => SonNombresIguales(u.NombreUsuario, nombreUsuario));
                if (usuarioAutenticado == null || !usuarioAutenticado.Activo || !usuarioAutenticado.VerificarPassword(password))
                {
                    return null;
                }

                usuarioAutenticado = usuarioAutenticado.Clonar();
            }

            SesionActual.IniciarSesion(usuarioAutenticado);
            return SesionActual.UsuarioActual == null ? null : SesionActual.UsuarioActual.Clonar();
        }

        public static void CerrarSesion()
        {
            SesionActual.CerrarSesion();
        }

        public static bool TienePermiso(string accion)
        {
            var usuario = ObtenerUsuarioActualVigente();
            return usuario != null && TienePermisoEvaluado(accion, usuario);
        }

        internal static bool TienePermiso(string accion, Usuario usuario)
        {
            return usuario != null && usuario.Activo && TienePermisoEvaluado(accion, usuario);
        }

        private static bool TienePermisoEvaluado(string accion, Usuario usuario)
        {
            if (usuario == null || !usuario.Activo)
            {
                return false;
            }

            if (usuario.Rol == RolUsuario.Administrador)
            {
                switch (accion)
                {
                    case "AgregarUsuario":
                    case "ActualizarUsuario":
                    case "DesactivarUsuario":
                    case "CambiarPassword":
                    case "ActualizarRol":
                    case "GestionarUsuarios":
                    case "GestionarClientes":
                    case "GestionarProveedores":
                    case "ConsultarProveedores":
                    case "ConsultarProductos":
                    case "GestionarProductos":
                    case "RegistrarCompra":
                    case "RegistrarVenta":
                    case "ConsultarReportes":
                        return true;
                    default:
                        return false;
                }
            }

            if (usuario.Rol == RolUsuario.Vendedor)
            {
                switch (accion)
                {
                    case "ConsultarProductos":
                    case "GestionarClientes":
                    case "ConsultarProveedores":
                    case "RegistrarCompra":
                    case "RegistrarVenta":
                    case "ConsultarReportes":
                        return true;
                    default:
                        return false;
                }
            }

            return false;
        }

        private static int ContarAdministradoresActivos()
        {
            return _usuarios == null ? 0 : _usuarios.Count(u => u.Activo && u.Rol == RolUsuario.Administrador);
        }
    }
}
