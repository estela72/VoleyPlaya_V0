using General.CrossCutting.Lib;

using Ligamania.Generic.Lib.Enums;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ligamania.Repository.Models
{
    public partial class CompeticionDTO : Entity
    {
        public CompeticionDTO()
        {
            Alineacion = new HashSet<AlineacionDTO>();
            AlineacionCambio = new HashSet<AlineacionCambioDTO>();
            AlineacionPrevia = new HashSet<AlineacionPreviaDTO>();
            CompeticionCategoria = new HashSet<CompeticionCategoriaDTO>();
            PuntuacionHistorica = new HashSet<PuntuacionHistoricaDTO>();
            TemporadaClasificacion = new HashSet<TemporadaClasificacionDTO>();
            TemporadaCompeticion = new HashSet<TemporadaCompeticionDTO>();
            TemporadaCompeticionCategoria = new HashSet<TemporadaCompeticionCategoriaDTO>();
            TemporadaCompeticionJornada = new HashSet<TemporadaCompeticionJornadaDTO>();
            TemporadaEquipo = new HashSet<TemporadaEquipoDTO>();
            TemporadaPartido = new HashSet<TemporadaPartidoDTO>();
            Rondas = new HashSet<TemporadaRondaDTO>();
        }

        public bool RepetirClubAliIni { get; set; }
        public int JornadaCuadro { get; set; }
        public bool CopiarAlineacionInicial { get; set; }
        public string CompeticionCopiarAliIni { get; set; }
        public int Orden { get; set; }
        public TipoCompeticion? Tipo { get; set; }

        public virtual ICollection<AlineacionDTO> Alineacion { get; set; }
        public virtual ICollection<AlineacionHistoricoDTO> AlineacionHistorica { get; set; }
        public virtual ICollection<AlineacionCambioDTO> AlineacionCambio { get; set; }
        public virtual ICollection<AlineacionPreviaDTO> AlineacionPrevia { get; set; }
        public virtual ICollection<CompeticionCategoriaDTO> CompeticionCategoria { get; set; }
        public virtual ICollection<PuntuacionHistoricaDTO> PuntuacionHistorica { get; set; }
        public virtual ICollection<TemporadaClasificacionDTO> TemporadaClasificacion { get; set; }
        public virtual ICollection<TemporadaCompeticionDTO> TemporadaCompeticion { get; set; }
        public virtual ICollection<TemporadaCompeticionCategoriaDTO> TemporadaCompeticionCategoria { get; set; }
        public virtual ICollection<TemporadaCompeticionJornadaDTO> TemporadaCompeticionJornada { get; set; }
        public virtual ICollection<TemporadaEquipoDTO> TemporadaEquipo { get; set; }
        public virtual ICollection<TemporadaPartidoDTO> TemporadaPartido { get; set; }
        public virtual ICollection<TemporadaRondaDTO> Rondas { get; set; }
    }
}