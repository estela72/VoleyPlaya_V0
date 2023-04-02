using General.CrossCutting.Lib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        DateTime? _fechaHora;
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
        public DateTime? FechaHora { get => _fechaHora; set => _fechaHora = value; }
        public string? Pista { get => _pista; set => _pista = value; }
        public List<ParcialPartido> Parciales { get => (List<ParcialPartido>)_parciales; set => _parciales = value; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }

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
            var set1 = Parciales.Where(p => p.Nombre.Equals("Set1"));
            if (set1 == null || set1.Count()==0)
                Parciales.Add(new ParcialPartido { Partido = this, Nombre = "Set1", ResultadoLocal = set1Local, ResultadoVisitante = set1Visitante });
            else
            {
                set1.First().ResultadoLocal = set1Local;
                set1.First().ResultadoVisitante = set1Visitante;
            }
            var set2 = Parciales.Where(p => p.Nombre.Equals("Set2"));
            if (set2 == null || set2.Count()==0)
                Parciales.Add(new ParcialPartido { Partido = this, Nombre = "Set2", ResultadoLocal = set2Local, ResultadoVisitante = set2Visitante });
            else
            {
                set2.First().ResultadoLocal = set2Local;
                set2.First().ResultadoVisitante = set2Visitante;
            }
            var set3 = Parciales.Where(p => p.Nombre.Equals("Set3"));
            if (set3 == null || set3.Count() == 0)
                Parciales.Add(new ParcialPartido { Partido = this, Nombre = "Set3", ResultadoLocal = set3Local, ResultadoVisitante = set3Visitante });
            else
            {
                set3.First().ResultadoLocal = set3Local;
                set3.First().ResultadoVisitante = set3Visitante;
            }
        }
    }
}
