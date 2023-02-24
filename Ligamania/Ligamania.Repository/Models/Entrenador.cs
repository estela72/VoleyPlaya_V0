using General.CrossCutting.Lib;

namespace Ligamania.Repository.Models
{
    public partial class EntrenadorDTO : Entity
    {
        public EntrenadorDTO()
        {
            //Equipo = new HashSet<Equipo_DTO>();
        }

        public string Email { get; set; }
        public bool Baja { get; set; }
        public bool EsBot { get; set; }

        //public virtual ICollection<Equipo_DTO> Equipo { get; set; }
    }
}