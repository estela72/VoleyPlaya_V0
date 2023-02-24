using LigamaniaCoreApp.Data.DataModels.Base.Model;
using LigamaniaCoreApp.Data.Repository.Base.Model;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;

using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public abstract class GenericAuditableAlineacionRepository<T> : GenericAuditableRepository<T>, 
        IGenericAuditableAlineacionRepository<T> where T : AuditableEntity
    {
        protected GenericAuditableAlineacionRepository(DbContext context) : base(context)
        {
        }

        public int GetLastId()
        {
            int? lastId = _dbset.Max(x => (int?)x.Id);
            return lastId ?? 0;
        }

        public async Task<int> GetLastIdAsync()
        {
            int? lastId = await _dbset.MaxAsync(x => (int?)x.Id);
            return lastId ?? 0;
        }
    }
}
