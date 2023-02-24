using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class JugadorRepository : Repository<JugadorDTO>, IJugadorRepository
    {
        public JugadorRepository(LigamaniaDbContext context)
            : base(context)
        {
        }

        public async Task<JugadorDTO> Alta(JugadorDTO jugadorDto)
        {
            jugadorDto.Baja = false;
            return await UpdateAsync(jugadorDto);
        }
        public async Task<JugadorDTO> Baja(JugadorDTO jugadorDto)
        {
            jugadorDto.Baja = true;
            return await UpdateAsync(jugadorDto);
        }
        public List<JugadorDTO> Search(string jugadorToSearch)
        {
            List<JugadorDTO> jugadores = DbSet
                .Where(j => j.Nombre.ToLower().Contains(jugadorToSearch.ToLower()))
                .ToList();
            return jugadores;
        }

    }
}