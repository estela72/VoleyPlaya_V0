using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public class TemporadaContabilidad : AuditableEntity
    {
        public int Temporada_ID { get; set; }

        public virtual Temporada Temporada { get; set; }
        public string Concepto { get; set; }
        public double Valor { get; set; }
        public bool Gasto { get; set; }

        public bool Equipo { get; set; }
    }
}
