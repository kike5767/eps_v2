using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public DepartamentoController(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetDepartamentos()
        {
            try
            {
                var departamentos = await _departamentoRepository.GetAllAsync();
                return Ok(departamentos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> GetDepartamento(int id)
        {
            try
            {
                var departamento = await _departamentoRepository.GetByIdAsync(id);
                if (departamento == null)
                {
                    return NotFound($"Departamento con ID {id} no encontrado");
                }
                return Ok(departamento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("activos")]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetDepartamentosActivos()
        {
            try
            {
                var departamentos = await _departamentoRepository.GetActivosAsync();
                return Ok(departamentos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Departamento>> CreateDepartamento(Departamento departamento)
        {
            try
            {
                var nuevoDepartamento = await _departamentoRepository.CreateAsync(departamento);
                return CreatedAtAction(nameof(GetDepartamento), new { id = nuevoDepartamento.Id }, nuevoDepartamento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Departamento>> UpdateDepartamento(int id, Departamento departamento)
        {
            try
            {
                if (id != departamento.Id)
                {
                    return BadRequest("El ID no coincide");
                }

                if (!await _departamentoRepository.ExistsAsync(id))
                {
                    return NotFound($"Departamento con ID {id} no encontrado");
                }

                var departamentoActualizado = await _departamentoRepository.UpdateAsync(departamento);
                return Ok(departamentoActualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartamento(int id)
        {
            try
            {
                var resultado = await _departamentoRepository.DeleteAsync(id);
                if (!resultado)
                {
                    return NotFound($"Departamento con ID {id} no encontrado");
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