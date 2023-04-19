﻿using General.CrossCutting.Lib;

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
    public interface IEdicionGrupoRepository : IRepository<EdicionGrupo>
    {
        Task<EdicionGrupo> CheckAddUpdate(Edicion edicionDto, string nombre, /*int numEquipos,*/ string tipo);
        Task<EdicionGrupo> GetBasicAsync(int id);
        Task<EdicionGrupo> GetWithPartidosAsync(int id);
    }
    public class EdicionGrupoRepository : Repository<EdicionGrupo>, IEdicionGrupoRepository
    {
        public EdicionGrupoRepository(VoleyPlayaDbContext context) : base(context)
        {
        }

        public EdicionGrupoRepository(VoleyPlayaDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<EdicionGrupo> CheckAddUpdate(Edicion edicionDto, string nombre, /*int numEquipos,*/ string tipo)
        {
            var dto = await FindAsync(c => c.Edicion.Id.Equals(edicionDto.Id)
                && c.Nombre.Equals(nombre)
                );
            if (dto == null)
                return await AddAsyn(new EdicionGrupo()
                {
                    Edicion = edicionDto,
                    Nombre=nombre,
                    Tipo = tipo,
                    Equipos = new HashSet<Equipo>()
                });
            else
            {
                dto.Tipo = tipo;
                dto = await UpdateAsync(dto);
            }
            return dto;
        }

        public async Task<EdicionGrupo> GetBasicAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<EdicionGrupo> GetWithPartidosAsync(int id)
        {
            var grupo = await FindIncludingAsync(g => g.Id.Equals(id),
                e => e.Partidos);
            return grupo;
        }

    }
}
