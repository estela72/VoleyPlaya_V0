using General.CrossCutting.Lib;

namespace Ligamania.Repository.Models
{
    public partial class TemporadaJornadaJugadorDTO : Entity
    {
        public int TemporadaId { get; set; }
        public int JugadorId { get; set; }
        public int JornadaId { get; set; }
        public bool PreEliminado { get; set; }
        public bool Eliminado { get; set; }
        public int GolesFavor { get; set; }
        public int GolesContra { get; set; }
        public int? MinutosJugados { get; set; }
        public int? TarjetasRojas { get; set; }
        public int? TarjetasAmarillas { get; set; }

        public virtual TemporadaCompeticionJornadaDTO Jornada { get; set; }
        public virtual JugadorDTO Jugador { get; set; }
        public virtual TemporadaDTO Temporada { get; set; }
    }
}