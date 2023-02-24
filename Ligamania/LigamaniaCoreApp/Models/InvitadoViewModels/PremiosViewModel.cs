using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.InvitadoViewModels
{
    public class PremiosViewModel
    {
        public List<PremioCompeticionViewModel> Premios { get; set; }
        public List<ContabilidadViewModel> Contabilidad { get; set; }
        public string Temporada { get; set; }
        public int Gastos { get; set; }
        public int NumEquipos { get; set; }
        public int Recaudacion { get; set; }
        public int TotalPremios { get; set; }
        public bool Editable { get; set; }
    }
}
