using LigamaniaCoreApp.Data;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using LigamaniaCoreApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Services
{
    public class ApplicationSignInManager<TUser> : SignInManager<ApplicationUser> where TUser : class
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _contextAccessor;
        public ApplicationSignInManager(
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<ApplicationUser>> logger,
            ApplicationDbContext dbContext,
            IAuthenticationSchemeProvider schemeProvider
            )
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemeProvider)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
            _db = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public override Task<SignInResult> PasswordSignInAsync(string userName, string password, bool rememberMe, bool shouldLockout)
        {
            var user = UserManager.FindByEmailAsync(userName).Result;

            ////if ((user.IsEnabled.HasValue && !user.IsEnabled.Value) || !user.IsEnabled.HasValue)
            ////{
            ////    return Task.FromResult(SignInResult.LockedOut);
            ////}
            var result = base.PasswordSignInAsync(user.UserName, password, rememberMe, shouldLockout);

            return result;
        }
    }
}
