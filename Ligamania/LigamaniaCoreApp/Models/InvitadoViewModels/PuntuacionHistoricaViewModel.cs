using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.InvitadoViewModels
{
    public class PuntuacionHistoricaViewModel
    {
        public int Id { get; set; }
        public string Competicion { get; set; }
        public string Categoria { get; set; }

        public int Campeon { get; set; }
        public int Subcampeon { get; set; }
        public int Tercero { get; set; }
        public int Pichichi { get; set; }
        public int Todos { get; set; }
    }
}
