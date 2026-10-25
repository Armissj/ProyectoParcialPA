using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoParcialPA.Entidades
{
    public class Venta
    {
        private int _id;
        private Guid _idOperacion;
        private DateTime _fecha;
        private bool _confirmada;
        private Cliente _participante;
        private Usuario _usuario;
        private List<DetalleVenta> _detalles;
        public Venta()
        {
            _idOperacion = Guid.NewGuid(); _fecha = DateTime.Now; _detalles = new List<DetalleVenta>();
        }
        public Venta(Cliente participante) : this() { _participante = participante; }
        public int Id { get { return _id; } internal set { _id = value; } }
        public Guid IdOperacion { get { return _idOperacion; } }
        public DateTime Fecha { get { return _fecha; } set { _fecha = value; } }
        public bool Confirmada { get { return _confirmada; } internal set { _confirmada = value; } }
        public Cliente Cliente { get { return _participante; } set { _participante = value; } }
        public Usuario Usuario { get { return _usuario; } set { _usuario = value; } }
        public List<DetalleVenta> Detalles { get { return _detalles; } }
        public decimal Total { get { return _detalles.Sum(d => d.Subtotal); } }
        internal Venta Copiar()
        {
            var copia = (Venta)MemberwiseClone();
            copia._participante = _participante == null ? null : _participante.Copiar();
            copia._usuario = _usuario == null ? null : _usuario.Clonar();
            copia._detalles = _detalles.Select(d => d == null ? null : d.Copiar()).ToList();
            return copia;
        }
    }
}
