using System;
using System.Linq;
using System.Windows.Forms;
using ProyectoParcialPA.Controladores;
using ProyectoParcialPA.Entidades;
using ProyectoParcialPA.Utilidades;
using ProyectoParcialPA.Visual;

namespace ProyectoParcialPA.Formularios
{
    public partial class frmVenta : Form
    {
        private readonly Venta operacion = new Venta();
        private bool cargando;
        public frmVenta()
        {
            InitializeComponent(); RayaoTema.Aplicar(this, "fondo_venta");
            Ui.AlCargar(this, "RegistrarVenta", delegate
            {
                cargando = true; numCantidad.Maximum = int.MaxValue;
                Ui.Combo(cboCliente, TListaCliente.ObtenerTodos().Select(c => new { Id = c.Id, Nombre = c.NombreCompleto }).ToList(), "Nombre", "Id");
                var productos = TListaProducto.ObtenerTodos().Select(p => new { Codigo = p.Codigo, Descripcion = p.Codigo + " · " + p.Nombre }).ToList();
                Ui.Combo(cboProducto, productos, "Descripcion", "Codigo"); cboProducto.DropDownWidth = 520;
                cargando = false; ProductoSeleccionado(); PrepararBorradorEjemplo(); ActualizarDetalle();
                if (cboCliente.Items.Count == 0 || cboProducto.Items.Count == 0) lblInfo.Text = "Registra primero un cliente y productos desde el menú principal.";
            });
        }
        private void PrepararBorradorEjemplo()
        {
            if (!DatosEjemplo.EstanCargados || cboCliente.Items.Count == 0) return;
            foreach (var p in TListaProducto.ObtenerTodos().Where(p => p.Stock > 0).Take(2))
                TListaVenta.AgregarDetalleVenta(operacion, p, 1, p.Precio);
            lblInfo.Text = "Borrador de ejemplo. Revisa el cliente y las líneas; Confirmar registra la venta y su comprobante.";
        }
        private Producto Seleccionado() { return TListaProducto.BuscarPorCodigo(Convert.ToString(cboProducto.SelectedValue)); }
        private void ProductoSeleccionado()
        {
            var p = Seleccionado(); if (p == null) return;
            numPrecio.Maximum = Math.Max(numPrecio.Maximum, p.Precio); numPrecio.Value = p.Precio;
            MostrarStock();
        }
        private void MostrarStock()
        {
            var p = Seleccionado(); if (p == null) { lblStock.Text = "Selecciona un producto."; return; }
            lblStock.Text = "Stock actual: " + p.Stock + " · En la lista: " + operacion.Detalles.Where(d => d.CodigoProducto == p.Codigo).Sum(d => d.Cantidad);
        }
        private void ActualizarDetalle()
        {
            Ui.Tabla(dgvDetalle, operacion.Detalles.Select((d, i) => new { Indice = i, Codigo = d.CodigoProducto, Producto = d.NombreProducto, Cantidad = d.Cantidad, PrecioUnitario = d.PrecioUnitario, Subtotal = d.Subtotal }).ToList());
            Ui.PonerDinero(lblTotal, operacion.Total, 31F); MostrarStock();
        }
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (!TListaVenta.AgregarDetalleVenta(operacion, Seleccionado(), (int)numCantidad.Value, numPrecio.Value))
            {
                Ui.Avisar(this, "Revisa el producto, la cantidad y el importe. La cantidad total debe estar disponible en stock."); return;
            }
            numCantidad.Value = 1; ActualizarDetalle();
        }
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow == null) return;
            int indice = Convert.ToInt32(dgvDetalle.CurrentRow.Cells["Indice"].Value);
            if (indice >= 0 && indice < operacion.Detalles.Count) operacion.Detalles.RemoveAt(indice);
            ActualizarDetalle();
        }
        internal bool ConfirmarActual(out string mensaje)
        {
            int id;
            if (!int.TryParse(Convert.ToString(cboCliente.SelectedValue), out id)) { mensaje = "Selecciona un cliente."; return false; }
            operacion.Cliente = TListaCliente.BuscarPorId(id);
            return TListaVenta.RegistrarVenta(operacion, out mensaje);
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!btnConfirmar.Enabled) return; btnConfirmar.Enabled = false;
            try
            {
                string mensaje;
                if (!ConfirmarActual(out mensaje)) { Ui.Avisar(this, mensaje); return; }
                var guardada = TListaVenta.ObtenerTodos().FirstOrDefault(v => v.Id == operacion.Id) ?? operacion; try { Ui.MostrarTicket(this, ComprobanteVenta.Crear(guardada)); } catch (Exception ex) { Ui.Avisar(this, "Venta registrada. No se pudo mostrar el comprobante: " + ex.Message); }
                DialogResult = DialogResult.OK; Close();
            }
            finally { if (!IsDisposed && !operacion.Confirmada) btnConfirmar.Enabled = true; }
        }
        private void btnCancelar_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; Close(); }
        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e) { if (!cargando && IsHandleCreated) ProductoSeleccionado(); }
    }
}
