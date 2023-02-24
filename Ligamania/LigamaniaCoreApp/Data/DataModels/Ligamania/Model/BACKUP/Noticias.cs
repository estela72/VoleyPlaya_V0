namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    using LigamaniaCoreApp.Data.DataModels.Base.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Noticia : AuditableEntity
    {
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [StringLength(8000)]
        public string Texto { get; set; }

        public int Nivel { get; set; }

        public bool Activa { get; set; }
    }
}
