using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.InvitadoViewModels
{
    public class ContabilidadViewModel
    {
        public string Concepto { get; set; }
        public double Valor { get; set; }
        public bool Gasto { get; set; }
        public bool Equipo { get; set; }
        public string Temporada { get; set; }
    }
}
