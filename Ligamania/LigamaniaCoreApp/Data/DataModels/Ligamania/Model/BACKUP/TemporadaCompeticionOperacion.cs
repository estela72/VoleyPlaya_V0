namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    using LigamaniaCoreApp.Data.DataModels.Base.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TemporadaCompeticionOperacion")]
    public partial class TemporadaCompeticionOperacion : AuditableEntity
    {
        public int Competicion_Id { get; set; }

        public int EstadoCompeticion_Id { get; set; }

        public int OperacionCompeticion_Id { get; set; }

        public int? EstadoSiguiente_Id { get; set; }

        public int? OperacionSiguiente_Id { get; set; }

        public virtual EstadoCompeticion EstadoCompeticion { get; set; }

        public virtual EstadoCompeticion EstadoCompeticionSiguiente { get; set; }

        public virtual OperacionCompeticion OperacionCompeticion { get; set; }

        public virtual OperacionCompeticion OperacionCompeticionSiguiente { get; set; }

        public virtual TemporadaCompeticion TemporadaCompeticion { get; set; }
    }
}
