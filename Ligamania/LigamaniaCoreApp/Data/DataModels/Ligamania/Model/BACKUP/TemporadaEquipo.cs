namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    using LigamaniaCoreApp.Data.DataModels.Base.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TemporadaEquipo")]
    public partial class TemporadaEquipo : AuditableEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TemporadaEquipo()
        {
            Alineacion_Cambio = new HashSet<Alineacion_Cambio>();
            Alineacion_Previa = new HashSet<Alineacion_Previa>();
            Alineacion = new HashSet<Alineacion>();
            Historico = new HashSet<Historico>();
        }

        public int Temporada_ID { get; set; }

        public int Competicion_ID { get; set; }

        public int Categoria_ID { get; set; }

        public int Equipo_ID { get; set; }

        public int PartidosJugados { get; set; }

        public int PartidosGanados { get; set; }

        public int PartidosPerdidos { get; set; }

        public int PartidosEmpatados { get; set; }

        public int GolesFavor { get; set; }

        public int GolesContra { get; set; }

        public int Diferencia { get; set; }

        public int Puntos { get; set; }

        public bool ConfirmadaTemporada { get; set; }
        public bool PagadaTemporada { get; set; }
        public bool Baja { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alineacion_Cambio> Alineacion_Cambio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alineacion_Previa> Alineacion_Previa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alineacion> Alineacion { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual Competicion Competicion { get; set; }

        public virtual Equipo Equipo { get; set; }

        public virtual Temporada Temporada { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historico> Historico { get; set; }

    }
}
