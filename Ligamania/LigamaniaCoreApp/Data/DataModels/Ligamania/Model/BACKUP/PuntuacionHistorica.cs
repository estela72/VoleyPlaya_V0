using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public class PuntuacionHistorica : AuditableEntity
    {
        public virtual Competicion Competicion { get; set; }
        public virtual Categoria Categoria { get; set; }

        public int Campeon { get; set; }
        public int Subcampeon { get; set; }
        public int Tercero { get; set; }
        public int Pichichi { get; set; }
        public int Todos { get; set; }

    }
}
