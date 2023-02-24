namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    using LigamaniaCoreApp.Data.DataModels.Base.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Puesto : AuditableNameEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Puesto()
        {
            Alineacion_Cambio = new HashSet<Alineacion_Cambio>();
            Alineacion_Previa = new HashSet<Alineacion_Previa>();
            Alineacion = new HashSet<Alineacion>();
            TemporadaPuestoJugador = new HashSet<TemporadaPuestoJugador>();
        }
        public int Orden { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alineacion_Cambio> Alineacion_Cambio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alineacion_Previa> Alineacion_Previa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alineacion> Alineacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaPuestoJugador> TemporadaPuestoJugador { get; set; }
    }
}
