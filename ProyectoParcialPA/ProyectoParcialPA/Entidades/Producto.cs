using System;
using System.Collections.Generic;

namespace ProyectoParcialPA.Entidades
{
    public abstract class Producto
    {
        private string _codigo;
        private string _nombre;
        private decimal _precio;
        private int _stock;
        private bool _activo;

        protected Producto()
        {
            _stock = 0;
            _activo = true;
        }

        protected Producto(string codigo, string nombre, decimal precio)
        {
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
            _stock = 0;
            _activo = true;
        }

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = NormalizarCodigo(value); }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = NormalizarTexto(value); }
        }

        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public int Stock
        {
            get { return _stock; }
            private set { _stock = value; }
        }

        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }

        public static string NormalizarCodigo(string codigo)
        {
            if (codigo == null)
            {
                return string.Empty;
            }

            return codigo.Trim().ToUpperInvariant();
        }

        public static string NormalizarTexto(string texto)
        {
            if (texto == null)
            {
                return string.Empty;
            }

            return texto.Trim();
        }

        internal Producto Copiar()
        {
            return (Producto)MemberwiseClone();
        }

        internal void EstablecerStockInterno(int valor)
        {
            if (valor < 0) throw new ArgumentOutOfRangeException("valor", "El stock no puede ser negativo.");
            _stock = valor;
        }

        public virtual List<string> Validar()
        {
            var errores = new List<string>();

            if (string.IsNullOrWhiteSpace(_codigo))
            {
                errores.Add("El código es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(_nombre))
            {
                errores.Add("El nombre es obligatorio.");
            }

            if (_precio <= 0m)
            {
                errores.Add("El precio debe ser mayor a cero.");
            }

            if (decimal.Round(_precio, 2) != _precio)
            {
                errores.Add("El precio debe tener máximo dos decimales.");
            }

            if (_stock < 0)
            {
                errores.Add("El stock no puede ser negativo.");
            }

            return errores;
        }
    }
}
