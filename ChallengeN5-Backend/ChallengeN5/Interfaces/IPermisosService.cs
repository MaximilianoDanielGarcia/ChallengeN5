using ChallengeN5.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeN5.Interfaces
{
    public interface IPermisosService
    {
        IEnumerable<Permiso> GetPermisos();

        Task<IEnumerable<Permiso>> GetPermisosAsync();

        Permiso GetPermisoId(int id);

        Task<Permiso> GetPermisoIdAsync(int id);

        Permiso RegistrarPermiso(Permiso permiso);

        Task<Permiso> RegistrarPermisoAsync(Permiso permiso);

        Permiso QuitarPermiso(int id);

        Task<Permiso> QuitarPermisoAsync(int id);

        Permiso ModificarPermiso(Permiso permiso);

        Task<Permiso> ModificarPermisoAsync (Permiso permiso);
    }
}
