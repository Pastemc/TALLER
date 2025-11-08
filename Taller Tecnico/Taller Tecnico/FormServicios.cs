using SistemaTallerServicioTecnico.Clases;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaTallerServicioTecnico
{
    public partial class FormServicios : Form
    {
        private int servicioIdSeleccionado = 0;
        private bool esNuevo = true;

        public FormServicios()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormServicios_Load(object sender, EventArgs e)
        {
            CargarServicios();
            CargarClientes();
            CargarEquipos();
            CargarTiposServicio();
            CargarEstadosServicio();
            CargarPrioridades();
            LimpiarCampos();
        }

        private void CargarServicios()
        {
            try
            {
                string consulta = @"SELECT 
                    s.ServicioID AS 'ID',
                    c.NombreCompleto AS 'Cliente',
                    e.TipoEquipo + ' ' + e.Marca AS 'Equipo',
                    s.TipoServicio AS 'Tipo Servicio',
                    s.Diagnostico AS 'Diagnóstico',
                    s.EstadoServicio AS 'Estado',
                    s.Prioridad,
                    s.CostoServicio AS 'Costo',
                    s.Tecnico AS 'Técnico',
                    CONVERT(VARCHAR(10), s.FechaIngreso, 103) AS 'Fecha Ingreso',
                    CONVERT(VARCHAR(10), s.FechaEntrega, 103) AS 'Fecha Entrega'
                FROM Servicios s
                INNER JOIN Clientes c ON s.ClienteID = c.ClienteID
                INNER JOIN Equipos e ON s.EquipoID = e.EquipoID
                ORDER BY s.ServicioID DESC";

                DataTable dt = ConexionBD.EjecutarConsulta(consulta);
                dgvServicios.DataSource = dt;

                if (dgvServicios.Columns.Count > 0)
                {
                    dgvServicios.Columns["ID"].Width = 50;
                    dgvServicios.Columns["Cliente"].Width = 150;
                    dgvServicios.Columns["Equipo"].Width = 150;
                    dgvServicios.Columns["Costo"].DefaultCellStyle.Format = "C2";
                }

                lblTotal.Text = $"Total de servicios: {dt.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar servicios: " + ex.Message);
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

        private void CargarEquipos()
        {
            if (cmbCliente.SelectedValue != null)
            {
                try
                {
                    int clienteId = Convert.ToInt32(cmbCliente.SelectedValue);
                    string consulta = $@"SELECT EquipoID, TipoEquipo + ' ' + Marca + ' ' + Modelo AS Equipo 
                                       FROM Equipos 
                                       WHERE ClienteID = {clienteId} AND Estado = 1";
                    DataTable dt = ConexionBD.EjecutarConsulta(consulta);

                    cmbEquipo.DataSource = dt;
                    cmbEquipo.DisplayMember = "Equipo";
                    cmbEquipo.ValueMember = "EquipoID";
                    cmbEquipo.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar equipos: " + ex.Message);
                }
            }
        }

        private void CargarTiposServicio()
        {
            cmbTipoServicio.Items.Clear();
            cmbTipoServicio.Items.AddRange(new string[] {
                "Reparación",
                "Mantenimiento",
                "Revisión",
                "Instalación",
                "Actualización",
                "Limpieza",
                "Diagnóstico",
                "Garantía"
            });
        }

        private void CargarEstadosServicio()
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.AddRange(new string[] {
                "Pendiente",
                "En Proceso",
                "Completado",
                "Entregado",
                "Cancelado"
            });
        }

        private void CargarPrioridades()
        {
            cmbPrioridad.Items.Clear();
            cmbPrioridad.Items.AddRange(new string[] {
                "Baja",
                "Normal",
                "Alta",
                "Urgente"
            });
            cmbPrioridad.SelectedIndex = 1; // Normal por defecto
        }

        private void LimpiarCampos()
        {
            cmbCliente.SelectedIndex = -1;
            cmbEquipo.DataSource = null;
            cmbTipoServicio.SelectedIndex = -1;
            cmbEstado.SelectedIndex = 0;
            cmbPrioridad.SelectedIndex = 1;
            txtDiagnostico.Clear();
            txtCosto.Text = "0.00";
            txtTecnico.Clear();
            txtObservaciones.Clear();
            dtpFechaIngreso.Value = DateTime.Now;
            dtpFechaEntrega.Value = DateTime.Now.AddDays(3);
            servicioIdSeleccionado = 0;
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

            if (cmbEquipo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un equipo", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEquipo.Focus();
                return false;
            }

            if (cmbTipoServicio.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de servicio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipoServicio.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiagnostico.Text))
            {
                MessageBox.Show("Ingrese el diagnóstico", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiagnostico.Focus();
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
                string tipoServicio = cmbTipoServicio.Text;
                string estadoServicio = cmbEstado.Text;
                string prioridad = cmbPrioridad.Text;
                string diagnostico = txtDiagnostico.Text.Trim().Replace("'", "''");
                decimal costo = Convert.ToDecimal(txtCosto.Text);
                string tecnico = txtTecnico.Text.Trim().Replace("'", "''");
                string observaciones = txtObservaciones.Text.Trim().Replace("'", "''");
                string fechaIngreso = dtpFechaIngreso.Value.ToString("yyyy-MM-dd");
                string fechaEntrega = dtpFechaEntrega.Value.ToString("yyyy-MM-dd");

                if (esNuevo)
                {
                    string consulta = $@"INSERT INTO Servicios 
                        (ClienteID, EquipoID, TipoServicio, EstadoServicio, Prioridad, 
                         Diagnostico, CostoServicio, Tecnico, Observaciones, FechaIngreso, FechaEntrega)
                        VALUES ({clienteId}, {equipoId}, '{tipoServicio}', '{estadoServicio}', '{prioridad}', 
                                '{diagnostico}', {costo}, '{tecnico}', '{observaciones}', '{fechaIngreso}', '{fechaEntrega}')";

                    if (ConexionBD.EjecutarComando(consulta))
                    {
                        MessageBox.Show("Servicio registrado exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarServicios();
                        LimpiarCampos();
                    }
                }
                else
                {
                    string consulta = $@"UPDATE Servicios SET 
                        ClienteID = {clienteId},
                        EquipoID = {equipoId},
                        TipoServicio = '{tipoServicio}',
                        EstadoServicio = '{estadoServicio}',
                        Prioridad = '{prioridad}',
                        Diagnostico = '{diagnostico}',
                        CostoServicio = {costo},
                        Tecnico = '{tecnico}',
                        Observaciones = '{observaciones}',
                        FechaIngreso = '{fechaIngreso}',
                        FechaEntrega = '{fechaEntrega}'
                        WHERE ServicioID = {servicioIdSeleccionado}";

                    if (ConexionBD.EjecutarComando(consulta))
                    {
                        MessageBox.Show("Servicio actualizado exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarServicios();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar servicio: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvServicios.SelectedRows.Count > 0)
            {
                servicioIdSeleccionado = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["ID"].Value);

                string consulta = $"SELECT * FROM Servicios WHERE ServicioID = {servicioIdSeleccionado}";
                DataTable dt = ConexionBD.EjecutarConsulta(consulta);

                if (dt.Rows.Count > 0)
                {
                    cmbCliente.SelectedValue = dt.Rows[0]["ClienteID"];
                    CargarEquipos();
                    cmbEquipo.SelectedValue = dt.Rows[0]["EquipoID"];
                    cmbTipoServicio.Text = dt.Rows[0]["TipoServicio"].ToString();
                    cmbEstado.Text = dt.Rows[0]["EstadoServicio"].ToString();
                    cmbPrioridad.Text = dt.Rows[0]["Prioridad"].ToString();
                    txtDiagnostico.Text = dt.Rows[0]["Diagnostico"].ToString();
                    txtCosto.Text = dt.Rows[0]["CostoServicio"].ToString();
                    txtTecnico.Text = dt.Rows[0]["Tecnico"].ToString();
                    txtObservaciones.Text = dt.Rows[0]["Observaciones"].ToString();

                    if (dt.Rows[0]["FechaIngreso"] != DBNull.Value)
                        dtpFechaIngreso.Value = Convert.ToDateTime(dt.Rows[0]["FechaIngreso"]);
                    if (dt.Rows[0]["FechaEntrega"] != DBNull.Value)
                        dtpFechaEntrega.Value = Convert.ToDateTime(dt.Rows[0]["FechaEntrega"]);

                    esNuevo = false;
                    btnGuardar.Text = "💾 Actualizar";
                    cmbCliente.Focus();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un servicio para editar", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvServicios.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "¿Está seguro de eliminar este servicio?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int servicioId = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["ID"].Value);
                    string consulta = $"DELETE FROM Servicios WHERE ServicioID = {servicioId}";

                    if (ConexionBD.EjecutarComando(consulta))
                    {
                        MessageBox.Show("Servicio eliminado exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarServicios();
                        LimpiarCampos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un servicio para eliminar", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(busqueda))
            {
                CargarServicios();
                return;
            }

            try
            {
                string consulta = $@"SELECT 
                    s.ServicioID AS 'ID',
                    c.NombreCompleto AS 'Cliente',
                    e.TipoEquipo + ' ' + e.Marca AS 'Equipo',
                    s.TipoServicio AS 'Tipo Servicio',
                    s.Diagnostico AS 'Diagnóstico',
                    s.EstadoServicio AS 'Estado',
                    s.Prioridad,
                    s.CostoServicio AS 'Costo',
                    s.Tecnico AS 'Técnico',
                    CONVERT(VARCHAR(10), s.FechaIngreso, 103) AS 'Fecha Ingreso',
                    CONVERT(VARCHAR(10), s.FechaEntrega, 103) AS 'Fecha Entrega'
                FROM Servicios s
                INNER JOIN Clientes c ON s.ClienteID = c.ClienteID
                INNER JOIN Equipos e ON s.EquipoID = e.EquipoID
                WHERE c.NombreCompleto LIKE '%{busqueda}%' 
                   OR s.Diagnostico LIKE '%{busqueda}%'
                   OR s.Tecnico LIKE '%{busqueda}%'
                ORDER BY s.ServicioID DESC";

                DataTable dt = ConexionBD.EjecutarConsulta(consulta);
                dgvServicios.DataSource = dt;
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

        private void dgvServicios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditar_Click(sender, e);
            }
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarEquipos();
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && txtCosto.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}