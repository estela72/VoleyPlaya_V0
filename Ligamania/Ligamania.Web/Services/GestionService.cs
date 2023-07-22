using AutoMapper;

using General.CrossCutting.Lib;

using Ligamania.API.Lib;
using Ligamania.API.Lib.Models;
using Ligamania.API.Lib.Services;
using Ligamania.Generic.Lib.Enums;
using Ligamania.Web.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Web.Services
{
    public interface IGestionService
    {
        Task<IEnumerable<EquipoVM>> GetAllEquipos(bool bots);

        Task<IEnumerable<UserVM>> GetAllUsers();

        Task<UserVM> GetUserById(string id);

        Task<UserVM> UpdateUser(string id, UserVM updatedUser);

        Task<UserVM> DeleteUserById(string id);

        Task<UserVM> CreateUser(UserVM user);

        Task<IEnumerable<RoleVM>> GetAllRoles();

        Task<IEnumerable<UserVM>> GetUsersByRole(string name);

        Task<GenericResponse> UpdateUsersRole(string newRol, string[] usuarios);

        Task<GenericResponse> RemoveUserFromRole(string userName, string rolName);

        Task<UserVM> ConfirmUserById(string id);

        Task<UserVM> NotConfirmUserById(string id);
        Task<IEnumerable<EntrenadorVM>> GetAllEntrenadores();
        Task<EquipoVM> AddEquipo(byte[] imagen, string nombre, bool esBot, string entrenadorId);
        Task<EquipoVM> AccionEquipo(int equipoId, string accion);
        Task<UserVM> BajaUserById(string id);
    }

    public class GestionService : IGestionService
    {
        private const string EntrenadorDummyName = "Dummy";
        private ILocalStorageService _localStorageService;
        private IMapper _mapper;
        private readonly IEquipoService _equipoService;
        private readonly IUserService _userService;
        private readonly IEntrenadorService _entrenadorService;

        public GestionService(
            ILocalStorageService localStorageService
            , IMapper mapper
            , IEquipoService equipoService
            , IUserService userService
            , IEntrenadorService entrenadorService
        )
        {
            _localStorageService = localStorageService;
            _mapper = mapper;
            _equipoService = equipoService;
            _userService = userService;
            _entrenadorService = entrenadorService;
        }

        public async Task<IEnumerable<EquipoVM>> GetAllEquipos(bool bots)
        {
            var equipos = await _equipoService.GetAllEquipos();
            var equiposSel = equipos.Where(e => e.Estado.Equals(EstadoEquipo.Activo));
            if (!bots)
                equiposSel = equiposSel.Where(e => e.Tipo.Equals(TipoEquipo.Regular));
            var list = _mapper.Map<IEnumerable<Equipo>, IEnumerable<EquipoVM>>(equiposSel);
            return list;
        }

        public async Task<IEnumerable<UserVM>> GetAllUsers()
        {
            var list = await _userService.GetAllUsers();
            return _mapper.Map<IEnumerable<UserVM>>(list);
        }

        public async Task<UserVM> GetUserById(string id)
        {
            var user = await _userService.GetById(id);
            return _mapper.Map<UserVM>(user);
        }

        public async Task<UserVM> UpdateUser(string id, UserVM updatedUser)
        {
            var userUpdated = _mapper.Map<User>(updatedUser);
            var user = await _userService.UpdateUser(id, userUpdated);
            return _mapper.Map<UserVM>(user);
        }

        public async Task<UserVM> DeleteUserById(string id)
        {
            var userDeleted = await _userService.DeleteUser(id);
            return _mapper.Map<UserVM>(userDeleted);
        }

        public async Task<UserVM> CreateUser(UserVM user)
        {
            var userCreated = _mapper.Map<User>(user);
            var result = await _userService.CreateUser(userCreated);
            return _mapper.Map<UserVM>(result);
        }

        public async Task<IEnumerable<RoleVM>> GetAllRoles()
        {
            var list = await _userService.GetAllRoles();
            return _mapper.Map<IEnumerable<RoleVM>>(list);
        }

        public async Task<IEnumerable<UserVM>> GetUsersByRole(string name)
        {
            var users = await _userService.GetUsersByRole(name);
            return _mapper.Map<IEnumerable<UserVM>>(users);
        }

        public async Task<GenericResponse> UpdateUsersRole(string newRol, string[] usuarios)
        {
            var response = await _userService.UpdateUsersRole(newRol, usuarios);
            return response;
        }

        public async Task<GenericResponse> RemoveUserFromRole(string userName, string rolName)
        {
            var response = await _userService.RemoveUserFromRole(userName, rolName);
            return response;
        }

        public async Task<UserVM> ConfirmUserById(string id)
        {
            var userConfirmed = await _userService.ConfirmUser(id);
            return _mapper.Map<UserVM>(userConfirmed);
        }

        public async Task<UserVM> NotConfirmUserById(string id)
        {
            var userNotConfirmed = await _userService.NotConfirmUser(id);
            return _mapper.Map<UserVM>(userNotConfirmed);
        }
        public async Task<IEnumerable<EntrenadorVM>> GetAllEntrenadores()
        {
            var entrenadores = await _userService.GetAllEntrenadores();
            return _mapper.Map<IEnumerable<EntrenadorVM>>(entrenadores);
        }

        public async Task<EquipoVM> AddEquipo(byte[] imagen, string nombre, bool esBot, string entrenadorId)
        {
            var equipo = await _equipoService.AddNewEquipo(imagen, nombre, esBot, entrenadorId);
            return _mapper.Map<EquipoVM>(equipo);
        }

        public async Task<EquipoVM> AccionEquipo(int equipoId, string accion)
        {
            var equipo = await _equipoService.AccionEquipo(equipoId, accion);
            return _mapper.Map<EquipoVM>(equipo);
        }

        public async Task<UserVM> BajaUserById(string id)
        {
            var userBaja = await _userService.BajaUserAsync(id);
            return _mapper.Map<UserVM>(userBaja);
        }
    }
}