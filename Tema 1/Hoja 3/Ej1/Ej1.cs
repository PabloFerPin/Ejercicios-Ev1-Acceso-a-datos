using System;
using System.Runtime.CompilerServices;

namespace Ej1
{
    internal class Ej1
    {
        public static void Main(String[] args)
        {
            Coche objC = new Coche("Subaru", "BRZ", 2015, 3);
            Moto objM = new Moto("Kawashaki", "20", 2015, 300);

            Console.WriteLine("--- Coche ---");
            objC.mostrarInfo();
            Console.WriteLine("\n--- Moto ---");
            objM.mostrarInfo();
        }
    }
}