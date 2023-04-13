using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace General.CrossCutting.Lib
{
    public interface IUnitOfWork : IDisposable
    {
        Task<EntityEntry> GetEntityEntry(Entity entity);
        Task<int> SaveMauiChangesAsync();
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }

    public abstract class UnitOfWork : IUnitOfWork, IDisposable
    {
        protected readonly DbContext _context;
        protected readonly ILogger _logger;
        public string DEFAULT_SCHEMA = "";
        private IDbContextTransaction _currentTransaction;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Recibe la configuración del proyecto
        /// </summary>
        protected IConfiguration Configuration { get { return _configuration; } }

        /// <summary>
        /// Clase UnitOfWork para aislar el contexto y repositorios de acceso a base de datos
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="context"></param>
        /// <param name="loggerFactory"></param>
        public UnitOfWork(IConfiguration configuration, DbContext context, ILoggerFactory loggerFactory)
        {
            _configuration = configuration;
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
        }

        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;

        private Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var httpContextAccessor = _context.GetService<IHttpContextAccessor>();
                var userId = httpContextAccessor.HttpContext?.User
                                       .FindFirst(ClaimTypes.NameIdentifier).Value;

                var modifiedEntries = _context.ChangeTracker.Entries()
                    .Where(x => x.Entity is IBaseEntity
                        && (x.State == EntityState.Added || x.State == EntityState.Modified));

                foreach (var entry in modifiedEntries)
                {
                    if (entry.Entity is IBaseEntity entity)
                    {
                        string userName = userId;
                        if (string.IsNullOrEmpty(userName)) userName = "-";
                        DateTime now = DateTime.UtcNow;

                        if (entry.State == EntityState.Added)
                        {
                            entity.CreatedBy = userName;
                            entity.CreatedDate = now;
                        }
                        else
                        {
                            _context.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                            _context.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                        }
                        entity.UpdatedBy = userName;
                        entity.UpdatedDate = now;
                    }
                }

                var entities = from e in _context.ChangeTracker.Entries()
                               where e.State == EntityState.Added
                                   || e.State == EntityState.Modified
                               select e.Entity;
                foreach (var entity in entities)
                {
                    var validationContext = new ValidationContext(entity);
                    Validator.ValidateObject(entity, validationContext);
                }

                return _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException updateConcException)
            {
                Console.WriteLine("error " + updateConcException);
                return null;
            }
            catch (DbUpdateException updateException)
            {
                Console.WriteLine("error " + updateException);
                return null;
            }
            catch(Exception x)
            {
                Console.WriteLine("error " + x);
                return null;
            }
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            // Dispatch Domain Events collection.
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions.
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers.
            //await _mediator.DispatchDomainEventsAsync(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers)
            // performed through the DbContext will be committed
            var result = await SaveChangesAsync(cancellationToken);

            return result > 0;
        }
        public Task<int> SaveMauiChangesAsync()
        {
            try
            {
                var modifiedEntries = _context.ChangeTracker.Entries()
                    .Where(x => x.Entity is IBaseEntity
                        && (x.State == EntityState.Added || x.State == EntityState.Modified));

                foreach (var entry in modifiedEntries)
                {
                    if (entry.Entity is IBaseEntity entity)
                    {
                        string userName = string.Empty;
                        DateTime now = DateTime.UtcNow;

                        if (entry.State == EntityState.Added)
                        {
                            entity.CreatedBy = userName;
                            entity.CreatedDate = now;
                        }
                        else
                        {
                            _context.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                            _context.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                        }
                        entity.UpdatedBy = userName;
                        entity.UpdatedDate = now;
                    }
                }

                var entities = from e in _context.ChangeTracker.Entries()
                               where e.State == EntityState.Added
                                   || e.State == EntityState.Modified
                               select e.Entity;
                foreach (var entity in entities)
                {
                    var validationContext = new ValidationContext(entity);
                    Validator.ValidateObject(entity, validationContext);
                }

                return _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException updateConcException)
            {
                Console.WriteLine("error " + updateConcException);
                return null;
            }
            catch (DbUpdateException updateException)
            {
                Console.WriteLine("error " + updateException);
                return null;
            }
            catch (Exception x)
            {
                Console.WriteLine("error " + x);
                return null;
            }
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await _context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        void IDisposable.Dispose()
        {
            _context.Dispose();
        }
        public async Task<EntityEntry> GetEntityEntry(Entity entity)
        {
            return await Task.FromResult(_context.Entry(entity));
        }
    }
}