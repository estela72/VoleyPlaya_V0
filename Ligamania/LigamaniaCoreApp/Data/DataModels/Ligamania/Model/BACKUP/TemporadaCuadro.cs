namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    using LigamaniaCoreApp.Data.DataModels.Base.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TemporadaCuadro")]
    public partial class TemporadaCuadro : AuditableEntity
    {
        public int Orden { get; set; }

        [StringLength(8000)]
        public string Nombre_EquipoA { get; set; }

        [StringLength(8000)]
        public string Nombre_EquipoB { get; set; }

        [StringLength(8000)]
        public string Nombre_Ganador { get; set; }

        public int Temporada_ID { get; set; }

        public int Competicion_ID { get; set; }

        public int EquipoA_Competicion_ID { get; set; }

        public int EquipoA_Categoria_ID { get; set; }

        public int EquipoB_Competicion_ID { get; set; }

        public int EquipoB_Categoria_ID { get; set; }

        public int Ronda { get; set; }

        public int EquipoA_Puesto { get; set; }

        public int EquipoB_Puesto { get; set; }
        public int? Numero_Partido { get; set; }
        public string Criterio { get; set; }

        public virtual TemporadaCompeticion Competicion { get; set; }

        public virtual TemporadaCompeticion EquipoA_Competicion { get; set; }

        public virtual TemporadaCompeticion EquipoB_Competicion { get; set; }

        public virtual TemporadaCompeticionCategoria EquipoA_Categoria { get; set; }

        public virtual TemporadaCompeticionCategoria EquipoB_Categoria { get; set; }

        public virtual Temporada Temporada { get; set; }
    }
}
