namespace ProyectoParcialPA.Formularios
{
    partial class frmCompra
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picModulo = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lineaCabecera = new System.Windows.Forms.Panel();
            this.lbl_cboProveedor = new System.Windows.Forms.Label();
            this.cboProveedor = new System.Windows.Forms.ComboBox();
            this.lbl_cboProducto = new System.Windows.Forms.Label();
            this.cboProducto = new System.Windows.Forms.ComboBox();
            this.lbl_numCantidad = new System.Windows.Forms.Label();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.lbl_numCosto = new System.Windows.Forms.Label();
            this.numCosto = new System.Windows.Forms.NumericUpDown();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.lblStock = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblTotalTitulo = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picModulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // picModulo
            this.picModulo.Name = "picModulo";
            this.picModulo.Location = new System.Drawing.Point(32, 23);
            this.picModulo.Size = new System.Drawing.Size(62, 62);
            this.picModulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.picModulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picModulo.BackColor = System.Drawing.Color.Transparent;
            this.picModulo.Tag = "asset:iconos/compras.png";
            this.picModulo.TabStop = false;
            // lblTitulo
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Location = new System.Drawing.Point(112, 25);
            this.lblTitulo.Size = new System.Drawing.Size(750, 38);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTitulo.Text = "Compras";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(23, 25, 23);
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.AutoSize = false;
            // lblSubtitulo
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Location = new System.Drawing.Point(113, 68);
            this.lblSubtitulo.Size = new System.Drawing.Size(820, 24);
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.Text = "Trae cosas nuevas a la tienda.";
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(98, 103, 95);
            this.lblSubtitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitulo.AutoSize = false;
            // lblMarca
            this.lblMarca.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Location = new System.Drawing.Point(975, 27);
            this.lblMarca.Size = new System.Drawing.Size(195, 43);
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMarca.Text = "RAYAO*";
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 27F, System.Drawing.FontStyle.Bold);
            this.lblMarca.ForeColor = System.Drawing.Color.FromArgb(23, 25, 23);
            this.lblMarca.BackColor = System.Drawing.Color.FromArgb(245, 243, 236);
            this.lblMarca.AutoSize = false;
            // lineaCabecera
            this.lineaCabecera.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.lineaCabecera.Name = "lineaCabecera";
            this.lineaCabecera.Location = new System.Drawing.Point(32, 108);
            this.lineaCabecera.Size = new System.Drawing.Size(1136, 2);
            this.lineaCabecera.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lineaCabecera.BackColor = System.Drawing.Color.FromArgb(23, 25, 23);
            // lbl_cboProveedor
            this.lbl_cboProveedor.Name = "lbl_cboProveedor";
            this.lbl_cboProveedor.Location = new System.Drawing.Point(32, 130);
            this.lbl_cboProveedor.Size = new System.Drawing.Size(260, 23);
            this.lbl_cboProveedor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_cboProveedor.Text = "PROVEEDOR";
            this.lbl_cboProveedor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_cboProveedor.ForeColor = System.Drawing.Color.FromArgb(98, 103, 95);
            this.lbl_cboProveedor.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cboProveedor.AutoSize = false;
            // cboProveedor
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Location = new System.Drawing.Point(32, 155);
            this.cboProveedor.Size = new System.Drawing.Size(260, 34);
            this.cboProveedor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProveedor.IntegralHeight = false;
            // lbl_cboProducto
            this.lbl_cboProducto.Name = "lbl_cboProducto";
            this.lbl_cboProducto.Location = new System.Drawing.Point(312, 130);
            this.lbl_cboProducto.Size = new System.Drawing.Size(330, 23);
            this.lbl_cboProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_cboProducto.Text = "PRODUCTO";
            this.lbl_cboProducto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_cboProducto.ForeColor = System.Drawing.Color.FromArgb(98, 103, 95);
            this.lbl_cboProducto.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cboProducto.AutoSize = false;
            // cboProducto
            this.cboProducto.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Location = new System.Drawing.Point(312, 155);
            this.cboProducto.Size = new System.Drawing.Size(330, 34);
            this.cboProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto.IntegralHeight = false;
            // lbl_numCantidad
            this.lbl_numCantidad.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lbl_numCantidad.Name = "lbl_numCantidad";
            this.lbl_numCantidad.Location = new System.Drawing.Point(662, 130);
            this.lbl_numCantidad.Size = new System.Drawing.Size(115, 23);
            this.lbl_numCantidad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_numCantidad.Text = "CANTIDAD";
            this.lbl_numCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_numCantidad.ForeColor = System.Drawing.Color.FromArgb(98, 103, 95);
            this.lbl_numCantidad.BackColor = System.Drawing.Color.Transparent;
            this.lbl_numCantidad.AutoSize = false;
            // numCantidad
            this.numCantidad.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Location = new System.Drawing.Point(662, 155);
            this.numCantidad.Size = new System.Drawing.Size(115, 34);
            this.numCantidad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numCantidad.DecimalPlaces = 0;
            this.numCantidad.Maximum = 1000000000M;
            this.numCantidad.Minimum = 1M;
            this.numCantidad.Value = 1M;
            this.numCantidad.ThousandsSeparator = true;
            // lbl_numCosto
            this.lbl_numCosto.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lbl_numCosto.Name = "lbl_numCosto";
            this.lbl_numCosto.Location = new System.Drawing.Point(797, 130);
            this.lbl_numCosto.Size = new System.Drawing.Size(165, 23);
            this.lbl_numCosto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_numCosto.Text = "COSTO UNITARIO ($)";
            this.lbl_numCosto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_numCosto.ForeColor = System.Drawing.Color.FromArgb(98, 103, 95);
            this.lbl_numCosto.BackColor = System.Drawing.Color.Transparent;
            this.lbl_numCosto.AutoSize = false;
            // numCosto
            this.numCosto.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.numCosto.Name = "numCosto";
            this.numCosto.Location = new System.Drawing.Point(797, 155);
            this.numCosto.Size = new System.Drawing.Size(165, 34);
            this.numCosto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numCosto.DecimalPlaces = 2;
            this.numCosto.Maximum = 1000000000M;
            this.numCosto.Minimum = 0.01M;
            this.numCosto.Value = 1M;
            this.numCosto.ThousandsSeparator = true;
            // btnAgregarProducto
            this.btnAgregarProducto.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Location = new System.Drawing.Point(982, 155);
            this.btnAgregarProducto.Size = new System.Drawing.Size(186, 36);
            this.btnAgregarProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAgregarProducto.Text = "Agregar a la lista";
            this.btnAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarProducto.FlatAppearance.BorderSize = 0;
            this.btnAgregarProducto.BackColor = System.Drawing.Color.FromArgb(209, 255, 50);
            this.btnAgregarProducto.ForeColor = System.Drawing.Color.FromArgb(23, 25, 23);
            this.btnAgregarProducto.UseVisualStyleBackColor = false;
            this.btnAgregarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarProducto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAgregarProducto.Tag = "icon:agregar";
            this.btnAgregarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // lblStock
            this.lblStock.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.lblStock.Name = "lblStock";
            this.lblStock.Location = new System.Drawing.Point(312, 197);
            this.lblStock.Size = new System.Drawing.Size(640, 25);
            this.lblStock.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStock.Text = "El stock aumenta cuando confirmas la compra.";
            this.lblStock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblStock.ForeColor = System.Drawing.Color.FromArgb(98, 103, 95);
            this.lblStock.BackColor = System.Drawing.Color.Transparent;
            this.lblStock.AutoSize = false;
            // dgvDetalle
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Location = new System.Drawing.Point(32, 239);
            this.dgvDetalle.Size = new System.Drawing.Size(1136, 292);
            this.dgvDetalle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AutoGenerateColumns = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            // btnQuitar
            this.btnQuitar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Location = new System.Drawing.Point(32, 551);
            this.btnQuitar.Size = new System.Drawing.Size(210, 40);
            this.btnQuitar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnQuitar.Text = "Quitar seleccionado";
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.FlatAppearance.BorderSize = 0;
            this.btnQuitar.BackColor = System.Drawing.Color.FromArgb(245, 243, 236);
            this.btnQuitar.ForeColor = System.Drawing.Color.FromArgb(23, 25, 23);
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuitar.Tag = "icon:eliminar";
            this.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // lblInfo
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Location = new System.Drawing.Point(32, 615);
            this.lblInfo.Size = new System.Drawing.Size(610, 55);
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfo.Text = "Revisa las cantidades y los importes antes de confirmar.";
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(98, 103, 95);
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.AutoSize = false;
            // lblTotalTitulo
            this.lblTotalTitulo.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.lblTotalTitulo.Name = "lblTotalTitulo";
            this.lblTotalTitulo.Location = new System.Drawing.Point(815, 550);
            this.lblTotalTitulo.Size = new System.Drawing.Size(350, 25);
            this.lblTotalTitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalTitulo.Text = "TOTAL DE LA COMPRA";
            this.lblTotalTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalTitulo.ForeColor = System.Drawing.Color.FromArgb(98, 103, 95);
            this.lblTotalTitulo.BackColor = System.Drawing.Color.FromArgb(245, 243, 236);
            this.lblTotalTitulo.AutoSize = false;
            // lblTotal
            this.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Location = new System.Drawing.Point(815, 582);
            this.lblTotal.Size = new System.Drawing.Size(350, 50);
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotal.Text = "$ 0.00";
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 31F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(23, 25, 23);
            this.lblTotal.BackColor = System.Drawing.Color.FromArgb(245, 243, 236);
            this.lblTotal.AutoSize = false;
            // btnCancelar
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Location = new System.Drawing.Point(680, 644);
            this.btnCancelar.Size = new System.Drawing.Size(210, 45);
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(245, 243, 236);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(23, 25, 23);
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            // btnConfirmar
            this.btnConfirmar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Location = new System.Drawing.Point(910, 644);
            this.btnConfirmar.Size = new System.Drawing.Size(258, 45);
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnConfirmar.Text = "Confirmar compra";
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(209, 255, 50);
            this.btnConfirmar.ForeColor = System.Drawing.Color.FromArgb(23, 25, 23);
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirmar.Tag = "icon:confirmar";
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            this.cboProducto.SelectedIndexChanged += new System.EventHandler(this.cboProducto_SelectedIndexChanged);
            this.Controls.Add(this.picModulo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lineaCabecera);
            this.Controls.Add(this.lbl_cboProveedor);
            this.Controls.Add(this.cboProveedor);
            this.Controls.Add(this.lbl_cboProducto);
            this.Controls.Add(this.cboProducto);
            this.Controls.Add(this.lbl_numCantidad);
            this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.lbl_numCosto);
            this.Controls.Add(this.numCosto);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblTotalTitulo);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(245, 243, 236);
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.MinimumSize = new System.Drawing.Size(1216, 759);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "frmCompra";
            this.Text = "RAYAO* | Compras";
            this.DoubleBuffered = true;
            ((System.ComponentModel.ISupportInitialize)(this.picModulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCosto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal System.Windows.Forms.PictureBox picModulo;
        internal System.Windows.Forms.Label lblTitulo;
        internal System.Windows.Forms.Label lblSubtitulo;
        internal System.Windows.Forms.Label lblMarca;
        internal System.Windows.Forms.Panel lineaCabecera;
        internal System.Windows.Forms.Label lbl_cboProveedor;
        internal System.Windows.Forms.ComboBox cboProveedor;
        internal System.Windows.Forms.Label lbl_cboProducto;
        internal System.Windows.Forms.ComboBox cboProducto;
        internal System.Windows.Forms.Label lbl_numCantidad;
        internal System.Windows.Forms.NumericUpDown numCantidad;
        internal System.Windows.Forms.Label lbl_numCosto;
        internal System.Windows.Forms.NumericUpDown numCosto;
        internal System.Windows.Forms.Button btnAgregarProducto;
        internal System.Windows.Forms.Label lblStock;
        internal System.Windows.Forms.DataGridView dgvDetalle;
        internal System.Windows.Forms.Button btnQuitar;
        internal System.Windows.Forms.Label lblInfo;
        internal System.Windows.Forms.Label lblTotalTitulo;
        internal System.Windows.Forms.Label lblTotal;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Button btnConfirmar;
    }
}