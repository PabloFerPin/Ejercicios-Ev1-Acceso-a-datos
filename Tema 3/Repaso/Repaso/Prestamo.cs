using System;
using System.Collections.Generic;
using System.Text;

namespace Repaso
{
    internal class Prestamo
    {
        public int IdPrestamo { get; set; }
        public string CodigoSocio { get; set; }
        public string NombreSocio { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucionPrevista { get; set; }
        public DateTime? FechaDevolucionReal { get; set; }

        public Prestamo() { }

        public Prestamo(int idPrestamo, string codigoSocio, string nombreSocio, string isbn,
                        string titulo, string autor, string genero, DateTime fechaPrestamo,
                        DateTime fechaDevolucionPrevista, DateTime? fechaDevolucionReal = null)
        {
            IdPrestamo = idPrestamo;
            CodigoSocio = codigoSocio;
            NombreSocio = nombreSocio;
            ISBN = isbn;
            Titulo = titulo;
            Autor = autor;
            Genero = genero;
            FechaPrestamo = fechaPrestamo;
            FechaDevolucionPrevista = fechaDevolucionPrevista;
            FechaDevolucionReal = fechaDevolucionReal;
        }
    }
}
