namespace General.CrossCutting.Lib
{
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    public abstract class Response
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    {
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public bool Error { get; set; }
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public string Message { get; set; }
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public Response()
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public Response(string errorMessage)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            Message = errorMessage;
            Error = string.IsNullOrEmpty(Message) ? false : true;
        }
    }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    public class GenericResponse : Response
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    {
    }
}