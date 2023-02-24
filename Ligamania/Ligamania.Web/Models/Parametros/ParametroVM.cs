using System.ComponentModel.DataAnnotations;

namespace Ligamania.Web.Models
{
    public class ParametroVM : BaseVM
    {
        public int Id { get; set; }
        [Display(Name = "Nº de jornadas para que un jugador eliminado vuelva")]
        public int NumJorVueltaJugadorEliminado { get; set; }
        [Display(Name = "Rótulo para mostrar información de Copa")]
        public string RotuloCopa { get; set; }
        [Display(Name = "Habilitar ver el rótulo de Copa")]
        public string VerRotuloCopa { get; set; }
        [Display(Name = "Habilitar ver el cuadro de Copa")]
        public string VerCuadroCopa { get; set; }
        [Display(Name = "Aviso para mostrar encima de las clasificaciones")]
        public string AvisoClasificaciones { get; set; }
        [Display(Name = "Habilitar ver el aviso de las clasificaciones")]
        public string VerAvisoClasificaciones { get; set; }
        [Display(Name = "Habilitar que se vean las noticias en la página principal")]
        public string VerNoticiasPaginaPrincipal { get; set; }
        [Display(Name = "Habilitar que se vean los equipos en pretemporada en la página principal")]
        public string VerEquiposPretemporadaPaginaPrincipal { get; set; }

    }
}
