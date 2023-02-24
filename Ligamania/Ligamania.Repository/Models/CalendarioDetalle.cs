using General.CrossCutting.Lib;

namespace Ligamania.Repository.Models
{
    public partial class CalendarioDetalleDTO : BaseEntity
    {
        public int Calendario_ID { get; set; }
        public int Jornada { get; set; }
        public string Local { get; set; }
        public string Visitante { get; set; }
        public virtual CalendarioDTO Calendario { get; set; }
    }
}