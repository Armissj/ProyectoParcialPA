using System;
using System.Security.Cryptography;
using System.Text;

namespace ProyectoParcialPA.Utilidades
{
    public static class SeguridadPassword
    {
        public const int IteracionesDefault = 600000;
        public const int LongitudSaltBytes = 16;
        public const int LongitudHashBytes = 32;

        public static byte[] GenerarSalt(int longitudBytes = LongitudSaltBytes)
        {
            if (longitudBytes < 16)
            {
                longitudBytes = LongitudSaltBytes;
            }

            var salt = new byte[longitudBytes];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public static byte[] GenerarHash(string password, byte[] salt, int iteraciones = IteracionesDefault)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            if (salt == null)
            {
                throw new ArgumentNullException("salt");
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(password), salt, iteraciones, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(LongitudHashBytes);
            }
        }

        public static string GenerarHashBase64(string password, out string saltBase64, int iteraciones = IteracionesDefault)
        {
            var salt = GenerarSalt();
            var hash = GenerarHash(password, salt, iteraciones);
            saltBase64 = Convert.ToBase64String(salt);
            return Convert.ToBase64String(hash);
        }

        public static bool Validar(string password, string hashBase64, string saltBase64, int iteraciones = IteracionesDefault)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashBase64) || string.IsNullOrEmpty(saltBase64))
            {
                return false;
            }

            try
            {
                var salt = Convert.FromBase64String(saltBase64);
                var hashEsperado = Convert.FromBase64String(hashBase64);
                var hashGenerado = GenerarHash(password, salt, iteraciones);

                if (hashGenerado.Length != hashEsperado.Length)
                {
                    return false;
                }

                int diferencia = 0;
                for (int i = 0; i < hashGenerado.Length; i++)
                {
                    diferencia |= hashGenerado[i] ^ hashEsperado[i];
                }

                return diferencia == 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
