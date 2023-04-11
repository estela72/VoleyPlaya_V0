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
        Task<Equipo> CheckAddUpdate(EdicionGrupo edicionGrupoDto, int posicion, string nombre, int jugados, int ganados, int perdidos, int puntosFavor, int puntosContra,
                    double coeficiente, int puntos);
        Task CheckAddUpdate(Edicion edicionDto, int posicion, string equiNombre, int jugados, int ganados, int perdidos, int puntosFavor, int puntosContra, double coeficiente, int puntos);
        Task RemoveEquipos(int numEquipos, EdicionGrupo edicionGrupo);
    }
    public class EquipoRepository : Repository<Equipo>, IEquipoRepository
    {
        public EquipoRepository(VoleyPlayaDbContext context) : base(context)
        {
        }

        public EquipoRepository(VoleyPlayaDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<Equipo> CheckAddUpdate(EdicionGrupo edicionGrupoDto, int posicion, string nombre, int jugados, int ganados, int perdidos, 
            int puntosFavor, int puntosContra, double coeficiente, int puntos)
        {
            if (nombre.Equals(string.Empty)) return null;
            var dto = await FindAsync(c => c.Nombre.Equals(nombre) && c.EdicionGrupo.Nombre.Equals(edicionGrupoDto.Nombre)) ?? 
                await FindAsync(c => c.Nombre.Equals(nombre) && c.Edicion.Id.Equals(edicionGrupoDto.Edicion.Id));
            if (dto == null)
                return await AddAsyn(new Equipo(edicionGrupoDto)
                { 
                    Nombre = nombre, 
                    Perdidos = perdidos,
                    Coeficiente = coeficiente,
                    Ganados = ganados,
                    Jugados = jugados, 
                    Puntos = puntos,
                    PuntosContra = puntosContra, 
                    PuntosFavor = puntosFavor,
                    OrdenCalendario = posicion,
                    Edicion = edicionGrupoDto.Edicion,
                    EdicionGrupo = edicionGrupoDto
                });
            else
            {
                dto.Nombre = nombre;
                dto.OrdenCalendario = posicion;
                dto.Perdidos = perdidos;
                dto.Coeficiente = coeficiente;
                dto.Ganados = ganados;
                dto.Jugados = jugados;
                dto.Puntos = puntos;
                dto.PuntosContra = puntosContra;
                dto.PuntosFavor = puntosFavor;
                dto.Edicion = edicionGrupoDto.Edicion;
                dto.EdicionGrupo = edicionGrupoDto;
                return await UpdateAsync(dto);
            }
        }

        public async Task CheckAddUpdate(Edicion edicionDto, int posicion, string nombre, int jugados, int ganados, int perdidos, int puntosFavor, int puntosContra, double coeficiente, int puntos)
        {
            if (nombre.Equals(string.Empty)) return;
            var dto = await FindAsync(c => c.Nombre.Equals(nombre) && c.Edicion.Id.Equals(edicionDto.Id)) ?? await FindAsync(c => c.OrdenCalendario.Equals(posicion) && c.Edicion.Id.Equals(edicionDto.Id));
            if (dto == null)
                await AddAsyn(new Equipo
                {
                    Nombre = nombre,
                    Perdidos = perdidos,
                    Coeficiente = coeficiente,
                    Ganados = ganados,
                    Jugados = jugados,
                    Puntos = puntos,
                    PuntosContra = puntosContra,
                    PuntosFavor = puntosFavor,
                    OrdenCalendario = posicion,
                    Edicion = edicionDto
                });
            else
            {
                dto.Nombre = nombre;
                dto.Perdidos = perdidos;
                dto.Coeficiente = coeficiente;
                dto.Ganados = ganados;
                dto.Jugados = jugados;
                dto.Puntos = puntos;
                dto.PuntosContra = puntosContra;
                dto.PuntosFavor = puntosFavor;
                dto.OrdenCalendario = posicion;
                await UpdateAsync(dto);
            }
        }

        public async Task RemoveEquipos(int numEquipos, EdicionGrupo edicionGrupo)
        {
            var actuales = await FindAllAsync(e => e.EdicionGrupo.Id.Equals(edicionGrupo.Id));
            var borrar = edicionGrupo.Equipos.Count - numEquipos;
            var i = edicionGrupo.Equipos.Count - 1;
            var count = 0;
            while (count != borrar)
            {
                await DeleteAsync(actuales.Last().Id);
                i--;
                count++;
            }
        }
    }
}
