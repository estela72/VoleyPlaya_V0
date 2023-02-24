using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.ManagerViewModels
{
    public class TemporadaPartidoRondaViewModel
    {
        public int Id { get; set; }
        public int NumeroPartido { get; set; }
        public string EquipoA { get; set; }
        public string EquipoB { get; set; }
        public TemporadaPartidoViewModel PartidoIda { get; set; }
        public TemporadaPartidoViewModel PartidoVuelta { get; set; }
        public string Ganador { get; set; }
        public string Criterio { get; set; }
    }
}
