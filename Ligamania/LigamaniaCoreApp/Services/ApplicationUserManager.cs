using AutoMapper;
using LigamaniaCoreApp.Data;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using LigamaniaCoreApp.Models;
using LigamaniaCoreApp.Models.AccountViewModels;
using LigamaniaCoreApp.Models.ManagerViewModels;
using LigamaniaCoreApp.Services.Interfaces;
using LigamaniaCoreApp.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Services
{
    public class ApplicationUserManager<TUser> : UserManager<ApplicationUser> where TUser : class
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IEquipoRepository _equipoRepository;
        private readonly ITemporadaRepository _temporadaRepository;
        private readonly ICambiosEquipoRepository _cambiosEquipoRepository;
        private readonly ITemporadaEquipoRepository _temporadaEquipoRepository;
        private readonly ITemporadaPartidoRepository _temporadaPartidoRepository;
        private readonly ITemporadaClasificacionRepository _temporadaClasificacionRepository;
        private readonly IControlUsuarioRepository _controlUsuarioRepository;

        private readonly IMapper _mapper;

        public ApplicationUserManager(
            IHttpContextAccessor contextAccessor,
            IOptions<IdentityOptions> optionsAccessor,
            ApplicationDbContext dbContext,
            IUserStore<ApplicationUser> userStore,
            IPasswordHasher<ApplicationUser> passwordHasher,
            IEnumerable<IUserValidator<ApplicationUser>> userValidators,
            IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators,
            ILookupNormalizer lookupNormalizer,
            IdentityErrorDescriber identityErrorDescriber,
            IServiceProvider serviceProvider,
            ILogger<UserManager<ApplicationUser>> logger,
            IEquipoRepository equipoRepository,
            ITemporadaRepository temporadaRepository,
            ICambiosEquipoRepository cambiosEquipoRepository,
            ITemporadaEquipoRepository temporadaEquipoRepository,
            ITemporadaPartidoRepository temporadaPartidoRepository,
            ITemporadaClasificacionRepository temporadaClasificacionRepository,
            IControlUsuarioRepository controlUsuarioRepository,
            IMapper mapper
            )
            : base(userStore, optionsAccessor, passwordHasher, userValidators, passwordValidators, lookupNormalizer, identityErrorDescriber, serviceProvider, logger)
        {
            _contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
            _db = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _equipoRepository = equipoRepository;
            _temporadaEquipoRepository = temporadaEquipoRepository;
            _temporadaRepository = temporadaRepository;
            _cambiosEquipoRepository = cambiosEquipoRepository;
            _temporadaPartidoRepository = temporadaPartidoRepository;
            _temporadaClasificacionRepository = temporadaClasificacionRepository;
            _controlUsuarioRepository = controlUsuarioRepository;
            _mapper = mapper;
        }
        public async Task<bool> FindByEquipoAsync(string equipo)
        {
            var equi = await _equipoRepository.GetByNameAsync(equipo).ConfigureAwait(false);
            return (equi != null);
        }
        public async Task<IEnumerable<EquipoDTO>> GetEquipos(ApplicationUser user)
        {
            var equipos = await _equipoRepository.FindAllAsync(e => e.ApplicationUser.Id.Equals(user.Id) && !e.Baja).ConfigureAwait(false);
            return equipos;
        }
        public async Task<ICollection<Tuple<string, string>>> GetListofUsersAndTrainers(bool incluirBots=false)
        {
            var entrenadores = await GetEntrenadores(incluirBots).ConfigureAwait(false);
            var usersNoEntrenadores = await GetUsersNoEntrenadores(incluirBots).ConfigureAwait(false);
            ICollection<Tuple<string, string>> lista = new List<Tuple<string, string>>();

            foreach (var user in entrenadores)
            {
                IEnumerable<EquipoDTO> equipos = await GetEquipos(user).ConfigureAwait(false);
                user.Equipos = equipos.Select(e => e.Nombre).ToList();
                foreach (var equipo in user.Equipos)
                {
                    lista.Add(new Tuple<string, string>(user.Email+ "#" + equipo, equipo));
                }
            }
            lista = lista.OrderBy(l => l.Item2).ToList();
            foreach (var user in usersNoEntrenadores)
            {
                lista.Add(new Tuple<string, string>(user.Email + "#" + user.UserName, user.UserName));
            }
            return lista;
        }
        public async Task<ICollection<Tuple<string, string>>> GetListofEntrenadores()
        {
            var entrenadores = await GetEntrenadores().ConfigureAwait(false);
            ICollection<Tuple<string, string>> lista = new List<Tuple<string, string>>();
            foreach (var user in entrenadores)
            {
                lista.Add(new Tuple<string, string>(user.Email, user.UserName));
            }
            return lista;
        }

        private async Task<List<ApplicationUser>> GetEntrenadores(bool incluirBots=false)
        {
            var entrenadores = await Users
                .Where(u => (incluirBots||!u.IsBot) && u.UserState.Equals(eUserState.Confirmed) && u.IsEntrenador)
                .OrderBy(u => u.UserName)
                .ToListAsync().ConfigureAwait(false);
            return entrenadores;
        }
        private async Task<List<ApplicationUser>> GetUsersNoEntrenadores(bool incluirBots = false)
        {
            var usersNoEntrenadores = await Users
                .Where(u => (incluirBots || !u.IsBot) && u.UserState.Equals(eUserState.Confirmed) && !u.IsEntrenador)
                .OrderBy(u => u.UserName)
                .ToListAsync().ConfigureAwait(false);
            return usersNoEntrenadores;
        }
        public async Task<List<RegisterViewModel>> GetInfoEquipos(bool incluirBots=false)
        {
            var entrenadores = await GetEntrenadores(incluirBots).ConfigureAwait(false);
            List<RegisterViewModel> lista = new List<RegisterViewModel>();
            foreach (var entrenador in entrenadores)
            {
                IEnumerable<EquipoDTO> equipos = await GetEquipos(entrenador).ConfigureAwait(false);
                foreach (var equipo in equipos)
                {
                    RegisterViewModel entVM = _mapper.Map<RegisterViewModel>(entrenador);
                    entVM.Equipo = equipo.Nombre;
                    entVM.EquipoId = equipo.Id;
                    lista.Add(entVM);
                }
            }
            return lista;
        }

        internal async Task<Response> EditarEquipo(RegisterViewModel equipoInfo)
        {
            try
            {
                var entrenador = await Users.FirstOrDefaultAsync(u => u.UserName.Equals(equipoInfo.UserName)).ConfigureAwait(false);
                if (entrenador==null)
                    return new Response { Message = "No se encuentra el entrenador", Result = false, Status = EResponseStatus.Warning};

                #region Modificar datos del entrenador
                var email = equipoInfo.Email;
                if (entrenador.Email != email)
                {
                    var setEmailResult = await SetEmailAsync(entrenador, email).ConfigureAwait(false);
                    if (!setEmailResult.Succeeded)
                    {
                        throw new ApplicationException($"Unexpected error occurred setting email for user with ID '{entrenador.Id}'.");
                    }
                }

                var telefono = equipoInfo.PhoneNumber;
                if (entrenador.PhoneNumber != telefono)
                {
                    var setEmailResult = await SetPhoneNumberAsync(entrenador, telefono).ConfigureAwait(false);
                    if (!setEmailResult.Succeeded)
                    {
                        throw new ApplicationException($"Unexpected error occurred setting phonenumber for user with ID '{entrenador.Id}'.");
                    }
                }
                var esbot = equipoInfo.EsBot;
                if (entrenador.IsBot!=esbot)
                {
                    entrenador.IsBot = esbot;
                    var setModificar = await UpdateAsync(entrenador).ConfigureAwait(false);
                    if (!setModificar.Succeeded)
                    {
                        throw new ApplicationException($"Unexpected error occurred setting IsBot parameters for user with ID '{entrenador.Id}'.");
                    }
                }
                #endregion
                
                // si lo que se pretende es cambiar el nombre del equipo
                if (equipoInfo.Equipo != equipoInfo.EquipoNuevo)
                {
                    Response response = await CambiarNombreEquipo(equipoInfo, entrenador).ConfigureAwait(false);
                    if (!response.Result)
                        return response;
                }

                return new Response { Message = "Equipo modificado", Result = true, Status = EResponseStatus.Success};
            }
            catch (Exception x)
            {
                return new Response { Message = "Error al editar equipo", Result = false, Status = EResponseStatus.Error };
            }
        }

        private async Task<Response> CambiarNombreEquipo(RegisterViewModel equipoInfo, ApplicationUser entrenador)
        {
            EquipoDTO equipo = await _equipoRepository.GetAsync(equipoInfo.EquipoId).ConfigureAwait(false);
            if (equipo == null)
                return new Response { Message = "No se encuentra el equipo " + equipoInfo.Equipo, Result = false, Status = EResponseStatus.Warning };

            EquipoDTO equipoNuevo = await _equipoRepository.GetByNameAsync(equipoInfo.EquipoNuevo).ConfigureAwait(false);
            //if (equipoNuevo != null)
            //    return new Response { Message = "El equipo " + equipoInfo.EquipoNuevo + " ya existe", Result = false, Status = EResponseStatus.Warning };

            equipo.Baja = true;
            await _equipoRepository.UpdateAsyn(equipo, equipo.Id).ConfigureAwait(false);
            EquipoDTO nuevo = null;
            if (equipoNuevo == null)
            {
                nuevo = new EquipoDTO
                {
                    ApplicationUser = entrenador,
                    Baja = false,
                    EsBot = equipoInfo.EsBot,
                    Nombre = equipoInfo.EquipoNuevo
                };
                await _equipoRepository.AddAsyn(nuevo).ConfigureAwait(false);
            }
            else
            {
                nuevo = equipoNuevo;
                nuevo.Baja = false;
                await _equipoRepository.UpdateAsyn(nuevo, nuevo.Id).ConfigureAwait(false);
            }
            await _equipoRepository.SaveAsync().ConfigureAwait(false);

            TemporadaDTO tActual = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
            CambiosEquipoDTO cambioEquipo = new CambiosEquipoDTO
            {
                EquipoDestino = nuevo,
                EquipoOrigen = equipo,
                Temporada = tActual
            };
            await _cambiosEquipoRepository.AddAsyn(cambioEquipo).ConfigureAwait(false);
            await _cambiosEquipoRepository.SaveAsync().ConfigureAwait(false);

            // buscar el equipo anterior en la temporada actual en: TemporadaEquipo, TemporadaPartido, TemporadaClasificacion y cambiar
            var temEquipos = await _temporadaEquipoRepository.FindAllAsync(te => te.Temporada.Actual && te.EquipoId.Equals(equipo.Id)).ConfigureAwait(false);
            foreach(var temEqui in temEquipos)
            {
                temEqui.EquipoId = nuevo.Id;
                await _temporadaEquipoRepository.UpdateAsyn(temEqui, temEqui.Id).ConfigureAwait(false);
            }
            var temClas = await _temporadaClasificacionRepository.FindAllAsync(te => te.Temporada.Actual && te.EquipoId.Equals(equipo.Id)).ConfigureAwait(false);
            foreach (var temEqui in temClas)
            {
                temEqui.EquipoId = nuevo.Id;
                await _temporadaClasificacionRepository.UpdateAsyn(temEqui, temEqui.Id).ConfigureAwait(false);
            }
            var temPartidosA = await _temporadaPartidoRepository.FindAllAsync(te => te.Temporada.Actual && te.EquipoAId.Equals(equipo.Id)).ConfigureAwait(false);
            var temPartidosB = await _temporadaPartidoRepository.FindAllAsync(te => te.Temporada.Actual && te.EquipoBId.Equals(equipo.Id)).ConfigureAwait(false);
            var temPartidos = temPartidosA.ToList();
            temPartidos.AddRange(temPartidosB.ToList());
            foreach (var partido in temPartidos)
            {
                if (partido.EquipoAId.Equals(equipo.Id))
                   partido.EquipoAId = nuevo.Id;
                if (partido.EquipoBId.Equals(equipo.Id))
                    partido.EquipoBId = nuevo.Id;
                await _temporadaPartidoRepository.UpdateAsyn(partido, partido.Id).ConfigureAwait(false);
            }
            await _temporadaClasificacionRepository.SaveAsync().ConfigureAwait(false);

            return new Response { Message = "Equipo modificado de nombre", Result = true, Status = EResponseStatus.Success };
        }

        public async Task<ICollection<AccionUsuarioViewModel>> GetAccionesUsuarios()
        {
            var acciones = await _controlUsuarioRepository.GetAllAsyn().ConfigureAwait(false);
            var lista = _mapper.Map<List<ControlUsuarioDTO>, List<AccionUsuarioViewModel>>(acciones.ToList());

            return lista;
        }

        internal async Task<List<RegisterViewModel>> GetInventarioEntrenadores()
        {
            var users = await Users.ToListAsync().ConfigureAwait(false);

            List<RegisterViewModel> lista = new List<RegisterViewModel>();
            foreach (var user in users)
            {
                IEnumerable<EquipoDTO> equipos = await GetEquipos(user).ConfigureAwait(false);
                var roles = await GetRolesAsync(user).ConfigureAwait(false);
                RegisterViewModel entVM = _mapper.Map<RegisterViewModel>(user);
                if (equipos.Any())
                {
                    foreach (var equipo in equipos)
                    {
                        entVM.Equipo = equipo.Nombre;
                        entVM.EquipoId = equipo.Id;
                        lista.Add(entVM);
                    }
                }
                else
                {
                    entVM.Equipo = null;
                    entVM.EquipoId = 0;
                    lista.Add(entVM);
                }
                if (roles.Any())
                {
                    entVM.Roles = roles.ToList();
                }
            }
            return lista;
        }

        

        internal async Task<Response> AddRoleToUser(RegisterViewModel equipoInfo)
        {
            try
            {
                var user = await Users.FirstOrDefaultAsync(u => u.UserName.Equals(equipoInfo.UserName)).ConfigureAwait(false);
                await AddToRoleAsync(user, equipoInfo.NewRole).ConfigureAwait(false);
                return new Response { Message = "Rol añadido", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                return new Response { Message = "Error al añadir rol", Result = false, Status = EResponseStatus.Error };
            }
        }

        internal async Task<Response> RemoveRoleFromUser(RegisterViewModel equipoInfo)
        {
            try
            {
                var user = await Users.FirstOrDefaultAsync(u => u.UserName.Equals(equipoInfo.UserName)).ConfigureAwait(false);
                await RemoveFromRoleAsync(user, equipoInfo.NewRole).ConfigureAwait(false);
                return new Response { Message = "Rol borrado", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                return new Response { Message = "Error al borrar rol", Result = false, Status = EResponseStatus.Error };
            }
        }
    }
}
