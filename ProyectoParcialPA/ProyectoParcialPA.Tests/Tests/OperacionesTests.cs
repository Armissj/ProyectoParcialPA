using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoParcialPA.Controladores;
using ProyectoParcialPA.Entidades;
using ProyectoParcialPA.Sesiones;

namespace ProyectoParcialPA.Tests
{
    [TestClass]
    [DoNotParallelize]
    public class OperacionesTests
    {
        private Producto producto;
        private Producto segundo;
        private Cliente cliente;
        private Proveedor proveedor;
        [TestInitialize]
        public void Preparar()
        {
            Limpiar(); Assert.IsNotNull(TListaUsuario.Login("admin", "Admin123*"));
            TListaCliente.AgregarCliente(new Cliente(0, "Ana", "Pérez", "Dirección Demo", "0991234567", "ana@example.com"));
            TListaProveedor.AgregarProveedor(new Proveedor(0, "Proveedor Demo", "Contacto", "0991234567", "proveedor@example.com"));
            cliente = TListaCliente.ObtenerTodos()[0]; proveedor = TListaProveedor.ObtenerTodos()[0];
            string mensaje;
            TListaProducto.AgregarProducto(new Teclado("PC001", "Teclado Demo", 25.50m, "Marca", "Mecánico"), out mensaje);
            TListaProducto.AgregarProducto(new Mouse("PC002", "Mouse Demo", 10m, "Marca", 1000), out mensaje);
            producto = TListaProducto.BuscarPorCodigo("PC001"); segundo = TListaProducto.BuscarPorCodigo("PC002");
        }
        [TestCleanup] public void Limpiar()
        {
            TListaCompra.ReiniciarEstado(); TListaVenta.ReiniciarEstado(); TListaProducto.ReiniciarEstado(); TListaCliente.ReiniciarEstado(); TListaProveedor.ReiniciarEstado(); SesionActual.CerrarSesion();
        }
        private Compra BorradorCompra(int cantidad = 5, decimal costo = 18m, Producto p = null)
        {
            var c = new Compra { Proveedor = proveedor }; c.Detalles.Add(new DetalleCompra(p ?? producto, cantidad, costo)); return c;
        }
        private Compra Comprar(int cantidad = 5, decimal costo = 18m, Producto p = null)
        {
            var c = BorradorCompra(cantidad, costo, p); string mensaje; Assert.IsTrue(TListaCompra.RegistrarCompra(c, out mensaje), mensaje); return c;
        }
        private Venta BorradorVenta(int cantidad = 2, decimal precio = 25.50m)
        {
            var v = new Venta { Cliente = cliente }; v.Detalles.Add(new DetalleVenta(producto, cantidad, precio)); return v;
        }

        [TestMethod] public void CompraConfirmadaAumentaStockYRegistraTotal()
        {
            var c = Comprar(); Assert.AreEqual(5, TListaProducto.BuscarPorCodigo("PC001").Stock); Assert.AreEqual(90m, c.Total);
            Assert.IsTrue(c.Confirmada); Assert.AreEqual(1, c.Id); Assert.AreEqual("admin", c.Usuario.NombreUsuario); Assert.AreEqual(1, TListaCompra.ObtenerTodos().Count);
        }
        [TestMethod] public void CompraConLineaInvalidaNoAplicaNingunaParte()
        {
            var c = BorradorCompra(); c.Detalles.Add(new DetalleCompra(segundo, -1, 5m)); string mensaje;
            Assert.IsFalse(TListaCompra.RegistrarCompra(c, out mensaje)); Assert.AreEqual(0, TListaProducto.BuscarPorCodigo("PC001").Stock);
            Assert.AreEqual(0, TListaCompra.ObtenerTodos().Count); Assert.IsFalse(c.Confirmada); Assert.AreEqual(0, c.Id);
        }
        [TestMethod] public void CompraVaciaONulaSeRechaza()
        {
            string mensaje; Assert.IsFalse(TListaCompra.RegistrarCompra(new Compra { Proveedor = proveedor }, out mensaje));
            Assert.IsFalse(TListaCompra.RegistrarCompra(null, out mensaje)); Assert.AreEqual(0, TListaCompra.ObtenerTodos().Count);
        }
        [TestMethod] public void DobleConfirmacionDeCompraNoDuplicaStockNiHistorial()
        {
            var c = Comprar(); string mensaje; Assert.IsFalse(TListaCompra.RegistrarCompra(c, out mensaje));
            var copia = TListaCompra.ObtenerTodos()[0]; copia.Confirmada = false;
            Assert.IsFalse(TListaCompra.RegistrarCompra(copia, out mensaje)); Assert.AreEqual(5, TListaProducto.BuscarPorCodigo("PC001").Stock); Assert.AreEqual(1, TListaCompra.ObtenerTodos().Count);
        }
        [TestMethod] public void VentaConfirmadaDescuentaStockYConservaPrecioDeVenta()
        {
            Comprar(); var v = BorradorVenta(); string mensaje; Assert.IsTrue(TListaVenta.RegistrarVenta(v, out mensaje), mensaje);
            Assert.AreEqual(3, TListaProducto.BuscarPorCodigo("PC001").Stock); Assert.AreEqual(51m, v.Total); Assert.AreEqual(25.50m, TListaProducto.BuscarPorCodigo("PC001").Precio);
        }
        [TestMethod] public void LineasRepetidasSeSumanParaValidarElStockAunqueTenganPreciosDistintos()
        {
            Comprar(); var v = BorradorVenta(3, 25m); v.Detalles.Add(new DetalleVenta(producto, 3, 24m)); string mensaje;
            Assert.IsFalse(TListaVenta.RegistrarVenta(v, out mensaje)); Assert.AreEqual(5, TListaProducto.BuscarPorCodigo("PC001").Stock); Assert.AreEqual(0, TListaVenta.ObtenerTodos().Count);
        }
        [TestMethod] public void VentaConUnaLineaInvalidaConservaTodosLosStocks()
        {
            Comprar(); Comprar(5, 5m, segundo); var v = BorradorVenta(); v.Detalles.Add(new DetalleVenta(segundo, 0, 10m)); string mensaje;
            Assert.IsFalse(TListaVenta.RegistrarVenta(v, out mensaje)); Assert.AreEqual(5, TListaProducto.BuscarPorCodigo("PC001").Stock); Assert.AreEqual(5, TListaProducto.BuscarPorCodigo("PC002").Stock);
        }
        [TestMethod] public void DobleConfirmacionDeVentaNoDescuentaOtraVez()
        {
            Comprar(); var v = BorradorVenta(); string mensaje; Assert.IsTrue(TListaVenta.RegistrarVenta(v, out mensaje));
            Assert.IsFalse(TListaVenta.RegistrarVenta(v, out mensaje)); Assert.AreEqual(3, TListaProducto.BuscarPorCodigo("PC001").Stock); Assert.AreEqual(1, TListaVenta.ObtenerTodos().Count);
        }
        [TestMethod] public void VentaVaciaYPreciosInvalidosSeRechazan()
        {
            Comprar(); string mensaje; Assert.IsFalse(TListaVenta.RegistrarVenta(new Venta { Cliente = cliente }, out mensaje));
            Assert.IsFalse(TListaVenta.RegistrarVenta(BorradorVenta(1, 0m), out mensaje));
            Assert.IsFalse(TListaVenta.RegistrarVenta(BorradorVenta(1, 1.001m), out mensaje)); Assert.AreEqual(5, TListaProducto.BuscarPorCodigo("PC001").Stock);
        }
        [TestMethod] public void CostosConTresDecimalesYDetalleNuloSeRechazan()
        {
            string mensaje; Assert.IsFalse(TListaCompra.RegistrarCompra(BorradorCompra(1, 1.001m), out mensaje));
            var c = BorradorCompra(); c.Detalles.Add(null); Assert.IsFalse(TListaCompra.RegistrarCompra(c, out mensaje)); Assert.AreEqual(0, TListaProducto.BuscarPorCodigo("PC001").Stock);
        }
        [TestMethod] public void DesbordamientoDeStockRechazaLaCompraCompleta()
        {
            Comprar(int.MaxValue, 1m, segundo); var c = BorradorCompra(2, 1m); c.Detalles.Add(new DetalleCompra(segundo, 1, 1m)); string mensaje;
            Assert.IsFalse(TListaCompra.RegistrarCompra(c, out mensaje)); Assert.AreEqual(0, TListaProducto.BuscarPorCodigo("PC001").Stock);
            Assert.AreEqual(int.MaxValue, TListaProducto.BuscarPorCodigo("PC002").Stock); Assert.AreEqual(1, TListaCompra.ObtenerTodos().Count);
        }
        [TestMethod] public void DesbordamientoDeImporteNoModificaStockNiHistorial()
        {
            string mensaje; Assert.IsFalse(TListaCompra.RegistrarCompra(BorradorCompra(2, decimal.MaxValue), out mensaje)); Assert.AreEqual(0, TListaProducto.BuscarPorCodigo("PC001").Stock); Assert.AreEqual(0, TListaCompra.ObtenerTodos().Count);
        }
        [TestMethod] public void HistorialConservaNombresPreciosClienteYProveedorOriginales()
        {
            Comprar(); string mensaje; var v = BorradorVenta(); TListaVenta.RegistrarVenta(v, out mensaje);
            TListaProducto.ActualizarProducto("PC001", new Teclado("PC001", "Nombre nuevo", 99m, "Otra", "Membrana"), out mensaje);
            var c = TListaCliente.BuscarPorId(cliente.Id); c.Nombre = "Nombre distinto"; TListaCliente.ActualizarCliente(c);
            var p = TListaProveedor.BuscarPorId(proveedor.Id); p.Nombre = "Otro proveedor"; TListaProveedor.ActualizarProveedor(p);
            Assert.AreEqual("Teclado Demo", TListaVenta.ObtenerTodos()[0].Detalles[0].NombreProducto);
            Assert.AreEqual(25.50m, TListaVenta.ObtenerTodos()[0].Detalles[0].PrecioUnitario);
            Assert.AreEqual("Ana", TListaVenta.ObtenerTodos()[0].Cliente.Nombre); Assert.AreEqual("Proveedor Demo", TListaCompra.ObtenerTodos()[0].Proveedor.Nombre);
        }
        [TestMethod] public void CopiasDelHistorialNoPermitenMutarloDesdeFuera()
        {
            var c = Comprar(); c.Detalles[0].Cantidad = 999;
            var copia = TListaCompra.ObtenerTodos()[0]; copia.Detalles[0].CostoUnitario = 0m; copia.Proveedor.Nombre = "Externo";
            var actual = TListaCompra.ObtenerTodos()[0]; Assert.AreEqual(5, actual.Detalles[0].Cantidad); Assert.AreEqual(18m, actual.Detalles[0].CostoUnitario); Assert.AreEqual("Proveedor Demo", actual.Proveedor.Nombre);
        }
        [TestMethod] public void VendedorPuedeComprarYVenderYQuedaRegistradoComoResponsable()
        {
            SesionActual.CerrarSesion(); Assert.IsNotNull(TListaUsuario.Login("vendedor", "Vendedor123*"));
            Comprar(); var v = BorradorVenta(); string mensaje; Assert.IsTrue(TListaVenta.RegistrarVenta(v, out mensaje));
            Assert.AreEqual("vendedor", TListaCompra.ObtenerTodos()[0].Usuario.NombreUsuario); Assert.AreEqual("vendedor", TListaVenta.ObtenerTodos()[0].Usuario.NombreUsuario);
        }
        [TestMethod] public void SinSesionNoSeRegistranOperacionesNiSeConsultaElHistorial()
        {
            Comprar(); var v = BorradorVenta(); SesionActual.CerrarSesion(); string mensaje;
            Assert.IsFalse(TListaVenta.RegistrarVenta(v, out mensaje)); Assert.AreEqual(0, TListaCompra.ObtenerTodos().Count);
            Assert.IsNotNull(TListaUsuario.Login("admin", "Admin123*")); Assert.AreEqual(5, TListaProducto.BuscarPorCodigo("PC001").Stock);
        }
        [TestMethod] public void ProveedorInactivoNoPuedeRecibirComprasNuevas()
        {
            TListaProveedor.DesactivarProveedor(proveedor.Id); string mensaje; Assert.IsFalse(TListaCompra.RegistrarCompra(BorradorCompra(), out mensaje)); Assert.AreEqual(0, TListaProducto.BuscarPorCodigo("PC001").Stock);
        }
        [TestMethod] public void ClienteInactivoNoPuedeRecibirVentasNuevas()
        {
            Comprar(); TListaCliente.DesactivarCliente(cliente.Id); string mensaje; Assert.IsFalse(TListaVenta.RegistrarVenta(BorradorVenta(), out mensaje)); Assert.AreEqual(5, TListaProducto.BuscarPorCodigo("PC001").Stock);
        }
        [TestMethod] public void ProductoInactivoNoPuedeEntrarEnMovimientosNuevos()
        {
            Comprar(); string mensaje; TListaProducto.DesactivarProducto("PC001", out mensaje); Assert.IsFalse(TListaVenta.RegistrarVenta(BorradorVenta(), out mensaje)); Assert.AreEqual(5, TListaProducto.ObtenerTodosInactivos()[0].Stock);
        }
        [TestMethod] public void FiltroDeFechasIncluyeLaTardeDelUltimoDiaYRechazaRangoInvertido()
        {
            var c = BorradorCompra(); c.Fecha = DateTime.Today.AddHours(23); string mensaje; Assert.IsTrue(TListaCompra.RegistrarCompra(c, out mensaje));
            Assert.AreEqual(1, TListaCompra.BuscarPorFechas(DateTime.Today, DateTime.Today).Count);
            Assert.AreEqual(0, TListaCompra.BuscarPorFechas(DateTime.Today.AddDays(1), DateTime.Today).Count);
            Assert.AreEqual(1, TListaCompra.BuscarPorFechas(DateTime.MinValue, DateTime.MaxValue).Count);
        }
        [TestMethod] public void BorradorYValidacionNoCambianStockNiRegistranNada()
        {
            var c = new Compra { Proveedor = proveedor }; Assert.IsTrue(TListaCompra.AgregarDetalleCompra(c, producto, 5, 18m)); Assert.IsTrue(TListaCompra.ValidarCompraAntesDeConfirmar(c));
            Assert.AreEqual(0, TListaProducto.BuscarPorCodigo("PC001").Stock); Assert.AreEqual(0, TListaCompra.ObtenerTodos().Count);
        }
        [TestMethod] public void DetallesRepetidosConMismoImporteSeConsolidanYOtrosSeConservan()
        {
            var c = new Compra { Proveedor = proveedor };
            Assert.IsTrue(TListaCompra.AgregarDetalleCompra(c, producto, 2, 10m)); Assert.IsTrue(TListaCompra.AgregarDetalleCompra(c, producto, 3, 10m));
            Assert.IsTrue(TListaCompra.AgregarDetalleCompra(c, producto, 1, 11m)); Assert.AreEqual(2, c.Detalles.Count); Assert.AreEqual(5, c.Detalles[0].Cantidad);
            string mensaje; Assert.IsTrue(TListaCompra.RegistrarCompra(c, out mensaje)); Assert.AreEqual(6, TListaProducto.BuscarPorCodigo("PC001").Stock);
        }
        [TestMethod] public void ProductoConStockCeroSigueTeniendoMovimientosYNoCambiaDeTipo()
        {
            Comprar(); string mensaje; Assert.IsTrue(TListaVenta.RegistrarVenta(BorradorVenta(5), out mensaje));
            Assert.AreEqual(0, TListaProducto.BuscarPorCodigo("PC001").Stock);
            Assert.IsFalse(TListaProducto.ActualizarProducto("PC001", new Mouse("PC001", "Otro tipo", 10m, "Marca", 1000), out mensaje));
        }
        [TestMethod] public void UsuarioRecibidoEnElBorradorNoReemplazaAlUsuarioDeLaSesion()
        {
            var c = BorradorCompra(); c.Usuario = new Usuario { Id = 999, NombreUsuario = "inventado" }; string mensaje;
            Assert.IsTrue(TListaCompra.RegistrarCompra(c, out mensaje)); Assert.AreEqual("admin", TListaCompra.ObtenerTodos()[0].Usuario.NombreUsuario);
        }
        [TestMethod] public void OperacionesDistintasConLosMismosProductosSonValidas()
        {
            var a = Comprar(); var b = Comprar(); Assert.AreNotEqual(a.IdOperacion, b.IdOperacion); Assert.AreEqual(10, TListaProducto.BuscarPorCodigo("PC001").Stock); Assert.AreEqual(2, TListaCompra.ObtenerTodos().Count);
        }
        [TestMethod] public void AgregarDetalleRechazaDesbordamientoDelTotalSinAlterarElBorrador()
        {
            var c = new Compra { Proveedor = proveedor };
            Assert.IsTrue(TListaCompra.AgregarDetalleCompra(c, producto, 1, decimal.MaxValue));
            Assert.IsFalse(TListaCompra.AgregarDetalleCompra(c, segundo, 1, 1m));
            Assert.AreEqual(1, c.Detalles.Count); Assert.AreEqual(decimal.MaxValue, c.Total);
        }
        [TestMethod] public void ResumenAdmiteSumarStocksDeVariosProductosSinDesbordarInt()
        {
            Comprar(int.MaxValue, 1m); Comprar(1, 1m, segundo);
            Assert.AreEqual((long)int.MaxValue + 1L, TListaProducto.ObtenerResumenGeneral().UnidadesTotales);
        }
    }
}
