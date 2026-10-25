using System.Collections.Generic;

namespace ProyectoParcialPA.Entidades
{
    public class InterfazAudio : EquipoMusical
    {
        private int _entradas;
        private int _salidas;

        public InterfazAudio()
        {
        }

        public InterfazAudio(string codigo, string nombre, decimal precio, string marca, int entradas, int salidas)
            : base(codigo, nombre, precio, marca)
        {
            Entradas = entradas;
            Salidas = salidas;
        }

        public int Entradas
        {
            get { return _entradas; }
            set { _entradas = value; }
        }

        public int Salidas
        {
            get { return _salidas; }
            set { _salidas = value; }
        }

        public override List<string> Validar()
        {
            var errores = base.Validar();

            if (_entradas < 0)
            {
                errores.Add("Las entradas no pueden ser negativas.");
            }

            if (_salidas < 0)
            {
                errores.Add("Las salidas no pueden ser negativas.");
            }

            if (_entradas == 0 && _salidas == 0)
            {
                errores.Add("Debe haber al menos una entrada o salida mayor a cero.");
            }

            return errores;
        }
    }
}
