using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.DataModels.Base.Model
{
    [Serializable]
    public class FormattedDbEntityValidationException : Exception
    {
        public FormattedDbEntityValidationException()
        {
        }

        //public FormattedDbEntityValidationException(DbEntityValidationException innerException) :
        //    base(null, innerException)
        //{
        //}

        public FormattedDbEntityValidationException(string message) : base(message)
        {
        }

        public FormattedDbEntityValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FormattedDbEntityValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
