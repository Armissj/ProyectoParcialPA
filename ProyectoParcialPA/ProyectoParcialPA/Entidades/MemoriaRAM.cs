using System.Collections.Generic;

namespace ProyectoParcialPA.Entidades
{
    public class MemoriaRAM : ComponentePC
    {
        private string _capacidad;
        private string _tipo;

        public MemoriaRAM()
        {
        }

        public MemoriaRAM(string codigo, string nombre, decimal precio, string marca, string capacidad, string tipo)
            : base(codigo, nombre, precio, marca)
        {
            Capacidad = capacidad;
            Tipo = tipo;
        }

        public string Capacidad
        {
            get { return _capacidad; }
            set { _capacidad = NormalizarTexto(value); }
        }

        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = NormalizarTexto(value); }
        }

        public override List<string> Validar()
        {
            var errores = base.Validar();

            if (string.IsNullOrWhiteSpace(_capacidad))
            {
                errores.Add("La capacidad es obligatoria.");
            }

            if (string.IsNullOrWhiteSpace(_tipo))
            {
                errores.Add("El tipo de memoria es obligatorio.");
            }

            return errores;
        }
    }
}
