using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public partial class JugadorDTO : AuditableNameEntity
    {
        public JugadorDTO()
        {
            Alineacion = new HashSet<AlineacionDTO>();
            AlineacionCambioJugador = new HashSet<AlineacionCambioDTO>();
            AlineacionCambioJugadorCambio = new HashSet<AlineacionCambioDTO>();
            AlineacionPrevia = new HashSet<AlineacionPreviaDTO>();
            TemporadaJornadaJugador = new HashSet<TemporadaJornadaJugadorDTO>();
            TemporadaJugador = new HashSet<TemporadaJugadorDTO>();

            //TemporadaClubJugador = new HashSet<TemporadaClubJugador_DTO>();
            //TemporadaPuestoJugador = new HashSet<TemporadaPuestoJugador_DTO>();
        }

        public bool Baja { get; set; }
        public virtual ICollection<AlineacionDTO> Alineacion { get; set; }
        public virtual ICollection<AlineacionHistoricoDTO> AlineacionHistorica { get; set; }
        public virtual ICollection<AlineacionCambioDTO> AlineacionCambioJugador { get; set; }
        public virtual ICollection<AlineacionCambioDTO> AlineacionCambioJugadorCambio { get; set; }
        public virtual ICollection<AlineacionPreviaDTO> AlineacionPrevia { get; set; }
        public virtual ICollection<TemporadaJornadaJugadorDTO> TemporadaJornadaJugador { get; set; }
        public virtual ICollection<TemporadaJugadorDTO> TemporadaJugador { get; set; }

        [Obsolete]
        public virtual ICollection<TemporadaClubJugadorDTO> TemporadaClubJugador { get; set; }
        [Obsolete]
        public virtual ICollection<TemporadaPuestoJugadorDTO> TemporadaPuestoJugador { get; set; }
        [Obsolete]
        public virtual ICollection<TemporadaJugadorObsolete> TemporadaJugador_obsolete { get; set; }
    }
}
