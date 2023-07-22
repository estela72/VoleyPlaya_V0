using AutoMapper;

using Ligamania.Generic.Lib.Enums;

//using X.PagedList;
using Ligamania.Web.Models;
using Ligamania.Web.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : BaseController<UserController>
    {
        private readonly IGestionService _gestionService;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger, IGestionService service, IMapper mapper):base(logger)
        {
            _gestionService = service;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            UserListVM model = new UserListVM();
            return View(model);
        }

        public async Task<IActionResult> getListaUsuarios()
        {
            IEnumerable<UserVM> users = await _gestionService.GetAllUsers();
            return Json(users);
        }

        public async Task<IActionResult> getListaUsuariosPendientes()
        {
            IEnumerable<UserVM> users = await _gestionService.GetAllUsers();
            users = users.Where(u => u.Estado.Equals(EstadoUsuario.Registered));
            return Json(users);
        }

        //// GET: UsersController/Details/5
        //public async Task<IActionResult> Details(int id)
        //{
        //    UserVM model = new UserVM();
        //    try
        //    {
        //        model = await _userService.GetById(id);
        //    }
        //    catch (Exception x)
        //    {
        //        model.Error = true;
        //        model.Message = "Error " + x.Message;
        //    }
        //    return View(model);
        //}

        // GET: UsersController/Create
        public IActionResult Create(UserVM model)
        {
            if (model == null)
                model = new UserVM();
            return View(model);
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(UserVM newUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _mapper.Map<UserVM>(newUser);
                    var userCreated = await _gestionService.CreateUser(user);
                    if (!userCreated.Error)
                    {
                        var model = new UserListVM();
                        string msg = "Usuario creado correctamente. El usuario recibirá un email con su contraseña";
                        var users = await _gestionService.GetAllUsers();
                        model.usuarios = users.ToList();
                        model.Set(false, msg);
                        return View("Index", model);
                    }
                    else
                    {
                        var model = new UserVM();
                        model.Set(true, "Error en los datos introducidos o faltan datos");
                        return View("Create", model);
                    }
                }
                else
                {
                    var model = new UserVM();
                    model.Set(true, "Error en los datos introducidos o faltan datos");
                    return View("Create", model);
                }
            }
            catch (Exception x)
            {
                var model = newUser;
                model.Set(true, x.Message);
                return View("Create", model);
            }
        }

        // GET: UsersController/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            EditUserVM model = new EditUserVM();
            try
            {
                var user = await _gestionService.GetUserById(id);
                model = _mapper.Map<EditUserVM>(user);
            }
            catch (Exception x)
            {
                model.Set(true, x.Message);
            }
            return View(model);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, EditUserVM updatedUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _mapper.Map<UserVM>(updatedUser);
                    var userUpdated = await _gestionService.UpdateUser(id, user);
                    if (!userUpdated.Error)
                    {
                        var model = new UserListVM();
                        var users = await _gestionService.GetAllUsers();
                        model.usuarios = users.ToList();
                        model.Set(false, "Usuario actualizado correctamente");
                        return View("Index", model);
                    }
                    else
                    {
                        var model = new UserVM();
                        model.Set(true, "Error en los datos introducidos o faltan datos");
                        return View("Edit", model);
                    }
                }
                else
                {
                    var model = new UserVM();
                    model.Set(true, "Error en los datos introducidos o faltan datos");
                    return View("Edit", model);
                }
            }
            catch (Exception x)
            {
                var model = updatedUser;
                model.Set(true, x.Message);
                return View("Edit", model);
            }
        }

        // GET: UsersController/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            UserVM model = new UserVM();
            try
            {
                var user = await _gestionService.GetUserById(id);
                model = _mapper.Map<UserVM>(user);
            }
            catch (Exception x)
            {
                model.Set(true, x.Message);
            }
            return View(model);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _gestionService.DeleteUserById(id);
                    if (result.Error)
                        return View(result);
                    else
                        return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception x)
            {
                UserVM model = new UserVM();
                model.Set(true, x.Message);
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: UsersController/Delete/5
        public async Task<IActionResult> Confirm(string id)
        {
            UserVM model = new UserVM();
            try
            {
                var user = await _gestionService.GetUserById(id);
                model = _mapper.Map<UserVM>(user);
            }
            catch (Exception x)
            {
                model.Set(true, x.Message);
            }
            return View(model);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Confirm(string id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _gestionService.ConfirmUserById(id);
                    if (result.Error)
                        return View(result);
                    else
                        return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception x)
            {
                UserVM model = new UserVM();
                model.Set(true, x.Message);
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: UsersController/Delete/5
        public async Task<IActionResult> NotConfirm(string id)
        {
            UserVM model = new UserVM();
            try
            {
                var user = await _gestionService.GetUserById(id);
                model = _mapper.Map<UserVM>(user);
            }
            catch (Exception x)
            {
                model.Set(true, x.Message);
            }
            return View(model);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NotConfirm(string id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _gestionService.NotConfirmUserById(id);
                    if (result.Error)
                        return View(result);
                    else
                        return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception x)
            {
                UserVM model = new UserVM();
                model.Set(true, x.Message);
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        // GET: UsersController/Baja/5
        public async Task<IActionResult> Baja(string id)
        {
            UserVM model = new UserVM();
            try
            {
                var user = await _gestionService.GetUserById(id);
                model = _mapper.Map<UserVM>(user);
            }
            catch (Exception x)
            {
                model.Set(true, x.Message);
            }
            return View(model);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Baja(string id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _gestionService.BajaUserById(id);
                    if (result.Error)
                        return View(result);
                    else
                        return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception x)
            {
                UserVM model = new UserVM();
                model.Set(true, x.Message);
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> getListaRoles()
        {
            IEnumerable<RoleVM> roles = await _gestionService.GetAllRoles();
            return Json(roles);
        }

        public IActionResult Roles()
        {
            return View();
        }

        public async Task<IActionResult> getListaUsuariosByRol(string name)
        {
            IEnumerable<UserVM> users = await _gestionService.GetUsersByRole(name);
            UserListVM model = new UserListVM();
            model.usuarios = users.OrderBy(u => u.UserName).ToList();
            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRoles(string newRol, string[] usuarios)
        {
            var response = await _gestionService.UpdateUsersRole(newRol, usuarios);
            if (response.Error)
                return View("Roles", response);
            return RedirectToAction(nameof(Roles));
        }

        public async Task<IActionResult> DeleteFromRole(string userName, string rolName)
        {
            var response = await _gestionService.RemoveUserFromRole(userName, rolName);
            if (response.Error)
                return View("Roles", response);
            return RedirectToAction(nameof(Roles));
        }
    }
}