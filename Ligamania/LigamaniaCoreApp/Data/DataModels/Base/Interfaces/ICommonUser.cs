using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.DataModels.Base.Interfaces
{
    public enum eUserState { Registered, Confirmed, Baja }

    public interface ICommonUser
    {
        string Id { get; set; }
        string Email { get; set; }
        string UserName { get; set; }
        int LoginCount { get; set; }
        DateTime LastLogin { get; set; }
        DateTime LastLogout { get; set; }
        string PasswordHash { get; set; }

        string City { get; set; }
        string Equipo { get; set; }
        string Conocimiento { get; set; }
        string PhoneNumber { get; set; }
        string CompartirGrupo { get; set; }
        bool Whatsap { get; set; }

        eUserState UserState { get; set; }
    }
}
