using General.CrossCutting.Lib;

using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface ITemporadaPremiosRepository : IBaseRepository<TemporadaPremiosDTO>
    {
        Task<ICollection<TemporadaPremiosDTO>> GetPremiosByTemporada(int id);
    }
}