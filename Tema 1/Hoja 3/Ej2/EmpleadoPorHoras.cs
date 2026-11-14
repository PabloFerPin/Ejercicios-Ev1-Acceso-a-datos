using System;

namespace Ej2
{
    internal class EmpleadoPorHoras : Empleado
    {
        private int horas { get; set; }
        private decimal precioHora{ get; set; }

        public EmpleadoPorHoras(string cNombre, int cHoras, decimal cPrecioHora) : base(cNombre)
        {
            this.horas = cHoras;
            this.precioHora = cPrecioHora;
        }

        public override decimal calcularSueldo() => this.horas * this.precioHora;
    }
}
