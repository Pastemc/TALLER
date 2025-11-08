using SistemaTallerServicioTecnico.Clases;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaTallerServicioTecnico
{
    public partial class FormCitas : Form
    {
        private int citaIdSeleccionada = 0;
        private bool esNuevo = true;

        public FormCitas()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormCitas_Load(object sender, EventArgs e)
        {
            CargarCitas();
            CargarClientes();
            CargarEquipos();
            CargarEstados();
            LimpiarCampos();
        }

        private void CargarCitas()
        {
            try
            {
                string consulta = @"SELECT 
                    c.CitaID AS 'ID',
                    cl.NombreCompleto AS 'Cliente',
                    cl.Telefono AS 'Teléfono',
                    e.TipoEquipo + ' ' + e.Marca AS 'Equipo',
                    CONVERT(VARCHAR(10), c.FechaCita, 103) AS 'Fecha',
                    CONVERT(VARCHAR(5), c.HoraCita, 108) AS 'Hora',
                    c.Motivo,
                    c.Estado,
                    c.Observaciones,
                    CONVERT(VARCHAR(10), c.FechaCreacion, 103) AS 'Fecha Creación'
                FROM Citas c
                INNER JOIN Clientes cl ON c.ClienteID = cl.ClienteID
                INNER JOIN Equipos e ON c.EquipoID = e.EquipoID
                ORDER BY c.FechaCita DESC, c.HoraCita DESC";

                DataTable dt = ConexionBD.EjecutarConsulta(consulta);
                dgvCitas.DataSource = dt;

                if (dgvCitas.Columns.Count > 0)
                {
                    dgvCitas.Columns["ID"].Width = 50;
                    dgvCitas.Columns["Cliente"].Width = 150;
                    dgvCitas.Columns["Equipo"].Width = 150;
                    dgvCitas.Columns["Fecha"].Width = 90;
                    dgvCitas.Columns["Hora"].Width = 70;
                    dgvCitas.Columns["Motivo"].Width = 200;
                    dgvCitas.Columns["Estado"].Width = 100;

                    foreach (DataGridViewRow row in dgvCitas.Rows)
                    {
                        if (row.Cells["Estado"].Value != null)
                        {
                            string estado = row.Cells["Estado"].Value.ToString();
                            if (estado == "Pendiente")
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 249, 196);
                            }
                            else if (estado == "Confirmada")
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(200, 230, 201);
                            }
                            else if (estado == "Cancelada")
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 205, 210);
                            }
                        }
                    }
                }

                lblTotal.Text = $"Total de citas: {dt.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar citas: " + ex.Message);
            }
        }

        private void CargarClientes()
        {
            try
            {
                string consulta = "SELECT ClienteID, NombreCompleto, Telefono FROM Clientes WHERE Estado = 1 ORDER BY NombreCompleto";
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

        private void CargarEquipos()
        {
            if (cmbCliente.SelectedValue != null)
            {
                try
                {
                    int clienteId = Convert.ToInt32(cmbCliente.SelectedValue);
                    string consulta = $@"SELECT EquipoID, TipoEquipo + ' ' + Marca + ' ' + Modelo AS Descripcion 
                        FROM Equipos WHERE ClienteID = {clienteId} AND Estado = 1 ORDER BY EquipoID DESC";
                    DataTable dt = ConexionBD.EjecutarConsulta(consulta);

                    cmbEquipo.DataSource = dt;
                    cmbEquipo.DisplayMember = "Descripcion";
                    cmbEquipo.ValueMember = "EquipoID";
                    cmbEquipo.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar equipos: " + ex.Message);
                }
            }
        }

        private void CargarEstados()
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.AddRange(new string[] {
                "Pendiente",
                "Confirmada",
                "Completada",
                "Cancelada"
            });
            cmbEstado.SelectedIndex = 0;
        }

        private void LimpiarCampos()
        {
            cmbCliente.SelectedIndex = -1;
            cmbEquipo.DataSource = null;
            dtpFechaCita.Value = DateTime.Now.AddDays(1);
            dtpHoraCita.Value = DateTime.Now;
            txtMotivo.Clear();
            cmbEstado.SelectedIndex = 0;
            txtObservaciones.Clear();
            citaIdSeleccionada = 0;
            esNuevo = true;
            btnGuardar.Text = "💾 Guardar Nuevo";
            cmbCliente.Focus();
        }

        private bool ValidarCampos()
        {
            if (cmbCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un cliente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCliente.Focus();
                return false;
            }

            if (cmbEquipo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un equipo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEquipo.Focus();
                return false;
            }

            if (dtpFechaCita.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("La fecha de la cita no puede ser anterior a hoy", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFechaCita.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("Ingrese el motivo de la cita", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotivo.Focus();
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
                int equipoId = Convert.ToInt32(cmbEquipo.SelectedValue);
                string fechaCita = dtpFechaCita.Value.ToString("yyyy-MM-dd");
                string horaCita = dtpHoraCita.Value.ToString("HH:mm:ss");
                string motivo = txtMotivo.Text.Trim().Replace("'", "''");
                string estado = cmbEstado.Text;
                string observaciones = txtObservaciones.Text.Trim().Replace("'", "''");

                if (esNuevo)
                {
                    string consulta = $@"INSERT INTO Citas 
                        (ClienteID, EquipoID, FechaCita, HoraCita, Motivo, Estado, Observaciones)
                        VALUES ({clienteId}, {equipoId}, '{fechaCita}', '{horaCita}', '{motivo}', '{estado}', '{observaciones}')";

                    if (ConexionBD.EjecutarComando(consulta))
                    {
                        MessageBox.Show("Cita registrada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCitas();
                        LimpiarCampos();
                    }
                }
                else
                {
                    string consulta = $@"UPDATE Citas SET 
                        ClienteID = {clienteId},
                        EquipoID = {equipoId},
                        FechaCita = '{fechaCita}',
                        HoraCita = '{horaCita}',
                        Motivo = '{motivo}',
                        Estado = '{estado}',
                        Observaciones = '{observaciones}'
                        WHERE CitaID = {citaIdSeleccionada}";

                    if (ConexionBD.EjecutarComando(consulta))
                    {
                        MessageBox.Show("Cita actualizada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCitas();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cita: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.SelectedRows.Count > 0)
            {
                citaIdSeleccionada = Convert.ToInt32(dgvCitas.SelectedRows[0].Cells["ID"].Value);

                string consulta = $"SELECT * FROM Citas WHERE CitaID = {citaIdSeleccionada}";
                DataTable dt = ConexionBD.EjecutarConsulta(consulta);

                if (dt.Rows.Count > 0)
                {
                    cmbCliente.SelectedValue = dt.Rows[0]["ClienteID"];
                    CargarEquipos();
                    cmbEquipo.SelectedValue = dt.Rows[0]["EquipoID"];
                    dtpFechaCita.Value = Convert.ToDateTime(dt.Rows[0]["FechaCita"]);

                    DateTime horaCita = DateTime.Parse(dt.Rows[0]["HoraCita"].ToString());
                    dtpHoraCita.Value = DateTime.Today.Add(horaCita.TimeOfDay);

                    txtMotivo.Text = dt.Rows[0]["Motivo"].ToString();
                    cmbEstado.Text = dt.Rows[0]["Estado"].ToString();
                    txtObservaciones.Text = dt.Rows[0]["Observaciones"].ToString();

                    esNuevo = false;
                    btnGuardar.Text = "💾 Actualizar";
                    cmbCliente.Focus();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una cita para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de eliminar esta cita?",
                    "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int citaId = Convert.ToInt32(dgvCitas.SelectedRows[0].Cells["ID"].Value);
                    string consulta = $"DELETE FROM Citas WHERE CitaID = {citaId}";

                    if (ConexionBD.EjecutarComando(consulta))
                    {
                        MessageBox.Show("Cita eliminada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCitas();
                        LimpiarCampos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una cita para eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(busqueda))
            {
                CargarCitas();
                return;
            }

            try
            {
                string consulta = $@"SELECT c.CitaID AS 'ID', cl.NombreCompleto AS 'Cliente', cl.Telefono AS 'Teléfono',
                    e.TipoEquipo + ' ' + e.Marca AS 'Equipo', CONVERT(VARCHAR(10), c.FechaCita, 103) AS 'Fecha',
                    CONVERT(VARCHAR(5), c.HoraCita, 108) AS 'Hora', c.Motivo, c.Estado, c.Observaciones,
                    CONVERT(VARCHAR(10), c.FechaCreacion, 103) AS 'Fecha Creación'
                FROM Citas c INNER JOIN Clientes cl ON c.ClienteID = cl.ClienteID
                INNER JOIN Equipos e ON c.EquipoID = e.EquipoID
                WHERE cl.NombreCompleto LIKE '%{busqueda}%' OR e.Marca LIKE '%{busqueda}%' 
                   OR c.Motivo LIKE '%{busqueda}%' OR c.Estado LIKE '%{busqueda}%'
                ORDER BY c.FechaCita DESC, c.HoraCita DESC";

                DataTable dt = ConexionBD.EjecutarConsulta(consulta);
                dgvCitas.DataSource = dt;
                lblTotal.Text = $"Resultados encontrados: {dt.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message);
            }
        }

        private void btnFiltrarPendientes_Click(object sender, EventArgs e)
        {
            try
            {
                string consulta = @"SELECT c.CitaID AS 'ID', cl.NombreCompleto AS 'Cliente', cl.Telefono AS 'Teléfono',
                    e.TipoEquipo + ' ' + e.Marca AS 'Equipo', CONVERT(VARCHAR(10), c.FechaCita, 103) AS 'Fecha',
                    CONVERT(VARCHAR(5), c.HoraCita, 108) AS 'Hora', c.Motivo, c.Estado, c.Observaciones,
                    CONVERT(VARCHAR(10), c.FechaCreacion, 103) AS 'Fecha Creación'
                FROM Citas c INNER JOIN Clientes cl ON c.ClienteID = cl.ClienteID
                INNER JOIN Equipos e ON c.EquipoID = e.EquipoID
                WHERE c.Estado IN ('Pendiente', 'Confirmada')
                ORDER BY c.FechaCita ASC, c.HoraCita ASC";

                DataTable dt = ConexionBD.EjecutarConsulta(consulta);
                dgvCitas.DataSource = dt;
                lblTotal.Text = $"Citas pendientes: {dt.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedIndex != -1)
            {
                CargarEquipos();
            }
        }

        private void dgvCitas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditar_Click(sender, e);
            }
        }
    }
}