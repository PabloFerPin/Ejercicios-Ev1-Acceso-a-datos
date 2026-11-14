using System;
using System.Collections.Generic;

namespace Ej3
{
    internal class Ej3
    {
        static void Main(string[] args)
        {
            List<IReproducible> reproductor = new List<IReproducible>()
            {
                new Cancion("Trellas", "Bad bunny"),
                new Cancion("Universitaria", "Quevedo"),
                new Podcast("The Wild Project", 259)
            };

            reproductor.ForEach(x => {
                x.reproducir();
            });

            Console.WriteLine();
            new Cancion("Kassandra", "Quevedo").descargar();
        }
    }
}