namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    using LigamaniaCoreApp.Data.DataModels.Base.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TemporadaPartido")]
    public partial class TemporadaPartido : AuditableEntity
    {
        public int Temporada_ID { get; set; }

        public int Competicion_ID { get; set; }

        public int Categoria_ID { get; set; }

        public int Jornada_ID { get; set; }

        public int Numero_Partido { get; set; }

        public int Resultado_A { get; set; }

        public int Resultado_B { get; set; }

        public int? Equipo_A_Id { get; set; }

        public int? Equipo_B_Id { get; set; }

        public int? Equipo_Ganador_Id { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual Competicion Competicion { get; set; }

        public virtual Equipo Equipo_A { get; set; }

        public virtual Equipo Equipo_B { get; set; }

        public virtual Equipo Equipo_Ganador { get; set; }

        public virtual TemporadaCompeticionJornada Jornada { get; set; }

        public virtual Temporada Temporada { get; set; }
    }
}
