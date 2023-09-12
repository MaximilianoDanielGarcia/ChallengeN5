using AutoMapper;
using ChallengeN5.Interfaces;
using ChallengeN5.Models;
using ChallengeN5.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallengeN5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermisosController : Controller
    {
        private readonly IPermisosService _permisosService;
        private readonly IMapper _mapper;
        public PermisosController(IPermisosService permisosService, IMapper mapper)
        {
            _permisosService = permisosService;
            _mapper = mapper;
        }

        [HttpGet("GetPermisos")]
        public IActionResult GetPermisos()
        {
            try
            {
                var response = _permisosService.GetPermisos();

                var listPermisos = _mapper.Map<IEnumerable<PermisoDTO>>(response);

                return Ok(listPermisos);
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

                var listPermisos = _mapper.Map<IEnumerable<PermisoDTO>>(response);

                return Ok(listPermisos);
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

                if (response == null)
                {
                    return NotFound();
                }

                var permisoDTO = _mapper.Map<PermisoDTO>(response);

                return Ok(permisoDTO);
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

                if (response == null)
                {
                    return NotFound();
                }

                var permisoDTO = _mapper.Map<PermisoDTO>(response);

                return Ok(permisoDTO);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpPost("RegistrarPermiso")]
        public IActionResult RegistrarPermiso(PermisoDTO permisoDTO)
        {
            try
            {
                Permiso permiso = _mapper.Map<Permiso>(permisoDTO);

                var response = _permisosService.RegistrarPermiso(permiso);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpPost("RegistrarPermisoAsync")]
        public async Task<IActionResult> RegistrarPermisoAsync([FromBody] PermisoDTO permisoDTO)
        {
            try
            {
                 Permiso permiso = _mapper.Map<Permiso>(permisoDTO);

                 var response = await _permisosService.RegistrarPermisoAsync(permiso);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPatch("ModificarPermiso/{id}")]
        public IActionResult ModificarPermiso(int id, PermisoDTO permisoDTO)
        {
            try
            {
                Permiso permiso = _permisosService.GetPermisoId(id);

                permiso.NombreEmpleado = permisoDTO.NombreEmpleado;
                permiso.ApellidoEmpleado = permisoDTO.ApellidoEmpleado;
                permiso.TipoPermiso = permisoDTO.TipoPermisoId;

                _permisosService.ModificarPermiso(permiso);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("ModificarPermisoAsync/{id}")]
        public async Task<IActionResult> ModificarPermisoAsync(int id, PermisoDTO permisoDTO)
        {
            try
            {
                Permiso permiso =await _permisosService.GetPermisoIdAsync(id);

                permiso.NombreEmpleado = permisoDTO.NombreEmpleado;
                permiso.ApellidoEmpleado = permisoDTO.ApellidoEmpleado;
                permiso.TipoPermiso = permisoDTO.TipoPermisoId;

                await _permisosService.ModificarPermisoAsync(permiso);
                return NoContent();
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
                return response != null ? NoContent() : NotFound();
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
                return response != null ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
