using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace General.CrossCutting.Lib
{
    public interface IBaseRepository<T> where T : IBaseEntity
    {
        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);

        T Get(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> match);

        Task<int> Count();

        Task<IEnumerable<T>> GetAllAsync();

        Task<bool> DeleteAsync(int id);

        Task<T> GetByIdAsync(int id);

        T GetById(int id);

        //por compatibilidad
        Task<T> FindAsync(Expression<Func<T, bool>> match);

        //por compatibilidad
        IQueryable<T> FindAllQueryable(Expression<Func<T, bool>> match);

        Task<ICollection<T>> FindAllIncludingAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> GetAll();

        Task<IQueryable<T>> GetAllIncludingAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<IQueryable<T>> GetAllQueryableAsync();
        Task<T> AddAsyn(T entity);

        Task<T> UpdateAsyn(T entity, int id);

        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);

        T Find(Expression<Func<T, bool>> match);

        ICollection<T> FindAll(Expression<Func<T, bool>> match);

        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);

        Task<T> FindIncludingAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties);

        Task<IQueryable<T>> FindAllQueryableIncludingAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
    }
    public interface IRepository<T> : IBaseRepository<T> where T : IEntity
    {
        Task<T> GetByNameAsync(string name);
        T GetByName(string name);
    }

    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DbContext _dbContext;
        private DbSet<T> _dbSet;
        private readonly ILogger _logger;
        protected ILogger Logger { get => _logger ?? throw new ArgumentNullException(nameof(_logger)); }
        
        protected DbContext Context { get { return _dbContext; } }

        protected DbSet<T> DbSet
        {
            get => _dbSet ?? (_dbSet = _dbContext.Set<T>());
        }
        public BaseRepository(DbContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<T>();
        }

        public BaseRepository(DbContext context, ILogger logger)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<T>();
            _logger = logger;
        }

        public async Task<int> Count()
        {
            return await DbSet.CountAsync();
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            var added = await DbSet.AddAsync(entity);
            return added.Entity;
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> match)
        {
            var exists = await DbSet.AnyAsync(match);
            return exists;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            if (entity == null) return default;
            if (!await ExistsAsync(e => e.Id.Equals(entity.Id))) return default;
            var existingEntity = await GetAsync(e => e.Id.Equals(entity.Id));
            _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            return existingEntity;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync() => await Task.FromResult(DbSet);

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

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var entity = await GetAsync(e => e.Id.Equals(id));
            return entity;
        }

        public virtual T GetById(int id)
        {
            var entity = DbSet.SingleOrDefault(e => e.Id.Equals(id));
            return entity;
        }
        public virtual T Get(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = DbSet.Where(match);
            if (queryable == null) return null;
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }
            return queryable.SingleOrDefault();
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties)
        { 
            IQueryable<T> queryable = DbSet.Where(match);
            if (queryable == null) return null;
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }
            return await queryable.SingleOrDefaultAsync().ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties)
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

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await GetAsync(match);
        }

        public virtual IQueryable<T> FindAllQueryable(Expression<Func<T, bool>> match)
        {
            return DbSet.Where(match);
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

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }
        public async Task<IQueryable<T>> GetAllQueryableAsync()
        {
            IQueryable<T> queryable = GetAll();
            if (queryable == null) return null;
            return await Task.FromResult(queryable).ConfigureAwait(false);
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

        public async Task<T> AddAsyn(T entity)
        {
            return await CreateAsync(entity);
        }

        public async Task<T> UpdateAsyn(T entity, int id)
        {
            return await UpdateAsync(entity);
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await DbSet.Where(match).ToListAsync().ConfigureAwait(false);
        }

        public virtual T Find(Expression<Func<T, bool>> match)
        {
            return DbSet.SingleOrDefault(match);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return DbSet.Where(match).ToList();
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


        //public Task<T> FindIncludingAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties)
        //{
        //    throw new NotImplementedException();
        //}
        public async Task<T> FindIncludingAsync(Expression<Func<T, bool>> predicado, params Expression<Func<T, object>>[] propiedadesIncluidas)
        {
            var entity = _dbContext.Set<T>().AsQueryable();

            // Aplicar el predicado de búsqueda
            entity = entity.Where(predicado).AsQueryable<T>();

            // Incluir propiedades de navegación
            foreach (var propiedad in propiedadesIncluidas)
            {
                entity = entity.Include(propiedad);
            }

            return await entity.SingleOrDefaultAsync();
        }

        //public async Task<T> FindIncludingAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties)
        //{
        //    var entity = await FindAsync(match).ConfigureAwait(false);
        //    if (entity == null) return null;
        //    foreach (Expression<Func<T, object>> includeProperty in includeProperties)
        //    {
        //        await _dbContext.Entry(entity).Reference(includeProperty).LoadAsync().ConfigureAwait(false);
        //    }
        //    return entity;
        //}

        public async Task<IQueryable<T>> FindAllQueryableIncludingAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = FindAllQueryable(match);
            if (queryable == null) return null;
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }
            return await Task.FromResult(queryable);
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = DbSet.Where(predicate);
            return query;
        }
    }

    public abstract class Repository<T> :  BaseRepository<T>, IRepository<T> where T : Entity
    {
        public Repository(DbContext context) : base(context)
        {
        }

        public Repository(DbContext context, ILogger logger) : base(context, logger)
        {
        }

        public T GetByName(string name)
        {
            var entity = Get(e => e.Nombre.Equals(name));
            return entity;
        }
        public async Task<T> GetByNameAsync(string name)
        {
            var entity = await GetAsync(e => e.Nombre.Equals(name));
            return entity;
        }
    }
}