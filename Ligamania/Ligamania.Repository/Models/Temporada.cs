using General.CrossCutting.Lib;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ligamania.Repository.Models
{
    public partial class TemporadaDTO : Entity
    {
        public TemporadaDTO()
        {
            Alineacion = new HashSet<AlineacionDTO>();
            AlineacionCambio = new HashSet<AlineacionCambioDTO>();
            AlineacionPrevia = new HashSet<AlineacionPreviaDTO>();
            CambiosEquipo = new HashSet<CambiosEquipoDTO>();
            Historico = new HashSet<HistoricoDTO>();
            TemporadaCompeticionCategoriaReferencia = new HashSet<TemporadaCompeticionCategoriaReferenciaDTO>();
            TemporadaClasificacion = new HashSet<TemporadaClasificacionDTO>();
            TemporadaCompeticion = new HashSet<TemporadaCompeticionDTO>();
            TemporadaCompeticionCategoria = new HashSet<TemporadaCompeticionCategoriaDTO>();
            TemporadaCompeticionJornada = new HashSet<TemporadaCompeticionJornadaDTO>();
            TemporadaContabilidad = new HashSet<TemporadaContabilidadDTO>();
            TemporadaCuadro = new HashSet<TemporadaCuadroDTO>();
            TemporadaEquipo = new HashSet<TemporadaEquipoDTO>();
            TemporadaJornadaJugador = new HashSet<TemporadaJornadaJugadorDTO>();
            TemporadaJugador = new HashSet<TemporadaJugadorDTO>();
            TemporadaPartido = new HashSet<TemporadaPartidoDTO>();
            Rondas = new HashSet<TemporadaRondaDTO>();
            //TemporadaPuestoJugador = new HashSet<TemporadaPuestoJugador_DTO>();
            //TemporadaClubJugador = new HashSet<TemporadaClubJugador_DTO>();
        }

        public bool Actual { get; set; }
        public string Estado { get; set; }

        ////[NotMapped]
        public byte[] Img_Clasificacion { get; set; }

        public virtual ICollection<AlineacionDTO> Alineacion { get; set; }
        public virtual ICollection<AlineacionHistoricoDTO> AlineacionHistorica { get; set; }
        public virtual ICollection<AlineacionCambioDTO> AlineacionCambio { get; set; }
        public virtual ICollection<AlineacionPreviaDTO> AlineacionPrevia { get; set; }
        public virtual ICollection<CambiosEquipoDTO> CambiosEquipo { get; set; }
        public virtual ICollection<HistoricoDTO> Historico { get; set; }
        public virtual ICollection<TemporadaCompeticionCategoriaReferenciaDTO> TemporadaCompeticionCategoriaReferencia { get; set; }
        public virtual ICollection<TemporadaClasificacionDTO> TemporadaClasificacion { get; set; }
        public virtual ICollection<TemporadaCompeticionDTO> TemporadaCompeticion { get; set; }
        public virtual ICollection<TemporadaCompeticionCategoriaDTO> TemporadaCompeticionCategoria { get; set; }
        public virtual ICollection<TemporadaCompeticionJornadaDTO> TemporadaCompeticionJornada { get; set; }
        public virtual ICollection<TemporadaContabilidadDTO> TemporadaContabilidad { get; set; }
        public virtual ICollection<TemporadaCuadroDTO> TemporadaCuadro { get; set; }
        public virtual ICollection<TemporadaEquipoDTO> TemporadaEquipo { get; set; }
        public virtual ICollection<TemporadaJornadaJugadorDTO> TemporadaJornadaJugador { get; set; }
        public virtual ICollection<TemporadaJugadorDTO> TemporadaJugador { get; set; }
        public virtual ICollection<TemporadaPartidoDTO> TemporadaPartido { get; set; }
        public virtual ICollection<TemporadaRondaDTO> Rondas { get; set; }

        [Obsolete]
        public virtual ICollection<TemporadaClubJugadorDTO> TemporadaClubJugador { get; set; }

        [Obsolete]
        public virtual ICollection<TemporadaPuestoJugadorDTO> TemporadaPuestoJugador { get; set; }

        [Obsolete]
        public virtual ICollection<TemporadaJugadorObsolete> TemporadaJugador_obsolete { get; set; }
    }
}