using General.CrossCutting.Lib;

using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface ITemporadaJornadaJugadorRepository : IRepository<TemporadaJornadaJugadorDTO>
    {
        Task<ICollection<TemporadaJornadaJugadorDTO>> GetJugadoresPreEliminados(TemporadaCompeticionJornadaDTO jornada);

        Task<ICollection<TemporadaJornadaJugadorDTO>> GetGoleadores(TemporadaCompeticionJornadaDTO jornada);

        Task<ICollection<TemporadaJornadaJugadorDTO>> GetJugadoresEliminadosJornada(TemporadaCompeticionJornadaDTO jornada);

        Task<ICollection<TemporadaJornadaJugadorDTO>> GetInfoJugadoresJornada(TemporadaCompeticionJornadaDTO jornada, List<string> listJugadores);
    }
}