using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.InvitadoViewModels
{
    public class CalendarioCategoriaViewModel
    {
        public string Categoria { get; set; }
        public int Orden { get; set; }
        public int JornadaSelected { get; set; }
        public int LastJornada { get { if (Jornadas!=null) return Jornadas.Max(jj => jj.Jornada); return JornadaSelected; } }
        public ICollection<CalendarioCategoriaJornadaViewModel> Jornadas { get; set; }
    }
}
