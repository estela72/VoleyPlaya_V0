using General.CrossCutting.Lib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Repository.Models
{
    public class EdicionGrupo : Entity
    {
        
        public int EdicionId { get; set; }
        string _tipo;

        Edicion _edicion;
        HashSet<Equipo>? _equipos;
        HashSet<Partido>? _partidos;

        public EdicionGrupo()
        {
            _equipos = new HashSet<Equipo>();
            _partidos = new HashSet<Partido>();
        }

        //public int NumEquipos { get => _numEquipos; set => _numEquipos = value; }
        public string Tipo { get => _tipo; set => _tipo = value; }
        public virtual Edicion Edicion { get => _edicion; set => _edicion = value; }
        public HashSet<Equipo>? Equipos { get => _equipos; set => _equipos = value; }
        public HashSet<Partido>? Partidos { get => _partidos; set => _partidos = value; }

        internal void AddEquipo(Equipo equipoDto)
        {
            if (_equipos.Contains(equipoDto))
            {
                var equi = _equipos.Single(e => e.GetHashCode().Equals(equipoDto.GetHashCode()));
                equi = equipoDto;
            }
            else
                _equipos.Add(equipoDto);
        }

        internal void AddPartido(Partido partidoDto)
        {
            var dto = _partidos.First(p => p.Jornada == partidoDto.Jornada && p.NumPartido == partidoDto.NumPartido);
            if (dto == null)
                _partidos.Add(partidoDto);
            else
            {
                dto = partidoDto;
            }
        }
    }
}
