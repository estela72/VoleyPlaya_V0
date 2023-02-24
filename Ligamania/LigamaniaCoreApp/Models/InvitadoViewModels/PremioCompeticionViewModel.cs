using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.InvitadoViewModels
{
    public class PremioCompeticionViewModel
    {
        public string Competicion { get; set; }
        public double Porcentaje { get; set; }
        public List<PremioPuestoViewModel> Premios { get; set; }
        public string NombreCompeticion { get; set; }
        public string NombreCategoria { get; set; }
        public string Temporada { get; set; }
    }
}
