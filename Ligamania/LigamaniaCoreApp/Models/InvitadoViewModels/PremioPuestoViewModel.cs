using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LigamaniaCoreApp.Data.LigamaniaEnum;

namespace LigamaniaCoreApp.Models.InvitadoViewModels
{
    public class PremioPuestoViewModel
    {
        public ePuestoCompeticion Puesto { get; set; }
        public string Equipo { get; set; }
        public double Importe { get; set; }
        public string Temporada { get; set; }
        public string Competicion { get; set; }
        public string Categoria { get; set; }
    }
}
