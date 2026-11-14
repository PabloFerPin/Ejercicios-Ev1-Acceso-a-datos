using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
//C:\Users\pablo\Documents\Dam\2DAM\Acceso a datos\Tema 2\Hoja 2\Ej2\bin\Debug
namespace Ej3
{
    internal class Ej3
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Coche>));

            List<Coche> listaCochesDeserializada = new List<Coche>();
            using (StreamReader sr = new StreamReader("coches.xml"))
            {
                listaCochesDeserializada = (List<Coche>)xmlSerializer.Deserialize(sr);
            }

            if (listaCochesDeserializada == null)
            {
                Console.WriteLine("El arhivo xml esta vacio");
            }
            else
            {
                Console.WriteLine($"Numero de coches leidos: {listaCochesDeserializada.Count}\n");

                List<Coche> listaChollos = listaCochesDeserializada.Where(x => x.Anio > 2017 && x.Kilometros < 60000 && x.Precio < 15000).OrderBy(y => y.Precio).ToList();
                Console.WriteLine($"Numero de chollos encontrados: {listaChollos.Count()}\n");
                Console.WriteLine("--- Los 5 más baratos ---");
                listaChollos.Take(5).ToList().ForEach(x => { Console.WriteLine(x); });

                using (StreamWriter sw = new StreamWriter("chollos.xml"))
                {
                    xmlSerializer.Serialize(sw, listaChollos);
                    Console.WriteLine($"\nGuardados {listaChollos.Count} chollos en chollos.xml");
                }

                List<Coche> listaChollosReleida = new List<Coche>();
                using (StreamReader sr = new StreamReader("chollos.xml"))
                {
                    listaChollosReleida = (List<Coche>)xmlSerializer.Deserialize(sr);
                }
                Console.WriteLine($"Releídos {listaChollosReleida.Count}. Primero: {listaChollosReleida.First()}");
            }
        }
    }
}
