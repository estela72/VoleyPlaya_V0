using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
    using LigamaniaCoreApp.Data.Repository.Base.Model;
    using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class JugadorRepository : GenericAuditableNameRepository<Jugador>, IJugadorRepository
    {
        public JugadorRepository(DbContext context)
            : base(context)
        {

        }
        public List<Jugador> Search(string jugadorToSearch)
        {
            ICollection<Jugador> jugadores = FindAll(j => j.Nombre.ToLower().Contains(jugadorToSearch.ToLower()));
            return jugadores.ToList();
        }

        public async Task<IEnumerable<Jugador>> SearchAsync(string jugadorToSearch)
        {
            ICollection<Jugador> jugadores = await FindAllAsync(j => j.Nombre.ToLower().Contains(jugadorToSearch.ToLower()));
            return jugadores;
        }
    }
}
