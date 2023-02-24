namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    using LigamaniaCoreApp.Data.DataModels.Base.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TemporadaPuestoJugador")]
    public partial class TemporadaPuestoJugador : AuditableEntity
    {
        public int Temporada_ID { get; set; }

        public int Puesto_ID { get; set; }

        public int Jugador_ID { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaAlta { get; set; }

        public DateTime FechaBaja { get; set; }

        public virtual Jugador Jugador { get; set; }

        public virtual Puesto Puesto { get; set; }

        public virtual Temporada Temporada { get; set; }
    }
}
