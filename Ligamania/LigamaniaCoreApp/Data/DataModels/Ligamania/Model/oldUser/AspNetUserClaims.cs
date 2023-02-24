using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model.oldUser
{
    public partial class oldAspNetUserClaimsDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public oldAspNetUsersDTO User { get; set; }
    }
}
