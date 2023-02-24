using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model.oldUser
{
    public partial class oldAspNetUserRolesDTO
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public oldAspNetRolesDTO Role { get; set; }
        public oldAspNetUsersDTO User { get; set; }
    }
}
