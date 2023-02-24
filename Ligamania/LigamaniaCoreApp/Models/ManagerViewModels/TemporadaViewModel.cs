using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LigamaniaCoreApp.Data.LigamaniaEnum;

namespace LigamaniaCoreApp.Models.ManagerViewModels
{
    public class TemporadaViewModel
    {
        public int Id { get; set; }
        public string Temporada { get; set; }
        public EEstadoTemporada EstadoTemporada { get; set; }
        public ICollection<TemporadaCompeticionViewModel> Competiciones { get; set; }
    }

}
