using General.CrossCutting.Lib;

namespace Ligamania.Repository.Models
{
    public partial class TemporadaContabilidadDTO : BaseEntity
    {
        public int TemporadaId { get; set; }
        public string Concepto { get; set; }
        public double Valor { get; set; }
        public bool Gasto { get; set; }
        public bool Equipo { get; set; }

        public virtual TemporadaDTO Temporada { get; set; }
    }
}