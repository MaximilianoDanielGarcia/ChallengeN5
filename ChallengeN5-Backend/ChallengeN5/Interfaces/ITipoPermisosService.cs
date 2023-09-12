using ChallengeN5.Models;

namespace ChallengeN5.Interfaces
{
    public interface ITipoPermisosService
    {
        IEnumerable<TipoPermiso> GetTiposPermiso();

        Task<IEnumerable<TipoPermiso>> GetTiposPermisoAsync();

        TipoPermiso GetTipoPermisoId(int id);

        Task<TipoPermiso> GetTipoPermisoIdAsync(int id);

        TipoPermiso RegistrarTipoPermiso(TipoPermiso permiso);

        Task<TipoPermiso> RegistrarTipoPermisoAsync(TipoPermiso permiso);

        TipoPermiso QuitarTipoPermiso(int id);

        Task<TipoPermiso> QuitarTipoPermisoAsync(int id);

        TipoPermiso ModificarTipoPermiso(TipoPermiso permiso);

        Task<TipoPermiso> ModificarTipoPermisoAsync (TipoPermiso permiso);
    }
}
