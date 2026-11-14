using Microsoft.Data.SqlClient;
using System.Globalization;

namespace Repaso
{
    internal class Insertar
    {
        //static void Main(string[] args)
        //{
        //    List<Prestamo> listaPrestamos = csvDeserializaer("prestamos_biblioteca.txt");
        //    using SqlConnection conexion = conectar();
        //    int filas = 0;

        //    foreach (Prestamo x in listaPrestamos) {
        //        using SqlCommand insertar = new SqlCommand("INSERT INTO Prestamos (IdPrestamo, CodigoSocio, NonmbreSocio, ISBN, Titulo, Autor, Genero, FechaPrestamo, FechaDevolucionReal, FechaDevolucionPrevista) " +
        //            "VALUES (@id, @codigo, @nombre, @isbn, @titulo, @autor, @genero, @fechaP, @fechaR, @fechaDP)", conexion);

        //        insertar.Parameters.AddWithValue("@id", x.IdPrestamo);
        //        insertar.Parameters.AddWithValue("@codigo", x.CodigoSocio);
        //        insertar.Parameters.AddWithValue("@nombre", x.NombreSocio);
        //        insertar.Parameters.AddWithValue("@isbn", x.ISBN);
        //        insertar.Parameters.AddWithValue("@titulo", x.Titulo);
        //        insertar.Parameters.AddWithValue("@autor", x.Autor);
        //        insertar.Parameters.AddWithValue("@genero", x.Genero);
        //        insertar.Parameters.AddWithValue("@fechaP", x.FechaPrestamo);
        //        insertar.Parameters.AddWithValue("@fechaDP", x.FechaDevolucionPrevista);
        //        insertar.Parameters.AddWithValue("@fechaR", (object?)x.FechaDevolucionReal ?? DBNull.Value);

        //        insertar.ExecuteNonQuery();

        //        filas++;
        //    }

        //    Console.WriteLine($"Filas insertadas: {filas}");
        //}

        public static SqlConnection conectar() {
            string cadenaConexion = "Server=(localdb)\\MSSQLLocalDB;Initial Catalog=Biblioteca;Integrated Security=true";

            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                return conexion;
            } catch(SqlException e)
            {
                throw new InvalidOperationException("Error al conectar", e);
            }
        }

        public static List<Prestamo> csvDeserializaer(string rutaCsv)
        {
            List<Prestamo> listaPrestamos = new List<Prestamo>();

            try {
                using StreamReader sr = new StreamReader(rutaCsv);
                
                sr.ReadLine();
                string? linea = sr.ReadLine();
                while(linea != null)
                {
                    string[] campos = linea.Split(';');
                    DateTime fechaPrestamo = DateTime.ParseExact(campos[7], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    DateTime fechaDevolucionPrevista = DateTime.ParseExact(campos[8], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    DateTime? FechaDevolucionReal = null;
                    if (!(string.IsNullOrWhiteSpace(campos[9])))
                    {
                        FechaDevolucionReal = DateTime.ParseExact(campos[9], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    }

                    listaPrestamos.Add(new Prestamo(int.Parse(campos[0]), campos[1], campos[2], campos[3], campos[4], campos[5], campos[6], fechaPrestamo, fechaDevolucionPrevista, FechaDevolucionReal));

                    linea = sr.ReadLine();
                }
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            return listaPrestamos;
        }
    }
}
