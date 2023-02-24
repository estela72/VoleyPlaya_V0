using General.CrossCutting.Lib;

namespace Ligamania.Repository.Models
{
    public partial class TemporadaPremiosPuestoDTO : Entity
    {
        public int PremioCategoriaId { get; set; }
        public int Puesto { get; set; }
        public double Porcentaje { get; set; }
        public double PorcentajeAjustado { get; set; }
        public double Importe { get; set; }

        public virtual TemporadaPremiosDTO PremioCategoria { get; set; }
    }
}