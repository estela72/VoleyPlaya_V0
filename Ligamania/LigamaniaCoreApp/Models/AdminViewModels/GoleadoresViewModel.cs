using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.AdminViewModels
{
    public class GoleadoresViewModel
    {
        public string Club { get; set; }
        //public int Jornada { get; set; }
        public DateTime Fecha { get; set; }

        public ICollection<TemporadaJornadaJugadorViewModel> Jugadores { get; set; }

        public Dictionary<string, int> CompeticionJornada { get; set; }
    }
}
