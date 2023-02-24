using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;

using Microsoft.EntityFrameworkCore;
namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class CompeticionCategoriaRepository : GenericRepository<CompeticionCategoriaDTO>, ICompeticionCategoriaRepository
    {
        public CompeticionCategoriaRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public async Task<ICollection<CompeticionCategoriaDTO>> GetByCompeticion(string competicion)
        {
            if (!string.IsNullOrEmpty(competicion))
            {
                var lista = await FindAllIncludingAsync(cc => cc.Competicion.Nombre.Equals(competicion) && (bool)cc.Categoria.Activa, cc => cc.Competicion, cc => cc.Categoria).ConfigureAwait(false);
                return lista;
            }
            else
            {
                var lista = await FindAllIncludingAsync(cc => (bool)cc.Categoria.Activa, cc => cc.Competicion, cc => cc.Categoria).ConfigureAwait(false);
                return lista;
            }
        }
        public async Task<ICollection<CompeticionDTO>> GetAllCompeticiones()
        {
            IQueryable<CompeticionCategoriaDTO> lista = await GetAllIncludingAsync(cc=>cc.Competicion).ConfigureAwait(false);
            List<CompeticionDTO> competicions = lista.GroupBy(cc => cc.Competicion.Nombre).Select(grp => grp.First().Competicion).ToList();
            return competicions;
        }

    }
}
