using General.CrossCutting.Lib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ligamania.API.Lib.Models
{
    public class Parametro : Response
    {
        public Parametro()
        {
        }

        public Parametro(string errorMessage) : base(errorMessage)
        {
        }
        public int Id { get; set; }
        public int NumJorVueltaJugadorEliminado { get; set; }
        public string RotuloCopa { get; set; }
        public bool VerRotuloCopa { get; set; }
        public bool VerCuadroCopa { get; set; }
        public string AvisoClasificaciones { get; set; }
        public bool VerAvisoClasificaciones { get; set; }
        public bool VerNoticiasPaginaPrincipal { get; set; }
        public bool VerEquiposPretemporadaPaginaPrincipal { get; set; }
    }
}
