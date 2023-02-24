using General.CrossCutting.Lib;

using System;

namespace Ligamania.Repository.Models
{
    public partial class AlineacionCambioDTO : Entity, IAuditableAlineacionEntity
    {
        public int Temporada_ID { get; set; }
        public int Competicion_ID { get; set; }
        public int Categoria_ID { get; set; }
        public int Equipo_ID { get; set; }
        public int Jugador_ID { get; set; }
        public int Club_ID { get; set; }
        public int Puesto_ID { get; set; }

        [Obsolete]
        public int? JugadorCambio_ID { get; set; }

        [Obsolete]
        public int? ClubCambio_ID { get; set; }

        public virtual CategoriaDTO Categoria { get; set; }
        public virtual ClubDTO Club { get; set; }

        [Obsolete]
        public virtual ClubDTO ClubCambio { get; set; }

        public virtual CompeticionDTO Competicion { get; set; }
        public virtual TemporadaEquipoDTO Equipo { get; set; }
        public virtual JugadorDTO Jugador { get; set; }

        [Obsolete]
        public virtual JugadorDTO JugadorCambio { get; set; }

        public virtual PuestoDTO Puesto { get; set; }
        public virtual TemporadaDTO Temporada { get; set; }
    }
}