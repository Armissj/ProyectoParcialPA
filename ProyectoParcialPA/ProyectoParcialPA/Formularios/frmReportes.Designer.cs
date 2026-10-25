namespace ProyectoParcialPA.Formularios
{
    partial class frmReportes
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
            this.lbl_cboReporte = new System.Windows.Forms.Label();
            this.cboReporte = new System.Windows.Forms.ComboBox();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.lblAyuda = new System.Windows.Forms.Label();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.lblResumen = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblTipoProducto = new System.Windows.Forms.Label();
            this.cboTipoProducto = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.picModulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.SuspendLayout();
            // picModulo
            this.picModulo.Name = "picModulo";
            this.picModulo.Location = new System.Drawing.Point(32, 23);
            this.picModulo.Size = new System.Drawing.Size(62, 62);
            this.picModulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.picModulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picModulo.BackColor = System.Drawing.Color.Transparent;
            this.picModulo.Tag = "asset:iconos/reportes.png";
            this.picModulo.TabStop = false;
            // lblTitulo
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Location = new System.Drawing.Point(112, 25);
            this.lblTitulo.Size = new System.Drawing.Size(750, 38);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTitulo.Text = "Reportes";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(23, 25, 23);
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.AutoSize = false;
            // lblSubtitulo
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Location = new System.Drawing.Point(113, 68);
            this.lblSubtitulo.Size = new System.Drawing.Size(820, 24);
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.Text = "Mira cómo se está moviendo tu tienda.";
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
            // lbl_cboReporte
            this.lbl_cboReporte.Name = "lbl_cboReporte";
            this.lbl_cboReporte.Location = new System.Drawing.Point(32, 130);
            this.lbl_cboReporte.Size = new System.Drawing.Size(280, 23);
            this.lbl_cboReporte.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_cboReporte.Text = "REPORTE";
            this.lbl_cboReporte.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_cboReporte.ForeColor = System.Drawing.Color.FromArgb(98, 103, 95);
            this.lbl_cboReporte.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cboReporte.AutoSize = false;
            // cboReporte
            this.cboReporte.Name = "cboReporte";
            this.cboReporte.Location = new System.Drawing.Point(32, 155);
            this.cboReporte.Size = new System.Drawing.Size(280, 34);
            this.cboReporte.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReporte.IntegralHeight = false;
            this.cboReporte.Items.AddRange(new object[] { "Inventario actual", "Compras", "Ventas" });
            // lblDesde
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Location = new System.Drawing.Point(338, 130);
            this.lblDesde.Size = new System.Drawing.Size(170, 23);
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDesde.Text = "DESDE";
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDesde.ForeColor = System.Drawing.Color.FromArgb(98, 103, 95);
            this.lblDesde.BackColor = System.Drawing.Color.Transparent;
            this.lblDesde.AutoSize = false;
            // dtpDesde
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Location = new System.Drawing.Point(338, 155);
            this.dtpDesde.Size = new System.Drawing.Size(210, 34);
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // lblHasta
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Location = new System.Drawing.Point(572, 130);
            this.lblHasta.Size = new System.Drawing.Size(170, 23);
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHasta.Text = "HASTA";
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHasta.ForeColor = System.Drawing.Color.FromArgb(98, 103, 95);
            this.lblHasta.BackColor = System.Drawing.Color.Transparent;
            this.lblHasta.AutoSize = false;
            // dtpHasta
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Location = new System.Drawing.Point(572, 155);
            this.dtpHasta.Size = new System.Drawing.Size(210, 34);
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // btnConsultar
            this.btnConsultar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Location = new System.Drawing.Point(809, 155);
            this.btnConsultar.Size = new System.Drawing.Size(168, 36);
            this.btnConsultar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.FlatAppearance.BorderSize = 0;
            this.btnConsultar.BackColor = System.Drawing.Color.FromArgb(209, 255, 50);
            this.btnConsultar.ForeColor = System.Drawing.Color.FromArgb(23, 25, 23);
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConsultar.Tag = "icon:buscar";
            this.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // btnExportar
            this.btnExportar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Location = new System.Drawing.Point(997, 155);
            this.btnExportar.Size = new System.Drawing.Size(171, 36);
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExportar.Text = "Exportar CSV";
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(245, 243, 236);
            this.btnExportar.ForeColor = System.Drawing.Color.FromArgb(23, 25, 23);
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportar.Tag = "icon:exportar";
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // lblAyuda
            this.lblAyuda.Name = "lblAyuda";
            this.lblAyuda.Location = new System.Drawing.Point(32, 204);
            this.lblAyuda.Size = new System.Drawing.Size(745, 25);
            this.lblAyuda.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAyuda.Text = "Las fechas corresponden a compras y ventas. El inventario muestra el estado actual.";
            this.lblAyuda.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblAyuda.ForeColor = System.Drawing.Color.FromArgb(98, 103, 95);
            this.lblAyuda.BackColor = System.Drawing.Color.Transparent;
            this.lblAyuda.AutoSize = false;
            // dgvReporte
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.Location = new System.Drawing.Point(32, 247);
            this.dgvReporte.Size = new System.Drawing.Size(1136, 345);
            this.dgvReporte.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvReporte.ReadOnly = true;
            this.dgvReporte.AllowUserToAddRows = false;
            this.dgvReporte.AllowUserToDeleteRows = false;
            this.dgvReporte.AutoGenerateColumns = true;
            this.dgvReporte.RowHeadersVisible = false;
            this.dgvReporte.MultiSelect = false;
            this.dgvReporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporte.BackgroundColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.dgvReporte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            // lblResumen
            this.lblResumen.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Location = new System.Drawing.Point(32, 620);
            this.lblResumen.Size = new System.Drawing.Size(800, 46);
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblResumen.Text = "Registros: 0    |    Total: $ 0.00";
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblResumen.ForeColor = System.Drawing.Color.FromArgb(23, 25, 23);
            this.lblResumen.BackColor = System.Drawing.Color.Transparent;
            this.lblResumen.AutoSize = false;
            // btnSalir
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Location = new System.Drawing.Point(977, 620);
            this.btnSalir.Size = new System.Drawing.Size(191, 44);
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSalir.Text = "Volver";
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(245, 243, 236);
            this.btnSalir.ForeColor = System.Drawing.Color.FromArgb(23, 25, 23);
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSalir.Tag = "icon:volver";
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // lblTipoProducto
            this.lblTipoProducto.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblTipoProducto.Name = "lblTipoProducto";
            this.lblTipoProducto.Location = new System.Drawing.Point(809, 203);
            this.lblTipoProducto.Size = new System.Drawing.Size(128, 25);
            this.lblTipoProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTipoProducto.Text = "Tipo de producto";
            this.lblTipoProducto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipoProducto.ForeColor = System.Drawing.Color.FromArgb(23, 25, 23);
            this.lblTipoProducto.BackColor = System.Drawing.Color.Transparent;
            this.lblTipoProducto.AutoSize = false;
            // cboTipoProducto
            this.cboTipoProducto.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.cboTipoProducto.Name = "cboTipoProducto";
            this.cboTipoProducto.Location = new System.Drawing.Point(941, 199);
            this.cboTipoProducto.Size = new System.Drawing.Size(227, 34);
            this.cboTipoProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoProducto.IntegralHeight = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            this.cboReporte.SelectedIndexChanged += new System.EventHandler(this.cboReporte_SelectedIndexChanged);
            this.cboTipoProducto.SelectedIndexChanged += new System.EventHandler(this.cboTipoProducto_SelectedIndexChanged);
            this.Controls.Add(this.picModulo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lineaCabecera);
            this.Controls.Add(this.lbl_cboReporte);
            this.Controls.Add(this.cboReporte);
            this.Controls.Add(this.lblDesde);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.lblAyuda);
            this.Controls.Add(this.dgvReporte);
            this.Controls.Add(this.lblResumen);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblTipoProducto);
            this.Controls.Add(this.cboTipoProducto);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(245, 243, 236);
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.MinimumSize = new System.Drawing.Size(1216, 759);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "frmReportes";
            this.Text = "RAYAO* | Reportes";
            this.DoubleBuffered = true;
            ((System.ComponentModel.ISupportInitialize)(this.picModulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal System.Windows.Forms.PictureBox picModulo;
        internal System.Windows.Forms.Label lblTitulo;
        internal System.Windows.Forms.Label lblSubtitulo;
        internal System.Windows.Forms.Label lblMarca;
        internal System.Windows.Forms.Panel lineaCabecera;
        internal System.Windows.Forms.Label lbl_cboReporte;
        internal System.Windows.Forms.ComboBox cboReporte;
        internal System.Windows.Forms.Label lblDesde;
        internal System.Windows.Forms.DateTimePicker dtpDesde;
        internal System.Windows.Forms.Label lblHasta;
        internal System.Windows.Forms.DateTimePicker dtpHasta;
        internal System.Windows.Forms.Button btnConsultar;
        internal System.Windows.Forms.Button btnExportar;
        internal System.Windows.Forms.Label lblAyuda;
        internal System.Windows.Forms.DataGridView dgvReporte;
        internal System.Windows.Forms.Label lblResumen;
        internal System.Windows.Forms.Button btnSalir;
        internal System.Windows.Forms.Label lblTipoProducto;
        internal System.Windows.Forms.ComboBox cboTipoProducto;
    }
}