namespace SistemaTallerServicioTecnico
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Panel panelCentral;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Panel panelUsuario;
        private System.Windows.Forms.Label lblUsuarioLabel;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Panel panelContraseña;
        private System.Windows.Forms.Label lblContraseñaLabel;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.CheckBox checkMostrarContraseña;
        private System.Windows.Forms.Button btnIngresar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelCentral = new System.Windows.Forms.Panel();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.checkMostrarContraseña = new System.Windows.Forms.CheckBox();
            this.panelContraseña = new System.Windows.Forms.Panel();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.lblContraseñaLabel = new System.Windows.Forms.Label();
            this.panelUsuario = new System.Windows.Forms.Panel();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuarioLabel = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panelSuperior.SuspendLayout();
            this.panelCentral.SuspendLayout();
            this.panelContraseña.SuspendLayout();
            this.panelUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.panelSuperior.Controls.Add(this.btnMinimizar);
            this.panelSuperior.Controls.Add(this.btnCerrar);
            this.panelSuperior.Controls.Add(this.lblTitulo);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(450, 50);
            this.panelSuperior.TabIndex = 0;
            this.panelSuperior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseDown);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Location = new System.Drawing.Point(360, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(45, 50);
            this.btnMinimizar.TabIndex = 5;
            this.btnMinimizar.Text = "-";
            this.btnMinimizar.UseVisualStyleBackColor = true;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(405, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(45, 50);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(278, 21);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "🔐 Sistema Taller Servicio Técnico";
            this.lblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitulo_MouseDown);
            // 
            // panelCentral
            // 
            this.panelCentral.BackColor = System.Drawing.Color.White;
            this.panelCentral.Controls.Add(this.btnIngresar);
            this.panelCentral.Controls.Add(this.checkMostrarContraseña);
            this.panelCentral.Controls.Add(this.panelContraseña);
            this.panelCentral.Controls.Add(this.panelUsuario);
            this.panelCentral.Controls.Add(this.lblBienvenida);
            this.panelCentral.Controls.Add(this.pictureBoxLogo);
            this.panelCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCentral.Location = new System.Drawing.Point(0, 50);
            this.panelCentral.Name = "panelCentral";
            this.panelCentral.Size = new System.Drawing.Size(450, 550);
            this.panelCentral.TabIndex = 1;
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Location = new System.Drawing.Point(75, 450);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(300, 50);
            this.btnIngresar.TabIndex = 4;
            this.btnIngresar.Text = "🚀 INGRESAR";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // checkMostrarContraseña
            // 
            this.checkMostrarContraseña.AutoSize = true;
            this.checkMostrarContraseña.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkMostrarContraseña.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkMostrarContraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkMostrarContraseña.Location = new System.Drawing.Point(75, 410);
            this.checkMostrarContraseña.Name = "checkMostrarContraseña";
            this.checkMostrarContraseña.Size = new System.Drawing.Size(130, 19);
            this.checkMostrarContraseña.TabIndex = 3;
            this.checkMostrarContraseña.Text = "Mostrar contraseña";
            this.checkMostrarContraseña.UseVisualStyleBackColor = true;
            this.checkMostrarContraseña.CheckedChanged += new System.EventHandler(this.checkMostrarContraseña_CheckedChanged);
            // 
            // panelContraseña
            // 
            this.panelContraseña.BackColor = System.Drawing.Color.White;
            this.panelContraseña.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContraseña.Controls.Add(this.txtContraseña);
            this.panelContraseña.Controls.Add(this.lblContraseñaLabel);
            this.panelContraseña.Location = new System.Drawing.Point(75, 345);
            this.panelContraseña.Name = "panelContraseña";
            this.panelContraseña.Size = new System.Drawing.Size(300, 50);
            this.panelContraseña.TabIndex = 2;
            // 
            // txtContraseña
            // 
            this.txtContraseña.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContraseña.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtContraseña.Location = new System.Drawing.Point(10, 22);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(280, 20);
            this.txtContraseña.TabIndex = 2;
            this.txtContraseña.UseSystemPasswordChar = true;
            // 
            // lblContraseñaLabel
            // 
            this.lblContraseñaLabel.AutoSize = true;
            this.lblContraseñaLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblContraseñaLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblContraseñaLabel.Location = new System.Drawing.Point(7, 5);
            this.lblContraseñaLabel.Name = "lblContraseñaLabel";
            this.lblContraseñaLabel.Size = new System.Drawing.Size(64, 13);
            this.lblContraseñaLabel.TabIndex = 0;
            this.lblContraseñaLabel.Text = "Contraseña";
            // 
            // panelUsuario
            // 
            this.panelUsuario.BackColor = System.Drawing.Color.White;
            this.panelUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUsuario.Controls.Add(this.txtUsuario);
            this.panelUsuario.Controls.Add(this.lblUsuarioLabel);
            this.panelUsuario.Location = new System.Drawing.Point(75, 275);
            this.panelUsuario.Name = "panelUsuario";
            this.panelUsuario.Size = new System.Drawing.Size(300, 50);
            this.panelUsuario.TabIndex = 1;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsuario.Location = new System.Drawing.Point(10, 22);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(280, 20);
            this.txtUsuario.TabIndex = 1;
            // 
            // lblUsuarioLabel
            // 
            this.lblUsuarioLabel.AutoSize = true;
            this.lblUsuarioLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblUsuarioLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblUsuarioLabel.Location = new System.Drawing.Point(7, 5);
            this.lblUsuarioLabel.Name = "lblUsuarioLabel";
            this.lblUsuarioLabel.Size = new System.Drawing.Size(46, 13);
            this.lblUsuarioLabel.TabIndex = 0;
            this.lblUsuarioLabel.Text = "Usuario";
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.lblBienvenida.Location = new System.Drawing.Point(75, 200);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(300, 60);
            this.lblBienvenida.TabIndex = 1;
            this.lblBienvenida.Text = "¡BIENVENIDO!\nInicia Sesión";
            this.lblBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.pictureBoxLogo.Location = new System.Drawing.Point(165, 40);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(120, 120);
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 600);
            this.Controls.Add(this.panelCentral);
            this.Controls.Add(this.panelSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login - Sistema Taller";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.panelCentral.ResumeLayout(false);
            this.panelCentral.PerformLayout();
            this.panelContraseña.ResumeLayout(false);
            this.panelContraseña.PerformLayout();
            this.panelUsuario.ResumeLayout(false);
            this.panelUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
        }
    }
}