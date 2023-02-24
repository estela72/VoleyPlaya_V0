using LigamaniaCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Services
{
    public interface IMenuMasterService
    {
		IEnumerable<MenuMasterViewModel> GetMenuMaster();
		IEnumerable<MenuMasterViewModel> GetMenuMaster(String UserRole);
	}
}
