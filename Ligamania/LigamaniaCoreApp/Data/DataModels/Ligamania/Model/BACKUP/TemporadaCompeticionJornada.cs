namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    using LigamaniaCoreApp.Data.DataModels.Base.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TemporadaCompeticionJornada")]
    public partial class TemporadaCompeticionJornada : AuditableEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TemporadaCompeticionJornada()
        {
            Alineacion = new HashSet<Alineacion>();
            TemporadaClasificacion = new HashSet<TemporadaClasificacion>();
            TemporadaJornadaJugador = new HashSet<TemporadaJornadaJugador>();
            TemporadaPartido = new HashSet<TemporadaPartido>();
        }

        public int Temporada_ID { get; set; }

        public int Competicion_ID { get; set; }

        public int Numero_Jornada { get; set; }

        public DateTime Fecha { get; set; }

        public bool Actual { get; set; }

        public bool Carrusel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alineacion> Alineacion { get; set; }

        public virtual Competicion Competicion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaClasificacion> TemporadaClasificacion { get; set; }

        public virtual Temporada Temporada { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaJornadaJugador> TemporadaJornadaJugador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaPartido> TemporadaPartido { get; set; }
    }
}
