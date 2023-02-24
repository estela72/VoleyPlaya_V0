using General.CrossCutting.Lib;

using Ligamania.Generic.Lib.Enums;

namespace Ligamania.API.Lib.Models
{
    public class User : Response
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdEntrenador { get; set; }
        public string UserName { get; set; }
        public string Roles { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Conocimiento { get; set; }
        public string CompartirGrupo { get; set; }
        public bool Whatsap { get; set; }
        public EstadoUsuario UserState { get; set; }
        public bool IsBot { get; set; }
        public bool IsEntrenador { get; set; }

        public User()
        {
        }

        public User(string errorMessage) : base(errorMessage)
        { }
    }
}