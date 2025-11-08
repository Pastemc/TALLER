using SistemaTallerServicioTecnico.Clases;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaTallerServicioTecnico
{
    public partial class FormEquipos : Form
    {
        private int equipoIdSeleccionado = 0;
        private bool esNuevo = true;

        public FormEquipos()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormEquipos_Load(object sender, EventArgs e)
        {
            CargarEquipos();
            CargarClientes();
            CargarTiposEquipo();
            LimpiarCampos();
        }

        private void CargarEquipos()
        {
            try
            {
                string consulta = @"SELECT 
                    e.EquipoID AS 'ID',
                    c.NombreCompleto AS 'Cliente',
                    e.TipoEquipo AS 'Tipo',
                    e.Marca,
                    e.Modelo,
                    e.NumeroSerie AS 'Nro. Serie',
                    e.Descripcion AS 'Descripción',
                    CONVERT(VARCHAR(10), e.FechaRegistro, 103) AS 'Fecha Registro',
                    CASE WHEN e.Estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS 'Estado'
                FROM Equipos e
                INNER JOIN Clientes c ON e.ClienteID = c.ClienteID
                ORDER BY e.EquipoID DESC";

                DataTable dt = ConexionBD.EjecutarConsulta(consulta);
                dgvEquipos.DataSource = dt;

                if (dgvEquipos.Columns.Count > 0)
                {
                    dgvEquipos.Columns["ID"].Width = 50;
                    dgvEquipos.Columns["Cliente"].Width = 150;
                    dgvEquipos.Columns["Tipo"].Width = 100;
                    dgvEquipos.Columns["Marca"].Width = 100;
                    dgvEquipos.Columns["Modelo"].Width = 100;
                }

                lblTotal.Text = $"Total de equipos: {dt.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar equipos: " + ex.Message);
            }
        }

        private void CargarClientes()
        {
            try
            {
                string consulta = "SELECT ClienteID, NombreCompleto FROM Clientes WHERE Estado = 1 ORDER BY NombreCompleto";
                DataTable dt = ConexionBD.EjecutarConsulta(consulta);

                cmbCliente.DataSource = dt;
                cmbCliente.DisplayMember = "NombreCompleto";
                cmbCliente.ValueMember = "ClienteID";
                cmbCliente.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        private void CargarTiposEquipo()
        {
            cmbTipoEquipo.Items.Clear();
            cmbTipoEquipo.Items.AddRange(new string[] {
                "Laptop",
                "PC Escritorio",
                "Impresora",
                "Scanner",
                "Monitor",
                "Tablet",
                "Smartphone",
                "Router",
                "UPS",
                "Otro"
            });
        }

        private void LimpiarCampos()
        {
            cmbCliente.SelectedIndex = -1;
            cmbTipoEquipo.SelectedIndex = -1;
            txtMarca.Clear();
            txtModelo.Clear();
            txtNumeroSerie.Clear();
            txtDescripcion.Clear();
            checkActivo.Checked = true;
            equipoIdSeleccionado = 0;
            esNuevo = true;
            btnGuardar.Text = "💾 Guardar Nuevo";
            cmbCliente.Focus();
        }

        private bool ValidarCampos()
        {
            if (cmbCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un cliente", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCliente.Focus();
                return false;
            }

            if (cmbTipoEquipo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de equipo", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipoEquipo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                MessageBox.Show("Ingrese la marca del equipo", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMarca.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                MessageBox.Show("Ingrese el modelo del equipo", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtModelo.Focus();
                return false;
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                int clienteId = Convert.ToInt32(cmbCliente.SelectedValue);
                string tipoEquipo = cmbTipoEquipo.Text;
                string marca = txtMarca.Text.Trim();
                string modelo = txtModelo.Text.Trim();
                string numeroSerie = txtNumeroSerie.Text.Trim();
                string descripcion = txtDescripcion.Text.Trim();
                int estado = checkActivo.Checked ? 1 : 0;

                if (esNuevo)
                {
                    string consulta = $@"INSERT INTO Equipos 
                        (ClienteID, TipoEquipo, Marca, Modelo, NumeroSerie, Descripcion, Estado)
                        VALUES ({clienteId}, '{tipoEquipo}', '{marca}', '{modelo}', '{numeroSerie}', '{descripcion}', {estado})";

                    if (ConexionBD.EjecutarComando(consulta))
                    {
                        MessageBox.Show("Equipo registrado exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarEquipos();
                        LimpiarCampos();
                    }
                }
                else
                {
                    string consulta = $@"UPDATE Equipos SET 
                        ClienteID = {clienteId},
                        TipoEquipo = '{tipoEquipo}',
                        Marca = '{marca}',
                        Modelo = '{modelo}',
                        NumeroSerie = '{numeroSerie}',
                        Descripcion = '{descripcion}',
                        Estado = {estado}
                        WHERE EquipoID = {equipoIdSeleccionado}";

                    if (ConexionBD.EjecutarComando(consulta))
                    {
                        MessageBox.Show("Equipo actualizado exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarEquipos();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar equipo: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEquipos.SelectedRows.Count > 0)
            {
                equipoIdSeleccionado = Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["ID"].Value);

                string consulta = $"SELECT * FROM Equipos WHERE EquipoID = {equipoIdSeleccionado}";
                DataTable dt = ConexionBD.EjecutarConsulta(consulta);

                if (dt.Rows.Count > 0)
                {
                    cmbCliente.SelectedValue = dt.Rows[0]["ClienteID"];
                    cmbTipoEquipo.Text = dt.Rows[0]["TipoEquipo"].ToString();
                    txtMarca.Text = dt.Rows[0]["Marca"].ToString();
                    txtModelo.Text = dt.Rows[0]["Modelo"].ToString();
                    txtNumeroSerie.Text = dt.Rows[0]["NumeroSerie"].ToString();
                    txtDescripcion.Text = dt.Rows[0]["Descripcion"].ToString();
                    checkActivo.Checked = Convert.ToBoolean(dt.Rows[0]["Estado"]);

                    esNuevo = false;
                    btnGuardar.Text = "💾 Actualizar";
                    cmbCliente.Focus();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un equipo para editar", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEquipos.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "¿Está seguro de eliminar este equipo?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int equipoId = Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["ID"].Value);
                    string consulta = $"DELETE FROM Equipos WHERE EquipoID = {equipoId}";

                    if (ConexionBD.EjecutarComando(consulta))
                    {
                        MessageBox.Show("Equipo eliminado exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarEquipos();
                        LimpiarCampos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un equipo para eliminar", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(busqueda))
            {
                CargarEquipos();
                return;
            }

            try
            {
                string consulta = $@"SELECT 
                    e.EquipoID AS 'ID',
                    c.NombreCompleto AS 'Cliente',
                    e.TipoEquipo AS 'Tipo',
                    e.Marca,
                    e.Modelo,
                    e.NumeroSerie AS 'Nro. Serie',
                    e.Descripcion AS 'Descripción',
                    CONVERT(VARCHAR(10), e.FechaRegistro, 103) AS 'Fecha Registro',
                    CASE WHEN e.Estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS 'Estado'
                FROM Equipos e
                INNER JOIN Clientes c ON e.ClienteID = c.ClienteID
                WHERE c.NombreCompleto LIKE '%{busqueda}%' 
                   OR e.Marca LIKE '%{busqueda}%'
                   OR e.Modelo LIKE '%{busqueda}%'
                   OR e.NumeroSerie LIKE '%{busqueda}%'
                ORDER BY e.EquipoID DESC";

                DataTable dt = ConexionBD.EjecutarConsulta(consulta);
                dgvEquipos.DataSource = dt;
                lblTotal.Text = $"Resultados encontrados: {dt.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvEquipos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditar_Click(sender, e);
            }
        }
    }
}