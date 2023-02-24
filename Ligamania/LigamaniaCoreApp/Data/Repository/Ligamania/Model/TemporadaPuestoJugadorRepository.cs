using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.DataModels.Base.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class TemporadaPuestoJugadorRepository : GenericAuditableRepository<TemporadaPuestoJugador_DTO>, ITemporadaPuestoJugadorRepository
    {
        public TemporadaPuestoJugadorRepository(DbContext context)
            : base(context)
        {

        }
        public List<TemporadaPuestoJugador_DTO> Search(string jugadorToSearch)
        {
            var jugadores = _dbset
                .Where(j => j.Jugador.Nombre.ToLower().Contains(jugadorToSearch.ToLower()))
                .ToList();
            return jugadores;
        }
    }
}
