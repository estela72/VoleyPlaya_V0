using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Models
{
    internal class PartidoCalendario : IEquatable<PartidoCalendario>
    {
        private int _numPartido;
        private int _jornada;
        private int _ordenLocal;
        private int _ordenVisitante;

        public PartidoCalendario()
        {
        }

        public PartidoCalendario(int numPartido, int jornada, int ordenLocal, int ordenVisitante)
        {
            _numPartido = numPartido;
            _jornada = jornada;
            _ordenLocal = ordenLocal;
            _ordenVisitante = ordenVisitante;
        }

        public int NumPartido { get => _numPartido; set => _numPartido = value; }
        public int Jornada { get => _jornada; set => _jornada = value; }
        public int OrdenLocal { get => _ordenLocal; set => _ordenLocal = value; }
        public int OrdenVisitante { get => _ordenVisitante; set => _ordenVisitante = value; }

        public override bool Equals(object obj)
        {
            return Equals(obj as PartidoCalendario);
        }

        public bool Equals(PartidoCalendario other)
        {
            return other is not null &&
                   _numPartido == other._numPartido &&
                   _jornada == other._jornada &&
                   _ordenLocal == other._ordenLocal &&
                   _ordenVisitante == other._ordenVisitante;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_numPartido, _jornada, _ordenLocal, _ordenVisitante);
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
