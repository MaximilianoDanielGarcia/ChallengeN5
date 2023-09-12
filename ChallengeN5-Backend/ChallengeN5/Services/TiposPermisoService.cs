using ChallengeN5.Interfaces;
using ChallengeN5.Models;
using ChallengeN5.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ChallengeN5.Services
{
    public class TiposPermisoService : ITipoPermisosService
    {
        private readonly IChallengeN5Context challengeN5Context;

        public TiposPermisoService(IChallengeN5Context _challengeN5Context)
        {
            challengeN5Context = _challengeN5Context;
        }

        public TipoPermiso GetTipoPermisoId(int id)
        {
            return challengeN5Context.Set<TipoPermiso>().Single(p => p.Id == id);
        }

        public async Task<TipoPermiso> GetTipoPermisoIdAsync(int id)
        {
            return await challengeN5Context.Set<TipoPermiso>().SingleAsync(p => p.Id == id);
        }

        public IEnumerable<TipoPermiso> GetTiposPermiso()
        {
            return challengeN5Context.Set<TipoPermiso>().ToList();
        }

        public async Task<IEnumerable<TipoPermiso>> GetTiposPermisoAsync()
        {
            return await challengeN5Context.Set<TipoPermiso>().ToListAsync();
        }

        public TipoPermiso ModificarTipoPermiso(TipoPermiso tipoPermiso)
        {
            challengeN5Context.Entry(tipoPermiso).State = EntityState.Modified;
            challengeN5Context.SaveChanges();

            return tipoPermiso;
        }

        public async Task<TipoPermiso> ModificarTipoPermisoAsync(TipoPermiso tipoPermiso)
        {
            challengeN5Context.Entry(tipoPermiso).State = EntityState.Modified;
            await challengeN5Context.SaveChangesAsync();

            return tipoPermiso;
        }

        public TipoPermiso QuitarTipoPermiso(int id)
        {
            TipoPermiso tipoPermiso = GetTipoPermisoId(id);

            if (tipoPermiso != null)
            {
                challengeN5Context.Set<TipoPermiso>().Remove(tipoPermiso);
                challengeN5Context.SaveChanges();
            }

            return tipoPermiso;
        }

        public async Task<TipoPermiso> QuitarTipoPermisoAsync(int id)
        {
            TipoPermiso tipoPermiso = await GetTipoPermisoIdAsync(id);

            if (tipoPermiso != null)
            {
                challengeN5Context.Set<TipoPermiso>().Remove(tipoPermiso);
                await challengeN5Context.SaveChangesAsync();
            }

            return tipoPermiso;
        }

        public TipoPermiso RegistrarTipoPermiso(TipoPermiso tipoPermiso)
        {
            challengeN5Context.Set<TipoPermiso>().Add(tipoPermiso);
            challengeN5Context.SaveChanges();

            return tipoPermiso;
        }

        public async Task<TipoPermiso> RegistrarTipoPermisoAsync(TipoPermiso tipoPermiso)
        {
            challengeN5Context.Set<TipoPermiso>().Add(tipoPermiso);
            await challengeN5Context.SaveChangesAsync();

            return tipoPermiso;
        }
    }
}
