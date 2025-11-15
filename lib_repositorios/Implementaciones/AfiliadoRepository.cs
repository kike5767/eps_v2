using lib_dominio.Entidades;
using lib_repositorios.Context;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class AfiliadoRepository : RepositoryBase<Afiliado>, IAfiliadoRepository
    {
        public AfiliadoRepository(EpsDbContext context) : base(context) { }

        public override async Task<IEnumerable<Afiliado>> GetAllAsync()
        {
            return await _dbSet.Include(a => a.Municipio)
                              .ThenInclude(m => m!.Departamento)
                              .ToListAsync();
        }

        public override async Task<Afiliado?> GetByIdAsync(int id)
        {
            return await _dbSet.Include(a => a.Municipio)
                              .ThenInclude(m => m!.Departamento)
                              .Include(a => a.Contratos)
                              .Include(a => a.Citas)
                              .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Afiliado?> GetByDocumentoAsync(string documento)
        {
            return await _dbSet.Include(a => a.Municipio)
                              .FirstOrDefaultAsync(a => a.Documento == documento);
        }

        public async Task<IEnumerable<Afiliado>> GetByMunicipioAsync(int municipioId)
        {
            return await _dbSet.Include(a => a.Municipio)
                              .Where(a => a.MunicipioId == municipioId)
                              .ToListAsync();
        }

        public async Task<bool> DocumentoExistsAsync(string documento)
        {
            return await _dbSet.AnyAsync(a => a.Documento == documento);
        }
    }

    public class ContratoRepository : RepositoryBase<Contrato>, IContratoRepository
    {
        public ContratoRepository(EpsDbContext context) : base(context) { }

        public override async Task<IEnumerable<Contrato>> GetAllAsync()
        {
            return await _dbSet.Include(c => c.Afiliado)
                              .Include(c => c.PlanEPS)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Contrato>> GetByAfiliadoAsync(int afiliadoId)
        {
            return await _dbSet.Include(c => c.PlanEPS)
                              .Where(c => c.AfiliadoId == afiliadoId)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Contrato>> GetByPlanEPSAsync(int planEPSId)
        {
            return await _dbSet.Include(c => c.Afiliado)
                              .Where(c => c.PlanEPSId == planEPSId)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Contrato>> GetActivosAsync()
        {
            return await _dbSet.Include(c => c.Afiliado)
                              .Include(c => c.PlanEPS)
                              .Where(c => c.Activo)
                              .ToListAsync();
        }
    }
}
