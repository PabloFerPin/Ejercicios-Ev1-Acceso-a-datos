using System;

namespace Ej1
{
    internal class Vehiculo
    {
        private string marca { get; set; }
        private string modelo { get; set; }
        private int anio { get; set; }

        public Vehiculo(string cMarca, string cModelo, int cAnio)
        {
            this.marca = cMarca;
            this.modelo = cModelo;
            this.anio = cAnio;
        }

        public virtual void mostrarInfo()
        {
            Console.Write($"Marca = {this.marca} \nModelo = {this.modelo} \nAño = {this.anio}");
        }
    }
}
