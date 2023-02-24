using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LigamaniaCoreApp.Data.LigamaniaEnum;

namespace LigamaniaCoreApp.Models.InvitadoViewModels
{
    public class PremioHistoricoViewModel
    {
        public string Equipo { get; set; }
        public EPremio Premio { get; set; }
        public bool EsPichichi { get; set; }
        public string PremioTxt { get; set; }
    }
}
