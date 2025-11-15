using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContratoController : ControllerBase
    {
        private readonly IContratoRepository _contratoRepository;

        public ContratoController(IContratoRepository contratoRepository)
        {
            _contratoRepository = contratoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contrato>>> GetContratos()
        {
            try
            {
                var contratos = await _contratoRepository.GetAllAsync();
                return Ok(contratos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contrato>> GetContrato(int id)
        {
            try
            {
                var contrato = await _contratoRepository.GetByIdAsync(id);
                if (contrato == null)
                {
                    return NotFound($"Contrato con ID {id} no encontrado");
                }
                return Ok(contrato);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("afiliado/{afiliadoId}")]
        public async Task<ActionResult<IEnumerable<Contrato>>> GetContratosByAfiliado(int afiliadoId)
        {
            try
            {
                var contratos = await _contratoRepository.GetByAfiliadoAsync(afiliadoId);
                return Ok(contratos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("activos")]
        public async Task<ActionResult<IEnumerable<Contrato>>> GetContratosActivos()
        {
            try
            {
                var contratos = await _contratoRepository.GetActivosAsync();
                return Ok(contratos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Contrato>> CreateContrato(Contrato contrato)
        {
            try
            {
                var nuevoContrato = await _contratoRepository.CreateAsync(contrato);
                return CreatedAtAction(nameof(GetContrato), new { id = nuevoContrato.Id }, nuevoContrato);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Contrato>> UpdateContrato(int id, Contrato contrato)
        {
            try
            {
                if (id != contrato.Id)
                {
                    return BadRequest("El ID no coincide");
                }

                if (!await _contratoRepository.ExistsAsync(id))
                {
                    return NotFound($"Contrato con ID {id} no encontrado");
                }

                var contratoActualizado = await _contratoRepository.UpdateAsync(contrato);
                return Ok(contratoActualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContrato(int id)
        {
            try
            {
                var resultado = await _contratoRepository.DeleteAsync(id);
                if (!resultado)
                {
                    return NotFound($"Contrato con ID {id} no encontrado");
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