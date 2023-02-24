using System.ComponentModel.DataAnnotations;

namespace Ligamania.Web.Models.Temporada
{
    [MetadataType(typeof(TemporadaVM))]
    public partial class Temp
    {
    }

    public class TemporadaVM:BaseVM
    {
        public int Id { get; set; }
        
        [Display(Name = "Temporada")]
        [Required(AllowEmptyStrings =false, ErrorMessage = "Este valor no debe quedar vacío. Formato: 9999-9999")]
        [StringLength(9,ErrorMessage="Este valor no debe quedar vacío. Formato: 9999-9999")]
        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Formato no permitido. Formato: 9999-9999")]
        public string Temporada { get; set; }
        [Display(Name = "Clasificación")]
        public byte[] Clasificacion { get; set; }
        [Display(Name = "Estado")]
        public string Estado { get; set; }
        [Display(Name = "Actual")]
        public string Actual { get; set; }
    }
}
