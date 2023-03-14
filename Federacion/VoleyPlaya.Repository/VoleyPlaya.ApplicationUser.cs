using General.CrossCutting.Lib;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace VoleyPlaya.Repository
{
    public class VoleyPlayaApplicationUser : ApplicationUser
    {
        //public int LoginCount { get; set; }
        //public DateTime LastLogin { get; set; }
        //public DateTime LastLogout { get; set; }
        //public string City { get; set; }
        //public string Conocimiento { get; set; }
        //public string CompartirGrupo { get; set; }
        //public bool Whatsap { get; set; }
        ////public EstadoUsuario UserState { get; set; }
        //public bool IsBot { get; set; }
        //public bool IsEntrenador { get; set; }
        //public string Equipo { get; set; }

        //[NotMapped]
        //public ICollection<string> Equipos { get; set; }

        public async Task<VoleyPlayaApplicationUser> UpdateInfo(VoleyPlayaApplicationUser accountModified)
        {
            //this.PhoneNumber = accountModified.PhoneNumber;
            //this.City = accountModified.City;
            //this.CompartirGrupo = accountModified.CompartirGrupo;
            //this.Conocimiento = accountModified.Conocimiento;
            //this.Email = accountModified.Email;
            //this.UserState = accountModified.UserState;
            //this.Whatsap = accountModified.Whatsap;
            //this.UserName = accountModified.UserName;
            //this.IsBot = accountModified.IsBot;
            //this.IsEntrenador = accountModified.IsEntrenador;
            return await Task.FromResult(this);
        }
    }

    [Owned]
    public class RefreshToken : Entity, IAggregateRoot
    {
        public VoleyPlayaApplicationUser Account { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedByIp { get; set; }
        public string ReplacedByToken { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;
    }
}