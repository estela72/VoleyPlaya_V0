namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Interfaces;
    using LigamaniaCoreApp.Data.DataModels.Base.Model;

    public partial class Alineacion : AuditableEntity, IAuditableAlineacionEntity
    {
        public int Temporada_ID { get; set; }
        public int Competicion_ID { get; set; }
        public int Categoria_ID { get; set; }
        public int Equipo_ID { get; set; }
        public int Jugador_ID { get; set; }
        public int Club_ID { get; set; }
        public int Puesto_ID { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual Club Club { get; set; }
        public virtual Competicion Competicion { get; set; }
        public virtual Jugador Jugador { get; set; }
        public virtual Puesto Puesto { get; set; }
        public virtual TemporadaEquipo Equipo { get; set; }
        public virtual Temporada Temporada { get; set; }

        public int Jornada_ID { get; set; }
        public virtual TemporadaCompeticionJornada Jornada { get; set; }
    }
}
