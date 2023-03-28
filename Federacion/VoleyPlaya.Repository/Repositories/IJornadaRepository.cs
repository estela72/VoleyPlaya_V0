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
    public interface IJornadaRepository : IRepository<Jornada>
    {
        Task<Jornada> CheckAddUpdate(Edicion edicionDto, int numero, DateTime fecha, string nombre);
    }
    public class JornadaRepository : Repository<Jornada>, IJornadaRepository
    {
        public JornadaRepository(VoleyPlayaDbContext context) : base(context)
        {
        }

        public JornadaRepository(VoleyPlayaDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<Jornada> CheckAddUpdate(Edicion edicionDto, int numero, DateTime fecha, string nombre)
        {
            var dto = await FindAsync(j => j.Edicion.Id == edicionDto.Id && j.Numero == numero);
            if (dto == null)
                return await AddAsyn(new Jornada()
                {
                    Edicion = edicionDto,
                    Numero = numero,
                    Fecha = fecha,
                    Nombre = nombre
                });
            else
            {
                dto.Fecha = fecha;
                await UpdateAsync(dto);
            }
            return dto;
        }
    }
}
