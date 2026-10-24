using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoParcialPA.Entidades;

namespace ProyectoParcialPA.Tests
{
    [TestClass]
    public class ProductoTests
    {
        [TestMethod]
        public void CodigoSeNormalizaEnMayusculasYSinEspacios()
        {
            var teclado = new Teclado(" pc001 ", "Teclado Gamer", 149.99m, "Logitech", "Mecánico");

            Assert.AreEqual("PC001", teclado.Codigo);
        }

        [TestMethod]
        public void TecladoValidoDevuelveCeroErrores()
        {
            var teclado = new Teclado("TK01", "Teclado Gamer", 149.99m, "Logitech", "Mecánico");

            var errores = teclado.Validar();

            Assert.AreEqual(0, errores.Count);
        }

        [TestMethod]
        public void PrecioNegativoSeRechaza()
        {
            var teclado = new Teclado("TK02", "Teclado Gamer", -10.00m, "Logitech", "Mecánico");

            var errores = teclado.Validar();

            Assert.IsTrue(errores.Contains("El precio debe ser mayor a cero."));
        }

        [TestMethod]
        public void CamposObligatoriosSeValidanSeparadamenteConNullVacioYEspacios()
        {
            var valoresInvalidos = new[] { null, string.Empty, "   " };

            foreach (var valor in valoresInvalidos)
            {
                AssertCampoObligatorio(valor, "Teclado Gamer", "Logitech", "Mecánico", "El código es obligatorio.");
                AssertCampoObligatorio("TK03", valor, "Logitech", "Mecánico", "El nombre es obligatorio.");
                AssertCampoObligatorio("TK04", "Teclado Gamer", valor, "Mecánico", "La marca es obligatoria.");
                AssertCampoObligatorio("TK05", "Teclado Gamer", "Logitech", valor, "El tipo es obligatorio.");
            }
        }

        [TestMethod]
        public void PrecioDebeSerMayorACeroYConMaximoDosDecimales()
        {
            var precioCero = new Teclado("TK06", "Teclado", 0m, "Logitech", "Mecánico");
            var erroresPrecioCero = precioCero.Validar();

            Assert.IsTrue(erroresPrecioCero.Contains("El precio debe ser mayor a cero."));

            var precioConMasDecimales = new Teclado("TK07", "Teclado", 18.999m, "Logitech", "Mecánico");
            var erroresMasDecimales = precioConMasDecimales.Validar();

            Assert.IsTrue(erroresMasDecimales.Contains("El precio debe tener máximo dos decimales."));
        }

        [TestMethod]
        public void ProductosNuevosEmpiezanConStockCeroYActivos()
        {
            var teclado = new Teclado();

            Assert.AreEqual(0, teclado.Stock);
            Assert.IsTrue(teclado.Activo);

            var tecladoPersistente = new Teclado("TK08", "Teclado", 129.90m, "Redragon", "Mecánico");
            Assert.AreEqual(0, tecladoPersistente.Stock);
            Assert.IsTrue(tecladoPersistente.Activo);
        }

        [TestMethod]
        public void AmbosConstructoresDeTecladoMantienenStockCeroYActivoVerdadero()
        {
            var tecladoPorDefecto = new Teclado();
            var tecladoParametrizado = new Teclado("TK09", "Teclado", 99.99m, "Redragon", "Mecánico");

            Assert.AreEqual(0, tecladoPorDefecto.Stock);
            Assert.IsTrue(tecladoPorDefecto.Activo);

            Assert.AreEqual(0, tecladoParametrizado.Stock);
            Assert.IsTrue(tecladoParametrizado.Activo);
        }

        private static void AssertCampoObligatorio(string codigo, string nombre, string marca, string tipo, string mensajeEsperado)
        {
            var teclado = new Teclado(codigo, nombre, 49.99m, marca, tipo);
            var errores = teclado.Validar();

            Assert.IsTrue(errores.Contains(mensajeEsperado),
                "Se esperaba el error '" + mensajeEsperado + "' para los valores: codigo=" + (codigo ?? "<null>") + ", nombre=" + (nombre ?? "<null>") + ", marca=" + (marca ?? "<null>") + ", tipo=" + (tipo ?? "<null>") + ". Errores: " + string.Join(", ", errores));
        }
    }
}
