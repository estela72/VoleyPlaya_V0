using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public partial class ControlUsuarioDTO : AuditableEntity
    {
        public string Usuario { get; set; }
        public string Equipo { get; set; }
        public DateTime Fecha { get; set; }
        public string Accion { get; set; }
    }
}
