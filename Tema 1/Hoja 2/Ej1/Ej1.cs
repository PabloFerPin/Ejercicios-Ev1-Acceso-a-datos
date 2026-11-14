using System;

namespace Ej1
{
    internal class Ej1
    {
        static void Main(string[] args)
        {
            int[] temperaturas = { 18, 21, 19, 23, 20 };
            int total = 0;
            int i = 0;

            Console.Write("Lista de temperaturas: ");
            foreach (int x in temperaturas)
            {
                Console.Write($"{x} ");
                total += x;
                i++;
            }
            Console.Write($"\nMedia: {(double) total / i}");
        }
    }
}
