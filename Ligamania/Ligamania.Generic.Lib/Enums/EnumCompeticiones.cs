using System.Collections.Generic;

namespace Ligamania.Generic.Lib.Enums
{
    public static class EnumCompeticiones
    {
        public static Dictionary<int, string> _competiciones = new Dictionary<int, string>();

        public static Dictionary<int, string> Competiciones
        {
            get
            {
                if (!_competiciones.ContainsKey(0)) _competiciones.Add(0, "Liga");
                if (!_competiciones.ContainsKey(1)) _competiciones.Add(1, "Copa");
                if (!_competiciones.ContainsKey(2)) _competiciones.Add(2, "Supercopa");
                return _competiciones;
            }
        }
    }
}