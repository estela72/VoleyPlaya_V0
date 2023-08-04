using GenericLib;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.Contracts.Persistence;
using VoleyPlaya.Management.Infraestructure.Persistence;
using VoleyPlaya.Management.Infraestructure.Repositories;

namespace VoleyPlaya.Organization.Infraestructure.Persistence
{
    public class UnitOfWorkManagement : UnitOfWork, IUnitOfWorkManagement
    {
        private IEdicionRepository? _edicionRepository;
        private IEdicionGrupoRepository? _edicionGrupoRepository;
        private IJornadaRepository? _jornadaRepository;
        private IPartidoRepository? _partidoRepository;

        public UnitOfWorkManagement(VoleyPlayaManagementContext context) : base(context)
        {
        }

        public IEdicionRepository EdicionRepository => _edicionRepository ??= new EdicionRepository(_context);

        public IEdicionGrupoRepository EdicionGrupoRepository => _edicionGrupoRepository ??= new EdicionGrupoRepository(_context);

        public IJornadaRepository JornadaRepository => _jornadaRepository ??= new JornadaRepository(_context);

        public IPartidoRepository PartidoRepository => _partidoRepository ??= new PartidoRepository(_context);
    }
}
