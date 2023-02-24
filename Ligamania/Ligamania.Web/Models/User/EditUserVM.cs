using System.ComponentModel.DataAnnotations;

namespace Ligamania.Web.Models
{
    public class EditUserVM : BaseVM
    {
        public string Id { get; set; }

        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Display(Name = "Equipo")]
        public string Equipo { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Permisos")]
        public string Roles { get; set; }

        [Display(Name = "Ciudad")]
        public string City { get; set; }

        [Display(Name = "Cómo conoció Ligamanía")]
        public string Conocimiento { get; set; }

        [Display(Name = "Categoría preferida")]
        public string CompartirGrupo { get; set; }

        [Display(Name = "Recibir whatsapps")]
        public string Whatsap { get; set; }

        [Display(Name = "Estado")]
        public string UserState { get; set; }

        [Display(Name = "Usuario BOT")]
        public string IsBot { get; set; }

        [Display(Name = "Entrenador")]
        public string IsEntrenador { get; set; }

        public EditUserVM()
        {
        }

        public EditUserVM(string message) : base(message)
        {
        }
    }
}