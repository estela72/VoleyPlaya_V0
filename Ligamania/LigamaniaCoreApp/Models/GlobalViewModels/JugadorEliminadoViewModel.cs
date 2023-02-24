using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.GlobalViewModels
{
    public class JugadorEliminadoViewModel
    {
        public int Id { get; set; }
        public string Jugador { get; set; }
        public int JornadaEliminado { get; set; }
        public string JornadaVuelta { get; set; }
        public int VecesEliminado { get; set; }
    }
}
