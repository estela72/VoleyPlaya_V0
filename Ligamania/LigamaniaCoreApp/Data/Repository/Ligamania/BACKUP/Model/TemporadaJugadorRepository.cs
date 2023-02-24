using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base.Model;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class TemporadaJugadorRepository : GenericAuditableRepository<TemporadaJugador>, ITemporadaJugadorRepository
    {
        public TemporadaJugadorRepository(DbContext context)
            : base(context)
        {

        }
        //public List<TemporadaJugador> Search(string jugadorToSearch)
        //{
        //    var jugadores = _entities.Set<TemporadaJugador>()
        //        .Where(j => j.Jugador.Nombre.ToLower().Contains(jugadorToSearch.ToLower()))
        //        .ToList();
        //    return jugadores;
        //}

        public List<TemporadaJugador> Search(string jugadorToSearch)
        {
            ICollection<TemporadaJugador> jugadores = FindAll(j => j.Jugador.Nombre.ToLower().Contains(jugadorToSearch.ToLower()));
            return jugadores.ToList();
        }

        public async Task<IEnumerable<TemporadaJugador>> SearchAsync(string jugadorToSearch)
        {
            ICollection<TemporadaJugador> jugadores = await FindAllAsync(j => j.Jugador.Nombre.ToLower().Contains(jugadorToSearch.ToLower()));
            return jugadores;
        }
    }
}
