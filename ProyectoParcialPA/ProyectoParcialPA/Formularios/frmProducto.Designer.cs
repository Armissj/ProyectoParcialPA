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
            this.pnlDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // picModulo
            // 
            this.picModulo.BackColor = System.Drawing.Color.Transparent;
            this.picModulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.picModulo.Location = new System.Drawing.Point(32, 23);
            this.picModulo.Name = "picModulo";
            this.picModulo.Size = new System.Drawing.Size(62, 62);
            this.picModulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picModulo.TabIndex = 0;
            this.picModulo.TabStop = false;
            this.picModulo.Tag = "asset:iconos/inventario.png";
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(25)))), ((int)(((byte)(23)))));
            this.lblTitulo.Location = new System.Drawing.Point(112, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(750, 38);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Productos";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(103)))), ((int)(((byte)(95)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(113, 68);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(820, 24);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Cada producto tiene su propio sonido.";
            // 
            // lblMarca
            // 
            this.lblMarca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMarca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(236)))));
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 27F, System.Drawing.FontStyle.Bold);
            this.lblMarca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(25)))), ((int)(((byte)(23)))));
            this.lblMarca.Location = new System.Drawing.Point(975, 27);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(195, 43);
            this.lblMarca.TabIndex = 3;
            this.lblMarca.Text = "RAYAO*";
            // 
            // lineaCabecera
            // 
            this.lineaCabecera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineaCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(25)))), ((int)(((byte)(23)))));
            this.lineaCabecera.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lineaCabecera.Location = new System.Drawing.Point(32, 108);
            this.lineaCabecera.Name = "lineaCabecera";
            this.lineaCabecera.Size = new System.Drawing.Size(1136, 2);
            this.lineaCabecera.TabIndex = 4;
            // 
            // pnlDatos
            // 
            this.pnlDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
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
            this.pnlDatos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.pnlDatos.Location = new System.Drawing.Point(32, 130);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(630, 540);
            this.pnlDatos.TabIndex = 5;
            // 
            // lbl_txtCodigo
            // 
            this.lbl_txtCodigo.BackColor = System.Drawing.Color.Transparent;
            this.lbl_txtCodigo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_txtCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(103)))), ((int)(((byte)(95)))));
            this.lbl_txtCodigo.Location = new System.Drawing.Point(24, 20);
            this.lbl_txtCodigo.Name = "lbl_txtCodigo";
            this.lbl_txtCodigo.Size = new System.Drawing.Size(190, 23);
            this.lbl_txtCodigo.TabIndex = 0;
            this.lbl_txtCodigo.Text = "CÓDIGO";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCodigo.Location = new System.Drawing.Point(24, 45);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(190, 25);
            this.txtCodigo.TabIndex = 1;
            // 
            // lbl_txtNombre
            // 
            this.lbl_txtNombre.BackColor = System.Drawing.Color.Transparent;
            this.lbl_txtNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_txtNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(103)))), ((int)(((byte)(95)))));
            this.lbl_txtNombre.Location = new System.Drawing.Point(234, 20);
            this.lbl_txtNombre.Name = "lbl_txtNombre";
            this.lbl_txtNombre.Size = new System.Drawing.Size(370, 23);
            this.lbl_txtNombre.TabIndex = 2;
            this.lbl_txtNombre.Text = "NOMBRE";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.Location = new System.Drawing.Point(234, 45);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(370, 25);
            this.txtNombre.TabIndex = 3;
            // 
            // lbl_cboTipoProducto
            // 
            this.lbl_cboTipoProducto.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cboTipoProducto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_cboTipoProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(103)))), ((int)(((byte)(95)))));
            this.lbl_cboTipoProducto.Location = new System.Drawing.Point(24, 99);
            this.lbl_cboTipoProducto.Name = "lbl_cboTipoProducto";
            this.lbl_cboTipoProducto.Size = new System.Drawing.Size(580, 23);
            this.lbl_cboTipoProducto.TabIndex = 4;
            this.lbl_cboTipoProducto.Text = "TIPO DE PRODUCTO";
            // 
            // cboTipoProducto
            // 
            this.cboTipoProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTipoProducto.IntegralHeight = false;
            this.cboTipoProducto.Items.AddRange(new object[] {
            "Teclado",
            "Mouse",
            "MonitorPC",
            "Procesador",
            "MemoriaRAM",
            "TarjetaGrafica",
            "Microfono",
            "InterfazAudio",
            "Vinilo",
            "PerifericoPS5",
            "PerifericoSwitch",
            "ProductoGaming"});
            this.cboTipoProducto.Location = new System.Drawing.Point(24, 124);
            this.cboTipoProducto.Name = "cboTipoProducto";
            this.cboTipoProducto.Size = new System.Drawing.Size(580, 25);
            this.cboTipoProducto.TabIndex = 5;
            this.cboTipoProducto.SelectedIndexChanged += new System.EventHandler(this.cboTipoProducto_SelectedIndexChanged);
            // 
            // lbl_numPrecio
            // 
            this.lbl_numPrecio.BackColor = System.Drawing.Color.Transparent;
            this.lbl_numPrecio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_numPrecio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(103)))), ((int)(((byte)(95)))));
            this.lbl_numPrecio.Location = new System.Drawing.Point(24, 178);
            this.lbl_numPrecio.Name = "lbl_numPrecio";
            this.lbl_numPrecio.Size = new System.Drawing.Size(190, 23);
            this.lbl_numPrecio.TabIndex = 6;
            this.lbl_numPrecio.Text = "PRECIO DE VENTA ($)";
            // 
            // numPrecio
            // 
            this.numPrecio.DecimalPlaces = 2;
            this.numPrecio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numPrecio.Location = new System.Drawing.Point(24, 203);
            this.numPrecio.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numPrecio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numPrecio.Name = "numPrecio";
            this.numPrecio.Size = new System.Drawing.Size(190, 25);
            this.numPrecio.TabIndex = 7;
            this.numPrecio.ThousandsSeparator = true;
            this.numPrecio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbl_txtStock
            // 
            this.lbl_txtStock.BackColor = System.Drawing.Color.Transparent;
            this.lbl_txtStock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_txtStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(103)))), ((int)(((byte)(95)))));
            this.lbl_txtStock.Location = new System.Drawing.Point(234, 178);
            this.lbl_txtStock.Name = "lbl_txtStock";
            this.lbl_txtStock.Size = new System.Drawing.Size(160, 23);
            this.lbl_txtStock.TabIndex = 8;
            this.lbl_txtStock.Text = "STOCK ACTUAL";
            // 
            // txtStock
            // 
            this.txtStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(236)))));
            this.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStock.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStock.Location = new System.Drawing.Point(234, 203);
            this.txtStock.Name = "txtStock";
            this.txtStock.ReadOnly = true;
            this.txtStock.Size = new System.Drawing.Size(160, 25);
            this.txtStock.TabIndex = 9;
            // 
            // chkActivo
            // 
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.Enabled = false;
            this.chkActivo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkActivo.Location = new System.Drawing.Point(425, 208);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(180, 30);
            this.chkActivo.TabIndex = 10;
            this.chkActivo.Text = "Activo";
            // 
            // lblDetalles
            // 
            this.lblDetalles.BackColor = System.Drawing.Color.Transparent;
            this.lblDetalles.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetalles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(25)))), ((int)(((byte)(23)))));
            this.lblDetalles.Location = new System.Drawing.Point(24, 264);
            this.lblDetalles.Name = "lblDetalles";
            this.lblDetalles.Size = new System.Drawing.Size(580, 25);
            this.lblDetalles.TabIndex = 11;
            this.lblDetalles.Text = "DATOS ESPECÍFICOS";
            // 
            // pnlCampos
            // 
            this.pnlCampos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCampos.AutoScroll = true;
            this.pnlCampos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlCampos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.pnlCampos.Location = new System.Drawing.Point(24, 297);
            this.pnlCampos.Name = "pnlCampos";
            this.pnlCampos.Size = new System.Drawing.Size(580, 160);
            this.pnlCampos.TabIndex = 12;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(255)))), ((int)(((byte)(50)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(25)))), ((int)(((byte)(23)))));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(24, 482);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(275, 43);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Tag = "icon:guardar";
            this.btnGuardar.Text = "Guardar producto";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(236)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(25)))), ((int)(((byte)(23)))));
            this.btnCancelar.Location = new System.Drawing.Point(315, 482);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(289, 43);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // picProducto
            // 
            this.picProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picProducto.BackColor = System.Drawing.Color.Transparent;
            this.picProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.picProducto.Location = new System.Drawing.Point(738, 144);
            this.picProducto.Name = "picProducto";
            this.picProducto.Size = new System.Drawing.Size(360, 330);
            this.picProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProducto.TabIndex = 6;
            this.picProducto.TabStop = false;
            this.picProducto.Tag = "asset:productos/teclado.png";
            // 
            // lblFicha
            // 
            this.lblFicha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFicha.BackColor = System.Drawing.Color.Transparent;
            this.lblFicha.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblFicha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(25)))), ((int)(((byte)(23)))));
            this.lblFicha.Location = new System.Drawing.Point(728, 491);
            this.lblFicha.Name = "lblFicha";
            this.lblFicha.Size = new System.Drawing.Size(395, 35);
            this.lblFicha.TabIndex = 7;
            this.lblFicha.Text = "PC / GAMING / MÚSICA";
            // 
            // lblAyuda
            // 
            this.lblAyuda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAyuda.BackColor = System.Drawing.Color.Transparent;
            this.lblAyuda.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblAyuda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(103)))), ((int)(((byte)(95)))));
            this.lblAyuda.Location = new System.Drawing.Point(728, 542);
            this.lblAyuda.Name = "lblAyuda";
            this.lblAyuda.Size = new System.Drawing.Size(395, 95);
            this.lblAyuda.TabIndex = 8;
            this.lblAyuda.Text = "Selecciona un tipo para ver sus campos.\nEl stock cambia con compras y ventas conf" +
    "irmadas.";
            // 
            // frmProducto
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(236)))));
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.picModulo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lineaCabecera);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.picProducto);
            this.Controls.Add(this.lblFicha);
            this.Controls.Add(this.lblAyuda);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1216, 759);
            this.Name = "frmProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RAYAO* | Productos";
            ((System.ComponentModel.ISupportInitialize)(this.picModulo)).EndInit();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProducto)).EndInit();
            this.ResumeLayout(false);

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