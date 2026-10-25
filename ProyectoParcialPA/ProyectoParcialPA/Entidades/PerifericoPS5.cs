using System.Collections.Generic;

namespace ProyectoParcialPA.Entidades
{
    public class PerifericoPS5 : PerifericoConsola
    {
        public PerifericoPS5()
        {
        }

        public PerifericoPS5(string codigo, string nombre, decimal precio, string marca, string tipoAccesorio, string compatibilidad)
            : base(codigo, nombre, precio, marca, tipoAccesorio, compatibilidad)
        {
        }

        public override List<string> Validar()
        {
            return base.Validar();
        }
    }
}
