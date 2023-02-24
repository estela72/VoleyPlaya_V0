using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public class TemporadaPremiosPuesto : AuditableEntity
    {
        public int PremioCategoria_ID { get; set; }
        public virtual TemporadaPremios PremioCategoria { get; set; }

        public int Puesto { get; set; }
        public double Porcentaje { get; set; }
        public double PorcentajeAjustado { get; set; }
    }
}
