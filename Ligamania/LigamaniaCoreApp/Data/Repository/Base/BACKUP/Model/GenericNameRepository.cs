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
    public abstract class GenericNameRepository<T> : GenericIdRepository<T>, IGenericNameRepository<T> where T : NameEntity
    {
        protected GenericNameRepository(DbContext context) : base(context)
        {
        }

        public T GetByName(string name)
        {
            return _dbset.FirstOrDefault(x => x.Nombre.Equals(name));
        }

        public async Task<T> GetByNameAsync(string name)
        {
            return await _dbset.FirstOrDefaultAsync(x => x.Nombre.Equals(name));
        }
    }
}
