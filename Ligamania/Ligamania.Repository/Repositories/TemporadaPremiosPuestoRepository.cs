using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

namespace Ligamania.Repository.Repositories
{
    public class TemporadaPremiosPuestoRepository : BaseRepository<TemporadaPremiosPuestoDTO>, ITemporadaPremiosPuestoRepository
    {
        public TemporadaPremiosPuestoRepository(LigamaniaDbContext context) : base(context)
        {
        }
    }
}