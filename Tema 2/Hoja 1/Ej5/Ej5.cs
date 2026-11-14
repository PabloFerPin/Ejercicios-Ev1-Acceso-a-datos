using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej5
{
    internal class Ej5
    {
        static void Main(string[] args)
        {
            string raiz = "instituto";
            if (Directory.Exists(raiz))
            {
                Directory.Delete(raiz, recursive: true);
            }

            Dictionary<string, int> ficheros = new Dictionary<string, int>
            {
                { Path.Combine("1DAM", "programacion.txt"),        120 },
                { Path.Combine("1DAM", "bases_datos.txt"),          80 },
                { Path.Combine("1DAM", "horario.pdf"),             300 },
                { Path.Combine("2DAM", "acceso_datos.txt"),        150 },
                { Path.Combine("2DAM", "proyectos", "tfc.pdf"),    900 },
                { Path.Combine("2DAM", "proyectos", "notas.csv"),   60 },
                { "normas.pdf",                                    200 }
            };

            foreach (KeyValuePair<string, int> x in ficheros)
            {
                string ruta = Path.Combine(raiz, x.Key);
                Directory.CreateDirectory(Path.GetDirectoryName(ruta));   
                File.WriteAllText(ruta, new string('x', x.Value));       
            }

            foreach(string x in Directory.EnumerateDirectories(raiz, "*", SearchOption.AllDirectories))
            {
                Console.WriteLine(x);
            }

            int numFicheros = 0;
            int bytesTotales = 0;
            string nombreMayor = "";
            int tamanioMayor = 0;
            foreach (string x in Directory.EnumerateDirectories(Directory.GetCurrentDirectory(), "*", SearchOption.AllDirectories))
            {
                foreach(string y in Directory.EnumerateFiles(x))
                {
                    int tamanio = (int) new FileInfo(y).Length;
                    bytesTotales += (int) tamanio;
                    Console.WriteLine($"{Path.GetFullPath(y)} ({tamanio} bytes)");
                    numFicheros++;

                    if(tamanio >= tamanioMayor)
                    {
                        tamanioMayor = tamanio;
                        nombreMayor = Path.GetFileName(y);
                    }
                }
            }

            Console.WriteLine($"Total: {numFicheros} ficheros, {bytesTotales} bytes");
            Console.WriteLine($"Fichero mas grande: {nombreMayor} ({tamanioMayor} bytes)");

            int numPdfs = 0;
            foreach (string x in Directory.EnumerateDirectories(Directory.GetCurrentDirectory(), "*", SearchOption.AllDirectories))
            {
                foreach (string y in Directory.EnumerateFiles(x, "*.pdf"))
                {
                    numPdfs++;
                }
            }
            Console.WriteLine($"Ficheros pdfs: {numPdfs}");
        }
    }
}
