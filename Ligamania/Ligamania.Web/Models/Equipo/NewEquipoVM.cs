using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Web.Models.Equipo
{
    public class NewEquipoVM
    {
        public IFormFile escudo { get; set; }
        public string nombre { get; set; }
        public bool esBot { get; set; }
        public string entrenadorId { get; set; }
    }
}
