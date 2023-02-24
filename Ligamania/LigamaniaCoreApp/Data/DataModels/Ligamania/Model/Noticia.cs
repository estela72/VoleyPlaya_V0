using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public partial class NoticiaDTO : AuditableEntity
    {
        public DateTime Fecha { get; set; }
        public string Texto { get; set; }
        public int Nivel { get; set; }
        public bool Activa { get; set; }
    }
}
