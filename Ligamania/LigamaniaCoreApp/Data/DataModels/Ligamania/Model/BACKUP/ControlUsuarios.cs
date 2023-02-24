namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    using LigamaniaCoreApp.Data.DataModels.Base.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ControlUsuario : AuditableEntity
    {
        [StringLength(8000)]
        public string Usuario { get; set; }

        public DateTime Fecha { get; set; }

        [StringLength(8000)]
        public string Accion { get; set; }
    }
}
