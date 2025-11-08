namespace SistemaTallerServicioTecnico
{
    partial class FormMenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.lblFechaHora = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelLateral = new System.Windows.Forms.Panel();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnFacturas = new System.Windows.Forms.Button();
            this.btnRepuestos = new System.Windows.Forms.Button();
            this.btnCitas = new System.Windows.Forms.Button();
            this.btnServicios = new System.Windows.Forms.Button();
            this.btnEquipos = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.panelCentral = new System.Windows.Forms.Panel();
            this.dgvServicios = new System.Windows.Forms.DataGridView();
            this.panelServiciosHeader = new System.Windows.Forms.Panel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblServiciosHoy = new System.Windows.Forms.Label();
            this.panelEstadisticas = new System.Windows.Forms.Panel();
            this.cardCitas = new System.Windows.Forms.Panel();
            this.lblNumeroCitas = new System.Windows.Forms.Label();
            this.lblCitasPendientes = new System.Windows.Forms.Label();
            this.lblIconoCitas = new System.Windows.Forms.Label();
            this.cardServicios = new System.Windows.Forms.Panel();
            this.lblNumeroServicios = new System.Windows.Forms.Label();
            this.lblServiciosActivos = new System.Windows.Forms.Label();
            this.lblIconoServicios = new System.Windows.Forms.Label();
            this.cardEquipos = new System.Windows.Forms.Panel();
            this.lblNumeroEquipos = new System.Windows.Forms.Label();
            this.lblTotalEquipos = new System.Windows.Forms.Label();
            this.lblIconoEquipos = new System.Windows.Forms.Label();
            this.cardClientes = new System.Windows.Forms.Panel();
            this.lblNumeroClientes = new System.Windows.Forms.Label();
            this.lblTotalClientes = new System.Windows.Forms.Label();
            this.lblIconoClientes = new System.Windows.Forms.Label();
            this.timerHora = new System.Windows.Forms.Timer(this.components);
            this.panelSuperior.SuspendLayout();
            this.panelLateral.SuspendLayout();
            this.panelCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
            this.panelServiciosHeader.SuspendLayout();
            this.panelEstadisticas.SuspendLayout();
            this.cardCitas.SuspendLayout();
            this.cardServicios.SuspendLayout();
            this.cardEquipos.SuspendLayout();
            this.cardClientes.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.panelSuperior.Controls.Add(this.lblFechaHora);
            this.panelSuperior.Controls.Add(this.btnMinimizar);
            this.panelSuperior.Controls.Add(this.btnCerrar);
            this.panelSuperior.Controls.Add(this.lblTitulo);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1386, 70);
            this.panelSuperior.TabIndex = 0;
            this.panelSuperior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseDown);
            // 
            // lblFechaHora
            // 
            this.lblFechaHora.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFechaHora.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHora.ForeColor = System.Drawing.Color.White;
            this.lblFechaHora.Location = new System.Drawing.Point(493, 22);
            this.lblFechaHora.Name = "lblFechaHora";
            this.lblFechaHora.Size = new System.Drawing.Size(400, 25);
            this.lblFechaHora.TabIndex = 3;
            this.lblFechaHora.Text = "Fecha y Hora";
            this.lblFechaHora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Location = new System.Drawing.Point(1276, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(55, 70);
            this.btnMinimizar.TabIndex = 2;
            this.btnMinimizar.Text = "─";
            this.btnMinimizar.UseVisualStyleBackColor = true;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(57)))), ((int)(((byte)(70)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1331, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(55, 70);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "✕";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(435, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "🔧 SISTEMA DE TALLER DE SERVICIO";
            // 
            // panelLateral
            // 
            this.panelLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(120)))));
            this.panelLateral.Controls.Add(this.btnCerrarSesion);
            this.panelLateral.Controls.Add(this.btnFacturas);
            this.panelLateral.Controls.Add(this.btnRepuestos);
            this.panelLateral.Controls.Add(this.btnCitas);
            this.panelLateral.Controls.Add(this.btnServicios);
            this.panelLateral.Controls.Add(this.btnEquipos);
            this.panelLateral.Controls.Add(this.btnClientes);
            this.panelLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLateral.Location = new System.Drawing.Point(0, 70);
            this.panelLateral.Name = "panelLateral";
            this.panelLateral.Size = new System.Drawing.Size(280, 718);
            this.panelLateral.TabIndex = 1;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSesion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(57)))), ((int)(((byte)(70)))));
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(0, 653);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnCerrarSesion.Size = new System.Drawing.Size(280, 65);
            this.btnCerrarSesion.TabIndex = 6;
            this.btnCerrarSesion.Text = "🚪  Cerrar Sesión";
            this.btnCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnFacturas
            // 
            this.btnFacturas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFacturas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFacturas.FlatAppearance.BorderSize = 0;
            this.btnFacturas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnFacturas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFacturas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturas.ForeColor = System.Drawing.Color.White;
            this.btnFacturas.Location = new System.Drawing.Point(0, 325);
            this.btnFacturas.Name = "btnFacturas";
            this.btnFacturas.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnFacturas.Size = new System.Drawing.Size(280, 65);
            this.btnFacturas.TabIndex = 5;
            this.btnFacturas.Text = "📄  Facturación";
            this.btnFacturas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFacturas.UseVisualStyleBackColor = true;
            this.btnFacturas.Click += new System.EventHandler(this.btnFacturas_Click);
            // 
            // btnRepuestos
            // 
            this.btnRepuestos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRepuestos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRepuestos.FlatAppearance.BorderSize = 0;
            this.btnRepuestos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnRepuestos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRepuestos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRepuestos.ForeColor = System.Drawing.Color.White;
            this.btnRepuestos.Location = new System.Drawing.Point(0, 260);
            this.btnRepuestos.Name = "btnRepuestos";
            this.btnRepuestos.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnRepuestos.Size = new System.Drawing.Size(280, 65);
            this.btnRepuestos.TabIndex = 4;
            this.btnRepuestos.Text = "🔧  Inventario Repuestos";
            this.btnRepuestos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRepuestos.UseVisualStyleBackColor = true;
            this.btnRepuestos.Click += new System.EventHandler(this.btnRepuestos_Click);
            // 
            // btnCitas
            // 
            this.btnCitas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCitas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCitas.FlatAppearance.BorderSize = 0;
            this.btnCitas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnCitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCitas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCitas.ForeColor = System.Drawing.Color.White;
            this.btnCitas.Location = new System.Drawing.Point(0, 195);
            this.btnCitas.Name = "btnCitas";
            this.btnCitas.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnCitas.Size = new System.Drawing.Size(280, 65);
            this.btnCitas.TabIndex = 3;
            this.btnCitas.Text = "📅  Gestión de Citas";
            this.btnCitas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCitas.UseVisualStyleBackColor = true;
            this.btnCitas.Click += new System.EventHandler(this.btnCitas_Click);
            // 
            // btnServicios
            // 
            this.btnServicios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServicios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnServicios.FlatAppearance.BorderSize = 0;
            this.btnServicios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnServicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServicios.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServicios.ForeColor = System.Drawing.Color.White;
            this.btnServicios.Location = new System.Drawing.Point(0, 130);
            this.btnServicios.Name = "btnServicios";
            this.btnServicios.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnServicios.Size = new System.Drawing.Size(280, 65);
            this.btnServicios.TabIndex = 2;
            this.btnServicios.Text = "⚙️  Control de Servicios";
            this.btnServicios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnServicios.UseVisualStyleBackColor = true;
            this.btnServicios.Click += new System.EventHandler(this.btnServicios_Click);
            // 
            // btnEquipos
            // 
            this.btnEquipos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEquipos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEquipos.FlatAppearance.BorderSize = 0;
            this.btnEquipos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnEquipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEquipos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEquipos.ForeColor = System.Drawing.Color.White;
            this.btnEquipos.Location = new System.Drawing.Point(0, 65);
            this.btnEquipos.Name = "btnEquipos";
            this.btnEquipos.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnEquipos.Size = new System.Drawing.Size(280, 65);
            this.btnEquipos.TabIndex = 1;
            this.btnEquipos.Text = "💻  Registro de Equipos";
            this.btnEquipos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEquipos.UseVisualStyleBackColor = true;
            this.btnEquipos.Click += new System.EventHandler(this.btnEquipos_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.Location = new System.Drawing.Point(0, 0);
            this.btnClientes.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnClientes.Size = new System.Drawing.Size(280, 65);
            this.btnClientes.TabIndex = 0;
            this.btnClientes.Text = "👥  Registro de Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // panelCentral
            // 
            this.panelCentral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.panelCentral.Controls.Add(this.dgvServicios);
            this.panelCentral.Controls.Add(this.panelServiciosHeader);
            this.panelCentral.Controls.Add(this.panelEstadisticas);
            this.panelCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCentral.Location = new System.Drawing.Point(280, 70);
            this.panelCentral.Name = "panelCentral";
            this.panelCentral.Padding = new System.Windows.Forms.Padding(30, 25, 30, 25);
            this.panelCentral.Size = new System.Drawing.Size(1106, 718);
            this.panelCentral.TabIndex = 2;
            // 
            // dgvServicios
            // 
            this.dgvServicios.AllowUserToAddRows = false;
            this.dgvServicios.AllowUserToDeleteRows = false;
            this.dgvServicios.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvServicios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServicios.BackgroundColor = System.Drawing.Color.White;
            this.dgvServicios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvServicios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvServicios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvServicios.ColumnHeadersHeight = 45;
            this.dgvServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServicios.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvServicios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServicios.EnableHeadersVisualStyles = false;
            this.dgvServicios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvServicios.Location = new System.Drawing.Point(30, 300);
            this.dgvServicios.MultiSelect = false;
            this.dgvServicios.Name = "dgvServicios";
            this.dgvServicios.ReadOnly = true;
            this.dgvServicios.RowHeadersVisible = false;
            this.dgvServicios.RowTemplate.Height = 35;
            this.dgvServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServicios.Size = new System.Drawing.Size(1046, 393);
            this.dgvServicios.TabIndex = 3;
            // 
            // panelServiciosHeader
            // 
            this.panelServiciosHeader.BackColor = System.Drawing.Color.White;
            this.panelServiciosHeader.Controls.Add(this.btnActualizar);
            this.panelServiciosHeader.Controls.Add(this.lblServiciosHoy);
            this.panelServiciosHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelServiciosHeader.Location = new System.Drawing.Point(30, 225);
            this.panelServiciosHeader.Name = "panelServiciosHeader";
            this.panelServiciosHeader.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelServiciosHeader.Size = new System.Drawing.Size(1046, 75);
            this.panelServiciosHeader.TabIndex = 2;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(886, 15);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(140, 45);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "🔄 Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblServiciosHoy
            // 
            this.lblServiciosHoy.AutoSize = true;
            this.lblServiciosHoy.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiciosHoy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.lblServiciosHoy.Location = new System.Drawing.Point(20, 20);
            this.lblServiciosHoy.Name = "lblServiciosHoy";
            this.lblServiciosHoy.Size = new System.Drawing.Size(261, 30);
            this.lblServiciosHoy.TabIndex = 0;
            this.lblServiciosHoy.Text = "📋 Servicios en Proceso";
            // 
            // panelEstadisticas
            // 
            this.panelEstadisticas.BackColor = System.Drawing.Color.Transparent;
            this.panelEstadisticas.Controls.Add(this.cardCitas);
            this.panelEstadisticas.Controls.Add(this.cardServicios);
            this.panelEstadisticas.Controls.Add(this.cardEquipos);
            this.panelEstadisticas.Controls.Add(this.cardClientes);
            this.panelEstadisticas.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEstadisticas.Location = new System.Drawing.Point(30, 25);
            this.panelEstadisticas.Name = "panelEstadisticas";
            this.panelEstadisticas.Size = new System.Drawing.Size(1046, 200);
            this.panelEstadisticas.TabIndex = 0;
            // 
            // cardCitas
            // 
            this.cardCitas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(138)))), ((int)(((byte)(101)))));
            this.cardCitas.Controls.Add(this.lblNumeroCitas);
            this.cardCitas.Controls.Add(this.lblCitasPendientes);
            this.cardCitas.Controls.Add(this.lblIconoCitas);
            this.cardCitas.Location = new System.Drawing.Point(810, 10);
            this.cardCitas.Name = "cardCitas";
            this.cardCitas.Size = new System.Drawing.Size(240, 180);
            this.cardCitas.TabIndex = 3;
            // 
            // lblNumeroCitas
            // 
            this.lblNumeroCitas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumeroCitas.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroCitas.ForeColor = System.Drawing.Color.White;
            this.lblNumeroCitas.Location = new System.Drawing.Point(0, 60);
            this.lblNumeroCitas.Name = "lblNumeroCitas";
            this.lblNumeroCitas.Size = new System.Drawing.Size(240, 85);
            this.lblNumeroCitas.TabIndex = 2;
            this.lblNumeroCitas.Text = "0";
            this.lblNumeroCitas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCitasPendientes
            // 
            this.lblCitasPendientes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCitasPendientes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCitasPendientes.ForeColor = System.Drawing.Color.White;
            this.lblCitasPendientes.Location = new System.Drawing.Point(0, 145);
            this.lblCitasPendientes.Name = "lblCitasPendientes";
            this.lblCitasPendientes.Size = new System.Drawing.Size(240, 35);
            this.lblCitasPendientes.TabIndex = 1;
            this.lblCitasPendientes.Text = "Citas Pendientes";
            this.lblCitasPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIconoCitas
            // 
            this.lblIconoCitas.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIconoCitas.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIconoCitas.ForeColor = System.Drawing.Color.White;
            this.lblIconoCitas.Location = new System.Drawing.Point(0, 0);
            this.lblIconoCitas.Name = "lblIconoCitas";
            this.lblIconoCitas.Size = new System.Drawing.Size(240, 60);
            this.lblIconoCitas.TabIndex = 0;
            this.lblIconoCitas.Text = "📅";
            this.lblIconoCitas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardServicios
            // 
            this.cardServicios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(212)))), ((int)(((byte)(250)))));
            this.cardServicios.Controls.Add(this.lblNumeroServicios);
            this.cardServicios.Controls.Add(this.lblServiciosActivos);
            this.cardServicios.Controls.Add(this.lblIconoServicios);
            this.cardServicios.Location = new System.Drawing.Point(545, 10);
            this.cardServicios.Name = "cardServicios";
            this.cardServicios.Size = new System.Drawing.Size(240, 180);
            this.cardServicios.TabIndex = 2;
            // 
            // lblNumeroServicios
            // 
            this.lblNumeroServicios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumeroServicios.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroServicios.ForeColor = System.Drawing.Color.White;
            this.lblNumeroServicios.Location = new System.Drawing.Point(0, 60);
            this.lblNumeroServicios.Name = "lblNumeroServicios";
            this.lblNumeroServicios.Size = new System.Drawing.Size(240, 85);
            this.lblNumeroServicios.TabIndex = 2;
            this.lblNumeroServicios.Text = "0";
            this.lblNumeroServicios.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblServiciosActivos
            // 
            this.lblServiciosActivos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblServiciosActivos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiciosActivos.ForeColor = System.Drawing.Color.White;
            this.lblServiciosActivos.Location = new System.Drawing.Point(0, 145);
            this.lblServiciosActivos.Name = "lblServiciosActivos";
            this.lblServiciosActivos.Size = new System.Drawing.Size(240, 35);
            this.lblServiciosActivos.TabIndex = 1;
            this.lblServiciosActivos.Text = "Servicios Activos";
            this.lblServiciosActivos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIconoServicios
            // 
            this.lblIconoServicios.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIconoServicios.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIconoServicios.ForeColor = System.Drawing.Color.White;
            this.lblIconoServicios.Location = new System.Drawing.Point(0, 0);
            this.lblIconoServicios.Name = "lblIconoServicios";
            this.lblIconoServicios.Size = new System.Drawing.Size(240, 60);
            this.lblIconoServicios.TabIndex = 0;
            this.lblIconoServicios.Text = "⚙️";
            this.lblIconoServicios.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardEquipos
            // 
            this.cardEquipos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(204)))), ((int)(((byte)(101)))));
            this.cardEquipos.Controls.Add(this.lblNumeroEquipos);
            this.cardEquipos.Controls.Add(this.lblTotalEquipos);
            this.cardEquipos.Controls.Add(this.lblIconoEquipos);
            this.cardEquipos.Location = new System.Drawing.Point(280, 10);
            this.cardEquipos.Name = "cardEquipos";
            this.cardEquipos.Size = new System.Drawing.Size(240, 180);
            this.cardEquipos.TabIndex = 1;
            // 
            // lblNumeroEquipos
            // 
            this.lblNumeroEquipos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumeroEquipos.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroEquipos.ForeColor = System.Drawing.Color.White;
            this.lblNumeroEquipos.Location = new System.Drawing.Point(0, 60);
            this.lblNumeroEquipos.Name = "lblNumeroEquipos";
            this.lblNumeroEquipos.Size = new System.Drawing.Size(240, 85);
            this.lblNumeroEquipos.TabIndex = 2;
            this.lblNumeroEquipos.Text = "0";
            this.lblNumeroEquipos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalEquipos
            // 
            this.lblTotalEquipos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTotalEquipos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalEquipos.ForeColor = System.Drawing.Color.White;
            this.lblTotalEquipos.Location = new System.Drawing.Point(0, 145);
            this.lblTotalEquipos.Name = "lblTotalEquipos";
            this.lblTotalEquipos.Size = new System.Drawing.Size(240, 35);
            this.lblTotalEquipos.TabIndex = 1;
            this.lblTotalEquipos.Text = "Total Equipos";
            this.lblTotalEquipos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIconoEquipos
            // 
            this.lblIconoEquipos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIconoEquipos.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIconoEquipos.ForeColor = System.Drawing.Color.White;
            this.lblIconoEquipos.Location = new System.Drawing.Point(0, 0);
            this.lblIconoEquipos.Name = "lblIconoEquipos";
            this.lblIconoEquipos.Size = new System.Drawing.Size(240, 60);
            this.lblIconoEquipos.TabIndex = 0;
            this.lblIconoEquipos.Text = "💻";
            this.lblIconoEquipos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardClientes
            // 
            this.cardClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(134)))), ((int)(((byte)(203)))));
            this.cardClientes.Controls.Add(this.lblNumeroClientes);
            this.cardClientes.Controls.Add(this.lblTotalClientes);
            this.cardClientes.Controls.Add(this.lblIconoClientes);
            this.cardClientes.Location = new System.Drawing.Point(10, 10);
            this.cardClientes.Name = "cardClientes";
            this.cardClientes.Size = new System.Drawing.Size(240, 180);
            this.cardClientes.TabIndex = 0;
            // 
            // lblNumeroClientes
            // 
            this.lblNumeroClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumeroClientes.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroClientes.ForeColor = System.Drawing.Color.White;
            this.lblNumeroClientes.Location = new System.Drawing.Point(0, 60);
            this.lblNumeroClientes.Name = "lblNumeroClientes";
            this.lblNumeroClientes.Size = new System.Drawing.Size(240, 85);
            this.lblNumeroClientes.TabIndex = 2;
            this.lblNumeroClientes.Text = "0";
            this.lblNumeroClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalClientes
            // 
            this.lblTotalClientes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTotalClientes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalClientes.ForeColor = System.Drawing.Color.White;
            this.lblTotalClientes.Location = new System.Drawing.Point(0, 145);
            this.lblTotalClientes.Name = "lblTotalClientes";
            this.lblTotalClientes.Size = new System.Drawing.Size(240, 35);
            this.lblTotalClientes.TabIndex = 1;
            this.lblTotalClientes.Text = "Total Clientes";
            this.lblTotalClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIconoClientes
            // 
            this.lblIconoClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIconoClientes.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIconoClientes.ForeColor = System.Drawing.Color.White;
            this.lblIconoClientes.Location = new System.Drawing.Point(0, 0);
            this.lblIconoClientes.Name = "lblIconoClientes";
            this.lblIconoClientes.Size = new System.Drawing.Size(240, 60);
            this.lblIconoClientes.TabIndex = 0;
            this.lblIconoClientes.Text = "👥";
            this.lblIconoClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerHora
            // 
            this.timerHora.Interval = 1000;
            this.timerHora.Tick += new System.EventHandler(this.timerHora_Tick);
            // 
            // FormMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.panelCentral);
            this.Controls.Add(this.panelLateral);
            this.Controls.Add(this.panelSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "FormMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Taller - Menú Principal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMenuPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.FormMenuPrincipal_Load);
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.panelLateral.ResumeLayout(false);
            this.panelCentral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
            this.panelServiciosHeader.ResumeLayout(false);
            this.panelServiciosHeader.PerformLayout();
            this.panelEstadisticas.ResumeLayout(false);
            this.cardCitas.ResumeLayout(false);
            this.cardServicios.ResumeLayout(false);
            this.cardEquipos.ResumeLayout(false);
            this.cardClientes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Label lblFechaHora;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelLateral;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnFacturas;
        private System.Windows.Forms.Button btnRepuestos;
        private System.Windows.Forms.Button btnCitas;
        private System.Windows.Forms.Button btnServicios;
        private System.Windows.Forms.Button btnEquipos;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Panel panelCentral;
        private System.Windows.Forms.DataGridView dgvServicios;
        private System.Windows.Forms.Panel panelServiciosHeader;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblServiciosHoy;
        private System.Windows.Forms.Panel panelEstadisticas;
        private System.Windows.Forms.Panel cardCitas;
        private System.Windows.Forms.Label lblNumeroCitas;
        private System.Windows.Forms.Label lblCitasPendientes;
        private System.Windows.Forms.Label lblIconoCitas;
        private System.Windows.Forms.Panel cardServicios;
        private System.Windows.Forms.Label lblNumeroServicios;
        private System.Windows.Forms.Label lblServiciosActivos;
        private System.Windows.Forms.Label lblIconoServicios;
        private System.Windows.Forms.Panel cardEquipos;
        private System.Windows.Forms.Label lblNumeroEquipos;
        private System.Windows.Forms.Label lblTotalEquipos;
        private System.Windows.Forms.Label lblIconoEquipos;
        private System.Windows.Forms.Panel cardClientes;
        private System.Windows.Forms.Label lblNumeroClientes;
        private System.Windows.Forms.Label lblTotalClientes;
        private System.Windows.Forms.Label lblIconoClientes;
        private System.Windows.Forms.Timer timerHora;
    }
}