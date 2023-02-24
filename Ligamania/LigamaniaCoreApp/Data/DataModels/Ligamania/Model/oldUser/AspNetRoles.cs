using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model.oldUser
{
    public partial class oldAspNetRolesDTO
    {
        public oldAspNetRolesDTO()
        {
            AspNetUserRoles = new HashSet<oldAspNetUserRolesDTO>();
        }
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<oldAspNetUserRolesDTO> AspNetUserRoles { get; set; }
    }
}
