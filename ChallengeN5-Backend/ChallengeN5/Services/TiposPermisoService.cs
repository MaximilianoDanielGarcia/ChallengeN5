using ChallengeN5.Interfaces;
using ChallengeN5.Models;
using ChallengeN5.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ChallengeN5.Services
{
    public class TiposPermisoService : ITipoPermisosService
    {
        private readonly IN5DbContext _N5DbContext;

        public TiposPermisoService(IN5DbContext n5DbContext)
        {
            _N5DbContext = n5DbContext;
        }

        public TipoPermiso GetTipoPermisoId(int id)
        {
            return _N5DbContext.TipoPermisos.Find(id);
        }

        public async Task<TipoPermiso> GetTipoPermisoIdAsync(int id)
        {
            return await _N5DbContext.TipoPermisos.FindAsync(id);
        }

        public IEnumerable<TipoPermiso> GetTiposPermiso()
        {
            return _N5DbContext.TipoPermisos.ToList();
        }

        public async Task<IEnumerable<TipoPermiso>> GetTiposPermisoAsync()
        {
            return await _N5DbContext.TipoPermisos.ToListAsync();
        }

        public TipoPermiso ModificarTipoPermiso(int id, TipoPermiso tipoPermiso)
        {
            TipoPermiso tipoPermisoDB = GetTipoPermisoId(id);

            if (tipoPermisoDB == null)
            {
                return tipoPermisoDB;
            }

            tipoPermisoDB.Descripcion = tipoPermiso.Descripcion;      

            _N5DbContext.Entry(tipoPermisoDB, EntityState.Modified);
            _N5DbContext.SaveChanges();

            return tipoPermisoDB;
           
        }

        public async Task<TipoPermiso> ModificarTipoPermisoAsync(int id, TipoPermiso tipoPermiso)
        {
            TipoPermiso tipoPermisoDB = await GetTipoPermisoIdAsync(id);

            if (tipoPermisoDB == null)
            {
                return tipoPermisoDB;
            }

            tipoPermisoDB.Descripcion = tipoPermiso.Descripcion;

            _N5DbContext.Entry(tipoPermisoDB, EntityState.Modified);
            await _N5DbContext.SaveChanges();

            return tipoPermisoDB;
        }

        public TipoPermiso QuitarTipoPermiso(int id)
        {
            TipoPermiso tipoPermiso = GetTipoPermisoId(id);

            if (tipoPermiso != null)
            {
                _N5DbContext.TipoPermisos.Remove(tipoPermiso);
                _N5DbContext.SaveChanges();
            }

            return tipoPermiso;
        }

        public async Task<TipoPermiso> QuitarTipoPermisoAsync(int id)
        {
            TipoPermiso tipoPermiso = await GetTipoPermisoIdAsync(id);

            if (tipoPermiso != null)
            {
                _N5DbContext.TipoPermisos.Remove(tipoPermiso);
                await _N5DbContext.SaveChanges();
            }

            return tipoPermiso;
        }

        public TipoPermiso RegistrarTipoPermiso(TipoPermisoDTO tipoPermiso)
        {
            TipoPermiso tipoPermiso1 = new TipoPermiso();
            tipoPermiso1.Descripcion = tipoPermiso.Descripcion;

            _N5DbContext.TipoPermisos.Add(tipoPermiso1);
            _N5DbContext.SaveChanges();

            return tipoPermiso1;
        }

        public async Task<TipoPermiso> RegistrarTipoPermisoAsync(TipoPermiso tipoPermiso)
        {
            _N5DbContext.TipoPermisos.Add(tipoPermiso);
            await _N5DbContext.SaveChanges();

            return tipoPermiso;
        }
    }
}
