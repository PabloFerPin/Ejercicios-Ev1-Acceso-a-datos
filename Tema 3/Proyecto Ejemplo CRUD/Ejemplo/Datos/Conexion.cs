using Microsoft.Data.SqlClient;

namespace CrudPersonas.Datos;

// Único sitio del proyecto donde aparece la cadena de conexión (§3.3.2).
// Si mañana cambia el servidor, solo se toca esta línea.
public static class Conexion
{
    private const string CadenaConexion =
        @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=AccesoDatos;Integrated Security=true;";

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
                "No se pudo conectar con la base de datos AccesoDatos", ex);
        }
    }
}