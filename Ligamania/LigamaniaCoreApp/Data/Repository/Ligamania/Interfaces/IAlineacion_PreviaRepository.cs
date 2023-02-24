using System.Collections.Generic;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{
    public interface IAlineacionPreviaRepository : IAlineacionGenericAuditableRepository<AlineacionPreviaDTO>
    {
        Task<ICollection<AlineacionPreviaDTO>> GetAllAlineacionesCompeticion(int competicionid);
    }
}
