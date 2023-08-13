using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Application.Exceptions;

public class GenericDomainException : Exception
{
    public GenericDomainException() : base() { }
    public GenericDomainException(string message) : base(message) { }
}
