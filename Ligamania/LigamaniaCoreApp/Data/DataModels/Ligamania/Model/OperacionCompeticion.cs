using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public partial class OperacionCompeticionDTO : AuditableEntity
    {
        public OperacionCompeticionDTO()
        {
            TemporadaCompeticion = new HashSet<TemporadaCompeticionDTO>();
            TemporadaCompeticionOperacionOperacionCompeticion = new HashSet<TemporadaCompeticionOperacionDTO>();
            TemporadaCompeticionOperacionOperacionSiguiente = new HashSet<TemporadaCompeticionOperacionDTO>();
        }

        public string Operacion { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<TemporadaCompeticionDTO> TemporadaCompeticion { get; set; }
        public virtual ICollection<TemporadaCompeticionOperacionDTO> TemporadaCompeticionOperacionOperacionCompeticion { get; set; }
        public virtual ICollection<TemporadaCompeticionOperacionDTO> TemporadaCompeticionOperacionOperacionSiguiente { get; set; }
    }
}
