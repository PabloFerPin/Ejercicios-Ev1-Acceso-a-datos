using System;

namespace Ej4
{
    internal class Ej4
    {
        static void Main(string[] args)
        {
            saludar("Pedro", "en");
            saludar("Pedro");
            saludar(idioma: "en", nombre: "Pedro");
        }

        static void saludar(string nombre, string idioma = "es")
        {
            if (idioma == "es")
            {
                Console.WriteLine($"Hola {nombre}!");
            } else
            {
                Console.WriteLine($"Hello {nombre}!");
            }
        }
    }
}
