using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2
{
    internal class Ej2
    {
        static void Main(string[] args)
        {
            List<Empleado> listaEmpleados = new List<Empleado>();
            listaEmpleados.Add(new EmpleadoFijo("Jose Luis", 1200, 400));
            listaEmpleados.Add(new EmpleadoFijo("Juan Carlos", 1700, 1000));
            listaEmpleados.Add(new EmpleadoPorHoras("Jose Maria", 30, 8));
            listaEmpleados.Add(new EmpleadoPorHoras("Jose Antonio", 60, 6));

            decimal total = 0;

            Console.Write("=== NÓMINAS DEL MES ===\n");
            foreach (Empleado objEmpleado in listaEmpleados)
            {
                total += objEmpleado.calcularSueldo();
                objEmpleado.mostrarNomina();
                Console.WriteLine();
            }

            Console.Write($"----------------------- \nTotal nóminas: {total}€");
        }
    }
}
