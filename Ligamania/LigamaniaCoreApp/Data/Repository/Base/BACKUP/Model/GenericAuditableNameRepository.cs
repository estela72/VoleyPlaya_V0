using LigamaniaCoreApp.Data.DataModels.Base.Model;
using LigamaniaCoreApp.Data.Repository.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LigamaniaCoreApp.Data.Repository.Base.Model
{
    public abstract class GenericAuditableNameRepository<T> : GenericNameRepository<T>, IGenericAuditableNameRepository<T> where T : AuditableNameEntity
    {
        protected GenericAuditableNameRepository(DbContext context) : base(context)
        {
        }
    }
}
