using System;
using System.Linq;
using System.Net.Mail;

namespace ProyectoParcialPA.Utilidades
{
    internal static class ReglasDatos
    {
        internal static string Texto(string valor) { return (valor ?? string.Empty).Trim(); }
        internal static bool Contiene(string valor, string texto) { return (valor ?? "").IndexOf(texto ?? "", StringComparison.OrdinalIgnoreCase) >= 0; }
        internal static bool EmailValido(string valor)
        {
            try { return !string.IsNullOrWhiteSpace(valor) && new MailAddress(valor).Address == valor; }
            catch (FormatException) { return false; }
        }
        internal static bool TelefonoValido(string valor)
        {
            return !string.IsNullOrWhiteSpace(valor) && valor.Length <= 25 && valor.Count(char.IsDigit) >= 7 && valor.All(c => char.IsDigit(c) || "+()- ".Contains(c));
        }
        internal static bool ImporteValido(decimal valor) { return valor > 0m && decimal.Round(valor, 2) == valor; }
    }
}
