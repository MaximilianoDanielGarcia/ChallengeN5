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
        public TipoPermisosController(ITipoPermisosService tiposPermisoService)
        {
            _tiposPermisoService = tiposPermisoService;
        }

        [HttpGet("GetTiposPermiso")]
        public IActionResult GetTiposPermiso()
        {
            try
            {
                var response = _tiposPermisoService.GetTiposPermiso();
                return Ok(response);
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
                return Ok(response);
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
                return response != null ? Ok(response) : NotFound();
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
                return response != null ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpPost("RegistrarTipoPermiso")]
        public IActionResult RegistrarTipoPermiso(TipoPermisoDTO tipoPermiso)
        {
            try
            {
                var response = _tiposPermisoService.RegistrarTipoPermiso(tipoPermiso);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpPost("RegistrarTipoPermisoAsync")]
        public async Task<IActionResult> RegistrarTipoPermisoAsync(TipoPermiso tipoPermiso)
        {
            try
            {
                 var response = await _tiposPermisoService.RegistrarTipoPermisoAsync(tipoPermiso);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPatch("ModificarTipoPermiso/{id}")]
        public IActionResult ModificarTipoPermiso(int id, TipoPermiso tipoPermiso)
        {
            try
            {
                var response =  _tiposPermisoService.ModificarTipoPermiso(id, tipoPermiso);
                return response != null ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("ModificarTipoPermisoAsync/{id}")]
        public async Task<IActionResult> ModificarTipoPermisoAsync(int id, TipoPermiso tipoPermiso)
        {
            try
            {
                var response = await _tiposPermisoService.ModificarTipoPermisoAsync(id, tipoPermiso);
                return response != null ? Ok(response) : NotFound();
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
                return response != null ? Ok(response) : NotFound();
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
                return response != null ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
