namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    using LigamaniaCoreApp.Data.DataModels.Base.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static LigamaniaCoreApp.Data.LigamaniaEnum;

    public partial class Competicion : AuditableNameEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Competicion()
        {
            Alineacion_Cambio = new HashSet<Alineacion_Cambio>();
            Alineacion_Previa = new HashSet<Alineacion_Previa>();
            Alineacion = new HashSet<Alineacion>();
            TemporadaClasificacion = new HashSet<TemporadaClasificacion>();
            TemporadaCompeticion = new HashSet<TemporadaCompeticion>();
            TemporadaCompeticionCategoria = new HashSet<TemporadaCompeticionCategoria>();
            TemporadaCompeticionJornada = new HashSet<TemporadaCompeticionJornada>();
            TemporadaEquipo = new HashSet<TemporadaEquipo>();
            TemporadaPartido = new HashSet<TemporadaPartido>();
            Categoria = new HashSet<Categoria>();
        }
        public bool RepetirClubAliIni { get; set; }

        // puede ser "Liga", "Copa", "Supercopa"
        public TipoCompeticion Tipo { get; set; }

        public int JornadaCuadro { get; set; }

        public bool Copiar_AlineacionInicial { get; set; }

        [StringLength(8000)]
        public string Competicion_CopiarAliIni { get; set; }

        public int Orden { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alineacion_Cambio> Alineacion_Cambio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alineacion_Previa> Alineacion_Previa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alineacion> Alineacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaClasificacion> TemporadaClasificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaCompeticion> TemporadaCompeticion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaCompeticionCategoria> TemporadaCompeticionCategoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaCompeticionJornada> TemporadaCompeticionJornada { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaEquipo> TemporadaEquipo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaPartido> TemporadaPartido { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Categoria> Categoria { get; set; }
        [NotMapped]
        public bool esLiga { get { if (Tipo == TipoCompeticion.Liga) return true;return false; } }
        [NotMapped]
        public bool esCopa { get { if (Tipo == TipoCompeticion.Copa) return true; return false; } }
        [NotMapped]
        public bool esSupercopa { get { if (Tipo == TipoCompeticion.Supercopa) return true; return false; } }
    }
}
