using System;
using System.Collections.Generic;

namespace Ej3
{
    internal class Ej2
    {
        static void Main(string[] args)
        {
            //Apartado A
            Console.WriteLine("De que altura quieres la piramide de *?");
            int counter = 1;

            if (int.TryParse(Console.ReadLine(), out int altura))
            {
                if(altura > 0)
                {
                    for (int i = 1; i <= altura; i++)
                    {
                        for (int j = 0; j < (altura - i); j++)
                        {
                            Console.Write(" ");
                        }

                        for (int j = 0; j < counter; j++)
                        {
                            Console.Write("*");
                        }
                        counter += 2;
                        Console.WriteLine();
                    }
                } else
                {
                    Console.WriteLine("Numeros negativos no permitidos");
                }
            }
            else
            {
                Console.WriteLine("Formato de numero no valido");
            }
            Console.WriteLine();

            //Apartado B
            Console.WriteLine("Dame un numero entero positivo");
            if (int.TryParse(Console.ReadLine(), out int entero))
            {
                if(entero > 0)
                {
                    List<int> listaDigitos = new List<int>();
                    int sumaDigitos = 0;
                    int numDigitos = 0;

                    while (entero >= 10)
                    {
                        sumaDigitos += entero % 10;
                        listaDigitos.Add(entero % 10);
                        numDigitos++;
                        entero /= 10;
                    }

                    listaDigitos.Add(entero);
                    sumaDigitos += entero % 10;
                    numDigitos++;

                    Console.Write($"La suma de los digitos del numero es: {sumaDigitos} \nEl numero de digitos del numero es: {numDigitos} \nEl numero invertido es: {concatenacionListInt(listaDigitos)} \nEl numero {esCapicua(listaDigitos)} es capicua");
                } else
                {
                    Console.WriteLine("Numeros negativos no admitidos");
                }
            }
            else
            {
                Console.WriteLine("No estas introduciendo un numero");
            }
            Console.WriteLine();

            //Apartado C
            Console.WriteLine("Imprimiendo los numeros del 1 al 30");
            for(int i = 1; i <= 30; i++)
            {
                if(i % 3 == 0 && i % 5 == 0)
                {
                    Console.Write(" FizzBuzz ");
                }
                else if (i % 3 == 0)
                {
                    Console.Write(" Fizz ");
                }
                else if(i % 5 == 0)
                {
                    Console.Write(" Buzz ");
                }
                else if(i == 1)
                {
                    Console.Write($"{i} ");
                }
                else 
                {
                    Console.Write($" {i} ");
                }
            }
        }

        public static string concatenacionListInt(List<int> listaNumeros)
        {
            string stringConcatenada = "";

            foreach (int x in listaNumeros)
            {
                stringConcatenada += x;
            }

            return stringConcatenada;
        }

        public static string esCapicua(List<int> listaNumeros)
        {
            int i = 0;
            int j = listaNumeros.Count - 1;
            bool continuar = true;

            while (continuar && i < j)
            {
                if (listaNumeros[i] != listaNumeros[j])
                {
                    continuar = false;
                }
                else
                {
                    i++;
                    j--;
                }
            }

            if (i >= j)
            {
                return "si";
            }
            else
            {
                return "no";
            }
        }
    }
}
