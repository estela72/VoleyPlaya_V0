using General.CrossCutting.Lib;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using VoleyPlaya.Repository.Models;
using VoleyPlaya.Repository.Services;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VoleyPlaya.Repository.Repositories
{
    public interface IEdicionRepository : IRepository<Edicion>
    {
        Task<Edicion> CheckAddUpdate(Temporada temporadaDto,
                Competicion competicionDto,
                Categoria categoriaDto,
                string genero,
                string grupo,
                int numEquipos,
                int numJornadas);
        Task<IEnumerable<Edicion>> GetFullAsync();
        Task<bool> Remove(string edicionName);
    }
    public class EdicionRepository : Repository<Edicion>, IEdicionRepository
    {
        public EdicionRepository(VoleyPlayaDbContext context) : base(context)
        {
        }

        public EdicionRepository(VoleyPlayaDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<Edicion> CheckAddUpdate(Temporada temporadaDto, Competicion competicionDto, Categoria categoriaDto, 
            string genero, string grupo, int numEquipos, int numJornadas)
        {
            var dto = await FindAsync(c => c.Temporada.Id.Equals(temporadaDto.Id)
                && c.Competicion.Id.Equals(competicionDto.Id)
                && c.Categoria.Id.Equals(categoriaDto.Id)
                && c.Genero!.Equals(genero)
                && c.Grupo!.Equals(grupo));
            if (dto == null)
                return await AddAsyn(new Edicion(temporadaDto, competicionDto, categoriaDto)
                { 
                    Nombre = VoleyPlayaService.GetNombreEdicion(temporadaDto.Nombre,competicionDto.Nombre,categoriaDto.Nombre,genero,grupo),
                    Genero = genero,
                    Grupo = grupo,
                    NumEquipos = numEquipos,
                    NumJornadas = numJornadas
                });
            else
            {
                dto.Genero = genero;
                dto.Grupo = grupo;
                dto.NumEquipos = numEquipos;
                dto.NumJornadas = numJornadas;
                dto = await UpdateAsync(dto);
            }
            return dto;

        }

        public async Task<IEnumerable<Edicion>> GetFullAsync()
        {
            IQueryable<Edicion> ediciones = await GetAllQueryableAsync();
            ediciones = ediciones
                .Include(h => h.Temporada)
                .Include(h => h.Competicion)
                .Include(h => h.Categoria)
                .Include(h => h.Equipos)
                .Include(h => h.Jornadas)
                .Include(h => h.Partidos).ThenInclude(p => p.Parciales);
            return await ediciones.ToListAsync();
        }

        public async Task<bool> Remove(string edicionName)
        {
            var dto = await GetByNameAsync(edicionName);
            if (dto != null)
            {
                //dto.Partidos.ToList().RemoveAll();
                await DeleteAsync(dto.Id);
                return true;
            }
            return false;
        }
    }
}
