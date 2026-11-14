using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej4
{
    internal class Ej4
    {
        static void Main(string[] args)
        {
            List<Alumno> listaObjAlumnos = new List<Alumno>()
            {
                new Alumno("Ana", 8.5),
                new Alumno("Luis", 4),
                new Alumno("Marta", 6.5),
                new Alumno("Pablo", 3.5),
                new Alumno("Lucía", 9),
                new Alumno("Jorge", 5),
                new Alumno("Sara", 7)
            };

            Console.WriteLine($"Numero de alumnos aprobados: {listaObjAlumnos.Where(x => x.nota >= 5).Count()}");
            Console.WriteLine($"Nota media de la clase: {listaObjAlumnos.Average(x => x.nota):F2}");
            Console.WriteLine($"Nota mas alta de la clase: {listaObjAlumnos.Max(x => x.nota)}");
            Console.WriteLine($"Nota mas baja de la clase: {listaObjAlumnos.Min(x => x.nota)}");
            Console.WriteLine($"Hay algun diez?: {listaObjAlumnos.Any(x => x.nota == 10)}");
            Console.WriteLine($"Han sacado todos los alumnos mas de un 3?: {listaObjAlumnos.All(x => x.nota >= 3)}");

            Console.Write("Ranking de aprobados: ");
            foreach (string x in listaObjAlumnos.Where(x => x.nota >= 5).OrderByDescending(y => y.nota).Select(z => $"{z.nombre} ({z.nota})").ToList())
            {
                Console.Write(x + " | ");
            }

            Console.Write("\nSuspensos: ");
            foreach (string x in listaObjAlumnos.Where(x => x.nota < 5).OrderByDescending(y => y.nota).Select(z => $"{z.nombre}").ToList())
            {
                Console.Write(x + ", ");
            }
        }
    }
}