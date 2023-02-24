using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public class CuadroCopaDTO : AuditableEntity
    {
        public int Ronda { get; set; }
        public int NumPartido { get; set; }
        public int CompeticionEquipoAId { get; set; }
        public int CategoriaEquipoAId { get; set; }
        public int CompeticionEquipoBId { get; set; }
        public int CategoriaEquipoBId { get; set; }
        public virtual CompeticionCategoriaDTO CompeticionCategoriaEquipoA { get; set; }
        public virtual CompeticionCategoriaDTO CompeticionCategoriaEquipoB { get; set; }
        public int PuestoPartidoEquipoA { get; set; }
        public int PuestoPartidoEquipoB { get; set; }
        public int Orden { get; set; }
    }
}
