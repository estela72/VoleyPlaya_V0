using General.CrossCutting.Lib;

using Ligamania.Generic.Lib.Enums;

namespace Ligamania.Repository.Models
{
    public partial class TemporadaPremiosPuestoDTO : BaseEntity
    {
        public int PremioCategoriaId { get; set; }
        public PuestoCompeticion Puesto { get; set; }
        public double Porcentaje { get; set; }
        public double PorcentajeAjustado { get; set; }
        public double Importe { get; set; }

        public virtual TemporadaPremiosDTO PremioCategoria { get; set; }
    }
}