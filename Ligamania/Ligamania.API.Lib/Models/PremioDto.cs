using Ligamania.Generic.Lib.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ligamania.API.Lib.Models
{
    public class PremioDto
    {
        public int Id { get; set; }
        public string Competicion { get; set; }
        public string Categoria { get; set; }
        public string Equipo { get; set; }
        public double Premio { get; set; }
        public double Porcentaje { get; set; }
        public PuestoCompeticion Puesto { get; set; }
    }
}
