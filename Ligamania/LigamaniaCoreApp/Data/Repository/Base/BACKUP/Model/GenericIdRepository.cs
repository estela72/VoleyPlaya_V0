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
    public abstract class GenericIdRepository<T> : GenericRepository<T>, IGenericIdRepository<T> where T : Entity
    {
        protected GenericIdRepository(DbContext context) : base(context)
        {
        }

        public T GetById(int id)
        {
            return _dbset.FirstOrDefault(x => x.Id.Equals(id));
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbset.FirstOrDefaultAsync(x=>x.Id.Equals(id));
        }
    }
}
