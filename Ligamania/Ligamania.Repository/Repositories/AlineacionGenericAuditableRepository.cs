using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;

using System.Linq;

namespace Ligamania.Repository.Repositories
{
    public abstract class AlineacionRepository<T> : Repository<T>, IAlineacionRepository<T> where T : Entity
    {
        public AlineacionRepository(LigamaniaDbContext context) : base(context)
        {
        }

        public int GetLastId()
        {
            int? lastId = DbSet.Max(x => (int?)x.Id);
            return lastId ?? 0;
        }
    }
}