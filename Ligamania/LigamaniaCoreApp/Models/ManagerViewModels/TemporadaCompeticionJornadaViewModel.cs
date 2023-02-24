using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.ManagerViewModels
{
    public class TemporadaCompeticionJornadaViewModel
    {
        public string Temporada { get; set; }
        public string Competicion { get; set; }
        public int NumeroJornada { get; set; }
        public DateTime Fecha { get; set; }
        public bool Actual { get; set; }
        public bool Carrusel { get; set; }

    }
}
