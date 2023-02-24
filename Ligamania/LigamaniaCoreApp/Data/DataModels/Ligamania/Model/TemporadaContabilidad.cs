using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public partial class TemporadaContabilidadDTO : AuditableEntity
    {
        public int TemporadaId { get; set; }
        public string Concepto { get; set; }
        public double Valor { get; set; }
        public bool Gasto { get; set; }
        public bool Equipo { get; set; }

        public virtual TemporadaDTO Temporada { get; set; }
    }
}
