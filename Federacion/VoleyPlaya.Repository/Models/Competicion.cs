using General.CrossCutting.Lib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Repository.Models
{
    public class Competicion:Entity
    {
        IEnumerable<Edicion> _ediciones;

        public Competicion()
        {
            _ediciones = new List<Edicion>();
        }

        public IEnumerable<Edicion> Ediciones { get => _ediciones; set => _ediciones = value; }
    }
}
