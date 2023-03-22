using IronXL.Printing;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace VoleyPlaya.Models
{
    public class Equipo : IEquatable<Equipo>
    {
        private int _posicion;
        private string _nombre;
        private int _jugados;
        private int _ganados;
        private int _perdidos;
        private int _puntosFavor;
        private int _puntosContra;
        private double _coeficiente;
        private int _puntos;

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
        public double Coeficiente { get => _coeficiente; set => _coeficiente = value; }
        public int Puntos { get => _puntos; set => _puntos = value; }

        internal static Equipo FromJson(JsonNode equipoJson)
        {
            Equipo equipo = new Equipo()
            {
                Posicion = equipoJson["OrdenCalendario"]!.GetValue<int>(),
                Coeficiente = equipoJson["Coeficiente"]!.GetValue<double>(),
                Ganados = equipoJson["Ganados"]!.GetValue<int>(),
                Jugados = equipoJson["Jugados"]!.GetValue<int>(),
                Nombre = equipoJson["Nombre"]!.GetValue<string>(),
                Perdidos = equipoJson["Perdidos"]!.GetValue<int>(),
                Puntos = equipoJson["Puntos"]!.GetValue<int>(),
                PuntosContra = equipoJson["PuntosContra"]!.GetValue<int>(),
                PuntosFavor = equipoJson["PuntosFavor"]!.GetValue<int>()
            };
            return equipo;
        }

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

        internal Task Reset()
        {
            _jugados = 0;
            _ganados = 0;
            _perdidos = 0;
            _puntosFavor = 0;
            _puntosContra = 0;
            _coeficiente = 0;
            _puntos = 0;
            return Task.CompletedTask;
        }

        internal Task SetLocal(Partido partido)
        {
            _jugados++;
            if (partido.Resultado.Local > partido.Resultado.Visitante) { _ganados++; _puntos += 2; }
            else if (partido.Resultado.Local < partido.Resultado.Visitante) { _perdidos++; _puntos += 1; }
            _puntosFavor += partido.Resultado.Set1.Local;
            _puntosFavor += partido.Resultado.Set2.Local;
            _puntosFavor += partido.Resultado.Set3.Local;

            _puntosContra += partido.Resultado.Set1.Visitante;
            _puntosContra += partido.Resultado.Set2.Visitante;
            _puntosContra += partido.Resultado.Set3.Visitante;

            _coeficiente = _puntosFavor*1.0 / _puntosContra*1.0;
            return Task.CompletedTask;
        }
        internal Task SetVisitante(Partido partido)
        {
            _jugados++;
            if (partido.Resultado.Local < partido.Resultado.Visitante) { _ganados++; _puntos += 2; }
            else if (partido.Resultado.Local > partido.Resultado.Visitante) { _perdidos++; _puntos += 1; }
            _puntosFavor += partido.Resultado.Set1.Visitante;
            _puntosFavor += partido.Resultado.Set2.Visitante;
            _puntosFavor += partido.Resultado.Set3.Visitante;

            _puntosContra += partido.Resultado.Set1.Local;
            _puntosContra += partido.Resultado.Set2.Local;
            _puntosContra += partido.Resultado.Set3.Local;

            _coeficiente = _puntosFavor*1.0 / _puntosContra*1.0;
            return Task.CompletedTask;
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
