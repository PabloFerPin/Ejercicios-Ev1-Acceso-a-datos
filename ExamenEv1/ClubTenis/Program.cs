using System.Globalization;
using System.Text.Json;
using ClubTenis.Datos;
using ClubTenis.Modelos;
using ClubTenis.Repositorios;
using Microsoft.Data.SqlClient;

namespace ClubTenis;

public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;   // tildes y emojis

        // Antes de nada, comprobamos que hay conexión con ClubTenis
        try
        {
            using var prueba = Conexion.Conectar();
            Console.WriteLine($"✅ Conectado a {prueba.Database} en {prueba.DataSource}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"❌ {ex.Message}: {ex.InnerException?.Message}");
            Console.WriteLine("¿Has ejecutado ClubTenis.sql en SSMS?");
            return;
        }

        // Apartado C1: escribe aquí el menú
        bool continuar = true;
        ReservaRepository repo = new ReservaRepository();
        
        while (continuar)
        {
            Console.WriteLine("1. Cargar reservas desde el CSV");
            string? respuesta = Console.ReadLine();

            switch(respuesta)
            {
                case "1":
                    repo.InsertarLote(repo.leerCSV("reservas.csv"));
                    break;
            }
        }

    }

    // ---------- Funciones auxiliares de consola (se dan hechas: úsalas) ----------

    // Pide un número entero hasta que se escriba uno válido
    private static int LeerEntero(string mensaje)
    {
        int valor;
        Console.Write(mensaje);
        while (!int.TryParse(Console.ReadLine(), out valor))
            Console.Write("  Escribe un número entero: ");
        return valor;
    }

    // Pide un texto no vacío (sin espacios al principio ni al final)
    private static string LeerTexto(string mensaje)
    {
        string texto;
        do
        {
            Console.Write(mensaje);
            texto = (Console.ReadLine() ?? "").Trim();
        } while (texto == "");
        return texto;
    }

    // Pide una fecha en formato AAAA-MM-DD hasta que sea válida
    private static DateTime LeerFecha(string mensaje)
    {
        DateTime fecha;
        Console.Write(mensaje);
        while (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture,
                                       DateTimeStyles.None, out fecha))
            Console.Write("  Formato AAAA-MM-DD, por ejemplo 2026-11-20: ");
        return fecha;
    }
}
