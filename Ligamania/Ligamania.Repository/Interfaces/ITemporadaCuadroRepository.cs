using General.CrossCutting.Lib;

using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface ITemporadaCuadroRepository : IRepository<TemporadaCuadroDTO>
    {
        Task<TemporadaCuadroDTO> GetLastPartidoCuadro(int temporadaId, int competicionId);

        Task<List<TemporadaCuadroDTO>> GetCuadro(int temporadaId, int competicionId);
    }
}