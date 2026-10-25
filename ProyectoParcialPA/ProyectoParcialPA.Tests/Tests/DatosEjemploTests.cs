using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoParcialPA.Controladores;
using ProyectoParcialPA.Entidades;
using ProyectoParcialPA.Formularios;
using ProyectoParcialPA.Sesiones;

namespace ProyectoParcialPA.Tests
{
    [TestClass]
    [DoNotParallelize]
    public class DatosEjemploTests
    {
        [TestInitialize] public void Preparar()
        {
            LimpiarListas(); TListaUsuario.ReiniciarEstado();
        }
        [TestCleanup] public void Limpiar()
        {
            LimpiarListas(); TListaUsuario.ReiniciarEstado(); SesionActual.CerrarSesion();
        }
        private static void LimpiarListas()
        {
            TListaProducto.ReiniciarEstado(); TListaCliente.ReiniciarEstado(); TListaProveedor.ReiniciarEstado();
            TListaCompra.ReiniciarEstado(); TListaVenta.ReiniciarEstado(); DatosEjemplo.ReiniciarParaPruebas(); SesionActual.CerrarSesion();
        }
        private static void Admin() { Assert.IsNotNull(TListaUsuario.Login("admin", "Admin123*")); }

        [TestMethod] public void EjemplosRespetanRolesYCompletanLosModulos()
        {
            string mensaje;
            Assert.IsFalse(DatosEjemplo.Cargar(out mensaje));
            Assert.IsNotNull(TListaUsuario.Login("vendedor", "Vendedor123*"));
            Assert.IsFalse(DatosEjemplo.Cargar(out mensaje));
            Admin(); Assert.IsTrue(DatosEjemplo.Cargar(out mensaje), mensaje);
            Assert.AreEqual(24, TListaProducto.ObtenerTodos().Count);
            Assert.AreEqual(6, TListaCliente.ObtenerTodos().Count);
            Assert.AreEqual(4, TListaProveedor.ObtenerTodos().Count);
            Assert.AreEqual(4, TListaUsuario.Usuarios.Count);
            Assert.AreEqual(3, TListaCompra.ObtenerTodos().Count);
            Assert.AreEqual(3, TListaVenta.ObtenerTodos().Count);
            Assert.IsTrue(TListaProducto.ObtenerTodos().All(p => p.Stock > 0));
            Assert.AreEqual(12, TListaProducto.ObtenerTodos().Select(p => p.GetType()).Distinct().Count());
        }

        [TestMethod] public void StockProvieneDelHistorialYRepetirCargaConservaCambios()
        {
            Admin(); string mensaje; Assert.IsTrue(DatosEjemplo.Cargar(out mensaje), mensaje);
            var productos = TListaProducto.ObtenerTodos();
            foreach (var p in productos)
            {
                int entradas = TListaCompra.ObtenerTodos().SelectMany(c => c.Detalles).Where(d => d.CodigoProducto == p.Codigo).Sum(d => d.Cantidad);
                int salidas = TListaVenta.ObtenerTodos().SelectMany(v => v.Detalles).Where(d => d.CodigoProducto == p.Codigo).Sum(d => d.Cantidad);
                Assert.AreEqual(entradas - salidas, p.Stock, p.Codigo);
            }
            Assert.AreEqual(276L, productos.Sum(p => (long)p.Stock));
            var cliente = TListaCliente.ObtenerTodos()[0]; cliente.Nombre = "Nombre cambiado";
            Assert.IsTrue(TListaCliente.ActualizarCliente(cliente, out mensaje), mensaje);
            Assert.IsTrue(DatosEjemplo.Cargar(out mensaje));
            Assert.AreEqual(24, TListaProducto.ObtenerTodos().Count);
            Assert.AreEqual(3, TListaCompra.ObtenerTodos().Count); Assert.AreEqual(3, TListaVenta.ObtenerTodos().Count);
            Assert.AreEqual(276L, TListaProducto.ObtenerTodos().Sum(p => (long)p.Stock));
            Assert.AreEqual("Nombre cambiado", TListaCliente.BuscarPorId(cliente.Id).Nombre);
            Assert.IsTrue(TListaCompra.ObtenerTodos().All(c => c.Confirmada && c.Usuario.NombreUsuario == "admin"));
            Assert.IsTrue(TListaVenta.ObtenerTodos().All(v => v.Confirmada && v.Usuario.NombreUsuario == "admin"));
        }

        [TestMethod] public void InicioPreparaDemoPeroExigeAutenticacionDelUsuario()
        {
            string mensaje; Assert.IsTrue(DatosEjemplo.PrepararInicio(out mensaje), mensaje);
            Assert.IsFalse(SesionActual.EstaAutenticado);
            Assert.IsFalse(TListaUsuario.TienePermiso("GestionarProductos"));
            Assert.IsNotNull(TListaUsuario.Login("vendedor", "Vendedor123*"));
            Assert.AreEqual(24, TListaProducto.ObtenerTodos().Count);
            Assert.AreEqual(3, TListaVenta.ObtenerTodos().Count);
            Assert.IsFalse(TListaUsuario.TienePermiso("GestionarUsuarios"));
        }

        [TestMethod] public void NoReemplazaNiIntroduceMovimientosParaUnProductoExistente()
        {
            Admin(); string mensaje;
            Assert.IsTrue(TListaProducto.AgregarProducto(new Teclado("PC001", "Mi teclado", 80m, "Mi marca", "Mecánico"), out mensaje));
            Assert.IsTrue(DatosEjemplo.Cargar(out mensaje), mensaje);
            var original = TListaProducto.BuscarPorCodigo("PC001");
            Assert.AreEqual("Mi teclado", original.Nombre); Assert.AreEqual(80m, original.Precio); Assert.AreEqual(0, original.Stock);
            Assert.IsFalse(TListaCompra.ObtenerTodos().SelectMany(c => c.Detalles).Any(d => d.CodigoProducto == "PC001"));
            Assert.IsFalse(TListaVenta.ObtenerTodos().SelectMany(v => v.Detalles).Any(d => d.CodigoProducto == "PC001"));
        }

        [TestMethod] public void PrepararInicioConservaLaSesionQueYaEstabaActiva()
        {
            Assert.IsNotNull(TListaUsuario.Login("vendedor", "Vendedor123*"));
            string mensaje; Assert.IsFalse(DatosEjemplo.PrepararInicio(out mensaje));
            Assert.AreEqual("vendedor", SesionActual.UsuarioActual.NombreUsuario);
            Assert.IsFalse(DatosEjemplo.EstanCargados);
            Assert.AreEqual(0, TListaProducto.ObtenerTodos().Count);
        }

        [TestMethod] public void PlantillasDeLosDoceTiposSonValidasYSoloPreparanBorradores()
        {
            Admin(); var tipos = DatosEjemplo.CrearCatalogo().Select(p => p.GetType().Name).Distinct().ToList();
            foreach (string tipo in tipos)
            {
                var ejemplo = EjemplosFormulario.Producto(tipo);
                Assert.AreEqual(0, ejemplo.Validar().Count, tipo); Assert.AreEqual(0, ejemplo.Stock); Assert.IsTrue(ejemplo.Activo);
            }
            Assert.AreEqual(12, tipos.Count); Assert.AreEqual(0, TListaProducto.ObtenerTodos().Count);
        }

        [TestMethod] public void CodigoDeLaPlantillaNoColisionaConProductosActivosOInactivos()
        {
            Admin(); string mensaje; var primero = EjemplosFormulario.Producto("Teclado");
            Assert.IsTrue(TListaProducto.AgregarProducto(primero, out mensaje));
            Assert.IsTrue(TListaProducto.DesactivarProducto(primero.Codigo, out mensaje));
            var segundo = EjemplosFormulario.Producto("Teclado"); Assert.AreNotEqual(primero.Codigo, segundo.Codigo);
            Assert.IsTrue(TListaProducto.AgregarProducto(segundo, out mensaje));
            var tercero = EjemplosFormulario.Producto("Teclado"); Assert.AreNotEqual(segundo.Codigo, tercero.Codigo);
        }
    }
}
