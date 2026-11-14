using System;
using System.Runtime.InteropServices;

namespace Ej2
{
    internal class EmpleadoFijo : Empleado
    {
        private decimal sueldoBase{ get; set; }
        private decimal complemento{ get; set; }

        public EmpleadoFijo(string cNombre, decimal cSueldoBase, decimal cComplemento) : base (cNombre)
        {
            this.sueldoBase = cSueldoBase;
            this.complemento = cComplemento;
        }

        public override decimal calcularSueldo() => this.sueldoBase + this.complemento;

        //var e = new Empleado("Prueba");
        //no hay hijos de una abstract y el var no va
    }
}