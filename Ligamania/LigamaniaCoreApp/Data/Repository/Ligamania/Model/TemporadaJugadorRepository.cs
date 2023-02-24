using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class TemporadaJugadorRepository : GenericAuditableRepository<TemporadaJugadorDTO>, ITemporadaJugadorRepository
    {
        public TemporadaJugadorRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public List<TemporadaJugadorDTO> Search(string jugadorToSearch)
        {
            var jugadores = _entities.Set<TemporadaJugadorDTO>()
                .Where(j => j.Jugador.Nombre.ToLower().Contains(jugadorToSearch.ToLower()))
                .ToList();
            return jugadores;
        }
        public async Task<ICollection<TemporadaJugadorDTO>> GetJugadoresEliminados()
        {
            var lista = await FindAllIncludingAsync(tj => tj.Temporada.Actual && tj.Activo && tj.Eliminado, tj=>tj.Temporada, tj=>tj.Jugador, tj=>tj.LastJornadaEliminacion).ConfigureAwait(false);
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
            var lista = await FindAllIncludingAsync(tj => tj.Temporada_ID.Equals(temporadaId), tj => tj.Jugador, tj => tj.Club, tj=>tj.Puesto).ConfigureAwait(false);
            return lista.ToList();
        }
        public async Task<TemporadaJugadorDTO> GetJugador(TemporadaDTO temporada, JugadorDTO jugador)
        {
            return await FindAsync(tj => tj.Temporada_ID.Equals(temporada.Id) && tj.Jugador_ID.Equals(jugador.Id) && tj.Activo).ConfigureAwait(false);
        }
    }
}
