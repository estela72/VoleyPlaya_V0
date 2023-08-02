using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ligamania.Generic.Lib.Enums
{
    public static class EnumPuestos
    {
        public static Dictionary<int, string> _puestos = new Dictionary<int, string>();

        public static Dictionary<int, string> Puestos
        {
            get
            {
                if (!_puestos.ContainsKey(0)) _puestos.Add(0, "Campeón");
                if (!_puestos.ContainsKey(1)) _puestos.Add(1, "Subcampeón");
                if (!_puestos.ContainsKey(2)) _puestos.Add(2, "Tercero");
                if (!_puestos.ContainsKey(3)) _puestos.Add(3, "Pichichi");
                return _puestos;
            }
        }
    }
}
