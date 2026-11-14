using System;
using System.IO;

namespace Ej2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Apartado A");
            using (RecursoDemo bloque = new RecursoDemo("MiRecurso"))
            {
                bloque.usar();
            }
            Console.WriteLine("Fin del programa");

            try
            {
                using (RecursoDemo bloque = new RecursoDemo("MiRecurso"))
                {
                    bloque.usar();
                    throw new InvalidOperationException("Error aposta");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Se ha producido un error: {e.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Apartado B");

            try
            {
                if (!(File.Exists("diario.txt")))
                {
                    File.Create("diario.txt");
                }

                using (StreamWriter sw = new StreamWriter("diario.txt", append: true))
                {
                    sw.WriteLine("Me");
                    sw.WriteLine("gustan");
                    sw.WriteLine("las espinacas");
                }

                using (StreamReader sr = new StreamReader("diario.txt"))
                {
                    //string contenido = sr.ReadToEnd();
                    //Console.WriteLine(contenido);

                    string linea = "";
                    while (linea != null)
                    {
                        linea = sr.ReadLine();
                        Console.WriteLine(linea);
                    }
                }
            } catch(Exception e)
            {
                Console.WriteLine($"Error: {e}");
            }
        }
    }
}
