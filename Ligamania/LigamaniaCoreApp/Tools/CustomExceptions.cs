using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LigamaniaCoreApp.Utils
{
    [Serializable]
    public class GeneralException : Exception
    {
        public GeneralException()
        {
        }

        public GeneralException(string message) : base(message)
        {
        }

        public GeneralException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GeneralException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}