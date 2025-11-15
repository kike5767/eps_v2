using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IContratoRepository : IRepositoryBase<Contrato>
    {
        Task<IEnumerable<Contrato>> GetByAfiliadoAsync(int afiliadoId);
        Task<IEnumerable<Contrato>> GetByPlanEPSAsync(int planEPSId);
        Task<IEnumerable<Contrato>> GetActivosAsync();
    }
}
