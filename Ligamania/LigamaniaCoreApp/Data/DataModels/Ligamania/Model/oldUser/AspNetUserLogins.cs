using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model.oldUser
{
    public partial class oldAspNetUserLoginsDTO
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        [Key]
        public string UserId { get; set; }

        public oldAspNetUsersDTO User { get; set; }
    }
}
