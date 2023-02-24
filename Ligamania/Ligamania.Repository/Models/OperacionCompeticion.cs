using General.CrossCutting.Lib;

using System.Collections.Generic;

namespace Ligamania.Repository.Models
{
    public partial class OperacionCompeticionDTO : Entity
    {
        public OperacionCompeticionDTO()
        {
            TemporadaCompeticion = new HashSet<TemporadaCompeticionDTO>();
            TemporadaCompeticionOperacionOperacionCompeticion = new HashSet<TemporadaCompeticionOperacionDTO>();
            TemporadaCompeticionOperacionOperacionSiguiente = new HashSet<TemporadaCompeticionOperacionDTO>();
        }

        public string Operacion { get; set; }
        public string Descripcion { get; set; }
        //public string Nombre { get; set; }

        public virtual ICollection<TemporadaCompeticionDTO> TemporadaCompeticion { get; set; }
        public virtual ICollection<TemporadaCompeticionOperacionDTO> TemporadaCompeticionOperacionOperacionCompeticion { get; set; }
        public virtual ICollection<TemporadaCompeticionOperacionDTO> TemporadaCompeticionOperacionOperacionSiguiente { get; set; }
    }
}