using General.CrossCutting.Lib;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Repository.Models;

namespace VoleyPlaya.Repository.Repositories
{
    public interface ITemporadaRepository : IRepository<Temporada>
    {
        Task<Temporada> CheckAddUpdate(string nombre);

    }
    public class TemporadaRepository : Repository<Temporada>, ITemporadaRepository
    {
        public TemporadaRepository(VoleyPlayaDbContext context) : base(context)
        {
        }

        public TemporadaRepository(VoleyPlayaDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<Temporada> CheckAddUpdate(string nombre)
        {
            var dto = await FindAsync(c => c.Nombre.Equals(nombre));
            if (dto == null)
                return await AddAsyn(new Temporada { Nombre = nombre });
            return dto;
        }
    }
}
