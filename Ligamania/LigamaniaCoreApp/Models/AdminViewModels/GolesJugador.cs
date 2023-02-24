using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.AdminViewModels
{
    public class GolesJugador
    {
        public string Jugador { get; set; }
        public bool Favor { get; set; }
        public bool Mas { get; set; }
        //public int Jornada { get; set; }
        [Display(Name = "Fecha:"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
    }
}
