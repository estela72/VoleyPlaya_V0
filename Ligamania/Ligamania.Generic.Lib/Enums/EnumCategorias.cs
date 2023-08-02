using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ligamania.Generic.Lib.Enums
{
    public static class EnumCategorias
    {
        public static Dictionary<int, string> _categorias = new Dictionary<int, string>();

        public static Dictionary<int, string> Categorias
        {
            get
            {
                if (!_categorias.ContainsKey(0)) _categorias.Add(0, "Golden");
                if (!_categorias.ContainsKey(1)) _categorias.Add(1, "Silver A");
                if (!_categorias.ContainsKey(2)) _categorias.Add(2, "Silver B");
                if (!_categorias.ContainsKey(3)) _categorias.Add(3, "");
                return _categorias;
            }
        }
    }
}
