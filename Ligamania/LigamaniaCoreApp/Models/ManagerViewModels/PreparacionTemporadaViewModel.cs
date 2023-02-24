using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.ManagerViewModels
{
    public class PreparacionTemporadaViewModel
    {
        public TemporadaViewModel Temporada { get; set; }
        public List<CompeticionCategoriaViewModel> AllCompeticiones { get; set; }
        public List<TemporadaCompeticionCategoriaViewModel> CompeticionesCategoriasActivas { get; set; }
        public List<TemporadaCompeticionViewModel> CompeticionesActivas { get; set; }

        public int IdCompeticion { get; set; }
        public int IdCategoria { get; set; }
        public bool Activar { get; set; }
        public string CompeticionOrigen { get; set; }
        public string CompeticionDestino { get; set; }
        public string Categoria { get; set; }
        public string Equipo { get; set; }
        public DateTime Fecha { get; set; }
        public int Jornada { get; set; }
        public string Calendario { get; set; }
        public int Dias { get; set; }
        public int Ronda { get; set; }
        public string Local { get; set; }
        public string Visitante { get; set; }
    }
}
