using AutoMapper;

using General.CrossCutting.Lib;

using Ligamania.API.Lib.Models;
using Ligamania.API.Lib.Models.Requests;
using Ligamania.Generic.Lib.Enums;
using Ligamania.Repository;

using System.Threading.Tasks;

namespace Ligamania.API.Lib
{
    public interface IAccountService
    {
        Task<User> Login(string email, string password);

        Task<User> Authenticate(string email, string password);

        Task<User> GetUserById(string id);

        Task Logout();

        Task<User> Register(RegisterRequest registerRequest, string origin);

        Task<User> VerifyEmail(string email, string token);

        Task<User> ForgotPassword(string email, string origin);

        Task<User> ResetPassword(string token, string email, string password, string confirmPassword);
    }

    public class AccountService : IAccountService
    {
        private readonly ILigamaniaUnitOfWork _ligamaniaUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ILigamaniaConfiguration _appSettings;
        private readonly IEmailService _emailService;

        public AccountService(
            IMapper mapper
            , ILigamaniaUnitOfWork ligamaniaUnitOfWork
            , ILigamaniaConfiguration appSettings
            , IEmailService emailService
            )
        {
            _mapper = mapper;
            _ligamaniaUnitOfWork = ligamaniaUnitOfWork;
            _appSettings = appSettings;
            _emailService = emailService;
        }

        public async Task<User> Authenticate(string email, string password)
        {
            var account = await _ligamaniaUnitOfWork.UserManager.FindByEmailAsync(email);

            if (account == null)
                return new User("No existe una cuenta de usuario con el email " + email);

            var response = await _ligamaniaUnitOfWork.SignInManager.PasswordSignInAsync(account, password, isPersistent: true, lockoutOnFailure: false);
            if (response.Succeeded)
                return _mapper.Map<User>(account);

            return new User("Contraseña incorrecta para el usuario: " + email);
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await _ligamaniaUnitOfWork.UserManager.FindByEmailAsync(email);
            if (user == null)
                return new User("No existe un usuario con este email: " + email);

            //if (await _ligamaniaUnitOfWork.UserManager.CheckPasswordAsync(user, password))
            //{
            var result = await _ligamaniaUnitOfWork.SignInManager.PasswordSignInAsync(user, password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var userToken = _mapper.Map<User>(user);
                return userToken;
            }
            //}
            return new User("Contraseña incorrecta. Vuelva a intentarlo o restablezca su clave");
        }

        public async Task<User> GetUserById(string id)
        {
            var account = await _ligamaniaUnitOfWork.UserManager.FindByIdAsync(id);
            if (account == null)
                return new User("No existe un usuario con el id: " + id);
            var user = _mapper.Map<User>(account);
            return user;
        }

        public async Task Logout()
        {
            await _ligamaniaUnitOfWork.SignInManager.SignOutAsync();
        }

        public async Task<User> Register(RegisterRequest registerRequest, string origin)
        {
            var user = await _ligamaniaUnitOfWork.UserManager.FindByEmailAsync(registerRequest.Email);
            if (user != null)
            {
                // send already registered error in email to prevent account enumeration
                await sendAlreadyRegisteredEmail(registerRequest.Email, origin);
                return new User();
            }

            if (await _ligamaniaUnitOfWork.EquipoRepository.ExistsAsync(e => e.Nombre.Equals(registerRequest.Equipo)))
            {
                return new User("Existe un equipo registrado con ese nombre");
            }

            user = new LigamaniaApplicationUser
            {
                UserName = registerRequest.Name,
                Email = registerRequest.Email,
                City = registerRequest.City,
                CompartirGrupo = registerRequest.CategoriaPreferida,
                Conocimiento = registerRequest.Conocimiento,
                IsBot = registerRequest.EsBot,
                PhoneNumber = registerRequest.PhoneNumber,
                Whatsap = registerRequest.Whatsapp,
                IsEntrenador = true,
                UserState = EstadoUsuario.Registered,
                Equipo = registerRequest.Equipo
            };

            if ((await _ligamaniaUnitOfWork.UserManager.CreateAsync(user, registerRequest.Password)).Succeeded)
            {
                var code = await GenerateVerificationToken(user);

                // send email
                await sendVerificationEmail(user, origin, code);

                var userCreated = _mapper.Map<User>(user);
                return userCreated;
            }
            return new User("El usuario no se ha podido crear");
        }

        private async Task<string> GenerateVerificationToken(LigamaniaApplicationUser user)
        {
            string code = await _ligamaniaUnitOfWork.UserManager.GenerateEmailConfirmationTokenAsync(user);
            code = code.Base64ForUrlEncode();
            return code;
        }

        private async Task<string> GenerateResetToken(LigamaniaApplicationUser user)
        {
            string code = await _ligamaniaUnitOfWork.UserManager.GeneratePasswordResetTokenAsync(user);
            //code = code.Base64ForUrlEncode();
            return code;
        }

        private async Task sendVerificationEmail(LigamaniaApplicationUser account, string origin, string code)
        {
            string message;
            if (!string.IsNullOrEmpty(origin))
            {
                var verifyUrl = $"{origin}/Account/VerifyEmailReceived?id={account.Id}&token={code}";
                message = $@"<p>Por favor, pincha en el siguiente enlace para verificar tu email:</p>
                             <p><a href=""{verifyUrl}"">{verifyUrl}</a></p>";
            }
            else
            {
                message = $@"<p>Por favor, utiliza el siguiente código para verificar tu email pinchando en el siguiente enlace <code>/Account/VerifyEmailReceived</code>:</p>
                             <p><code>{code}</code></p>";
            }

            await _emailService.Send(
                to: account.Email,
                subject: "Ligamania - Verificación de email",
                html: $@"<h4>Verificar Email</h4>
                         <p>Gracias por registrarte!</p>
                         {message}"
            );
        }

        private async Task sendAlreadyRegisteredEmail(string email, string origin)
        {
            string message;
            if (!string.IsNullOrEmpty(origin))
                message = $@"<p>Si no conoces o recuerdas tu contraseña, por favor, visita <a href=""{origin}/Account/ForgotPassword"">forgot password</a>.</p>";
            else
                message = "<p>Si no conoces o recuerdas tu contraseña, puedes resetearla aquí: <code>/Accounts/ForgotPassword</code></p>";

            await _emailService.Send(
                to: email,
                subject: "Ligamania - Verificación de acceso - Email ya registradado",
                html: $@"<h4>Email ya registrado</h4>
                         <p>Su email <strong>{email}</strong> ya está registrado.</p>
                         {message}"
            );
        }

        private async Task sendPasswordResetEmail(LigamaniaApplicationUser account, string origin, string code)
        {
            string message;
            if (!string.IsNullOrEmpty(origin))
            {
                var resetUrl = $"{origin}/Account/ResetPassword";
                message = $@"<p>Por favor, pincha en el siguiente enlace para resetear tu contraseña, el enlace será válido por un día:</p>
                             <p><a href=""{resetUrl}"">{resetUrl}</a></p>
                             <p>Utiliza este código: {code}";
            }
            else
            {
                message = $@"<p>Por favor, pincha en el siguiente enlace para resetear tu contraseña <code>/Account/ResetPassword</code>:</p>
                             <p><code>{code}</code></p>";
            }

            await _emailService.Send(
                to: account.Email,
                subject: "Ligamania - Verificación - Resetear contraseña",
                html: $@"<h4>Resetear contraseña</h4>
                         {message}"
            );
        }

        public async Task<User> VerifyEmail(string id, string token)
        {
            var account = await _ligamaniaUnitOfWork.UserManager.FindByIdAsync(id);
            if (account == null)
                return new User("Error de verificación: el usuario no está registrado");

            var result = await _ligamaniaUnitOfWork.UserManager.ConfirmEmailAsync(account, StringExtensions.Base64ForUrlDecode(token));

            if (result.Succeeded)
            {
                return new User();
            }
            return new User("Error de verificación: código incorrecto");
        }

        public async Task<User> ForgotPassword(string email, string origin)
        {
            var user = await _ligamaniaUnitOfWork.UserManager.FindByEmailAsync(email);
            if (user == null)
                return new User("ForgotPassword: el usuario no está registrado");
            var code = await GenerateResetToken(user);
            await sendPasswordResetEmail(user, origin, code);
            return new User();
        }

        public async Task<User> ResetPassword(string token, string email, string password, string confirmPassword)
        {
            var user = await _ligamaniaUnitOfWork.UserManager.FindByEmailAsync(email);
            if (user == null)
                // Don't reveal that the user does not exist
                return new User("ResetPassword: el usuario no está registrado");
            var result = await _ligamaniaUnitOfWork.UserManager.ResetPasswordAsync(user, token, password);
            if (result.Succeeded)
                return new User();
            return new User("ResetPassword: error al resetear la contraseña. Póngase en contacto con el administrador");
        }

        //public async Task<AccountResponse> Create(CreateRequest model)
        //{
        //    // validate
        //    if (await _accountsRepository.ExistsAsync(x => x.Email == model.Email))
        //        throw new AppException($"Email '{model.Email}' is already registered");

        //    // map model to new account object
        //    var account = _mapper.Map<Account>(model);

        //    account.Creation(BC.HashPassword(model.Password));

        //    // save account
        //    var created = await _accountsRepository.CreateAsync(account);
        //    var saved = await _accountsRepository.UnitOfWork.SaveChangesAsync();

        //    return _mapper.Map<AccountResponse>(account);
        //}

        //public async Task<AccountResponse> Update(int id, UpdateRequest model)
        //{
        //    var account = await getAccount(id);

        //    // validate
        //    if (account.Email != model.Email && await _accountsRepository.ExistsAsync(x => x.Email == model.Email))
        //        throw new AppException($"Email '{model.Email}' is already taken");

        //    // hash password if it was entered
        //    if (!string.IsNullOrEmpty(model.Password))
        //        account.PasswordHash = BC.HashPassword(model.Password);

        //    // copy model to account and save
        //    _mapper.Map(model, account);
        //    var updated = await _accountsRepository.UpdateAsync(account);
        //    var saved = await _accountsRepository.UnitOfWork.SaveChangesAsync();

        //    return _mapper.Map<AccountResponse>(account);
        //}
        //public async Task<(bool exists, int id)> Search(string firstName, string email)
        //{
        //    // validate
        //    if (await _accountsRepository.ExistsAsync(x => x.Email.Equals(email) && x.Name.Equals(firstName)))
        //    {
        //        var user = _accountsRepository.GetAsync(x => x.Email.Equals(email) && x.Name.Equals(firstName));
        //        return (true,user.Id);
        //    }
        //    return (false,0);
        //}
        //public async Task Delete(int id)
        //{
        //    var account = await getAccount(id);
        //    var deleted = _accountsRepository.DeleteAsync(id);
        //    var saved = await _accountsRepository.UnitOfWork.SaveChangesAsync();
        //}

        //public async Task<IEnumerable<AccountResponse>> GetUsersByRoleId(int id)
        //{
        //    var accounts = await _accountsRepository.GetUsersByRoleAsync(id);
        //    return _mapper.Map<IList<AccountResponse>>(accounts);
        //}
        //public async Task<AccountResponse> UpdateUserRoles(IEnumerable<UpdateUserRoleRequest> updateUserRoleRequests)
        //{
        //    AccountResponse account=null;
        //    foreach (var user in updateUserRoleRequests)
        //        account = await UpdateUserRole(user);
        //    return account;
        //}
        //public async Task<AccountResponse> UpdateUserRole(UpdateUserRoleRequest updateUserRoleRequest)
        //{
        //    var account = await getAccount(updateUserRoleRequest.Id);
        //    account.UpdateRole(updateUserRoleRequest.Role);
        //    var saved = await _accountsRepository.UnitOfWork.SaveChangesAsync();

        //    //publicar un evento para notificar el cambio de rol de un usuario
        //    _userRoleUpdateSender.SendUser(account, updateUserRoleRequest);

        //    return _mapper.Map<AccountResponse>(account);
        //}
        //// helper methods

        //private async Task<Account> getAccount(int id)
        //{
        //    //var account = await _context.Accounts.FindAsync(id);
        //    var account = await _accountsRepository.GetByIdAsync(id);
        //    if (account == null) throw new KeyNotFoundException("Account not found");
        //    return account;
        //}

        //private async Task<(RefreshToken, Account)> getRefreshToken(string token)
        //{
        //    //var account = _context.Accounts.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));
        //    var account = await _accountsRepository.GetAsync(u => u.RefreshTokens.Any(t => t.Token == token));
        //    if (account == null) throw new AppException("Invalid token");
        //    var refreshToken = account.GetRefreshToken(token);
        //    if (!refreshToken.IsActive) throw new AppException("Invalid token");
        //    return (refreshToken, account);
        //}

        //private async Task sendVerificationEmail(Account account, string origin)
        //{
        //    string message;
        //    if (!string.IsNullOrEmpty(origin))
        //    {
        //        var verifyUrl = $"{origin}/account/verify-email?token={account.VerificationToken}";
        //        message = $@"<p>Please click the below link to verify your email address:</p>
        //                     <p><a href=""{verifyUrl}"">{verifyUrl}</a></p>";
        //    }
        //    else
        //    {
        //        message = $@"<p>Please use the below token to verify your email address with the <code>/accounts/verify-email</code> api route:</p>
        //                     <p><code>{account.VerificationToken}</code></p>";
        //    }

        //    await _emailService.Send(
        //        to: account.Email,
        //        subject: "Sign-up Verification API - Verify Email",
        //        html: $@"<h4>Verify Email</h4>
        //                 <p>Thanks for registering!</p>
        //                 {message}"
        //    );
        //}

        //private async Task sendAlreadyRegisteredEmail(string email, string origin)
        //{
        //    string message;
        //    if (!string.IsNullOrEmpty(origin))
        //        message = $@"<p>If you don't know your password please visit the <a href=""{origin}/account/forgot-password"">forgot password</a> page.</p>";
        //    else
        //        message = "<p>If you don't know your password you can reset it via the <code>/accounts/forgot-password</code> api route.</p>";

        //    await _emailService.Send(
        //        to: email,
        //        subject: "Sign-up Verification API - Email Already Registered",
        //        html: $@"<h4>Email Already Registered</h4>
        //                 <p>Your email <strong>{email}</strong> is already registered.</p>
        //                 {message}"
        //    );
        //}

        //private async Task sendPasswordResetEmail(Account account, string origin)
        //{
        //    string message;
        //    if (!string.IsNullOrEmpty(origin))
        //    {
        //        var resetUrl = $"{origin}/account/reset-password?token={account.ResetToken}";
        //        message = $@"<p>Please click the below link to reset your password, the link will be valid for 1 day:</p>
        //                     <p><a href=""{resetUrl}"">{resetUrl}</a></p>";
        //    }
        //    else
        //    {
        //        message = $@"<p>Please use the below token to reset your password with the <code>/accounts/reset-password</code> api route:</p>
        //                     <p><code>{account.ResetToken}</code></p>";
        //    }

        //    await _emailService.Send(
        //        to: account.Email,
        //        subject: "Sign-up Verification API - Reset Password",
        //        html: $@"<h4>Reset Password Email</h4>
        //                 {message}"
        //    );
        //}
    }
}