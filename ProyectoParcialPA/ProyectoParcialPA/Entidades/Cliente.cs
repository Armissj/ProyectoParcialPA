using System;
using System.Collections.Generic;
using ProyectoParcialPA.Utilidades;

namespace ProyectoParcialPA.Entidades
{
    public class Cliente
    {
        private int _id;
        private bool _activo = true;
        private string _nombre;
        private string _apellido;
        private string _direccion;
        private string _telefono;
        private string _email;
        public Cliente() { }
        public Cliente(int id, string nombre, string apellido, string direccion, string telefono, string email)
        {
            _id = id;
            Nombre = nombre;
            Apellido = apellido;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
        }
        public int Id { get { return _id; } set { _id = value; } }
        public bool Activo { get { return _activo; } set { _activo = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = ReglasDatos.Texto(value); } }

        public string Apellido { get { return _apellido; } set { _apellido = ReglasDatos.Texto(value); } }

        public string Direccion { get { return _direccion; } set { _direccion = ReglasDatos.Texto(value); } }

        public string Telefono { get { return _telefono; } set { _telefono = ReglasDatos.Texto(value); } }

        public string Email { get { return _email; } set { _email = ReglasDatos.Texto(value); } }
        public string NombreCompleto { get { return (Nombre + " " + Apellido).Trim(); } }

        public List<string> Validar()
        {
            var errores = new List<string>();
            if (string.IsNullOrWhiteSpace(Nombre)) errores.Add("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(Apellido)) errores.Add("El apellido es obligatorio.");
            if (string.IsNullOrWhiteSpace(Direccion)) errores.Add("La dirección es obligatoria.");
            if (string.IsNullOrWhiteSpace(Telefono)) errores.Add("El teléfono es obligatorio.");
            if (string.IsNullOrWhiteSpace(Email)) errores.Add("El email es obligatorio.");
            if (!string.IsNullOrWhiteSpace(Telefono) && !ReglasDatos.TelefonoValido(Telefono)) errores.Add("El teléfono debe contener al menos 7 dígitos y solo signos telefónicos.");
            if (!string.IsNullOrWhiteSpace(Email) && !ReglasDatos.EmailValido(Email)) errores.Add("El email no tiene un formato válido.");
            return errores;
        }
        internal Cliente Copiar() { return (Cliente)MemberwiseClone(); }
    }
}
