using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

namespace Ligamania.Repository.Repositories
{
    public class TemporadaPremiosPuestoRepository : Repository<TemporadaPremiosPuestoDTO>, ITemporadaPremiosPuestoRepository
    {
        public TemporadaPremiosPuestoRepository(LigamaniaDbContext context) : base(context)
        {
        }
    }
}