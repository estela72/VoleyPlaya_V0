namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    using LigamaniaCoreApp.Data.DataModels.Base.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TemporadaClubJugador")]
    public partial class TemporadaClubJugador : AuditableEntity
    {
        public int Temporada_ID { get; set; }

        public int Club_ID { get; set; }

        public int Jugador_ID { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaAlta { get; set; }

        public DateTime FechaBaja { get; set; }

        public virtual Club Club { get; set; }

        public virtual Jugador Jugador { get; set; }

        public virtual Temporada Temporada { get; set; }
    }
}
