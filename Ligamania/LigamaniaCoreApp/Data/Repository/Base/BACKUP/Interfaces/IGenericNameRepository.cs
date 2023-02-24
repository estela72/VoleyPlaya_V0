using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.Repository.Base.Interfaces
{
    public interface IGenericNameRepository<T> : IGenericIdRepository<T> where T: NameEntity
    {
        T GetByName(string name);
        Task<T> GetByNameAsync(string name);
    }
}
