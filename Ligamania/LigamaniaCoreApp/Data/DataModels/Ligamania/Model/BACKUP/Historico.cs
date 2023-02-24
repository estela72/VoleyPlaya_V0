using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public class Historico : AuditableEntity
    {
        public int Temporada_ID { get; set; }
        public virtual Temporada Temporada { get; set; }
        public int Equipo_ID { get; set; }
        public virtual TemporadaEquipo Equipo { get; set; }
        public int Categoria_ID { get; set; }
        public virtual TemporadaCompeticionCategoria Categoria {get;set;}

        public int Puesto { get; set; }
        public bool Pichichi { get; set; }
    }
}
