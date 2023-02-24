namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    using LigamaniaCoreApp.Data.DataModels.Base.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("oldTemporadaJugador")]
    public partial class TemporadaJugadorObsolete : AuditableEntity
    {
        public int Temporada_ID { get; set; }

        public int Jugador_ID { get; set; }

        public int VecesPreEliminado { get; set; }

        public int VecesEliminado { get; set; }

        public bool Eliminado { get; set; }

        public bool PreEliminado { get; set; }
        //public bool Activo { get; set; }
        //public virtual Club_DTO Club { get; set; }
        //public virtual Puesto_DTO Puesto { get; set; }
        public virtual JugadorDTO Jugador { get; set; }

        public virtual TemporadaDTO Temporada { get; set; }
    }
}
