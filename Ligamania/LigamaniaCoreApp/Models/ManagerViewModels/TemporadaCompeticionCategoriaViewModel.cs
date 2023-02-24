using LigamaniaCoreApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LigamaniaCoreApp.Data.LigamaniaEnum;

namespace LigamaniaCoreApp.Models.ManagerViewModels
{
    public class TemporadaCompeticionCategoriaViewModel
    {
        public string Competicion { get; set; }
        public string Categoria { get; set; }
        public int IdCompeticion { get; set; }
        public int IdCategoria { get; set; }

        public bool RepetirClubAliIni { get; set; }
        public bool CopiarAlineacionInicial { get; set; }
        public string CompeticionCopiarAliIni { get; set; }
        public bool MarcarPichichi { get; set; }
        public int NumMaxJugEliminar { get; set; }

        public int CambiosFijos { get; set; }
        public int JornadaCuadro { get; set; }
        public int OrdenCompeticion { get; set; }
        public eTipoCompeticion Tipo { get; set; }
        public int OrdenCategoria { get; set; }
        public bool CategoriaActiva { get; set; }

        public string Repetir { get { return RepetirClubAliIni ? LigamaniaConst.SI : LigamaniaConst.NO; } }
        public string CopiarAliIni { get { return CopiarAlineacionInicial ? LigamaniaConst.SI : LigamaniaConst.NO; } }
        public string Pichichi { get { return MarcarPichichi ? LigamaniaConst.SI : LigamaniaConst.NO; } }
        public List<TemporadaEquipoViewModel> Equipos { get; set; }
        public List<TemporadaPartidoViewModel> Partidos { get; set; }
        public List<TemporadaCompeticionJornadaViewModel> Jornadas { get; set; }
        public List<CuadroViewModel> Cuadro { get; set; }
        public List<TemporadaCuadroViewModel> CuadroConEquipos { get; set; }
        public List<TemporadaRondaViewModel> Rondas { get; set; }
    }
}
