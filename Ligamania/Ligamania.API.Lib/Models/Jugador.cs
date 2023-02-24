using General.CrossCutting.Lib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ligamania.API.Lib.Models
{
    public class Jugador : Response
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public bool Baja { get; private set; }

        public string Club { get; private set; }
        public string Puesto { get; private set; }
        public int OrdenPuesto { get; private set; }
        public bool Activo { get; private set; }
        public string AliasClub { get; private set; }

        public Jugador()
        {
        }

        public Jugador(string errorMessage) : base(errorMessage)
        {
        }
    }
}
