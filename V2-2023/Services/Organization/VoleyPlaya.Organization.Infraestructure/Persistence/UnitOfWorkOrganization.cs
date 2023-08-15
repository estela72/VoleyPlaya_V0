using Common.Infraestructure.Repositories;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Infraestructure.Repositories;

namespace VoleyPlaya.Organization.Infraestructure.Persistence
{
    public class UnitOfWorkOrganization : UnitOfWork, IUnitOfWorkOrganization
    {
        private ITemporadaRepository? _temporadaRepository;
        private ITablaRepository? _tablaRepository;
        private IEquipoRepository? _equipoRepository;
        private ICompeticionRepository? _competicionRepository;
        private ICategoriaRepository? _categoriaRepository;

        public UnitOfWorkOrganization(VoleyPlayaOrganizationContext context) : base(context)
        {
        }

        public ITemporadaRepository TemporadaRepository => _temporadaRepository ??= new TemporadaRepository(_context);

        public ITablaRepository TablaRepository => _tablaRepository ??= new TablaRepository(_context);

        public IEquipoRepository EquipoRepository => _equipoRepository ??= new EquipoRepository(_context);

        public ICompeticionRepository CompeticionRepository => _competicionRepository ??= new CompeticionRepository(_context);

        public ICategoriaRepository CategoriaRepository => _categoriaRepository ??= new CategoriaRepository(_context);

    }
}
