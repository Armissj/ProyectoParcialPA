namespace ProyectoParcialPA.Formularios
{
    partial class frmLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlFrase = new System.Windows.Forms.Panel();
            this.lblSlogan = new System.Windows.Forms.Label();
            this.lblUniverso = new System.Windows.Forms.Label();
            this.lblPie = new System.Windows.Forms.Label();
            this.pnlAcceso = new System.Windows.Forms.Panel();
            this.lblAcceso = new System.Windows.Forms.Label();
            this.lblAyuda = new System.Windows.Forms.Label();
            this.lbl_txtUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lbl_txtPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlFrase.SuspendLayout();
            this.pnlAcceso.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.picLogo.Location = new System.Drawing.Point(59, 53);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(205, 185);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            this.picLogo.Tag = "asset:marca/logo_rayao.png";
            this.picLogo.Click += new System.EventHandler(this.picLogo_Click);
            // 
            // pnlFrase
            // 
            this.pnlFrase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlFrase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(236)))));
            this.pnlFrase.Controls.Add(this.lblSlogan);
            this.pnlFrase.Controls.Add(this.lblUniverso);
            this.pnlFrase.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.pnlFrase.Location = new System.Drawing.Point(32, 493);
            this.pnlFrase.Name = "pnlFrase";
            this.pnlFrase.Size = new System.Drawing.Size(620, 113);
            this.pnlFrase.TabIndex = 1;
            // 
            // lblSlogan
            // 
            this.lblSlogan.BackColor = System.Drawing.Color.Transparent;
            this.lblSlogan.Font = new System.Drawing.Font("Segoe UI", 27F, System.Drawing.FontStyle.Bold);
            this.lblSlogan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(25)))), ((int)(((byte)(23)))));
            this.lblSlogan.Location = new System.Drawing.Point(20, 12);
            this.lblSlogan.Name = "lblSlogan";
            this.lblSlogan.Size = new System.Drawing.Size(580, 49);
            this.lblSlogan.TabIndex = 0;
            this.lblSlogan.Text = "El ruido empieza aquí.";
            // 
            // lblUniverso
            // 
            this.lblUniverso.BackColor = System.Drawing.Color.Transparent;
            this.lblUniverso.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblUniverso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(25)))), ((int)(((byte)(23)))));
            this.lblUniverso.Location = new System.Drawing.Point(22, 68);
            this.lblUniverso.Name = "lblUniverso";
            this.lblUniverso.Size = new System.Drawing.Size(570, 30);
            this.lblUniverso.TabIndex = 1;
            this.lblUniverso.Text = "PC  /  GAMING  /  MÚSICA";
            // 
            // lblPie
            // 
            this.lblPie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(236)))));
            this.lblPie.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblPie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(103)))), ((int)(((byte)(95)))));
            this.lblPie.Location = new System.Drawing.Point(32, 648);
            this.lblPie.Name = "lblPie";
            this.lblPie.Size = new System.Drawing.Size(620, 33);
            this.lblPie.TabIndex = 2;
            this.lblPie.Text = "Todo lo que te mueve, en un solo lugar.";
            // 
            // pnlAcceso
            // 
            this.pnlAcceso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAcceso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlAcceso.Controls.Add(this.lblAcceso);
            this.pnlAcceso.Controls.Add(this.lblAyuda);
            this.pnlAcceso.Controls.Add(this.lbl_txtUsuario);
            this.pnlAcceso.Controls.Add(this.txtUsuario);
            this.pnlAcceso.Controls.Add(this.lbl_txtPassword);
            this.pnlAcceso.Controls.Add(this.txtPassword);
            this.pnlAcceso.Controls.Add(this.btnEntrar);
            this.pnlAcceso.Controls.Add(this.btnSalir);
            this.pnlAcceso.Controls.Add(this.lblEstado);
            this.pnlAcceso.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.pnlAcceso.Location = new System.Drawing.Point(685, 115);
            this.pnlAcceso.Name = "pnlAcceso";
            this.pnlAcceso.Size = new System.Drawing.Size(435, 510);
            this.pnlAcceso.TabIndex = 3;
            // 
            // lblAcceso
            // 
            this.lblAcceso.BackColor = System.Drawing.Color.Transparent;
            this.lblAcceso.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            this.lblAcceso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(25)))), ((int)(((byte)(23)))));
            this.lblAcceso.Location = new System.Drawing.Point(35, 30);
            this.lblAcceso.Name = "lblAcceso";
            this.lblAcceso.Size = new System.Drawing.Size(360, 34);
            this.lblAcceso.TabIndex = 0;
            this.lblAcceso.Text = "BIENVENIDO A RAYAO*";
            // 
            // lblAyuda
            // 
            this.lblAyuda.BackColor = System.Drawing.Color.Transparent;
            this.lblAyuda.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblAyuda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(103)))), ((int)(((byte)(95)))));
            this.lblAyuda.Location = new System.Drawing.Point(35, 78);
            this.lblAyuda.Name = "lblAyuda";
            this.lblAyuda.Size = new System.Drawing.Size(360, 45);
            this.lblAyuda.TabIndex = 1;
            this.lblAyuda.Text = "Entra con tu cuenta para abrir la tienda.";
            // 
            // lbl_txtUsuario
            // 
            this.lbl_txtUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lbl_txtUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_txtUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(103)))), ((int)(((byte)(95)))));
            this.lbl_txtUsuario.Location = new System.Drawing.Point(35, 145);
            this.lbl_txtUsuario.Name = "lbl_txtUsuario";
            this.lbl_txtUsuario.Size = new System.Drawing.Size(365, 23);
            this.lbl_txtUsuario.TabIndex = 2;
            this.lbl_txtUsuario.Text = "USUARIO";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsuario.Location = new System.Drawing.Point(35, 170);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(365, 25);
            this.txtUsuario.TabIndex = 3;
            // 
            // lbl_txtPassword
            // 
            this.lbl_txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.lbl_txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(103)))), ((int)(((byte)(95)))));
            this.lbl_txtPassword.Location = new System.Drawing.Point(35, 225);
            this.lbl_txtPassword.Name = "lbl_txtPassword";
            this.lbl_txtPassword.Size = new System.Drawing.Size(365, 23);
            this.lbl_txtPassword.TabIndex = 4;
            this.lbl_txtPassword.Text = "CONTRASEÑA";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(35, 250);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(365, 25);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnEntrar
            // 
            this.btnEntrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(255)))), ((int)(((byte)(50)))));
            this.btnEntrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntrar.FlatAppearance.BorderSize = 0;
            this.btnEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEntrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(25)))), ((int)(((byte)(23)))));
            this.btnEntrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntrar.Location = new System.Drawing.Point(35, 325);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(365, 50);
            this.btnEntrar.TabIndex = 6;
            this.btnEntrar.Tag = "icon:entrar";
            this.btnEntrar.Text = "ENTRAR A LA TIENDA";
            this.btnEntrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEntrar.UseVisualStyleBackColor = false;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(236)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(25)))), ((int)(((byte)(23)))));
            this.btnSalir.Location = new System.Drawing.Point(35, 388);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(365, 40);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.BackColor = System.Drawing.Color.Transparent;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(103)))), ((int)(((byte)(95)))));
            this.lblEstado.Location = new System.Drawing.Point(35, 447);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(365, 42);
            this.lblEstado.TabIndex = 8;
            this.lblEstado.Text = "Administrador / Vendedor";
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnEntrar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(236)))));
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.pnlFrase);
            this.Controls.Add(this.lblPie);
            this.Controls.Add(this.pnlAcceso);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1216, 759);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RAYAO* | Iniciar sesión";
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlFrase.ResumeLayout(false);
            this.pnlAcceso.ResumeLayout(false);
            this.pnlAcceso.PerformLayout();
            this.ResumeLayout(false);

        }

        internal System.Windows.Forms.PictureBox picLogo;
        internal System.Windows.Forms.Panel pnlFrase;
        internal System.Windows.Forms.Label lblSlogan;
        internal System.Windows.Forms.Label lblUniverso;
        internal System.Windows.Forms.Label lblPie;
        internal System.Windows.Forms.Panel pnlAcceso;
        internal System.Windows.Forms.Label lblAcceso;
        internal System.Windows.Forms.Label lblAyuda;
        internal System.Windows.Forms.Label lbl_txtUsuario;
        internal System.Windows.Forms.TextBox txtUsuario;
        internal System.Windows.Forms.Label lbl_txtPassword;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.Button btnEntrar;
        internal System.Windows.Forms.Button btnSalir;
        internal System.Windows.Forms.Label lblEstado;
    }
}