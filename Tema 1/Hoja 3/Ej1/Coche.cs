using System;

namespace Ej1
{
    internal class Coche : Vehiculo
    {
        private int puertas;

        public Coche(string cMarca, string cModelo, int cAnio, int cPuertas) : base(cMarca, cModelo, cAnio)
        {
            this.puertas = cPuertas;
        }

        public override void mostrarInfo()
        {
            base.mostrarInfo();
            Console.Write($"\nPuertas = {this.puertas}");
        }
    }
}
