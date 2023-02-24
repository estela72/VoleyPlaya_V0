using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.InvitadoViewModels
{
    public class ClasificacionHistoricaViewModel
    {
        public List<PuntuacionHistoricaViewModel> LPuntuaciones { get; set; }
        public Dictionary<string, HistorialEquipoViewModel> LClasificacion { get; set; }

        //private List<string> EquiposCalculados;

        //public string EquipoSelected { get; set; }
    }
}
