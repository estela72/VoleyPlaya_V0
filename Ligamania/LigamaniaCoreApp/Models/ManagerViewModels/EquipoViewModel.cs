using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.ManagerViewModels
{
    public class EquipoViewModel
    {
        public int Id { get; set; }
        public string Equipo { get; set; }
        public string Entrenador { get; set; }
        public bool Baja { get; set; }
        public bool EsBOT { get; set; }
    }
}
