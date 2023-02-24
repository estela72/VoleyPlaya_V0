using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;

namespace Ligamania.Repository.Services
{
    public class ApplicationUserManager<TUser> : UserManager<LigamaniaApplicationUser> where TUser : class
    {
        private readonly LigamaniaDbContext _db;
        private readonly IHttpContextAccessor _contextAccessor;

        public ApplicationUserManager(
            IHttpContextAccessor contextAccessor,
            IOptions<IdentityOptions> optionsAccessor,
            LigamaniaDbContext dbContext,
            IUserStore<LigamaniaApplicationUser> userStore,
            IPasswordHasher<LigamaniaApplicationUser> passwordHasher,
            IEnumerable<IUserValidator<LigamaniaApplicationUser>> userValidators,
            IEnumerable<IPasswordValidator<LigamaniaApplicationUser>> passwordValidators,
            ILookupNormalizer lookupNormalizer,
            IdentityErrorDescriber identityErrorDescriber,
            IServiceProvider serviceProvider,
            ILogger<ApplicationUserManager<LigamaniaApplicationUser>> logger
            )
            : base(userStore, optionsAccessor, passwordHasher, userValidators, passwordValidators, lookupNormalizer, identityErrorDescriber, serviceProvider, logger)
        {
            _contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
            _db = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
    }
}