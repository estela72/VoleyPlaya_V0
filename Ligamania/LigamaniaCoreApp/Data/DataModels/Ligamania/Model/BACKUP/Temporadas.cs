namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    using LigamaniaCoreApp.Data.DataModels.Base.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Temporada : AuditableNameEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Temporada()
        {
            Alineacion_Cambio = new HashSet<Alineacion_Cambio>();
            Alineacion_Previa = new HashSet<Alineacion_Previa>();
            Alineacion = new HashSet<Alineacion>();
            TemporadaClasificacion = new HashSet<TemporadaClasificacion>();
            TemporadaClubJugador = new HashSet<TemporadaClubJugador>();
            TemporadaCompeticion = new HashSet<TemporadaCompeticion>();
            TemporadaCompeticionCategoria = new HashSet<TemporadaCompeticionCategoria>();
            TemporadaCompeticionJornada = new HashSet<TemporadaCompeticionJornada>();
            TemporadaCuadro = new HashSet<TemporadaCuadro>();
            TemporadaEquipo = new HashSet<TemporadaEquipo>();
            TemporadaJornadaJugador = new HashSet<TemporadaJornadaJugador>();
            TemporadaJugador = new HashSet<TemporadaJugador>();
            TemporadaPartido = new HashSet<TemporadaPartido>();
            TemporadaPuestoJugador = new HashSet<TemporadaPuestoJugador>();
            TemporadaCategoriaReferencia = new HashSet<TemporadaCategoriaReferencia>();
            TemporadaContabilidad = new HashSet<TemporadaContabilidad>();
            Historico = new HashSet<Historico>();
        }

        public bool Actual { get; set; }

        // UnderConstruction
        // Creada(Actual y Pretemporada)
        // EnJuego (actual, iniciada)
        // Finalizada (actual, ver clasificaciones e historial)
        // Cerrada (no actual, sólo historial - Desaparece clasificación)
        public string Estado { get; set; }

        [Display(Name = "Clasificacion")]
        [Column(TypeName = "image")]
        public byte[] Img_Clasificacion { get; set; }

        [NotMapped]
        public bool VerHistorico
        {
            get
            {
                if (!Actual || (Actual && Estado == "Finalizada")) return true;
                return false;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alineacion_Cambio> Alineacion_Cambio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alineacion_Previa> Alineacion_Previa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alineacion> Alineacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaClasificacion> TemporadaClasificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaClubJugador> TemporadaClubJugador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaCompeticion> TemporadaCompeticion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaCompeticionCategoria> TemporadaCompeticionCategoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaCompeticionJornada> TemporadaCompeticionJornada { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaCuadro> TemporadaCuadro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaEquipo> TemporadaEquipo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaJornadaJugador> TemporadaJornadaJugador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaJugador> TemporadaJugador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaPartido> TemporadaPartido { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaPuestoJugador> TemporadaPuestoJugador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaCategoriaReferencia> TemporadaCategoriaReferencia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaContabilidad> TemporadaContabilidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historico> Historico{ get; set; }
    }
}
