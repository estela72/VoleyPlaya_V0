using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public partial class EntrenadorDTO : AuditableNameEntity
    {
        public EntrenadorDTO()
        {
            //Equipo = new HashSet<Equipo_DTO>();
        }

        public string Email { get; set; }
        public bool Baja { get; set; }
        public bool EsBot { get; set; }

        //public virtual ICollection<Equipo_DTO> Equipo { get; set; }
    }
}
