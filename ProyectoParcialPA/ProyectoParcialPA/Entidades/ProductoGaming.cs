using System.Collections.Generic;
using System.Linq;

namespace ProyectoParcialPA.Entidades
{
    public class ProductoGaming : Producto
    {
        private string _marca;
        private string _plataforma;
        private string _tipoArticulo;
        private bool _esRetro;

        public ProductoGaming()
        {
        }

        public ProductoGaming(string codigo, string nombre, decimal precio, string marca, string plataforma, string tipoArticulo, bool esRetro)
            : base(codigo, nombre, precio)
        {
            Marca = marca;
            Plataforma = plataforma;
            TipoArticulo = tipoArticulo;
            EsRetro = esRetro;
        }

        public string Marca
        {
            get { return _marca; }
            set { _marca = NormalizarTexto(value); }
        }

        public string Plataforma
        {
            get { return _plataforma; }
            set { _plataforma = NormalizarTexto(value); }
        }

        public string TipoArticulo
        {
            get { return _tipoArticulo; }
            set
            {
                var valor = NormalizarTexto(value);
                if (string.IsNullOrWhiteSpace(valor))
                {
                    _tipoArticulo = string.Empty;
                    return;
                }

                var normalizado = valor.Substring(0, 1).ToUpperInvariant() + valor.Substring(1).ToLowerInvariant();
                var validos = new[] { "Consola", "Videojuego", "Accesorio" };
                _tipoArticulo = validos.Contains(normalizado) ? normalizado : valor;
            }
        }

        public bool EsRetro
        {
            get { return _esRetro; }
            set { _esRetro = value; }
        }

        public override List<string> Validar()
        {
            var errores = base.Validar();

            if (string.IsNullOrWhiteSpace(_marca))
            {
                errores.Add("La marca es obligatoria.");
            }

            if (string.IsNullOrWhiteSpace(_plataforma))
            {
                errores.Add("La plataforma es obligatoria.");
            }

            if (string.IsNullOrWhiteSpace(_tipoArticulo))
            {
                errores.Add("El tipo de artículo es obligatorio.");
                return errores;
            }

            var valorNormalizado = _tipoArticulo.Trim();
            var tipo = valorNormalizado.Substring(0, 1).ToUpperInvariant() + valorNormalizado.Substring(1).ToLowerInvariant();
            if (tipo != "Consola" && tipo != "Videojuego" && tipo != "Accesorio")
            {
                errores.Add("El tipo de artículo debe ser Consola, Videojuego o Accesorio.");
            }
            else
            {
                _tipoArticulo = tipo;
            }

            return errores;
        }
    }
}
