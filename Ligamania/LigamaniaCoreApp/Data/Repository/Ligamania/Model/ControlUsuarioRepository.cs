using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;

using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{

    public class ControlUsuarioRepository : GenericAuditableRepository<ControlUsuarioDTO>, IControlUsuarioRepository
    {
        public ControlUsuarioRepository(ApplicationDbContext context)
            : base(context)
        {

        }
        public async Task AddAccionUsuario(string userName, string accion, string equipo)
        {
            ControlUsuarioDTO control = new ControlUsuarioDTO
            {
                Accion = accion,
                Fecha = DateTime.UtcNow,
                Usuario = userName, 
                Equipo = equipo
            };
            await AddAsyn(control).ConfigureAwait(false);
            await SaveAsync().ConfigureAwait(false);
        }

    }
}
