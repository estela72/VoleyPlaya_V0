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

    public class TemporadaPuestoJugadorRepository : GenericAuditableRepository<TemporadaPuestoJugador>, ITemporadaPuestoJugadorRepository
    {
        public TemporadaPuestoJugadorRepository(DbContext context)
            : base(context)
        {

        }
        //public List<TemporadaPuestoJugador> Search(string jugadorToSearch)
        //{
        //    var jugadores = _dbset
        //        .Where(j => j.Jugador.Nombre.ToLower().Contains(jugadorToSearch.ToLower()))
        //        .ToList();
        //    return jugadores;
        //}

        public List<TemporadaPuestoJugador> Search(string jugadorToSearch)
        {
            ICollection<TemporadaPuestoJugador> jugadores = FindAll(j => j.Jugador.Nombre.ToLower().Contains(jugadorToSearch.ToLower()));
            return jugadores.ToList();
        }

        public async Task<IEnumerable<TemporadaPuestoJugador>> SearchAsync(string jugadorToSearch)
        {
            ICollection<TemporadaPuestoJugador> jugadores = await FindAllAsync(j => j.Jugador.Nombre.ToLower().Contains(jugadorToSearch.ToLower()));
            return jugadores;
        }

    }
}
