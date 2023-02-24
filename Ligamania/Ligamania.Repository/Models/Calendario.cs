using General.CrossCutting.Lib;

using System.Collections.Generic;

namespace Ligamania.Repository.Models
{
    public partial class CalendarioDTO : Entity
    {
        public CalendarioDTO()
        {
            CalendarioDetalle = new HashSet<CalendarioDetalleDTO>();
        }

        public int NumEquipos { get; set; }

        public virtual ICollection<CalendarioDetalleDTO> CalendarioDetalle { get; set; }
    }
}