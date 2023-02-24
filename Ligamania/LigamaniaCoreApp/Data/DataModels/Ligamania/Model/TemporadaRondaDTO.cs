using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public class TemporadaRondaDTO : AuditableEntity
    {
        public TemporadaRondaDTO()
        {
            JornadasFinal = new HashSet<TemporadaCompeticionJornadaDTO>();
        }

        public int NumRonda { get; set; }
        public bool RondaFinal { get; set; }
        public bool Activa { get; set; }
        public bool JornadaIdaActiva { get; set; }

        public bool GenerarJornadaFinal { get; set; }

        public int TemporadaID { get; set; }
        public int CompeticionID { get; set; }
        public virtual TemporadaDTO Temporada { get; set; }
        public virtual CompeticionDTO Competicion { get; set; }
        public int JornadaIdaID { get; set; }
        [ForeignKey("JornadaIdaID ")]
        public virtual TemporadaCompeticionJornadaDTO JornadaIda { get; set; }
        public int? JornadaVueltaID { get; set; }
        [ForeignKey("JornadaVueltaID")] 
        public virtual TemporadaCompeticionJornadaDTO JornadaVuelta { get; set; }

        public virtual ICollection<TemporadaCompeticionJornadaDTO> JornadasFinal { get; set; }
    }
}
