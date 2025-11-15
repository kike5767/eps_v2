// Interfaz para la capa de presentación de Afiliados
// Define los métodos que la UI puede usar para interactuar con el API
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IAfiliadosPresentacion
    {
        // Lista todos los afiliados
        Task<List<Afiliado>> Listar();
        
        // Obtiene afiliados por municipio
        Task<List<Afiliado>> PorMunicipio(Afiliado? entidad);
        
        // Guarda un nuevo afiliado
        Task<Afiliado?> Guardar(Afiliado? entidad);
        
        // Modifica un afiliado existente
        Task<Afiliado?> Modificar(Afiliado? entidad);
        
        // Borra un afiliado
        Task<Afiliado?> Borrar(Afiliado? entidad);
    }
}

