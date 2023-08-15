using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.GlobalViewModels
{
    public class JugadorBajaViewModel
    {
        public int Id { get; set; }
        public string Jugador { get; set; }
        public bool PendienteBaja { get; set; }
    }
}
