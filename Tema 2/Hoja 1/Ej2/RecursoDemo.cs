using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2
{
    internal class RecursoDemo : IDisposable
    {
        private string nombre;

        public RecursoDemo(string nombre)
        {
            this.nombre = nombre;
            Console.WriteLine($"Recurso {nombre} abierto");
        }

        public void usar()
        {
            Console.WriteLine($"Usando recurso {nombre}");
        }

        public void Dispose()
        {
            Console.WriteLine("Recurso cerrado");
        }
    }
}
