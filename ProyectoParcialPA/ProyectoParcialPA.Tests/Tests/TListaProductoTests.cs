using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoParcialPA.Controladores;
using ProyectoParcialPA.Entidades;
using ProyectoParcialPA.Sesiones;

namespace ProyectoParcialPA.Tests
{
    [TestClass]
    [DoNotParallelize]
    public class TListaProductoTests
    {
        [TestInitialize]
        public void InicializarEstado()
        {
            TListaProducto.ReiniciarEstado();
            SesionActual.CerrarSesion();
        }

        [TestCleanup]
        public void LimpiarEstado()
        {
            TListaProducto.ReiniciarEstado();
            SesionActual.CerrarSesion();
        }

        private static void IniciarComoAdmin()
        {
            TListaUsuario.ReiniciarEstado();
            var usuario = TListaUsuario.Login("admin", "Admin123*");
            Assert.IsNotNull(usuario);
        }

        private static void IniciarComoVendedor()
        {
            TListaUsuario.ReiniciarEstado();
            var usuario = TListaUsuario.Login("vendedor", "Vendedor123*");
            Assert.IsNotNull(usuario);
        }

        [TestMethod]
        public void AgregarProductoValidoYBuscarPorCodigo()
        {
            IniciarComoAdmin();

            var teclado = new Teclado("PC001", "Teclado Gamer", 149.99m, "Logitech", "Mecánico");
            string mensaje;
            var agregado = TListaProducto.AgregarProducto(teclado, out mensaje);

            Assert.IsTrue(agregado, mensaje);
            Assert.AreEqual("PC001", TListaProducto.BuscarPorCodigo("pc001").Codigo);
            Assert.AreEqual(1, TListaProducto.ObtenerTodos().Count);
        }

        [TestMethod]
        public void DuplicadoPorCodigoRechazaEntreFamilias()
        {
            IniciarComoAdmin();

            string mensaje;
            Assert.IsTrue(TListaProducto.AgregarProducto(new Teclado("PC002", "Teclado", 99.99m, "Logitech", "Mecánico"), out mensaje));
            Assert.IsFalse(TListaProducto.AgregarProducto(new Mouse("PC002", "Mouse", 39.90m, "Razer", 12000), out mensaje));
            Assert.AreEqual(1, TListaProducto.ObtenerTodos().Count);
        }

        [TestMethod]
        public void EditarProductoValidoMantieneStockYActivo()
        {
            IniciarComoAdmin();

            var teclado = new Teclado("PC010", "Teclado", 149.99m, "Logitech", "Mecánico");
            string mensaje;
            Assert.IsTrue(TListaProducto.AgregarProducto(teclado, out mensaje));

            var cambios = new Teclado("PC010", "Teclado RGB", 179.99m, "Redragon", "Mecánico");
            var actualizado = TListaProducto.ActualizarProducto("PC010", cambios, out mensaje);

            Assert.IsTrue(actualizado, mensaje);
            var producto = TListaProducto.BuscarPorCodigo("PC010");
            Assert.AreEqual("Teclado RGB", producto.Nombre);
            Assert.AreEqual(0, producto.Stock);
            Assert.IsTrue(producto.Activo);
        }

        [TestMethod]
        public void EditarProductoConCodigoDistintoOInvalidoNoModificaDatos()
        {
            IniciarComoAdmin();

            var teclado = new Teclado("PC020", "Teclado", 149.99m, "Logitech", "Mecánico");
            string mensaje;
            Assert.IsTrue(TListaProducto.AgregarProducto(teclado, out mensaje));

            var cambios = new Teclado("PC021", "Teclado Nuevo", 200m, "Logitech", "Mecánico");
            var actualizado = TListaProducto.ActualizarProducto("PC020", cambios, out mensaje);
            Assert.IsFalse(actualizado);
            Assert.AreEqual("Teclado", TListaProducto.BuscarPorCodigo("PC020").Nombre);

            var cambiosInvalidos = new Teclado("PC020", " ", 0m, "Logitech", "Mecánico");
            Assert.IsFalse(TListaProducto.ActualizarProducto("PC020", cambiosInvalidos, out mensaje));
            Assert.AreEqual("Teclado", TListaProducto.BuscarPorCodigo("PC020").Nombre);
        }

        [TestMethod]
        public void DesactivarProductoOcultaEnBusquedaNormalYConservaDatos()
        {
            IniciarComoAdmin();

            var teclado = new Teclado("PC030", "Teclado", 120m, "Logitech", "Mecánico");
            string mensaje;
            Assert.IsTrue(TListaProducto.AgregarProducto(teclado, out mensaje));

            Assert.IsTrue(TListaProducto.DesactivarProducto("PC030", out mensaje), mensaje);
            Assert.IsNull(TListaProducto.BuscarPorCodigo("PC030"));
            Assert.AreEqual(0, TListaProducto.ObtenerTodos().Count);
            Assert.AreEqual(1, TListaProducto.ObtenerTodosInactivos().Count);
        }

        [TestMethod]
        public void BusquedaPorTextoYFiltroPorFamiliaIncluyenClasesDerivadas()
        {
            IniciarComoAdmin();

            var teclado = new Teclado("PC040", "Teclado Gamer", 120m, "Logitech", "Mecánico");
            var mouse = new Mouse("MS040", "Mouse Gamer", 50m, "Logitech", 12000);
            var procesador = new Procesador("PR040", "Intel i7", 300m, "Intel", "LGA1700", 8);

            TListaProducto.AgregarProducto(teclado, out _);
            TListaProducto.AgregarProducto(mouse, out _);
            TListaProducto.AgregarProducto(procesador, out _);

            Assert.AreEqual(2, TListaProducto.BuscarPorTexto("gamer").Count);
            Assert.AreEqual(1, TListaProducto.BuscarPorTexto("intel").Count);
            Assert.AreEqual(2, TListaProducto.FiltrarPorTipo("PerifericoPC").Count);
            Assert.AreEqual(1, TListaProducto.FiltrarPorTipo("ComponentePC").Count);
            Assert.AreEqual(1, TListaProducto.FiltrarPorTipo("Teclado").Count);
        }

        [TestMethod]
        public void PermisosRechazanGestionYPermitenConsultaSegunRol()
        {
            Assert.AreEqual(0, TListaProducto.ObtenerTodos().Count);
            Assert.IsFalse(TListaProducto.TienePermisoGestionar());

            IniciarComoVendedor();
            var teclado = new Teclado("PC050", "Teclado", 120m, "Logitech", "Mecánico");
            string mensaje;
            Assert.IsTrue(TListaProducto.TienePermisoConsultar());
            Assert.IsFalse(TListaProducto.AgregarProducto(teclado, out mensaje));
            Assert.AreEqual(0, TListaProducto.ObtenerTodos().Count);

            IniciarComoAdmin();
            Assert.IsTrue(TListaProducto.TienePermisoGestionar());
            Assert.IsTrue(TListaProducto.AgregarProducto(teclado, out mensaje), mensaje);
            Assert.AreEqual(1, TListaProducto.ObtenerTodos().Count);
        }

        [TestMethod]
        public void ProteccionDeObjetosInternosEvitaModificacionesExternas()
        {
            IniciarComoAdmin();

            var teclado = new Teclado("PC060", "Teclado", 120m, "Logitech", "Mecánico");
            string mensaje;
            Assert.IsTrue(TListaProducto.AgregarProducto(teclado, out mensaje));

            var producto = TListaProducto.BuscarPorCodigo("PC060");
            producto.Nombre = "Cambiado desde fuera";
            producto.Precio = 999m;
            var campoStock = typeof(Producto).GetField("_stock", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            campoStock.SetValue(producto, 25);

            var guardado = TListaProducto.BuscarPorCodigo("PC060");
            Assert.AreEqual("Teclado", guardado.Nombre);
            Assert.AreEqual(120m, guardado.Precio);
            Assert.AreEqual(0, guardado.Stock);
        }

        [TestMethod]
        public void ResumenGeneralCalculaProductosUnidadesYValor()
        {
            IniciarComoAdmin();

            var teclado = new Teclado("PC070", "Teclado", 25.50m, "Logitech", "Mecánico");
            var mouse = new Mouse("MS070", "Mouse", 10.00m, "Razer", 15000);

            var campoStock = typeof(Producto).GetField("_stock", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            TListaProducto.AgregarProducto(teclado, out _);
            TListaProducto.AgregarProducto(mouse, out _);
            var internos = (System.Collections.IList)typeof(TListaProducto).GetField("_productos", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).GetValue(null);
            campoStock.SetValue(internos[0], 5);
            campoStock.SetValue(internos[1], 2);

            var resumen = TListaProducto.ObtenerResumenGeneral();
            Assert.AreEqual(2, resumen.CantidadProductos);
            Assert.AreEqual(7, resumen.UnidadesTotales);
            Assert.AreEqual(147.50m, resumen.ValorTotal);
        }

        [TestMethod]
        public void ValidarStockDisponibleYMovimientoBloqueaCambioTipo()
        {
            IniciarComoAdmin();

            var teclado = new Teclado("PC080", "Teclado", 100m, "Logitech", "Mecánico");
            string mensaje;
            Assert.IsTrue(TListaProducto.AgregarProducto(teclado, out mensaje));

            var productos = (System.Collections.IList)typeof(TListaProducto)
                .GetField("_productos", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic)
                .GetValue(null);
            var productoInterno = productos[0];
            var campoStock = typeof(Producto).GetField("_stock", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            campoStock.SetValue(productoInterno, 5);

            Assert.IsTrue(TListaProducto.ValidarStockDisponible("PC080", 4));
            Assert.IsFalse(TListaProducto.ValidarStockDisponible("PC080", 6));

            TListaProducto.RegistrarMovimientoProducto("PC080");
            var cambioTipo = new Mouse("PC080", "Mouse", 99m, "Razer", 5000);
            Assert.IsFalse(TListaProducto.ActualizarProducto("PC080", cambioTipo, out mensaje));

            var sinMovimiento = new Teclado("PC090", "Teclado 2", 100m, "Logitech", "Mecánico");
            TListaProducto.AgregarProducto(sinMovimiento, out _);
            Assert.IsTrue(TListaProducto.ActualizarProducto("PC090", new Mouse("PC090", "Mouse 2", 50m, "Razer", 4000), out mensaje));
        }

        [TestMethod]
        public void CambioDeTipoGuardaRealmenteElNuevoObjetoYCampos()
        {
            IniciarComoAdmin(); string mensaje;
            Assert.IsTrue(TListaProducto.AgregarProducto(new Teclado("TIPO01", "Inicial", 10m, "Marca", "Mecánico"), out mensaje));
            Assert.IsTrue(TListaProducto.ActualizarProducto("TIPO01", new Mouse("TIPO01", "Mouse nuevo", 25m, "Nueva marca", 6400), out mensaje));
            var guardado = TListaProducto.BuscarPorCodigo("TIPO01") as Mouse;
            Assert.IsNotNull(guardado);
            Assert.AreEqual(6400, guardado.Dpi);
            Assert.AreEqual("Mouse nuevo", guardado.Nombre);
            Assert.AreEqual("Nueva marca", guardado.Marca);
            Assert.AreEqual(25m, guardado.Precio);
        }

        [TestMethod]
        public void CerrarSesionImpideConsultarInventarioPreviamenteCargado()
        {
            IniciarComoAdmin(); string mensaje;
            TListaProducto.AgregarProducto(new Teclado("PRIV01", "Privado", 10m, "Marca", "Mecánico"), out mensaje);
            SesionActual.CerrarSesion();
            Assert.AreEqual(0, TListaProducto.ObtenerTodos().Count);
            Assert.AreEqual(0, TListaProducto.ObtenerTodosInactivos().Count);
            Assert.IsNull(TListaProducto.BuscarPorCodigo("PRIV01"));
            Assert.AreEqual(0, TListaProducto.BuscarPorTexto("Privado").Count);
            Assert.AreEqual(0, TListaProducto.FiltrarPorTipo("Teclado").Count);
            Assert.AreEqual(0, TListaProducto.ObtenerResumenGeneral().CantidadProductos);
            Assert.AreEqual(0m, TListaProducto.ObtenerValorInventarioVenta());
            Assert.IsFalse(TListaProducto.ValidarStockDisponible("PRIV01", 1));
        }

        [TestMethod]
        public void AltaSiempreEmpiezaEnCeroAunqueLaCopiaEntranteTengaStock()
        {
            IniciarComoAdmin(); string mensaje;
            var producto = new Mouse("STOCK01", "Mouse", 10m, "Marca", 1000);
            typeof(Producto).GetField("_stock", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(producto, 7);
            Assert.IsTrue(TListaProducto.AgregarProducto(producto, out mensaje));
            Assert.AreEqual(0, TListaProducto.BuscarPorCodigo("STOCK01").Stock);
        }

        [TestMethod]
        public void CodigoDeProductoInactivoTampocoPuedeReutilizarse()
        {
            IniciarComoAdmin(); string mensaje;
            TListaProducto.AgregarProducto(new Mouse("UNICO01", "Mouse", 10m, "Marca", 1000), out mensaje);
            TListaProducto.DesactivarProducto("UNICO01", out mensaje);
            Assert.IsFalse(TListaProducto.AgregarProducto(new Vinilo(" unico01 ", "Disco", 12m, "Artista", "Rap", 2000), out mensaje));
        }

        [TestMethod]
        public void CopiasDeEntradaYListadosNoCambianElProductoGuardado()
        {
            IniciarComoAdmin(); string mensaje;
            var producto = new Mouse("COPIA01", "Original", 10m, "Marca", 1000);
            TListaProducto.AgregarProducto(producto, out mensaje); producto.Nombre = "Externo";
            var copia = (Mouse)TListaProducto.ObtenerTodos()[0]; copia.Dpi = 999; copia.Activo = false;
            var actual = (Mouse)TListaProducto.BuscarPorCodigo("COPIA01");
            Assert.AreEqual("Original", actual.Nombre); Assert.AreEqual(1000, actual.Dpi); Assert.IsTrue(actual.Activo);
        }
    }
}
