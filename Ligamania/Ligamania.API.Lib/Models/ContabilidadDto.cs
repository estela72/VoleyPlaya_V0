using Ligamania.Generic.Lib.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ligamania.API.Lib.Models
{
    public class ContabilidadDto
    {
        public int Id { get; set; }
        public string Concepto { get; set; }
        public double Valor { get; set; }
        public bool Gasto { get; set; }
        public bool PorEquipo { get; set; }
        public string Temporada { get; set; }
        public int Equipos { get; set; }
    }
    
}
