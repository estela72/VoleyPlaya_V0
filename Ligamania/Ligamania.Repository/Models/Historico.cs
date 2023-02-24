using General.CrossCutting.Lib;

using Ligamania.Generic.Lib.Enums;

using System.ComponentModel.DataAnnotations.Schema;

namespace Ligamania.Repository.Models
{
    public partial class HistoricoDTO : Entity
    {
        public int Temporada_ID { get; set; }
        public int Equipo_ID { get; set; }
        public int Categoria_ID { get; set; }
        public int Puesto { get; set; }
        public bool Pichichi { get; set; }

        public virtual TemporadaCompeticionCategoriaDTO TemporadaCompeticionCategoria { get; set; }
        public virtual TemporadaEquipoDTO TemporadaEquipo { get; set; }
        public virtual TemporadaDTO Temporada { get; set; }

        [NotMapped]
        public bool Visible
        {
            get
            {
                if (Temporada == null) return false;
                if (!Temporada.Actual) return true;
                else
                {
                    if (Temporada.Estado.Equals(EstadoTemporada.Cerrada.ToString()) || Temporada.Estado.Equals(EstadoTemporada.Finalizada.ToString()))
                        return true;
                }
                return false;
            }
        }
    }
}