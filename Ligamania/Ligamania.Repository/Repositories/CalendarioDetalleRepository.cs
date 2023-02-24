using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

namespace Ligamania.Repository.Repositories
{
    public class CalendarioDetalleRepository : BaseRepository<CalendarioDetalleDTO>, ICalendarioDetalleRepository
    {
        public CalendarioDetalleRepository(LigamaniaDbContext context) : base(context)
        {
        }
    }
}