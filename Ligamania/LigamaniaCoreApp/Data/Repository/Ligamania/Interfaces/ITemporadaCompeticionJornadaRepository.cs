using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{
    public interface ITemporadaCompeticionJornadaRepository : IGenericAuditableIdRepository<TemporadaCompeticionJornadaDTO>
    {
        Task<TemporadaCompeticionJornadaDTO> GetLastJornada(int competicionId, string nombreTemporada = "");
        Task<TemporadaCompeticionJornadaDTO> GetJornadaCarrusel(int competicionId, string nombreTemporada = "");
        Task<TemporadaCompeticionJornadaDTO> GetJornadaActual(int competicionId, string nombreTemporada = "");
        Task<TemporadaCompeticionJornadaDTO> GetJornadaClasificacion(string nombreTemporada, int competicionId);
        Task<TemporadaCompeticionJornadaDTO> GetJornada(int temporadaId, int competicionId, int numJornada);
        Task IncrementarJornadaActual(TemporadaCompeticionDTO temporadaCompeticion, TemporadaCompeticionJornadaDTO jornadaActual);
    }
}
