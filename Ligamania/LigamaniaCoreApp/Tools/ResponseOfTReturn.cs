using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Utils
{
    public class ResponseOfTReturn<TReturn> : Response
    {
        public TReturn ResultDTO { get; set; }
    }
}
