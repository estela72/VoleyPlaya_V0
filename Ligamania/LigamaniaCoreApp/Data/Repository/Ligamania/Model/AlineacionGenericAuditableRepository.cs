using LigamaniaCoreApp.Data.DataModels.Base.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public abstract class AlineacionGenericAuditableRepository<T> : GenericAuditableRepository<T>, 
        IAlineacionGenericAuditableRepository<T> where T : AuditableEntity
    {
        public AlineacionGenericAuditableRepository(ApplicationDbContext context) : base(context)
        {
        }

        public int GetLastId()
        {
            int? lastId = _dbset.Max(x => (int?)x.Id);
            return lastId ?? 0;
        }        

    }
}
