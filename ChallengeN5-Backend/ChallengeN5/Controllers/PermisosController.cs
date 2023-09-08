using ChallengeN5.Interfaces;
using ChallengeN5.Models;
using ChallengeN5.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeN5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermisosController : Controller
    {
        private readonly IPermisosService _permisosService;
        public PermisosController(IPermisosService permisosService)
        {
            _permisosService = permisosService;
        }

        [HttpGet("GetPermisos")]
        public IActionResult GetPermisos()
        {
            try
            {
                var response = _permisosService.GetPermisos();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("GetPermisosAsync")]
        public async Task<IActionResult> GetPermisosAsync()
        {
            try
            {
                var response = await _permisosService.GetPermisosAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpGet("GetPermisoById/{id}")]

        public IActionResult GetPermisoById(int id)
        {
            try
            {
                var response = _permisosService.GetPermisoId(id);
                return response != null ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("GetPermisoByIdAsync/{id}")]
        public async Task<IActionResult> GetPermisoByIdAsync(int id)
        {
            try
            {
                var response = await _permisosService.GetPermisoIdAsync(id);
                return response != null ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpPost("RegistrarPermiso")]
        public IActionResult RegistrarPermiso(PermisoDTO _permiso)
        {
            try
            {
                Permiso permiso = new Permiso();

                permiso.NombreEmpleado = _permiso.NombreEmpleado;
                permiso.ApellidoEmpleado = _permiso.ApellidoEmpleado;
                permiso.FechaPermiso = _permiso.FechaPermiso;
                permiso.TipoPermisoId = _permiso.TipoPermisoId;

                var response = _permisosService.RegistrarPermiso(permiso);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpPost("RegistrarPermisoAsync")]
        public async Task<IActionResult> RegistrarPermisoAsync(Permiso permiso)
        {
            try
            {
                 var response = await _permisosService.RegistrarPermisoAsync(permiso);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPatch("ModificarPermiso/{id}")]
        public IActionResult ModificarPermiso(int id, Permiso permiso)
        {
            try
            {
                var response =  _permisosService.ModificarPermiso(id, permiso);
                return response != null ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("ModificarPermisoAsync/{id}")]
        public async Task<IActionResult> ModificarPermisoAsync(int id, Permiso permiso)
        {
            try
            {
                var response = await _permisosService.ModificarPermisoAsync(id, permiso);
                return response != null ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("QuitarPermiso/{id}")]
        public IActionResult QuitarPermiso(int id)
        {
            try
            {
                var response = _permisosService.QuitarPermiso(id);
                return response != null ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("QuitarPermisoAsync/{id}")]
        public async Task<IActionResult> QuitarPermisoAsync(int id)
        {
            try
            {
                var response = await _permisosService.QuitarPermisoAsync(id);
                return response != null ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
