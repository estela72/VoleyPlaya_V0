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
    public interface IEquipoRepository : IRepository<Equipo>
    {
        Task<Equipo> CheckAddUpdate(Edicion edicionDto, int posicion, string nombre, int jugados, int ganados, int perdidos, int puntosFavor, int puntosContra,
                    double coeficiente, int puntos);

    }
    public class EquipoRepository : Repository<Equipo>, IEquipoRepository
    {
        public EquipoRepository(VoleyPlayaDbContext context) : base(context)
        {
        }

        public EquipoRepository(VoleyPlayaDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<Equipo> CheckAddUpdate(Edicion edicionDto, int posicion, string nombre, int jugados, int ganados, int perdidos, 
            int puntosFavor, int puntosContra, double coeficiente, int puntos)
        {
            if (nombre.Equals(string.Empty)) return null;
            var dto = await FindAsync(c => c.Nombre.Equals(nombre) && c.Edicion.Id.Equals(edicionDto.Id));
            if (dto == null)
                return await AddAsyn(new Equipo(edicionDto)
                { 
                    Nombre = nombre, 
                    Perdidos = perdidos,
                    Coeficiente = coeficiente,
                    Ganados = ganados,
                    Jugados = jugados, 
                    Puntos = puntos,
                    PuntosContra = puntosContra, 
                    PuntosFavor = puntosFavor,
                    OrdenCalendario = posicion
                });
            else
            {
                dto.Perdidos = perdidos;
                dto.Coeficiente = coeficiente;
                dto.Ganados = ganados;
                dto.Jugados = jugados;
                dto.Puntos = puntos;
                dto.PuntosContra = puntosContra;
                dto.PuntosFavor = puntosFavor;
                dto.OrdenCalendario = posicion;
                return await UpdateAsync(dto);
            }
        }
    }
}
