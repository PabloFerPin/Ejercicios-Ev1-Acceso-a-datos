using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej3
{
    internal class Podcast : IReproducible
    {
        public string titulo { get; }
        private int episodio {  get; set; }
        public Podcast(string cTitulo, int cEpisodio)
        {
            this.titulo = cTitulo;
            this.episodio = cEpisodio;
        }

        public void reproducir()
        {
            Console.Write($"Reproduciendo pódcast: {this.titulo} (episodio {this.episodio})");
        }
    }
}
