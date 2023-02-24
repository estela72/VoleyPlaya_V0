using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.InvitadoViewModels
{
    public class HistoriaEquipoTemporadaViewModel
    {
        public string Temporada { get; set; }
        public string CategoriaLiga { get; set; }
        public int PuestoLiga { get; set; }
        public int PuestoCopa { get; set; }
        public int PuestoSupercopa { get; set; }
        public bool Pichichi { get; set; }
    }
}
