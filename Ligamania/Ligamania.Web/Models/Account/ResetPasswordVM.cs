using System.ComponentModel.DataAnnotations;

namespace Ligamania.Web.Models
{
    public class ResetPasswordVM : BaseVM
    {
        public ResetPasswordVM()
        {
        }

        public ResetPasswordVM(string message) : base(message)
        {
        }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Código recibido por email")]
        public string Token { get; set; }

        [Required]
        [Display(Name = "Nueva Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirmar Nueva Contraseña")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}