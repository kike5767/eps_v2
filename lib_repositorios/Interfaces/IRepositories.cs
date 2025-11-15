using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IRolRepository : IRepositoryBase<Rol>
    {
        Task<Rol?> GetByNombreAsync(string nombre);
    }

    public interface IPlanEPSRepository : IRepositoryBase<PlanEPS>
    {
        Task<IEnumerable<PlanEPS>> GetActivosAsync();
    }

    public interface IDepartamentoRepository : IRepositoryBase<Departamento>
    {
        Task<IEnumerable<Departamento>> GetActivosAsync();
    }

    public interface IMunicipioRepository : IRepositoryBase<Municipio>
    {
        Task<IEnumerable<Municipio>> GetByDepartamentoAsync(int departamentoId);
    }

    public interface ICitaRepository : IRepositoryBase<Cita>
    {
        Task<IEnumerable<Cita>> GetByAfiliadoAsync(int afiliadoId);
        Task<IEnumerable<Cita>> GetByFechaAsync(DateTime fecha);
    }

    public interface IHistoriaMedicaRepository : IRepositoryBase<HistoriaMedica>
    {
        Task<IEnumerable<HistoriaMedica>> GetByAfiliadoAsync(int afiliadoId);
    }

    public interface IAfiliadoDetalleRepository : IRepositoryBase<AfiliadoDetalle>
    {
        Task<IEnumerable<AfiliadoDetalle>> GetByAfiliadoAsync(int afiliadoId);
    }

    public interface IPagoRepository : IRepositoryBase<Pago>
    {
        Task<IEnumerable<Pago>> GetByContratoAsync(int contratoId);
        Task<IEnumerable<Pago>> GetByEstadoAsync(string estado);
    }

    public interface IFacturaRepository : IRepositoryBase<Factura>
    {
        Task<IEnumerable<Factura>> GetByPagoAsync(int pagoId);
        Task<Factura?> GetByNumeroAsync(string numero);
    }

    public interface IIndicadorRepository : IRepositoryBase<Indicador>
    {
        Task<IEnumerable<Indicador>> GetActivosAsync();
    }

    public interface IReporteRepository : IRepositoryBase<Reporte>
    {
        Task<IEnumerable<Reporte>> GetByTipoAsync(string tipo);
        Task<IEnumerable<Reporte>> GetByFechaAsync(DateTime fecha);
    }

    public interface ICategoriaRepository : IRepositoryBase<Categoria>
    {
        Task<IEnumerable<Categoria>> GetActivasAsync();
    }
}
