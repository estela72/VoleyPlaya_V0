using General.CrossCutting.Lib;

using Ligamania.Generic.Lib.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ligamania.API.Lib.Models
{
    public class Temporada : Response
    {
        public Temporada():base()
        { }
        public Temporada(string errorMessage) : base(errorMessage)
        {
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public byte[] Clasificacion { get; set; }
        public EstadoTemporada Estado { get; set; }
        public bool Actual { get; set; }
    }
}
