using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public class TemporadaPremios : AuditableEntity
    {
        public int Categoria_ID { get; set; }
        public virtual TemporadaCompeticionCategoria Categoria { get; set; }
        
        public double Porcentaje { get; set; }
        public double PorcentajeAjustado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemporadaPremiosPuesto> TemporadaPremiosPuesto { get; set; }
    }
}
