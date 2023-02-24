using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public class CalendarioDetalle : AuditableEntity
    {
        public int Calendario_Id { get; set; }
        public int Jornada { get; set; }
        public string Local { get; set; }
        public string Visitante { get; set; }

        [ForeignKey("Calendario_Id")]
        public virtual Calendario Calendario { get; set; }
    }
}
