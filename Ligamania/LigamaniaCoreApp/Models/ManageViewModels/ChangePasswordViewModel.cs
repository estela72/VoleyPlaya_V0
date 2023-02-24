using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.ManageViewModels
{
    public class ChangePasswordViewModel
    {
        //[Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña actual")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} y como máximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nueva contraseña")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar nueva contraseña")]
        [Compare("NewPassword", ErrorMessage = "La nueva contraseña y la confirmación no coiniciden.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Olvidé mi contraseña anterior")]
        public bool ForgottenPassword { get; set; }
        public string StatusMessage { get; set; }
    }
}
