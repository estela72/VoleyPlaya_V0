using General.CrossCutting.Lib;

using System;
using System.Collections.Generic;

namespace Ligamania.Repository.Models
{
    public partial class PuestoDTO : Entity
    {
        public PuestoDTO()
        {
            Alineacion = new HashSet<AlineacionDTO>();
            AlineacionCambio = new HashSet<AlineacionCambioDTO>();
            AlineacionPrevia = new HashSet<AlineacionPreviaDTO>();
            TemporadaJugador = new HashSet<TemporadaJugadorDTO>();

            //TemporadaPuestoJugador = new HashSet<TemporadaPuestoJugador_DTO>();
        }

        public int Orden { get; set; }

        public virtual ICollection<AlineacionDTO> Alineacion { get; set; }
        public virtual ICollection<AlineacionHistoricoDTO> AlineacionHistorica { get; set; }
        public virtual ICollection<AlineacionCambioDTO> AlineacionCambio { get; set; }
        public virtual ICollection<AlineacionPreviaDTO> AlineacionPrevia { get; set; }
        public virtual ICollection<TemporadaJugadorDTO> TemporadaJugador { get; set; }

        [Obsolete]
        public virtual ICollection<TemporadaPuestoJugadorDTO> TemporadaPuestoJugador { get; set; }
    }
}