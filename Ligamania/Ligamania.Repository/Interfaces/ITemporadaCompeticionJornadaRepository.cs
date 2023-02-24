using General.CrossCutting.Lib;

using Ligamania.Repository.Models;

using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface ITemporadaCompeticionJornadaRepository : IRepository<TemporadaCompeticionJornadaDTO>
    {
        Task<TemporadaCompeticionJornadaDTO> GetLastJornada(int competicionId, string nombreTemporada = "");

        Task<TemporadaCompeticionJornadaDTO> GetJornadaCarrusel(int competicionId, string nombreTemporada = "");

        Task<TemporadaCompeticionJornadaDTO> GetJornadaActual(int competicionId, string nombreTemporada = "");

        Task<TemporadaCompeticionJornadaDTO> GetJornadaClasificacion(string nombreTemporada, int competicionId);

        Task<TemporadaCompeticionJornadaDTO> GetJornada(int temporadaId, int competicionId, int numJornada);

        Task IncrementarJornadaActual(TemporadaCompeticionDTO temporadaCompeticion, TemporadaCompeticionJornadaDTO jornadaActual);
    }
}