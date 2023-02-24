using LigamaniaCoreApp.Data.DataModels.Base.Model;
using System;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model
{
    public partial class DocumentsDTO : AuditableNameEntity
    {
        public string Description { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}
