using Ligamania.Web.Models;
using Ligamania.Web.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : BaseController<AccountController>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IGestionService _gestionService;

        public AccountController(ILogger<AccountController> logger, IAuthenticationService service, IGestionService gestionService)
            : base(logger)
        {
            _authenticationService = service;
            _gestionService = gestionService;
        }

        public async Task<IActionResult> Login()
        {
            UserVM model = new UserVM();
            try
            {
                // redirect to home if already logged in
                if (User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Index", "Home");
                }
                //var listOfEquipos = await _gestionService.GetAllEquipos(bots: false);
                //ViewBag.ListOfEquipos = new SelectList(listOfEquipos.OrderBy(e => e.Nombre).ToList(), "EntrenadorId", "Nombre");
            }
            catch (Exception x)
            {
                //ViewBag.ListOfUsers = new SelectList(new List<string>());
                model.Set(true, x.Message);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserVM model)
        {
            if (ModelState.IsValid)
            {
                model.Loading = true;
                var user = model;
                try
                {
                    if (!string.IsNullOrEmpty(model.Email))
                        user = await _authenticationService.LoginWithEmail(model.Email, model.Password);
                    else if (!string.IsNullOrEmpty(model.Equipo))
                        user = await _authenticationService.LoginWithId(model.Equipo, model.Password);

                    if (!user.Error)
                    {
                        var msg = "Usuario " + user.Email + " entra en sesión";
                        logInfo(msg);
                        model.Set(false, msg);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        model.Set(true, user.Message);
                        ModelState.AddModelError("Login", "Server Error. Please contact administrator.");
                    }
                }
                catch (Exception ex)
                {
                    model.Set(true, ex.Message);
                    ModelState.AddModelError("Login", "Server Error. Please contact administrator.");
                }
            }
            model.Loading = false;
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _authenticationService.Logout();
            var msg = "Usuario " + User.Identity.Name + " sale de sesión";
            logInfo(msg);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View(new RegisterVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _authenticationService.Register(model, Request.Headers["origin"]);

                    if (!user.Error)
                    {
                        var msg = "Usuario " + model.Name + " " + " registrado en Ligamanía. Verifique su email para confirmar y finalizar el registro";
                        logInfo(msg);
                        model.Set(false, msg);
                        return RedirectToAction("VerifyEmail");
                    }
                    ModelState.AddModelError("Register", user.Message);
                }
                catch (Exception ex)
                {
                    model.Set(true, ex.Message);
                    ModelState.AddModelError("Register", "Server Error. Please contact administrator.");
                }
            }
            return View(model);
        }

        public IActionResult VerifyEmail()
        {
            return View(new VerifyEmailVM());
        }

        public async Task<IActionResult> VerifyEmailReceived(string id, string token)
        {
            UserVM model = new UserVM();
            try
            {
                model = await _authenticationService.VerifyEmail(id, token);
                if (!model.Error)
                {
                    var msg = "Verificación correcta. Ya puede acceder a Ligamanía";
                    logInfo(msg);
                    model.Set(false, msg);
                    return RedirectToAction("Login");
                }
                ModelState.AddModelError("VerifyEmail", model.Message);
            }
            catch (Exception ex)
            {
                model.Set(true, ex.Message);
                ModelState.AddModelError("VerifyEmail", "Server Error. Please contact administrator.");
            }
            return RedirectToAction("Login");
        }

        public IActionResult ForgotPassword()
        {
            return View(new ForgotPasswordVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _authenticationService.ForgotPassword(model.Email, Request.Headers["origin"]);
                    if (!user.Error)
                    {
                        var msg = "Enviado email para recuperar contraseña";
                        logInfo(msg);
                        model.Set(false, msg);
                        return RedirectToAction("ResetPassword");
                    }
                    ModelState.AddModelError("ForgotPassword", user.Message);
                }
                catch (Exception ex)
                {
                    model.Set(true, ex.Message);
                    ModelState.AddModelError("ForgotPassword", "Server Error. Please contact administrator.");
                }
            }
            return View(model);
        }

        public IActionResult ResetPassword()
        {
            return View(new ResetPasswordVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _authenticationService.ResetPassword(model.Token, model.Email, model.Password, model.ConfirmPassword);
                    if (!user.Error)
                    {
                        var msg = "Contraseña renovada";
                        logInfo(msg);
                        model.Set(false, msg);
                        return RedirectToAction("Login");
                    }
                    ModelState.AddModelError("ResetPassword", user.Message);
                }
                catch (Exception ex)
                {
                    model.Set(true, ex.Message);
                    ModelState.AddModelError("ResetPassword", "Server Error. Please contact administrator.");
                }
            }
            return View(model);
        }
    }
}