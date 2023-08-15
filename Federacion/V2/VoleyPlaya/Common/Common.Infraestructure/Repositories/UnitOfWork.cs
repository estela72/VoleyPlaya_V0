using Common.Application.Contracts.Persistence;
using Common.Domain;
using Common.Infraestructure.Persistence;

using Microsoft.EntityFrameworkCore;

using System.Security.Principal;
using System.Threading;

namespace Common.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly GenericDbContext _context;

        public UnitOfWork(GenericDbContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public GenericDbContext DataContext => _context;
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
        
    }
}
