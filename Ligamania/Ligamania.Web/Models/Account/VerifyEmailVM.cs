using System.ComponentModel.DataAnnotations;

namespace Ligamania.Web.Models
{
    public class VerifyEmailVM : BaseVM
    {
        public VerifyEmailVM()
        {
        }

        public VerifyEmailVM(string message) : base(message)
        {
        }

        [Required]
        [Display(Name = "Código recibido por email")]
        public string Token { get; set; }
    }
}