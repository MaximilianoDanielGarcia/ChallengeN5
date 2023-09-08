using Swashbuckle.AspNetCore.Annotations;

namespace ChallengeN5.Models.DTOs
{
    public class PermisoDTO
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public string NombreEmpleado { get; set; }

        public string ApellidoEmpleado { get; set; }

        public DateTime FechaPermiso { get; set; }

        public int TipoPermisoId { get; set; }

    }
}
