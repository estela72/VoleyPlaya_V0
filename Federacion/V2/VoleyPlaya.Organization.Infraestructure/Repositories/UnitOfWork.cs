using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Infraestructure.Persistence;

namespace VoleyPlaya.Organization.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VoleyPlayaOrganizationContext _context;

        private ITemporadaRepository? _temporadaRepository;
        private ITablaRepository? _tablaRepository;
        private IEquipoRepository? _equipoRepository;
        private ICompeticionRepository? _competicionRepository;
        private ICategoriaRepository? _categoriaRepository;

        public UnitOfWork(VoleyPlayaOrganizationContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public VoleyPlayaOrganizationContext DataContext => _context;

        public ITemporadaRepository TemporadaRepository => _temporadaRepository ??= new TemporadaRepository(_context);

        public ITablaRepository TablaRepository => _tablaRepository ??= new TablaRepository(_context);

        public IEquipoRepository EquipoRepository => _equipoRepository ??= new EquipoRepository(_context);

        public ICompeticionRepository CompeticionRepository => _competicionRepository ??= new CompeticionRepository(_context);

        public ICategoriaRepository CategoriaRepository => _categoriaRepository ??= new CategoriaRepository(_context);

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
    }
}
