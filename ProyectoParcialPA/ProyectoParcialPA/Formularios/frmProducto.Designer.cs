namespace ProyectoParcialPA.Formularios
{
    partial class frmProducto
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
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.lbl_txtCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lbl_txtNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lbl_cboTipoProducto = new System.Windows.Forms.Label();
            this.cboTipoProducto = new System.Windows.Forms.ComboBox();
            this.lbl_numPrecio = new System.Windows.Forms.Label();
            this.numPrecio = new System.Windows.Forms.NumericUpDown();
            this.lbl_txtStock = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.lblDetalles = new System.Windows.Forms.Label();
            this.pnlCampos = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.picProducto = new System.Windows.Forms.PictureBox();
            this.lblFicha = new System.Windows.Forms.Label();
            this.lblAyuda = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picModulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProducto)).BeginInit();
            this.SuspendLayout();
            // picModulo
            this.picModulo.Name = "picModulo";
            this.picModulo.Location = new System.Drawing.Point(32, 23);
            this.picModulo.Size = new System.Drawing.Size(62, 62);
            this.picModulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.picModulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picModulo.BackColor = System.Drawing.Color.Transparent;
            this.picModulo.Tag = "asset:iconos/inventario.png";
            this.picModulo.TabStop = false;
            // lblTitulo
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Location = new System.Drawing.Point(112, 25);
            this.lblTitulo.Size = new System.Drawing.Size(750, 38);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTitulo.Text = "Productos";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(23, 25, 23);
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.AutoSize = false;
            // lblSubtitulo
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Location = new System.Drawing.Point(113, 68);
            this.lblSubtitulo.Size = new System.Drawing.Size(820, 24);
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.Text = "Cada producto tiene su propio sonido.";
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
            // pnlDatos
            this.pnlDatos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Location = new System.Drawing.Point(32, 130);
            this.pnlDatos.Size = new System.Drawing.Size(630, 540);
            this.pnlDatos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.pnlDatos.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            // lbl_txtCodigo
            this.lbl_txtCodigo.Name = "lbl_txtCodigo";
            this.lbl_txtCodigo.Location = new System.Drawing.Point(24, 20);
            this.lbl_txtCodigo.Size = new System.Drawing.Size(190, 23);
            this.lbl_txtCodigo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_txtCodigo.Text = "CÓDIGO";
            this.lbl_txtCodigo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_txtCodigo.ForeColor = System.Drawing.Color.FromArgb(98, 103, 95);
            this.lbl_txtCodigo.BackColor = System.Drawing.Color.Transparent;
            this.lbl_txtCodigo.AutoSize = false;
            // txtCodigo
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Location = new System.Drawing.Point(24, 45);
            this.txtCodigo.Size = new System.Drawing.Size(190, 34);
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.ReadOnly = false;
            this.txtCodigo.UseSystemPasswordChar = false;
            this.txtCodigo.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            // lbl_txtNombre
            this.lbl_txtNombre.Name = "lbl_txtNombre";
            this.lbl_txtNombre.Location = new System.Drawing.Point(234, 20);
            this.lbl_txtNombre.Size = new System.Drawing.Size(370, 23);
            this.lbl_txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_txtNombre.Text = "NOMBRE";
            this.lbl_txtNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_txtNombre.ForeColor = System.Drawing.Color.FromArgb(98, 103, 95);
            this.lbl_txtNombre.BackColor = System.Drawing.Color.Transparent;
            this.lbl_txtNombre.AutoSize = false;
            // txtNombre
            this.txtNombre.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Location = new System.Drawing.Point(234, 45);
            this.txtNombre.Size = new System.Drawing.Size(370, 34);
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.ReadOnly = false;
            this.txtNombre.UseSystemPasswordChar = false;
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            // lbl_cboTipoProducto
            this.lbl_cboTipoProducto.Name = "lbl_cboTipoProducto";
            this.lbl_cboTipoProducto.Location = new System.Drawing.Point(24, 99);
            this.lbl_cboTipoProducto.Size = new System.Drawing.Size(580, 23);
            this.lbl_cboTipoProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_cboTipoProducto.Text = "TIPO DE PRODUCTO";
            this.lbl_cboTipoProducto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_cboTipoProducto.ForeColor = System.Drawing.Color.FromArgb(98, 103, 95);
            this.lbl_cboTipoProducto.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cboTipoProducto.AutoSize = false;
            // cboTipoProducto
            this.cboTipoProducto.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.cboTipoProducto.Name = "cboTipoProducto";
            this.cboTipoProducto.Location = new System.Drawing.Point(24, 124);
            this.cboTipoProducto.Size = new System.Drawing.Size(580, 34);
            this.cboTipoProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoProducto.IntegralHeight = false;
            this.cboTipoProducto.Items.AddRange(new object[] { "Teclado", "Mouse", "MonitorPC", "Procesador", "MemoriaRAM", "TarjetaGrafica", "Microfono", "InterfazAudio", "Vinilo", "PerifericoPS5", "PerifericoSwitch", "ProductoGaming" });
            // lbl_numPrecio
            this.lbl_numPrecio.Name = "lbl_numPrecio";
            this.lbl_numPrecio.Location = new System.Drawing.Point(24, 178);
            this.lbl_numPrecio.Size = new System.Drawing.Size(190, 23);
            this.lbl_numPrecio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_numPrecio.Text = "PRECIO DE VENTA ($)";
            this.lbl_numPrecio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_numPrecio.ForeColor = System.Drawing.Color.FromArgb(98, 103, 95);
            this.lbl_numPrecio.BackColor = System.Drawing.Color.Transparent;
            this.lbl_numPrecio.AutoSize = false;
            // numPrecio
            this.numPrecio.Name = "numPrecio";
            this.numPrecio.Location = new System.Drawing.Point(24, 203);
            this.numPrecio.Size = new System.Drawing.Size(190, 34);
            this.numPrecio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numPrecio.DecimalPlaces = 2;
            this.numPrecio.Maximum = 1000000000M;
            this.numPrecio.Minimum = 0.01M;
            this.numPrecio.Value = 1M;
            this.numPrecio.ThousandsSeparator = true;
            // lbl_txtStock
            this.lbl_txtStock.Name = "lbl_txtStock";
            this.lbl_txtStock.Location = new System.Drawing.Point(234, 178);
            this.lbl_txtStock.Size = new System.Drawing.Size(160, 23);
            this.lbl_txtStock.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_txtStock.Text = "STOCK ACTUAL";
            this.lbl_txtStock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_txtStock.ForeColor = System.Drawing.Color.FromArgb(98, 103, 95);
            this.lbl_txtStock.BackColor = System.Drawing.Color.Transparent;
            this.lbl_txtStock.AutoSize = false;
            // txtStock
            this.txtStock.Name = "txtStock";
            this.txtStock.Location = new System.Drawing.Point(234, 203);
            this.txtStock.Size = new System.Drawing.Size(160, 34);
            this.txtStock.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStock.ReadOnly = true;
            this.txtStock.UseSystemPasswordChar = false;
            this.txtStock.BackColor = System.Drawing.Color.FromArgb(245, 243, 236);
            // chkActivo
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Location = new System.Drawing.Point(425, 208);
            this.chkActivo.Size = new System.Drawing.Size(180, 30);
            this.chkActivo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkActivo.Text = "Activo";
            this.chkActivo.Checked = true;
            this.chkActivo.Enabled = false;
            // lblDetalles
            this.lblDetalles.Name = "lblDetalles";
            this.lblDetalles.Location = new System.Drawing.Point(24, 264);
            this.lblDetalles.Size = new System.Drawing.Size(580, 25);
            this.lblDetalles.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDetalles.Text = "DATOS ESPECÍFICOS";
            this.lblDetalles.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetalles.ForeColor = System.Drawing.Color.FromArgb(23, 25, 23);
            this.lblDetalles.BackColor = System.Drawing.Color.Transparent;
            this.lblDetalles.AutoSize = false;
            // pnlCampos
            this.pnlCampos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pnlCampos.Name = "pnlCampos";
            this.pnlCampos.Location = new System.Drawing.Point(24, 297);
            this.pnlCampos.Size = new System.Drawing.Size(580, 160);
            this.pnlCampos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.pnlCampos.AutoScroll = true;
            this.pnlCampos.WrapContents = true;
            this.pnlCampos.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.pnlCampos.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            // btnGuardar
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Location = new System.Drawing.Point(24, 482);
            this.btnGuardar.Size = new System.Drawing.Size(275, 43);
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGuardar.Text = "Guardar producto";
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(209, 255, 50);
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(23, 25, 23);
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Tag = "icon:guardar";
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // btnCancelar
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Location = new System.Drawing.Point(315, 482);
            this.btnCancelar.Size = new System.Drawing.Size(289, 43);
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(245, 243, 236);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(23, 25, 23);
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            // picProducto
            this.picProducto.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.picProducto.Name = "picProducto";
            this.picProducto.Location = new System.Drawing.Point(738, 144);
            this.picProducto.Size = new System.Drawing.Size(360, 330);
            this.picProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.picProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProducto.BackColor = System.Drawing.Color.Transparent;
            this.picProducto.Tag = "asset:productos/teclado.png";
            this.picProducto.TabStop = false;
            // lblFicha
            this.lblFicha.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblFicha.Name = "lblFicha";
            this.lblFicha.Location = new System.Drawing.Point(728, 491);
            this.lblFicha.Size = new System.Drawing.Size(395, 35);
            this.lblFicha.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFicha.Text = "PC / GAMING / MÚSICA";
            this.lblFicha.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblFicha.ForeColor = System.Drawing.Color.FromArgb(23, 25, 23);
            this.lblFicha.BackColor = System.Drawing.Color.Transparent;
            this.lblFicha.AutoSize = false;
            // lblAyuda
            this.lblAyuda.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblAyuda.Name = "lblAyuda";
            this.lblAyuda.Location = new System.Drawing.Point(728, 542);
            this.lblAyuda.Size = new System.Drawing.Size(395, 95);
            this.lblAyuda.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAyuda.Text = "Selecciona un tipo para ver sus campos.\nEl stock cambia con compras y ventas confirmadas.";
            this.lblAyuda.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            this.lblAyuda.ForeColor = System.Drawing.Color.FromArgb(98, 103, 95);
            this.lblAyuda.BackColor = System.Drawing.Color.Transparent;
            this.lblAyuda.AutoSize = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.cboTipoProducto.SelectedIndexChanged += new System.EventHandler(this.cboTipoProducto_SelectedIndexChanged);
            this.Controls.Add(this.picModulo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lineaCabecera);
            this.Controls.Add(this.pnlDatos);
            this.pnlDatos.Controls.Add(this.lbl_txtCodigo);
            this.pnlDatos.Controls.Add(this.txtCodigo);
            this.pnlDatos.Controls.Add(this.lbl_txtNombre);
            this.pnlDatos.Controls.Add(this.txtNombre);
            this.pnlDatos.Controls.Add(this.lbl_cboTipoProducto);
            this.pnlDatos.Controls.Add(this.cboTipoProducto);
            this.pnlDatos.Controls.Add(this.lbl_numPrecio);
            this.pnlDatos.Controls.Add(this.numPrecio);
            this.pnlDatos.Controls.Add(this.lbl_txtStock);
            this.pnlDatos.Controls.Add(this.txtStock);
            this.pnlDatos.Controls.Add(this.chkActivo);
            this.pnlDatos.Controls.Add(this.lblDetalles);
            this.pnlDatos.Controls.Add(this.pnlCampos);
            this.pnlDatos.Controls.Add(this.btnGuardar);
            this.pnlDatos.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.picProducto);
            this.Controls.Add(this.lblFicha);
            this.Controls.Add(this.lblAyuda);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(245, 243, 236);
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.MinimumSize = new System.Drawing.Size(1216, 759);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "frmProducto";
            this.Text = "RAYAO* | Productos";
            this.DoubleBuffered = true;
            this.CancelButton = this.btnCancelar;
            ((System.ComponentModel.ISupportInitialize)(this.picModulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal System.Windows.Forms.PictureBox picModulo;
        internal System.Windows.Forms.Label lblTitulo;
        internal System.Windows.Forms.Label lblSubtitulo;
        internal System.Windows.Forms.Label lblMarca;
        internal System.Windows.Forms.Panel lineaCabecera;
        internal System.Windows.Forms.Panel pnlDatos;
        internal System.Windows.Forms.Label lbl_txtCodigo;
        internal System.Windows.Forms.TextBox txtCodigo;
        internal System.Windows.Forms.Label lbl_txtNombre;
        internal System.Windows.Forms.TextBox txtNombre;
        internal System.Windows.Forms.Label lbl_cboTipoProducto;
        internal System.Windows.Forms.ComboBox cboTipoProducto;
        internal System.Windows.Forms.Label lbl_numPrecio;
        internal System.Windows.Forms.NumericUpDown numPrecio;
        internal System.Windows.Forms.Label lbl_txtStock;
        internal System.Windows.Forms.TextBox txtStock;
        internal System.Windows.Forms.CheckBox chkActivo;
        internal System.Windows.Forms.Label lblDetalles;
        internal System.Windows.Forms.FlowLayoutPanel pnlCampos;
        internal System.Windows.Forms.Button btnGuardar;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.PictureBox picProducto;
        internal System.Windows.Forms.Label lblFicha;
        internal System.Windows.Forms.Label lblAyuda;
    }
}