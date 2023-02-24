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
    public class TemporadaClubJugadorRepository : GenericAuditableRepository<TemporadaClubJugador>, ITemporadaClubJugadorRepository
    {
        public TemporadaClubJugadorRepository(DbContext context)
            : base(context)
        {

        }
        //public List<TemporadaClubJugador> Search(string jugador)
        //{
        //    var jugadores = _dbset
        //        .Where(j => j.Jugador.Nombre.ToLower().Contains(jugador.ToLower()))
        //        .ToList();
        //    return jugadores;
        //}

        public List<TemporadaClubJugador> Search(string jugador)
        {
            ICollection<TemporadaClubJugador> jugadores = FindAll(j => j.Jugador.Nombre.ToLower().Contains(jugador.ToLower()));
            return jugadores.ToList();
        }

        public async Task<IEnumerable<TemporadaClubJugador>> SearchAsync(string jugador)
        {
            ICollection<TemporadaClubJugador> jugadores = await FindAllAsync(j => j.Jugador.Nombre.ToLower().Contains(jugador.ToLower()));
            return jugadores;
        }

    }
}
