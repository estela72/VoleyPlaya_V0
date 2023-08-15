using General.CrossCutting.Lib;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Repository.Models;

namespace VoleyPlaya.Repository.Repositories
{
    public interface ITablaCalendarioRepository : IRepository<TablaCalendario>
    {

    }
    public class TablaCalendarioRepository : Repository<TablaCalendario>, ITablaCalendarioRepository
    {
        public TablaCalendarioRepository(VoleyPlayaDbContext context) : base(context)
        {
        }

        public TablaCalendarioRepository(VoleyPlayaDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
