using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ChallengeN5.Interfaces
{
    public interface IChallengeN5Context
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

    }
}
