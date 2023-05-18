// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel.DataAnnotations;

using General.CrossCutting.Lib;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

using VoleyPlaya.GestionWeb.Pages;

namespace VoleyPlaya.GestionWeb.Areas.Identity.Pages.Account
{
    public class UserInfo
    {
        public IdentityUser User { get; set; }
        public List<string> RolesAsignados { get; set; }
    }

    [Authorize(Policy = "AdminOnly")]
    public class RegisterRequestsModel : VPPageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailService _emailService;
        
        public RegisterRequestsModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IEmailService emailService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _emailService = emailService;
            RolesDisponibles = _roleManager.Roles.Select(r => r.Name).ToList();
        }

        [BindProperty]
        public List<UserInfo> Users { get; set; }

        public List<string> RolesDisponibles { get; set; }
        [BindProperty]
        public List<string> RolesAsignados { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Obtén la lista de usuarios 
            await ObtenerListaUsuarios();
            return Page();
        }

        private async Task ObtenerListaUsuarios()
        {
            var users = _userManager.Users.OrderBy(u => u.EmailConfirmed).ToList();
            Users = new List<UserInfo>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                Users.Add(new UserInfo { User = user, RolesAsignados = roles.ToList() });
            }
        }

        public async Task<IActionResult> OnPostAsync(string? userId, string[] rolesSeleccionados)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                // Maneja el caso en el que el usuario no sea encontrado
                return NotFound();
            }

            // Confirma la cuenta del usuario
            user.EmailConfirmed = true;
            await _userManager.UpdateAsync(user);
            try
            {
                await _emailService.Send(user.Email, "[Federación de Voleibol de Asturias] Confirmación de registro",
                    $"Tu registro en la aplicación de Voley Playa ha sido validado. Ya puedes utilizar la aplicación.");
            }
            catch { }

            var rolesAsignados = await _userManager.GetRolesAsync(user);

            foreach (var rol in rolesSeleccionados.Except(rolesAsignados))
            {
                await _userManager.AddToRoleAsync(user, rol);
            }

            foreach (var rol in rolesAsignados.Except(rolesSeleccionados))
            {
                await _userManager.RemoveFromRoleAsync(user, rol);
            }

            // Obtén la lista de usuarios pendientes de confirmación
            await ObtenerListaUsuarios();
            return Page();
        }
    }
}