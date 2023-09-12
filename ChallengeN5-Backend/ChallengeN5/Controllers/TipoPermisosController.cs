using AutoMapper;
using ChallengeN5.Interfaces;
using ChallengeN5.Models;
using ChallengeN5.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeN5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoPermisosController : Controller
    {
        private readonly ITipoPermisosService _tiposPermisoService;
        private readonly IMapper _mapper;
        public TipoPermisosController(ITipoPermisosService tiposPermisoService, IMapper mapper)
        {
            _tiposPermisoService = tiposPermisoService;
            _mapper = mapper;
        }

        [HttpGet("GetTiposPermiso")]
        public IActionResult GetTiposPermiso()
        {
            try
            {
                var response = _tiposPermisoService.GetTiposPermiso();

                var listTiposPermiso = _mapper.Map<IEnumerable<TipoPermisoDTO>>(response);
                
                return Ok(listTiposPermiso);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("GetTiposPermisoAsync")]
        public async Task<IActionResult> GetTiposPermisoAsync()
        {
            try
            {
                var response = await _tiposPermisoService.GetTiposPermisoAsync();

                var listTiposPermiso = _mapper.Map<IEnumerable<TipoPermisoDTO>>(response);

                return Ok(listTiposPermiso);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpGet("GetTipoPermisoById/{id}")]

        public IActionResult GetTipoPermisoById(int id)
        {
            try
            {
                var response = _tiposPermisoService.GetTipoPermisoId(id);

                if (response == null)
                {
                    return NotFound();
                }

                var tipoPermisoDTO = _mapper.Map<TipoPermisoDTO>(response);

                return Ok(tipoPermisoDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("GetTipoPermisoByIdAsync/{id}")]
        public async Task<IActionResult> GetTipoPermisoByIdAsync(int id)
        {
            try
            {
                var response = await _tiposPermisoService.GetTipoPermisoIdAsync(id);

                if (response == null)
                {
                    return NotFound();
                }

                var tipoPermisoDTO = _mapper.Map<TipoPermisoDTO>(response);

                return Ok(tipoPermisoDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpPost("RegistrarTipoPermiso")]
        public IActionResult RegistrarTipoPermiso(TipoPermisoDTO tipoPermisoDTO)
        {
            try
            {
                TipoPermiso tipoPermiso = _mapper.Map<TipoPermiso>(tipoPermisoDTO);

                var response = _tiposPermisoService.RegistrarTipoPermiso(tipoPermiso);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpPost("RegistrarTipoPermisoAsync")]
        public async Task<IActionResult> RegistrarTipoPermisoAsync(TipoPermisoDTO tipoPermisoDTO)
        {
            try
            {
                TipoPermiso tipoPermiso = _mapper.Map<TipoPermiso>(tipoPermisoDTO);

                var response = await _tiposPermisoService.RegistrarTipoPermisoAsync(tipoPermiso);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPatch("ModificarTipoPermiso/{id}")]
        public IActionResult ModificarTipoPermiso(int id, TipoPermisoDTO tipoPermisoDTO)
        {
            try
            {
                TipoPermiso tipoPermiso = _tiposPermisoService.GetTipoPermisoId(id);

                tipoPermiso.Descripcion = tipoPermisoDTO.Descripcion;

                _tiposPermisoService.ModificarTipoPermiso(tipoPermiso);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("ModificarTipoPermisoAsync/{id}")]
        public async Task<IActionResult> ModificarTipoPermisoAsync(int id, TipoPermisoDTO tipoPermisoDTO)
        {
            try
            {
                TipoPermiso tipoPermiso = await _tiposPermisoService.GetTipoPermisoIdAsync(id);

                tipoPermiso.Descripcion = tipoPermisoDTO.Descripcion;

                await _tiposPermisoService.ModificarTipoPermisoAsync(tipoPermiso);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("QuitarTipoPermiso/{id}")]
        public IActionResult QuitarTipoPermiso(int id)
        {
            try
            {
                var response = _tiposPermisoService.QuitarTipoPermiso(id);
                return response != null ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("QuitarTipoPermisoAsync/{id}")]
        public async Task<IActionResult> QuitarTipoPermisoAsync(int id)
        {
            try
            {
                var response = await _tiposPermisoService.QuitarTipoPermisoAsync(id);
                return response != null ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
