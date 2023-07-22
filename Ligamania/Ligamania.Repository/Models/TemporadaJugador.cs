using General.CrossCutting.Lib;

using System.ComponentModel.DataAnnotations.Schema;

namespace Ligamania.Repository.Models
{
    [Table("TemporadaJugador")]
    public partial class TemporadaJugadorDTO : BaseEntity
    {
        public TemporadaJugadorDTO() { }
        public TemporadaJugadorDTO(TemporadaJugadorDTO j)
        {
            VecesEliminado = 0;
            VecesPreEliminado = 0;
            Eliminado = false;
            PreEliminado = false;
            Activo = j.Activo;
            Club = j.Club;
            Puesto = j.Puesto;
            Jugador = j.Jugador;
            LastJornadaEliminacion = null;
        }

        public int Temporada_ID { get; set; }

        public int Jugador_ID { get; set; }

        public int VecesPreEliminado { get; set; }

        public int VecesEliminado { get; set; }

        public bool Eliminado { get; set; }

        public bool PreEliminado { get; set; }
        public bool Activo { get; set; }
        public virtual ClubDTO Club { get; set; }
        public virtual PuestoDTO Puesto { get; set; }
        public virtual JugadorDTO Jugador { get; set; }
        public virtual TemporadaCompeticionJornadaDTO LastJornadaEliminacion { get; set; }
        public virtual TemporadaDTO Temporada { get; set; }
    }
}