using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLib
{
    public class VoleyPlayaDomainException : Exception
    {
        public VoleyPlayaDomainException():base() { }
        public VoleyPlayaDomainException(string message) : base(message) { }
    }
}
