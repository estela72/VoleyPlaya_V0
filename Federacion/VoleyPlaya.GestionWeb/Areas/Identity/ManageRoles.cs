using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Hosting;

using VoleyPlaya.Domain.Services;
using VoleyPlaya.Repository;

namespace VoleyPlaya.GestionWeb.Areas.Identity
{
    public enum eRoles { Admin, Competiciones, Resultados};
    public class InputUser
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }
    }
    public static class ManageIdentity
    {
        static readonly List<InputUser> AdminUsers = new List<InputUser> {
            new InputUser
            {
                Email="estela.gonzalez@fvbpa.com",
                Name = "Estela Gonzalez",
                Password="Carcaba_51"
            },
            new InputUser
            {
                Email = "voleyasturias@fvbpa.com",
                Name = "Federacion de Voleiboll Asturiana",
                Password = "Voleibol_2023"
            }
        };
        public static async Task AddAdminUsers(this IServiceCollection services)
        {
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                UserManager<IdentityUser> userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
                RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                foreach(var user in AdminUsers)
                {
                    var idUser = new IdentityUser
                    {
                        UserName = user.Name,
                        Email = user.Email,
                        NormalizedUserName = user.Name.ToUpper()
                    };
                    // Buscar el usuario por su Id
                    var newUser = await userManager.FindByEmailAsync(user.Email);
                    if (newUser == null)
                    {
                        await userManager.CreateAsync(idUser, user.Password);
                        newUser = idUser;
                    }
                    await AsignarRol(userManager, roleManager, newUser.Id, eRoles.Admin.ToString());
                    await AsignarRol(userManager, roleManager, newUser.Id, eRoles.Competiciones.ToString());
                    await AsignarRol(userManager, roleManager, newUser.Id, eRoles.Resultados.ToString());
                }
            }
        }

        public static async Task AddApplicationRoles(this IServiceCollection services)
        {
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                foreach (var rol in Enum.GetNames(typeof(eRoles)))
                    await CreateRole(roleManager, rol.ToString());
            }
        }
        public static async Task AddPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy =>
                    policy.RequireRole(eRoles.Admin.ToString()));
                options.AddPolicy("CompeticionesOnly", policy =>
                    policy.RequireRole(eRoles.Competiciones.ToString()));
                options.AddPolicy("ResultadosOnly", policy =>
                    policy.RequireRole(eRoles.Resultados.ToString()));
            });
        }
        // Crear un nuevo rol
        public static async Task CreateRole(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (roleManager == null) return;
            var role = new IdentityRole { Name = roleName };
            var result = await roleManager.CreateAsync(role);
        }

        // Método para asignar un rol a un usuario
        public static async Task AsignarRol(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, string userId, string roleName)
        {
            // Buscar el usuario por su Id
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return;
            }

            // Verificar si el rol existe
            if (!(await roleManager.RoleExistsAsync(roleName)))
            {
                return;
            }

            // Asignar el rol al usuario
            await userManager.AddToRoleAsync(user, roleName);
        }
    }
}
