using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public partial class ClubDTO : AuditableNameEntity
    {
        public ClubDTO()
        {
            Alineacion = new HashSet<AlineacionDTO>();
            AlineacionCambioClub = new HashSet<AlineacionCambioDTO>();
            AlineacionCambioClubCambio = new HashSet<AlineacionCambioDTO>();
            AlineacionPrevia = new HashSet<AlineacionPreviaDTO>();
            //TemporadaClubJugador = new HashSet<TemporadaClubJugador_DTO>();
            TemporadaJugador = new HashSet<TemporadaJugadorDTO>();
        }

        public string Alias { get; set; }
        public bool Baja { get; set; }
        public virtual ICollection<AlineacionDTO> Alineacion { get; set; }
        public virtual ICollection<AlineacionHistoricoDTO> AlineacionHistorica { get; set; }
        public virtual ICollection<AlineacionCambioDTO> AlineacionCambioClub { get; set; }
        public virtual ICollection<AlineacionCambioDTO> AlineacionCambioClubCambio { get; set; }
        public virtual ICollection<AlineacionPreviaDTO> AlineacionPrevia { get; set; }
        [Obsolete]
        public virtual ICollection<TemporadaClubJugadorDTO> TemporadaClubJugador { get; set; }
        public virtual ICollection<TemporadaJugadorDTO> TemporadaJugador { get; set; }
    }
}
