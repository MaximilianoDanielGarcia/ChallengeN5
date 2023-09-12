using Swashbuckle.AspNetCore.Annotations;

namespace ChallengeN5.Models.DTOs
{
    public class PermisoDTO
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public string NombreEmpleado { get; set; }

        public string ApellidoEmpleado { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public DateTime FechaPermiso { get; set; } = DateTime.Now;

        public int TipoPermisoId { get; set; }

    }
}
