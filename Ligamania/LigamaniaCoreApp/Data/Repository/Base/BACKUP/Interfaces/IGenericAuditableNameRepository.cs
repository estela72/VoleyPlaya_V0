using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.Repository.Base.Interfaces
{
    public interface IGenericAuditableNameRepository<T> : IGenericNameRepository<T> where T : AuditableNameEntity
    {
    }
}
