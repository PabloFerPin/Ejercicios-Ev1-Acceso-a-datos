using ClubTenis.Datos;
using ClubTenis.Modelos;
using Microsoft.Data.SqlClient;

namespace ClubTenis.Repositorios;

// Todo el acceso a la base de datos va en esta clase
public class ReservaRepository
{
    public Reserva reservaMapper(SqlDataReader lector)
    {
        return new Reserva(
            lector.GetInt32(lector.GetOrdinal("IdPista")),
            lector.GetString(lector.GetOrdinal("NombreJugador")),
            lector.GetBoolean(lector.GetOrdinal("EsSocio")),
            lector.GetDateTime(lector.GetOrdinal("Fecha")),
            lector.GetInt32(lector.GetOrdinal("HoraInicio")),
            lector.GetInt32(lector.GetOrdinal("Horas"))
        );
    }

    public int Insertar(Reserva x)
    {
        string sql = "INSERT INTO Reservas (IsPista, NombreJugador, EsSocio, Fecha, HoraInicio, Horas, Importe) " +
            "OUTPUT INSERTED.Id" +
            "Values (@idP, @n, @s, @f, @hi, @h, @i)";

        using SqlConnection conexion = Conexion.Conectar();
        using SqlCommand comando = new SqlCommand(sql, conexion);
        comando.Parameters.AddWithValue("@idP", x.idPista);
        comando.Parameters.AddWithValue("@n", x.nombreJugador);
        comando.Parameters.AddWithValue("@s", x.esSocio);
        comando.Parameters.AddWithValue("@f", x.fecha);
        comando.Parameters.AddWithValue("@hi", x.horaInicio);
        comando.Parameters.AddWithValue("@h", x.horas);
        comando.Parameters.AddWithValue("@i", x.importe);

        return (int) comando.ExecuteScalar();
    }

    public List<Reserva> ObtenePorFecha(DateTime fecha)
    {
        List<Reserva> listaReservas = new List<Reserva>();
        string sql = "SELECT * FROM Reservas WHERE Fecha = @fecha";

        using SqlConnection conexion = Conexion.Conectar();
        using SqlCommand comando = new SqlCommand(sql, conexion);
        comando.Parameters.AddWithValue("@fecha", fecha);
        using SqlDataReader lector = comando.ExecuteReader();

        while (lector.Read())
        {
            listaReservas.Add(reservaMapper(lector));
        }

        return listaReservas;
    }

    public List<Reserva> leerCSV(string ruta)
    {
        List<Reserva> listaReservas = new List<Reserva>();
        using SqlConnection conexion = Conexion.Conectar();
        using SqlCommand comando = new SqlCommand("SELECT COUNT(IdReserva) FROM Reservas", conexion);
        int numRegistros = (int)comando.ExecuteScalar();
        if (numRegistros< 1)
        {
            using StreamReader sr = new StreamReader(ruta);
            sr.ReadLine();

            string? linea = sr.ReadLine();
            int numLinea = 0;
            while (linea != null)
            {
                string[] campos = linea.Split(';');

                try
                {
                    numLinea++;
                    bool esSocio = false;
                    if (campos[2] == "S")
                    {
                        esSocio = true;
                    }

                    if(int.Parse(campos[5]) > 5 || int.Parse(campos[5]) < 1)
                    {
                        throw new Exception();
                    }

                    listaReservas.Add(new Reserva(int.Parse(campos[0]), campos[1], esSocio, DateTime.Parse(campos[3]), 
                        int.Parse(campos[4]), int.Parse(campos[5])));
                } 
                catch (FormatException fe)
                {
                    Console.WriteLine("En la linea {numLinea} el registro tiene un numero mal escrito");
                }
                catch (Exception e)
                {
                    if(campos.Length < 6)
                    {
                        Console.WriteLine($"En la linea {numLinea} el registro tiene menos de 6 campos");
                    }

                    if (int.Parse(campos[5]) > 5 || int.Parse(campos[5]) < 1)
                    {
                        Console.WriteLine($"En la linea {numLinea} el registro no tiene un id de pista valido");
                    }
                }

                linea = sr.ReadLine();
            }

        } else
        {
            Console.WriteLine("La tabal no esta vacia!");
        }

        return listaReservas;
    }

    public void InsertarLote(List<Reserva> listaReservas)
    {
        using SqlConnection conexion = Conexion.Conectar();
        using SqlTransaction transaccion = conexion.BeginTransaction();
        int cargadas = 0;
        int rechazadas = 0;

        try
        {            
            string sql = "INSERT INTO Reservas (IsPista, NombreJugador, EsSocio, Fecha, HoraInicio, Horas, Importe) " +
            "Values (@idP, @n, @s, @f, @hi, @h, @i)";

            foreach(Reserva x in listaReservas)
            {
                using SqlCommand comando = new SqlCommand(sql, conexion, transaccion);
                comando.Parameters.AddWithValue("@idP", x.idPista);
                comando.Parameters.AddWithValue("@n", x.nombreJugador);
                comando.Parameters.AddWithValue("@s", x.esSocio);
                comando.Parameters.AddWithValue("@f", x.fecha);
                comando.Parameters.AddWithValue("@hi", x.horaInicio);
                comando.Parameters.AddWithValue("@h", x.horas);
                comando.Parameters.AddWithValue("@i", x.importe);

                comando.ExecuteNonQuery();
                cargadas++;
            }

            transaccion.Commit();
        } catch (Exception e)
        {
            transaccion.Rollback();
            rechazadas++;
        }

        
        Console.WriteLine($"Registros cargados: {cargadas}. Registros rechazados: {rechazadas}");
    }
}
