using System;
using System.Collections.Generic;

namespace Ej3
{
    internal class Ej3
    {
        static void Main(string[] args)
        {
            List<int> listaEdades = new List<int>() { 11, 24, 3};

            listaEdades.ForEach(x =>
            {
                Console.WriteLine($"Una persona con {x} años es mayor de edad?: {esMayorDeEdad(x)}");
            });
        }

        static bool esMayorDeEdad(int edad)
        {
            return edad > 17 ? true : false;
        }
    }
}
