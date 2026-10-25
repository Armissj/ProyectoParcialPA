using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoParcialPA.Controladores;
using ProyectoParcialPA.Entidades;
using ProyectoParcialPA.Sesiones;

namespace ProyectoParcialPA.Tests
{
    [TestClass]
    [DoNotParallelize]
    public class PersonasTests
    {
        [TestInitialize]
        public void Preparar()
        {
            TListaCliente.ReiniciarEstado(); TListaProveedor.ReiniciarEstado();
            SesionActual.CerrarSesion(); Assert.IsNotNull(TListaUsuario.Login("admin", "Admin123*"));
        }
        [TestCleanup] public void Limpiar() { TListaCliente.ReiniciarEstado(); TListaProveedor.ReiniciarEstado(); SesionActual.CerrarSesion(); }
        private Cliente ClienteValido() { return new Cliente(0, " Ana ", " Pérez ", "Dirección de ejemplo", "0991234567", "ana@example.com"); }
        private Proveedor ProveedorValido() { return new Proveedor(0, "Proveedor Demo", "Contacto Demo", "0997654321", "proveedor@example.com"); }

        [TestMethod] public void ClienteSeNormalizaYRecibeIdAutomatico()
        {
            var cliente = ClienteValido(); Assert.IsTrue(TListaCliente.AgregarCliente(cliente));
            var guardado = TListaCliente.ObtenerTodos()[0]; Assert.AreEqual(1, guardado.Id); Assert.AreEqual("Ana", guardado.Nombre); Assert.IsTrue(guardado.Activo);
        }
        [TestMethod] public void CopiasDeClienteNoPermitenCambiarElRegistroInterno()
        {
            var cliente = ClienteValido(); TListaCliente.AgregarCliente(cliente); cliente.Nombre = "Externo";
            var copia = TListaCliente.BuscarPorId(1); copia.Email = "otro@example.com";
            Assert.AreEqual("Ana", TListaCliente.BuscarPorId(1).Nombre); Assert.AreEqual("ana@example.com", TListaCliente.BuscarPorId(1).Email);
        }
        [TestMethod] public void EdicionInvalidaNoModificaCliente()
        {
            TListaCliente.AgregarCliente(ClienteValido()); var cambio = TListaCliente.BuscarPorId(1); cambio.Nombre = "";
            Assert.IsFalse(TListaCliente.ActualizarCliente(cambio)); Assert.AreEqual("Ana", TListaCliente.BuscarPorId(1).Nombre);
        }
        [TestMethod] public void DesactivarClienteLoOcultaSinBorrarlo()
        {
            TListaCliente.AgregarCliente(ClienteValido()); Assert.IsTrue(TListaCliente.DesactivarCliente(1));
            Assert.IsNull(TListaCliente.BuscarPorId(1)); Assert.AreEqual(0, TListaCliente.ObtenerTodos().Count); Assert.AreEqual(1, TListaCliente.ObtenerTodos(true).Count);
        }
        [TestMethod] public void EmailYTelefonoInvalidosSeRechazan()
        {
            var c = ClienteValido(); c.Email = "sin-arroba"; Assert.IsFalse(TListaCliente.AgregarCliente(c));
            c = ClienteValido(); c.Telefono = "abcdefg"; Assert.IsFalse(TListaCliente.AgregarCliente(c));
            Assert.AreEqual(0, TListaCliente.ObtenerTodos().Count);
        }
        [TestMethod] public void IdRecibidoEnAltaNoProduceDuplicados()
        {
            var c = ClienteValido(); c.Id = 55; TListaCliente.AgregarCliente(c); TListaCliente.AgregarCliente(c);
            Assert.AreEqual(1, TListaCliente.ObtenerTodos()[0].Id); Assert.AreEqual(2, TListaCliente.ObtenerTodos()[1].Id);
        }
        [TestMethod] public void BusquedaEncuentraApellidoYContactoSinDistinguirMayusculas()
        {
            TListaCliente.AgregarCliente(ClienteValido()); TListaProveedor.AgregarProveedor(ProveedorValido());
            Assert.AreEqual(1, TListaCliente.BuscarPorNombre("PÉREZ").Count); Assert.AreEqual(1, TListaProveedor.BuscarPorNombre("contacto").Count);
        }
        [TestMethod] public void VendedorConsultaProveedoresYGestionaClientesSinModificarProveedores()
        {
            TListaProveedor.AgregarProveedor(ProveedorValido()); SesionActual.CerrarSesion(); Assert.IsNotNull(TListaUsuario.Login("vendedor", "Vendedor123*"));
            Assert.AreEqual(1, TListaProveedor.ObtenerTodos().Count); Assert.IsTrue(TListaCliente.AgregarCliente(ClienteValido()));
            Assert.IsFalse(TListaProveedor.AgregarProveedor(ProveedorValido())); var p = TListaProveedor.BuscarPorId(1); p.Nombre = "No permitido";
            Assert.IsFalse(TListaProveedor.ActualizarProveedor(p)); Assert.IsFalse(TListaProveedor.DesactivarProveedor(1)); Assert.AreEqual("Proveedor Demo", TListaProveedor.BuscarPorId(1).Nombre);
        }
        [TestMethod] public void SinSesionNoSePuedenConsultarNiModificarPersonas()
        {
            TListaCliente.AgregarCliente(ClienteValido()); TListaProveedor.AgregarProveedor(ProveedorValido()); SesionActual.CerrarSesion();
            Assert.AreEqual(0, TListaCliente.ObtenerTodos().Count); Assert.AreEqual(0, TListaProveedor.ObtenerTodos().Count);
            Assert.IsFalse(TListaCliente.AgregarCliente(ClienteValido())); Assert.IsFalse(TListaProveedor.DesactivarProveedor(1));
        }
    }
}
