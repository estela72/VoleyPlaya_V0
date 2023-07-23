using General.CrossCutting.Lib;

using System.Collections.Generic;

namespace Ligamania.Repository.Models
{
    public partial class TemporadaEquipoDTO : BaseEntity
    {
        public TemporadaEquipoDTO()
        {
            Alineacion = new HashSet<AlineacionDTO>();
            AlineacionCambio = new HashSet<AlineacionCambioDTO>();
            AlineacionPrevia = new HashSet<AlineacionPreviaDTO>();
            Historico = new HashSet<HistoricoDTO>();
        }

        public int TemporadaId { get; set; }
        public int CompeticionId { get; set; }
        public int CategoriaId { get; set; }
        public int EquipoId { get; set; }
        public int PartidosJugados { get; set; }
        public int PartidosGanados { get; set; }
        public int PartidosPerdidos { get; set; }
        public int PartidosEmpatados { get; set; }
        public int GolesFavor { get; set; }
        public int GolesContra { get; set; }
        public int Diferencia { get; set; }
        public int Puntos { get; set; }
        public bool PagadaTemporada { get; set; }
        public bool ConfirmadaTemporada { get; set; }
        public bool Baja { get; set; }
        public bool AlineacionLibre { get; set; }

        public virtual CategoriaDTO Categoria { get; set; }
        public virtual CompeticionDTO Competicion { get; set; }
        public virtual EquipoDTO Equipo { get; set; }
        public virtual TemporadaDTO Temporada { get; set; }
        public virtual ICollection<AlineacionDTO> Alineacion { get; set; }
        public virtual ICollection<AlineacionHistoricoDTO> AlineacionHistorica { get; set; }
        public virtual ICollection<AlineacionCambioDTO> AlineacionCambio { get; set; }
        public virtual ICollection<AlineacionPreviaDTO> AlineacionPrevia { get; set; }
        public virtual ICollection<HistoricoDTO> Historico { get; set; }
    }
}