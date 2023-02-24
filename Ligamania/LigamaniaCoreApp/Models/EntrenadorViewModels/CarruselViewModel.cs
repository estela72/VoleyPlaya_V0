using LigamaniaCoreApp.Models.ManagerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.EntrenadorViewModels
{
    public class CarruselViewModel
    {
        public string Competicion { get; set; }
        public string Categoria { get; set; }
        public int Jornada { get; set; }
        public int RondaActual { get; set; }
        public int JornadaActual { get; set; }
        public List<TemporadaPartidoViewModel> Partidos { get; set; }
    }
}
