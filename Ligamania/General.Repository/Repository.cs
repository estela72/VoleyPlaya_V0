using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace General.CrossCutting.Lib
{
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    public interface IBaseRepository<T> where T : IBaseEntity
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    {
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        Task<T> CreateAsync(T entity);
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        Task<T> UpdateAsync(T entity);
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        T Get(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties);
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        Task<T> GetAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties);
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        Task<bool> ExistsAsync(Expression<Func<T, bool>> match);
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        Task<int> Count();
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        Task<IEnumerable<T>> GetAllAsync();
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        Task<bool> DeleteAsync(int id);
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        Task<T> GetByIdAsync(int id);
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        T GetById(int id);
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

        //por compatibilidad
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        Task<T> FindAsync(Expression<Func<T, bool>> match);
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

        //por compatibilidad
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        IQueryable<T> FindAllQueryable(Expression<Func<T, bool>> match);
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        Task<ICollection<T>> FindAllIncludingAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties);
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        IQueryable<T> GetAll();
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        Task<IQueryable<T>> GetAllIncludingAsync(params Expression<Func<T, object>>[] includeProperties);
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        Task<T> AddAsyn(T entity);
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        Task<T> UpdateAsyn(T entity, int id);
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        T Find(Expression<Func<T, bool>> match);
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        ICollection<T> FindAll(Expression<Func<T, bool>> match);
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        Task<T> FindIncludingAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties);
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        Task<IQueryable<T>> FindAllQueryableIncludingAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties);
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    }
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    public interface IRepository<T> : IBaseRepository<T> where T : IEntity
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    {
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        Task<T> GetByNameAsync(string name);
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        T GetByName(string name);
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    {
        private readonly DbContext _dbContext;
        private DbSet<T> _dbSet;
        private readonly ILogger _logger;
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        protected ILogger Logger { get => _logger ?? throw new ArgumentNullException(nameof(_logger)); }
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        protected DbSet<T> DbSet
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            get => _dbSet ?? (_dbSet = _dbContext.Set<T>());
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public BaseRepository(DbContext context)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<T>();
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public BaseRepository(DbContext context, ILogger logger)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<T>();
            _logger = logger;
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public async Task<int> Count()
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            return await DbSet.CountAsync();
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public virtual async Task<T> CreateAsync(T entity)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            var added = await DbSet.AddAsync(entity);
            return added.Entity;
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> match)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            var exists = await DbSet.AnyAsync(match);
            return exists;
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public virtual async Task<T> UpdateAsync(T entity)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            if (entity == null) return default;
            if (!await ExistsAsync(e => e.Id.Equals(entity.Id))) return default;
            var existingEntity = await GetAsync(e => e.Id.Equals(entity.Id));
            _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            return existingEntity;
        }
/// <inheritdoc/>

        public virtual async Task<IEnumerable<T>> GetAllAsync() => await Task.FromResult(DbSet);
/// <inheritdoc/>

        public virtual async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != default)
            {
                DbSet.Remove(entity);
                return true;
            }
            return false;
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public virtual async Task<T> GetByIdAsync(int id)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            var entity = await GetAsync(e => e.Id.Equals(id));
            return entity;
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public virtual T GetById(int id)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            var entity = DbSet.SingleOrDefault(e => e.Id.Equals(id));
            return entity;
        }
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public virtual T Get(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            IQueryable<T> queryable = DbSet.Where(match);
            if (queryable == null) return null;
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }
            return queryable.SingleOrDefault();
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        { 
            IQueryable<T> queryable = DbSet.Where(match);
            if (queryable == null) return null;
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }
            return await queryable.SingleOrDefaultAsync().ConfigureAwait(false);
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            var entities = await DbSet.Where(match).ToListAsync().ConfigureAwait(false);
            foreach (var entity in entities)
            {
                foreach (Expression<Func<T, object>> includeProperty in includeProperties)
                {
                    await _dbContext.Entry(entity).Reference(includeProperty).LoadAsync();
                }
            }
            return entities;
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> match)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            return await GetAsync(match);
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public virtual IQueryable<T> FindAllQueryable(Expression<Func<T, bool>> match)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            return DbSet.Where(match);
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public async Task<ICollection<T>> FindAllIncludingAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            IQueryable<T> queryable = FindAllQueryable(match);
            if (queryable == null) return null;

            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }

            return await queryable.ToListAsync().ConfigureAwait(false);
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public IQueryable<T> GetAll()
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            return DbSet;
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public async Task<IQueryable<T>> GetAllIncludingAsync(params Expression<Func<T, object>>[] includeProperties)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            IQueryable<T> queryable = GetAll();
            if (queryable == null) return null;
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }

            return await Task.FromResult(queryable).ConfigureAwait(false);
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public async Task<T> AddAsyn(T entity)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            return await CreateAsync(entity);
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public async Task<T> UpdateAsyn(T entity, int id)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            return await UpdateAsync(entity);
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            return await DbSet.Where(match).ToListAsync().ConfigureAwait(false);
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public virtual T Find(Expression<Func<T, bool>> match)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            return DbSet.SingleOrDefault(match);
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            return DbSet.Where(match).ToList();
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            IQueryable<T> queryable = GetAll();
            if (queryable == null) return null;
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }
            return queryable;
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public async Task<T> FindIncludingAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            var entity = await FindAsync(match).ConfigureAwait(false);
            if (entity == null) return null;
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                await _dbContext.Entry(entity).Reference(includeProperty).LoadAsync().ConfigureAwait(false);
            }
            return entity;
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public async Task<IQueryable<T>> FindAllQueryableIncludingAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            IQueryable<T> queryable = FindAllQueryable(match);
            if (queryable == null) return null;
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }
            return await Task.FromResult(queryable);
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            IQueryable<T> query = DbSet.Where(predicate);
            return query;
        }
    }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    public abstract class Repository<T> :  BaseRepository<T>, IRepository<T> where T : Entity
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    {
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public Repository(DbContext context) : base(context)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public Repository(DbContext context, ILogger logger) : base(context, logger)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public T GetByName(string name)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            var entity = Get(e => e.Nombre.Equals(name));
            return entity;
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public async Task<T> GetByNameAsync(string name)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            var entity = await GetAsync(e => e.Nombre.Equals(name));
            return entity;
        }
    }
}