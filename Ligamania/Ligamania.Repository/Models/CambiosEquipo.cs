using General.CrossCutting.Lib;

namespace Ligamania.Repository.Models
{
    public partial class CambiosEquipoDTO : Entity
    {
        public int? EquipoDestino_ID { get; set; }
        public int? EquipoOrigen_ID { get; set; }
        public int? Temporada_ID { get; set; }

        public virtual EquipoDTO EquipoDestino { get; set; }
        public virtual EquipoDTO EquipoOrigen { get; set; }
        public virtual TemporadaDTO Temporada { get; set; }
    }
}