using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<Usuario?> GetByEmailAsync(string email);
        Task<IEnumerable<Usuario>> GetByRolAsync(int rolId);
        Task<bool> EmailExistsAsync(string email);
    }
}
