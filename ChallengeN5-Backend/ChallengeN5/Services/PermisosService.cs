using ChallengeN5.Interfaces;
using ChallengeN5.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeN5.Services
{
    public class PermisosService : IPermisosService
    {
        private readonly IChallengeN5Context challengeN5Context;

        public PermisosService(IChallengeN5Context _challengeN5Context)
        {
            challengeN5Context = _challengeN5Context;
        }

        public Permiso GetPermisoId(int id)
        {
            return challengeN5Context.Set<Permiso>().Include(p => p.TipoPermisoNavigation).Single(p => p.Id == id);
        }

        public async Task<Permiso> GetPermisoIdAsync(int id)
        {
            return await challengeN5Context.Set<Permiso>().Include(p => p.TipoPermisoNavigation).SingleAsync(p => p.Id == id);
        }

        public IEnumerable<Permiso> GetPermisos()
        {
            return challengeN5Context.Set<Permiso>().Include(p => p.TipoPermisoNavigation).ToList();
        }

        public async Task<IEnumerable<Permiso>> GetPermisosAsync()
        {
            return await challengeN5Context.Set<Permiso>().Include(p => p.TipoPermisoNavigation).ToListAsync();
        }

        public Permiso ModificarPermiso(Permiso permiso)
        {
            challengeN5Context.Entry(permiso).State = EntityState.Modified;
            challengeN5Context.SaveChanges();

            return permiso;
        }

        public async Task<Permiso> ModificarPermisoAsync(Permiso permiso)
        {
            challengeN5Context.Entry(permiso).State = EntityState.Modified;
            await challengeN5Context.SaveChangesAsync();

            return permiso;
        }

        public Permiso QuitarPermiso(int id)
        {
            Permiso permiso = GetPermisoId(id);

            if (permiso != null)
            {
                challengeN5Context.Set<Permiso>().Remove(permiso);
                challengeN5Context.SaveChanges();
            }

            return permiso;
        }

        public async Task<Permiso> QuitarPermisoAsync(int id)
        {
            Permiso permiso = await GetPermisoIdAsync(id);

            if (permiso != null)
            {
                challengeN5Context.Set<Permiso>().Remove(permiso);
                await challengeN5Context.SaveChangesAsync();
            }

            return permiso;
        }

        public Permiso RegistrarPermiso(Permiso permiso)
        {
            challengeN5Context.Set<Permiso>().Add(permiso);
            challengeN5Context.SaveChanges();

            return permiso;
        }

        public async Task<Permiso> RegistrarPermisoAsync(Permiso permiso)
        {
            challengeN5Context.Set<Permiso>().Add(permiso);
            await challengeN5Context.SaveChangesAsync();

            return permiso;
        }
    }
}
