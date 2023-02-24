using System.ComponentModel.DataAnnotations;

namespace Ligamania.Web.Models
{
    public class ForgotPasswordVM : BaseVM
    {
        public ForgotPasswordVM()
        {
        }

        public ForgotPasswordVM(string message) : base(message)
        {
        }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}