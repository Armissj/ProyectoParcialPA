using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoParcialPA.Controladores;
using ProyectoParcialPA.Entidades;
using ProyectoParcialPA.Sesiones;
using ProyectoParcialPA.Utilidades;

namespace ProyectoParcialPA.Tests
{
    [TestClass]
    [DoNotParallelize]
    public class UsuarioTests
    {
        [TestInitialize]
        public void InicializarEstado()
        {
            TListaUsuario.ReiniciarEstado();
            SesionActual.CerrarSesion();
        }

        [TestCleanup]
        public void LimpiarEstado()
        {
            TListaUsuario.ReiniciarEstado();
            SesionActual.CerrarSesion();
        }

        private static void AssertArgumentException(Action accion)
        {
            try
            {
                accion();
                Assert.Fail("Se esperaba ArgumentException.");
            }
            catch (ArgumentException)
            {
            }
        }

        private static void ResetearUsuariosSinUsarReiniciarEstado()
        {
            var campoUsuarios = typeof(TListaUsuario).GetField("_usuarios", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            campoUsuarios.SetValue(null, null);
            SesionActual.CerrarSesion();
        }

        [TestMethod]
        public void LoginCorrectoAutenticaYGuardaSesion()
        {
            var usuario = TListaUsuario.Login("admin", "Admin123*");
            Assert.IsNotNull(usuario);
            Assert.AreEqual(RolUsuario.Administrador, usuario.Rol);
            Assert.IsTrue(SesionActual.EstaAutenticado);
            Assert.AreEqual("admin", SesionActual.UsuarioActual.NombreUsuario);
        }

        [TestMethod]
        public void LoginSinAccederAUsuariosInicializaCuentasDemo()
        {
            ResetearUsuariosSinUsarReiniciarEstado();
            var usuario = TListaUsuario.Login("admin", "Admin123*");
            Assert.IsNotNull(usuario);
            Assert.AreEqual("admin", usuario.NombreUsuario);

            var campoUsuarios = typeof(TListaUsuario).GetField("_usuarios", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            var usuarios = campoUsuarios.GetValue(null) as System.Collections.Generic.List<Usuario>;
            Assert.IsNotNull(usuarios);
            Assert.AreEqual(2, usuarios.Count);
            Assert.IsTrue(usuarios.Any(u => string.Equals(u.NombreUsuario, "admin", StringComparison.OrdinalIgnoreCase)));
            Assert.IsTrue(usuarios.Any(u => string.Equals(u.NombreUsuario, "vendedor", StringComparison.OrdinalIgnoreCase)));
        }

        [TestMethod]
        public void LoginConContrasenaIncorrectaFalla()
        {
            var usuario = TListaUsuario.Login("admin", "PasswordIncorrecta");
            Assert.IsNull(usuario);
            Assert.IsFalse(SesionActual.EstaAutenticado);
        }

        [TestMethod]
        public void LoginDeUsuarioInactivoFalla()
        {
            var admin = TListaUsuario.Login("admin", "Admin123*");
            Assert.IsNotNull(admin);

            var usuario = TListaUsuario.BuscarPorNombreUsuario("admin");
            Assert.IsNotNull(usuario);

            var segundoAdmin = new Usuario(99, "admin2", "Admin456*", RolUsuario.Administrador, true);
            Assert.IsTrue(TListaUsuario.AgregarUsuario(segundoAdmin));
            Assert.IsTrue(TListaUsuario.DesactivarUsuario(usuario.Id));

            var resultado = TListaUsuario.Login("admin", "Admin123*");
            Assert.IsNull(resultado);
            Assert.IsFalse(SesionActual.EstaAutenticado);
        }

        [TestMethod]
        public void ContrasenasIgualesGeneranHashYSaltDistintos()
        {
            var hash1 = SeguridadPassword.GenerarHashBase64("MismaClave123*", out var salt1);
            var hash2 = SeguridadPassword.GenerarHashBase64("MismaClave123*", out var salt2);

            Assert.AreNotEqual(salt1, salt2);
            Assert.AreNotEqual(hash1, hash2);
            Assert.IsTrue(SeguridadPassword.Validar("MismaClave123*", hash1, salt1, SeguridadPassword.IteracionesDefault));
            Assert.IsTrue(SeguridadPassword.Validar("MismaClave123*", hash2, salt2, SeguridadPassword.IteracionesDefault));
        }

        [TestMethod]
        public void NombresDeUsuarioDuplicadosSeRechazanIgnorandoMayusculasYEspacios()
        {
            var admin = TListaUsuario.Login("admin", "Admin123*");
            Assert.IsNotNull(admin);

            var usuario = new Usuario(99, " juan ", "Pass123*", RolUsuario.Vendedor);
            var agregado = TListaUsuario.AgregarUsuario(usuario);
            Assert.IsTrue(agregado);

            var duplicado = new Usuario(100, "JUAN", "Pass456*", RolUsuario.Vendedor);
            var agregadoDuplicado = TListaUsuario.AgregarUsuario(duplicado);
            Assert.IsFalse(agregadoDuplicado);
        }

        [TestMethod]
        public void AgregarUsuarioRechazaNombreDuplicadoSinImportarElIdRecibido()
        {
            var admin = TListaUsuario.Login("admin", "Admin123*");
            Assert.IsNotNull(admin);

            var usuariosAntes = TListaUsuario.Usuarios.Count;
            var duplicado = new Usuario(1, " ADMIN ", "OtraClave456*", RolUsuario.Vendedor);
            var agregado = TListaUsuario.AgregarUsuario(duplicado);

            Assert.IsFalse(agregado);
            Assert.AreEqual(usuariosAntes, TListaUsuario.Usuarios.Count);
        }

        [TestMethod]
        public void UsuarioRechazaPasswordsNulasVaciasOConSoloEspacios()
        {
            AssertArgumentException(() => new Usuario(10, "juan", null, RolUsuario.Vendedor));
            AssertArgumentException(() => new Usuario(11, "juan", string.Empty, RolUsuario.Vendedor));
            AssertArgumentException(() => new Usuario(12, "juan", "   ", RolUsuario.Vendedor));

            var admin = TListaUsuario.Login("admin", "Admin123*");
            Assert.IsNotNull(admin);

            var usuario = TListaUsuario.BuscarPorNombreUsuario("admin");
            Assert.IsNotNull(usuario);

            var passwordAnterior = usuario.PasswordHash;
            AssertArgumentException(() => usuario.CambiarPassword(null));
            AssertArgumentException(() => usuario.CambiarPassword(string.Empty));
            AssertArgumentException(() => usuario.CambiarPassword("   "));
            Assert.AreEqual(passwordAnterior, usuario.PasswordHash);
            Assert.IsTrue(TListaUsuario.ValidarCredenciales("admin", "Admin123*"));

            Assert.IsFalse(TListaUsuario.CambiarPassword(admin.Id, null));
            Assert.IsFalse(TListaUsuario.CambiarPassword(admin.Id, string.Empty));
            Assert.IsFalse(TListaUsuario.CambiarPassword(admin.Id, "   "));
            Assert.IsTrue(TListaUsuario.ValidarCredenciales("admin", "Admin123*"));

            var claveExacta = "  P@ss 123*  ";
            var resultado = TListaUsuario.CambiarPassword(admin.Id, claveExacta);
            Assert.IsTrue(resultado);
            Assert.IsTrue(TListaUsuario.ValidarCredenciales("admin", claveExacta));
            Assert.IsFalse(TListaUsuario.ValidarCredenciales("admin", "P@ss 123*"));
        }

        [TestMethod]
        public void GestionarProveedoresPermiteSoloAlAdministrador()
        {
            Assert.IsFalse(TListaUsuario.TienePermiso("GestionarProveedores"));

            var admin = TListaUsuario.Login("admin", "Admin123*");
            Assert.IsNotNull(admin);
            Assert.IsTrue(TListaUsuario.TienePermiso("GestionarProveedores"));

            TListaUsuario.CerrarSesion();
            var vendedor = TListaUsuario.Login("vendedor", "Vendedor123*");
            Assert.IsNotNull(vendedor);
            Assert.IsFalse(TListaUsuario.TienePermiso("GestionarProveedores"));

            TListaUsuario.CerrarSesion();
            Assert.IsFalse(TListaUsuario.TienePermiso("GestionarProveedores"));
        }

        [TestMethod]
        public void SesionActualNoAceptaUsuarioInventado()
        {
            var inventado = new Usuario(999, "intruso", "NoVale123*", RolUsuario.Vendedor);
            SesionActual.IniciarSesion(inventado);
            Assert.IsFalse(SesionActual.EstaAutenticado);
            Assert.IsNull(SesionActual.UsuarioActual);
        }

        [TestMethod]
        public void PermisosSegunRolYSesionActual()
        {
            var admin = TListaUsuario.Login("admin", "Admin123*");
            Assert.IsTrue(TListaUsuario.TienePermiso("AgregarUsuario"));
            Assert.IsTrue(TListaUsuario.TienePermiso("ActualizarUsuario"));
            Assert.IsTrue(TListaUsuario.TienePermiso("RegistrarCompra"));
            Assert.IsTrue(TListaUsuario.TienePermiso("ConsultarProductos"));
            Assert.IsTrue(TListaUsuario.TienePermiso("GestionarProveedores"));

            TListaUsuario.CerrarSesion();
            Assert.IsFalse(TListaUsuario.TienePermiso("AgregarUsuario"));

            var vendedor = TListaUsuario.Login("vendedor", "Vendedor123*");
            Assert.IsTrue(TListaUsuario.TienePermiso("ConsultarProductos"));
            Assert.IsTrue(TListaUsuario.TienePermiso("RegistrarCompra"));
            Assert.IsTrue(TListaUsuario.TienePermiso("RegistrarVenta"));
            Assert.IsFalse(TListaUsuario.TienePermiso("AgregarUsuario"));
            Assert.IsFalse(TListaUsuario.TienePermiso("GestionarProductos"));
            Assert.IsFalse(TListaUsuario.TienePermiso("AccionDesconocida"));
            Assert.IsFalse(TListaUsuario.TienePermiso("ActualizarUsuario"));
            Assert.IsFalse(TListaUsuario.TienePermiso("CambiarPassword"));
            Assert.IsFalse(TListaUsuario.TienePermiso("GestionarProveedores"));

            TListaUsuario.CerrarSesion();
            Assert.IsFalse(TListaUsuario.TienePermiso("RegistrarCompra"));
        }

        [TestMethod]
        public void UltimoAdministradorActivoNoPuedeDesactivarseNiCambiarARolVendedor()
        {
            var login = TListaUsuario.Login("admin", "Admin123*");
            Assert.IsNotNull(login);
            Assert.IsTrue(SesionActual.EstaAutenticado);

            var admin = TListaUsuario.BuscarPorNombreUsuario("admin");
            Assert.IsNotNull(admin);
            Assert.AreEqual(RolUsuario.Administrador, admin.Rol);
            Assert.IsTrue(admin.Activo);

            var desactivar = TListaUsuario.DesactivarUsuario(admin.Id);
            Assert.IsFalse(desactivar);

            var cambioRol = TListaUsuario.ActualizarRol(admin.Id, RolUsuario.Vendedor);
            Assert.IsFalse(cambioRol);

            var actual = TListaUsuario.BuscarPorNombreUsuario("admin");
            Assert.IsNotNull(actual);
            Assert.AreEqual(RolUsuario.Administrador, actual.Rol);
            Assert.IsTrue(actual.Activo);
            Assert.IsTrue(SesionActual.EstaAutenticado);
        }

        [TestMethod]
        public void VendedorNoPuedeCambiarPasswordDeAdministrador()
        {
            var vendedor = TListaUsuario.Login("vendedor", "Vendedor123*");
            Assert.IsNotNull(vendedor);

            var admin = TListaUsuario.BuscarPorNombreUsuario("admin");
            Assert.IsNotNull(admin);

            var resultado = TListaUsuario.CambiarPassword(admin.Id, "NuevaPass456*");
            Assert.IsFalse(resultado);
            Assert.IsTrue(TListaUsuario.ValidarCredenciales("admin", "Admin123*"));
        }

        [TestMethod]
        public void ActualizarUsuarioNoPuedeDesactivarUltimoAdministrador()
        {
            var admin = TListaUsuario.Login("admin", "Admin123*");
            Assert.IsNotNull(admin);

            var actualizado = TListaUsuario.BuscarPorNombreUsuario("admin");
            actualizado.Activo = false;

            var resultado = TListaUsuario.ActualizarUsuario(actualizado);
            Assert.IsFalse(resultado);
            Assert.IsTrue(TListaUsuario.ValidarCredenciales("admin", "Admin123*"));
        }

        [TestMethod]
        public void CerrarSesionConservaUsuariosYNoDuplicaCuentasDemo()
        {
            var admin = TListaUsuario.Login("admin", "Admin123*");
            Assert.IsNotNull(admin);

            TListaUsuario.CerrarSesion();
            var usuarios = TListaUsuario.Usuarios;

            Assert.AreEqual(2, usuarios.Count);
            Assert.AreEqual(1, usuarios.Count(u => string.Equals(u.NombreUsuario, "admin", StringComparison.OrdinalIgnoreCase)));
            Assert.AreEqual(1, usuarios.Count(u => string.Equals(u.NombreUsuario, "vendedor", StringComparison.OrdinalIgnoreCase)));
            Assert.IsFalse(SesionActual.EstaAutenticado);
        }
    }
}
