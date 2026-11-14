using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej4
{
    internal class Alumno
    {
        public string nombre { get; set; }
        public double nota { get; set; }

        public Alumno()
        {

        }

        public Alumno(string cNombre, double cNota)
        {
            this.nombre = cNombre;
            this.nota = cNota;
        }

        public override string ToString()
        {
            return $"Nombre: {nombre ?? string.Empty}, Nota: {nota:F2}";
        }
    }
}
