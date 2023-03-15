using General.CrossCutting.Lib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Repository.Models
{
    public class Equipo:Entity
    {
        Edicion _edicion;
        int? _ordenCalendario;
        int? _jugados;
        int? _ganados;
        int? _perdidos;
        int? _puntosFavor;
        int? _puntosContra;
        double? _coeficiente;
        int? _puntos;

        IEnumerable<Partido> _locales;
        IEnumerable<Partido> _visitantes;

        public Equipo()
        {
        }

        public Equipo(Edicion edicion)
        {
            _edicion = edicion;
            _locales = new List<Partido>();
            _visitantes = new List<Partido>();
        }

        public Edicion Edicion { get => _edicion; set => _edicion = value; }
        public int? OrdenCalendario { get => _ordenCalendario; set => _ordenCalendario = value; }
        public int? Jugados { get => _jugados; set => _jugados = value; }
        public int? Ganados { get => _ganados; set => _ganados = value; }
        public int? Perdidos { get => _perdidos; set => _perdidos = value; }
        public int? PuntosFavor { get => _puntosFavor; set => _puntosFavor = value; }
        public int? PuntosContra { get => _puntosContra; set => _puntosContra = value; }
        public double? Coeficiente { get => _coeficiente; set => _coeficiente = value; }
        public int? Puntos { get => _puntos; set => _puntos = value; }
        internal IEnumerable<Partido> Locales { get => _locales; set => _locales = value; }
        internal IEnumerable<Partido> Visitantes { get => _visitantes; set => _visitantes = value; }
    }
}
