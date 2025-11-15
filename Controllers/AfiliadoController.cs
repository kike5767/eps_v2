using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AfiliadoController : ControllerBase
    {
        private readonly IAfiliadoRepository _afiliadoRepository;

        public AfiliadoController(IAfiliadoRepository afiliadoRepository)
        {
            _afiliadoRepository = afiliadoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Afiliado>>> GetAfiliados()
        {
            try
            {
                var afiliados = await _afiliadoRepository.GetAllAsync();
                return Ok(afiliados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Afiliado>> GetAfiliado(int id)
        {
            try
            {
                var afiliado = await _afiliadoRepository.GetByIdAsync(id);
                if (afiliado == null)
                {
                    return NotFound($"Afiliado con ID {id} no encontrado");
                }
                return Ok(afiliado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("documento/{documento}")]
        public async Task<ActionResult<Afiliado>> GetAfiliadoByDocumento(string documento)
        {
            try
            {
                var afiliado = await _afiliadoRepository.GetByDocumentoAsync(documento);
                if (afiliado == null)
                {
                    return NotFound($"Afiliado con documento {documento} no encontrado");
                }
                return Ok(afiliado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("municipio/{municipioId}")]
        public async Task<ActionResult<IEnumerable<Afiliado>>> GetAfiliadosByMunicipio(int municipioId)
        {
            try
            {
                var afiliados = await _afiliadoRepository.GetByMunicipioAsync(municipioId);
                return Ok(afiliados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Afiliado>> CreateAfiliado(Afiliado afiliado)
        {
            try
            {
                if (await _afiliadoRepository.DocumentoExistsAsync(afiliado.Documento))
                {
                    return BadRequest("Ya existe un afiliado con este documento");
                }

                var nuevoAfiliado = await _afiliadoRepository.CreateAsync(afiliado);
                return CreatedAtAction(nameof(GetAfiliado), new { id = nuevoAfiliado.Id }, nuevoAfiliado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Afiliado>> UpdateAfiliado(int id, Afiliado afiliado)
        {
            try
            {
                if (id != afiliado.Id)
                {
                    return BadRequest("El ID no coincide");
                }

                if (!await _afiliadoRepository.ExistsAsync(id))
                {
                    return NotFound($"Afiliado con ID {id} no encontrado");
                }

                var afiliadoActualizado = await _afiliadoRepository.UpdateAsync(afiliado);
                return Ok(afiliadoActualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAfiliado(int id)
        {
            try
            {
                var resultado = await _afiliadoRepository.DeleteAsync(id);
                if (!resultado)
                {
                    return NotFound($"Afiliado con ID {id} no encontrado");
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

