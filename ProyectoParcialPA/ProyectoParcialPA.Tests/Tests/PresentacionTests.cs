using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoParcialPA.Entidades;
using ProyectoParcialPA.Formularios;
using ProyectoParcialPA.Utilidades;

namespace ProyectoParcialPA.Tests
{
    [TestClass]
    public class PresentacionTests
    {
        [TestMethod] public void CsvEscapaComillasComasYLineasYConservaDecimales()
        {
            var tabla = new DataTable(); tabla.Columns.Add("Nombre"); tabla.Columns.Add("Precio", typeof(decimal)); tabla.Rows.Add("Vinilo, \"edición\"\nEspecial", 25.50m);
            string archivo = Path.GetTempFileName();
            try { ExportadorCsv.Guardar(tabla, archivo); string texto = File.ReadAllText(archivo); Assert.IsTrue(texto.Contains("\"Vinilo, \"\"edición\"\"\nEspecial\"")); Assert.IsTrue(texto.Contains("\"25.50\"")); }
            finally { File.Delete(archivo); }
        }
        [TestMethod] public void CsvTrataComoTextoLosValoresQuePodrianSerFormulas()
        {
            Assert.AreEqual("\"'=1+1\"", ExportadorCsv.Campo("=1+1")); Assert.AreEqual("\"Nombre\"", ExportadorCsv.Campo("Nombre"));
        }
        [TestMethod] public void FiltrosSeCombinanPorArtistaFamiliaPlataformaYRetro()
        {
            var productos = new List<Producto> { new Vinilo("V1", "Disco", 10m, "Tupac", "Rap", 2000), new ProductoGaming("G1", "Consola retro", 10m, "Marca", "Retro", "Consola", true), new PerifericoPS5("P1", "Control", 10m, "Marca", "Mando", "PS5") };
            Assert.AreEqual(1, TiposProducto.Filtrar(productos,"TUPAC","Vinilo","Todas",null).Count);
            Assert.AreEqual(1, TiposProducto.Filtrar(productos,"","PerifericoConsola","PS5",false).Count);
            Assert.AreEqual(1, TiposProducto.Filtrar(productos,"","Todos","Todas",true).Count);
            Assert.AreEqual(0, TiposProducto.Filtrar(productos,"Tupac","ProductoGaming","Todas",null).Count);
        }
        [TestMethod] public void ComprobanteMuestraCodigoCantidadesYTotalOriginal()
        {
            var v = new Venta { Id = 7, Confirmada = true, Cliente = new Cliente(1,"Ana","Pérez","Dirección","0991234567","ana@example.com"), Usuario = new Usuario { NombreUsuario = "vendedor" } };
            v.Detalles.Add(new DetalleVenta(new Teclado("PC001","Teclado",25.50m,"Marca","Mecánico"),2,25.50m));
            string texto = ComprobanteVenta.Crear(v); Assert.IsTrue(texto.Contains("000007")); Assert.IsTrue(texto.Contains("PC001")); Assert.IsTrue(texto.Contains("2 x USD 25.50")); Assert.IsTrue(texto.Contains("TOTAL USD 51.00"));
        }
        [TestMethod] public void EditorReconstruyeLosDoceTiposConTodosSusAtributos()
        {
            Producto[] productos = {
                new Teclado("T","Teclado",10m,"Marca","Mecánico"), new Mouse("M","Mouse",10m,"Marca",1600), new MonitorPC("MON","Monitor",10m,"Marca",27.5m,144),
                new Procesador("CPU","Procesador",10m,"Marca","AM4",6), new MemoriaRAM("RAM","Memoria",10m,"Marca","16 GB","DDR4"), new TarjetaGrafica("GPU","Gráfica",10m,"Marca","8 GB","Chipset"),
                new Microfono("MIC","Micrófono",10m,"Marca","Condensador"), new InterfazAudio("AUD","Interfaz",10m,"Marca",2,2), new Vinilo("VIN","Disco",10m,"Artista","Rap",2000),
                new PerifericoPS5("PS","Control",10m,"Marca","Mando","PS5"), new PerifericoSwitch("SW","Control",10m,"Marca","Mando","Switch"), new ProductoGaming("RET","Consola",10m,"Marca","Retro","Consola",true)
            };
            foreach (var antes in productos)
            {
                var despues = EditorProducto.Crear(antes.GetType().Name, antes.Codigo, antes.Nombre, antes.Precio, EditorProducto.Leer(antes));
                Assert.AreEqual(antes.GetType(), despues.GetType()); Assert.AreEqual(0, despues.Validar().Count);
                foreach (var propiedad in antes.GetType().GetProperties()) Assert.AreEqual(propiedad.GetValue(antes), propiedad.GetValue(despues), propiedad.Name);
            }
        }
        [TestMethod] public void EditorRechazaUnaCantidadDeDpiQueNoEsEntera()
        {
            bool rechazo = false;
            try { EditorProducto.Crear("Mouse","PC01","Mouse",10m,new Dictionary<string,string> { {"Marca","Marca"},{"Dpi","abc"} }); }
            catch (FormatException) { rechazo = true; }
            Assert.IsTrue(rechazo);
        }
    }
}
