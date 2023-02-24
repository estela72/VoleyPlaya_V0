using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public partial class TemporadaCompeticionOperacionDTO : AuditableEntity
    {
        public int CompeticionId { get; set; }
        public int EstadoCompeticionId { get; set; }
        public int OperacionCompeticionId { get; set; }
        public int? EstadoSiguienteId { get; set; }
        public int? OperacionSiguienteId { get; set; }

        public virtual TemporadaCompeticionDTO Competicion { get; set; }
        public virtual EstadoCompeticionDTO EstadoCompeticion { get; set; }
        public virtual EstadoCompeticionDTO EstadoSiguiente { get; set; }
        public virtual OperacionCompeticionDTO OperacionCompeticion { get; set; }
        public virtual OperacionCompeticionDTO OperacionSiguiente { get; set; }
    }
}
