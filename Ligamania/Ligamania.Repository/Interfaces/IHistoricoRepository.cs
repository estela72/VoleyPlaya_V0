using General.CrossCutting.Lib;

using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface IHistoricoRepository : IRepository<HistoricoDTO>
    {
        Task<ICollection<HistoricoDTO>> GetHistorial();

        Task<ICollection<HistoricoDTO>> GetHistoriaEquipo(string equipo);
    }
}