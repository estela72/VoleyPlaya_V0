using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.ManageViewModels
{
    public class IndexViewModel
    {
        [Display(Name = "Entrenador/Usuario")]
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Nº de teléfono")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Ciudad residencia")]
        public string City { get; set; }

        [Required]
        [Display(Name = "¿Cómo conociste Ligamania?")]
        public string Conocimiento { get; set; }

        [Required]
        [Display(Name = "¿Quieres recibir whatsapp con las novedades e incidencias?")]
        public bool Whatsapp { get; set; }

        //[Required]
        //[Display(Name = "¿Es un equipo BOT?")]
        //public bool EsBot { get; set; }

        //[Required]
        //[Display(Name = "Nombre del Equipo")]
        //public string Equipo { get; set; }

        [Display(Name = "Si quieres jugar contra tus amigos, elige tu Categoría preferida (Silver A o Silver B)")]
        public string CategoriaPreferida { get; set; }

        //public bool CheckSoloEquipo { get; set; }


        public string StatusMessage { get; set; }
    }
}
