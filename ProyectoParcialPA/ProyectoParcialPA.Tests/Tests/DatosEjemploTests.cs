using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoParcialPA.Controladores;
using ProyectoParcialPA.Sesiones;
using System.Linq;
namespace ProyectoParcialPA.Tests
{
    [TestClass]
    [DoNotParallelize]
    public class DatosEjemploTests
    {
        [TestMethod] public void EjemploRespetaRolesNoDuplicaYNoIntroduceStockSinCompras()
        {
            TListaProducto.ReiniciarEstado(); TListaCliente.ReiniciarEstado(); TListaProveedor.ReiniciarEstado(); DatosEjemplo.ReiniciarParaPruebas(); string mensaje;
            try
            {
                SesionActual.CerrarSesion(); Assert.IsFalse(DatosEjemplo.Cargar(out mensaje));
                Assert.IsNotNull(TListaUsuario.Login("vendedor","Vendedor123*")); Assert.IsFalse(DatosEjemplo.Cargar(out mensaje));
                SesionActual.CerrarSesion(); Assert.IsNotNull(TListaUsuario.Login("admin","Admin123*"));
                Assert.IsTrue(DatosEjemplo.Cargar(out mensaje)); int cantidad = TListaProducto.ObtenerTodos().Count;
                Assert.AreEqual(16,cantidad); Assert.IsTrue(TListaProducto.ObtenerTodos().All(p => p.Stock == 0));
                Assert.IsTrue(DatosEjemplo.Cargar(out mensaje)); Assert.AreEqual(cantidad,TListaProducto.ObtenerTodos().Count); Assert.AreEqual(1,TListaCliente.ObtenerTodos().Count);
            }
            finally { TListaProducto.ReiniciarEstado(); TListaCliente.ReiniciarEstado(); TListaProveedor.ReiniciarEstado(); DatosEjemplo.ReiniciarParaPruebas(); SesionActual.CerrarSesion(); }
        }
    }
}
