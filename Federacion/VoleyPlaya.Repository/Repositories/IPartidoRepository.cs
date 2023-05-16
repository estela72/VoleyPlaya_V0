using General.CrossCutting.Lib;

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
            int id, int jornada, int numPartido, DateTime fechaHora, string pista, string label);
        Task<List<Partido>> GetListaPartidosAsync(int competicionSelected, int categoriaSelected, string generoSelected, int grupoSelected);
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
            int id, int jornada, int numPartido, DateTime fechaHora, string pista, string label)
        {
            var dto = await GetByIdAsync(id);
            if (dto == null)
                return await AddAsyn(new Partido(edicionGrupoDto, localDto, visitanteDto)
                {
                    Jornada = jornada,
                    NumPartido = numPartido,
                    FechaHora = fechaHora,
                    Pista = pista,
                    Label = label
                });
            else
            {
                dto.FechaHora = fechaHora;
                dto.Pista = pista;
                dto.Label = label;
                return await UpdateAsync(dto);
            }
            return dto;

        }

        public async Task<List<Partido>> GetListaPartidosAsync(int competicionSelected, int categoriaSelected, string generoSelected, int grupoSelected)
        {
            var partidos = await FindAllIncludingAsync(p => p.Grupo.Edicion.Competicion.Id.Equals(competicionSelected), p=>p.Grupo.Edicion, p=>p.Grupo.Edicion.Competicion, p=>p.Grupo.Edicion.Categoria);
            if (categoriaSelected > 0)
                partidos = partidos.Where(p => p.Grupo.Edicion.Categoria.Id.Equals(categoriaSelected)).ToList();

            if (!string.IsNullOrEmpty(generoSelected) && generoSelected!="0")
                partidos = partidos.Where(p => p.Grupo.Edicion.Genero.Equals(generoSelected)).ToList();

            if (grupoSelected > 0)
                partidos = partidos.Where(p => p.Grupo.Id.Equals(grupoSelected)).ToList();

            return partidos.ToList();
        }

        public async Task UpdateHoraYPista(Partido partido)
        {
            var part = await GetByIdAsync(partido.Id);
            if (part == null) return;
            part.FechaHora = new DateTime(part.FechaHora.Value.Year, part.FechaHora.Value.Month, part.FechaHora.Value.Day, partido.FechaHora.Value.Hour, partido.FechaHora.Value.Minute,0);
            part.Pista = partido.Pista;
            await UpdateAsync(part);
        }
    }
}
