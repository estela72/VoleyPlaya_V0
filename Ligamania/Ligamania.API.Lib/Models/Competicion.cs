using General.CrossCutting.Lib;

using Ligamania.Generic.Lib.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ligamania.API.Lib.Models
{
    public class Competicion : Response
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public bool RepetirClubAliIni { get; private set; }
        public int JornadaCuadro { get; private set; }
        public bool CopiarAlineacionInicial { get; private set; }
        public string CompeticionCopiarAliIni { get; private set; }
        public int Orden { get; private set; }
        public TipoCompeticion Tipo { get; private set; }

        public bool EsLiga { get { if (Tipo == TipoCompeticion.Liga) return true; return false; } }

        public bool EsCopa { get { if (Tipo == TipoCompeticion.Copa) return true; return false; } }

        public bool EsSupercopa { get { if (Tipo == TipoCompeticion.Supercopa) return true; return false; } }

        public int CambiosFijos { get; set; }
        public bool Activa { get; set; }
        public string DescripcionEstado { get; set; }


        public Competicion()
        {
        }

        public Competicion(string errorMessage) : base(errorMessage)
        {
        }
    }
}
