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
    }
}
