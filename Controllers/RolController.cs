using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly IRolRepository _rolRepository;

        public RolController(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> GetRoles()
        {
            try
            {
                var roles = await _rolRepository.GetAllAsync();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> GetRol(int id)
        {
            try
            {
                var rol = await _rolRepository.GetByIdAsync(id);
                if (rol == null)
                {
                    return NotFound($"Rol con ID {id} no encontrado");
                }
                return Ok(rol);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Rol>> CreateRol(Rol rol)
        {
            try
            {
                var nuevoRol = await _rolRepository.CreateAsync(rol);
                return CreatedAtAction(nameof(GetRol), new { id = nuevoRol.Id }, nuevoRol);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Rol>> UpdateRol(int id, Rol rol)
        {
            try
            {
                if (id != rol.Id)
                {
                    return BadRequest("El ID no coincide");
                }

                if (!await _rolRepository.ExistsAsync(id))
                {
                    return NotFound($"Rol con ID {id} no encontrado");
                }

                var rolActualizado = await _rolRepository.UpdateAsync(rol);
                return Ok(rolActualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRol(int id)
        {
            try
            {
                var resultado = await _rolRepository.DeleteAsync(id);
                if (!resultado)
                {
                    return NotFound($"Rol con ID {id} no encontrado");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}

