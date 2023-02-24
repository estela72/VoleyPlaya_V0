using General.CrossCutting.Lib;

using System;

namespace Ligamania.Repository.Models
{
    public partial class TemporadaClasificacionDTO : Entity
    {
        public int TemporadaId { get; set; }
        public int CompeticionId { get; set; }
        public int CategoriaId { get; set; }
        public int JornadaId { get; set; }
        public int EquipoId { get; set; }
        public DateTime FechaIns { get; set; }
        public int Puesto { get; set; }
        public int Jugados { get; set; }
        public int Ganados { get; set; }
        public int Perdidos { get; set; }
        public int Empatados { get; set; }
        public int GolesFavor { get; set; }
        public int GolesContra { get; set; }
        public int Diferencia { get; set; }
        public int Puntos { get; set; }

        public virtual CategoriaDTO Categoria { get; set; }
        public virtual CompeticionDTO Competicion { get; set; }
        public virtual EquipoDTO Equipo { get; set; }
        public virtual TemporadaCompeticionJornadaDTO Jornada { get; set; }
        public virtual TemporadaDTO Temporada { get; set; }
    }
}