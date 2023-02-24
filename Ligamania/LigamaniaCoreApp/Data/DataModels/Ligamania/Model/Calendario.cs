using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public partial class CalendarioDTO : AuditableNameEntity
    {
        public CalendarioDTO()
        {
            CalendarioDetalle = new HashSet<CalendarioDetalleDTO>();
        }

        public int NumEquipos { get; set; }

        public virtual ICollection<CalendarioDetalleDTO> CalendarioDetalle { get; set; }
    }
}
