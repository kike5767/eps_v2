using lib_dominio.Entidades;
using lib_repositorios.Context;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class RolRepository : RepositoryBase<Rol>, IRolRepository
    {
        public RolRepository(EpsDbContext context) : base(context) { }

        public async Task<Rol?> GetByNombreAsync(string nombre)
        {
            return await _dbSet.FirstOrDefaultAsync(r => r.Nombre == nombre);
        }
    }

    public class PlanEPSRepository : RepositoryBase<PlanEPS>, IPlanEPSRepository
    {
        public PlanEPSRepository(EpsDbContext context) : base(context) { }

        public async Task<IEnumerable<PlanEPS>> GetActivosAsync()
        {
            return await _dbSet.Where(p => p.Activo).ToListAsync();
        }
    }

    public class DepartamentoRepository : RepositoryBase<Departamento>, IDepartamentoRepository
    {
        public DepartamentoRepository(EpsDbContext context) : base(context) { }

        public async Task<IEnumerable<Departamento>> GetActivosAsync()
        {
            return await _dbSet.Where(d => d.Activo)
                              .Include(d => d.Municipios)
                              .ToListAsync();
        }
    }

    public class MunicipioRepository : RepositoryBase<Municipio>, IMunicipioRepository
    {
        public MunicipioRepository(EpsDbContext context) : base(context) { }

        public override async Task<IEnumerable<Municipio>> GetAllAsync()
        {
            return await _dbSet.Include(m => m.Departamento).ToListAsync();
        }

        public async Task<IEnumerable<Municipio>> GetByDepartamentoAsync(int departamentoId)
        {
            return await _dbSet.Where(m => m.DepartamentoId == departamentoId)
                              .ToListAsync();
        }
    }

    public class CitaRepository : RepositoryBase<Cita>, ICitaRepository
    {
        public CitaRepository(EpsDbContext context) : base(context) { }

        public override async Task<IEnumerable<Cita>> GetAllAsync()
        {
            return await _dbSet.Include(c => c.Afiliado).ToListAsync();
        }

        public async Task<IEnumerable<Cita>> GetByAfiliadoAsync(int afiliadoId)
        {
            return await _dbSet.Where(c => c.AfiliadoId == afiliadoId)
                              .OrderBy(c => c.Fecha)
                              .ThenBy(c => c.Hora)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Cita>> GetByFechaAsync(DateTime fecha)
        {
            return await _dbSet.Include(c => c.Afiliado)
                              .Where(c => c.Fecha.Date == fecha.Date)
                              .OrderBy(c => c.Hora)
                              .ToListAsync();
        }
    }

    public class HistoriaMedicaRepository : RepositoryBase<HistoriaMedica>, IHistoriaMedicaRepository
    {
        public HistoriaMedicaRepository(EpsDbContext context) : base(context) { }

        public override async Task<IEnumerable<HistoriaMedica>> GetAllAsync()
        {
            return await _dbSet.Include(h => h.Afiliado).ToListAsync();
        }

        public async Task<IEnumerable<HistoriaMedica>> GetByAfiliadoAsync(int afiliadoId)
        {
            return await _dbSet.Where(h => h.AfiliadoId == afiliadoId)
                              .OrderByDescending(h => h.Fecha)
                              .ToListAsync();
        }
    }

    public class AfiliadoDetalleRepository : RepositoryBase<AfiliadoDetalle>, IAfiliadoDetalleRepository
    {
        public AfiliadoDetalleRepository(EpsDbContext context) : base(context) { }

        public override async Task<IEnumerable<AfiliadoDetalle>> GetAllAsync()
        {
            return await _dbSet.Include(ad => ad.Afiliado).ToListAsync();
        }

        public async Task<IEnumerable<AfiliadoDetalle>> GetByAfiliadoAsync(int afiliadoId)
        {
            return await _dbSet.Where(ad => ad.AfiliadoId == afiliadoId)
                              .OrderByDescending(ad => ad.FechaRegistro)
                              .ToListAsync();
        }
    }

    public class PagoRepository : RepositoryBase<Pago>, IPagoRepository
    {
        public PagoRepository(EpsDbContext context) : base(context) { }

        public override async Task<IEnumerable<Pago>> GetAllAsync()
        {
            return await _dbSet.Include(p => p.Contrato)
                              .ThenInclude(c => c!.Afiliado)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Pago>> GetByContratoAsync(int contratoId)
        {
            return await _dbSet.Where(p => p.ContratoId == contratoId)
                              .OrderByDescending(p => p.Fecha)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Pago>> GetByEstadoAsync(string estado)
        {
            return await _dbSet.Include(p => p.Contrato)
                              .Where(p => p.Estado == estado)
                              .ToListAsync();
        }
    }

    public class FacturaRepository : RepositoryBase<Factura>, IFacturaRepository
    {
        public FacturaRepository(EpsDbContext context) : base(context) { }

        public override async Task<IEnumerable<Factura>> GetAllAsync()
        {
            return await _dbSet.Include(f => f.Pago).ToListAsync();
        }

        public async Task<IEnumerable<Factura>> GetByPagoAsync(int pagoId)
        {
            return await _dbSet.Where(f => f.PagoId == pagoId).ToListAsync();
        }

        public async Task<Factura?> GetByNumeroAsync(string numero)
        {
            return await _dbSet.Include(f => f.Pago)
                              .FirstOrDefaultAsync(f => f.Numero == numero);
        }
    }

    public class IndicadorRepository : RepositoryBase<Indicador>, IIndicadorRepository
    {
        public IndicadorRepository(EpsDbContext context) : base(context) { }

        public async Task<IEnumerable<Indicador>> GetActivosAsync()
        {
            return await _dbSet.Where(i => i.Activo)
                              .OrderBy(i => i.Nombre)
                              .ToListAsync();
        }
    }

    public class ReporteRepository : RepositoryBase<Reporte>, IReporteRepository
    {
        public ReporteRepository(EpsDbContext context) : base(context) { }

        public async Task<IEnumerable<Reporte>> GetByTipoAsync(string tipo)
        {
            return await _dbSet.Where(r => r.Tipo == tipo)
                              .OrderByDescending(r => r.Fecha)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Reporte>> GetByFechaAsync(DateTime fecha)
        {
            return await _dbSet.Where(r => r.Fecha.Date == fecha.Date)
                              .ToListAsync();
        }
    }

    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(EpsDbContext context) : base(context) { }

        public async Task<IEnumerable<Categoria>> GetActivasAsync()
        {
            return await _dbSet.Where(c => c.Activo)
                              .OrderBy(c => c.Nombre)
                              .ToListAsync();
        }
    }
}
