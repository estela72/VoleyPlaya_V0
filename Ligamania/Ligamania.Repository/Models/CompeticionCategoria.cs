using General.CrossCutting.Lib;

using System.Collections.Generic;

namespace Ligamania.Repository.Models
{
    public partial class CompeticionCategoriaDTO //: Entity
    {
        public CompeticionCategoriaDTO()
        {
            CuadroCopaEquipoA = new HashSet<CuadroCopaDTO>();
            CuadroCopaEquipoB = new HashSet<CuadroCopaDTO>();
        }

        public int Categoria_Id { get; set; }
        public int Competicion_Id { get; set; }

        public virtual CategoriaDTO Categoria { get; set; }
        public virtual CompeticionDTO Competicion { get; set; }

        public virtual ICollection<CuadroCopaDTO> CuadroCopaEquipoA { get; set; }
        public virtual ICollection<CuadroCopaDTO> CuadroCopaEquipoB { get; set; }
    }
}