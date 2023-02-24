namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    using LigamaniaCoreApp.Data.DataModels.Base.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Jugador : AuditableNameEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Jugador()
        {
            Alineacion_Cambio = new HashSet<Alineacion_Cambio>();
            Alineacion_Cambio1 = new HashSet<Alineacion_Cambio>();
            Alineacion_Previa = new HashSet<Alineacion_Previa>();
            Alineacion = new HashSet<Alineacion>();
            TemporadaClubJugador = new HashSet<TemporadaClubJugador>();
            TemporadaJornadaJugador = new HashSet<TemporadaJornadaJugador>();
            TemporadaJugador = new HashSet<TemporadaJugador>();
            TemporadaPuestoJugador = new HashSet<TemporadaPuestoJugador>();
        }
        public bool Baja { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alineacion_Cambio> Alineacion_Cambio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alineacion_Cambio> Alineacion_Cambio1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alineacion_Previa> Alineacion_Previa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alineacion> Alineacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaClubJugador> TemporadaClubJugador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaJornadaJugador> TemporadaJornadaJugador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaJugador> TemporadaJugador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaPuestoJugador> TemporadaPuestoJugador { get; set; }
    }
}
