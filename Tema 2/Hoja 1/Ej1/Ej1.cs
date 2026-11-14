using System;
using System.IO;

namespace Ej1
{
    internal class Ej1
    {
        static void Main(string[] args)
        {
            string ruta = Path.Combine("datos", "2Dam", "alumnos.csv");
            Console.WriteLine($"Ruta completa: {ruta}");
            Console.WriteLine("Nombre: " + Path.GetFileName(ruta));
            Console.WriteLine("Nombre sin extensión: " + Path.GetFileNameWithoutExtension(ruta));
            Console.WriteLine("Extensión: " + Path.GetExtension(ruta));
            Console.WriteLine("Directorio: " + Path.GetDirectoryName(ruta));
            ruta = Path.ChangeExtension(ruta, "json");
            Console.WriteLine("Como JSON: " + ruta);

            Console.WriteLine("---------------------------");
            Console.WriteLine("Directorio actual: " + Directory.GetCurrentDirectory());
            Console.WriteLine("Ruta absoluta: " + Path.GetFullPath(ruta));

            Console.WriteLine("---------------------------");
            string[] rutas = { "foto.PNG", "notas.txt", "logo.gif", "informe.pdf", "playa.Jpg", "LEEME" };
            foreach (string r in rutas)
            {
                Console.Write(r);
                if (Path.GetExtension(r) == ".PNG" || Path.GetExtension(r) == ".Jpg" || Path.GetExtension(r) == ".gif")
                {
                    Console.Write(" --> es una imagen");
                }
                Console.WriteLine();
            }
        }
    }
}
