using System.Collections.Generic;

namespace ProyectoParcialPA.Entidades
{
    public class Teclado : PerifericoPC
    {
        private string _tipo;

        public Teclado()
        {
        }

        public Teclado(string codigo, string nombre, decimal precio, string marca, string tipo)
            : base(codigo, nombre, precio, marca)
        {
            Tipo = tipo;
        }

        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = NormalizarTexto(value); }
        }

        public override List<string> Validar()
        {
            var errores = base.Validar();

            if (string.IsNullOrWhiteSpace(_tipo))
            {
                errores.Add("El tipo es obligatorio.");
            }

            return errores;
        }
    }
}
