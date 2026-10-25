using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoParcialPA.Entidades;
using ProyectoParcialPA.Utilidades;

namespace ProyectoParcialPA.Controladores
{
    public static class TListaCliente
    {
        private static List<Cliente> _registros = new List<Cliente>();
        internal static void ReiniciarEstado() { lock (EstadoTienda.Sincronizacion) _registros = new List<Cliente>(); }
        public static List<Cliente> ObtenerTodos(bool incluirInactivos = false)
        {
            if (!TListaUsuario.TienePermiso("GestionarClientes")) return new List<Cliente>();
            lock (EstadoTienda.Sincronizacion) return _registros.Where(x => incluirInactivos || x.Activo).Select(x => x.Copiar()).ToList();
        }
        public static Cliente BuscarPorId(int id)
        {
            if (!TListaUsuario.TienePermiso("GestionarClientes")) return null;
            lock (EstadoTienda.Sincronizacion) { var item = _registros.FirstOrDefault(x => x.Id == id && x.Activo); return item == null ? null : item.Copiar(); }
        }
        public static List<Cliente> BuscarPorNombre(string texto)
        {
            texto = ReglasDatos.Texto(texto);
            return ObtenerTodos().Where(x => ReglasDatos.Contiene(x.Nombre, texto) || ReglasDatos.Contiene(x.Apellido, texto) || ReglasDatos.Contiene(x.Telefono, texto) || ReglasDatos.Contiene(x.Email, texto)).ToList();
        }
        public static bool AgregarCliente(Cliente registro) { string mensaje; return AgregarCliente(registro, out mensaje); }
        public static bool AgregarCliente(Cliente registro, out string mensaje)
        {
            mensaje = "";
            if (!TListaUsuario.TienePermiso("GestionarClientes")) { mensaje = "No tienes permiso para gestionar clientes."; return false; }
            if (registro == null) { mensaje = "Completa los datos del registro."; return false; }
            var copia = registro.Copiar(); var errores = copia.Validar();
            if (errores.Count > 0) { mensaje = errores[0]; return false; }
            lock (EstadoTienda.Sincronizacion)
            {
                int ultimo = _registros.Count == 0 ? 0 : _registros.Max(x => x.Id);
                if (ultimo == int.MaxValue) { mensaje = "Se alcanzó el límite de registros."; return false; }
                copia.Id = ultimo + 1; copia.Activo = true; _registros.Add(copia);
            }
            mensaje = "Registro agregado correctamente."; return true;
        }
        public static bool ActualizarCliente(Cliente registro) { string mensaje; return ActualizarCliente(registro, out mensaje); }
        public static bool ActualizarCliente(Cliente registro, out string mensaje)
        {
            mensaje = "";
            if (!TListaUsuario.TienePermiso("GestionarClientes")) { mensaje = "No tienes permiso para gestionar clientes."; return false; }
            if (registro == null) { mensaje = "No se encontró el registro."; return false; }
            var copia = registro.Copiar(); var errores = copia.Validar();
            if (errores.Count > 0) { mensaje = errores[0]; return false; }
            lock (EstadoTienda.Sincronizacion)
            {
                int indice = _registros.FindIndex(x => x.Id == copia.Id);
                if (indice < 0) { mensaje = "El registro no existe."; return false; }
                _registros[indice] = copia;
            }
            mensaje = "Datos actualizados."; return true;
        }
        public static bool DesactivarCliente(int id) { string mensaje; return DesactivarCliente(id, out mensaje); }
        public static bool DesactivarCliente(int id, out string mensaje)
        {
            mensaje = "";
            if (!TListaUsuario.TienePermiso("GestionarClientes")) { mensaje = "No tienes permiso para gestionar clientes."; return false; }
            lock (EstadoTienda.Sincronizacion)
            {
                var actual = _registros.FirstOrDefault(x => x.Id == id && x.Activo);
                if (actual == null) { mensaje = "El registro no existe o ya está inactivo."; return false; }
                actual.Activo = false;
            }
            mensaje = "Registro desactivado. Su historial se conserva."; return true;
        }
    }
}
