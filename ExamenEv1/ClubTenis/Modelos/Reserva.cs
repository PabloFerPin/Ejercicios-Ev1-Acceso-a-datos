namespace ClubTenis.Modelos;

// Apartado B1: escribe aquí la clase Reserva
public class Reserva
{
    public int idReserva { set; get; }
    public int idPista { set; get; }
    public string nombreJugador { set; get; }
    public bool esSocio { set; get; }
    public DateTime fecha { set; get; }
    public int horaInicio { set; get; }
    public int horas { set; get; }
    public decimal importe { set; get; }
    public string estado { set; get; }

    public Reserva()
    {

    }

    public Reserva(int cIdPista, string cNombreJugador, bool cEsSocio, DateTime cFecha, int cHoraInicio, int cHoras)
    {
        this.idPista = cIdPista;
        this.nombreJugador = cNombreJugador;
        this.esSocio = cEsSocio;
        this.fecha = cFecha;
        this.horaInicio = cHoraInicio;
        this.horas = cHoras;
        this.importe = calcularImporte();
    }

    public decimal calcularImporte()
    {
        if (esSocio) return (decimal) horas * 8;

        else return (decimal) horas * 10;
    }

    public override string ToString()
    {
        return $"Reserva: Id pista: {this.idPista}, Nombre del jugador: {this.nombreJugador}, Socio: {this.esSocio}, " +
            $"Fecha {this.fecha}, Hora de inicio: {this.horaInicio}, Duracion: {this.horas} horas, Importe: {this.importe} euros";
    }
}
