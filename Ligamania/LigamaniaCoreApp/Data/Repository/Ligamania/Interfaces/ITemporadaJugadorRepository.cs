using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{

    public interface ITemporadaJugadorRepository : IGenericAuditableIdRepository<TemporadaJugadorDTO>
    {
        List<TemporadaJugadorDTO> Search(string jugadorToSearch);
        Task<ICollection<TemporadaJugadorDTO>> GetJugadoresEliminados();
        Task<IQueryable<TemporadaJugadorDTO>> GetJugadoresEliminadosQueryable();
        Task<ICollection<TemporadaJugadorDTO>> GetJugadoresFromTemporada(int temporadaId);
        Task<ICollection<TemporadaJugadorDTO>> GetJugadoresPreEliminados();
        Task<TemporadaJugadorDTO> GetJugador(TemporadaDTO temporada, JugadorDTO jugador);
    }
}
