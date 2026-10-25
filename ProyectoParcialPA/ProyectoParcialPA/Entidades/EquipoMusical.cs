using System.Collections.Generic;

namespace ProyectoParcialPA.Entidades
{
    public abstract class EquipoMusical : Producto
    {
        private string _marca;

        protected EquipoMusical()
        {
        }

        protected EquipoMusical(string codigo, string nombre, decimal precio, string marca)
            : base(codigo, nombre, precio)
        {
            Marca = marca;
        }

        public string Marca
        {
            get { return _marca; }
            set { _marca = NormalizarTexto(value); }
        }

        public override List<string> Validar()
        {
            var errores = base.Validar();

            if (string.IsNullOrWhiteSpace(_marca))
            {
                errores.Add("La marca es obligatoria.");
            }

            return errores;
        }
    }
}
