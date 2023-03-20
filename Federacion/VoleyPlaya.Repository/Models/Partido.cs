using General.CrossCutting.Lib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Repository.Models
{
    public class Partido:Entity   
    {
        Edicion _edicion;
        Equipo _local;
        Equipo _visitante;
        int? _resultadoLocal;
        int? _resultadoVisitante;
        int? _jornada;
        int? _numPartido;
        DateTime? _fecha;
        TimeSpan? _hora;
        string? _pista;

        ICollection<ParcialPartido> _parciales;

        public Partido() => _parciales = new List<ParcialPartido>();

        public Partido(Edicion edicion, Equipo local, Equipo visitante)
        {
            _edicion = edicion;
            _local = local;
            _visitante = visitante;
            _parciales = new List<ParcialPartido>();
        }

        public Edicion Edicion { get => _edicion; set => _edicion = value; }
        public Equipo Local { get => _local; set => _local = value; }
        public Equipo Visitante { get => _visitante; set => _visitante = value; }
        public int? ResultadoLocal { get => _resultadoLocal; set => _resultadoLocal = value; }
        public int? ResultadoVisitante { get => _resultadoVisitante; set => _resultadoVisitante = value; }
        public int? Jornada { get => _jornada; set => _jornada = value; }
        public int? NumPartido { get => _numPartido; set => _numPartido = value; }
        public DateTime? Fecha { get => _fecha; set => _fecha = value; }
        public TimeSpan? Hora { get => _hora; set => _hora = value; }
        public string? Pista { get => _pista; set => _pista = value; }
        internal List<ParcialPartido> Parciales { get => (List<ParcialPartido>)_parciales; set => _parciales = value; }

        internal void AddEquipo(string v, Equipo equipoDto)
        {
            if (v.Equals("local"))
                Local = equipoDto;
            else
                Visitante = equipoDto;
        }

        internal void AddResultado(int resLocal, int resVisitante, int set1Local, int set1Visitante, int set2Local, int set2Visitante, int set3Local, int set3Visitante)
        {
            ResultadoLocal = resLocal;
            ResultadoVisitante = resVisitante;
            Parciales.Add(new ParcialPartido { Partido = this, ResultadoLocal = set1Local, ResultadoVisitante = set1Visitante });
            Parciales.Add(new ParcialPartido { Partido = this, ResultadoLocal = set2Local, ResultadoVisitante = set2Visitante });
            Parciales.Add(new ParcialPartido { Partido = this, ResultadoLocal = set3Local, ResultadoVisitante = set3Visitante });
        }
    }
}
