using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.HerramientasViewModels
{
    public class JugadorRepositoryViewModel
    {
        public int Id { get; set; }
        public int IdTemporada { get; set; }
        public string Jugador { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaJugador { get; set; }
        public string Temporada { get; set; }
        public string Club { get; set; }
        public string Puesto { get; set; }
        public bool ActivoTemporada { get; set; }
        public DateTime FechaTemporada { get; set; }
        public int UsadoEnAlineaciones { get; set; }
        public int UsadoEnJornadas { get; set; }
    }
}
