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

        IEnumerable<ParcialPartido> _parciales;

        public Partido()
        {
        }

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
        internal IEnumerable<ParcialPartido> Parciales { get => _parciales; set => _parciales = value; }
    }
}
