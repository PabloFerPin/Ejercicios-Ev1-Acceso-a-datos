using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej3
{
    internal class Producto
    {
        public string nombre { get; set; }
        public string categoria { get; set; }
        public decimal precio { get; set; }

        public Producto(string cNombre, string cCategoria, decimal cPrecio)
        {
            this.nombre = cNombre;
            this.categoria = cCategoria;
            this.precio = cPrecio;
        }

        public override string ToString()
        {
            return $"Nombre: {nombre}, Categoría: {categoria}, Precio: {precio} euros";
        }
    }
}
