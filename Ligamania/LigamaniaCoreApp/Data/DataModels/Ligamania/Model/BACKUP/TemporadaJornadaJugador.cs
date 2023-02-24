namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    using LigamaniaCoreApp.Data.DataModels.Base.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TemporadaJornadaJugador")]
    public partial class TemporadaJornadaJugador : AuditableEntity
    {
        public int Temporada_ID { get; set; }

        public int Jugador_ID { get; set; }

        public int Jornada_ID { get; set; }

        public bool PreEliminado { get; set; }

        public bool Eliminado { get; set; }

        public int GolesFavor { get; set; }

        public int GolesContra { get; set; }

        public int? MinutosJugados { get; set; }
        public int? TarjetasRojas { get; set; }
        public int? TarjetasAmarillas { get; set; }
        public virtual Jugador Jugador { get; set; }

        public virtual TemporadaCompeticionJornada Jornada { get; set; }

        public virtual Temporada Temporada { get; set; }
    }
}
