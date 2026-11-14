using Microsoft.Data.SqlClient;

namespace ClubTenis.Datos;

// Único sitio del proyecto donde aparece la cadena de conexión.
public static class Conexion
{
    private const string CadenaConexion =
        @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=ClubTenis;Integrated Security=true;";

    // Devuelve una conexión YA ABIERTA. Quien la pide la cierra con using.
    public static SqlConnection Conectar()
    {
        var conexion = new SqlConnection(CadenaConexion);
        try
        {
            conexion.Open();
            return conexion;
        }
        catch (SqlException ex)
        {
            conexion.Dispose();
            throw new InvalidOperationException(
                "No se pudo conectar con la base de datos ClubTenis", ex);
        }
    }
}
