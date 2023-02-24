using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Web.Models
{
    public class CalendarioDetalleVM
    {
        public int CalendarioId { get; set; }
        public int Id { get; set; }
        public int Jornada { get; set; }
        public string Local { get; set; }
        public string Visitante { get; set; }
    }
    public class CalendarioVM : BaseVM
    {
        public int Id { get; set; }
        public string Calendario { get; set; }
        [Display(Name = "Nº de equipos")]
        public int NumEquipos { get; set; }
        public List<CalendarioDetalleVM> Partidos { get; set; }
    }
}
