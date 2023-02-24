using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name="Nombre del Entrenador")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} caracteres y como máximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} caracteres y como máximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name="Ciudad residencia")]
        public string City { get; set; }

        //[Required]
        [Display(Name="¿Cómo conociste Ligamania?")]
        public string Conocimiento { get; set; }

        //[Required]
        [Display(Name="¿Quieres recibir whatsapp con las novedades e incidencias?")]
        public bool Whatsapp { get; set; }
        [Display(Name = "¿Quieres recibir whatsapp con las novedades e incidencias?")]
        public string StrWhats { get { return Whatsapp ? "SI" : "NO"; } set { Whatsapp = value == "SI" ? true : false; } }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name="Nº de teléfono")]
        public string PhoneNumber { get; set; }

        //[Required]
        [Display(Name="¿Es un equipo BOT?")]
        public bool EsBot { get; set; }

        [Required]
        [Display(Name = "Nombre del Equipo")]
        public string Equipo { get; set; }

        public int EquipoId { get; set; }

        [Display(Name = "Si quieres jugar contra tus amigos, elige tu Categoría preferida (Silver A o Silver B)")]
        public string CategoriaPreferida { get; set; }

        public string EquipoNuevo { get; set; }
        public bool CheckSoloEquipo { get; set; }
        public eUserState UserState { get; set; }
        public string EstadoUsuario { get
            {
                switch(UserState)
                {
                    case eUserState.Confirmed: return "Activo (en juego)";
                    case eUserState.Registered: return "Registrado(sin confirmar)";
                    case eUserState.Removed: return "Baja en Ligamanía";
                    default: return UserState.ToString();
                }
            }
        }
        public bool EsEntrenador { get; set; }
        public List<string> Roles { get; internal set; }
        public string StringRoles { get { if (Roles!=null) return string.Join(",", Roles.ToArray()); return string.Empty; } }

        public string NewRole { get; set; }
    }
}
