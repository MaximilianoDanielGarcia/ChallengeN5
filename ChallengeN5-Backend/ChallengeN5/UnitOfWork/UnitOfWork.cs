using ChallengeN5.Context;
using ChallengeN5.Interfaces;
using ChallengeN5.Repository;
using Microsoft.EntityFrameworkCore;

namespace ChallengeN5.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChallengeN5Context _dbContext;

        public IPermisosRepository Permisos { get; }

        public ITiposPermisoRepository TiposPermiso { get; }

        public UnitOfWork(ChallengeN5Context dbContext, IPermisosRepository permisosRepository, ITiposPermisoRepository iposPermisosRepository)
        {
            _dbContext = dbContext;
            Permisos = permisosRepository;
            TiposPermiso = iposPermisosRepository;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Rollback()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }

        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();   

        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
