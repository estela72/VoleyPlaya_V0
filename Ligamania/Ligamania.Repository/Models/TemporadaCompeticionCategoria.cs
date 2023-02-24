using General.CrossCutting.Lib;

using System.Collections.Generic;

namespace Ligamania.Repository.Models
{
    public partial class TemporadaCompeticionCategoriaDTO : BaseEntity
    {
        public TemporadaCompeticionCategoriaDTO()
        {
            Historico = new HashSet<HistoricoDTO>();
            TemporadaCompeticionCategoriaReferencia = new HashSet<TemporadaCompeticionCategoriaReferenciaDTO>();
            TemporadaCuadroEquipoACategoria = new HashSet<TemporadaCuadroDTO>();
            TemporadaCuadroEquipoBCategoria = new HashSet<TemporadaCuadroDTO>();
            TemporadaPremios = new HashSet<TemporadaPremiosDTO>();
        }

        public int TemporadaId { get; set; }
        public int CompeticionId { get; set; }
        public int CategoriaId { get; set; }
        public int NumeroMaximoJugadorEliminar { get; set; }
        public bool MarcarPichichi { get; set; }

        public virtual CategoriaDTO Categoria { get; set; }
        public virtual CompeticionDTO Competicion { get; set; }
        public virtual TemporadaDTO Temporada { get; set; }
        public virtual ICollection<HistoricoDTO> Historico { get; set; }
        public virtual ICollection<TemporadaCompeticionCategoriaReferenciaDTO> TemporadaCompeticionCategoriaReferencia { get; set; }
        public virtual ICollection<TemporadaCuadroDTO> TemporadaCuadroEquipoACategoria { get; set; }
        public virtual ICollection<TemporadaCuadroDTO> TemporadaCuadroEquipoBCategoria { get; set; }
        public virtual ICollection<TemporadaPremiosDTO> TemporadaPremios { get; set; }
    }
}