using AutoMapper;
using EPS.DTOs;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace EPS.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDto>> GetAllAsync();
        Task<UsuarioDto?> GetByIdAsync(int id);
        Task<UsuarioDto?> GetByEmailAsync(string email);
        Task<UsuarioDto> CreateAsync(CreateUsuarioDto dto);
        Task<UsuarioDto?> UpdateAsync(UpdateUsuarioDto dto);
        Task<bool> DeleteAsync(int id);
    }

    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDto>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UsuarioDto>>(items);
        }

        public async Task<UsuarioDto?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return item is null ? null : _mapper.Map<UsuarioDto>(item);
        }

        public async Task<UsuarioDto?> GetByEmailAsync(string email)
        {
            var item = await _repository.GetByEmailAsync(email);
            return item is null ? null : _mapper.Map<UsuarioDto>(item);
        }

        public async Task<UsuarioDto> CreateAsync(CreateUsuarioDto dto)
        {
            var entity = _mapper.Map<Usuario>(dto);
            var created = await _repository.CreateAsync(entity);
            return _mapper.Map<UsuarioDto>(created);
        }

        public async Task<UsuarioDto?> UpdateAsync(UpdateUsuarioDto dto)
        {
            var exists = await _repository.ExistsAsync(dto.Id);
            if (!exists) return null;
            var entity = _mapper.Map<Usuario>(dto);
            var updated = await _repository.UpdateAsync(entity);
            return _mapper.Map<UsuarioDto>(updated);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }
    }
}

