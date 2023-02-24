using LigamaniaCoreApp.Data.DataModels.Base.Model;
using LigamaniaCoreApp.Data.Repository.Base;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{
    public interface IAlineacionGenericAuditableRepository<T> : IGenericAuditableIdRepository<T> 
        where T: AuditableEntity
    {
        int GetLastId();
    }
}
