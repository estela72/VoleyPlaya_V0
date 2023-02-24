using General.CrossCutting.Lib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ligamania.API.Lib.Models
{
    public class Categoria : Response
    {
        public Categoria()
        {
        }

        public Categoria(string errorMessage) : base(errorMessage)
        {
        }

        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public int Orden { get; private set; }
        public bool Activa { get; private set; }
        public int NumeroMaximoJugadorEliminar { get; set; }
        public bool MarcarPichichi { get; set; }

    }
}
