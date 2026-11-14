using System;

namespace Ej4
{
    internal class Ej4
    {
        static void Main(string[] args)
        {
            decimal saldo = 1000m;
            const decimal LIMITE_RETIRADA = 300m;
            string[] menuBanco = { "1) Consultar saldo", "2) Ingresar dinero", "3) Retirar dinero", "4) Salir" };
            bool continuar = true;
            int operacionesExitosas = 0;

            do { 
                foreach(string x in menuBanco) Console.WriteLine(x);
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    
                    case "1":
                        Console.WriteLine($"Su saldo es de: {saldo} euros");
                        break;
                    case "2":
                        Console.WriteLine("Intruce la cantidad que quiere ingresar.");
                        if (decimal.TryParse(Console.ReadLine(), out decimal ingreso))
                        {
                            if (ingreso > 0)
                            {
                                saldo += ingreso;
                                operacionesExitosas++;
                            }
                            else { Console.WriteLine("No puede ingresar 0 euros o dinero negativo"); }
                        }
                        else { Console.WriteLine("Introduce un numero valido"); }
                        break;
                    case "3":
                        Console.WriteLine("Introduce la cantidad que quiere retirar. No puede retirar mas de 300 euros por operacion");
                        if (decimal.TryParse(Console.ReadLine(), out decimal retirada))
                        {
                            if (retirada > 0 && retirada < LIMITE_RETIRADA)
                            {
                                saldo -= retirada;
                                operacionesExitosas++;
                            }
                            else { Console.WriteLine("No puede retirar 0 euros, dinero negativo, o mas de 300 euros"); }
                        }
                        else { Console.WriteLine("Introduce un numero valido"); }
                        break;
                    case "4":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opcion no valida, intentalo enuevo");
                        break;
                }
            } while (continuar);
        }
    }
}
