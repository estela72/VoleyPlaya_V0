using LigamaniaCoreApp.Models.ManagerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.EntrenadorViewModels
{
    public class AlineacionesCambiosViewModel
    {
        public string Entrenador { get; set; }
        public List<TemporadaEquipoViewModel> Equipos { get; set; }
    }
}
