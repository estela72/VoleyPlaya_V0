using General.CrossCutting.Lib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace VoleyPlaya.Repository.Models
{
    public class Edicion : Entity
    {
        Temporada _temporada;
        Competicion _competicion;
        Categoria _categoria;
        string? _genero;
        string? _grupo;
        int _numEquipos;
        int _numJornadas;
        string? _lugar;

        HashSet<Equipo> _equipos;
        HashSet<Partido> _partidos;
        HashSet<Jornada> _jornadas;

        public Edicion()
        {
        }

        public Edicion(Temporada temporada, Competicion competicion, Categoria categoria)
        {
            _temporada = temporada;
            _competicion = competicion;
            _categoria = categoria;
            _equipos = new HashSet<Equipo>();
            _partidos = new HashSet<Partido>();
            _jornadas = new HashSet<Jornada>();
        }

        public Temporada Temporada { get => _temporada; set => _temporada = value; }
        public Competicion Competicion { get => _competicion; set => _competicion = value; }
        public Categoria Categoria { get => _categoria; set => _categoria = value; }
        public string? Genero { get => _genero; set => _genero = value; }
        public string? Grupo { get => _grupo; set => _grupo = value; }
        public int NumEquipos { get => _numEquipos; set => _numEquipos = value; }
        public int NumJornadas { get => _numJornadas; set => _numJornadas = value; }
        public string? Lugar { get => _lugar; set => _lugar = value; }
        public HashSet<Equipo> Equipos { get => _equipos; set => _equipos = value; }
        public HashSet<Partido> Partidos {get => _partidos; set => _partidos= value;}
        public HashSet<Jornada> Jornadas{ get => _jornadas; set => _jornadas = value; }

        internal void AddEquipo(Equipo equipoDto)
        {
            _equipos.Add(equipoDto);
        }

        internal void AddPartido(Partido partidoDto)
        {
            var dto = _partidos.First(p => p.Jornada == partidoDto.Jornada && p.NumPartido == partidoDto.NumPartido);
            if(dto == null)
                _partidos.Add(partidoDto);
            else
            {
                dto = partidoDto;
            }
        }

        internal void AddJornada(Jornada jornadaDto)
        {
            if (!_jornadas.Contains(jornadaDto))
                _jornadas.Add(jornadaDto);
        }
    }
}
