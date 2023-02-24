using System.ComponentModel.DataAnnotations;

namespace Ligamania.Web.Models
{
    public class RegisterVM : BaseVM
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Correo Electrónico")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirmar Contraseña")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Nº de teléfono")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Ciudad")]
        public string City { get; set; }

        [Display(Name = "¿Cómo conociste Ligamania?")]
        public string Conocimiento { get; set; }

        [Display(Name = "¿Quieres recibir whatsapp con las novedades e incidencias?")]
        public bool Whatsapp { get; set; }

        [Display(Name = "¿Quieres recibir whatsapp con las novedades e incidencias?")]
        public string StrWhats { get { return Whatsapp ? "SI" : "NO"; } set { Whatsapp = value == "SI" ? true : false; } }

        [Display(Name = "¿Es un equipo BOT?")]
        public bool EsBot { get; set; }

        [Required]
        [Display(Name = "Nombre del Equipo")]
        public string Equipo { get; set; }

        public int EquipoId { get; set; }

        [Display(Name = "Si quieres jugar contra tus amigos, elige tu Categoría preferida (Silver A o Silver B)")]
        public string CategoriaPreferida { get; set; }

        public RegisterVM()
        {
        }

        public RegisterVM(string message) : base(message)
        {
        }
    }
}