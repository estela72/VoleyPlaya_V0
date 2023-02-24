using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.Repository.Base.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        ICollection<T> GetAll();
        Task<ICollection<T>> GetAllAsync();

        T Get(int id);
        Task<T> GetAsync(int id);

        bool Exists(Expression<Func<T, bool>> predicate);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

        ICollection<T> FindBy(Expression<Func<T, bool>> predicate);
        T Find(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        ICollection<T> FindAll(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);

        int Count();
        Task<int> CountAsync();

        T Add(T entity);
        //Task<T> AddAsync(T entity);

        IEnumerable<T> AddRange(IEnumerable<T> entityRange);
        //Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entityRange);

        T Delete(T entity);
        //Task<T> DeleteAsync(T entity);

        List<T> DeleteRange(List<T> entityRange);
        Task<ICollection<T>> DeleteRangeAsync(ICollection<T> entityRange);

        void Edit(T entity);
        Task EditAsync(T entity);

        void NotModified(T entity);
        Task NotModifiedAsync(T entity);
    }
}
