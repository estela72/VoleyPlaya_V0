using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{
    public interface IAlineacionCambiosRepository : IAlineacionGenericAuditableRepository<AlineacionCambioDTO>
    {
        Task<AlineacionCambioDTO> GetByJugador(int competicionId, int categoriaId, int equipoId, string jugador);
        Task<ICollection<AlineacionCambioDTO>> GetAllAlineacionesCompeticion(int competicionid);
    }
}
