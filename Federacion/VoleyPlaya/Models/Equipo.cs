using IronXL.Printing;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Models
{
    internal class Equipo : IEquatable<Equipo>
    {
        private int _posicion;
        private string _nombre;
        private int _jugados;
        private int _ganados;
        private int _perdidos;
        private int _puntosFavor;
        private int _puntosContra;
        private int _coeficiente;

        public Equipo()
        {
        }

        public Equipo(int posicion, string nombre)
        {
            _posicion = posicion;
            _nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
        }

        public int Posicion { get => _posicion; set => _posicion = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public int Jugados { get => _jugados; set => _jugados = value; }
        public int Ganados { get => _ganados; set => _ganados = value; }
        public int Perdidos { get => _perdidos; set => _perdidos = value; }
        public int PuntosFavor { get => _puntosFavor; set => _puntosFavor = value; }
        public int PuntosContra { get => _puntosContra; set => _puntosContra = value; }
        public int Coeficiente { get => _coeficiente; set => _coeficiente = value; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Equipo);
        }

        public bool Equals(Equipo other)
        {
            return other is not null &&
                   _posicion == other._posicion &&
                   _nombre == other._nombre;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_posicion, _nombre);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static bool operator ==(Equipo left, Equipo right)
        {
            return EqualityComparer<Equipo>.Default.Equals(left, right);
        }

        public static bool operator !=(Equipo left, Equipo right)
        {
            return !(left == right);
        }
    }
}
