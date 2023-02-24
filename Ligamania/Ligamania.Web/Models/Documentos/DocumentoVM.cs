using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Web.Models
{
    public class DocumentoVM : BaseVM
    {
        public int Id { get; set; }
        public string Documento { get; set; }
        public string Descripcion { get; set; }
        public byte[] Contenido { get; set; }
        public string Tipo { get; set; }
    }
}
