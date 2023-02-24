using LigamaniaCoreApp.Data.DataModels.Base.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public partial class TemporadaCompeticionJornadaDTO : AuditableEntity
    {
        public TemporadaCompeticionJornadaDTO()
        {
            Alineacion = new HashSet<AlineacionDTO>();
            TemporadaClasificacion = new HashSet<TemporadaClasificacionDTO>();
            TemporadaJornadaJugador = new HashSet<TemporadaJornadaJugadorDTO>();
            TemporadaPartido = new HashSet<TemporadaPartidoDTO>();
            TemporadaJugador = new HashSet<TemporadaJugadorDTO>();
        }

        public int TemporadaId { get; set; }
        public int CompeticionId { get; set; }
        public int NumeroJornada { get; set; }
        public DateTime Fecha { get; set; }
        public bool Actual { get; set; }
        public bool Carrusel { get; set; }
        public bool AlineacionLibre { get; set; }
        public virtual CompeticionDTO Competicion { get; set; }
        public virtual TemporadaDTO Temporada { get; set; }
        public virtual ICollection<AlineacionDTO> Alineacion { get; set; }
        public virtual ICollection<AlineacionHistoricoDTO> AlineacionHistorica { get; set; }
        public virtual ICollection<TemporadaClasificacionDTO> TemporadaClasificacion { get; set; }
        public virtual ICollection<TemporadaJornadaJugadorDTO> TemporadaJornadaJugador { get; set; }
        public virtual ICollection<TemporadaPartidoDTO> TemporadaPartido { get; set; }
        public virtual ICollection<TemporadaJugadorDTO> TemporadaJugador { get; set; }

        public int RondaId { get; set; }
        [ForeignKey("RondaId")]
        public virtual TemporadaRondaDTO Ronda { get; set; }
    }
}
