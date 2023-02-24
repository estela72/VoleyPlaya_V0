using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.AdminViewModels
{
    public class JugadoresAlineadosCategoriaViewModel
    {
        public string Categoria { get; set; }
        public int NumJugadores { get { return Jugadores.Count; } }
        public Dictionary<string,int> Jugadores { get; set; }
    }
}
