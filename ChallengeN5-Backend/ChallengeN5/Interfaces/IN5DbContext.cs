using ChallengeN5.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeN5.Interfaces
{
    public interface IN5DbContext
    {
        DbSet<Permiso> Permisos { get; set; }

        DbSet<TipoPermiso> TipoPermisos { get; set; }

        Task<int> SaveChanges();

        void Entry<T>(T entity, EntityState entityState);
    }
}
