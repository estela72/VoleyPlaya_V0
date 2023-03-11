using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Models
{
    public class TablaCalendario : IEquatable<TablaCalendario>
    {
        private string _name;
        private int _jornadas;
        private int _equipos;
        private int _vueltas;
        private List<PartidoCalendario> _partidos;

        public TablaCalendario() 
        {
            _name = string.Empty;
            _partidos = new List<PartidoCalendario>();
        }
        public TablaCalendario(string name, int jornadas, int equipos, int vueltas)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _jornadas = jornadas;
            _equipos = equipos;
            _vueltas = vueltas;
            _partidos = new List<PartidoCalendario>();
        }
        public void AddPartido(int jornada, int numPartido, int ordenLocal, int ordenVisitante)
        {
            PartidoCalendario partido = new PartidoCalendario
            {
                Jornada = jornada,
                NumPartido = numPartido,
                OrdenLocal = ordenLocal,
                OrdenVisitante = ordenVisitante
            };
            if (!_partidos.Contains(partido))
                _partidos.Add(partido);
        }
        public string Name { get => _name; set => _name = value; }
        public int Jornadas { get => _jornadas; set => _jornadas = value; }
        public int Equipos { get => _equipos; set => _equipos = value; }
        public int Vueltas { get => _vueltas; set => _vueltas = value; }
        internal List<PartidoCalendario> Partidos { get => _partidos; set => _partidos = value; }

        public override bool Equals(object obj)
        {
            return Equals(obj as TablaCalendario);
        }

        public bool Equals(TablaCalendario other)
        {
            return other is not null &&
                   _jornadas == other._jornadas &&
                   _equipos == other._equipos &&
                   _vueltas == other._vueltas;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_jornadas, _equipos, _vueltas);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static bool operator ==(TablaCalendario left, TablaCalendario right)
        {
            return EqualityComparer<TablaCalendario>.Default.Equals(left, right);
        }

        public static bool operator !=(TablaCalendario left, TablaCalendario right)
        {
            return !(left == right);
        }
    }
}
