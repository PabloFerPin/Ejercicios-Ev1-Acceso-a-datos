using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1
{
    internal class Ej1
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            foreach (Coche x in leerCSV("coches.csv"))
            {
                Console.WriteLine(x.ToString());
            }
        }

        static List<Coche> leerCSV(string ruta)
        {
            List<Coche> listaCoches = new List<Coche>();

            try
            {
                using (StreamReader sr = new StreamReader(ruta))
                {
                    sr.ReadLine();

                    string linea = sr.ReadLine();
                    while(linea != null)
                    {
                        string[] campos = linea.Split(';');
                        listaCoches.Add(new Coche(int.Parse(campos[0]), campos[1], campos[2], int.Parse(campos[3]), campos[4], campos[5], int.Parse(campos[6]), int.Parse(campos[7])));
                        linea = sr.ReadLine();
                    }
                }
            } catch(Exception e)
            {
                Console.WriteLine(e);
            }

            return listaCoches;
        }
    }
}
