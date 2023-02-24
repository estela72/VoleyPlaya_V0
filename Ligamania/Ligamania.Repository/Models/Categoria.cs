using General.CrossCutting.Lib;

using System.Collections.Generic;

namespace Ligamania.Repository.Models
{
    public partial class CategoriaDTO : Entity
    {
        public CategoriaDTO()
        {
            Alineacion = new HashSet<AlineacionDTO>();
            AlineacionCambio = new HashSet<AlineacionCambioDTO>();
            AlineacionPrevia = new HashSet<AlineacionPreviaDTO>();
            CompeticionCategoria = new HashSet<CompeticionCategoriaDTO>();
            PuntuacionHistorica = new HashSet<PuntuacionHistoricaDTO>();
            TemporadaClasificacion = new HashSet<TemporadaClasificacionDTO>();
            TemporadaCompeticionCategoria = new HashSet<TemporadaCompeticionCategoriaDTO>();
            TemporadaEquipo = new HashSet<TemporadaEquipoDTO>();
            TemporadaPartido = new HashSet<TemporadaPartidoDTO>();
        }

        public int Orden { get; set; }
        public bool? Activa { get; set; }

        public virtual ICollection<AlineacionDTO> Alineacion { get; set; }
        public virtual ICollection<AlineacionHistoricoDTO> AlineacionHistorica { get; set; }
        public virtual ICollection<AlineacionCambioDTO> AlineacionCambio { get; set; }
        public virtual ICollection<AlineacionPreviaDTO> AlineacionPrevia { get; set; }
        public virtual ICollection<CompeticionCategoriaDTO> CompeticionCategoria { get; set; }
        public virtual ICollection<PuntuacionHistoricaDTO> PuntuacionHistorica { get; set; }
        public virtual ICollection<TemporadaClasificacionDTO> TemporadaClasificacion { get; set; }
        public virtual ICollection<TemporadaCompeticionCategoriaDTO> TemporadaCompeticionCategoria { get; set; }
        public virtual ICollection<TemporadaEquipoDTO> TemporadaEquipo { get; set; }
        public virtual ICollection<TemporadaPartidoDTO> TemporadaPartido { get; set; }
    }
}