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

        [TestMethod]
        public void MouseValidoNoGeneraErrores()
        {
            var mouse = new Mouse("MS01", "Mouse Gamer", 59.90m, "Logitech", 16000);

            var errores = mouse.Validar();

            Assert.AreEqual(0, errores.Count);
        }

        [TestMethod]
        public void MonitorPCValidoNoGeneraErrores()
        {
            var monitor = new MonitorPC("MN01", "Monitor 27\"", 249.99m, "Acer", 27.0m, 144);

            var errores = monitor.Validar();

            Assert.AreEqual(0, errores.Count);
        }

        [TestMethod]
        public void ProcesadorYMemoriaValidanCamposObligatorios()
        {
            var procesador = new Procesador("PR01", "Intel i7", 329.99m, "Intel", "LGA1700", 8);
            Assert.AreEqual(0, procesador.Validar().Count);

            var memoria = new MemoriaRAM("RM01", "Corsair 16GB", 149.99m, "Corsair", "16GB", "DDR4");
            Assert.AreEqual(0, memoria.Validar().Count);

            var invalido = new Procesador("PR02", "Intel i5", 299.99m, "Intel", "   ", 0);
            var errores = invalido.Validar();

            Assert.IsTrue(errores.Contains("El socket es obligatorio."));
            Assert.IsTrue(errores.Contains("Los núcleos deben ser mayores a cero."));
        }

        [TestMethod]
        public void EquipoMusicalYViniloValidanCamposObligatorios()
        {
            var microfono = new Microfono("MI01", "Microfono USB", 79.99m, "HyperX", "Condensador");
            Assert.AreEqual(0, microfono.Validar().Count);

            var vinilo = new Vinilo("VI01", "Dark Side of the Moon", 29.99m, "Pink Floyd", "Rock Progresivo", 1973);
            Assert.AreEqual(0, vinilo.Validar().Count);

            var viniloInvalido = new Vinilo("VI02", "Album", 19.99m, "   ", "Rock", 1800);
            var errores = viniloInvalido.Validar();

            Assert.IsTrue(errores.Contains("El artista es obligatorio."));
            Assert.IsTrue(errores.Contains("El año debe estar entre 1900 y el año actual más uno."));
        }

        [TestMethod]
        public void PerifericoConsolaYProductoGamingValidanCamposObligatorios()
        {
            var ps5 = new PerifericoPS5("PS01", "Control DualSense", 69.99m, "Sony", "Control", "PS5");
            Assert.AreEqual(0, ps5.Validar().Count);

            var gaming = new ProductoGaming("PG01", "The Last of Us", 59.99m, "Sony", "PlayStation 5", "Videojuego", true);
            Assert.AreEqual(0, gaming.Validar().Count);

            var gamingInvalido = new ProductoGaming("PG02", "Juego", 19.99m, "   ", "   ", "   ", false);
            var errores = gamingInvalido.Validar();

            Assert.IsTrue(errores.Contains("La marca es obligatoria."));
            Assert.IsTrue(errores.Contains("La plataforma es obligatoria."));
            Assert.IsTrue(errores.Contains("El tipo de artículo es obligatorio."));
        }

        [TestMethod]
        public void ProductoGamingAceptaTiposPermitidosYRechazaOtros()
        {
            var consola = new ProductoGaming("PG10", "PlayStation 5", 499.99m, "Sony", "PlayStation 5", " consola ", false);
            var videojuego = new ProductoGaming("PG11", "The Last of Us", 59.99m, "Sony", "PlayStation 5", " videoJUEGO ", false);
            var accesorio = new ProductoGaming("PG12", "DualSense", 69.99m, "Sony", "PlayStation 5", " ACCESORIO ", false);

            Assert.AreEqual(0, consola.Validar().Count);
            Assert.AreEqual("Consola", consola.TipoArticulo);
            Assert.AreEqual(0, videojuego.Validar().Count);
            Assert.AreEqual("Videojuego", videojuego.TipoArticulo);
            Assert.AreEqual(0, accesorio.Validar().Count);
            Assert.AreEqual("Accesorio", accesorio.TipoArticulo);

            var invalido = new ProductoGaming("PG13", "Juego", 19.99m, "Sony", "PlayStation 5", "Desconocido", false);
            var errores = invalido.Validar();

            Assert.IsTrue(errores.Contains("El tipo de artículo debe ser Consola, Videojuego o Accesorio."));
        }

        [TestMethod]
        public void InterfazAudioDebeTenerAlMenosUnaEntradaOSalidaMayorACero()
        {
            var valida = new InterfazAudio("IA02", "Audio", 89.90m, "Focusrite", 2, 0);
            var erroresValidos = valida.Validar();
            Assert.AreEqual(0, erroresValidos.Count);

            var invalida = new InterfazAudio("IA03", "Audio", 89.90m, "Focusrite", 0, 0);
            var erroresInvalidos = invalida.Validar();
            Assert.IsTrue(erroresInvalidos.Contains("Debe haber al menos una entrada o salida mayor a cero."));

            var negativa = new InterfazAudio("IA04", "Audio", 89.90m, "Focusrite", -1, 2);
            var erroresNegativos = negativa.Validar();
            Assert.IsTrue(erroresNegativos.Contains("Las entradas no pueden ser negativas."));
        }

        [TestMethod]
        public void TarjetaGraficaYPerifericoSwitchValidanCamposYHerencia()
        {
            var tarjeta = new TarjetaGrafica("TG01", "RTX 4070", 649.99m, "NVIDIA", "12GB", "Ada Lovelace");
            Assert.AreEqual(0, tarjeta.Validar().Count);

            var tarjetaSinMemoria = new TarjetaGrafica("TG02", "RTX 3060", 299.99m, "NVIDIA", "   ", "Ampere");
            Assert.IsTrue(tarjetaSinMemoria.Validar().Contains("La memoria es obligatoria."));

            var tarjetaSinChipset = new TarjetaGrafica("TG03", "RTX 3060", 299.99m, "NVIDIA", "12GB", "   ");
            Assert.IsTrue(tarjetaSinChipset.Validar().Contains("El chipset es obligatorio."));

            var switchValid = new PerifericoSwitch("SW01", "Control Pro", 39.99m, "Nintendo", "Control", "Switch");
            Assert.AreEqual(0, switchValid.Validar().Count);

            var switchInvalido = new PerifericoSwitch("SW02", "Control", 29.99m, "   ", "Control", "Switch");
            Assert.IsTrue(switchInvalido.Validar().Contains("La marca es obligatoria."));
        }

        [TestMethod]
        public void ConstructoresConcretosMantienenStockCeroYActivoVerdadero()
        {
            var tarjetaDefault = new TarjetaGrafica();
            var tarjetaParametrizada = new TarjetaGrafica("TG04", "GTX 1660", 229.99m, "NVIDIA", "6GB", "Turing");
            Assert.AreEqual(0, tarjetaDefault.Stock);
            Assert.IsTrue(tarjetaDefault.Activo);
            Assert.AreEqual(0, tarjetaParametrizada.Stock);
            Assert.IsTrue(tarjetaParametrizada.Activo);

            var interfazDefault = new InterfazAudio();
            var interfazParametrizada = new InterfazAudio("IA05", "Audio", 129.90m, "Focusrite", 2, 1);
            Assert.AreEqual(0, interfazDefault.Stock);
            Assert.IsTrue(interfazDefault.Activo);
            Assert.AreEqual(0, interfazParametrizada.Stock);
            Assert.IsTrue(interfazParametrizada.Activo);

            var switchDefault = new PerifericoSwitch();
            var switchParametrizado = new PerifericoSwitch("SW03", "Control Joy-Con", 49.99m, "Nintendo", "Control", "Switch");
            Assert.AreEqual(0, switchDefault.Stock);
            Assert.IsTrue(switchDefault.Activo);
            Assert.AreEqual(0, switchParametrizado.Stock);
            Assert.IsTrue(switchParametrizado.Activo);
        }

        [TestMethod]
        public void ValoresNumericosInvalidosSeRechazanEnFamilias()
        {
            var mouseInvalido = new Mouse("MS02", "Mouse", 39.90m, "Razer", 0);
            var erroresMouse = mouseInvalido.Validar();
            Assert.IsTrue(erroresMouse.Contains("Los DPI deben ser mayores a cero."));

            var monitorInvalido = new MonitorPC("MN02", "Monitor", 199.90m, "Dell", 0m, 0);
            var erroresMonitor = monitorInvalido.Validar();
            Assert.IsTrue(erroresMonitor.Contains("Las pulgadas deben ser mayores a cero."));
            Assert.IsTrue(erroresMonitor.Contains("La frecuencia del monitor debe ser mayor a cero."));

            var interfaz = new InterfazAudio("IA01", "Audio", 89.90m, "Focusrite", -2, -1);
            var erroresInterfaz = interfaz.Validar();
            Assert.IsTrue(erroresInterfaz.Contains("Las entradas no pueden ser negativas."));
            Assert.IsTrue(erroresInterfaz.Contains("Las salidas no pueden ser negativas."));
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
