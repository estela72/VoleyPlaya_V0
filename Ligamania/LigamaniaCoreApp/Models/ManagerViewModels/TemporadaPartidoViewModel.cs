using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.ManagerViewModels
{
    public class TemporadaPartidoViewModel
    {
        public string Temporada { get; set; }
        public string Competicion { get; set; }
        public string Categoria { get; set; }
        public int Jornada { get; set; }
        public DateTime Fecha { get; set; }
        public int NumeroPartido { get; set; }
        public int ResultadoA { get; set; }
        public int ResultadoB { get; set; }
        public string EquipoA { get; set; }
        public string EquipoB { get; set; }
        public string EquipoGanador { get; set; }
        public List<AlineacionViewModel> AlineacionEquipoA { get; set; }
        public List<AlineacionViewModel> AlineacionEquipoB { get; set; }
        public int JornadaId { get; set; }

    }
}
