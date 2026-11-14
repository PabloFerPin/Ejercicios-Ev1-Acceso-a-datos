using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numeros = new List<int> { 12, 7, 25, 3, 18, 40, 9, 16 };

            List<int> pares = numeros.Where(num => num % 2 == 0).ToList();
            List<int> mayoresDiez = numeros.Where(num => num > 10).ToList();
            List<int> intervalo10y20 = numeros.Where(num => num >= 10 && num <= 20).ToList();
            int numImpares = numeros.Where(num => num % 2 != 0).Count();

            Console.WriteLine($"Pares: {string.Join(", ", pares)} \nMayores que 10: {string.Join(", ", mayoresDiez)} \nEntre 10 y 20: {string.Join(", ", intervalo10y20)} \nNumero de impares: {numImpares}");
        }
    }
}
