using Microsoft.Data.SqlClient;

namespace ConsoleApp1
{
    internal class Program
    {
        private const string CadenaConexion = @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=acceso_datos;Integrated Security=true;";

        static void Main(string[] args)
        {
            try
            {
                using SqlConnection conexion = conectar();

                Console.WriteLine($"Estado:   {conexion.State}");          // Open
                Console.WriteLine($"Servidor: {conexion.DataSource}");     // (localdb)\MSSQLLocalDB
                Console.WriteLine($"Base:     {conexion.Database}");       // AccesoDatos
                Console.WriteLine($"Versión:  {conexion.ServerVersion}");  // 16.00.xxxx

                using SqlCommand comando = new SqlCommand("SELECT Id, Nombre, Email FROM Personas ORDER BY Nombre", conexion);
                using SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    int id = lector.GetInt32(0);    // columna 0 del SELECT: Id
                    string nombre = lector.GetString(1);   // columna 1: Nombre
                    string email = lector.GetString(2);   // columna 2: Email
                    Console.WriteLine($"{id,3} | {nombre,-15} | {email}");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"❌ {ex.Message}: {ex.InnerException?.Message}");
            }
        }

        public static SqlConnection conectar()
        {
            var conexion = new SqlConnection(CadenaConexion);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException("Error al conectar", ex);
            }
        }
    }
}
