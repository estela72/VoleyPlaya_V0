using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.HerramientasViewModels
{
    public class AlineacionCompeticionJornadaViewModel
    {
        public string Categoria { get; set; }
        public string Equipo { get; set; }
        public string Jugador { get; set; }
        public string Club { get; set; }
        public string Puesto { get; set; }
        public int OrdenCategoria { get; set; }
        public int OrdenPuesto { get; set; }
        public int IdAlineacion { get; set; }
        public string JugadorCambio { get; set; }
        public string Competicion { get; set; }
        public string Tipo { get; set; }
    }
}
