using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaTallerServicioTecnico
{
    /// <summary>
    /// Clase para manejar la conexión y operaciones con SQL Server
    /// </summary>
    public class ConexionBD
    {
        // ⚠️ IMPORTANTE: CAMBIA ESTO POR TU SERVIDOR SQL SERVER
        // Para ver tu servidor, abre SQL Server Management Studio
        // El nombre aparece cuando te conectas, ejemplo: DESKTOP-G29AM4\SQLEXPRESS
        private static string servidor = "DESKTOP-G29AMJ4"; // ⬅️ CAMBIA ESTO
        private static string baseDatos = "TallerServicioTecnico";

        // Cadena de conexión con seguridad integrada de Windows
        private static string cadenaConexion =
            $"Data Source={servidor};Initial Catalog={baseDatos};Integrated Security=True;";

        /// <summary>
        /// Obtiene la conexión a la base de datos
        /// </summary>
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message +
                    "\n\nVerifica que SQL Server esté ejecutándose y que el nombre del servidor sea correcto.",
                    "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Prueba la conexión a la base de datos
        /// </summary>
        public static bool ProbarConexion()
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    if (conexion != null)
                    {
                        conexion.Close();
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Ejecuta una consulta SELECT y retorna un DataTable
        /// </summary>
        public static DataTable EjecutarConsulta(string consulta)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    if (conexion != null)
                    {
                        SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
                        adaptador.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar consulta: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        /// <summary>
        /// Ejecuta comandos INSERT, UPDATE, DELETE
        /// </summary>
        public static bool EjecutarComando(string comando)
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    if (conexion != null)
                    {
                        SqlCommand cmd = new SqlCommand(comando, conexion);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar comando: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado con parámetros
        /// </summary>
        public static bool EjecutarProcedimiento(string nombreProcedimiento, SqlParameter[] parametros)
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    if (conexion != null)
                    {
                        SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (parametros != null)
                        {
                            cmd.Parameters.AddRange(parametros);
                        }

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar procedimiento: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Obtiene un valor escalar (para COUNT, SUM, MAX, MIN, etc.)
        /// ⚠️ ESTE MÉTODO ES ESENCIAL PARA EL MENÚ PRINCIPAL
        /// </summary>
        public static object ObtenerValorEscalar(string consulta)
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    if (conexion != null)
                    {
                        SqlCommand cmd = new SqlCommand(consulta, conexion);
                        object resultado = cmd.ExecuteScalar();
                        return resultado;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener valor: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        /// <summary>
        /// Ejecuta una consulta SELECT y retorna un SqlDataReader
        /// Útil para leer grandes cantidades de datos de forma eficiente
        /// </summary>
        public static SqlDataReader EjecutarReader(string consulta, SqlConnection conexion)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(consulta, conexion);
                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar reader: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Verifica si existe un registro en una tabla
        /// </summary>
        public static bool ExisteRegistro(string tabla, string condicion)
        {
            try
            {
                string consulta = $"SELECT COUNT(*) FROM {tabla} WHERE {condicion}";
                object resultado = ObtenerValorEscalar(consulta);

                if (resultado != null && resultado != DBNull.Value)
                {
                    int count = Convert.ToInt32(resultado);
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar registro: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        /// <summary>
        /// Obtiene el último ID insertado
        /// </summary>
        public static int ObtenerUltimoID(string tabla, string campoID)
        {
            try
            {
                string consulta = $"SELECT MAX({campoID}) FROM {tabla}";
                object resultado = ObtenerValorEscalar(consulta);

                if (resultado != null && resultado != DBNull.Value)
                {
                    return Convert.ToInt32(resultado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener último ID: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return 0;
        }

        /// <summary>
        /// Ejecuta una transacción (conjunto de comandos que se ejecutan todos o ninguno)
        /// </summary>
        public static bool EjecutarTransaccion(string[] comandos)
        {
            SqlConnection conexion = null;
            SqlTransaction transaccion = null;

            try
            {
                conexion = ObtenerConexion();
                if (conexion != null)
                {
                    transaccion = conexion.BeginTransaction();

                    foreach (string comando in comandos)
                    {
                        SqlCommand cmd = new SqlCommand(comando, conexion, transaccion);
                        cmd.ExecuteNonQuery();
                    }

                    transaccion.Commit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                if (transaccion != null)
                {
                    transaccion.Rollback();
                }
                MessageBox.Show("Error en la transacción: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
            return false;
        }
    }
}