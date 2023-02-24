using System.Collections.Generic;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{

    public interface ITemporadaJornadaJugadorRepository : IGenericAuditableIdRepository<TemporadaJornadaJugadorDTO>
    {
        Task<ICollection<TemporadaJornadaJugadorDTO>> GetJugadoresPreEliminados(TemporadaCompeticionJornadaDTO jornada);
        Task<ICollection<TemporadaJornadaJugadorDTO>> GetGoleadores(TemporadaCompeticionJornadaDTO jornada);
        Task<ICollection<TemporadaJornadaJugadorDTO>> GetJugadoresEliminadosJornada(TemporadaCompeticionJornadaDTO jornada);
        Task<ICollection<TemporadaJornadaJugadorDTO>> GetInfoJugadoresJornada(TemporadaCompeticionJornadaDTO jornada, List<string> listJugadores);
    }
}
