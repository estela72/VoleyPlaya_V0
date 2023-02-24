using LigamaniaCoreApp.Data;
using LigamaniaCoreApp.Models;
using LigamaniaCoreApp.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LigamaniaCoreApp.Services
{
    // TODO: agregar _logger y añadir try catch en todas las operaciones devolviendo Response (success o error)

    public class MenuMasterService:IMenuMasterService
    {
		private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<MenuMasterService> _logger;

		public MenuMasterService(ApplicationDbContext dbContext, ILogger<MenuMasterService> logger)
		{
			_dbContext = dbContext;
            _logger = logger;
		}

		public IEnumerable<MenuMasterViewModel> GetMenuMaster()
		{ 
			return _dbContext.MenuMaster.Where(m=>m.Order!=-1).OrderBy(m=>m.Order).AsEnumerable();

		}
        public IEnumerable<MenuMasterViewModel> GetMenuMasterToConfig()
        {
            return _dbContext.MenuMaster.OrderBy(m=>m.User_Roll).ThenBy(m => m.Order).AsEnumerable();

        }

        public IEnumerable<MenuMasterViewModel> GetMenuMaster(string UserRole)
		{  
			var result = _dbContext.MenuMaster.Where(m => m.Order != -1 && m.User_Roll == UserRole).OrderBy(m=>m.Order).ToList();  
			return result;
		}

        internal async Task<Response> NuevoMenu(MenuMasterViewModel menu)
        {
            try
            {
                menu.USE_YN = "Y";
                var n = await _dbContext.MenuMaster.AddAsync(menu).ConfigureAwait(false);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                return new Response { Message = "", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("[NuevoMenu] " + x);
                return new Response { Message = "Error al crear nuevo menú", Result = false, Status = EResponseStatus.Error};
            }
        }

        internal async Task<Response> EditarMenu(MenuMasterViewModel menu)
        {
            try
            {
                var menuReg = await _dbContext.MenuMaster.FirstOrDefaultAsync(m => m.MenuIdentity.Equals(menu.MenuIdentity)).ConfigureAwait(false);
                if (menuReg == null) return new Response { Message = "Menú no encontrado", Result = false, Status = EResponseStatus.Error };
                menuReg.MenuFileName = menu.MenuFileName;
                menuReg.MenuID = menu.MenuID;
                menuReg.MenuName = menu.MenuName;
                menuReg.MenuURL = menu.MenuURL;
                menuReg.Order = menu.Order;
                menuReg.Parent_MenuID = menu.Parent_MenuID;
                menuReg.User_Roll = menu.User_Roll;
                menuReg.USE_YN = "Y";
                _dbContext.MenuMaster.Update(menuReg);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                return new Response { Message = "Menu modificado", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("[EditarMenu] " + x);
                return new Response { Message = "Error al editar menú", Result = false, Status = EResponseStatus.Error };
            }
        }

        internal async Task<Response> BorrarMenu(MenuMasterViewModel menu)
        {
            try
            { 
            var menuReg = await _dbContext.MenuMaster.FirstOrDefaultAsync(m => m.MenuIdentity.Equals(menu.MenuIdentity)).ConfigureAwait(false);
            if (menuReg == null) return new Response { Message = "Menú no encontrado", Result = false, Status = EResponseStatus.Error };
            _dbContext.MenuMaster.Remove(menuReg);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return new Response { Message = "Menu eliminado", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("[BorrarMenu] " + x);
                return new Response { Message = "Error al borrar menú", Result = false, Status = EResponseStatus.Error };
            }
        }
    }
}
