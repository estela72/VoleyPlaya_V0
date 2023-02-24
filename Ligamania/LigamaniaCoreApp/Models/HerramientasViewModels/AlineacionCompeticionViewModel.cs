using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.HerramientasViewModels
{
    public class AlineacionCompeticionViewModel
    {
        public int IdTemporadaCompeticion { get; set; }
        public int IdCompeticion { get; set; }
        public string Competicion { get; set; }
        public string Equipo { get; set; }
        public ICollection<AlineacionCompeticionJornadaViewModel> AlineacionesPrevias { get; set; }
        public ICollection<AlineacionCompeticionJornadaViewModel> AlineacionesCambios { get; set; }
        public ICollection<AlineacionCompeticionJornadaViewModel> AlineacionesActual { get; set; }
    }
}
