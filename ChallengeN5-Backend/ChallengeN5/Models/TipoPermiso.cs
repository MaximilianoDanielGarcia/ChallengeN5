using System;
using System.Collections.Generic;

namespace ChallengeN5.Models;

public class TipoPermiso
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();
}
