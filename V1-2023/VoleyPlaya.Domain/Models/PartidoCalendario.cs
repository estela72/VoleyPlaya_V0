using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Domain.Models
{
    public class PartidoCalendario : IEquatable<PartidoCalendario>
    {
        private int _local;
        private int _visitante;
        private int _jornada;
        public PartidoCalendario()
        {
        }

        public PartidoCalendario(int numPartido,  int ordenLocal, int ordenVisitante, int jornada)
        {
            _local = ordenLocal;
            _visitante = ordenVisitante;
            _jornada = jornada;
        }

        public int Local { get => _local; set => _local = value; }
        public int Visitante { get => _visitante; set => _visitante = value; }
        public int Jornada { get => _jornada; set => _jornada = value; }

        public override bool Equals(object obj)
        {
            return Equals(obj as PartidoCalendario);
        }

        public bool Equals(PartidoCalendario other)
        {
            return other is not null &&
                   _jornada == other._jornada &&
                   _local == other._local &&
                   _visitante == other._visitante;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_local, _visitante);
        }

        public static bool operator ==(PartidoCalendario left, PartidoCalendario right)
        {
            return EqualityComparer<PartidoCalendario>.Default.Equals(left, right);
        }

        public static bool operator !=(PartidoCalendario left, PartidoCalendario right)
        {
            return !(left == right);
        }
    }
}
