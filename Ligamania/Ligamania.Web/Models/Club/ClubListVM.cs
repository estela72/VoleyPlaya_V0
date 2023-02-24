using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Web.Models.Club
{
    public class ClubListVM : BaseVM
    {
        public List<ClubVM> clubs { get; set; }
        public ClubVM nuevoClub { get; set; }

        public ClubListVM() : base()
        {
            Inicializar();
        }
        public ClubListVM(string message) : base(message)
        {
            Inicializar();
        }

        private void Inicializar()
        {
            clubs = new List<ClubVM>();
            clubs.Add(new ClubVM());
            nuevoClub = new ClubVM();
        }

    }
}
