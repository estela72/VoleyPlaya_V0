using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public class CambiosEquipo : AuditableEntity
    {
        public virtual Temporada Temporada { get; set; }
        public virtual Equipo Equipo_Origen { get; set; }
        public virtual Equipo Equipo_Destino { get; set; }
    }
}
