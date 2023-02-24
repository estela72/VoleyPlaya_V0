using General.CrossCutting.Lib;

namespace Ligamania.Repository.Models
{
    public partial class DocumentsDTO : Entity
    {
        public string Description { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}