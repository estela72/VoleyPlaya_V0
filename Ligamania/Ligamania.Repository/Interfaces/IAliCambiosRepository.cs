using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface IAlineacionCambiosRepository : IAlineacionRepository<AlineacionCambioDTO>
    {
        Task<AlineacionCambioDTO> GetByJugador(int competicionId, int categoriaId, int equipoId, string jugador);

        Task<ICollection<AlineacionCambioDTO>> GetAllAlineacionesCompeticion(int competicionid);
    }
}