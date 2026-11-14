using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Ej4
{
    internal class Ej4
    {
        static void Main(string[] args)
        {
            string carpeta = "Descargas";
            List<string> listaFicheros = new List<string>() { "apuntes.pdf", "foto1.jpg", "practica.zip", "foto2.jpg", "temp1.tmp", "examen.pdf", "temp2.tmp" };
            foreach (string nombre in listaFicheros)
            {
                File.WriteAllText(path: Path.Combine(carpeta, nombre), $"Contenido de {nombre}");
            }
            
            try
            {
                Console.WriteLine($"Ficheros en la carpeta: {contarFicheros(carpeta)}");

                for (int i = listaFicheros.Count - 1; i >= 0; i--)
                {
                    if(Path.GetExtension(listaFicheros[i]) == ".tmp")
                    {
                        Console.WriteLine($"Eliminado el archivo {Path.GetFileName(listaFicheros[i])}");
                        File.Delete(Path.Combine(carpeta, listaFicheros[i]));
                        listaFicheros.RemoveAt(i);
                    }                    
                }

                foreach (string x in listaFicheros)
                {
                    string nuevaRuta = Path.Combine(carpeta, Path.GetExtension(x).Replace(".", ""));
                    Directory.CreateDirectory(nuevaRuta);
                    try
                    {
                        File.Move(Path.Combine(carpeta, x), Path.Combine(nuevaRuta, x));
                        Console.WriteLine($"Moviendo {Path.GetFileName(x)} a la subcarpeta {Path.GetExtension(x).Replace(".", "")}");
                    } catch(Exception) {
                        for (int i = listaFicheros.Count - 1; i >= 0; i--)
                        {
                            File.Delete(Path.Combine(carpeta, listaFicheros[i]));
                        }
                    }
                }

                string carpetaPdf = Path.Combine(carpeta, "pdf");
                int numPdfs = 0;
                foreach(string x in Directory.EnumerateFiles(carpetaPdf))
                {
                    string carpetaCopia = "copia_pdf";
                    Directory.CreateDirectory(carpetaCopia);
                    File.Copy(x, Path.Combine(carpetaCopia, $"copia_{Path.GetFileName(x)}"), true);
                    numPdfs++;
                }
                Console.WriteLine($"Copia de seguridad: {numPdfs} ficheros en copia_pdf");

                int numFicherosSueltos = 0;
                foreach(string nombre in Directory.EnumerateFiles(carpeta)) { numFicherosSueltos++; }
                Console.WriteLine($"\nFicheros sueltos en descargas: {numFicherosSueltos}");

                foreach(string x in Directory.EnumerateDirectories(carpeta))
                {
                    numFicherosSueltos = 0;
                    foreach (string y in Directory.EnumerateFiles(x))
                    {
                        numFicherosSueltos++;
                    }

                    Console.WriteLine($"{x}: {numFicherosSueltos} ficheros");
                }

            } catch(Exception e)
            {
                Console.WriteLine($"Error: {e}");
            }
        }

        public static int contarFicheros(string carpeta)
        {
            int numFicheros = 0;
            foreach (string x in Directory.EnumerateFiles(carpeta)) { 
                numFicheros++; 
            }
            return numFicheros;
        }
    }
}
