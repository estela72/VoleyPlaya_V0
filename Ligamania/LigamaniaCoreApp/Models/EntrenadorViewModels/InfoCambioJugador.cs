using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.EntrenadorViewModels
{
    public class InfoCambioJugador
    {
        public string Equipo { get; set; }
        public string Competicion { get; set; }
        public int JugadorId { get; set; }
        public int JugadorCambioId { get; set; }
        public string Jugador { get; set; }
        public string JugadorCambio { get; set; }
    }
}
