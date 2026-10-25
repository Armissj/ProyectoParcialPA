using System;
using System.Linq;
using System.Windows.Forms;
using ProyectoParcialPA.Controladores;
using ProyectoParcialPA.Entidades;
using ProyectoParcialPA.Utilidades;
using ProyectoParcialPA.Visual;

namespace ProyectoParcialPA.Formularios
{
    public partial class frmCompra : Form
    {
        private readonly Compra operacion = new Compra();
        private bool cargando;
        public frmCompra()
        {
            InitializeComponent(); RayaoTema.Aplicar(this, "fondo_compra");
            Ui.AlCargar(this, "RegistrarCompra", delegate
            {
                cargando = true; numCantidad.Maximum = int.MaxValue;
                Ui.Combo(cboProveedor, TListaProveedor.ObtenerTodos(), "Nombre", "Id");
                var productos = TListaProducto.ObtenerTodos().Select(p => new { Codigo = p.Codigo, Descripcion = p.Codigo + " · " + p.Nombre }).ToList();
                Ui.Combo(cboProducto, productos, "Descripcion", "Codigo"); cboProducto.DropDownWidth = 520;
                cargando = false; ProductoSeleccionado(); ActualizarDetalle();
                if (cboProveedor.Items.Count == 0 || cboProducto.Items.Count == 0) lblInfo.Text = "Registra primero un proveedor y productos desde el menú principal.";
            });
        }
        private Producto Seleccionado() { return TListaProducto.BuscarPorCodigo(Convert.ToString(cboProducto.SelectedValue)); }
        private void ProductoSeleccionado()
        {
            var p = Seleccionado(); if (p == null) return;
            lblInfo.Text = "El costo de compra es distinto del precio de venta del producto.";
            MostrarStock();
        }
        private void MostrarStock()
        {
            var p = Seleccionado(); if (p == null) { lblStock.Text = "Selecciona un producto."; return; }
            lblStock.Text = "Stock actual: " + p.Stock + " · En la lista: " + operacion.Detalles.Where(d => d.CodigoProducto == p.Codigo).Sum(d => d.Cantidad);
        }
        private void ActualizarDetalle()
        {
            Ui.Tabla(dgvDetalle, operacion.Detalles.Select((d, i) => new { Indice = i, Codigo = d.CodigoProducto, Producto = d.NombreProducto, Cantidad = d.Cantidad, CostoUnitario = d.CostoUnitario, Subtotal = d.Subtotal }).ToList());
            Ui.PonerDinero(lblTotal, operacion.Total, 31F); MostrarStock();
        }
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (!TListaCompra.AgregarDetalleCompra(operacion, Seleccionado(), (int)numCantidad.Value, numCosto.Value))
            {
                Ui.Avisar(this, "Revisa el producto, la cantidad y el importe. Las cantidades deben ser positivas y los importes tener máximo dos decimales."); return;
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
            if (!int.TryParse(Convert.ToString(cboProveedor.SelectedValue), out id)) { mensaje = "Selecciona un proveedor."; return false; }
            operacion.Proveedor = TListaProveedor.BuscarPorId(id);
            return TListaCompra.RegistrarCompra(operacion, out mensaje);
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!btnConfirmar.Enabled) return; btnConfirmar.Enabled = false;
            try
            {
                string mensaje;
                if (!ConfirmarActual(out mensaje)) { Ui.Avisar(this, mensaje); return; }
                
                DialogResult = DialogResult.OK; Close();
            }
            finally { if (!IsDisposed && !operacion.Confirmada) btnConfirmar.Enabled = true; }
        }
        private void btnCancelar_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; Close(); }
        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e) { if (!cargando && IsHandleCreated) ProductoSeleccionado(); }
    }
}
