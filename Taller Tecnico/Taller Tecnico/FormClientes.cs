using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaTallerServicioTecnico
{
    public partial class FormClientes : Form
    {
        private int clienteIdSeleccionado = 0;
        private bool esNuevo = true;

        public FormClientes()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
            LimpiarCampos();
        }

        private void CargarClientes()
        {
            try
            {
                string consulta = @"SELECT 
                    ClienteID AS 'ID',
                    NombreCompleto AS 'Nombre Completo',
                    DNI,
                    Telefono AS 'Teléfono',
                    Email,
                    Direccion AS 'Dirección',
                    CONVERT(VARCHAR(10), FechaRegistro, 103) AS 'Fecha Registro',
                    CASE WHEN Estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS 'Estado'
                FROM Clientes
                ORDER BY ClienteID DESC";

                DataTable dt = ConexionBD.EjecutarConsulta(consulta);
                dgvClientes.DataSource = dt;

                // Configurar columnas con anchos adecuados
                if (dgvClientes.Columns.Count > 0)
                {
                    dgvClientes.Columns["ID"].Width = 60;
                    dgvClientes.Columns["Nombre Completo"].Width = 200;
                    dgvClientes.Columns["DNI"].Width = 100;
                    dgvClientes.Columns["Teléfono"].Width = 120;
                    dgvClientes.Columns["Email"].Width = 180;
                    dgvClientes.Columns["Dirección"].Width = 200;
                    dgvClientes.Columns["Fecha Registro"].Width = 120;
                    dgvClientes.Columns["Estado"].Width = 90;

                    // Colorear según estado
                    foreach (DataGridViewRow row in dgvClientes.Rows)
                    {
                        if (row.Cells["Estado"].Value != null)
                        {
                            string estado = row.Cells["Estado"].Value.ToString();
                            if (estado == "Activo")
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(200, 230, 201);
                            }
                            else
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 205, 210);
                            }
                        }
                    }
                }

                lblTotal.Text = $"Total de clientes: {dt.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDNI.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            checkActivo.Checked = true;
            clienteIdSeleccionado = 0;
            esNuevo = true;
            btnGuardar.Text = "💾 Guardar Nuevo";
            txtNombre.Focus();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre completo del cliente", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                MessageBox.Show("Ingrese el DNI del cliente", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDNI.Focus();
                return false;
            }

            if (txtDNI.Text.Length != 8)
            {
                MessageBox.Show("El DNI debe tener 8 dígitos", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDNI.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Ingrese el teléfono del cliente", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                string nombre = txtNombre.Text.Trim().Replace("'", "''");
                string dni = txtDNI.Text.Trim();
                string telefono = txtTelefono.Text.Trim();
                string email = txtEmail.Text.Trim().Replace("'", "''");
                string direccion = txtDireccion.Text.Trim().Replace("'", "''");
                int estado = checkActivo.Checked ? 1 : 0;

                if (esNuevo)
                {
                    // Verificar si el DNI ya existe
                    string consultaVerificar = $"SELECT COUNT(*) FROM Clientes WHERE DNI = '{dni}'";
                    object resultado = ConexionBD.ObtenerValorEscalar(consultaVerificar);
                    int existe = resultado != null ? Convert.ToInt32(resultado) : 0;

                    if (existe > 0)
                    {
                        MessageBox.Show("Ya existe un cliente con ese DNI", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Insertar nuevo cliente
                    string consulta = $@"INSERT INTO Clientes 
                        (NombreCompleto, DNI, Telefono, Email, Direccion, Estado)
                        VALUES ('{nombre}', '{dni}', '{telefono}', '{email}', '{direccion}', {estado})";

                    if (ConexionBD.EjecutarComando(consulta))
                    {
                        MessageBox.Show("Cliente registrado exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarClientes();
                        LimpiarCampos();
                    }
                }
                else
                {
                    // Actualizar cliente existente
                    string consulta = $@"UPDATE Clientes SET 
                        NombreCompleto = '{nombre}',
                        DNI = '{dni}',
                        Telefono = '{telefono}',
                        Email = '{email}',
                        Direccion = '{direccion}',
                        Estado = {estado}
                        WHERE ClienteID = {clienteIdSeleccionado}";

                    if (ConexionBD.EjecutarComando(consulta))
                    {
                        MessageBox.Show("Cliente actualizado exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarClientes();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cliente: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                clienteIdSeleccionado = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["ID"].Value);

                string consulta = $"SELECT * FROM Clientes WHERE ClienteID = {clienteIdSeleccionado}";
                DataTable dt = ConexionBD.EjecutarConsulta(consulta);

                if (dt.Rows.Count > 0)
                {
                    txtNombre.Text = dt.Rows[0]["NombreCompleto"].ToString();
                    txtDNI.Text = dt.Rows[0]["DNI"].ToString();
                    txtTelefono.Text = dt.Rows[0]["Telefono"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtDireccion.Text = dt.Rows[0]["Direccion"].ToString();
                    checkActivo.Checked = Convert.ToBoolean(dt.Rows[0]["Estado"]);

                    esNuevo = false;
                    btnGuardar.Text = "💾 Actualizar";
                    txtNombre.Focus();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para editar", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "¿Está seguro de eliminar este cliente?\nEsta acción eliminará también sus equipos y servicios asociados.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int clienteId = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["ID"].Value);
                    string consulta = $"DELETE FROM Clientes WHERE ClienteID = {clienteId}";

                    if (ConexionBD.EjecutarComando(consulta))
                    {
                        MessageBox.Show("Cliente eliminado exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarClientes();
                        LimpiarCampos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para eliminar", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(busqueda))
            {
                CargarClientes();
                return;
            }

            try
            {
                string consulta = $@"SELECT 
                    ClienteID AS 'ID',
                    NombreCompleto AS 'Nombre Completo',
                    DNI,
                    Telefono AS 'Teléfono',
                    Email,
                    Direccion AS 'Dirección',
                    CONVERT(VARCHAR(10), FechaRegistro, 103) AS 'Fecha Registro',
                    CASE WHEN Estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS 'Estado'
                FROM Clientes
                WHERE NombreCompleto LIKE '%{busqueda}%' 
                   OR DNI LIKE '%{busqueda}%'
                   OR Telefono LIKE '%{busqueda}%'
                   OR Email LIKE '%{busqueda}%'
                ORDER BY ClienteID DESC";

                DataTable dt = ConexionBD.EjecutarConsulta(consulta);
                dgvClientes.DataSource = dt;
                lblTotal.Text = $"Resultados encontrados: {dt.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditar_Click(sender, e);
            }
        }

        // Solo permitir números en DNI y Teléfono
        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}