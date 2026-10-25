namespace ProyectoParcialPA.Formularios
{
    partial class frmProveedores
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
            this.lbl_txtBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.pnlEditor = new System.Windows.Forms.Panel();
            this.lblEditor = new System.Windows.Forms.Label();
            this.lbl_txtNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lbl_txtContacto = new System.Windows.Forms.Label();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.lbl_txtTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lbl_txtEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnDesactivar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picModulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.SuspendLayout();
            // picModulo
            this.picModulo.Name = "picModulo";
            this.picModulo.Location = new System.Drawing.Point(32, 23);
            this.picModulo.Size = new System.Drawing.Size(62, 62);
            this.picModulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.picModulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picModulo.BackColor = System.Drawing.Color.Transparent;
            this.picModulo.Tag = "asset:iconos/proveedores.png";
            this.picModulo.TabStop = false;
            // lblTitulo
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Location = new System.Drawing.Point(112, 25);
            this.lblTitulo.Size = new System.Drawing.Size(750, 38);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTitulo.Text = "Proveedores";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(23, 25, 23);
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.AutoSize = false;
            // lblSubtitulo
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Location = new System.Drawing.Point(113, 68);
            this.lblSubtitulo.Size = new System.Drawing.Size(820, 24);
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.Text = "Organiza los contactos que abastecen la tienda.";
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
            // lbl_txtBuscar
            this.lbl_txtBuscar.Name = "lbl_txtBuscar";
            this.lbl_txtBuscar.Location = new System.Drawing.Point(32, 130);
            this.lbl_txtBuscar.Size = new System.Drawing.Size(495, 23);
            this.lbl_txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_txtBuscar.Text = "BUSCAR";
            this.lbl_txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_txtBuscar.ForeColor = System.Drawing.Color.FromArgb(98, 103, 95);
            this.lbl_txtBuscar.BackColor = System.Drawing.Color.Transparent;
            this.lbl_txtBuscar.AutoSize = false;
            // txtBuscar
            this.txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Location = new System.Drawing.Point(32, 155);
            this.txtBuscar.Size = new System.Drawing.Size(495, 34);
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.ReadOnly = false;
            this.txtBuscar.UseSystemPasswordChar = false;
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            // btnBuscar
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Location = new System.Drawing.Point(545, 155);
            this.btnBuscar.Size = new System.Drawing.Size(175, 36);
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(245, 243, 236);
            this.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(23, 25, 23);
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.Tag = "icon:buscar";
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // dgvProveedores
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.Location = new System.Drawing.Point(32, 218);
            this.dgvProveedores.Size = new System.Drawing.Size(688, 378);
            this.dgvProveedores.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvProveedores.ReadOnly = true;
            this.dgvProveedores.AllowUserToAddRows = false;
            this.dgvProveedores.AllowUserToDeleteRows = false;
            this.dgvProveedores.AutoGenerateColumns = true;
            this.dgvProveedores.RowHeadersVisible = false;
            this.dgvProveedores.MultiSelect = false;
            this.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProveedores.BackgroundColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.dgvProveedores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProveedores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            // pnlEditor
            this.pnlEditor.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.pnlEditor.Name = "pnlEditor";
            this.pnlEditor.Location = new System.Drawing.Point(750, 130);
            this.pnlEditor.Size = new System.Drawing.Size(418, 525);
            this.pnlEditor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.pnlEditor.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            // lblEditor
            this.lblEditor.Name = "lblEditor";
            this.lblEditor.Location = new System.Drawing.Point(25, 18);
            this.lblEditor.Size = new System.Drawing.Size(365, 35);
            this.lblEditor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEditor.Text = "DATOS DEL REGISTRO";
            this.lblEditor.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblEditor.ForeColor = System.Drawing.Color.FromArgb(23, 25, 23);
            this.lblEditor.BackColor = System.Drawing.Color.Transparent;
            this.lblEditor.AutoSize = false;
            // lbl_txtNombre
            this.lbl_txtNombre.Name = "lbl_txtNombre";
            this.lbl_txtNombre.Location = new System.Drawing.Point(25, 64);
            this.lbl_txtNombre.Size = new System.Drawing.Size(365, 23);
            this.lbl_txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_txtNombre.Text = "NOMBRE";
            this.lbl_txtNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_txtNombre.ForeColor = System.Drawing.Color.FromArgb(98, 103, 95);
            this.lbl_txtNombre.BackColor = System.Drawing.Color.Transparent;
            this.lbl_txtNombre.AutoSize = false;
            // txtNombre
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Location = new System.Drawing.Point(25, 89);
            this.txtNombre.Size = new System.Drawing.Size(365, 34);
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.ReadOnly = false;
            this.txtNombre.UseSystemPasswordChar = false;
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            // lbl_txtContacto
            this.lbl_txtContacto.Name = "lbl_txtContacto";
            this.lbl_txtContacto.Location = new System.Drawing.Point(25, 136);
            this.lbl_txtContacto.Size = new System.Drawing.Size(365, 23);
            this.lbl_txtContacto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_txtContacto.Text = "CONTACTO";
            this.lbl_txtContacto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_txtContacto.ForeColor = System.Drawing.Color.FromArgb(98, 103, 95);
            this.lbl_txtContacto.BackColor = System.Drawing.Color.Transparent;
            this.lbl_txtContacto.AutoSize = false;
            // txtContacto
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Location = new System.Drawing.Point(25, 161);
            this.txtContacto.Size = new System.Drawing.Size(365, 34);
            this.txtContacto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtContacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContacto.ReadOnly = false;
            this.txtContacto.UseSystemPasswordChar = false;
            this.txtContacto.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            // lbl_txtTelefono
            this.lbl_txtTelefono.Name = "lbl_txtTelefono";
            this.lbl_txtTelefono.Location = new System.Drawing.Point(25, 208);
            this.lbl_txtTelefono.Size = new System.Drawing.Size(365, 23);
            this.lbl_txtTelefono.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_txtTelefono.Text = "TELÉFONO";
            this.lbl_txtTelefono.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_txtTelefono.ForeColor = System.Drawing.Color.FromArgb(98, 103, 95);
            this.lbl_txtTelefono.BackColor = System.Drawing.Color.Transparent;
            this.lbl_txtTelefono.AutoSize = false;
            // txtTelefono
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Location = new System.Drawing.Point(25, 233);
            this.txtTelefono.Size = new System.Drawing.Size(365, 34);
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.ReadOnly = false;
            this.txtTelefono.UseSystemPasswordChar = false;
            this.txtTelefono.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            // lbl_txtEmail
            this.lbl_txtEmail.Name = "lbl_txtEmail";
            this.lbl_txtEmail.Location = new System.Drawing.Point(25, 280);
            this.lbl_txtEmail.Size = new System.Drawing.Size(365, 23);
            this.lbl_txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_txtEmail.Text = "EMAIL";
            this.lbl_txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_txtEmail.ForeColor = System.Drawing.Color.FromArgb(98, 103, 95);
            this.lbl_txtEmail.BackColor = System.Drawing.Color.Transparent;
            this.lbl_txtEmail.AutoSize = false;
            // txtEmail
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Location = new System.Drawing.Point(25, 305);
            this.txtEmail.Size = new System.Drawing.Size(365, 34);
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.ReadOnly = false;
            this.txtEmail.UseSystemPasswordChar = false;
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            // chkActivo
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Location = new System.Drawing.Point(25, 352);
            this.chkActivo.Size = new System.Drawing.Size(225, 30);
            this.chkActivo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkActivo.Text = "Registro activo";
            this.chkActivo.Checked = true;
            // btnGuardar
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Location = new System.Drawing.Point(25, 465);
            this.btnGuardar.Size = new System.Drawing.Size(365, 43);
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGuardar.Text = "Guardar cambios";
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
            // btnNuevo
            this.btnNuevo.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Location = new System.Drawing.Point(32, 620);
            this.btnNuevo.Size = new System.Drawing.Size(175, 44);
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNuevo.Text = "Nuevo registro";
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(209, 255, 50);
            this.btnNuevo.ForeColor = System.Drawing.Color.FromArgb(23, 25, 23);
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.Tag = "icon:agregar";
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // btnDesactivar
            this.btnDesactivar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Location = new System.Drawing.Point(223, 620);
            this.btnDesactivar.Size = new System.Drawing.Size(200, 44);
            this.btnDesactivar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDesactivar.Text = "Desactivar";
            this.btnDesactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesactivar.FlatAppearance.BorderSize = 0;
            this.btnDesactivar.BackColor = System.Drawing.Color.FromArgb(245, 243, 236);
            this.btnDesactivar.ForeColor = System.Drawing.Color.FromArgb(23, 25, 23);
            this.btnDesactivar.UseVisualStyleBackColor = false;
            this.btnDesactivar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesactivar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDesactivar.Tag = "icon:eliminar";
            this.btnDesactivar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDesactivar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // btnSalir
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Location = new System.Drawing.Point(545, 620);
            this.btnSalir.Size = new System.Drawing.Size(175, 44);
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
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            this.btnDesactivar.Click += new System.EventHandler(this.btnDesactivar_Click);
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            this.dgvProveedores.SelectionChanged += new System.EventHandler(this.dgvProveedores_SelectionChanged);
            this.Controls.Add(this.picModulo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lineaCabecera);
            this.Controls.Add(this.lbl_txtBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvProveedores);
            this.Controls.Add(this.pnlEditor);
            this.pnlEditor.Controls.Add(this.lblEditor);
            this.pnlEditor.Controls.Add(this.lbl_txtNombre);
            this.pnlEditor.Controls.Add(this.txtNombre);
            this.pnlEditor.Controls.Add(this.lbl_txtContacto);
            this.pnlEditor.Controls.Add(this.txtContacto);
            this.pnlEditor.Controls.Add(this.lbl_txtTelefono);
            this.pnlEditor.Controls.Add(this.txtTelefono);
            this.pnlEditor.Controls.Add(this.lbl_txtEmail);
            this.pnlEditor.Controls.Add(this.txtEmail);
            this.pnlEditor.Controls.Add(this.chkActivo);
            this.pnlEditor.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnDesactivar);
            this.Controls.Add(this.btnSalir);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(245, 243, 236);
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.MinimumSize = new System.Drawing.Size(1216, 759);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "frmProveedores";
            this.Text = "RAYAO* | Proveedores";
            this.DoubleBuffered = true;
            ((System.ComponentModel.ISupportInitialize)(this.picModulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal System.Windows.Forms.PictureBox picModulo;
        internal System.Windows.Forms.Label lblTitulo;
        internal System.Windows.Forms.Label lblSubtitulo;
        internal System.Windows.Forms.Label lblMarca;
        internal System.Windows.Forms.Panel lineaCabecera;
        internal System.Windows.Forms.Label lbl_txtBuscar;
        internal System.Windows.Forms.TextBox txtBuscar;
        internal System.Windows.Forms.Button btnBuscar;
        internal System.Windows.Forms.DataGridView dgvProveedores;
        internal System.Windows.Forms.Panel pnlEditor;
        internal System.Windows.Forms.Label lblEditor;
        internal System.Windows.Forms.Label lbl_txtNombre;
        internal System.Windows.Forms.TextBox txtNombre;
        internal System.Windows.Forms.Label lbl_txtContacto;
        internal System.Windows.Forms.TextBox txtContacto;
        internal System.Windows.Forms.Label lbl_txtTelefono;
        internal System.Windows.Forms.TextBox txtTelefono;
        internal System.Windows.Forms.Label lbl_txtEmail;
        internal System.Windows.Forms.TextBox txtEmail;
        internal System.Windows.Forms.CheckBox chkActivo;
        internal System.Windows.Forms.Button btnGuardar;
        internal System.Windows.Forms.Button btnNuevo;
        internal System.Windows.Forms.Button btnDesactivar;
        internal System.Windows.Forms.Button btnSalir;
    }
}