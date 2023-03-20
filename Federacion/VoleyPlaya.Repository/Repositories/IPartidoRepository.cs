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
        Task<Partido> CheckAddUpdate(Edicion edicionDto, Equipo localDto, Equipo visitanteDto, 
            int jornada, int numPartido, DateTime fecha, TimeSpan hora, string pista);

    }
    public class PartidoRepository : Repository<Partido>, IPartidoRepository
    {
        public PartidoRepository(VoleyPlayaDbContext context) : base(context)
        {
        }

        public PartidoRepository(VoleyPlayaDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<Partido> CheckAddUpdate(Edicion edicionDto, Equipo localDto, Equipo visitanteDto, 
            int jornada, int numPartido, DateTime fecha, TimeSpan hora, string pista)
        {
            var dto = await FindAsync(c => c.Jornada.Equals(jornada)
                && c.NumPartido.Equals(numPartido));
            if (dto == null)
                return await AddAsyn(new Partido(edicionDto, localDto, visitanteDto)
                {
                    Jornada = jornada,
                    NumPartido = numPartido,
                    Fecha = fecha,
                    Hora = hora,
                    Pista = pista
                });
            else
            {
                dto.Fecha = fecha;
                dto.Hora = hora;
                dto.Pista = pista;
                return await UpdateAsync(dto);
            }
            return dto;

        }
    }
}
