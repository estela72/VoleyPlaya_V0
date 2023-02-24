using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public partial class TemporadaCompeticionCategoriaDTO : AuditableEntity
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
