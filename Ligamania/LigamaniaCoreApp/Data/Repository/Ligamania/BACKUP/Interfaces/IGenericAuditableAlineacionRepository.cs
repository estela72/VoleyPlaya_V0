using LigamaniaCoreApp.Data.DataModels.Base.Model;
using LigamaniaCoreApp.Data.Repository.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{
    public interface IGenericAuditableAlineacionRepository<T> : IGenericAuditableIdRepository<T> 
        where T: AuditableEntity
    {
        int GetLastId();
        Task<int> GetLastIdAsync();
    }
}
