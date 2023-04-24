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
                string tipoCalendario,
                string lugar
            );

        Task<IEnumerable<Edicion>> GetFullAsync();
        Task<bool> Remove(string edicionName);

        Task<bool> Remove(int id);
        Task<Edicion> GetFullEdicionAsync(int id);
        Task<Edicion> GetFullEdicionAsync(string nombre);
        Task<Edicion> GetBasicAsync(int id);

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
            string genero, string tipoCalendario, string lugar)
        {
            var dto = await FindAsync(c => c.Temporada.Nombre.Equals(temporadaDto.Nombre)
                && c.Competicion.Nombre.Equals(competicionDto.Nombre)
                && c.Categoria.Nombre.Equals(categoriaDto.Nombre)
                && c.Genero!.Equals(genero)
                );
            if (dto == null)
                return await AddAsyn(new Edicion(temporadaDto, competicionDto, categoriaDto)
                {
                    Nombre = VoleyPlayaService.GetNombreEdicion(temporadaDto.Nombre, competicionDto.Nombre, categoriaDto.Nombre, genero),
                    Genero = genero,
                    TipoCalendario = tipoCalendario,
                    Lugar = lugar
                });
            else
            {
                dto.Genero = genero;
                dto.TipoCalendario = tipoCalendario;
                dto.Lugar = lugar;
                dto = await UpdateAsync(dto);
            }
            return dto;
        }
        public async Task<Edicion> GetBasicAsync(int id)
        {
            var edicion = await FindIncludingAsync(e => e.Id.Equals(id),
                e => e.Temporada, e => e.Competicion, e => e.Categoria);
            return edicion;
        }
        public async Task<IEnumerable<Edicion>> GetFullAsync()
        {
            IQueryable<Edicion> ediciones = await GetAllQueryableAsync();
            ediciones = ediciones
                .Include(h => h.Temporada)
                .Include(h => h.Competicion)
                .Include(h => h.Categoria)
                .Include(h => h.Grupos)
                ;
            return await ediciones.ToListAsync();
        }
        public async Task<Edicion> GetFullEdicionAsync(int id)
        {
            var edicion = await FindIncludingAsync(e => e.Id.Equals(id),
                e=>e.Temporada, e=>e.Competicion, e=>e.Categoria, e => e.Grupos, e => e.Equipos, e => e.Jornadas);
            // Cargar las listas de cada grupo
            foreach (var grupo in edicion.Grupos)
            {
                Context.Entry(grupo).Collection(g => g.Equipos).Load();
                Context.Entry(grupo).Collection(g => g.Partidos).Load();
            }
            return edicion;
        }
        public async Task<Edicion> GetFullEdicionAsync(string nombre)
        {
            var edicion = await FindIncludingAsync(e => e.Nombre.Equals(nombre),
                e => e.Temporada, e => e.Competicion, e => e.Categoria, e => e.Grupos, e => e.Equipos, e => e.Jornadas);
            // Cargar las listas de cada grupo
            foreach (var grupo in edicion.Grupos)
            {
                Context.Entry(grupo).Collection(g => g.Equipos).Load();
                Context.Entry(grupo).Collection(g => g.Partidos).Load();
            }
            return edicion;
        }
        public async Task<bool> Remove(string edicionName)
        {
            var dto = await GetByNameAsync(edicionName);
            if (dto != null)
            {
                await DeleteAsync(dto.Id);
                return true;
            }
            return false;
        }
        public async Task<bool> Remove(int id)
        {
            var dto = await GetByIdAsync(id);
            if (dto != null)
            {
                await DeleteAsync(dto.Id);
                return true;
            }
            return false;
        }
        
    }
}
