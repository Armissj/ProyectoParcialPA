using System.Collections.Generic;

namespace ProyectoParcialPA.Entidades
{
    public abstract class PerifericoConsola : Producto
    {
        private string _marca;
        private string _tipoAccesorio;
        private string _compatibilidad;

        protected PerifericoConsola()
        {
        }

        protected PerifericoConsola(string codigo, string nombre, decimal precio, string marca, string tipoAccesorio, string compatibilidad)
            : base(codigo, nombre, precio)
        {
            Marca = marca;
            TipoAccesorio = tipoAccesorio;
            Compatibilidad = compatibilidad;
        }

        public string Marca
        {
            get { return _marca; }
            set { _marca = NormalizarTexto(value); }
        }

        public string TipoAccesorio
        {
            get { return _tipoAccesorio; }
            set { _tipoAccesorio = NormalizarTexto(value); }
        }

        public string Compatibilidad
        {
            get { return _compatibilidad; }
            set { _compatibilidad = NormalizarTexto(value); }
        }

        public override List<string> Validar()
        {
            var errores = base.Validar();

            if (string.IsNullOrWhiteSpace(_marca))
            {
                errores.Add("La marca es obligatoria.");
            }

            if (string.IsNullOrWhiteSpace(_tipoAccesorio))
            {
                errores.Add("El tipo de accesorio es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(_compatibilidad))
            {
                errores.Add("La compatibilidad es obligatoria.");
            }

            return errores;
        }
    }
}
