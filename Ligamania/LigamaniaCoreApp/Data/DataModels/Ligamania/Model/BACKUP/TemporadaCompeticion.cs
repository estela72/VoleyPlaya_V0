namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    using LigamaniaCoreApp.Data.DataModels.Base.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TemporadaCompeticion")]
    public partial class TemporadaCompeticion : AuditableEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TemporadaCompeticion()
        {
            TemporadaCompeticionOperacion = new HashSet<TemporadaCompeticionOperacion>();
            TemporadaCuadro = new HashSet<TemporadaCuadro>();
            TemporadaCuadro1 = new HashSet<TemporadaCuadro>();
            TemporadaCuadro2 = new HashSet<TemporadaCuadro>();
        }

        public int CambiosFijos { get; set; }

        public bool Activa { get; set; }

        [StringLength(8000)]
        public string DescripcionEstado { get; set; }

        public int Temporada_ID { get; set; }

        public int Competicion_ID { get; set; }

        public int? EstadoActual_Id { get; set; }

        public int? OperacionActual_Id { get; set; }

        public virtual Competicion Competicion { get; set; }

        public virtual EstadoCompeticion EstadoActual { get; set; }

        public virtual OperacionCompeticion OperacionActual { get; set; }

        public virtual Temporada Temporada { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaCompeticionOperacion> TemporadaCompeticionOperacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaCuadro> TemporadaCuadro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaCuadro> TemporadaCuadro1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaCuadro> TemporadaCuadro2 { get; set; }

        public string GetEstadoOperacion()
        {
            string estado = string.Empty;
            if (EstadoActual != null && OperacionActual != null)
                estado = EstadoActual.Estado + "-" + OperacionActual.Operacion;
            return estado;
        }
    }
}
