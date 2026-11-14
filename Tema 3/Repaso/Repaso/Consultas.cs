using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace Repaso
{
    internal class Consultas
    {
        static void Main(String[] args)
        {
            using SqlConnection conexion = Insertar.conectar();

            using SqlCommand query = new SqlCommand("SELECT COUNT(*) FROM Prestamos", conexion);
            Console.WriteLine($"Numero de prestamos: {query.ExecuteScalar()}");

            using SqlCommand query2 = new SqlCommand("SELECT IDENT_CURRENT('Prestamos') FROM Prestamos", conexion);
            Console.WriteLine($"IDENT_CURRENT: {query2.ExecuteScalar()}");

            using SqlCommand query3 = new SqlCommand("SELECT COUNT(IdPrestamo) FROM Prestamos WHERE FechaDevolucionReal IS NULL", conexion);
            Console.WriteLine($"Pendientes de devolver: {query3.ExecuteScalar()}");

            using SqlCommand query4 = new SqlCommand("SELECT COUNT(DISTINCT CodigoSocio) FROM Prestamos", conexion);
            Console.WriteLine($"Socios distintos: {query4.ExecuteScalar()}");

            using SqlCommand query5 = new SqlCommand("SELECT COUNT(DISTINCT Titulo) FROM Prestamos", conexion);
            Console.WriteLine($"Libros distintos: {query5.ExecuteScalar()}");

            using SqlCommand query6 = new SqlCommand("SELECT Genero AS Generos, COUNT(IdPrestamo) AS numero FROM Prestamos GROUP BY Genero ORDER BY numero DESC", conexion);
            using SqlDataReader lector = query6.ExecuteReader();
            Console.WriteLine($"\n{"Genero", -12} | {"Prestamos", 12} \n---------------------------");
            while(lector.Read())
            {
                Console.WriteLine($"{lector.GetString(0), -12} | {lector.GetInt32(1), 12}");
            }
        }
    }
}
