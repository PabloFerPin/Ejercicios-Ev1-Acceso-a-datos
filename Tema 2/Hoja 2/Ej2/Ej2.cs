using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;

namespace Ej2
{
    internal class Ej2
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            JsonSerializerOptions opcionNoCompacta = new JsonSerializerOptions() { WriteIndented = true };
            JsonSerializerOptions opcionCompacta = new JsonSerializerOptions();

            string coches = File.ReadAllText("coches.json");
            List<Coche> listaCochesDeserializada = JsonSerializer.Deserialize<List<Coche>>(coches);

            if(listaCochesDeserializada == null)
            {
                Console.WriteLine("El arhivo json esta vacio");
            } else
            {
                Console.WriteLine($"Numero de coches leidos: {listaCochesDeserializada.Count}");
                Console.WriteLine($"El coche mas caro del catalogo es: {listaCochesDeserializada.OrderByDescending(x => x.Precio).First().ToString()}");
                Console.WriteLine($"Numero de coches de 2020 y posteriores: {listaCochesDeserializada.Where(x => x.Anio >= 2020).Count()}");
                Console.WriteLine($"Media de km de coches de 2020 y posteriores: {listaCochesDeserializada.Where(x => x.Anio >= 2020).Average(x => x.Kilometros):F0}");

                List<Coche> listaToyota = listaCochesDeserializada.Where(x => x.Marca == "Toyota").ToList();
                Console.WriteLine($"Numero de coches toyota: {listaToyota.Count}");

                string jsonCompacto = JsonSerializer.Serialize(listaToyota, opcionCompacta);
                string jsonNoCompacto = JsonSerializer.Serialize(listaToyota, opcionNoCompacta);
                File.WriteAllText("cochesToyotaCompacto.json", jsonCompacto);
                File.WriteAllText("cochesToyotaNoCompacto.json", jsonNoCompacto);

                Console.WriteLine($"cochesToyotaNoCompacto.json (con sangría): {new FileInfo("cochesToyotaNoCompacto.json").Length} bytes");
                Console.WriteLine($"cochesToyotaCompacto.json (campacto): {new FileInfo("cochesToyotaCompacto.json").Length} bytes");
                //Console.WriteLine($"El formato con sangría ocupa un {((double) new FileInfo("cochesToyotaCompacto.json").Length / new FileInfo("cochesToyotaNoCompacto.json").Length) * 100 :F0} % más");
                Console.WriteLine($"El formato con sangría ocupa un {(new FileInfo("cochesToyotaNoCompacto.json").Length - new FileInfo("cochesToyotaCompacto.json").Length) * 100.0 / new FileInfo("cochesToyotaCompacto.json").Length:F0} % más");

                string toyotasReleidosSting = File.ReadAllText("cochesToyotaNoCompacto.json");
                List<Coche> toyotasReleidos = JsonSerializer.Deserialize<List<Coche>>(toyotasReleidosSting);
                Console.WriteLine($"Releídos {toyotasReleidos.Count} coches de cochesToyotaNoCompacto.json: OK");
            }
        }
    }
}
