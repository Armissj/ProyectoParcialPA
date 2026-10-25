using System.Collections.Generic;

namespace ProyectoParcialPA.Entidades
{
    public class MonitorPC : PerifericoPC
    {
        private decimal _pulgadas;
        private int _hz;

        public MonitorPC()
        {
        }

        public MonitorPC(string codigo, string nombre, decimal precio, string marca, decimal pulgadas, int hz)
            : base(codigo, nombre, precio, marca)
        {
            Pulgadas = pulgadas;
            Hz = hz;
        }

        public decimal Pulgadas
        {
            get { return _pulgadas; }
            set { _pulgadas = value; }
        }

        public int Hz
        {
            get { return _hz; }
            set { _hz = value; }
        }

        public override List<string> Validar()
        {
            var errores = base.Validar();

            if (_pulgadas <= 0m)
            {
                errores.Add("Las pulgadas deben ser mayores a cero.");
            }

            if (_hz <= 0)
            {
                errores.Add("La frecuencia del monitor debe ser mayor a cero.");
            }

            return errores;
        }
    }
}
