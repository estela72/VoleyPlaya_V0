namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    using LigamaniaCoreApp.Data.DataModels.Base.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TemporadaCategoriaReferencia")]
    public partial class TemporadaCategoriaReferencia : AuditableEntity
    {
        public int Categoria_ID { get; set; }

        public int Posicion_Inicial { get; set; }

        public int Posicion_Final { get; set; }

        [StringLength(8000)]
        public string Descripcion { get; set; }

        public bool UsarMarca { get; set; }

        public bool UsarColor { get; set; }

        public bool EsPremio { get; set; }

        public int Argb { get; set; }

        [StringLength(8000)]
        public string Marca { get; set; }

        public virtual TemporadaCompeticionCategoria TemporadaCompeticionCategoria { get; set; }

        [NotMapped]
        [Display(Name = "Color de referencia")]
        public System.Drawing.Color Color
        {
            get { return System.Drawing.Color.FromArgb(this.Argb); }
            set
            {
                if (value != null)
                    this.Argb = value.ToArgb();
                else
                    this.Argb = 0;
            }
        }
    }
}
