namespace Ligamania.API.Lib.Models.Requests
{
    public class RegisterRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Conocimiento { get; set; }
        public bool Whatsapp { get; set; }
        public string StrWhats { get { return Whatsapp ? "SI" : "NO"; } set { Whatsapp = value == "SI" ? true : false; } }
        public bool EsBot { get; set; }
        public string Equipo { get; set; }
        public string CategoriaPreferida { get; set; }
    }
}