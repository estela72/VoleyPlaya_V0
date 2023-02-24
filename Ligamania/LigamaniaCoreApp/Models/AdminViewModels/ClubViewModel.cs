using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.AdminViewModels
{
    public class ClubViewModel
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Club { get; set; }
        public bool Activo { get; set; }
    }
}
