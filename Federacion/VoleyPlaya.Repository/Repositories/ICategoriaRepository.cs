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
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<Categoria> CheckAddUpdate(string nombre);
    }
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(VoleyPlayaDbContext context) : base(context)
        {
        }

        public CategoriaRepository(VoleyPlayaDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<Categoria> CheckAddUpdate(string nombre)
        {
            if (string.IsNullOrEmpty(nombre)) return null;
            var dto = await FindAsync(c => c.Nombre.Equals(nombre));
            if (dto == null) 
                return await AddAsyn(new Categoria { Nombre = nombre }); 
            return dto;
        }
    }
}
