using General.CrossCutting.Lib;

namespace Ligamania.Repository.Models
{
    public class CuadroCopaDTO : Entity
    {
        public int Ronda { get; set; }
        public int NumPartido { get; set; }
        public int CompeticionEquipoAId { get; set; }
        public int CategoriaEquipoAId { get; set; }
        public int CompeticionEquipoBId { get; set; }
        public int CategoriaEquipoBId { get; set; }
        public virtual CompeticionCategoriaDTO CompeticionCategoriaEquipoA { get; set; }
        public virtual CompeticionCategoriaDTO CompeticionCategoriaEquipoB { get; set; }
        public int PuestoPartidoEquipoA { get; set; }
        public int PuestoPartidoEquipoB { get; set; }
        public int Orden { get; set; }
    }
}