using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class PuntuacionHistoricaRepository : Repository<PuntuacionHistoricaDTO>, IPuntuacionHistoricaRepository
    {
        public PuntuacionHistoricaRepository(LigamaniaDbContext context)
            : base(context)
        {
        }

        public int GetPuntuacion(int competicionId, int categoriaId, int puesto, bool pichichi)
        {
            var puntuacion = Find(ph => ph.Competicion_Id.Equals(competicionId) && ph.Categoria_Id.Equals(categoriaId));
            int puntos = puntuacion.Todos;
            if (pichichi) puntos += puntuacion.Pichichi;
            if (puesto == 1) puntos += puntuacion.Campeon;
            else if (puesto == 2) puntos += puntuacion.Subcampeon;
            else if (puesto == 3) puntos += puntuacion.Tercero;
            return puntos;
        }

        public async Task<ICollection<PuntuacionHistoricaDTO>> GetAllPuntuaciones()
        {
            var puntuaciones = await GetAllIncludingAsync(ph => ph.Competicion, ph => ph.Categoria).ConfigureAwait(false)
                ;//.ToListAsync().OrderBy(p => p.Competicion.Orden).ThenBy(p => p.Categoria.Orden);

            return await puntuaciones.ToListAsync().ConfigureAwait(false);
        }
    }
}