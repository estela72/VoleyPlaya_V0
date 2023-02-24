using LigamaniaCoreApp.Models.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.ManagerViewModels
{
    public class InfoPreparacionTemporadaViewModel
    {
        public TemporadaViewModel Actual { get; set; }
        public TemporadaViewModel Pretemporada { get; set; }
        public List<TemporadaJugadorViewModel> Jugadores { get; set; }
        public string Message { get; set; }
    }
}
