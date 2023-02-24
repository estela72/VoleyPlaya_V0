using Ligamania.Generic.Lib.Enums;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Web.Models.Competicion
{
    public class CompeticionVM : BaseVM
    {
        public int Id { get; set; }
        public string Competicion { get; set; }
        public string Tipo { get; set; }
        [Display(Name = "¿Copiar la alineación inicial de otra competición?")]
        public string CopiarAliIni { get; set; }
        [Display(Name = "Copiar la alineación inicial de la competición:")]
        public string AliInicial { get; set; }
        [Display(Name ="Permitir repetir club en la alineación")]
        public string RepetirClub { get; set; }
        [Display(Name ="Jornada de Liga para generar el Cuadro de Copa")]
        public string JornadaCuadro { get; set; }
        public int Orden { get; set; }
        public int CambiosFijos { get; set; }
        public string Activa { get; set; }
        public string DescripcionEstado { get; set; }
        public List<CategoriaVM> categorias { get; set; }

        internal void AddCategorias(IEnumerable<CategoriaVM> categorias)
        {
            this.categorias = categorias.Where(c=>c.Categoria!= TipoCategoria.SinCategoria.ToString()).ToList();
        }
    }
}
