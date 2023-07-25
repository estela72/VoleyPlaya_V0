using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.Contracts.Persistence;
using VoleyPlaya.Management.Infraestructure.Persistence;

namespace VoleyPlaya.Management.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VoleyPlayaManagementContext _context;

        private IPartidoRepository? _partidoRepository;
        private IJornadaRepository? _jornadaRepository;
        private IEdicionRepository? _edicionRepository;
        private IEdicionGrupoRepository? _edicionGrupoRepository;

        public UnitOfWork(VoleyPlayaManagementContext context)
        {
            _context = context;
        }

        public VoleyPlayaManagementContext DataContext => _context;

        public IPartidoRepository PartidoRepository => _partidoRepository ??= new PartidoRepository(_context);

        public IJornadaRepository JornadaRepository => _jornadaRepository ??= new JornadaRepository(_context);

        public IEdicionRepository EdicionRepository => _edicionRepository ??= new EdicionRepository(_context);

        public IEdicionGrupoRepository EdicionGrupoRepository => _edicionGrupoRepository ??= new EdicionGrupoRepository(_context);

        public async Task<int> Complete()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred saving changes", ex);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
