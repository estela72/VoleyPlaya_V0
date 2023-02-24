using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.AdminViewModels
{
    public class TemporadaJugadorViewModel
    {
        public int IdTemporadaJugador { get; set; }
        public int IdJugador { get; set; }
        public string Jugador { get; set; }
        public bool Activo { get; set; }
        public string Club { get; set; }
        public bool ClubActivo { get; set; }
        public string Puesto { get; set; }
        public string Temporada { get; set; }
        public bool Baja { get; set; }
        public int OrdenPuesto { get; set; }
    }
}
