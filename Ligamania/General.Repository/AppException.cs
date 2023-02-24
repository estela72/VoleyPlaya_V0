using System;
using System.Globalization;

namespace General.CrossCutting.Lib
{
    // Custom exception class for throwing application specific exceptions (e.g. for validation)
    // that can be caught and handled within the application
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    public class AppException : Exception
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    {
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public AppException() : base()
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public AppException(string message) : base(message)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public AppException(string message, params object[] args)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}