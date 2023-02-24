﻿using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base.Model;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class TemporadaJornadaJugadorRepository : GenericAuditableRepository<TemporadaJornadaJugador>, ITemporadaJornadaJugadorRepository
    {
        public TemporadaJornadaJugadorRepository(DbContext context)
            : base(context)
        {

        }
    }
}
