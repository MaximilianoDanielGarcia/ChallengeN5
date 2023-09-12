using Swashbuckle.AspNetCore.Annotations;

namespace ChallengeN5.Models.DTOs
{
    public class TipoPermisoDTO
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }

        public string Descripcion { get; set; }
    }
}
