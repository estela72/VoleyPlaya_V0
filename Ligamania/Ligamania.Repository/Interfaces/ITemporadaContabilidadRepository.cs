using General.CrossCutting.Lib;

using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface ITemporadaContabilidadRepository : IBaseRepository<TemporadaContabilidadDTO>
    {
        Task<ICollection<TemporadaContabilidadDTO>> GetContabilidadByTemporada(int id);
        Task<ICollection<TemporadaContabilidadDTO>> GetContabilidades();
    }
}