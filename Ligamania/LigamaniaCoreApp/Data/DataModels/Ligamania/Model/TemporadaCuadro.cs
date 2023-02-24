using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public partial class TemporadaCuadroDTO : AuditableEntity
    {
        public int Orden { get; set; }
        public string NombreEquipoA { get; set; }
        public string NombreEquipoB { get; set; }
        public string NombreGanador { get; set; }
        public int TemporadaId { get; set; }
        public int CompeticionId { get; set; }
        public int EquipoACompeticionId { get; set; }
        public int EquipoACategoriaId { get; set; }
        public int EquipoBCompeticionId { get; set; }
        public int EquipoBCategoriaId { get; set; }
        public int Ronda { get; set; }
        public int EquipoAPuesto { get; set; }
        public int EquipoBPuesto { get; set; }
        public int? NumeroPartido { get; set; }
        public string Criterio { get; set; }

        public virtual TemporadaCompeticionDTO Competicion { get; set; }
        public virtual TemporadaCompeticionCategoriaDTO EquipoACategoria { get; set; }
        public virtual TemporadaCompeticionDTO EquipoACompeticion { get; set; }
        public virtual TemporadaCompeticionCategoriaDTO EquipoBCategoria { get; set; }
        public virtual TemporadaCompeticionDTO EquipoBCompeticion { get; set; }
        public virtual TemporadaDTO Temporada { get; set; }
    }
}
