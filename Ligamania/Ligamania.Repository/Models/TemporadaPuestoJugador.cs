using General.CrossCutting.Lib;

using System;

namespace Ligamania.Repository.Models
{
    public partial class TemporadaPuestoJugadorDTO : Entity
    {
        public int TemporadaId { get; set; }
        public int PuestoId { get; set; }
        public int JugadorId { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaBaja { get; set; }

        public virtual JugadorDTO Jugador { get; set; }
        public virtual PuestoDTO Puesto { get; set; }
        public virtual TemporadaDTO Temporada { get; set; }
    }
}