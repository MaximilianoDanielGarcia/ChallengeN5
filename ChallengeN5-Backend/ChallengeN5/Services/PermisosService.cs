using ChallengeN5.Interfaces;
using ChallengeN5.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeN5.Services
{
    public class PermisosService : IPermisosService
    {
        private readonly IN5DbContext _N5DbContext;

        public PermisosService(IN5DbContext n5DbContext)
        {
            _N5DbContext = n5DbContext;
        }

        public Permiso GetPermisoId(int id)
        {
            return _N5DbContext.Permisos.Include(p => p.TipoPermiso).Single(p => p.Id == id);
        }

        public async Task<Permiso> GetPermisoIdAsync(int id)
        {
            return await _N5DbContext.Permisos.Include(p => p.TipoPermiso).SingleAsync(p => p.Id == id);
        }

        public IEnumerable<Permiso> GetPermisos()
        {
            return _N5DbContext.Permisos.Include(p => p.TipoPermiso).ToList();
        }

        public async Task<IEnumerable<Permiso>> GetPermisosAsync()
        {
            return await _N5DbContext.Permisos.Include(p => p.TipoPermiso).ToListAsync();
        }

        public Permiso ModificarPermiso(int id, Permiso permiso)
        {
            Permiso permisoDB = GetPermisoId(id);

            if (permisoDB == null)
            {
                return permisoDB;
            }

            permisoDB.NombreEmpleado = permiso.NombreEmpleado;
            permisoDB.ApellidoEmpleado = permiso.ApellidoEmpleado;
            permisoDB.TipoPermisoId = permiso.TipoPermisoId;
            permisoDB.FechaPermiso = permiso.FechaPermiso;

            _N5DbContext.Entry(permisoDB, EntityState.Modified);
            _N5DbContext.SaveChanges();

            return permisoDB;
           
        }

        public async Task<Permiso> ModificarPermisoAsync(int id, Permiso permiso)
        {
            Permiso permisoDB = await GetPermisoIdAsync(id);

            if (permisoDB == null)
            {
                return permisoDB;
            }

            permisoDB.NombreEmpleado = permiso.NombreEmpleado;
            permisoDB.ApellidoEmpleado = permiso.ApellidoEmpleado;
            permisoDB.TipoPermisoId = permiso.TipoPermisoId;
            permisoDB.FechaPermiso = permiso.FechaPermiso;

            _N5DbContext.Entry(permisoDB, EntityState.Modified);
            await _N5DbContext.SaveChanges();

            return permisoDB;
        }

        public Permiso QuitarPermiso(int id)
        {
            Permiso permiso = GetPermisoId(id);

            if (permiso != null)
            {
                _N5DbContext.Entry(permiso, EntityState.Deleted);
                _N5DbContext.SaveChanges();
            }

            return permiso;
        }

        public async Task<Permiso> QuitarPermisoAsync(int id)
        {
            Permiso permiso = await GetPermisoIdAsync(id);

            if (permiso != null)
            {
                _N5DbContext.Entry(permiso, EntityState.Deleted);
                await _N5DbContext.SaveChanges();
            }

            return permiso;
        }

        public Permiso RegistrarPermiso(Permiso permiso)
        {
            _N5DbContext.Permisos.Add(permiso);
            _N5DbContext.SaveChanges();

            return permiso;
        }

        public async Task<Permiso> RegistrarPermisoAsync(Permiso permiso)
        {
            _N5DbContext.Permisos.Add(permiso);
            await _N5DbContext.SaveChanges();

            return permiso;
        }
    }
}
