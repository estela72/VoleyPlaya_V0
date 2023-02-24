using LigamaniaCoreApp.Models.ManagerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.InvitadoViewModels
{
    public class CalendarioCategoriaJornadaViewModel
    {
        public int Jornada { get; set; }
        public DateTime Fecha { get; set; }
        public List<TemporadaPartidoViewModel> Partidos { get; set; }

    }
}
