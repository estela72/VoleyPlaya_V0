using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LigamaniaCoreApp.Data.LigamaniaEnum;

namespace LigamaniaCoreApp.Models.ManagerViewModels
{
    public class TemporadaCompeticionViewModel
    {
        public int Id { get; set; }
        public string Competicion { get; set; }
        public string EstadoCompeticion { get; set; }
        public eTipoCompeticion TipoCompeticion { get; set; }
        public int OrdenCompeticion { get; set; }
        public int CambiosFijos { get; set; }
        public int IdCompeticion { get; set; }
        public int Jornada { get; set; }
        public int JornadaCarrusel { get; set; }
        public int JornadaActual { get; set; }
        public int RondaActual { get; set; }
        public bool RondaActiva { get; set; }
        public bool JornadaIdaActiva { get; set; }
        public int JornadaIda { get; set; }
        public int JornadaVuelta { get; set; }
        public bool RondaFinal { get; set; }
        public bool GenerarJornadaFinal { get; set; }
        public List<TemporadaPartidoViewModel> PartidosCopa { get; set; }
        public bool AlineacionLibre { get; set; }
    }
}
