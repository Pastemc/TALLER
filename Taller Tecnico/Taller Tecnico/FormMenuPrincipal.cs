using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SistemaTallerServicioTecnico
{
    public partial class FormMenuPrincipal : Form
    {
        // Para mover el formulario sin bordes
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        public FormMenuPrincipal()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            // ════════════════════════════════════════════════════════════
            // ⚠️ CONFIGURAR ACCESOS SEGÚN EL ROL DEL USUARIO
            // ════════════════════════════════════════════════════════════
            ConfigurarAccesosPorRol();

            // Cargar estadísticas al inicio
            CargarEstadisticas();
            CargarServiciosActivos();

            // Configurar el timer para actualizar la hora
            timerHora.Start();
            ActualizarHora();
        }

        // ════════════════════════════════════════════════════════════
        // 🔐 MÉTODO QUE CONTROLA ACCESO DEL TÉCNICO (SOLO 4 MÓDULOS)
        // ════════════════════════════════════════════════════════════
        private void ConfigurarAccesosPorRol()
        {
            if (FormLogin.RolUsuario == "Técnico")
            {
                // ❌ OCULTAR módulos NO permitidos para técnico
                btnClientes.Visible = false;
                btnFacturas.Visible = false;
                cardClientes.Visible = false;

                // ✅ MOSTRAR solo los 4 módulos permitidos
                btnEquipos.Visible = true;      // 1. Registro de Equipos
                btnServicios.Visible = true;    // 2. Control de Servicios
                btnCitas.Visible = true;        // 3. Gestión de Citas
                btnRepuestos.Visible = true;    // 4. Inventario Repuestos

                // 🎯 CENTRAR LAS 3 TARJETAS DEL TÉCNICO
                CentrarTarjetas();
            }
            else if (FormLogin.RolUsuario == "Administrador")
            {
                // ✅ ADMINISTRADOR ve TODOS los módulos
                btnClientes.Visible = true;
                btnEquipos.Visible = true;
                btnServicios.Visible = true;
                btnCitas.Visible = true;
                btnRepuestos.Visible = true;
                btnFacturas.Visible = true;
                cardClientes.Visible = true;
            }
        }

        // ════════════════════════════════════════════════════════════
        // 🎯 MÉTODO PARA CENTRAR LAS 3 TARJETAS DEL TÉCNICO
        // ════════════════════════════════════════════════════════════
        private void CentrarTarjetas()
        {
            // Ancho del panel: 1046px
            // Cada tarjeta: 240px
            // Espaciado entre tarjetas: 25px
            // Total: (240 * 3) + (25 * 2) = 720 + 50 = 770px
            // Centrado: (1046 - 770) / 2 = 138px de margen izquierdo

            int anchoPanel = panelEstadisticas.Width;
            int anchoTarjeta = 240;
            int espaciado = 25;
            int numTarjetas = 3;

            int anchoTotal = (anchoTarjeta * numTarjetas) + (espaciado * (numTarjetas - 1));
            int margenIzquierdo = (anchoPanel - anchoTotal) / 2;

            // Reposicionar las 3 tarjetas visibles
            cardEquipos.Location = new Point(margenIzquierdo, 10);
            cardServicios.Location = new Point(margenIzquierdo + anchoTarjeta + espaciado, 10);
            cardCitas.Location = new Point(margenIzquierdo + (anchoTarjeta + espaciado) * 2, 10);
        }

        private void CargarEstadisticas()
        {
            try
            {
                // Contar clientes activos
                string queryClientes = "SELECT COUNT(*) FROM Clientes WHERE Estado = 1";
                object resultClientes = ConexionBD.ObtenerValorEscalar(queryClientes);
                int totalClientes = resultClientes != null ? Convert.ToInt32(resultClientes) : 0;
                lblNumeroClientes.Text = totalClientes.ToString();
                lblTotalClientes.Text = "Total Clientes";

                // Contar equipos registrados
                string queryEquipos = "SELECT COUNT(*) FROM Equipos WHERE Estado = 1";
                object resultEquipos = ConexionBD.ObtenerValorEscalar(queryEquipos);
                int totalEquipos = resultEquipos != null ? Convert.ToInt32(resultEquipos) : 0;
                lblNumeroEquipos.Text = totalEquipos.ToString();
                lblTotalEquipos.Text = "Total Equipos";

                // Contar servicios en proceso
                string queryServicios = "SELECT COUNT(*) FROM Servicios WHERE EstadoServicio = 'En Proceso'";
                object resultServicios = ConexionBD.ObtenerValorEscalar(queryServicios);
                int serviciosActivos = resultServicios != null ? Convert.ToInt32(resultServicios) : 0;
                lblNumeroServicios.Text = serviciosActivos.ToString();
                lblServiciosActivos.Text = "Servicios Activos";

                // Contar citas pendientes
                string queryCitas = "SELECT COUNT(*) FROM Citas WHERE Estado = 'Pendiente' OR Estado = 'Confirmada'";
                object resultCitas = ConexionBD.ObtenerValorEscalar(queryCitas);
                int citasPendientes = resultCitas != null ? Convert.ToInt32(resultCitas) : 0;
                lblNumeroCitas.Text = citasPendientes.ToString();
                lblCitasPendientes.Text = "Citas Pendientes";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estadísticas: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarServiciosActivos()
        {
            try
            {
                string consulta = @"SELECT 
                    s.ServicioID AS 'ID',
                    c.NombreCompleto AS 'Cliente',
                    e.TipoEquipo AS 'Tipo',
                    e.Marca + ' ' + e.Modelo AS 'Equipo',
                    s.TipoServicio AS 'Servicio',
                    s.EstadoServicio AS 'Estado',
                    s.Prioridad,
                    CONVERT(VARCHAR(10), s.FechaIngreso, 103) AS 'Fecha Ingreso'
                FROM Servicios s
                INNER JOIN Clientes c ON s.ClienteID = c.ClienteID
                INNER JOIN Equipos e ON s.EquipoID = e.EquipoID
                WHERE s.EstadoServicio IN ('En Proceso', 'Pendiente')
                ORDER BY s.FechaIngreso DESC";

                DataTable dt = ConexionBD.EjecutarConsulta(consulta);
                dgvServicios.DataSource = dt;

                // Configurar el DataGridView
                if (dgvServicios.Columns.Count > 0)
                {
                    dgvServicios.Columns["ID"].Width = 50;
                    dgvServicios.Columns["Cliente"].Width = 150;
                    dgvServicios.Columns["Tipo"].Width = 100;
                    dgvServicios.Columns["Equipo"].Width = 150;
                    dgvServicios.Columns["Servicio"].Width = 120;
                    dgvServicios.Columns["Estado"].Width = 100;
                    dgvServicios.Columns["Prioridad"].Width = 80;

                    // Colorear según prioridad
                    foreach (DataGridViewRow row in dgvServicios.Rows)
                    {
                        if (row.Cells["Prioridad"].Value != null)
                        {
                            string prioridad = row.Cells["Prioridad"].Value.ToString();
                            if (prioridad == "Alta")
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 205, 210);
                            }
                            else if (prioridad == "Normal")
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 249, 196);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar servicios: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarHora()
        {
            lblFechaHora.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy HH:mm:ss");
        }

        // EVENTOS DE LOS BOTONES DEL MENÚ
        private void btnClientes_Click(object sender, EventArgs e)
        {
            // ════════════════════════════════════════════════════════════
            // ⚠️ VALIDACIÓN: Solo administrador puede acceder
            // ════════════════════════════════════════════════════════════
            if (FormLogin.RolUsuario != "Administrador")
            {
                MessageBox.Show("❌ No tienes permisos para acceder a este módulo",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FormClientes formClientes = new FormClientes();
            formClientes.ShowDialog();
            CargarEstadisticas();
        }

        private void btnEquipos_Click(object sender, EventArgs e)
        {
            // ✅ TÉCNICO PUEDE ACCEDER
            FormEquipos formEquipos = new FormEquipos();
            formEquipos.ShowDialog();
            CargarEstadisticas();
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            // ✅ TÉCNICO PUEDE ACCEDER
            FormServicios formServicios = new FormServicios();
            formServicios.ShowDialog();
            CargarEstadisticas();
            CargarServiciosActivos();
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            // ✅ TÉCNICO PUEDE ACCEDER
            FormCitas formCitas = new FormCitas();
            formCitas.ShowDialog();
            CargarEstadisticas();
        }

        private void btnRepuestos_Click(object sender, EventArgs e)
        {
            // ✅ TÉCNICO PUEDE ACCEDER
            FormRepuestos formRepuestos = new FormRepuestos();
            formRepuestos.ShowDialog();
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            // ════════════════════════════════════════════════════════════
            // ⚠️ VALIDACIÓN: Solo administrador puede acceder
            // ════════════════════════════════════════════════════════════
            if (FormLogin.RolUsuario != "Administrador")
            {
                MessageBox.Show("❌ No tienes permisos para acceder a este módulo",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FormFacturas formFacturas = new FormFacturas();
            formFacturas.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarEstadisticas();
            CargarServiciosActivos();
            MessageBox.Show("Datos actualizados correctamente", "Actualización",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea cerrar sesión?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Limpiar variables de sesión
                FormLogin.RolUsuario = "";
                FormLogin.NombreUsuario = "";
                FormLogin.UsuarioID = 0;

                FormLogin formLogin = new FormLogin();
                formLogin.Show();
                this.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea salir del sistema?",
                "Confirmar Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void timerHora_Tick(object sender, EventArgs e)
        {
            ActualizarHora();
        }

        private void FormMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}