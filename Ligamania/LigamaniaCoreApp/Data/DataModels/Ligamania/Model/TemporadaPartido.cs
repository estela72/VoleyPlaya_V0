using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public partial class TemporadaPartidoDTO : AuditableEntity
    {
        public int TemporadaId { get; set; }
        public int CompeticionId { get; set; }
        public int CategoriaId { get; set; }
        public int JornadaId { get; set; }
        public int NumeroPartido { get; set; }
        public int ResultadoA { get; set; }
        public int ResultadoB { get; set; }
        public int? EquipoAId { get; set; }
        public int? EquipoBId { get; set; }
        public int? EquipoGanadorId { get; set; }

        public virtual CategoriaDTO Categoria { get; set; }
        public virtual CompeticionDTO Competicion { get; set; }
        public virtual EquipoDTO EquipoA { get; set; }
        public virtual EquipoDTO EquipoB { get; set; }
        public virtual EquipoDTO EquipoGanador { get; set; }
        public virtual TemporadaCompeticionJornadaDTO Jornada { get; set; }
        public virtual TemporadaDTO Temporada { get; set; }
    }
}
