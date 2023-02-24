using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public partial class EstadoCompeticionDTO : AuditableEntity
    {
        public EstadoCompeticionDTO()
        {
            TemporadaCompeticion = new HashSet<TemporadaCompeticionDTO>();
            TemporadaCompeticionOperacionEstadoCompeticion = new HashSet<TemporadaCompeticionOperacionDTO>();
            TemporadaCompeticionOperacionEstadoSiguiente = new HashSet<TemporadaCompeticionOperacionDTO>();
        }

        public string Estado { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<TemporadaCompeticionDTO> TemporadaCompeticion { get; set; }
        public virtual ICollection<TemporadaCompeticionOperacionDTO> TemporadaCompeticionOperacionEstadoCompeticion { get; set; }
        public virtual ICollection<TemporadaCompeticionOperacionDTO> TemporadaCompeticionOperacionEstadoSiguiente { get; set; }
    }
}
