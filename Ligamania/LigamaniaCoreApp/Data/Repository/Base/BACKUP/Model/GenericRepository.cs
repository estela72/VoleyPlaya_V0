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
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected DbContext _entities;
        protected readonly DbSet<T> _dbset;

        protected GenericRepository(DbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public ICollection<T> GetAll()
        {
            return _entities.Set<T>().ToList();
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _entities.Set<T>().ToListAsync();
        }

        public T Get(int id)
        {
            return _entities.Set<T>().Find(id);
        }

        public async Task<T> GetAsync(int id)
        {
            return await _entities.Set<T>().FindAsync(id);
        }

        public bool Exists(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            bool exists = _dbset.Any(predicate);
            return exists;
        }
        public async Task<bool> ExistsAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            bool exists = await _dbset.AnyAsync(predicate);
            return exists;
        }
        ICollection<T> IGenericRepository<T>.FindBy(Expression<Func<T, bool>> predicate) => FindAll(predicate);

        public T Find(Expression<Func<T, bool>> match)
        {
            return _entities.Set<T>().SingleOrDefault(match);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _entities.Set<T>().SingleOrDefaultAsync(match);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _entities.Set<T>().Where(match).ToList();
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _entities.Set<T>().Where(match).ToListAsync();
        }

        public int Count()
        {
            return _entities.Set<T>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _entities.Set<T>().CountAsync();
        }

        public virtual T Add(T entity)
        {
            _entities.Entry(entity).State = EntityState.Added;
            return entity;
        }
        public virtual IEnumerable<T> AddRange(IEnumerable<T> entityRange)
        {
            _entities.Set<T>().AddRange(entityRange);
            return entityRange;
        }
        public virtual T Delete(T entity)
        {
            _entities.Entry(entity).State = EntityState.Deleted;
            return entity;
        }
        public virtual List<T> DeleteRange(List<T> entityRange)
        {
            _entities.Set<T>().RemoveRange(entityRange);
            return entityRange;
        }
        public virtual void Edit(T entity)
        {
            if (_entities.Entry(entity).State != EntityState.Modified)
                _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void NotModified(T entity)
        {
            _entities.Entry(entity).State = EntityState.Unchanged;
        }

        //public Task<T> AddAsync(T entity) => Task.Run(() => _entities.Set<T>().Add(entity));

        //public Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entityRange) => Task.Run(() => _entities.Set<T>().AddRange(entityRange));

        //public Task<T> DeleteAsync(T entity) => Task.Run(() => _entities.Set<T>().Remove(entity));

        public Task<ICollection<T>> DeleteRangeAsync(ICollection<T> entityRange)
        {
            var list = entityRange.ToList();
            Task<List<T>> task = Task.Run(() => DeleteRange(list));
            return task as Task<ICollection<T>>;
        }
        public Task EditAsync(T entity) => Task.Run(() => Edit(entity));

        public Task NotModifiedAsync(T entity) => Task.Run(() => NotModified(entity));
    }
}
