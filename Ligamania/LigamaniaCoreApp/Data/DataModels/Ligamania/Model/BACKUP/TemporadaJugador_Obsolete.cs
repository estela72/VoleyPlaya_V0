namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    using LigamaniaCoreApp.Data.DataModels.Base.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TemporadaJugador")]
    public partial class TemporadaJugador_Obsolete : AuditableEntity
    {
        //public int Id { get; set; }

        public int Temporada_ID { get; set; }

        public int Jugador_ID { get; set; }

        public int VecesPreEliminado { get; set; }

        public int VecesEliminado { get; set; }

        public bool Eliminado { get; set; }

        public bool PreEliminado { get; set; }

        //public DateTime CreatedDate { get; set; }

        //[StringLength(256)]
        //public string CreatedBy { get; set; }

        //public DateTime UpdatedDate { get; set; }

        //[StringLength(256)]
        //public string UpdatedBy { get; set; }

        public virtual Jugador Jugador { get; set; }

        public virtual Temporada Temporada { get; set; }
    }
}
