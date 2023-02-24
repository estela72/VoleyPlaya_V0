using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static LigamaniaCoreApp.Data.LigamaniaEnum;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public partial class HistoricoDTO : AuditableEntity
    {
        public int Temporada_ID { get; set; }
        public int Equipo_ID { get; set; }
        public int Categoria_ID { get; set; }
        public int Puesto { get; set; }
        public bool Pichichi { get; set; }

        public virtual TemporadaCompeticionCategoriaDTO TemporadaCompeticionCategoria { get; set; }
        public virtual TemporadaEquipoDTO TemporadaEquipo { get; set; }
        public virtual TemporadaDTO Temporada { get; set; }

        [NotMapped]
        public bool Visible
        {
            get
            {
                if (Temporada == null) return false;
                if (!Temporada.Actual) return true;
                else
                {
                    if (Temporada.Estado.Equals(EEstadoTemporada.Cerrada.ToString()) || Temporada.Estado.Equals(EEstadoTemporada.Finalizada.ToString()))
                        return true;
                }
                return false;
            }
        }
    }
}
