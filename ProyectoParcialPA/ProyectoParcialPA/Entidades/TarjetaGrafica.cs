using System.Collections.Generic;

namespace ProyectoParcialPA.Entidades
{
    public class TarjetaGrafica : ComponentePC
    {
        private string _memoria;
        private string _chipset;

        public TarjetaGrafica()
        {
        }

        public TarjetaGrafica(string codigo, string nombre, decimal precio, string marca, string memoria, string chipset)
            : base(codigo, nombre, precio, marca)
        {
            Memoria = memoria;
            Chipset = chipset;
        }

        public string Memoria
        {
            get { return _memoria; }
            set { _memoria = NormalizarTexto(value); }
        }

        public string Chipset
        {
            get { return _chipset; }
            set { _chipset = NormalizarTexto(value); }
        }

        public override List<string> Validar()
        {
            var errores = base.Validar();

            if (string.IsNullOrWhiteSpace(_memoria))
            {
                errores.Add("La memoria es obligatoria.");
            }

            if (string.IsNullOrWhiteSpace(_chipset))
            {
                errores.Add("El chipset es obligatorio.");
            }

            return errores;
        }
    }
}
