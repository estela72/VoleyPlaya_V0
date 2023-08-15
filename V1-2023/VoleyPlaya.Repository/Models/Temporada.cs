using General.CrossCutting.Lib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Repository.Models
{
    public class Temporada : Entity
    {
        bool _actual;
        
        HashSet<Edicion> _ediciones;

        public Temporada()
        {
            _ediciones = new HashSet<Edicion>();
        }

        public HashSet<Edicion> Ediciones { get => _ediciones; set => _ediciones = value; }
        public bool Actual { get => _actual; set => _actual = value; }
    }
}
