using LigamaniaCoreApp.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.ManagerViewModels
{
    public class EntrenadorEquipoViewModel
    {
        public List<RegisterViewModel> Entrenadores { get; set; }
        public List<EquipoViewModel> Equipos { get; set; }
        public List<RegisterViewModel> InventarioEntrenadores { get; set; }
        public List<string> ExistingRoles { get; set; }
    }
}
