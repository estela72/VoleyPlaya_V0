using System.Collections.Generic;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{
    public interface ITemporadaCuadroRepository : IGenericAuditableIdRepository<TemporadaCuadroDTO>
    {
        Task<TemporadaCuadroDTO> GetLastPartidoCuadro(int temporadaId, int competicionId);
        Task<List<TemporadaCuadroDTO>> GetCuadro(int temporadaId, int competicionId);
    }
}
