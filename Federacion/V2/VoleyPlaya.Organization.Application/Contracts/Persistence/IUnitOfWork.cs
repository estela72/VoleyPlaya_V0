using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Organization.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ITemporadaRepository TemporadaRepository { get; }
        ITablaRepository TablaRepository { get; }                
        IEquipoRepository EquipoRepository { get; }
        ICompeticionRepository CompeticionRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }

        Task<int> Complete();
    }
}
