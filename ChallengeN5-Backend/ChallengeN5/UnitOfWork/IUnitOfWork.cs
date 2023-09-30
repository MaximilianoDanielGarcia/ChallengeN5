using ChallengeN5.Interfaces;

namespace ChallengeN5.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPermisosRepository Permisos { get;  }

        ITiposPermisoRepository TiposPermiso { get; }
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }

}
