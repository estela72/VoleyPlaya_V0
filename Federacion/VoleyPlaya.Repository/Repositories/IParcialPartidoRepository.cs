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
    public interface IParcialPartidoRepository : IRepository<ParcialPartido>
    {
        Task<ParcialPartido> CheckAddUpdate(string nombre);

    }
    public class ParcialPartidoRepository : Repository<ParcialPartido>, IParcialPartidoRepository
    {
        public ParcialPartidoRepository(VoleyPlayaDbContext context) : base(context)
        {
        }

        public ParcialPartidoRepository(VoleyPlayaDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public Task<ParcialPartido> CheckAddUpdate(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
