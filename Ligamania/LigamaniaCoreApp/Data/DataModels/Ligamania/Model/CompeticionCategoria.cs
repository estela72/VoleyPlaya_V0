using LigamaniaCoreApp.Data.DataModels.Base.Interfaces;
using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public partial class CompeticionCategoriaDTO : BaseEntity
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
