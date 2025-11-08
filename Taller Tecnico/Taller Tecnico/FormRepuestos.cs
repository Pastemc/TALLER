using SistemaTallerServicioTecnico.Clases;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaTallerServicioTecnico
{
    public partial class FormRepuestos : Form
    {
        private int repuestoIdSeleccionado = 0;
        private bool esNuevo = true;

        public FormRepuestos()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormRepuestos_Load(object sender, EventArgs e)
        {
            CargarRepuestos();
            CargarCategorias();
            LimpiarCampos();
        }

        private void CargarRepuestos()
        {
            try
            {
                string consulta = @"SELECT 
                    RepuestoID AS 'ID',
                    NombreRepuesto AS 'Nombre',
                    Descripcion AS 'Descripción',
                    Marca,
                    Categoria AS 'Categoría',
                    Stock,
                    StockMinimo AS 'Stock Mínimo',
                    PrecioUnitario AS 'Precio',
                    CONVERT(VARCHAR(10), FechaRegistro, 103) AS 'Fecha Registro',
                    CASE WHEN Estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS 'Estado'
                FROM Repuestos
                ORDER BY RepuestoID DESC";

                DataTable dt = ConexionBD.EjecutarConsulta(consulta);
                dgvRepuestos.DataSource = dt;

                if (dgvRepuestos.Columns.Count > 0)
                {
                    dgvRepuestos.Columns["ID"].Width = 50;
                    dgvRepuestos.Columns["Nombre"].Width = 180;
                    dgvRepuestos.Columns["Descripción"].Width = 200;
                    dgvRepuestos.Columns["Stock"].Width = 80;
                    dgvRepuestos.Columns["Precio"].Width = 100;

                    foreach (DataGridViewRow row in dgvRepuestos.Rows)
                    {
                        if (row.Cells["Stock"].Value != null && row.Cells["Stock Mínimo"].Value != null)
                        {
                            int stock = Convert.ToInt32(row.Cells["Stock"].Value);
                            int stockMin = Convert.ToInt32(row.Cells["Stock Mínimo"].Value);

                            if (stock == 0)
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 205, 210);
                            }
                            else if (stock <= stockMin)
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 249, 196);
                            }
                        }
                    }
                }

                lblTotal.Text = $"Total de repuestos: {dt.Rows.Count}";
                VerificarStockBajo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar repuestos: " + ex.Message);
            }
        }

        private void VerificarStockBajo()
        {
            try
            {
                string consulta = "SELECT COUNT(*) FROM Repuestos WHERE Stock <= StockMinimo AND Estado = 1";
                object resultado = ConexionBD.ObtenerValorEscalar(consulta);
                int stockBajo = resultado != null ? Convert.ToInt32(resultado) : 0;

                if (stockBajo > 0)
                {
                    lblAlerta.Text = $"⚠️ {stockBajo} repuesto(s) con stock bajo";
                    lblAlerta.ForeColor = Color.Red;
                    lblAlerta.Visible = true;
                }
                else
                {
                    lblAlerta.Visible = false;
                }
            }
            catch { }
        }

        private void CargarCategorias()
        {
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.AddRange(new string[] {
                "Memoria", "Almacenamiento", "Procesador", "Tarjeta Madre",
                "Fuente de Poder", "Periféricos", "Cables", "Insumos", "Software", "Otros"
            });
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtMarca.Clear();
            cmbCategoria.SelectedIndex = -1;
            numStock.Value = 0;
            numStockMinimo.Value = 5;
            numPrecio.Value = 0;
            checkActivo.Checked = true;
            repuestoIdSeleccionado = 0;
            esNuevo = true;
            btnGuardar.Text = "💾 Guardar Nuevo";
            txtNombre.Focus();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del repuesto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            if (cmbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una categoría", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategoria.Focus();
                return false;
            }
            if (numPrecio.Value <= 0)
            {
                MessageBox.Show("El precio debe ser mayor a 0", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPrecio.Focus();
                return false;
            }
            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                string nombre = txtNombre.Text.Trim();
                string descripcion = txtDescripcion.Text.Trim();
                string marca = txtMarca.Text.Trim();
                string categoria = cmbCategoria.Text;
                int stock = Convert.ToInt32(numStock.Value);
                int stockMinimo = Convert.ToInt32(numStockMinimo.Value);
                decimal precio = numPrecio.Value;
                int estado = checkActivo.Checked ? 1 : 0;

                if (esNuevo)
                {
                    string consulta = $@"INSERT INTO Repuestos 
                        (NombreRepuesto, Descripcion, Marca, Categoria, Stock, StockMinimo, PrecioUnitario, Estado)
                        VALUES ('{nombre}', '{descripcion}', '{marca}', '{categoria}', {stock}, {stockMinimo}, {precio}, {estado})";

                    if (ConexionBD.EjecutarComando(consulta))
                    {
                        MessageBox.Show("Repuesto registrado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarRepuestos();
                        LimpiarCampos();
                    }
                }
                else
                {
                    string consulta = $@"UPDATE Repuestos SET 
                        NombreRepuesto = '{nombre}', Descripcion = '{descripcion}', Marca = '{marca}',
                        Categoria = '{categoria}', Stock = {stock}, StockMinimo = {stockMinimo},
                        PrecioUnitario = {precio}, Estado = {estado}
                        WHERE RepuestoID = {repuestoIdSeleccionado}";

                    if (ConexionBD.EjecutarComando(consulta))
                    {
                        MessageBox.Show("Repuesto actualizado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarRepuestos();
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar repuesto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvRepuestos.SelectedRows.Count > 0)
            {
                repuestoIdSeleccionado = Convert.ToInt32(dgvRepuestos.SelectedRows[0].Cells["ID"].Value);
                string consulta = $"SELECT * FROM Repuestos WHERE RepuestoID = {repuestoIdSeleccionado}";
                DataTable dt = ConexionBD.EjecutarConsulta(consulta);

                if (dt.Rows.Count > 0)
                {
                    txtNombre.Text = dt.Rows[0]["NombreRepuesto"].ToString();
                    txtDescripcion.Text = dt.Rows[0]["Descripcion"].ToString();
                    txtMarca.Text = dt.Rows[0]["Marca"].ToString();
                    cmbCategoria.Text = dt.Rows[0]["Categoria"].ToString();
                    numStock.Value = Convert.ToDecimal(dt.Rows[0]["Stock"]);
                    numStockMinimo.Value = Convert.ToDecimal(dt.Rows[0]["StockMinimo"]);
                    numPrecio.Value = Convert.ToDecimal(dt.Rows[0]["PrecioUnitario"]);
                    checkActivo.Checked = Convert.ToBoolean(dt.Rows[0]["Estado"]);
                    esNuevo = false;
                    btnGuardar.Text = "💾 Actualizar";
                    txtNombre.Focus();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un repuesto para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvRepuestos.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de eliminar este repuesto?",
                    "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int repuestoId = Convert.ToInt32(dgvRepuestos.SelectedRows[0].Cells["ID"].Value);
                    string consulta = $"DELETE FROM Repuestos WHERE RepuestoID = {repuestoId}";

                    if (ConexionBD.EjecutarComando(consulta))
                    {
                        MessageBox.Show("Repuesto eliminado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarRepuestos();
                        LimpiarCampos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un repuesto para eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text.Trim();
            if (string.IsNullOrEmpty(busqueda))
            {
                CargarRepuestos();
                return;
            }

            try
            {
                string consulta = $@"SELECT RepuestoID AS 'ID', NombreRepuesto AS 'Nombre',
                    Descripcion AS 'Descripción', Marca, Categoria AS 'Categoría', Stock,
                    StockMinimo AS 'Stock Mínimo', PrecioUnitario AS 'Precio',
                    CONVERT(VARCHAR(10), FechaRegistro, 103) AS 'Fecha Registro',
                    CASE WHEN Estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS 'Estado'
                FROM Repuestos WHERE NombreRepuesto LIKE '%{busqueda}%' OR Marca LIKE '%{busqueda}%' OR Categoria LIKE '%{busqueda}%'
                ORDER BY RepuestoID DESC";

                DataTable dt = ConexionBD.EjecutarConsulta(consulta);
                dgvRepuestos.DataSource = dt;
                lblTotal.Text = $"Resultados encontrados: {dt.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message);
            }
        }

        private void btnStockBajo_Click(object sender, EventArgs e)
        {
            try
            {
                string consulta = @"SELECT RepuestoID AS 'ID', NombreRepuesto AS 'Nombre',
                    Descripcion AS 'Descripción', Marca, Categoria AS 'Categoría', Stock,
                    StockMinimo AS 'Stock Mínimo', PrecioUnitario AS 'Precio',
                    CONVERT(VARCHAR(10), FechaRegistro, 103) AS 'Fecha Registro',
                    CASE WHEN Estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS 'Estado'
                FROM Repuestos WHERE Stock <= StockMinimo AND Estado = 1 ORDER BY Stock ASC";

                DataTable dt = ConexionBD.EjecutarConsulta(consulta);
                dgvRepuestos.DataSource = dt;
                lblTotal.Text = $"Repuestos con stock bajo: {dt.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarRepuestos();
            MessageBox.Show("Lista actualizada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvRepuestos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditar_Click(sender, e);
            }
        }
    }
}