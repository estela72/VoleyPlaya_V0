using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class TemporadaJornadaJugadorRepository : Repository<TemporadaJornadaJugadorDTO>, ITemporadaJornadaJugadorRepository
    {
        public TemporadaJornadaJugadorRepository(LigamaniaDbContext context)
            : base(context)
        {
        }

        public async Task<ICollection<TemporadaJornadaJugadorDTO>> GetJugadoresPreEliminados(TemporadaCompeticionJornadaDTO jornada)
        {
            var jugadores = await FindAllIncludingAsync(tcj => tcj.JornadaId.Equals(jornada.Id) && tcj.PreEliminado, tcj => tcj.Jugador).ConfigureAwait(false);
            return jugadores;
        }

        public async Task<ICollection<TemporadaJornadaJugadorDTO>> GetGoleadores(TemporadaCompeticionJornadaDTO jornada)
        {
            var jugadores = await FindAllIncludingAsync(tcj => tcj.JornadaId.Equals(jornada.Id) && (tcj.GolesFavor > 0 || tcj.GolesContra > 0),
                tcj => tcj.Jugador).ConfigureAwait(false);
            return jugadores;
        }

        public async Task<ICollection<TemporadaJornadaJugadorDTO>> GetInfoJugadoresJornada(TemporadaCompeticionJornadaDTO jornada, List<string> listJugadores)
        {
            var jugadores = await FindAllIncludingAsync(tcj => tcj.JornadaId.Equals(jornada.Id) && listJugadores.Contains(tcj.Jugador.Nombre),
                    tcj => tcj.Jugador).ConfigureAwait(false);
            return jugadores;
        }

        public async Task<ICollection<TemporadaJornadaJugadorDTO>> GetJugadoresEliminadosJornada(TemporadaCompeticionJornadaDTO jornada)
        {
            var jugadores = await FindAllIncludingAsync(tcj => tcj.JornadaId.Equals(jornada.Id) && tcj.Eliminado, tcj => tcj.Jugador).ConfigureAwait(false);
            return jugadores;
        }
    }
}