using CrudPersonas.Modelos;

namespace CrudPersonas.Repositorios;

// QUÉ se puede hacer con las personas, sin decir CÓMO (§3.6.2)
public interface IPersonaRepository
{
    int Insertar(Persona p);                      // devuelve el Id generado
    Persona? ObtenerPorId(int id);                // null si no existe
    List<Persona> ObtenerTodas();                 // solo las activas
    List<Persona> BuscarPorNombre(string texto);
    bool Actualizar(Persona p);                   // false si el Id no existe
    bool DarDeBaja(int id);                       // borrado lógico
    bool Eliminar(int id);                        // borrado físico
}