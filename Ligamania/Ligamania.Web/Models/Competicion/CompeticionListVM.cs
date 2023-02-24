using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Web.Models.Competicion
{
    public class CompeticionListVM : BaseVM
    {
        public List<CompeticionVM> competiciones { get; set; }

        public CompeticionListVM() : base()
        {
            competiciones = new List<CompeticionVM>();
            competiciones.Add(new CompeticionVM());
        }

        public CompeticionListVM(string message) : base(message)
        {
            competiciones = new List<CompeticionVM>();
            competiciones.Add(new CompeticionVM());
        }
    }
}
