using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ProyectoParcialPA.Controladores;
using ProyectoParcialPA.Utilidades;
using ProyectoParcialPA.Visual;

namespace ProyectoParcialPA.Formularios
{
    public partial class frmReportes : Form
    {
        private bool cargando;
        private bool reporteValido;
        private DataTable tablaActual = new DataTable();
        internal DataTable TablaActual { get { return tablaActual.Copy(); } }
        public frmReportes()
        {
            InitializeComponent(); RayaoTema.Aplicar(this, "fondo_reportes"); RayaoTema.FormatearTipos(cboTipoProducto);
            dtpDesde.ValueChanged += FechaCambiada; dtpHasta.ValueChanged += FechaCambiada;
            Ui.AlCargar(this, "ConsultarReportes", delegate
            {
                cargando = true; dtpDesde.Value = DateTime.Today.AddMonths(-1); dtpHasta.Value = DateTime.Today;
                cboTipoProducto.Items.AddRange(TiposProducto.Todos); cboTipoProducto.SelectedIndex = 0; cboReporte.SelectedIndex = 0;
                cargando = false; ConsultarActual();
            });
        }
        internal void ConsultarActual()
        {
            if (!TListaUsuario.TienePermiso("ConsultarReportes")) { tablaActual.Clear(); dgvReporte.DataSource = null; Close(); return; }
            reporteValido = false; btnExportar.Enabled = false;
            bool inventario = cboReporte.SelectedIndex == 0;
            dtpDesde.Enabled = !inventario; dtpHasta.Enabled = !inventario;
            lblAyuda.Text = inventario ? "Inventario actual. Las fechas se aplican a compras y ventas." : "El rango incluye todos los movimientos de ambos días.";
            if (!inventario && dtpDesde.Value.Date > dtpHasta.Value.Date) { Ui.Avisar(this, "La fecha inicial debe ser anterior o igual a la final."); return; }
            string tipo = Convert.ToString(cboTipoProducto.SelectedItem);
            var tabla = new DataTable(); decimal total = 0m; int operaciones = 0;
            try
            {
                if (inventario)
                {
                    tabla.Columns.Add("Codigo"); tabla.Columns.Add("Nombre"); tabla.Columns.Add("Tipo");
                    tabla.Columns.Add("Precio", typeof(decimal)); tabla.Columns.Add("Stock", typeof(int)); tabla.Columns.Add("Valor", typeof(decimal));
                    foreach (var p in TListaProducto.ObtenerTodos().Where(p => TiposProducto.EsTipo(p, tipo)))
                    {
                        decimal valor = checked(p.Precio * p.Stock); total = checked(total + valor);
                        tabla.Rows.Add(p.Codigo, p.Nombre, RayaoTema.NombreTipo(p.GetType().Name), p.Precio, p.Stock, valor);
                    }
                    operaciones = tabla.Rows.Count;
                }
                else
                {
                    tabla.Columns.Add("Operacion", typeof(int)); tabla.Columns.Add("Fecha", typeof(DateTime));
                    tabla.Columns.Add(cboReporte.SelectedIndex == 1 ? "Proveedor" : "Cliente"); tabla.Columns.Add("Usuario");
                    tabla.Columns.Add("Codigo"); tabla.Columns.Add("Producto"); tabla.Columns.Add("Tipo");
                    tabla.Columns.Add("Cantidad", typeof(int)); tabla.Columns.Add(cboReporte.SelectedIndex == 1 ? "CostoUnitario" : "PrecioUnitario", typeof(decimal)); tabla.Columns.Add("Subtotal", typeof(decimal));
                    if (cboReporte.SelectedIndex == 1)
                    {
                        foreach (var c in TListaCompra.BuscarPorFechas(dtpDesde.Value, dtpHasta.Value))
                        foreach (var d in c.Detalles.Where(d => TiposProducto.EsTipo(d.Producto, tipo)))
                        { tabla.Rows.Add(c.Id, c.Fecha, c.Proveedor.Nombre, c.Usuario.NombreUsuario, d.CodigoProducto, d.NombreProducto, RayaoTema.NombreTipo(d.Producto.GetType().Name), d.Cantidad, d.CostoUnitario, d.Subtotal); total = checked(total + d.Subtotal); }
                    }
                    else
                    {
                        foreach (var v in TListaVenta.BuscarPorFechas(dtpDesde.Value, dtpHasta.Value))
                        foreach (var d in v.Detalles.Where(d => TiposProducto.EsTipo(d.Producto, tipo)))
                        { tabla.Rows.Add(v.Id, v.Fecha, v.Cliente.NombreCompleto, v.Usuario.NombreUsuario, d.CodigoProducto, d.NombreProducto, RayaoTema.NombreTipo(d.Producto.GetType().Name), d.Cantidad, d.PrecioUnitario, d.Subtotal); total = checked(total + d.Subtotal); }
                    }
                    operaciones = tabla.AsEnumerable().Select(r => r.Field<int>("Operacion")).Distinct().Count();
                }
                tablaActual = tabla; Ui.Tabla(dgvReporte, tabla); reporteValido = true; btnExportar.Enabled = true;
                lblResumen.Text = (inventario ? "Productos: " : "Operaciones: ") + operaciones + "  |  Filas: " + tabla.Rows.Count + "  |  Total mostrado: " + Ui.Dinero(total);
            }
            catch (OverflowException) { Ui.Avisar(this, "Los valores del reporte exceden el límite numérico permitido."); }
        }
        internal void ExportarActual(string ruta)
        {
            if (!TListaUsuario.TienePermiso("ConsultarReportes")) throw new UnauthorizedAccessException("La sesión no permite exportar reportes.");
            if (!reporteValido) throw new InvalidOperationException("Actualiza el reporte antes de exportarlo.");
            ExportadorCsv.Guardar(tablaActual, ruta);
        }
        private void FechaCambiada(object sender, EventArgs e)
        {
            if (!cargando && IsHandleCreated && cboReporte.SelectedIndex != 0) { reporteValido = false; btnExportar.Enabled = false; lblResumen.Text = "Pulsa Consultar para actualizar el rango de fechas."; }
        }
        private void btnConsultar_Click(object sender, EventArgs e) { ConsultarActual(); }
        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (!Ui.Permitir(this, "ConsultarReportes")) return;
            using (var guardar = new SaveFileDialog { Filter = "Archivo CSV (*.csv)|*.csv", FileName = "RAYAO-reporte-" + DateTime.Today.ToString("yyyyMMdd") + ".csv", DefaultExt = "csv", AddExtension = true, OverwritePrompt = true })
            {
                if (guardar.ShowDialog(this) != DialogResult.OK) return;
                try { ExportarActual(guardar.FileName); Ui.Avisar(this, "Reporte exportado correctamente."); }
                catch (Exception ex) { Ui.Avisar(this, "No se pudo guardar el archivo: " + ex.Message); }
            }
        }
        private void cboReporte_SelectedIndexChanged(object sender, EventArgs e) { if (!cargando && IsHandleCreated) ConsultarActual(); }
        private void cboTipoProducto_SelectedIndexChanged(object sender, EventArgs e) { if (!cargando && IsHandleCreated) ConsultarActual(); }
        private void btnSalir_Click(object sender, EventArgs e) { Close(); }
    }
}
