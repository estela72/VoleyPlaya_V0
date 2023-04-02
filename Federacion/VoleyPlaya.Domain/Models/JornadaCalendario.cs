using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Domain.Models
{
    public class JornadaCalendario
    {
         int _jornada;
         IList<PartidoCalendario> _partidos;

        public int Jornada { get => _jornada; set => _jornada = value; }
        public IList<PartidoCalendario> Partidos { get => _partidos; set => _partidos = value; }
    }
}
