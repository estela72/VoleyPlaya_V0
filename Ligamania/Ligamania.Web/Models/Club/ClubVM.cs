using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Web.Models.Club
{
    public class ClubVM : BaseVM
    {
        public int Id { get; set; }

        [Display(Name = "Club")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este valor no debe quedar vacío.")]
        public string Club { get; set; }

        [Display(Name = "Alias")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este valor no debe quedar vacío. Formato: XXX")]
        [StringLength(3, ErrorMessage = "Este valor no debe quedar vacío. Formato: XXX")]
        public string Alias { get; set; }

        public string Baja { get; set; }

        public string ClubAlias {
            get { return Alias + " - " + Club; 
            } 
        }
    }
    public class Inspection
    {
        public string InspectionId { get; set; }
        public string Description { get; set; }
    }

    public class InspectionReasons : Inspection
    {
        public string ReasonId { get; set; }
        public string ReasonDesc { get; set; }
        public string NotUsedInUpdate { get; set; }
        public bool CheckedFlag { get; set; }
    }
}
