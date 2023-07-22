using AutoMapper;

using General.CrossCutting.Lib;

using Ligamania.API.Lib.Models;
using Ligamania.Repository;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.API.Lib
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();

        Task<User> GetById(string id);

        Task<User> UpdateUser(string id, User updatedUser);

        Task<User> DeleteUser(string id);

        Task<User> CreateUser(User userCreated);

        Task<IEnumerable<Role>> GetAllRoles();

        Task<IEnumerable<User>> GetUsersByRole(string name);

        Task<GenericResponse> UpdateUsersRole(string newRol, string[] usuarios);

        Task<GenericResponse> RemoveUserFromRole(string userName, string rolName);

        Task<User> ConfirmUser(string id);

        Task<User> NotConfirmUser(string id);
        Task<IEnumerable<Entrenador>> GetAllEntrenadores();
        Task<User> BajaUserAsync(string id);
    }

    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly ILigamaniaUnitOfWork _ligamaniaUnitOfWork;

        public UserService(IMapper mapper
            , ILigamaniaUnitOfWork ligamaniaUnitOfWork
            )
        {
            _mapper = mapper;
            _ligamaniaUnitOfWork = ligamaniaUnitOfWork;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var usersLgm = await _ligamaniaUnitOfWork.UserManager.Users.ToListAsync();
            var users = _mapper.Map<List<User>>(usersLgm);
            foreach (var user in users)
            {
                var userLgm = usersLgm.First(us => us.Id.Equals(user.Id));
                var roles = await _ligamaniaUnitOfWork.UserManager.GetRolesAsync(userLgm);
                user.Roles = string.Join(',', roles);
            }
            return users;
        }

        public async Task<User> GetById(string id)
        {
            var account = await _ligamaniaUnitOfWork.UserManager.FindByIdAsync(id);
            return _mapper.Map<User>(account);
        }

        public async Task<User> UpdateUser(string id, User updatedUserRequest)
        {
            var accountRequested = _mapper.Map<LigamaniaApplicationUser>(updatedUserRequest);
            var account = await _ligamaniaUnitOfWork.UserManager.FindByIdAsync(id);
            var accountModified = await account.UpdateInfo(accountRequested);

            var result = await _ligamaniaUnitOfWork.UserManager.UpdateAsync(accountModified);
            if (result.Succeeded)
                return _mapper.Map<User>(accountModified);
            return new User("Error al actualizar el usuario: " + result.Errors);
        }

        public async Task<User> DeleteUser(string id)
        {
            var user = await _ligamaniaUnitOfWork.UserManager.FindByIdAsync(id);
            var result = await _ligamaniaUnitOfWork.UserManager.DeleteAsync(user);
            if (result.Succeeded)
                return new User();
            var userRet = _mapper.Map<User>(user);
            userRet.Error = true;
            userRet.Message = "Error al eliminar el usuario con id " + id;
            return userRet;
        }

        public async Task<User> CreateUser(User userCreated)
        {
            var accountToCreate = _mapper.Map<LigamaniaApplicationUser>(userCreated);
            if (_ligamaniaUnitOfWork.UserManager.Users.Any(u => u.UserName.Equals(userCreated.UserName)))
                return new User { Error = true, Message = "Ya existe un usuario con el nombre especificado" };
            if (_ligamaniaUnitOfWork.UserManager.Users.Any(u => u.Email.Equals(userCreated.Email)))
                return new User { Error = true, Message = "Ya existe un usuario con el email especificado" };

            var result = await _ligamaniaUnitOfWork.UserManager.CreateAsync(accountToCreate);
            if (result.Succeeded)
                return _mapper.Map<User>(accountToCreate);
            return new User { Error = true, Message = result.Errors.ToArray().ToString() };
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            var rolesLgm = await _ligamaniaUnitOfWork.RolManager.Roles.ToListAsync();
            var roles = _mapper.Map<List<Role>>(rolesLgm);
            foreach (var rol in roles)
            {
                rol.Description = getRolDescription(rol.Name);
                rol.NumberOfUsers = (await _ligamaniaUnitOfWork.UserManager.GetUsersInRoleAsync(rol.Name)).Count();
            }
            return roles;
        }

        private string getRolDescription(string name)
        {
            switch (name)
            {
                case "Invitado": return "El usuario tiene permisos sólo para visualizar las páginas públicas como Carrusel, Calendario, Historial";
                case "Entrenador": return "El usuario tiene permisos para gestionar su o sus equipos de Ligamanía";
                case "Admin": return "El usuario tiene permisos para añadir/eliminar jugadores, clubs, manejar el panel de control y los goleadores";
                case "Manager": return "El usuario tiene permisos para añadir/eliminar usuarios, equipos, entrenadores";
            }
            return "Sin descripción";
        }

        public async Task<IEnumerable<User>> GetUsersByRole(string name)
        {
            var users = await _ligamaniaUnitOfWork.UserManager.GetUsersInRoleAsync(name);
            return _mapper.Map<IEnumerable<User>>(users);
        }

        public async Task<GenericResponse> UpdateUsersRole(string newRol, string[] usuarios)
        {
            //var role = await _ligamaniaUnitOfWork.RolManager.FindByNameAsync(newRol);
            foreach (var userName in usuarios)
            {
                var user = await _ligamaniaUnitOfWork.UserManager.FindByNameAsync(userName);
                var result = await _ligamaniaUnitOfWork.UserManager.AddToRoleAsync(user, newRol);
                if (!result.Succeeded)
                    return new GenericResponse { Error = true, Message = "Error asignando el rol " + newRol + " al usuario " + userName };
                if (newRol.Equals("Entrenador"))
                {
                    user.IsEntrenador = true;
                    var result2 = await _ligamaniaUnitOfWork.UserManager.UpdateAsync(user);
                    if (!result2.Succeeded)
                        return new GenericResponse { Error = true, Message = "Error estableciendo que el usuario es entrenador: " + userName };
                }
            }
            return new GenericResponse { Error = false };
        }

        public async Task<GenericResponse> RemoveUserFromRole(string userName, string rolName)
        {
            var user = await _ligamaniaUnitOfWork.UserManager.FindByNameAsync(userName);
            var result = await _ligamaniaUnitOfWork.UserManager.RemoveFromRoleAsync(user, rolName);
            if (!result.Succeeded)
                return new GenericResponse { Error = true, Message = "Error eliminando el rol " + rolName + " al usuario " + userName };
            return new GenericResponse { Error = false };
        }

        public async Task<User> ConfirmUser(string id)
        {
            var user = await _ligamaniaUnitOfWork.UserManager.FindByIdAsync(id);
            user.UserState = Generic.Lib.Enums.EstadoUsuario.Confirmed;
            var result = await _ligamaniaUnitOfWork.UserManager.UpdateAsync(user);
            if (result.Succeeded)
                return new User();
            var userRet = _mapper.Map<User>(user);
            userRet.Error = true;
            userRet.Message = "Error al confirmar el usuario con id " + id;
            return userRet;
        }

        public async Task<User> NotConfirmUser(string id)
        {
            var user = await _ligamaniaUnitOfWork.UserManager.FindByIdAsync(id);
            user.UserState = Generic.Lib.Enums.EstadoUsuario.Registered;
            var result = await _ligamaniaUnitOfWork.UserManager.UpdateAsync(user);
            if (result.Succeeded)
                return new User();
            var userRet = _mapper.Map<User>(user);
            userRet.Error = true;
            userRet.Message = "Error al confirmar el usuario con id " + id;
            return userRet;
        }
        public async Task<IEnumerable<Entrenador>> GetAllEntrenadores()
        {
            var entrenadores = await _ligamaniaUnitOfWork.UserManager.GetUsersInRoleAsync("Entrenador");
            var listEntrenadores = _mapper.Map<IEnumerable<Entrenador>>(entrenadores);
            foreach (var entrenador in listEntrenadores)
            {
                var equipos = await _ligamaniaUnitOfWork.EquipoRepository.FindAllAsync(e => e.ApplicationUser.Id.Equals(entrenador.Id));
                entrenador.SetNumEquipos(equipos != null ? equipos.Count : 0);
                entrenador.Equipos = _mapper.Map<IEnumerable<Equipo>>(equipos);
            }
            return listEntrenadores;
        }

        public async Task<User> BajaUserAsync(string id)
        {
            var user = await _ligamaniaUnitOfWork.UserManager.FindByIdAsync(id);
            user.UserState = Generic.Lib.Enums.EstadoUsuario.Removed;
            var result = await _ligamaniaUnitOfWork.UserManager.UpdateAsync(user);
            if (result.Succeeded)
                return new User();
            var userRet = _mapper.Map<User>(user);
            userRet.Error = true;
            userRet.Message = "Error al dar de baja el usuario con id " + id;
            return userRet;
        }
    }
}