using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

namespace Ligamania.Repository.Repositories
{
    public class CalendarioRepository : Repository<CalendarioDTO>, ICalendarioRepository
    {
        public CalendarioRepository(LigamaniaDbContext context) : base(context)
        {
        }
    }
}