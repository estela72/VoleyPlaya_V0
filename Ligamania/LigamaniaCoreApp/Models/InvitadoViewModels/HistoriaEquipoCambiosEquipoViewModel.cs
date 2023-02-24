using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.InvitadoViewModels
{
    public class HistoriaEquipoCambiosEquipoViewModel
    {
        public string Temporada { get; set; }
        public string Equipo { get; set; }
        public HistoriaEquipoCambiosEquipoViewModel(string temp, string equi)
        {
            Temporada = temp;
            Equipo = equi;
        }
    }
}
