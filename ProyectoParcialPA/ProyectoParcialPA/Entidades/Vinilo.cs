using System;
using System.Collections.Generic;

namespace ProyectoParcialPA.Entidades
{
    public class Vinilo : Producto
    {
        private string _artista;
        private string _genero;
        private int _anio;

        public Vinilo()
        {
        }

        public Vinilo(string codigo, string nombre, decimal precio, string artista, string genero, int anio)
            : base(codigo, nombre, precio)
        {
            Artista = artista;
            Genero = genero;
            Anio = anio;
        }

        public string Artista
        {
            get { return _artista; }
            set { _artista = NormalizarTexto(value); }
        }

        public string Genero
        {
            get { return _genero; }
            set { _genero = NormalizarTexto(value); }
        }

        public int Anio
        {
            get { return _anio; }
            set { _anio = value; }
        }

        public override List<string> Validar()
        {
            var errores = base.Validar();

            if (string.IsNullOrWhiteSpace(_artista))
            {
                errores.Add("El artista es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(_genero))
            {
                errores.Add("El género es obligatorio.");
            }

            var anioMinimo = 1900;
            var anioMaximo = DateTime.Now.Year + 1;
            if (_anio < anioMinimo || _anio > anioMaximo)
            {
                errores.Add("El año debe estar entre 1900 y el año actual más uno.");
            }

            return errores;
        }
    }
}
