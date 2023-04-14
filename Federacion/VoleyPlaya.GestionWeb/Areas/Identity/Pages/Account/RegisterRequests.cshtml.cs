// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VoleyPlaya.GestionWeb.Areas.Identity.Pages.Account
{
    [Authorize(Policy = "AdminOnly")]
    public class RegisterRequestsModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterRequestsModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public List<IdentityUser> Requests { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Obtén la lista de usuarios pendientes de confirmación
            Requests = _userManager.Users.Where(u => !u.EmailConfirmed).ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string? userId)
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

            // Obtén la lista de usuarios pendientes de confirmación
            Requests = _userManager.Users.Where(u => !u.EmailConfirmed).ToList();
            return Page();
        }
    }
}