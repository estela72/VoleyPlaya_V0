using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Web.Models
{
    public class EntrenadorListVM : BaseVM
    {
        public List<EntrenadorVM> entrenadores { get; set; }

        public EntrenadorListVM() : base()
        {
            entrenadores = new List<EntrenadorVM>();
            entrenadores.Add(new EntrenadorVM());
        }
    }
}
