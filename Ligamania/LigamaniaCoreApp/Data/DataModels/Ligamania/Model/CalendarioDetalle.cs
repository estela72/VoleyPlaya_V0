using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public partial class CalendarioDetalleDTO : AuditableEntity
    {
        public int Calendario_ID { get; set; }
        public int Jornada { get; set; }
        public string Local { get; set; }
        public string Visitante { get; set; }
        public virtual CalendarioDTO Calendario { get; set; }
    }
}
