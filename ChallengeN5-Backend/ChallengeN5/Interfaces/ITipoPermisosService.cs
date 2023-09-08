using ChallengeN5.Models;
using ChallengeN5.Models.DTOs;

namespace ChallengeN5.Interfaces
{
    public interface ITipoPermisosService
    {
        IEnumerable<TipoPermiso> GetTiposPermiso();

        Task<IEnumerable<TipoPermiso>> GetTiposPermisoAsync();

        TipoPermiso GetTipoPermisoId(int id);

        Task<TipoPermiso> GetTipoPermisoIdAsync(int id);

        TipoPermiso RegistrarTipoPermiso(TipoPermisoDTO permiso);

        Task<TipoPermiso> RegistrarTipoPermisoAsync(TipoPermiso permiso);

        TipoPermiso QuitarTipoPermiso(int id);

        Task<TipoPermiso> QuitarTipoPermisoAsync(int id);

        TipoPermiso ModificarTipoPermiso(int id, TipoPermiso permiso);

        Task<TipoPermiso> ModificarTipoPermisoAsync (int id, TipoPermiso permiso);
    }
}
