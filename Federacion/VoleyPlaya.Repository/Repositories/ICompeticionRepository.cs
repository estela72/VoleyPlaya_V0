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
    public interface ICompeticionRepository : IRepository<Competicion>
    {
        Task<Competicion> CheckAddUpdate(string nombre);

    }
    public class CompeticionRepository : Repository<Competicion>, ICompeticionRepository
    {
        public CompeticionRepository(VoleyPlayaDbContext context) : base(context)
        {
        }

        public CompeticionRepository(VoleyPlayaDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<Competicion> CheckAddUpdate(string nombre)
        {
            var dto = await FindAsync(c => c.Nombre.Equals(nombre));
            if (dto == null)
                return await AddAsyn(new Competicion { Nombre = nombre });
            return dto;
        }
    }
}
