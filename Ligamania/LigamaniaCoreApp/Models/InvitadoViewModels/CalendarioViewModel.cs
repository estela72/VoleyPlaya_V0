using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.InvitadoViewModels
{
    public class CalendarioViewModel
    {
        public string Competicion { get; set; }
        public int Orden { get; set; }
        public ICollection<CalendarioCategoriaViewModel> Categorias { get; set; }
    }
}
