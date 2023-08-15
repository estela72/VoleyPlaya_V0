using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.ManagerViewModels
{
    public class AlineacionViewModel
    {
        public int Id { get; set; }
        public string Jugador { get; set; }
        public string Club { get; set; }
        public string Alias { get; set; }
        public string Puesto { get; set; }
        public string ClubJugador { get { return Club + " - " + Jugador; } }
        public string AliasJugador { get { return Alias + " - " + Jugador; } }
        public int OrdenPuesto { get; set; }
        public int GF { get; set; }
        public int GC { get; set; }
        public bool Cambiado { get; set; }
        public bool Preeliminado { get; set; }
        public bool Eliminado { get; set; }

        public int MinutosJugados { get; set; }
        public int TarjetasRojas { get; set; }
        public int TarjetasAmarillas { get; set; }

        public int NumeroJornada { get; set;}

        public string AliasCambio { get; set; }
        public string ClubCambio { get; set; }
        public string JugadorCambio { get; set; }
        public string ClubCambioJugador { get { return ClubCambio + " - " + JugadorCambio; } }
        public string AliasCambioJugador { get { return AliasCambio + " - " + JugadorCambio; } }
        public bool PendienteBaja { get; set; }
    }
}
