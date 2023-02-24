using System.ComponentModel.DataAnnotations;

namespace Ligamania.Web.Models
{
    public class RoleVM
    {
        [Display(Name = "Rol")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Display(Name = "Nº de usuarios con este rol")]
        public int NumberOfUsers { get; set; }
    }
}