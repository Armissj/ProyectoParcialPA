using System;
using System.Collections.Generic;
using ProyectoParcialPA.Utilidades;

namespace ProyectoParcialPA.Entidades
{
    public class Usuario
    {
        private int _id;
        private string _nombreUsuario;
        private string _passwordHash;
        private string _passwordSalt;
        private int _passwordIterations;
        private RolUsuario _rol;
        private bool _activo;

        public Usuario()
        {
            _passwordIterations = SeguridadPassword.IteracionesDefault;
            _activo = true;
        }

        public Usuario(int id, string nombreUsuario, string password, RolUsuario rol, bool activo = true)
        {
            _id = id;
            _nombreUsuario = NormalizarNombreUsuario(nombreUsuario);
            _rol = rol;
            _activo = activo;
            _passwordIterations = SeguridadPassword.IteracionesDefault;

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("La contraseña es obligatoria.", "password");
            }

            CambiarPassword(password);
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string NombreUsuario
        {
            get { return _nombreUsuario; }
            set { _nombreUsuario = NormalizarNombreUsuario(value); }
        }

        public string PasswordHash
        {
            get { return _passwordHash; }
            private set { _passwordHash = value; }
        }

        public string PasswordSalt
        {
            get { return _passwordSalt; }
            private set { _passwordSalt = value; }
        }

        public int PasswordIterations
        {
            get { return _passwordIterations; }
            private set { _passwordIterations = value; }
        }

        public RolUsuario Rol
        {
            get { return _rol; }
            set { _rol = value; }
        }

        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }

        public static string NormalizarNombreUsuario(string nombreUsuario)
        {
            if (nombreUsuario == null)
            {
                return string.Empty;
            }

            return nombreUsuario.Trim();
        }

        internal void AsignarCredenciales(string passwordHash, string passwordSalt, int passwordIterations)
        {
            if (string.IsNullOrWhiteSpace(passwordHash) || string.IsNullOrWhiteSpace(passwordSalt) || passwordIterations <= 0)
            {
                throw new ArgumentException("Las credenciales de acceso no son válidas.");
            }

            _passwordHash = passwordHash;
            _passwordSalt = passwordSalt;
            _passwordIterations = passwordIterations;
        }

        public void CambiarPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("La contraseña es obligatoria.", "password");
            }

            var passwordAnteriorHash = _passwordHash;
            var passwordAnteriorSalt = _passwordSalt;
            var passwordAnteriorIteraciones = _passwordIterations;

            try
            {
                var salt = SeguridadPassword.GenerarSalt();
                var hash = SeguridadPassword.GenerarHash(password, salt, SeguridadPassword.IteracionesDefault);

                _passwordSalt = Convert.ToBase64String(salt);
                _passwordHash = Convert.ToBase64String(hash);
                _passwordIterations = SeguridadPassword.IteracionesDefault;
            }
            catch
            {
                _passwordHash = passwordAnteriorHash;
                _passwordSalt = passwordAnteriorSalt;
                _passwordIterations = passwordAnteriorIteraciones;
                throw;
            }
        }

        public Usuario Clonar()
        {
            var copia = new Usuario();
            copia._id = _id;
            copia._nombreUsuario = _nombreUsuario;
            copia._passwordHash = _passwordHash;
            copia._passwordSalt = _passwordSalt;
            copia._passwordIterations = _passwordIterations;
            copia._rol = _rol;
            copia._activo = _activo;
            return copia;
        }

        public bool VerificarPassword(string password)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(_passwordHash) || string.IsNullOrEmpty(_passwordSalt))
            {
                return false;
            }

            return SeguridadPassword.Validar(password, _passwordHash, _passwordSalt, _passwordIterations);
        }

        public List<string> Validar()
        {
            var errores = new List<string>();

            if (string.IsNullOrWhiteSpace(_nombreUsuario))
            {
                errores.Add("El nombre de usuario es obligatorio.");
            }

            if (!Enum.IsDefined(typeof(RolUsuario), _rol))
            {
                errores.Add("El rol del usuario no es válido.");
            }

            if (string.IsNullOrWhiteSpace(_passwordHash) || string.IsNullOrWhiteSpace(_passwordSalt))
            {
                errores.Add("La contraseña del usuario es obligatoria.");
            }

            if (_passwordIterations <= 0)
            {
                errores.Add("Las iteraciones de la contraseña son inválidas.");
            }

            return errores;
        }
    }
}
