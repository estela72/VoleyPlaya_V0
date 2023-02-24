using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public partial class TemporadaJornadaJugadorDTO : AuditableEntity
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
