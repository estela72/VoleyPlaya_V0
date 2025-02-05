﻿using General.CrossCutting.Lib;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Repository.Models;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VoleyPlaya.Repository.Repositories
{
    public interface IPartidoRepository:IRepository<Partido>
    {
        Task<Partido> CheckAddUpdate(EdicionGrupo edicionGrupoDto, Equipo localDto, Equipo visitanteDto, 
            int id, int jornada, int numPartido, DateTime fechaHora, string pista, string label, bool validado, string nombreLocal, string nombreVisitante, string ronda);
        Task<List<Partido>> GetListaPartidosAsync(string pruebaSelected, int competicionSelected, int categoriaSelected, string generoSelected, int grupoSelected);
        Task UpdateHoraYPista(Partido partido);
    }
    public class PartidoRepository : Repository<Partido>, IPartidoRepository
    {
        public PartidoRepository(VoleyPlayaDbContext context) : base(context)
        {
        }

        public PartidoRepository(VoleyPlayaDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<Partido> CheckAddUpdate(EdicionGrupo edicionGrupoDto, Equipo localDto, Equipo visitanteDto, 
            int id, int jornada, int numPartido, DateTime fechaHora, string pista, string label, bool validado, string nombreLocal, string nombreVisitante, string ronda)
        {
            var dto = await GetByIdAsync(id);
            if (dto == null)
                return await AddAsyn(new Partido(edicionGrupoDto, localDto, visitanteDto)
                {
                    Jornada = jornada,
                    NumPartido = numPartido,
                    FechaHora = fechaHora,
                    Pista = pista.Trim(),
                    Label = label.Trim(),
                    NombreLocal = nombreLocal.Trim(),
                    NombreVisitante = nombreVisitante.Trim(),
                    Validado = validado,
                    Ronda = ronda
                });
            else
            {
                dto.FechaHora = fechaHora;
                dto.Pista = pista.Trim();
                dto.Label = label.Trim();
                if (localDto!=null && dto.Local.Id!=localDto.Id)
                    dto.Local = localDto;
                if (visitanteDto != null && dto.Visitante.Id!=visitanteDto.Id)
                    dto.Visitante = visitanteDto;
                dto.NombreLocal = nombreLocal.Trim();
                dto.NombreVisitante = nombreVisitante.Trim();
                dto.Validado = validado;
                dto.Ronda = ronda;
                return await UpdateAsync(dto);
            }
            return dto;

        }

        public async Task<List<Partido>> GetListaPartidosAsync(string pruebaSelected, int competicionSelected, int categoriaSelected, string generoSelected, int grupoSelected)
        {
            //var partidos = await FindAllIncludingAsync(p => p.Grupo.Edicion.Prueba.Equals(pruebaSelected), p=>p.Grupo.Edicion, p=>p.Grupo.Edicion.Competicion, p=>p.Grupo.Edicion.Categoria);

            //if (competicionSelected > 0)
            //    partidos = partidos.Where(p => p.Grupo.Edicion.Competicion.Id.Equals(competicionSelected)).ToList();
            //if (categoriaSelected > 0)
            //    partidos = partidos.Where(p => p.Grupo.Edicion.Categoria.Id.Equals(categoriaSelected)).ToList();

            //if (!string.IsNullOrEmpty(generoSelected) && generoSelected!="0")
            //    partidos = partidos.Where(p => p.Grupo.Edicion.Genero.Equals(generoSelected)).ToList();

            //if (grupoSelected > 0)
            //    partidos = partidos.Where(p => p.Grupo.Id.Equals(grupoSelected)).ToList();

            //return partidos.ToList();

            IQueryable<Partido> partidos = DbSet.Where(p => p.Grupo.Edicion.Prueba.Equals(pruebaSelected))
                .Include(p => p.Grupo.Edicion)
                .Include(p => p.Grupo.Edicion.Competicion)
                .Include(p => p.Grupo.Edicion.Categoria);

            if (competicionSelected > 0)
                partidos = partidos.Where(p => p.Grupo.Edicion.CompeticionId.Equals(competicionSelected));
            if (categoriaSelected > 0)
                partidos = partidos.Where(p => p.Grupo.Edicion.CategoriaId.Equals(categoriaSelected));
            if (!string.IsNullOrEmpty(generoSelected) && generoSelected != "0")
                partidos = partidos.Where(p => p.Grupo.Edicion.Genero.Equals(generoSelected));
            return await partidos.ToListAsync();
        }

        public async Task UpdateHoraYPista(Partido partido)
        {
            var part = await GetByIdAsync(partido.Id);
            if (part == null) return;
            part.FechaHora = partido.FechaHora;// new DateTime(partido.FechaHora.Value.Year, partido.FechaHora.Value.Month, partido.FechaHora.Value.Day, partido.FechaHora.Value.Hour, partido.FechaHora.Value.Minute,0);
            part.Pista = partido.Pista;
            await UpdateAsync(part);
        }
    }
}
