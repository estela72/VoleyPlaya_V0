using Ligamania.Generic.Lib.Enums;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Ligamania.Web.Models
{
    public class EntrenadorVM : BaseVM
    {
        [Display(Name = "Id")]
        public string Id { get; set; }
        [Display(Name = "Entrenador")]
        public string Nombre { get; set; }
        public TipoEntrenador Tipo { get; set; }
        public EstadoEntrenador Estado { get; set; }
        [Display(Name = "Tipo")]
        public string TipoEntrenador { get { return Tipo.ToString(); } }
        [Display(Name = "Estado")]
        public string EstadoEntrenador { get { return Estado.ToString(); } }
        [Display(Name ="Nº de equipos")]
        public int NumEquipos { get; set; }
        public ICollection<EquipoVM> Equipos { get; set; }
        public EntrenadorVM()
        {
        }

        public EntrenadorVM(string message) : base(message)
        {
        }
    }
}