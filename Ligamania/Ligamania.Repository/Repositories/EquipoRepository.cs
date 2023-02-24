using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using Microsoft.Extensions.Logging;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class EquipoRepository : Repository<EquipoDTO>, IEquipoRepository
    {
        public EquipoRepository(LigamaniaDbContext context, ILogger<EquipoRepository> logger)
            : base(context, logger)
        {
        }

        public async Task<EquipoDTO> AddNewEquipo(byte[] imagen, string nombre, bool esBot, LigamaniaApplicationUser user)
        {
            EquipoDTO equipo = new EquipoDTO
            {
                ApplicationUser = user,
                Baja = false,
                EsBot = esBot,
                EscudoImage = imagen,
                Nombre = nombre
            };
            var equipoAdded = await AddAsyn(equipo);
            return equipoAdded;
        }

        public async Task<ICollection<EquipoDTO>> GetEquiposActivos()
        {
            var equipos = await FindAllAsync(e => !e.Baja).ConfigureAwait(false);
            return equipos;
        }
    }
}