using System.Collections.Generic;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{

    public interface IPuntuacionHistoricaRepository : IGenericAuditableIdRepository<PuntuacionHistoricaDTO>
    {
        int GetPuntuacion(int competicionId, int categoriaId, int puesto, bool pichichi);
        Task<ICollection<PuntuacionHistoricaDTO>> GetAllPuntuaciones();
    }
}
