using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public partial class TemporadaPremiosDTO : AuditableEntity
    {
        public TemporadaPremiosDTO()
        {
            TemporadaPremiosPuesto = new HashSet<TemporadaPremiosPuestoDTO>();
        }

        public int CategoriaId { get; set; }
        public double Porcentaje { get; set; }
        public double PorcentajeAjustado { get; set; }

        public virtual TemporadaCompeticionCategoriaDTO Categoria { get; set; }
        public virtual ICollection<TemporadaPremiosPuestoDTO> TemporadaPremiosPuesto { get; set; }
    }
}
