using General.CrossCutting.Lib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ligamania.API.Lib.Models
{
    public class Documento : Response
    {
        public Documento()
        {
        }

        public Documento(string errorMessage) : base(errorMessage)
        {
        }

        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Description { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
   
}
