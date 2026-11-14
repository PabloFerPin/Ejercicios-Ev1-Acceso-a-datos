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
            Console.Write("Año: ");
            int.TryParse(Console.ReadLine(), out int anio);
            Console.Write("Mes (1-12): ");
            int.TryParse(Console.ReadLine(), out int mes);
            Console.Write("Día: ");
            int.TryParse(Console.ReadLine(), out int dia);

            if (anio > 0 && (mes > 0 && mes <= 12))
            {
                bool esBisiesto = (anio % 4 == 0 && anio % 100 != 0) || anio % 400 == 0;

                string nombreMes = "";
                int diasMes = 0;
                string estacion = "";

                switch (mes)
                {
                    case 1:
                        nombreMes = "Enero";
                        break;
                    case 2:
                        nombreMes = "Febrero";
                        break;
                    case 3:
                        nombreMes = "Marzo";
                        break;
                    case 4:
                        nombreMes = "Abril";
                        break;
                    case 5:
                        nombreMes = "Mayo";
                        break;
                    case 6:
                        nombreMes = "Junio";
                        break;
                    case 7:
                        nombreMes = "Julio";
                        break;
                    case 8:
                        nombreMes = "Agosto";
                        break;
                    case 9:
                        nombreMes = "Septiembre";
                        break;
                    case 10:
                        nombreMes = "Octubre";
                        break;
                    case 11:
                        nombreMes = "Noviembre";
                        break;
                    case 12:
                        nombreMes = "Diciembre";
                        break;
                }

                switch (mes)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        diasMes = 31;
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        diasMes = 30;
                        break;
                    case 2:
                        diasMes = esBisiesto ? 29 : 28;
                        break;
                }

                switch (mes)
                {
                    case 12:
                    case 1:
                    case 2:
                        estacion = "Invierno";
                        break;
                    case 3:
                    case 4:
                    case 5:
                        estacion = "Primavera";
                        break;
                    case 6:
                    case 7:
                    case 8:
                        estacion = "Verano";
                        break;
                    case 9:
                    case 10:
                    case 11:
                        estacion = "Otoño";
                        break;
                }

                if (dia > 0 && dia <= diasMes)
                {
                    int diasRestantes = diasMes - dia;
                    Console.WriteLine($"Fecha válida: {dia} de {nombreMes} de {anio}");
                    Console.WriteLine($"Estación: {estacion}");
                    Console.WriteLine($"Días restantes para acabar el mes: {diasRestantes}");
                }
                else
                {
                    Console.WriteLine($"Día no válido. {nombreMes} de {anio} tiene {diasMes} días, y el día introducido fue {dia}.");
                }
            }
            else
            {
                Console.Write("Formato no valido");
            }
        }
    }
}
