using Common.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Management.Application.Contracts.Persistence
{
    public interface IUnitOfWorkManagement : IUnitOfWork 
    {
        IPartidoRepository PartidoRepository { get; }
        IJornadaRepository JornadaRepository { get; }                
        IEdicionRepository EdicionRepository { get; }
        IEdicionGrupoRepository EdicionGrupoRepository { get; }
    }
}
