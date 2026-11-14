using System;

namespace Ej5
{
    internal class Ej5
    {
        private static readonly Random rnd = new Random();

        static void Main(string[] args)
        {
            const int MIN = 1;
            const int MAX = 100;
            const int MAX_INTENTOS = 7;            
            bool otraPartida = true;
            int partidaJugadas = 0;
            int partidaGanadas = 0;
            

            do
            {
                partidaJugadas++;
                int numIntentos = 1;
                bool continuar = true;
                int secreto = rnd.Next(MIN, MAX + 1);

                Console.WriteLine("Dame un numero y te digo si acertaste o te quedarte corto o largo");
                while (continuar && numIntentos <= MAX_INTENTOS)
                {
                    if (int.TryParse(Console.ReadLine(), out int numero))
                    {
                        if (numero >= MIN && numero <= MAX)
                        {
                            if (numero == secreto)
                            {
                                Console.WriteLine($"Has acertado el número!!\nIntentos: {numIntentos}");
                                continuar = false;
                                partidaGanadas++;
                            }
                            else if (numero > secreto)
                            {
                                Console.WriteLine("Demasiado alto");
                                numIntentos++;
                            }
                            else
                            {
                                Console.WriteLine("Demasiado bajo");
                                numIntentos++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error: Debe introducir un numero entre el 1 y el 100");

                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: Debe introducir un numero");
                    }
                }

                switch (numIntentos)
                {
                    case 1: Console.WriteLine("¡Increíble!"); break;
                    case 2:
                    case 3: Console.WriteLine("Excelente"); break;
                    case 4:
                    case 5: Console.WriteLine("Bien jugado"); break;
                    case 6:
                    case 7: Console.WriteLine("Justito"); break;
                    default: Console.WriteLine($"El numero secreto era: {secreto}"); break;
                }

                Console.WriteLine("Quieres jugar otra partida? Responde s o n");
                string respuesta = Console.ReadLine();
                if(respuesta.ToUpper() == "N" || respuesta.ToUpper() == "NO")
                {
                    otraPartida = false;
                }
            } while (otraPartida);

            Console.WriteLine($"Has juagdo {partidaJugadas} de las cuales has ganado {partidaGanadas}");
        }
    }
}
