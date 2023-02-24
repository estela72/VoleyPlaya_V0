using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.ManagerViewModels
{
    public class TemporadaRondaViewModel
    {
        public int Ronda { get; set; }
        public bool Final { get; set; }
        public int JornadaIda { get; set; }
        public int JornadaVuelta { get; set; }
    }
}
