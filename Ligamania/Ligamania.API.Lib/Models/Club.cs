using General.CrossCutting.Lib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ligamania.API.Lib.Models
{
    public class Club : Response
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Alias { get; private set; }
        public bool Baja { get; private set; }

        public Club()
        {
        }

        public Club(string errorMessage) : base(errorMessage)
        {
        }
    }
}
