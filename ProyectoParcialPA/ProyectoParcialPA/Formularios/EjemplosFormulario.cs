using System;
using System.Linq;
using ProyectoParcialPA.Controladores;
using ProyectoParcialPA.Entidades;

namespace ProyectoParcialPA.Formularios
{
    // Solo completa borradores. Guardar o Confirmar sigue siendo una acción del usuario.
    internal static class EjemplosFormulario
    {
        internal static Producto Producto(string tipo)
        {
            var ejemplo = DatosEjemplo.CrearCatalogo().FirstOrDefault(p => p.GetType().Name == tipo);
            if (ejemplo == null) throw new ArgumentException("Selecciona un tipo de producto válido.");
            var codigos = TListaProducto.ObtenerTodos().Concat(TListaProducto.ObtenerTodosInactivos()).Select(p => p.Codigo).ToList();
            string prefijo = "EJ-" + tipo.ToUpperInvariant() + "-"; int numero = 1;
            while (codigos.Any(c => string.Equals(c, prefijo + numero.ToString("D3"), StringComparison.OrdinalIgnoreCase))) numero++;
            ejemplo.Codigo = prefijo + numero.ToString("D3"); ejemplo.Nombre += " · Ejemplo";
            return ejemplo;
        }

        internal static Cliente Cliente()
        {
            var todos = TListaCliente.ObtenerTodos(true); int numero = 1;
            while (todos.Any(c => c.Email == "cliente_demo_" + numero + "@rayao.example")) numero++;
            return new Cliente(0,"Cliente " + numero,"Demo","Machala · Dirección de ejemplo","0990000301","cliente_demo_" + numero + "@rayao.example");
        }

        internal static Proveedor Proveedor()
        {
            var todos = TListaProveedor.ObtenerTodos(true); int numero = 1;
            while (todos.Any(p => p.Email == "proveedor_demo_" + numero + "@rayao.example")) numero++;
            return new Proveedor(0,"Proveedor " + numero + " Demo","Contacto de ejemplo","0990000401","proveedor_demo_" + numero + "@rayao.example");
        }

        internal static string NombreUsuario()
        {
            var todos = TListaUsuario.Usuarios; int numero = 1;
            while (todos.Any(u => u.NombreUsuario == "vendedor_demo_" + numero)) numero++;
            return "vendedor_demo_" + numero;
        }
    }
}
