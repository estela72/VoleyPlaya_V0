using Common.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Common.Application.Contracts.Persistence;

public interface IAsyncRepository<T> where T : IAggregateRoot
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
    Task<T?> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

    T AddEntity(T entity);
    void UpdateEntity(T entity);
    bool DeleteEntity(T entity);
    bool Exists(Expression<Func<T, bool>> predicate);
}
