using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using LigamaniaCoreApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class AccountRepository : IAccountRepository
    {
        protected ApplicationDbContext _entities;

        public AccountRepository(ApplicationDbContext context)
        {
            _entities = context;
        }
        ///// <summary>
        ///// Devuelve los usuarios que son entrenadores (tienen equipos)
        ///// </summary>
        ///// <returns></returns>
        //public List<UsuarioEquipoInfo> GetUsersEntrenadores()
        //{
        //    List<UsuarioEquipoInfo> lista = _entities.Users.Join(_entities.EntrenadorSet.Include(e => e.Equipo),
        //        u => u.UserName,
        //        e => e.Nombre,
        //        (u, e) => new
        //        {
        //            Usuario = u.UserName,
        //            Entrenador = e.Nombre,
        //            Equipos = e.Equipo.ToList(),
        //            EquipoPrincipal = e.Equipo.FirstOrDefault(eq=>!eq.Baja),
        //            e.Baja,
        //            e.Email,
        //            e.EsBOT,
        //            Estado = u.UserState,
        //            e.Id
        //        })
        //        .OrderBy(l => l.Entrenador)
        //        .Select(u => new UsuarioEquipoInfo
        //            {
        //                Usuario = u.Usuario,
        //                EquipoPrincipal = u.EquipoPrincipal.Nombre,
        //                Baja= u.Baja,
        //                Email = u.Email,
        //                EsBOT = u.EsBOT,
        //                Estado = u.Estado,
        //                Id = u.Id
        //            })
        //        .ToList();
        //    lista = lista.Where(l => !string.IsNullOrEmpty(l.EquipoPrincipal)).ToList();
        //    return lista;
        //}

        //public List<UsuarioEquipoInfo> GetUsersNoEntrenadores()
        //{
        //    List<string> usuarios = GetUsersEntrenadores().Select(u=>u.Usuario).ToList();
        //    List<UsuarioEquipoInfo> usuariosSinEquipos = _entities.Users.Where(
        //        u => u.UserState!=eUserState.Baja && !usuarios.Contains(u.UserName))
        //        .OrderBy(u => u.UserName)
        //        .Select(u => new UsuarioEquipoInfo
        //        {
        //            Usuario = u.UserName,
        //            EquipoPrincipal = string.Empty,
        //            Baja = false,
        //            Email = u.Email,
        //            Estado = u.UserState,
        //            EsBOT = false
        //        })
        //        .ToList();
        //    return usuariosSinEquipos;
        //}
        //public List<UsuarioEquipoInfo> GetEntrenadoresBOT()
        //{
        //    List<UsuarioEquipoInfo> ent = _entities.EquipoSet.Where(e => e.EsBOT && !e.Baja)
        //        .Select(u => new UsuarioEquipoInfo
        //        {
        //            Usuario = u.Entrenador.Nombre,
        //            EquipoPrincipal = u.Nombre,
        //            Baja = u.Baja,
        //            Email = string.Empty,
        //            EsBOT = u.EsBOT,
        //            Estado = eUserState.Confirmed,
        //            Id = u.Id
        //        })
        //        .ToList();
        //    return ent;
        //}
        //public List<UsuarioEquipoInfo> GetUsuariosConfirmados()
        //{
        //    List<UsuarioEquipoInfo> usuario = GetUsersEntrenadores();
        //    List<UsuarioEquipoInfo> usuariosConfirmados = usuario.Where(u => u.Estado.Equals(eUserState.Confirmed) && !u.Baja).ToList();
        //    return usuariosConfirmados;
        //}
        //public List<UsuarioEquipoInfo> GetUsuariosConfirmadosBaja()
        //{
        //    List<UsuarioEquipoInfo> usuario = GetUsersEntrenadores();
        //    List<UsuarioEquipoInfo> usuariosConfirmados = usuario.Where(u => u.Estado.Equals(eUserState.Confirmed) && u.Baja).ToList();
        //    return usuariosConfirmados;
        //}

        //public void StoreAction(ControlUsuario registro)
        //{
        //    _entities.Entry(registro).State = EntityState.Added;
        //    _entities.SaveChanges();
        //}
        //public List<IdentityRole> GetAllRoles()
        //{
        //    return _entities.Roles.ToList();
        //}
        //public List<ApplicationUser> GetAllUsers()
        //{
        //    return _entities.Users.ToList();
        //}

        //public ApplicationUser GetUserByName(string nombre)
        //{
        //    ApplicationUser registro = _entities.Users.FirstOrDefault(u => u.UserName.Equals(nombre));
        //    return registro;
        //}
        //public void NewRol(IdentityRole role)
        //{
        //    _entities.Roles.Add(role);
        //    _entities.SaveChanges();
        //}

        //public async Task<IEnumerable<UsuarioEquipoInfo>> GetUsersEntrenadoresAsync()
        //{
        //    List<UsuarioEquipoInfo> lista = await _entities.Users.Join(_entities.EntrenadorSet.Include(e => e.Equipo),
        //        u => u.UserName,
        //        e => e.Nombre,
        //        (u, e) => new
        //        {
        //            Usuario = u.UserName,
        //            Entrenador = e.Nombre,
        //            Equipos = e.Equipo.ToList(),
        //            EquipoPrincipal = e.Equipo.FirstOrDefault(eq => !eq.Baja),
        //            e.Baja,
        //            e.Email,
        //            e.EsBOT,
        //            Estado = u.UserState,
        //            e.Id
        //        })
        //        .OrderBy(l => l.Entrenador)
        //        .Select(u => new UsuarioEquipoInfo
        //        {
        //            Usuario = u.Usuario,
        //            EquipoPrincipal = u.EquipoPrincipal.Nombre,
        //            Baja = u.Baja,
        //            Email = u.Email,
        //            EsBOT = u.EsBOT,
        //            Estado = u.Estado,
        //            Id = u.Id
        //        })
        //        .Where(l => !string.IsNullOrEmpty(l.EquipoPrincipal))
        //        .ToListAsync();
        //    return lista;
        //}

        //public async Task<IEnumerable<UsuarioEquipoInfo>> GetUsersNoEntrenadoresAsync()
        //{
        //    IEnumerable<UsuarioEquipoInfo> entrenadores = await GetUsersEntrenadoresAsync();
        //    List<string> usuarios = entrenadores.Select(u => u.Usuario).ToList();
        //    List<UsuarioEquipoInfo> usuariosSinEquipos = _entities.Users.Where(
        //        u => u.UserState != eUserState.Baja && !usuarios.Contains(u.UserName))
        //        .OrderBy(u => u.UserName)
        //        .Select(u => new UsuarioEquipoInfo
        //        {
        //            Usuario = u.UserName,
        //            EquipoPrincipal = string.Empty,
        //            Baja = false,
        //            Email = u.Email,
        //            Estado = u.UserState,
        //            EsBOT = false
        //        })
        //        .ToList();
        //    return usuariosSinEquipos;
        //}

        //public async Task StoreActionAsync(ControlUsuario registro)
        //{
        //    _entities.Entry(registro).State = EntityState.Added;
        //    await _entities.SaveChangesAsync();
        //}

        //public async Task<IEnumerable<IdentityRole>> GetAllRolesAsync()
        //{
        //    return await _entities.Roles.ToListAsync();
        //}

        //public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        //{
        //    return await _entities.Users.ToListAsync();
        //}

        //public async Task NewRolAsync(IdentityRole role)
        //{
        //    _entities.Roles.Add(role);
        //    await _entities.SaveChangesAsync();
        //}

        //public async Task<IEnumerable<UsuarioEquipoInfo>> GetUsuariosConfirmadosAsync()
        //{
        //    IEnumerable<UsuarioEquipoInfo> usuario = await GetUsersEntrenadoresAsync();
        //    List<UsuarioEquipoInfo> usuariosConfirmados = usuario.Where(u => u.Estado.Equals(eUserState.Confirmed) && !u.Baja).ToList();
        //    return usuariosConfirmados;
        //}

        //public async Task<IEnumerable<UsuarioEquipoInfo>> GetUsuariosConfirmadosBajaAsync()
        //{
        //    IEnumerable<UsuarioEquipoInfo> usuario = await GetUsersEntrenadoresAsync();
        //    List<UsuarioEquipoInfo> usuariosConfirmados = usuario.Where(u => u.Estado.Equals(eUserState.Confirmed) && u.Baja).ToList();
        //    return usuariosConfirmados;
        //}

        //public async Task<IEnumerable<UsuarioEquipoInfo>> GetEntrenadoresBOTAsync()
        //{
        //    List<UsuarioEquipoInfo> ent = await _entities.EquipoSet.Where(e => e.EsBOT && !e.Baja)
        //        .Select(u => new UsuarioEquipoInfo
        //        {
        //            Usuario = u.Entrenador.Nombre,
        //            EquipoPrincipal = u.Nombre,
        //            Baja = u.Baja,
        //            Email = string.Empty,
        //            EsBOT = u.EsBOT,
        //            Estado = eUserState.Confirmed,
        //            Id = u.Id
        //        })
        //        .ToListAsync();
        //    return ent;
        //}

        //public async Task<ApplicationUser> GetUserByNameAsync(string nombre)
        //{
        //    ApplicationUser registro = await _entities.Users.FirstOrDefaultAsync(u => u.UserName.Equals(nombre));
        //    return registro;
        //}
    }
}
