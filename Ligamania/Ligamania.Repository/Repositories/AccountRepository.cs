//using General.CrossCutting.Lib;

//using Ligamania.Repository.Interfaces;

//using Microsoft.EntityFrameworkCore;

//namespace Ligamania.Repository.Repositories
//{
//    public class AccountRepository : Repository<Account>, IAccountRepository
//    {
//        public AccountRepository(LigamaniaDbContext context)
//        {
//        }
//        ///// <summary>
//        ///// Devuelve los usuarios que son entrenadores (tienen equipos)
//        ///// </summary>
//        ///// <returns></returns>
//        //public List<UsuarioEquipo_Info> GetUsersEntrenadores()
//        //{
//        //    var ent = _entities.Entrenador.Where(e => e.Equipo != null && e.Equipo.Count > 0);
//        //    var lista = _entities.Users.Join(_entities.Entrenador.Include(e => e.Equipo),
//        //        u => u.UserName,
//        //        e => e.Nombre,
//        //        (u, e) => new
//        //        {
//        //            Usuario = u.UserName,
//        //            Entrenador = e.Nombre,
//        //            Equipos = e.Equipo.ToList(),
//        //            EquipoPrincipal = e.Equipo.Where(eq=>!eq.Baja).FirstOrDefault(),
//        //            e.Baja,
//        //            e.Email,
//        //            e.EsBot,
//        //            Estado = u.UserState,
//        //            e.Id
//        //        })
//        //        .OrderBy(l => l.Entrenador)
//        //        .Select(u => new UsuarioEquipo_Info
//        //            {
//        //                Usuario = u.Usuario,
//        //                EquipoPrincipal = u.EquipoPrincipal.Nombre,
//        //                Baja= u.Baja,
//        //                Email = u.Email,
//        //                EsBOT = u.EsBot,
//        //                Estado = (EUserState)u.Estado,
//        //                Id = u.Id
//        //            })
//        //        .ToList();
//        //    lista = lista.Where(l => !string.IsNullOrEmpty(l.EquipoPrincipal)).ToList();
//        //    return lista;
//        //}

//        //public List<UsuarioEquipo_Info> GetUsersNoEntrenadores()
//        //{
//        //    var usuarios = GetUsersEntrenadores().Select(u=>u.Usuario).ToList();
//        //    var usuariosSinEquipos = _entities.Users
//        //        .Where(u => u.UserState!=(int)EUserState.Baja && !usuarios.Contains(u.UserName))
//        //        .OrderBy(u => u.UserName)
//        //        .Select(u => new UsuarioEquipo_Info
//        //        {
//        //            Usuario = u.UserName,
//        //            EquipoPrincipal = string.Empty,
//        //            Baja = false,
//        //            Email = u.Email,
//        //            Estado = (EUserState)u.UserState,
//        //            EsBOT = false
//        //        })
//        //        .ToList();
//        //    return usuariosSinEquipos;
//        //}
//        //public List<UsuarioEquipo_Info> GetEntrenadoresBOT()
//        //{
//        //    var equi = _entities.Equipo.ToList();
//        //    var equi2 = _entities.Equipo.Where(e => e.Entrenador.EsBot).ToList();
//        //    var ent = _entities.Equipo.Where(e => e.EsBot && !e.Baja)
//        //        .Select(u => new UsuarioEquipo_Info
//        //        {
//        //            Usuario = u.Entrenador.Nombre,
//        //            EquipoPrincipal = u.Nombre,
//        //            Baja = u.Baja,
//        //            Email = string.Empty,
//        //            EsBOT = u.EsBot,
//        //            Estado = EUserState.Confirmed,
//        //            Id = u.Id
//        //        })
//        //        .ToList();
//        //    return ent;
//        //}
//        //public List<UsuarioEquipo_Info> GetUsuariosConfirmados()
//        //{
//        //    var usuario = GetUsersEntrenadores();
//        //    var usuariosConfirmados = usuario.Where(u => u.Estado.Equals(EUserState.Confirmed) && !u.Baja).ToList();
//        //    return usuariosConfirmados;
//        //}
//        //public List<UsuarioEquipo_Info> GetUsuariosConfirmadosBaja()
//        //{
//        //    var usuario = GetUsersEntrenadores();
//        //    var usuariosConfirmados = usuario.Where(u => u.Estado.Equals(EUserState.Confirmed) && u.Baja).ToList();
//        //    return usuariosConfirmados;
//        //}

//        //public void StoreAction(ControlUsuario_DTO registro)
//        //{
//        //    _entities.Entry(registro).State = EntityState.Added;
//        //    _entities.SaveChanges();
//        //}
//        //public List<IdentityRole> GetAllRoles()
//        //{
//        //    return _entities.Roles.ToList();
//        //}
//        //public List<Ligamania_User> GetAllUsers()
//        //{
//        //    return _entities.Users.ToList();
//        //}

//        //public Ligamania_User GetUserByName(string nombre)
//        //{
//        //    var registro = _entities.Users.Where(u => u.UserName.Equals(nombre)).FirstOrDefault();
//        //    return registro;
//        //}
//        //public void NewRol(IdentityRole role)
//        //{
//        //    _entities.Roles.Add(role);
//        //    _entities.SaveChanges();
//        //}
//    }
//}