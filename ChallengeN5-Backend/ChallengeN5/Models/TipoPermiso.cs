using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ChallengeN5.Models
{
    public class TipoPermiso
    {
        [SwaggerSchema(ReadOnly = true)]
        [Key]
        public int Id { get; set; }

        public string Descripcion { get; set; }

    }
}
