using System;

namespace ProyectoParcialPA.Entidades
{
    public class DetalleVenta
    {
        private Producto _producto;
        private string _codigoProducto = "";
        private string _nombreProducto = "";
        private int _cantidad;
        private decimal _importe;
        public DetalleVenta() { FechaRegistro = DateTime.Now; }
        public DetalleVenta(Producto producto, int cantidad, decimal importe) : this()
        {
            Producto = producto; _cantidad = cantidad; _importe = importe;
        }
        public Producto Producto
        {
            get { return _producto == null ? null : _producto.Copiar(); }
            set
            {
                _producto = value == null ? null : value.Copiar();
                _codigoProducto = value == null ? "" : value.Codigo;
                _nombreProducto = value == null ? "" : value.Nombre;
            }
        }
        public string CodigoProducto { get { return _codigoProducto; } }
        public string NombreProducto { get { return _nombreProducto; } }
        public int Cantidad { get { return _cantidad; } set { _cantidad = value; } }
        public decimal PrecioUnitario { get { return _importe; } set { _importe = value; } }
        public decimal Subtotal { get { return checked(_cantidad * _importe); } }
        public DateTime FechaRegistro { get; internal set; }
        internal DetalleVenta Copiar()
        {
            var copia = (DetalleVenta)MemberwiseClone();
            copia._producto = _producto == null ? null : _producto.Copiar(); return copia;
        }
    }
}
