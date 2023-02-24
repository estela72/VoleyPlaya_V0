using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class JugadorRepository : GenericAuditableNameRepository<JugadorDTO>, IJugadorRepository
    {
        public JugadorRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public List<JugadorDTO> Search(string jugadorToSearch)
        {
            List<JugadorDTO> jugadores = _dbset
                .Where(j => j.Nombre.ToLower().Contains(jugadorToSearch.ToLower()))
                .ToList();
            return jugadores;
        }
    }
}
