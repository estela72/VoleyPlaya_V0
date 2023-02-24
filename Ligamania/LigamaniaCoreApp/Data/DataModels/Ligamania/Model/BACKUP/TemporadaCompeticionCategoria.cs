namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    using LigamaniaCoreApp.Data.DataModels.Base.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TemporadaCompeticionCategoria")]
    public partial class TemporadaCompeticionCategoria : AuditableEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TemporadaCompeticionCategoria()
        {
            Referencias = new HashSet<TemporadaCategoriaReferencia>();
            TemporadaCuadro = new HashSet<TemporadaCuadro>();
            TemporadaCuadro1 = new HashSet<TemporadaCuadro>();
            TemporadaPremios = new HashSet<TemporadaPremios>();
            Historico = new HashSet<Historico>();
        }

        public int Temporada_ID { get; set; }

        public int Competicion_ID { get; set; }

        public int Categoria_ID { get; set; }

        public int NumeroMaximoJugador_Eliminar { get; set; }

        public bool MarcarPichichi { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual Competicion Competicion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaCategoriaReferencia> Referencias { get; set; }

        public virtual Temporada Temporada { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaCuadro> TemporadaCuadro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaCuadro> TemporadaCuadro1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaPremios> TemporadaPremios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historico> Historico { get; set; }

    }
}
