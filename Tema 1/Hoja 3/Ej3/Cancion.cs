using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej3
{
    internal class Cancion : IReproducible, IDescargable
    {
        public string titulo {  get; }
        private string artista {  get; set; }

        public Cancion(string cTitulo, string cArtista)
        {
            this.titulo = cTitulo;
            this.artista = cArtista;
        }

        public void reproducir() {
            Console.WriteLine($"Reproduciendo canción: {this.titulo} - {this.artista}");
        }

        public void descargar()
        {
            Console.Write($"Descargando canción: {this.titulo}");
        }

    }
}
