// Interfaz para la lógica de aplicación de Afiliados
// Define los métodos CRUD y operaciones de negocio
using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IAfiliadosAplicacion
    {
        // Configura la cadena de conexión
        void Configurar(string StringConexion);
        
        // Lista todos los afiliados (máximo 50)
        List<Afiliado> Listar();
        
        // Obtiene afiliados por municipio
        List<Afiliado> PorMunicipio(Afiliado? entidad);
        
        // Guarda un nuevo afiliado
        Afiliado? Guardar(Afiliado? entidad);
        
        // Modifica un afiliado existente
        Afiliado? Modificar(Afiliado? entidad);
        
        // Borra un afiliado
        Afiliado? Borrar(Afiliado? entidad);
    }
}

