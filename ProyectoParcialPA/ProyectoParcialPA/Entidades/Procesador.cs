using System.Collections.Generic;

namespace ProyectoParcialPA.Entidades
{
    public class Procesador : ComponentePC
    {
        private string _socket;
        private int _nucleos;

        public Procesador()
        {
        }

        public Procesador(string codigo, string nombre, decimal precio, string marca, string socket, int nucleos)
            : base(codigo, nombre, precio, marca)
        {
            Socket = socket;
            Nucleos = nucleos;
        }

        public string Socket
        {
            get { return _socket; }
            set { _socket = NormalizarTexto(value); }
        }

        public int Nucleos
        {
            get { return _nucleos; }
            set { _nucleos = value; }
        }

        public override List<string> Validar()
        {
            var errores = base.Validar();

            if (string.IsNullOrWhiteSpace(_socket))
            {
                errores.Add("El socket es obligatorio.");
            }

            if (_nucleos <= 0)
            {
                errores.Add("Los núcleos deben ser mayores a cero.");
            }

            return errores;
        }
    }
}
