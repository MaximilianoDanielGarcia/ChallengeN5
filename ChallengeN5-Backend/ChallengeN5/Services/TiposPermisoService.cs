using ChallengeN5.Interfaces;
using ChallengeN5.Models;
using ChallengeN5.Models.DTOs;
using ChallengeN5.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ChallengeN5.Services
{
    public class TiposPermisoService : ITipoPermisosService
    {
        IUnitOfWork _work;

        public TiposPermisoService(IUnitOfWork work)
        {
            _work = work;
    }

        public TipoPermiso GetTipoPermisoId(int id)
        {
            return _work.TiposPermiso.Get(p => p.Id == id);
        }

        public async Task<TipoPermiso> GetTipoPermisoIdAsync(int id)
        {
            return await _work.TiposPermiso.GetAsync(p => p.Id == id);
        }

        public IEnumerable<TipoPermiso> GetTiposPermiso()
        {
            return _work.TiposPermiso.GetAll();
        }

        public async Task<IEnumerable<TipoPermiso>> GetTiposPermisoAsync()
        {
            return await _work.TiposPermiso.GetAllAsync();
        }

        public TipoPermiso ModificarTipoPermiso(TipoPermiso tipoPermiso)
        {
            _work.TiposPermiso.Update(tipoPermiso);
            _work.Commit();

            return tipoPermiso;
        }

        public async Task<TipoPermiso> ModificarTipoPermisoAsync(TipoPermiso tipoPermiso)
        {
            _work.TiposPermiso.Update(tipoPermiso);
            await _work.CommitAsync();

            return tipoPermiso;
        }

        public TipoPermiso QuitarTipoPermiso(int id)
        {
            TipoPermiso tipoPermiso = GetTipoPermisoId(id);

            if (tipoPermiso != null)
            {
                _work.TiposPermiso.Remove(tipoPermiso);
                _work.Commit();
            }

            return tipoPermiso;
        }

        public async Task<TipoPermiso> QuitarTipoPermisoAsync(int id)
        {
            TipoPermiso tipoPermiso = await GetTipoPermisoIdAsync(id);

            if (tipoPermiso != null)
            {
                _work.TiposPermiso.Remove(tipoPermiso);
                await _work.CommitAsync();
            }

            return tipoPermiso;
        }

        public TipoPermiso RegistrarTipoPermiso(TipoPermiso tipoPermiso)
        {
            _work.TiposPermiso.Add(tipoPermiso);
            _work.Commit();

            return tipoPermiso;
        }

        public async Task<TipoPermiso> RegistrarTipoPermisoAsync(TipoPermiso tipoPermiso)
        {
            _work.TiposPermiso.Add(tipoPermiso);
            await _work.CommitAsync();

            return tipoPermiso;
        }
    }
}
