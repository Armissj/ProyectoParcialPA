using System.Collections.Generic;

namespace ProyectoParcialPA.Entidades
{
    public class Mouse : PerifericoPC
    {
        private int _dpi;

        public Mouse()
        {
        }

        public Mouse(string codigo, string nombre, decimal precio, string marca, int dpi)
            : base(codigo, nombre, precio, marca)
        {
            Dpi = dpi;
        }

        public int Dpi
        {
            get { return _dpi; }
            set { _dpi = value; }
        }

        public override List<string> Validar()
        {
            var errores = base.Validar();

            if (_dpi <= 0)
            {
                errores.Add("Los DPI deben ser mayores a cero.");
            }

            return errores;
        }
    }
}
