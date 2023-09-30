using ChallengeN5.Context;
using ChallengeN5.Interfaces;
using ChallengeN5.Models;

namespace ChallengeN5.Repository
{
    public class TiposPermisoRepository : GenericRepository<TipoPermiso>, ITiposPermisoRepository
    {
        public TiposPermisoRepository(ChallengeN5Context dbContext) : base(dbContext)
        {
        }
    }
}
