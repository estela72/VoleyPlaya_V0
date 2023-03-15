using General.CrossCutting.Lib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Repository.Models
{
    public class Edicion : Entity
    {
        Temporada _temporada;
        Competicion _competicion;
        Categoria _categoria;
        string? _genero;
        string? _grupo;

        IEnumerable<Equipo> _equipos;
        IEnumerable<Partido> _partidos;

        public Edicion()
        {
        }

        public Edicion(Temporada temporada, Competicion competicion, Categoria categoria)
        {
            _temporada = temporada;
            _competicion = competicion;
            _categoria = categoria;
            _equipos = new List<Equipo>();
            _partidos = new List<Partido>();
        }

        public Temporada Temporada { get => _temporada; set => _temporada = value; }
        public Competicion Competicion { get => _competicion; set => _competicion = value; }
        public Categoria Categoria { get => _categoria; set => _categoria = value; }
        public string? Genero { get => _genero; set => _genero = value; }
        public string? Grupo { get => _grupo; set => _grupo = value; }
        public IEnumerable<Equipo> Equipos { get => _equipos; set => _equipos = value; }
        public IEnumerable<Partido> Partidos {get => _partidos; set => _partidos= value;}
    }
}
