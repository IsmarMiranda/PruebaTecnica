using System;
using System.Data;
using System.Data.SqlClient;

public class Conector
{
    private string cadenaDeConexion;

    public Conector(string cadenaDeConexion)
    {
        this.cadenaDeConexion = cadenaDeConexion;
    }
    // Método para verificar la conexión
    public bool VerificarConexion()
    {
        try
        {
            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            {
                conexion.Open();
                // Si llegamos aquí, la conexión fue exitosa
                return true;
            }
        }
        catch (Exception ex)
        {
            // Manejar excepciones según sea necesario
            Console.WriteLine("Error al conectar con la base de datos: " + ex.Message);
            return false;
        }
    }



    /// <summary>
    /// Recibe una consulta Select y retorna informacion.
    /// </summary>
    /// <param name="consulta">Consulta SQL a ejecutar</param>
    /// <returns>Un DataSet con información del select</returns>
    public DataSet returnDataSet(string consulta)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
        {
            // Validar que la consulta comience con SELECT
            if (!consulta.Trim().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            using (SqlDataAdapter data = new SqlDataAdapter(consulta, conexion))
            {
                try
                {
                    conexion.Open();
                    data.Fill(dataSet);
                }
                catch (Exception ex)
                {
                    // Manejar excepciones según sea necesario
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        return dataSet;
    }


    /// <summary>
    /// Recibe una consulta INSERT, UPDATE O DELETE y retorna las filas afectadas.
    /// </summary>
    /// <param name="comando">ejecuta un INSERT UPDATE O DELETE.</param>
    /// <returns>retorna un entero con las filas afectadas.</returns>
    public int EjecutarComandoContar(string comando)
    {
        int filas = 0;
        using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
        {
            using (SqlCommand sqlComando = new SqlCommand(comando, conexion))
            {
                try
                {
                    conexion.Open();
                    filas = sqlComando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Manejar excepciones según sea necesario
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        return filas;
    }

    /// <summary>
    /// Recibe una consulta SELECT y retorna las filas que mostraria.
    /// </summary>
    /// <param name="consulta">recibe una consulta select</param>
    /// <returns>retorna un entero con las filas del select</returns>
    public int ContarFilas(string consulta)
    {
        int filasDevueltas = 0;
        string consultaConteo = "SELECT COUNT(*) FROM (" + consulta + ") AS ConsultaConteo";

        // Validar que la consulta comience con SELECT
        if (!consulta.Trim().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
        {
            return 0;
        }

        using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
        {
            using (SqlCommand comandoSql = new SqlCommand(consultaConteo, conexion))
            {
                try
                {
                    conexion.Open();
                    filasDevueltas = (int)comandoSql.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    // Manejar excepciones según sea necesario
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        return filasDevueltas;
    }
}
