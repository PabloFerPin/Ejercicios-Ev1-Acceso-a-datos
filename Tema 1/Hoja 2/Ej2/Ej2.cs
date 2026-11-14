using System;
using System.Collections.Generic;

namespace Ej3
{
    internal class Ej2
    {
        static void Main(string[] args)
        {
            List<string> lista = new List<string>() { "Tarea 1", "Tarea 2", "Tarea 3" };
            int i = 1;

            foreach (string x in lista) { 
                Console.Write($"{i} = {x} \n");
                i++;
            }

            lista.Remove("Tarea 1");
            Console.Write($"\nQuedan {lista.Count} tareas pendientes");
        }
    }
}
