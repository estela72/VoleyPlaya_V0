using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LigamaniaCoreApp.Data.LigamaniaEnum;

namespace LigamaniaCoreApp.Models.ManagerViewModels
{
    public class CompeticionCategoriaViewModel
    {
        public string Competicion { get; set; }
        public string Categoria { get; set; }

        public bool RepetirClubAliIni { get; set; }
        public int JornadaCuadro { get; set; }
        public bool CopiarAlineacionInicial { get; set; }
        public string CompeticionCopiarAliIni { get; set; }
        public int OrdenCompeticion { get; set; }
        public eTipoCompeticion Tipo { get; set; }
        public int OrdenCategoria { get; set; }
        public bool CategoriaActiva { get; set; }

        public int IdCompeticion { get; set; }
        public int IdCategoria { get; set; }

        public ICollection<ReferenciaCompeticionViewModel> Referencias { get; set; }
    }
}
