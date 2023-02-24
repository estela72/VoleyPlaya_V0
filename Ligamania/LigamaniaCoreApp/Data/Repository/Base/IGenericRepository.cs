using LigamaniaCoreApp.Data.DataModels.Base.Model;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.Repository.Base
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        void Dispose();

        T Add(T t);
        Task<T> AddAsyn(T t);

        void AddRange(ICollection<T> entities);
        Task AddRangeAsyn(ICollection<T> entities);

        int Count();
        Task<int> CountAsync();
        Task<int> CountMatchAsync(Expression<Func<T, bool>> predicate);
        void Delete(T entity);
        Task<int> DeleteAsyn(T entity);

        void DeleteRange(ICollection<T> entities);
        Task DeleteRangeAsyn(ICollection<T> entities);

        T Find(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        Task<T> FindIncludingAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties);

        bool Exists(Expression<Func<T, bool>> match);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> match);


        ICollection<T> FindAll(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
        IQueryable<T> FindAllQueryable(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllIncludingAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> FindByAsyn(Expression<Func<T, bool>> predicate);

        T Get(int id);
        Task<T> GetAsync(int id);
        TResult GetFirstOrDefault<TResult>(Expression<Func<T, TResult>> selector,
                                                 Expression<Func<T, bool>> predicate = null,
                                                 Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                 Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                                 bool disableTracking = true);
        IQueryable<T> GetAll();
        ICollection<TResult> GetAll<TResult>(Expression<Func<T, TResult>> selector,
                                                 Expression<Func<T, bool>> predicate = null,
                                                 Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                 Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                                 bool disableTracking = true);
        Task<ICollection<T>> GetAllAsyn();
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        Task<IQueryable<T>> GetAllIncludingAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<ICollection<T>> GetAllListIncludingAsync(params Expression<Func<T, object>>[] includeProperties);
        void Save();
        Task<int> SaveAsync();
        T Update(T t, object key);
        Task<T> UpdateAsyn(T t, object key);

        void NotModified(T entity);
    }
    public interface IGenericCachedRepository<T>:IGenericRepository<T> where T: Entity
    {

    }
    public interface IGenericIdRepository<T> : IGenericCachedRepository<T> where T: Entity
    {
        T GetById(int id);
        Task<T> GetByIdIncludingAsync(int id, params Expression<Func<T, object>>[] includeProperties);

    }

    public interface IGenericNameRepository<T> : IGenericIdRepository<T> where T: EntityName
    {
        T GetByName(string name);
        Task<T> GetByNameAsync(string name);
        Task<T> GetByNameIncludingAsync(string name, params Expression<Func<T, object>>[] includeProperties);

    }

    public interface IGenericAuditableIdRepository<T> : IGenericIdRepository<T> where T : AuditableEntity
    {
    }
    
    public interface IGenericAuditableNameRepository<T> : IGenericNameRepository<T> where T : AuditableNameEntity
    {
    }
}
