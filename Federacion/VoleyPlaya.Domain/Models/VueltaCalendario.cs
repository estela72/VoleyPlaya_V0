using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Domain.Models
{
    public class VueltaCalendario
    {
         int _vuelta;
         IList<PartidoCalendario> _partidos;

        public int Vuelta { get => _vuelta; set => _vuelta = value; }
        public IList<PartidoCalendario> Partidos { get => _partidos; set => _partidos = value; }
    }
}
