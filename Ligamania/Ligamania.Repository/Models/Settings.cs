using General.CrossCutting.Lib;

namespace Ligamania.Repository.Models
{
    public partial class SettingsDTO : BaseEntity
    {
        public bool ClasificacionRotuloCopa { get; set; }
        public bool? VerNoticias { get; set; }
        public bool? VerEquiposPretemporada { get; set; }
        public bool? VerCuadroCopa { get; set; }
        public string TemporadaPremios { get; set; }
        public int NumeroJornadasVolverEliminados { get; set; }
        public string NotificacionClasificaciones { get; set; }
    }
}