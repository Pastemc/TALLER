using SistemaTallerServicioTecnico.Clases;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaTallerServicioTecnico
{
    public partial class FormFacturas : Form
    {
        private int facturaIdSeleccionada = 0;
        private bool esNuevo = true;

        public FormFacturas()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormFacturas_Load(object sender, EventArgs e)
        {
            CargarFacturas();
            CargarServicios();
            CargarMetodosPago();
            CargarEstados();
            LimpiarCampos();
        }

        private void CargarFacturas()
        {
            try
            {
                string consulta = @"SELECT 
                    f.FacturaID AS 'ID',
                    f.NumeroFactura AS 'Nro. Factura',
                    c.NombreCompleto AS 'Cliente',
                    c.Telefono AS 'Teléfono',
                    CONVERT(VARCHAR(10), f.FechaEmision, 103) AS 'Fecha Emisión',
                    f.Subtotal,
                    f.IGV,
                    f.Total,
                    f.MetodoPago AS 'Método Pago',
                    f.Estado
                FROM Facturas f
                INNER JOIN Servicios s ON f.ServicioID = s.ServicioID
                INNER JOIN Clientes c ON f.ClienteID = c.ClienteID
                ORDER BY f.FacturaID DESC";

                DataTable dt = ConexionBD.EjecutarConsulta(consulta);
                dgvFacturas.DataSource = dt;

                if (dgvFacturas.Columns.Count > 0)
                {
                    dgvFacturas.Columns["ID"].Width = 50;
                    dgvFacturas.Columns["Nro. Factura"].Width = 120;
                    dgvFacturas.Columns["Cliente"].Width = 180;
                    dgvFacturas.Columns["Fecha Emisión"].Width = 100;
                    dgvFacturas.Columns["Subtotal"].Width = 90;
                    dgvFacturas.Columns["IGV"].Width = 70;
                    dgvFacturas.Columns["Total"].Width = 90;
                    dgvFacturas.Columns["Método Pago"].Width = 100;
                    dgvFacturas.Columns["Estado"].Width = 90;

                    // Formatear columnas de dinero
                    dgvFacturas.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
                    dgvFacturas.Columns["IGV"].DefaultCellStyle.Format = "C2";
                    dgvFacturas.Columns["Total"].DefaultCellStyle.Format = "C2";

                    // Colorear según estado
                    foreach (DataGridViewRow row in dgvFacturas.Rows)
                    {
                        if (row.Cells["Estado"].Value != null)
                        {
                            string estado = row.Cells["Estado"].Value.ToString();
                            if (estado == "Pendiente")
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 249, 196);
                            }
                            else if (estado == "Pagada")
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(200, 230, 201);
                            }
                            else if (estado == "Anulada")
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 205, 210);
                            }
                        }
                    }
                }

                lblTotal.Text = $"Total de facturas: {dt.Rows.Count}";
                CalcularTotalGeneral();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar facturas: " + ex.Message);
            }
        }

        private void CalcularTotalGeneral()
        {
            try
            {
                string consulta = "SELECT ISNULL(SUM(Total), 0) FROM Facturas WHERE Estado = 'Pagada'";
                object resultado = ConexionBD.ObtenerValorEscalar(consulta);
                decimal totalGeneral = resultado != null ? Convert.ToDecimal(resultado) : 0;
                lblTotalGeneral.Text = $"Total Facturado: {totalGeneral:C2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular total: " + ex.Message);
            }
        }

        private void CargarServicios()
        {
            try
            {
                string consulta = @"SELECT 
                    s.ServicioID,
                    c.NombreCompleto + ' - ' + e.TipoEquipo + ' ' + e.Marca AS Descripcion,
                    s.CostoServicio,
                    c.ClienteID
                FROM Servicios s
                INNER JOIN Clientes c ON s.ClienteID = c.ClienteID
                INNER JOIN Equipos e ON s.EquipoID = e.EquipoID
                WHERE s.EstadoServicio IN ('Completado', 'Entregado')
                AND s.ServicioID NOT IN (SELECT ServicioID FROM Facturas)
                ORDER BY s.ServicioID DESC";

                DataTable dt = ConexionBD.EjecutarConsulta(consulta);
                cmbServicio.DataSource = dt;
                cmbServicio.DisplayMember = "Descripcion";
                cmbServicio.ValueMember = "ServicioID";
                cmbServicio.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar servicios: " + ex.Message);
            }
        }

        private void CargarMetodosPago()
        {
            cmbMetodoPago.Items.Clear();
            cmbMetodoPago.Items.AddRange(new string[] {
                "Efectivo",
                "Tarjeta",
                "Transferencia",
                "Yape",
                "Plin",
                "Depósito Bancario"
            });
        }

        private void CargarEstados()
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.AddRange(new string[] {
                "Pendiente",
                "Pagada",
                "Anulada"
            });
            cmbEstado.SelectedIndex = 0;
        }

        private void LimpiarCampos()
        {
            cmbServicio.SelectedIndex = -1;
            txtNumeroFactura.Text = GenerarNumeroFactura();
            dtpFechaEmision.Value = DateTime.Now;
            numSubtotal.Value = 0;
            numIGV.Value = 0;
            numTotal.Value = 0;
            cmbMetodoPago.SelectedIndex = -1;
            cmbEstado.SelectedIndex = 0;
            txtObservaciones.Clear();
            facturaIdSeleccionada = 0;
            esNuevo = true;
            btnGuardar.Text = "💾 Guardar Nuevo";
            cmbServicio.Focus();
        }

        private string GenerarNumeroFactura()
        {
            try
            {
                string consulta = "SELECT COUNT(*) FROM Facturas";
                object resultado = ConexionBD.ObtenerValorEscalar(consulta);
                int contador = resultado != null ? Convert.ToInt32(resultado) + 1 : 1;

                return $"F-{DateTime.Now.Year}-{contador.ToString("D6")}";
            }
            catch
            {
                return $"F-{DateTime.Now.Year}-000001";
            }
        }

        private bool ValidarCampos()
        {
            if (cmbServicio.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un servicio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbServicio.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNumeroFactura.Text))
            {
                MessageBox.Show("Ingrese el número de factura", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumeroFactura.Focus();
                return false;
            }

            if (numSubtotal.Value <= 0)
            {
                MessageBox.Show("El subtotal debe ser mayor a 0", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numSubtotal.Focus();
                return false;
            }

            if (cmbMetodoPago.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un método de pago", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMetodoPago.Focus();
                return false;
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                int servicioId = Convert.ToInt32(cmbServicio.SelectedValue);

                // Obtener ClienteID del servicio seleccionado
                DataRowView drv = (DataRowView)cmbServicio.SelectedItem;
                int clienteId = Convert.ToInt32(drv["ClienteID"]);

                string numeroFactura = txtNumeroFactura.Text.Trim();
                string fechaEmision = dtpFechaEmision.Value.ToString("yyyy-MM-dd");
                decimal subtotal = numSubtotal.Value;
                decimal igv = numIGV.Value;
                decimal total = numTotal.Value;
                string metodoPago = cmbMetodoPago.Text;
                string estado = cmbEstado.Text;

                if (esNuevo)
                {
                    // Verificar que el número de factura no exista
                    string consultaVerificar = $"SELECT COUNT(*) FROM Facturas WHERE NumeroFactura = '{numeroFactura}'";
                    object resultVerif = ConexionBD.ObtenerValorEscalar(consultaVerificar);
                    int existe = resultVerif != null ? Convert.ToInt32(resultVerif) : 0;

                    if (existe > 0)
                    {
                        MessageBox.Show("El número de factura ya existe", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string consulta = $@"INSERT INTO Facturas 
                        (ServicioID, ClienteID, NumeroFactura, FechaEmision, Subtotal, IGV, Total, MetodoPago, Estado)
                        VALUES ({servicioId}, {clienteId}, '{numeroFactura}', '{fechaEmision}', 
                                {subtotal}, {igv}, {total}, '{metodoPago}', '{estado}')";

                    if (ConexionBD.EjecutarComando(consulta))
                    {
                        MessageBox.Show("Factura registrada exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarFacturas();
                        CargarServicios(); // Recargar para quitar el servicio facturado
                        LimpiarCampos();
                    }
                }
                else
                {
                    string consulta = $@"UPDATE Facturas SET 
                        NumeroFactura = '{numeroFactura}',
                        FechaEmision = '{fechaEmision}',
                        Subtotal = {subtotal},
                        IGV = {igv},
                        Total = {total},
                        MetodoPago = '{metodoPago}',
                        Estado = '{estado}'
                        WHERE FacturaID = {facturaIdSeleccionada}";

                    if (ConexionBD.EjecutarComando(consulta))
                    {
                        MessageBox.Show("Factura actualizada exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarFacturas();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar factura: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.SelectedRows.Count > 0)
            {
                facturaIdSeleccionada = Convert.ToInt32(dgvFacturas.SelectedRows[0].Cells["ID"].Value);

                string consulta = $"SELECT * FROM Facturas WHERE FacturaID = {facturaIdSeleccionada}";
                DataTable dt = ConexionBD.EjecutarConsulta(consulta);

                if (dt.Rows.Count > 0)
                {
                    // Cargar todos los servicios para edición
                    string consultaServicios = @"SELECT 
                        s.ServicioID,
                        c.NombreCompleto + ' - ' + e.TipoEquipo + ' ' + e.Marca AS Descripcion,
                        s.CostoServicio,
                        c.ClienteID
                    FROM Servicios s
                    INNER JOIN Clientes c ON s.ClienteID = c.ClienteID
                    INNER JOIN Equipos e ON s.EquipoID = e.EquipoID
                    WHERE s.EstadoServicio IN ('Completado', 'Entregado')
                    ORDER BY s.ServicioID DESC";

                    DataTable dtServicios = ConexionBD.EjecutarConsulta(consultaServicios);
                    cmbServicio.DataSource = dtServicios;
                    cmbServicio.DisplayMember = "Descripcion";
                    cmbServicio.ValueMember = "ServicioID";

                    cmbServicio.SelectedValue = dt.Rows[0]["ServicioID"];
                    txtNumeroFactura.Text = dt.Rows[0]["NumeroFactura"].ToString();
                    dtpFechaEmision.Value = Convert.ToDateTime(dt.Rows[0]["FechaEmision"]);
                    numSubtotal.Value = Convert.ToDecimal(dt.Rows[0]["Subtotal"]);
                    numIGV.Value = Convert.ToDecimal(dt.Rows[0]["IGV"]);
                    numTotal.Value = Convert.ToDecimal(dt.Rows[0]["Total"]);
                    cmbMetodoPago.Text = dt.Rows[0]["MetodoPago"].ToString();
                    cmbEstado.Text = dt.Rows[0]["Estado"].ToString();

                    esNuevo = false;
                    btnGuardar.Text = "💾 Actualizar";
                    cmbServicio.Focus();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una factura para editar", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "¿Está seguro de eliminar esta factura?\nEsta acción no se puede deshacer.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int facturaId = Convert.ToInt32(dgvFacturas.SelectedRows[0].Cells["ID"].Value);
                    string consulta = $"DELETE FROM Facturas WHERE FacturaID = {facturaId}";

                    if (ConexionBD.EjecutarComando(consulta))
                    {
                        MessageBox.Show("Factura eliminada exitosamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarFacturas();
                        CargarServicios();
                        LimpiarCampos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una factura para eliminar", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(busqueda))
            {
                CargarFacturas();
                return;
            }

            try
            {
                string consulta = $@"SELECT 
                    f.FacturaID AS 'ID',
                    f.NumeroFactura AS 'Nro. Factura',
                    c.NombreCompleto AS 'Cliente',
                    c.Telefono AS 'Teléfono',
                    CONVERT(VARCHAR(10), f.FechaEmision, 103) AS 'Fecha Emisión',
                    f.Subtotal,
                    f.IGV,
                    f.Total,
                    f.MetodoPago AS 'Método Pago',
                    f.Estado
                FROM Facturas f
                INNER JOIN Servicios s ON f.ServicioID = s.ServicioID
                INNER JOIN Clientes c ON f.ClienteID = c.ClienteID
                WHERE f.NumeroFactura LIKE '%{busqueda}%' 
                   OR c.NombreCompleto LIKE '%{busqueda}%'
                   OR c.Telefono LIKE '%{busqueda}%'
                   OR f.Estado LIKE '%{busqueda}%'
                ORDER BY f.FacturaID DESC";

                DataTable dt = ConexionBD.EjecutarConsulta(consulta);
                dgvFacturas.DataSource = dt;
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
                string consulta = @"SELECT 
                    f.FacturaID AS 'ID',
                    f.NumeroFactura AS 'Nro. Factura',
                    c.NombreCompleto AS 'Cliente',
                    c.Telefono AS 'Teléfono',
                    CONVERT(VARCHAR(10), f.FechaEmision, 103) AS 'Fecha Emisión',
                    f.Subtotal,
                    f.IGV,
                    f.Total,
                    f.MetodoPago AS 'Método Pago',
                    f.Estado
                FROM Facturas f
                INNER JOIN Servicios s ON f.ServicioID = s.ServicioID
                INNER JOIN Clientes c ON f.ClienteID = c.ClienteID
                WHERE f.Estado = 'Pendiente'
                ORDER BY f.FechaEmision DESC";

                DataTable dt = ConexionBD.EjecutarConsulta(consulta);
                dgvFacturas.DataSource = dt;
                lblTotal.Text = $"Facturas pendientes: {dt.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.Message);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.SelectedRows.Count > 0)
            {
                MessageBox.Show("Función de impresión en desarrollo.\n\n" +
                    "Aquí se generaría un PDF con los datos de la factura.",
                    "Imprimir Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seleccione una factura para imprimir", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServicio.SelectedIndex != -1 && esNuevo)
            {
                try
                {
                    DataRowView drv = (DataRowView)cmbServicio.SelectedItem;
                    decimal costoServicio = Convert.ToDecimal(drv["CostoServicio"]);

                    numSubtotal.Value = costoServicio;
                    CalcularTotal();
                }
                catch { }
            }
        }

        private void numSubtotal_ValueChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            decimal subtotal = numSubtotal.Value;
            decimal igv = subtotal * 0.18m; // 18% de IGV
            decimal total = subtotal + igv;

            numIGV.Value = Math.Round(igv, 2);
            numTotal.Value = Math.Round(total, 2);
        }

        private void dgvFacturas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditar_Click(sender, e);
            }
        }
    }
}