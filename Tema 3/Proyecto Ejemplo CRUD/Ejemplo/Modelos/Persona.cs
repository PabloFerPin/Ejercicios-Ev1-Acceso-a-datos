namespace CrudPersonas.Modelos;

// Entidad: cada objeto Persona es una fila de la tabla Personas (§3.4.1)
public class Persona
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public string Email { get; set; } = "";
    public int Edad { get; set; }
    public bool Activo { get; set; } = true;

    public override string ToString() =>
        $"[{Id}] {Nombre} <{Email}>, {Edad} años{(Activo ? "" : " (baja)")}";
}