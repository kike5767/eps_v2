using lib_dominio.Entidades;
using lib_repositorios.Context;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(EpsDbContext context) : base(context) { }

        public override async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _dbSet.Include(u => u.Rol).ToListAsync();
        }

        public override async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _dbSet.Include(u => u.Rol)
                              .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _dbSet.Include(u => u.Rol)
                              .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<Usuario>> GetByRolAsync(int rolId)
        {
            return await _dbSet.Include(u => u.Rol)
                              .Where(u => u.RolId == rolId)
                              .ToListAsync();
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _dbSet.AnyAsync(u => u.Email == email);
        }
    }
}
