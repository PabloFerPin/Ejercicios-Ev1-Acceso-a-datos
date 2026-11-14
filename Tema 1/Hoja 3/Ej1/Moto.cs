using System;

namespace Ej1
{
    internal class Moto : Vehiculo
    {
        private int cilindrada;

        public Moto(string cMarca, string cModelo, int cAnio, int cCilindrada) : base(cMarca, cModelo, cAnio)
        {
            this.cilindrada = cCilindrada;
        }

        public override void mostrarInfo()
        {
            base.mostrarInfo();
            Console.Write($"\nPuertas = {this.cilindrada}");
        }
    }
}
