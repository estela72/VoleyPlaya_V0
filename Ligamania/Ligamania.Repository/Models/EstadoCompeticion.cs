using General.CrossCutting.Lib;

using System.Collections.Generic;

namespace Ligamania.Repository.Models
{
    public partial class EstadoCompeticionDTO : Entity
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