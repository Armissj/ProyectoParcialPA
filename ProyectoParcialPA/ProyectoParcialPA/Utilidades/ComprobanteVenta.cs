using System;
using System.Globalization;
using System.Text;
using ProyectoParcialPA.Entidades;

namespace ProyectoParcialPA.Utilidades
{
    public static class ComprobanteVenta
    {
        public static string Crear(Venta venta)
        {
            if (venta == null || !venta.Confirmada) throw new ArgumentException("La venta todavía no está confirmada.");
            var texto = new StringBuilder();
            texto.AppendLine("RAYAO*").AppendLine("PC / GAMING / MÚSICA");
            texto.AppendLine("COMPROBANTE DE VENTA N.º " + venta.Id.ToString("D6"));
            texto.AppendLine("Fecha: " + venta.Fecha.ToString("dd/MM/yyyy HH:mm"));
            texto.AppendLine("Cliente: " + venta.Cliente.NombreCompleto);
            texto.AppendLine("Atendido por: " + venta.Usuario.NombreUsuario);
            texto.AppendLine(new string('-', 48));
            foreach (var d in venta.Detalles)
            {
                texto.AppendLine(d.CodigoProducto + " · " + d.NombreProducto);
                texto.AppendLine(d.Cantidad + " x USD " + d.PrecioUnitario.ToString("0.00", CultureInfo.InvariantCulture) + " = USD " + d.Subtotal.ToString("0.00", CultureInfo.InvariantCulture));
            }
            texto.AppendLine(new string('-', 48));
            texto.AppendLine("TOTAL USD " + venta.Total.ToString("0.00", CultureInfo.InvariantCulture));
            texto.AppendLine().AppendLine("Gracias por ser parte de RAYAO*.");
            return texto.ToString();
        }
    }
}
