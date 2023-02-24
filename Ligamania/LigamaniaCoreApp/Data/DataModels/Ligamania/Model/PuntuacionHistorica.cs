using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public partial class PuntuacionHistoricaDTO : AuditableEntity
    {
        public int Campeon { get; set; }
        public int Subcampeon { get; set; }
        public int Tercero { get; set; }
        public int Pichichi { get; set; }
        public int Todos { get; set; }
        public int? Categoria_Id { get; set; }
        public int? Competicion_Id { get; set; }

        public virtual CategoriaDTO Categoria { get; set; }
        public virtual CompeticionDTO Competicion { get; set; }
    }
}
