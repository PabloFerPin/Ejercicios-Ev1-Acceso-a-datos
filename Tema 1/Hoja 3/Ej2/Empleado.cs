using System;

namespace Ej2
{
    internal abstract class Empleado
    {
        private string nombre { get; set; }
        
        public Empleado(string cNombre) => this.nombre = cNombre;

        public abstract decimal calcularSueldo();

        public void mostrarNomina() => Console.Write($"{this.nombre}: {calcularSueldo():F2}€");
    }
}
