namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    using LigamaniaCoreApp.Data.DataModels.Base.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EstadoCompeticion")]
    public partial class EstadoCompeticion : AuditableEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EstadoCompeticion()
        {
            TemporadaCompeticion = new HashSet<TemporadaCompeticion>();
            TemporadaCompeticionOperacion = new HashSet<TemporadaCompeticionOperacion>();
            TemporadaCompeticionOperacion1 = new HashSet<TemporadaCompeticionOperacion>();
        }

        [Required]
        [StringLength(100)]
        public string Estado { get; set; }

        [StringLength(8000)]
        public string Descripcion { get; set; }

        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaCompeticion> TemporadaCompeticion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaCompeticionOperacion> TemporadaCompeticionOperacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaCompeticionOperacion> TemporadaCompeticionOperacion1 { get; set; }
    }
}
