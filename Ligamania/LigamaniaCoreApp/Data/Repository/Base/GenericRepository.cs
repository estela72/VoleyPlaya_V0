using LigamaniaCoreApp.Data.DataModels.Base.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.Repository.Base
{

    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected ApplicationDbContext _entities;
        protected DbSet<T> _dbset;
        public GenericRepository(ApplicationDbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _entities.Set<T>();
        }

        public virtual async Task<ICollection<T>> GetAllAsyn()
        {

            return await _entities.Set<T>().ToListAsync().ConfigureAwait(false);
        }

        public virtual T Get(int id)
        {
            return _entities.Set<T>().Find(id);
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await _entities.Set<T>().FindAsync(id).ConfigureAwait(false);
        }

        public virtual T Add(T t)
        {

            _entities.Set<T>().Add(t);
            //_entities.SaveChanges();
            return t;
        }

        public virtual async Task<T> AddAsyn(T t)
        {
            await _entities.Set<T>().AddAsync(t).ConfigureAwait(false);
            //await _entities.SaveChangesAsync();
            return t;

        }
        public void AddRange(ICollection<T> entities)
        {
            _entities.Set<T>().AddRange(entities);
        }
        public async Task AddRangeAsyn(ICollection<T> entities)
        {
            await _entities.Set<T>().AddRangeAsync(entities).ConfigureAwait(false);
        }

        public virtual T Find(Expression<Func<T, bool>> match)
        {
            return _entities.Set<T>().SingleOrDefault(match);
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _entities.Set<T>().SingleOrDefaultAsync(match).ConfigureAwait(false);
        }

        public virtual bool Exists(Expression<Func<T, bool>> match)
        {
            var entity = _entities.Set<T>().SingleOrDefault(match);
            return entity != null;
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> match)
        {
            var entity = await _entities.Set<T>().SingleOrDefaultAsync(match).ConfigureAwait(false);
            return entity != null;
        }

        public async Task<T> FindIncludingAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties)
        {
            var entity = await FindAsync(match).ConfigureAwait(false);
            if (entity == null) return null;
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                await _entities.Entry(entity).Reference(includeProperty).LoadAsync().ConfigureAwait(false);
            }
            return entity;
        }
        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _entities.Set<T>().Where(match).ToList();
        }
        public IQueryable<T> FindAllQueryable(Expression<Func<T, bool>> match)
        {
            return _entities.Set<T>().Where(match);
        }
        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _entities.Set<T>().Where(match).ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the first or default entity based on a predicate, orderby delegate and include delegate. This method default no-tracking query.
        /// </summary>
        /// <param name="selector">The selector for projection.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="orderBy">A function to order elements.</param>
        /// <param name="include">A function to include navigation properties</param>
        /// <param name="disableTracking"><c>True</c> to disable changing tracking; otherwise, <c>false</c>. Default to <c>true</c>.</param>
        /// <returns>An <see cref="IPagedList{TEntity}"/> that contains elements that satisfy the condition specified by <paramref name="predicate"/>.</returns>
        /// <remarks>This method default no-tracking query.</remarks>
        public TResult GetFirstOrDefault<TResult>(Expression<Func<T, TResult>> selector,
                                                  Expression<Func<T, bool>> predicate = null,
                                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                  Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                                  bool disableTracking = true)
        {
            IQueryable<T> query = _dbset;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return orderBy(query).Select(selector).FirstOrDefault();
            }
            else
            {
                return query.Select(selector).FirstOrDefault();
            }
        }
        /// <summary>
        /// Gets the first or default entity based on a predicate, orderby delegate and include delegate. This method default no-tracking query.
        /// </summary>
        /// <param name="selector">The selector for projection.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="orderBy">A function to order elements.</param>
        /// <param name="include">A function to include navigation properties</param>
        /// <param name="disableTracking"><c>True</c> to disable changing tracking; otherwise, <c>false</c>. Default to <c>true</c>.</param>
        /// <returns>An <see cref="IPagedList{TEntity}"/> that contains elements that satisfy the condition specified by <paramref name="predicate"/>.</returns>
        /// <remarks>This method default no-tracking query.</remarks>
        public ICollection<TResult> GetAll<TResult>(Expression<Func<T, TResult>> selector,
                                                  Expression<Func<T, bool>> predicate = null,
                                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                  Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                                  bool disableTracking = true)
        {
            IQueryable<T> query = _dbset;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return orderBy(query).Select(selector).ToList();
            }
            else
            {
                return query.Select(selector).ToList();
            }
        }
        public async Task<ICollection<T>> FindAllIncludingAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = FindAllQueryable(match);
            if (queryable == null) return null;

            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }

            return await queryable.ToListAsync().ConfigureAwait(false);
        }
        public async Task<IQueryable<T>> FindAllQueryableIncludingAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = FindAllQueryable(match);
            if (queryable == null) return null;
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }
            return queryable;
        }

        public virtual void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
            //_entities.SaveChanges();
        }

        public virtual async Task<int> DeleteAsyn(T entity)
        {
            _entities.Set<T>().Remove(entity);
            return 1;
            //return await _entities.SaveChangesAsync();
        }

        public void DeleteRange(ICollection<T> entities)
        {
            _entities.Set<T>().RemoveRange(entities);
        }
        public async Task DeleteRangeAsyn(ICollection<T> entities)
        {
            _entities.Set<T>().RemoveRange(entities);
        }

        public virtual T Update(T t, object key)
        {
            if (t == null)
                return null;
            T exist = _entities.Set<T>().Find(key);
            if (exist != null)
            {
                _entities.Entry(exist).CurrentValues.SetValues(t);
                //_entities.SaveChanges();
            }
            return exist;
        }

        public virtual async Task<T> UpdateAsyn(T t, object key)
        {
            if (t == null)
                return null;
            T exist = await _entities.Set<T>().FindAsync(key).ConfigureAwait(false);
            if (exist != null)
            {
                _entities.Entry(exist).CurrentValues.SetValues(t);
                //await _entities.SaveChangesAsync();
            }
            return exist;
        }

        public int Count()
        {
            return _entities.Set<T>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _entities.Set<T>().CountAsync().ConfigureAwait(false);
        }

        public async Task<int> CountMatchAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entities.Set<T>().Where(predicate).CountAsync().ConfigureAwait(false);
        }

        public virtual void Save()
        {
            _entities.SaveChanges(true);
        }

        public async virtual Task<int> SaveAsync()
        {
            return await _entities.SaveChangesAsync(true, default).ConfigureAwait(false);
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual async Task<ICollection<T>> FindByAsyn(Expression<Func<T, bool>> predicate)
        {
            return await _entities.Set<T>().Where(predicate).ToListAsync().ConfigureAwait(false);
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = GetAll();
            if (queryable == null) return null;
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }
            return queryable;
        }
        public async Task<IQueryable<T>> GetAllIncludingAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = GetAll();
            if (queryable == null) return null;
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }

            return await Task.FromResult(queryable).ConfigureAwait(false);
        }
        public async Task<ICollection<T>> GetAllListIncludingAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = await GetAllIncludingAsync(includeProperties).ConfigureAwait(false);
            return await queryable.ToListAsync().ConfigureAwait(false);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _entities.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void NotModified(T entity)
        {
            _entities.Entry(entity).State = EntityState.Unchanged;
        }

    }

    public class GenericIdRepository<T> : GenericRepository<T>, IGenericIdRepository<T> where T : Entity
    {
        public GenericIdRepository(ApplicationDbContext context) : base(context)
        {
        }

        public T GetById(int id)
        {
            return Get(id);
        }
        public async Task<T> GetByIdIncludingAsync(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = _entities.Set<T>().Where(e => e.Id.Equals(id));
            if (queryable == null) return null;
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }

            return await queryable.SingleOrDefaultAsync().ConfigureAwait(false);
        }


    }
    public class GenericNameRepository<T> : GenericIdRepository<T>, IGenericNameRepository<T> where T : EntityName
    {
        public GenericNameRepository(ApplicationDbContext context) : base(context)
        {
        }

        public T GetByName(string name)
        {
            //var entities = _dbset.Where(x => x.Nombre == name);
            //if (entities.Count() == 1)
            //    return entities.FirstOrDefault();
            //return null;
            var entity = Find(e => e.Nombre.Equals(name));
            return entity;
        }

        public async Task<T> GetByNameAsync(string name)
        {
            var entity = await FindAsync(e => e.Nombre.Equals(name)).ConfigureAwait(false);
            return entity;
        }
        public async Task<T> GetByNameIncludingAsync(string name, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = _entities.Set<T>().Where(e => e.Nombre.Equals(name));
            if (queryable == null) return null;
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }

            return await queryable.SingleOrDefaultAsync().ConfigureAwait(false);
        }

    }

    public class GenericAuditableRepository<T> : GenericIdRepository<T>, IGenericAuditableIdRepository<T> where T : AuditableEntity
    {
        public GenericAuditableRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    public class GenericAuditableNameRepository<T> : GenericNameRepository<T>, IGenericAuditableNameRepository<T> where T : AuditableNameEntity
    {
        public GenericAuditableNameRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
