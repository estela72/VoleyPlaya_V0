using General.CrossCutting.Lib;

using System.Collections.Generic;

namespace Ligamania.Repository.Models
{
    public partial class TemporadaPremiosDTO : Entity
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