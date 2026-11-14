using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> nombres = new List<string> { "ana", "luis", "marta", "pablo" };

            List<string> nombresMayuscula = nombres.Select(nombre => nombre.ToUpper()).ToList();
            List<int> numLetras = nombres.Select(nombre => nombre.Length).ToList();
            List<string> nombresConSaludo = nombres.Select(nombre => $"Hola, {nombre}").ToList();
            List<string> nombreMasDe4Letras = nombres.Where(nombre => nombre.Length > 4).Select(nombre => nombre.ToUpper()).ToList();

            Console.WriteLine($"Mayúsculas: {string.Join(", ", nombresMayuscula)}");
            Console.WriteLine($"Letras: {string.Join(", ", numLetras)}");
            Console.WriteLine($"{string.Join(" | ", nombresConSaludo)}");
            Console.WriteLine($"Alumnos con mas de 4 letras: {string.Join(", ", nombreMasDe4Letras)}");
        }
    }
}
