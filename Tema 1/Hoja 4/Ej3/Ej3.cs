using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej3
{
    internal class Ej3
    {
        static void Main(string[] args)
        {
            List<Producto> listaObjProductos = new List<Producto>()
            {
                new Producto("Teclado", "Perifericos", 25.99m),
                new Producto("Monitor", "Pantallas", 149.00m),
                new Producto("Ratón", "Perifericos", 12.50m),
                new Producto("Portatil", "Ordenadores", 799.00m),
                new Producto("Webcam", "Perifericos", 39.90m),
                new Producto("Tablet", "Ordenadores", 229.00m),
            };

            Console.Write($"Productos de la lista ordenados de menor a mayor precio:\n");
            listaObjProductos.OrderBy(x => x.precio).ToList().ForEach(x => {
                Console.WriteLine(x.ToString());
            });

            Console.Write($"\nProductos mas caro de la lista: {listaObjProductos.OrderByDescending(x => x.precio).FirstOrDefault().ToString()} \n");

            Console.Write($"\nLista de productos ordenada por precio y por nombre\n");
            listaObjProductos.OrderBy(x => x.categoria).ThenBy(y => y.nombre).ToList().ForEach(z => {
                Console.Write($"{z.ToString()}\n");
            });

            Producto impresora = listaObjProductos.FirstOrDefault(x => x.categoria == "Impresora");
            if (impresora != null) { Console.WriteLine($"\nImpresora dsponible: {impresora.ToString()}"); } 
            else { Console.WriteLine("\nNo hay impresoras en el catálogo."); }
        }
    }
}
