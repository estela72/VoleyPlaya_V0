using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{
    public interface ITemporadaRepository : IGenericAuditableNameRepository<TemporadaDTO>
    {
        TemporadaDTO GetActual();
        Task<TemporadaDTO> GetActualAsync();
        Task<TemporadaDTO> GetPreTemporada();
        IQueryable<byte[]> GetImg_Clasificacion(int id);
        IQueryable<byte[]> GetImg_Clasificacion(string temporada);
        Task<TemporadaDTO> GetUltimaTemporadaEnJuego();
        Task<TemporadaDTO> GetTemporadaAnteriorAsync(TemporadaDTO temporada);
    }
}
