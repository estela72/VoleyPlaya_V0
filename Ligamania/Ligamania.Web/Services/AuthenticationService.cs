using AutoMapper;

using Ligamania.API.Lib;
using Ligamania.API.Lib.Models;
using Ligamania.API.Lib.Models.Requests;
using Ligamania.Web.Models;

using System.Threading.Tasks;

namespace Ligamania.Web.Services
{
    public interface IAuthenticationService
    {
        Task<UserVM> LoginWithId(string id, string password);

        Task<UserVM> LoginWithEmail(string email, string password);

        Task Logout();

        Task<UserVM> Register(RegisterVM register, string origin);

        Task<UserVM> VerifyEmail(string id, string token);

        Task<UserVM> ForgotPassword(string email, string origin);

        Task<UserVM> ResetPassword(string token, string email, string password, string confirmPassword);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private ILocalStorageService _localStorageService;
        private IMapper _mapper;
        private readonly IAccountService _accountService;

        public AuthenticationService(
            ILocalStorageService localStorageService
            , IMapper mapper
            , IAccountService accountService
        )
        {
            _localStorageService = localStorageService;
            _mapper = mapper;
            _accountService = accountService;
        }

        private async Task<UserVM> GetUserById(string id)
        {
            var account = await _accountService.GetUserById(id);
            UserVM user = _mapper.Map<UserVM>(account);
            return user;
        }

        public async Task<UserVM> LoginWithId(string id, string password)
        {
            var user = await GetUserById(id);
            if (user.Error)
                return await LoginWithEmail(user.Email, password);
            return new UserVM(user.Message);
        }

        public async Task<UserVM> LoginWithEmail(string email, string password)
        {
            var account = await _accountService.Login(email, password);
            if (!account.Error)
            {
                _localStorageService.SetItem("user", account);
                UserVM user = _mapper.Map<UserVM>(account);
                return user;
            }
            return new UserVM(account.Message);
        }

        public async Task Logout()
        {
            await _accountService.Logout();
            _localStorageService.RemoveItem("user");
        }

        public async Task<UserVM> Register(RegisterVM register, string origin)
        {
            var registerRequest = _mapper.Map<RegisterRequest>(register);
            var account = await _accountService.Register(registerRequest, origin);
            return _mapper.Map<UserVM>(account);
        }

        public async Task<UserVM> VerifyEmail(string id, string token)
        {
            var account = await _accountService.VerifyEmail(id, token);
            return _mapper.Map<UserVM>(account);
        }

        public async Task<UserVM> ForgotPassword(string email, string origin)
        {
            var account = await _accountService.ForgotPassword(email, origin);
            return _mapper.Map<UserVM>(account);
        }

        public async Task<UserVM> ResetPassword(string token, string email, string password, string confirmPassword)
        {
            var account = await _accountService.ResetPassword(token, email, password, confirmPassword);
            return _mapper.Map<UserVM>(account);
        }

        private async Task<User> GetCurrentUser()
        {
            return await _localStorageService.GetItem<User>("user");
        }
    }
}