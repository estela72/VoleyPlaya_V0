using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public partial class TemporadaPremiosPuestoDTO : AuditableEntity
    {
        public int PremioCategoriaId { get; set; }
        public int Puesto { get; set; }
        public double Porcentaje { get; set; }
        public double PorcentajeAjustado { get; set; }
        public double Importe { get; set; }

        public virtual TemporadaPremiosDTO PremioCategoria { get; set; }
    }
}
