using General.CrossCutting.Lib;

using System;

namespace Ligamania.Repository.Models
{
    public partial class TemporadaClubJugadorDTO : Entity
    {
        public int TemporadaId { get; set; }
        public int ClubId { get; set; }
        public int JugadorId { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaBaja { get; set; }

        public virtual ClubDTO Club { get; set; }
        public virtual JugadorDTO Jugador { get; set; }
        public virtual TemporadaDTO Temporada { get; set; }
    }
}