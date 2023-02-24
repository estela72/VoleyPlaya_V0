using System;
using System.Collections.Generic;
using System.Linq;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base.Model;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class TemporadaCompeticionRepository : GenericAuditableRepository<TemporadaCompeticion>, ITemporadaCompeticionRepository
    {
        public TemporadaCompeticionRepository(DbContext context)
            : base(context)
        {

        }
        public List<TemporadaCompeticion> GetCompeticionesActivas(int temporadaId)
        {
            var lista = FindAll(tc => tc.Temporada_ID.Equals(temporadaId) && tc.Activa);
            return lista.ToList();
        }
    }
}
