using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Web.Models
{
    public class DocumentoListVM : BaseVM
    {
        public List<DocumentoVM> documentos { get; set; }
        public DocumentoVM nuevoDocumento { get; set; }

        public DocumentoListVM() : base()
        {
            Inicializar();
        }
        public DocumentoListVM(string message) : base(message)
        {
            Inicializar();
        }

        private void Inicializar()
        {
            documentos = new List<DocumentoVM>();
            documentos.Add(new DocumentoVM());
            nuevoDocumento = new DocumentoVM();
        }

    }
}
