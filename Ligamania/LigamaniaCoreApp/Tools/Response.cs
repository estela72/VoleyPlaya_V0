using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Utils
{
    public class Response
    {
        public bool Result { get; set; }
        public EResponseStatus Status { get; set; }
        public string Message { get; set; }

        //public ETipoAviso TipoAviso
        //{
        //    get
        //    {
        //        if (Status == EResponseStatus.Error)
        //            return ETipoAviso.Error;
        //        else if (Status == EResponseStatus.Info)
        //            return ETipoAviso.Info;
        //        else if (Status == EResponseStatus.Success)
        //            return ETipoAviso.Success;
        //        else
        //            return ETipoAviso.Warning;
        //    }
        //}
    }
}
