using SistemaTallerServicioTecnico.Clases;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SistemaTallerServicioTecnico
{
    public partial class FormLogin : Form
    {
        // ════════════════════════════════════════════════════════════
        // ⚠️ VARIABLES ESTÁTICAS PARA GUARDAR ROL DEL USUARIO
        // ════════════════════════════════════════════════════════════
        public static string RolUsuario = "";
        public static string NombreUsuario = "";
        public static int UsuarioID = 0;

        // Para mover el formulario sin bordes
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        public FormLogin()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Probar conexión al cargar
            if (!ConexionBD.ProbarConexion())
            {
                MessageBox.Show("No se pudo conectar a la base de datos.\n" +
                    "Verifica tu cadena de conexión en ConexionBD.cs",
                    "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Configurar campos
            txtUsuario.Text = "admin";
            txtContraseña.UseSystemPasswordChar = true;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor ingrese usuario y contraseña",
                    "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar usuario
            string consulta = $"SELECT * FROM Usuarios WHERE NombreUsuario = '{usuario}' " +
                            $"AND Contraseña = '{contraseña}' AND Estado = 1";

            DataTable dt = ConexionBD.EjecutarConsulta(consulta);

            if (dt.Rows.Count > 0)
            {
                // ════════════════════════════════════════════════════════════
                // ⚠️ GUARDAR EL ROL DEL USUARIO EN VARIABLE ESTÁTICA
                // ════════════════════════════════════════════════════════════
                UsuarioID = Convert.ToInt32(dt.Rows[0]["UsuarioID"]);
                NombreUsuario = dt.Rows[0]["NombreCompleto"].ToString();
                RolUsuario = dt.Rows[0]["Rol"].ToString(); // ⬅️ AQUÍ SE GUARDA EL ROL

                MessageBox.Show($"¡Bienvenido {NombreUsuario}!\nRol: {RolUsuario}",
                    "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir formulario principal
                FormMenuPrincipal menuPrincipal = new FormMenuPrincipal();
                menuPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContraseña.Clear();
                txtUsuario.Focus();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void lblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void checkMostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = !checkMostrarContraseña.Checked;
        }
    }
}