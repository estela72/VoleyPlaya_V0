using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.ManagerViewModels
{
    public class TemporadaRondaPartidos
    {
        public int Ronda { get; set; }
        public int JornadaIda { get; set; }
        public DateTime FechaIda { get; set; }
        public int JornadaVuelta { get; set; }
        public DateTime FechaVuelta { get; set; }
        public bool RondaFinal { get; set; }
        public List<int> JornadasFinales { get; set; }
        public List<DateTime> FechasFinales { get; set; }
        public List<TemporadaPartidoRondaViewModel> Partidos { get; set; }

    }
}
