using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public class Calendario : AuditableNameEntity
    {
        public Calendario()
        {
            Jornadas = new HashSet<CalendarioDetalle>();
        }
        public int NumEquipos { get; set; }

        public ICollection<CalendarioDetalle> Jornadas { get; set; }
    }
}
