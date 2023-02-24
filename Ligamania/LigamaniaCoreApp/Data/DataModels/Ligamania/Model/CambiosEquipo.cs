using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public partial class CambiosEquipoDTO : AuditableEntity
    {
        public int? EquipoDestino_ID { get; set; }
        public int? EquipoOrigen_ID { get; set; }
        public int? Temporada_ID { get; set; }

        public virtual EquipoDTO EquipoDestino { get; set; }
        public virtual EquipoDTO EquipoOrigen { get; set; }
        public virtual TemporadaDTO Temporada { get; set; }
    }
}
