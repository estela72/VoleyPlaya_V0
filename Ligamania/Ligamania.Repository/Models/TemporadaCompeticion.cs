using General.CrossCutting.Lib;

using System.Collections.Generic;

namespace Ligamania.Repository.Models
{
    public partial class TemporadaCompeticionDTO : BaseEntity
    {
        public TemporadaCompeticionDTO()
        {
            TemporadaCompeticionOperacion = new HashSet<TemporadaCompeticionOperacionDTO>();
            TemporadaCuadroCompeticion = new HashSet<TemporadaCuadroDTO>();
            TemporadaCuadroEquipoACompeticion = new HashSet<TemporadaCuadroDTO>();
            TemporadaCuadroEquipoBCompeticion = new HashSet<TemporadaCuadroDTO>();
        }

        public string GetEstadoOperacion()
        {
            string estado = LigamaniaConst.JI_EstadoInicial;
            if (EstadoActual != null && OperacionActual != null)
                estado = EstadoActual.Estado + "-" + OperacionActual.Operacion;
            if (EstadoActual != null && OperacionActual == null)
            {
                if (EstadoActual.Estado.Equals(LigamaniaConst.Estado_Jornada_Inicial))
                    return estado;
                else
                    return LigamaniaConst.SinDefinir;
            }
            return estado;
        }

        public int CambiosFijos { get; set; }
        public bool Activa { get; set; }
        public string DescripcionEstado { get; set; }
        public int TemporadaId { get; set; }
        public int CompeticionId { get; set; }
        public int? EstadoActualId { get; set; }
        public int? OperacionActualId { get; set; }

        public virtual CompeticionDTO Competicion { get; set; }
        public virtual EstadoCompeticionDTO EstadoActual { get; set; }
        public virtual OperacionCompeticionDTO OperacionActual { get; set; }
        public virtual TemporadaDTO Temporada { get; set; }
        public virtual ICollection<TemporadaCompeticionOperacionDTO> TemporadaCompeticionOperacion { get; set; }
        public virtual ICollection<TemporadaCuadroDTO> TemporadaCuadroCompeticion { get; set; }
        public virtual ICollection<TemporadaCuadroDTO> TemporadaCuadroEquipoACompeticion { get; set; }
        public virtual ICollection<TemporadaCuadroDTO> TemporadaCuadroEquipoBCompeticion { get; set; }
    }
}