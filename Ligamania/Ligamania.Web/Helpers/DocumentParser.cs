using Ligamania.Web.Models;

using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Web.Helpers
{
    public class DocumentParser
    {
        public static bool Parse(DocumentoVM documento, IFormFile file, string folderName, string webRootPath)
        {
            string newPath = Path.Combine(webRootPath, folderName);
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {
                string contentType = file.ContentType;
                using (Stream fs = file.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        documento.Contenido = bytes;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
