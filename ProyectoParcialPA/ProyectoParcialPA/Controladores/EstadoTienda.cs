namespace ProyectoParcialPA.Controladores
{
    // Un solo bloqueo permite confirmar inventario e historial como una operación.
    internal static class EstadoTienda
    {
        internal static readonly object Sincronizacion = new object();
    }
}
