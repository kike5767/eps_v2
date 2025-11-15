using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IAfiliadoRepository : IRepositoryBase<Afiliado>
    {
        Task<Afiliado?> GetByDocumentoAsync(string documento);
        Task<IEnumerable<Afiliado>> GetByMunicipioAsync(int municipioId);
        Task<bool> DocumentoExistsAsync(string documento);
    }
}
