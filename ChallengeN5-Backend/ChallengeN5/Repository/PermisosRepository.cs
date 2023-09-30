using ChallengeN5.Context;
using ChallengeN5.Interfaces;
using ChallengeN5.Models;

namespace ChallengeN5.Repository
{
    public class PermisosRepository : GenericRepository<Permiso>, IPermisosRepository
    {
        public PermisosRepository(ChallengeN5Context dbContext) : base(dbContext)
        {
        }
    }
}
