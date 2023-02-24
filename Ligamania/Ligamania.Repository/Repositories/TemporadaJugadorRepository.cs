using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class TemporadaJugadorRepository : BaseRepository<TemporadaJugadorDTO>, ITemporadaJugadorRepository
    {
        public TemporadaJugadorRepository(LigamaniaDbContext context)
            : base(context)
        {
        }

        public List<TemporadaJugadorDTO> Search(string jugadorToSearch)
        {
            var jugadores = DbSet
                .Where(j => j.Jugador.Nombre.ToLower().Contains(jugadorToSearch.ToLower()))
                .ToList();
            return jugadores;
        }

        public async Task<ICollection<TemporadaJugadorDTO>> GetJugadoresEliminados()
        {
            var lista = await FindAllIncludingAsync(tj => tj.Temporada.Actual && tj.Activo && tj.Eliminado, tj => tj.Temporada, tj => tj.Jugador, tj => tj.LastJornadaEliminacion).ConfigureAwait(false);
            lista = lista.GroupBy(tj => tj.Jugador_ID).Select(grp => grp.First()).ToList();
            return lista;
        }

        public async Task<ICollection<TemporadaJugadorDTO>> GetJugadoresPreEliminados()
        {
            var lista = await FindAllIncludingAsync(tj => tj.Temporada.Actual && tj.Activo && tj.PreEliminado, tj => tj.Temporada, tj => tj.Jugador, tj => tj.LastJornadaEliminacion).ConfigureAwait(false);
            lista = lista.GroupBy(tj => tj.Jugador_ID).Select(grp => grp.First()).ToList();
            return lista;
        }

        public async Task<IQueryable<TemporadaJugadorDTO>> GetJugadoresEliminadosQueryable()
        {
            var lista = await FindAllQueryableIncludingAsync(tj => tj.Temporada.Actual && tj.Activo && tj.Eliminado, tj => tj.Temporada, tj => tj.Jugador, tj => tj.LastJornadaEliminacion).ConfigureAwait(false);
            return lista;
        }

        public async Task<ICollection<TemporadaJugadorDTO>> GetJugadoresFromTemporada(int temporadaId)
        {
            var lista = await FindAllIncludingAsync(tj => tj.Temporada_ID.Equals(temporadaId), tj => tj.Jugador, tj => tj.Club, tj => tj.Puesto).ConfigureAwait(false);
            return lista.ToList();
        }

        public async Task<TemporadaJugadorDTO> GetJugador(TemporadaDTO temporada, JugadorDTO jugador)
        {
            return await FindAsync(tj => tj.Temporada_ID.Equals(temporada.Id) && tj.Jugador_ID.Equals(jugador.Id) && tj.Activo).ConfigureAwait(false);
        }

        public async Task<TemporadaJugadorDTO> Alta(JugadorDTO jugador, ClubDTO club, PuestoDTO puesto, TemporadaDTO temporada)
        {
            TemporadaJugadorDTO tj = new TemporadaJugadorDTO
            {
                Activo = true,
                Jugador = jugador,
                Club = club,
                Puesto = puesto,
                Temporada = temporada,
                Eliminado = false,
                LastJornadaEliminacion = null,
                PreEliminado = false,
                VecesEliminado = 0,
                VecesPreEliminado = 0
            };
            var tjNew = await AddAsyn(tj);
            return tjNew;
        }

        public async Task<bool> Baja(TemporadaJugadorDTO jugExiste)
        {
            jugExiste.Activo = false;
            var j = await UpdateAsync(jugExiste);
            return (j != null);
        }
    }
}