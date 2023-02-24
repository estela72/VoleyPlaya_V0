using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using System;
using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class ControlUsuarioRepository : Repository<ControlUsuarioDTO>, IControlUsuarioRepository
    {
        public ControlUsuarioRepository(LigamaniaDbContext context)
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
            //TODO: REVISAR
            //await SaveAsync().ConfigureAwait(false);
        }
    }
}