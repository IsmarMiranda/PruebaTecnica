using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConexion
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Configuracion de cadena de conexion: CAMBIAR PARAMETROS SERVER, DATABASE, USER ID, PASSWORD
            string cadenaConexion = "Server=;Database=;User Id=sa;Password=;";
            Conector conexion = new Conector(cadenaConexion);

            // Ejecutar un SELECT y obtener un DataSet
            string sqlSelect = "SELECT * FROM Customers";
            DataSet DataSet = conexion.returnDataSet(sqlSelect);
            
            Console.Write("Dataset exitoso.");
            Console.WriteLine();
            // Ejecutar un INSERT y obtener el número de filas afectadas
            string consultaInsert = "INSERT INTO NombreTabla (Columna1, Columna2) VALUES ('Valor1', 'Valor2')";
            int filasAfectadas = conexion.EjecutarComandoContar(consultaInsert);
            Console.WriteLine("Filas fectadas: "+ filasAfectadas);
            Console.WriteLine();
            // Obtener el número de filas que devolvería un SELECT
            string consultaConteo = "SELECT * FROM Customers";
            int numeroFilas = conexion.ContarFilas(consultaConteo);

            Console.WriteLine("Las columnas afectadas serían: " + numeroFilas);
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
