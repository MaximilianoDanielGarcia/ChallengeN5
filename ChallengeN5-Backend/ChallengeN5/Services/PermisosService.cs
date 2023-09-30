using ChallengeN5.Interfaces;
using ChallengeN5.Models;
using ChallengeN5.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ChallengeN5.Services
{
    public class PermisosService : IPermisosService
    {
        IUnitOfWork _work;

        public PermisosService(IUnitOfWork work)
        {
            _work = work;
        }

        public Permiso GetPermisoId(int id)
        {
            return _work.Permisos.Get(p => p.Id == id);
        }

        public async Task<Permiso> GetPermisoIdAsync(int id)
        {
            return await _work.Permisos.GetAsync(p => p.Id == id);
        }

        public IEnumerable<Permiso> GetPermisos()
        {
            return _work.Permisos.GetAll();
        }

        public async Task<IEnumerable<Permiso>> GetPermisosAsync()
        {
            return await _work.Permisos.GetAllAsync();
        }

        public Permiso ModificarPermiso(Permiso permiso)
        {
            _work.Permisos.Update(permiso);
            _work.Commit();

            return permiso;
        }

        public async Task<Permiso> ModificarPermisoAsync(Permiso permiso)
        {
            _work.Permisos.Update(permiso);
            await _work.CommitAsync();

            return permiso;
        }

        public Permiso QuitarPermiso(int id)
        {
            Permiso permiso = GetPermisoId(id);

            if (permiso != null)
            {
                _work.Permisos.Remove(permiso);
                _work.Commit();
            }

            return permiso;
        }

        public async Task<Permiso> QuitarPermisoAsync(int id)
        {
            Permiso permiso = await GetPermisoIdAsync(id);

            if (permiso != null)
            {
                _work.Permisos.Remove(permiso);
                await _work.CommitAsync();
            }

            return permiso;
        }

        public Permiso RegistrarPermiso(Permiso permiso)
        {
            _work.Permisos.Add(permiso);
            _work.Commit();

            return permiso;
        }

        public async Task<Permiso> RegistrarPermisoAsync(Permiso permiso)
        {
            await _work.Permisos.AddAsync(permiso);
            await _work.CommitAsync();

            return permiso;
        }
    }
}
