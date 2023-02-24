namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    using LigamaniaCoreApp.Data.DataModels.Base.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TemporadaClasificacion")]
    public partial class TemporadaClasificacion : AuditableEntity
    {
        public int Temporada_ID { get; set; }

        public int Competicion_ID { get; set; }

        public int Categoria_ID { get; set; }

        public int Jornada_ID { get; set; }

        public int Equipo_ID { get; set; }

        public DateTime FechaIns { get; set; }

        public int Puesto { get; set; }

        public int Jugados { get; set; }

        public int Ganados { get; set; }

        public int Perdidos { get; set; }

        public int Empatados { get; set; }

        public int GolesFavor { get; set; }

        public int GolesContra { get; set; }

        public int Diferencia { get; set; }

        public int Puntos { get; set; }

        //public DateTime CreatedDate { get; set; }

        //[StringLength(256)]
        //public string CreatedBy { get; set; }

        //public DateTime UpdatedDate { get; set; }

        //[StringLength(256)]
        //public string UpdatedBy { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual Competicion Competicion { get; set; }

        public virtual Equipo Equipo { get; set; }

        public virtual TemporadaCompeticionJornada Jornada { get; set; }

        public virtual Temporada Temporada { get; set; }
    }
}
