namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    using LigamaniaCoreApp.Data.DataModels.Base.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Equipo : AuditableNameEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Equipo()
        {
            TemporadaClasificacion = new HashSet<TemporadaClasificacion>();
            TemporadaEquipo = new HashSet<TemporadaEquipo>();
            TemporadaPartido_Ganador = new HashSet<TemporadaPartido>();
            TemporadaPartido_EquipoA = new HashSet<TemporadaPartido>();
            TemporadaPartido_EquipoB = new HashSet<TemporadaPartido>();
        }

        public byte[] EscudoImage { get; set; }

        public bool Baja { get; set; }

        public int? Entrenador_Id { get; set; }

        public virtual Entrenador Entrenador { get; set; }
        public bool EsBOT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaClasificacion> TemporadaClasificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaEquipo> TemporadaEquipo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaPartido> TemporadaPartido_Ganador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaPartido> TemporadaPartido_EquipoA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaPartido> TemporadaPartido_EquipoB { get; set; }
    }
}
