using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1
{
    internal class Ej1
    {
        static void Main(string[] args)
        {
            const decimal IVA = 0.21m;
            const decimal envioGratis = 50;
            const decimal costeDeEnvio = 4.95m;

            Console.WriteLine("Introduce el nombre del producto");
            string nombreProducto = Console.ReadLine();
            Console.WriteLine("Introduce el precio del producto");
            decimal precioProducto = Decimal.Parse(Console.ReadLine());
            Console.WriteLine("Introduce las unidades del producto");
            int unidadesProducto = int.Parse(Console.ReadLine());

            if (nombreProducto == "")
            {
                nombreProducto = "Producto sin nombre";
            }

            if (precioProducto > 0 && unidadesProducto > 0)
            {
                Console.WriteLine("Tienes algun ticket de descuento?");
                string cupon = Console.ReadLine();

                int porcentajeDeDescuento = 0;
                switch (cupon.ToUpper())
                {
                    case "DAM10":
                        porcentajeDeDescuento = 10;
                        break;
                    case "DAM20":
                        porcentajeDeDescuento = 20;
                        break;
                    case "DAM30":
                        porcentajeDeDescuento = 30;
                        break;
                    case "DAM40":
                        porcentajeDeDescuento = 40;
                        break;
                    default:
                        porcentajeDeDescuento = 0;
                        break;
                }

                decimal subtotal = unidadesProducto * precioProducto;
                decimal ahorroCupon = subtotal * ((decimal)porcentajeDeDescuento / 100);
                decimal baseImponible = subtotal - subtotal * (porcentajeDeDescuento / 100);
                decimal totalIVA = baseImponible * IVA;
                decimal precioTotal = baseImponible + totalIVA;

                if (baseImponible < envioGratis) { precioTotal += costeDeEnvio; }

                Console.Write($"========== TICKET ========== \n{nombreProducto}: {unidadesProducto} unidades x {precioProducto}€ \n");
                Console.Write($"Subtotal: {subtotal}€ \nCupon {cupon}: -{ahorroCupon}€ ({porcentajeDeDescuento}%) \n");
                Console.Write($"Base imponible: {baseImponible}€ \nIVA (21%): {totalIVA}€ \n----------------------------\n");
                Console.Write($"Total a pagar: {precioTotal}€");
            }
            else
            {
                Console.WriteLine("Error, ni el precio ni las unidades pueden ser menores que 0");
            }
        }
    }
}
