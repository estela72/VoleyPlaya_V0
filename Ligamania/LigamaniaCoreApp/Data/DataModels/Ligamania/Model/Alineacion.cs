using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Interfaces;
using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public partial class AlineacionDTO : AuditableEntity, IAuditableAlineacionEntity
    {
        public int Temporada_ID { get; set; }
        public int Competicion_ID { get; set; }
        public int Categoria_ID { get; set; }
        public int Equipo_ID { get; set; }
        public int Jugador_ID { get; set; }
        public int Club_ID { get; set; }
        public int Puesto_ID { get; set; }
        public int Jornada_ID { get; set; }
        public virtual CategoriaDTO Categoria { get; set; }
        public virtual ClubDTO Club { get; set; }
        public virtual CompeticionDTO Competicion { get; set; }
        public virtual TemporadaEquipoDTO Equipo { get; set; }
        public virtual TemporadaCompeticionJornadaDTO Jornada { get; set; }
        public virtual JugadorDTO Jugador { get; set; }
        public virtual PuestoDTO Puesto { get; set; }
        public virtual TemporadaDTO Temporada { get; set; }
    }
}
