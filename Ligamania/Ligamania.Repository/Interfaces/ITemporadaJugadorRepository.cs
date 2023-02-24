using General.CrossCutting.Lib;

using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface ITemporadaJugadorRepository : IBaseRepository<TemporadaJugadorDTO>
    {
        List<TemporadaJugadorDTO> Search(string jugadorToSearch);

        Task<ICollection<TemporadaJugadorDTO>> GetJugadoresEliminados();

        Task<IQueryable<TemporadaJugadorDTO>> GetJugadoresEliminadosQueryable();

        Task<ICollection<TemporadaJugadorDTO>> GetJugadoresFromTemporada(int temporadaId);

        Task<ICollection<TemporadaJugadorDTO>> GetJugadoresPreEliminados();

        Task<TemporadaJugadorDTO> GetJugador(TemporadaDTO temporada, JugadorDTO jugador);

        Task<TemporadaJugadorDTO> Alta(JugadorDTO jugador, ClubDTO club, PuestoDTO puesto, TemporadaDTO temporada);
        Task<bool> Baja(TemporadaJugadorDTO jugExiste);
    }
}