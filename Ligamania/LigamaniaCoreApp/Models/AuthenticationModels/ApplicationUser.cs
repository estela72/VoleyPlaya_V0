using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using Microsoft.AspNetCore.Identity;

namespace LigamaniaCoreApp.Models
{
    public enum eUserState { Registered, Confirmed, Removed }

    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
        }
        public int LoginCount { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime LastLogin { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime LastLogout { get; set; }
        public string City { get; set; }
        public string Conocimiento { get; set; }
        public string CompartirGrupo { get; set; }
        public bool Whatsap { get; set; }
        public eUserState UserState { get; set; }
        public bool IsBot { get; set; }
        public bool IsEntrenador { get; set; }
        public string Equipo { get; set; }
        [NotMapped]
        public ICollection<string> Equipos { get; set; }

        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    // Add custom user claims here
        //    return userIdentity;
        //}
    }
}
