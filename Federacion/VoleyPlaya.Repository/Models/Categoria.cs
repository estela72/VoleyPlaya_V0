using General.CrossCutting.Lib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Repository.Models
{
    public class Categoria:Entity
    {
        HashSet<Edicion> _ediciones;

        public Categoria()
        {
            _ediciones = new HashSet<Edicion>();
        }

        public HashSet<Edicion> Ediciones { get => _ediciones; set => _ediciones = value; }
    }
}
