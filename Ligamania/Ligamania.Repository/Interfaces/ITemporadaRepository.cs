using General.CrossCutting.Lib;

using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface ITemporadaRepository : IRepository<TemporadaDTO>
    {
        TemporadaDTO GetActual();

        Task<TemporadaDTO> GetActualAsync();

        Task<TemporadaDTO> GetPreTemporada();

        Task<byte[]> GetImg_Clasificacion(int id);

        Task<byte[]> GetImg_Clasificacion(string temporada);

        Task<TemporadaDTO> GetUltimaTemporadaEnJuego();

        Task<TemporadaDTO> GetTemporadaAnteriorAsync(TemporadaDTO temporada);
        Task<ICollection<TemporadaCompeticionDTO>> GetCompeticionesByTemporada(int idTemporada);
        Task<ICollection<TemporadaCompeticionCategoriaDTO>> GetCategoriasByTemporadaAndCompeticion(int idTemporada, int idCompeticion);
        Task<ICollection<TemporadaJugadorDTO>> GetJugadoresByTemporada(int id);
        Task<ICollection<ClubDTO>> GetAllClubs(int idTemporada);
        Task<TemporadaDTO> GetTemporadaHistorificarAsync(int id);
    }
}