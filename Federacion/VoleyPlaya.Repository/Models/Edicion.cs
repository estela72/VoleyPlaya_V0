using General.CrossCutting.Lib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

using VoleyPlaya.Repository.Enums;

namespace VoleyPlaya.Repository.Models
{
    public class Edicion : Entity
    {
        int _temporadaId;
        int _competicionId;
        int _categoriaId;
        Temporada _temporada;
        Competicion _competicion;
        Categoria _categoria;
        string _prueba;
        string _genero;
        string? _tipoCalendario;
        private string? _modeloCompeticion; // Juegos deportivos o Circuito -> indica como es la distribución de equipos en los grupos
        private EnumEstadoEdicion _estado;

        HashSet<Jornada> _jornadas;
        HashSet<EdicionGrupo> _grupos;
        HashSet<Equipo> _equipos;

        public Edicion()
        {
            _jornadas = new HashSet<Jornada>();
            _grupos = new HashSet<EdicionGrupo>();
            _equipos = new HashSet<Equipo>();
        }

        public Edicion(Temporada temporada, Competicion competicion, Categoria categoria)
        {
            _temporada = temporada;
            _competicion = competicion;
            _categoria = categoria;
            _jornadas = new HashSet<Jornada>();
            _grupos = new HashSet<EdicionGrupo>();
            _equipos = new HashSet<Equipo>();
        }

        public int TemporadaId { get => _temporadaId; set => _temporadaId = value; }
        public Temporada Temporada { get => _temporada; set => _temporada = value; }
        public int CompeticionId { get => _competicionId; set => _competicionId = value; }
        public Competicion Competicion { get => _competicion; set => _competicion = value; }
        public int CategoriaId { get => _categoriaId; set => _categoriaId = value; }
        public Categoria Categoria { get => _categoria; set => _categoria = value; }
        public string Genero { get => _genero; set => _genero = value; }
        public string Prueba { get => _prueba; set => _prueba = value; }
        public string? TipoCalendario { get => _tipoCalendario; set => _tipoCalendario = value; }
        public HashSet<Jornada> Jornadas{ get => _jornadas; set => _jornadas = value; }
        public HashSet<EdicionGrupo> Grupos { get => _grupos; set => _grupos = value; }
        public HashSet<Equipo> Equipos { get => _equipos; set => _equipos = value; }
        public string? ModeloCompeticion { get => _modeloCompeticion; set => _modeloCompeticion = value; }
        public EnumEstadoEdicion Estado { get => _estado; set => _estado = value; }

        internal void AddJornada(Jornada jornadaDto)
        {
            if (!_jornadas.Contains(jornadaDto))
                _jornadas.Add(jornadaDto);
        }
        public void AddGrupo(EdicionGrupo edicionGrupo)
        {
            var dto = Grupos.Where(g => g.Nombre.Equals(edicionGrupo.Nombre));
            if (dto == null)
                Grupos.Add(edicionGrupo);
        }
        public void AddEquipo(Equipo equipo)
        {
            var dto = Equipos.Where(e => e.Nombre.Equals(equipo.Nombre));
            if (dto == null)
                Equipos.Add(equipo);
        }
    }
}
