using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Web.Models.Competicion
{
    public class CategoriaVM
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public int Orden { get; set; }
        public string Activa { get; set; }
        public int NumeroMaximoJugadorEliminar { get; set; }
        public string MarcarPichichi { get; set; }

    }
}
