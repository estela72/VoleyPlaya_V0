using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.ManagerViewModels
{
    public class AccionUsuarioViewModel
    {
        public string Equipo { get; set; }
        public string Entrenador { get; set; }
        public string Accion { get; set; }
        public DateTime Fecha { get; set; }
    }
}
