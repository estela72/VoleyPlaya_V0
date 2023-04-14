using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Domain.Models
{
    public static class EnumCompeticiones
    {
        public static Dictionary<int, string> _competiciones = new Dictionary<int, string>();
        
        public static Dictionary<int, string> Competiciones
        { 
            get
            {
                if (!_competiciones.ContainsKey(0)) _competiciones.Add(0, "Juegos Deportivos");
                if (!_competiciones.ContainsKey(1)) _competiciones.Add(1, "Circuito Regional Asturiano");
                if (!_competiciones.ContainsKey(2)) _competiciones.Add(2, "Rey de la Pista");
                if (!_competiciones.ContainsKey(3)) _competiciones.Add(3, "Copa Principado");
                if (!_competiciones.ContainsKey(4)) _competiciones.Add(4, "Circuito Nacional");
                if (!_competiciones.ContainsKey(5)) _competiciones.Add(5, "None");
                return _competiciones;
            }
        }
    }
}
