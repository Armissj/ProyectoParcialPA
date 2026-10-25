using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ProyectoParcialPA.Utilidades
{
    public static class ExportadorCsv
    {
        public static string Campo(string valor)
        {
            valor = valor ?? "";
            if (valor.Length > 0 && "=+-@\t\r".IndexOf(valor[0]) >= 0) valor = "'" + valor;
            return "\"" + valor.Replace("\"", "\"\"") + "\"";
        }
        public static void Guardar(DataTable tabla, string archivo)
        {
            if (tabla == null) throw new ArgumentNullException("tabla");
            using (var salida = new StreamWriter(archivo, false, new UTF8Encoding(true)))
            {
                salida.NewLine = "\r\n";
                salida.WriteLine(string.Join(",", tabla.Columns.Cast<DataColumn>().Select(c => Campo(c.ColumnName))));
                foreach (DataRow fila in tabla.Rows)
                    salida.WriteLine(string.Join(",", fila.ItemArray.Select(v => Campo(v is DateTime ? ((DateTime)v).ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) : v is decimal ? ((decimal)v).ToString("0.00", CultureInfo.InvariantCulture) : Convert.ToString(v, CultureInfo.InvariantCulture)))));
            }
        }
    }
}
