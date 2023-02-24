using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    [Obsolete]
    public partial class TemporadaCategoriaReferenciaDTO : AuditableEntity
    {
        public int TemporadaCategoriaId { get; set; }
        public int PosicionInicial { get; set; }
        public int PosicionFinal { get; set; }
        public string Descripcion { get; set; }
        public bool UsarMarca { get; set; }
        public bool UsarColor { get; set; }
        public bool EsPremio { get; set; }
        public int Argb { get; set; }
        public string Marca { get; set; }
        public int? TemporadaId { get; set; }

        public virtual TemporadaCompeticionCategoriaDTO TemporadaCompeticionCategoria { get; set; }
        public virtual TemporadaDTO Temporada { get; set; }

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
