using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ej3
{
    internal class Ej3
    {
        static void Main(string[] args)
        {
            string carpeta = "ProyectoDAM";
            string[] subcarpetas = { "docs", "src", "tests" };

            try
            {
                if (!Directory.Exists(carpeta))
                {
                    Directory.CreateDirectory(carpeta);
                }

                foreach (string x in subcarpetas)
                {
                    string ruta = Path.Combine(carpeta, x);
                    if (!Directory.Exists(ruta))
                    {
                        Directory.CreateDirectory(ruta);
                        Console.WriteLine($"Creado: {ruta}");
                    }
                    else
                    {
                        Console.WriteLine($"La carpeta {ruta} ya existia");
                    }

                    string rutaArchivo = Path.Combine(ruta, "readme.md");
                    if (!File.Exists(rutaArchivo))
                    {
                        File.WriteAllText(rutaArchivo, $"Carpeta {x} del ProyectoDAM");
                    }

                    FileInfo fi = new FileInfo(rutaArchivo);
                    Console.WriteLine($"{fi.Name} ({x}) - {fi.Length} bytes - creado el {fi.CreationTime: dd/MM/yyyy HH:mm}");
                }
            } catch(Exception e)
            {
                Console.WriteLine($"Error: {e}");
            }
        }
    }
}
