using Ligamania.Generic.Lib.Enums;

using System;
using System.ComponentModel.DataAnnotations;

namespace Ligamania.Web.Models
{
    public class EquipoVM : BaseVM
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Id Entrenador")]
        public string EntrenadorId { get; set; }

        [Display(Name = "Entrenador")]
        public string Nombre { get; set; }

        public EstadoEquipo Estado { get; set; }

        public TipoEquipo Tipo { get; set; }

        [Display(Name = "Tipo")]
        public string TipoEquipo { get { return Tipo.ToString(); } }
        [Display(Name = "Estado")]
        public string EstadoEquipo { get { return Estado.ToString(); } }
        public byte[] Escudo { get; set; }
        public string EscudoToShow { get { return String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(Escudo)); } }   // OJO! El formato tiene que ser jpg

        public EquipoVM()
        {
        }

        public EquipoVM(string message) : base(message)
        {
        }
    }
}