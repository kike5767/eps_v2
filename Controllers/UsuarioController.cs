using EPS.DTOs;
using EPS.Services;
using Microsoft.AspNetCore.Mvc;

namespace EPS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetUsuarios()
        {
            var usuarios = await _usuarioService.GetAllAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> GetUsuario(int id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound($"Usuario con ID {id} no encontrado");
            }
            return Ok(usuario);
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<UsuarioDto>> GetUsuarioByEmail(string email)
        {
            var usuario = await _usuarioService.GetByEmailAsync(email);
            if (usuario == null)
            {
                return NotFound($"Usuario con email {email} no encontrado");
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> CreateUsuario(CreateUsuarioDto dto)
        {
            var nuevoUsuario = await _usuarioService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetUsuario), new { id = nuevoUsuario.Id }, nuevoUsuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioDto>> UpdateUsuario(int id, UpdateUsuarioDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("El ID no coincide");
            }
            var usuarioActualizado = await _usuarioService.UpdateAsync(dto);
            if (usuarioActualizado is null)
            {
                return NotFound($"Usuario con ID {id} no encontrado");
            }
            return Ok(usuarioActualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuario(int id)
        {
            var resultado = await _usuarioService.DeleteAsync(id);
            if (!resultado)
            {
                return NotFound($"Usuario con ID {id} no encontrado");
            }
            return NoContent();
        }
    }
}

