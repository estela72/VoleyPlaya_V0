using LigamaniaCoreApp.Data.DataModels.Base.Interfaces;
using LigamaniaCoreApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model.oldUser
{
    public partial class oldAspNetUsersDTO
    {
        public oldAspNetUsersDTO()
        {
            AspNetUserClaims = new HashSet<oldAspNetUserClaimsDTO>();
            AspNetUserLogins = new HashSet<oldAspNetUserLoginsDTO>();
            AspNetUserRoles = new HashSet<oldAspNetUserRolesDTO>();
        }
        public string Id { get; set; }
        public int LoginCount { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime LastLogout { get; set; }
        public string City { get; set; }
        public string Equipo { get; set; }
        public string Conocimiento { get; set; }
        public string CompartirGrupo { get; set; }
        public bool Whatsap { get; set; }
        public eUserState UserState { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }

        public ICollection<oldAspNetUserClaimsDTO> AspNetUserClaims { get; set; }
        public ICollection<oldAspNetUserLoginsDTO> AspNetUserLogins { get; set; }
        public ICollection<oldAspNetUserRolesDTO> AspNetUserRoles { get; set; }
    }
}
