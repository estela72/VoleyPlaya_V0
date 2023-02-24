using System.Collections.Generic;

namespace Ligamania.Web.Models
{
    public class UserListVM : BaseVM
    {
        public List<UserVM> usuarios { get; set; }

        public UserListVM() : base()
        {
            usuarios = new List<UserVM>();
            usuarios.Add(new UserVM());
        }
    }
}