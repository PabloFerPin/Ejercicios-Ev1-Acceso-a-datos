using System.Xml.Serialization;
using System.Text.Json;

namespace Infografia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            try
            {
                //XML
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Coche>));
                List<Coche> listaCochesDeserializadaXML = new List<Coche>();
                using StreamReader sr = new StreamReader("coches.xml");
                listaCochesDeserializadaXML = (List<Coche>)xmlSerializer.Deserialize(sr);

                //JSON
                string cochesJSON = File.ReadAllText("coches.json");
                List<Coche> listaCochesDeserializadaJSON = JsonSerializer.Deserialize<List<Coche>>(cochesJSON);

                //CSV
                List<Coche> listaCochesDeserializadaCSV = new List<Coche>();
                using StreamReader sr2 = new StreamReader("coches.csv");
                string cabeceraCSV = sr2.ReadLine();
                string linea = sr2.ReadLine();
                while (linea != null)
                {
                    string[] campos = linea.Split(';');
                    listaCochesDeserializadaCSV.Add(new Coche(int.Parse(campos[0]), campos[1], campos[2], int.Parse(campos[3]), campos[4], campos[5], int.Parse(campos[6]), int.Parse(campos[7])));
                    linea = sr2.ReadLine();
                }

                if(!Directory.Exists("salida"))
                {
                    Directory.CreateDirectory("salida");
                }

                //CSV
                using (StreamWriter sw = new StreamWriter(Path.Combine("salida", "coches.csv")))
                {
                    sw.WriteLine(cabeceraCSV);
                    foreach (Coche x in listaCochesDeserializadaCSV)
                    {
                        sw.WriteLine($"{x.Id};{x.Marca};{x.Modelo};{x.Anio};{x.Combustible};{x.Color};{x.Kilometros};{x.Precio}");
                    }
                }

                //JSON
                JsonSerializerOptions opciones = new JsonSerializerOptions { WriteIndented = true };
                File.WriteAllText(Path.Combine("salida", "coches.json"), JsonSerializer.Serialize(listaCochesDeserializadaCSV, opciones));

                //XML
                using (StreamWriter swXml = new StreamWriter(Path.Combine("salida", "coches.xml")))
                {
                    xmlSerializer.Serialize(swXml, listaCochesDeserializadaCSV);
                }

                //Tamaños
                string[] ficheros = { "coches.csv", "coches.json", "coches.xml" };

                Console.WriteLine();
                Console.WriteLine($"{"Fichero",-15}{"Bytes",12}{"MB",14} \n-----------------------------------------");

                foreach (string x in ficheros)
                {
                    FileInfo info = new FileInfo(Path.Combine("salida", x));
                    long bytes = info.Length;
                    double mb = bytes / (1024.0 * 1024.0);
                    Console.WriteLine($"{x,-15}{bytes,12:N0}{mb,14:F6}");
                }

                //Volver a leer CSV
                List<Coche> cochesCSV = new List<Coche>();
                using (StreamReader srCsvSalida = new StreamReader(Path.Combine("salida", "coches.csv")))
                {
                    srCsvSalida.ReadLine();
                    string lineaSalida = srCsvSalida.ReadLine();
                    while (lineaSalida != null)
                    {
                        string[] campos = lineaSalida.Split(';');
                        cochesCSV.Add(new Coche(int.Parse(campos[0]), campos[1], campos[2], int.Parse(campos[3]), campos[4], campos[5], int.Parse(campos[6]), int.Parse(campos[7])));
                        lineaSalida = srCsvSalida.ReadLine();
                    }
                }

                //Volver a leer JSON
                List<Coche> cochesJSONSalida = JsonSerializer.Deserialize<List<Coche>>(File.ReadAllText(Path.Combine("salida", "coches.json")));

                //Volver a leer XML
                List<Coche> cochesXML;
                using (StreamReader srXmlSalida = new StreamReader(Path.Combine("salida", "coches.xml")))
                {
                    cochesXML = (List<Coche>)xmlSerializer.Deserialize(srXmlSalida);
                }

                //Comprobación
                string[] nombres = { "coches.csv", "coches.json", "coches.xml" };
                List<Coche>[] listas = { cochesCSV, cochesJSONSalida, cochesXML };

                Console.WriteLine();
                Console.WriteLine($"{"Fichero",-15}{"Coches",10}{"Sospechosos",14} \n---------------------------------------");

                for (int i = 0; i < listas.Length; i++)
                {
                    int sospechosos = 0;
                    foreach (Coche c in listas[i])
                    {
                        if (
                                 c.Marca == null || c.Marca == ""
                                || c.Modelo == null || c.Modelo == ""
                                || c.Combustible == null || c.Combustible == ""
                                || c.Color == null || c.Color == ""
                                || c.Id == 0 || c.Anio == 0 || c.Kilometros == 0 || c.Precio == 0
                            )
                        {
                            sospechosos++;
                        }
                    }
                    Console.WriteLine($"{nombres[i],-15}{listas[i].Count,10:N0}{sospechosos,14:N0}");
                }
            } catch(Exception e)
            {
                Console.WriteLine(e);
            }

            if (!Directory.Exists("pruebas"))
            {
                Directory.CreateDirectory("pruebas");
            }

            Console.Write("\nPruebas\n");

            string[] ficherosPrueba = Directory.GetFiles("pruebas");
            foreach (string rutaPrueba in ficherosPrueba)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Coche>));

                string nombrePrueba = Path.GetFileName(rutaPrueba);
                try
                {
                    string extension = Path.GetExtension(rutaPrueba).ToLower();
                    List<Coche> cochesPrueba = new List<Coche>();

                    if (extension == ".csv")
                    {
                        using (StreamReader srPrueba = new StreamReader(rutaPrueba))
                        {
                            srPrueba.ReadLine();
                            string lineaPrueba = srPrueba.ReadLine();
                            while (lineaPrueba != null)
                            {
                                string[] campos = lineaPrueba.Split(';');
                                cochesPrueba.Add(new Coche(int.Parse(campos[0]), campos[1], campos[2], int.Parse(campos[3]), campos[4], campos[5], int.Parse(campos[6]), int.Parse(campos[7])));
                                lineaPrueba = srPrueba.ReadLine();
                            }
                        }
                    }
                    else if (extension == ".json")
                    {
                        cochesPrueba = JsonSerializer.Deserialize<List<Coche>>(File.ReadAllText(rutaPrueba));
                    }
                    else if (extension == ".xml")
                    {
                        using (StreamReader srPrueba = new StreamReader(rutaPrueba))
                        {
                            cochesPrueba = (List<Coche>)xmlSerializer.Deserialize(srPrueba);
                        }
                    }
                    

                    int sospechososPrueba = 0;
                    foreach (Coche c in cochesPrueba)
                    {
                        if (c.Marca == null || c.Marca == ""
                            || c.Modelo == null || c.Modelo == ""
                            || c.Combustible == null || c.Combustible == ""
                            || c.Color == null || c.Color == ""
                            || c.Id == 0 || c.Anio == 0 || c.Kilometros == 0 || c.Precio == 0)
                        {
                            sospechososPrueba++;
                        }
                    }
                    Console.WriteLine($"{nombrePrueba,-35} OK    {cochesPrueba.Count,8:N0} coches, {sospechososPrueba} sospechosos");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{nombrePrueba,-35} ERROR {ex.GetType().Name}: {ex.Message}");
                }
            }
        }
    }
}
