using General.CrossCutting.Lib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VoleyPlaya.Repository.Models
{
    public class ParcialPartido : Entity
    {
        //int _partidoId;
        Partido _partido;
        int? _resultadoLocal;
        int? _resultadoVisitante;

        public ParcialPartido()
        {
        }

        public ParcialPartido(Partido partido)
        {
            _partido = partido;
        }
        //public int PartidoId { get => _partidoId; set => _partidoId = value; }
        public Partido Partido { get => _partido; set => _partido = value; }
        public int? ResultadoLocal { get => _resultadoLocal; set => _resultadoLocal = value; }
        public int? ResultadoVisitante { get => _resultadoVisitante; set => _resultadoVisitante = value; }
    }
}
