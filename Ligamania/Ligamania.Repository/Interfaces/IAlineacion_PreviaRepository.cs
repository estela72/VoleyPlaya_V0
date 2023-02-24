using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface IAlineacionPreviaRepository : IAlineacionRepository<AlineacionPreviaDTO>
    {
        Task<ICollection<AlineacionPreviaDTO>> GetAllAlineacionesCompeticion(int competicionid);
    }
}