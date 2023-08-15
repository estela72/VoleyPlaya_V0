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
        Task<Equipo> CheckAddUpdate(EdicionGrupo edicionGrupoDto, int idEquipo, int? posicion, string nombre, int? jugados, int? ganados, int? perdidos,
            int? puntosFavor, int? puntosContra, double? coeficiente, int? puntos, int? ordenEntrada, int clasifinal);
        Task CheckAddUpdate(Edicion edicionDto, int idEquipo, int? posicion, string nombre, int? jugados, int? ganados, int? perdidos,
            int? puntosFavor, int? puntosContra, double? coeficiente, int? puntos, int? ordenEntrada);
        Task RemoveEquipos(int numEquipos, EdicionGrupo edicionGrupo);
        Task<string> UpdateClasificacionFinal(int edicionId, int equipoId, int clasificacionFinal);
    }
    public class EquipoRepository : Repository<Equipo>, IEquipoRepository
    {
        public EquipoRepository(VoleyPlayaDbContext context) : base(context)
        {
        }

        public EquipoRepository(VoleyPlayaDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<Equipo> CheckAddUpdate(EdicionGrupo edicionGrupoDto, int idEquipo, int? posicion, string nombre, int? jugados, int? ganados, int? perdidos, 
            int? puntosFavor, int? puntosContra, double? coeficiente, int? puntos, int? ordenEntrada, int clasifinal)
        {
            if (nombre.Equals(string.Empty)) return null;
            Equipo dto = null;
            if (idEquipo != 0)
                dto = await GetByIdAsync(idEquipo);

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
                    Retirado=false,
                    OrdenEntrada = ordenEntrada,
                    ClasificacionFinal = clasifinal
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
                //dto.Edicion = edicionGrupoDto.Edicion;
                dto.OrdenEntrada = ordenEntrada;
                dto.ClasificacionFinal = clasifinal;
                return await UpdateAsync(dto);
            }
        }

        public async Task CheckAddUpdate(Edicion edicionDto, int idEquipo, int? posicion, string nombre, int? jugados, int? ganados, int? perdidos,
            int? puntosFavor, int? puntosContra, double? coeficiente, int? puntos, int? ordenEntrada)
        {
            if (string.IsNullOrEmpty(nombre)) return;
            Equipo dto = null;
            if (idEquipo != 0)
                dto = await GetByIdAsync(idEquipo);

            if (dto == null)
                await AddAsyn(new Equipo
                {
                    Nombre = nombre.Trim(),
                    Perdidos = perdidos,
                    Coeficiente = coeficiente,
                    Ganados = ganados,
                    Jugados = jugados,
                    Puntos = puntos,
                    PuntosContra = puntosContra,
                    PuntosFavor = puntosFavor,
                    OrdenCalendario = posicion,
                    Edicion = edicionDto,
                    OrdenEntrada = ordenEntrada
                });
            else
            {
                dto.Nombre = nombre.Trim();
                dto.Perdidos = perdidos;
                dto.Coeficiente = coeficiente;
                dto.Ganados = ganados;
                dto.Jugados = jugados;
                dto.Puntos = puntos;
                dto.PuntosContra = puntosContra;
                dto.PuntosFavor = puntosFavor;
                dto.OrdenCalendario = posicion;
                dto.OrdenEntrada = ordenEntrada;
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

        public async Task<string> UpdateClasificacionFinal(int edicionId, int equipoId, int clasificacionFinal)
        {
            var equipo = await GetByIdAsync(equipoId);
            if (equipo == null) return "El equipo no existe";

            var existeclasi = await FindAllAsync(e => e.Edicion.Id.Equals(edicionId) && e.ClasificacionFinal.Equals(clasificacionFinal));
            if (existeclasi != null && existeclasi.Count>0 && clasificacionFinal!=0) return "Ya existe algún equipo con la clasificación "+clasificacionFinal+"\n";
            if (existeclasi != null && existeclasi.Count > 0) return "\n";

            equipo.ClasificacionFinal = clasificacionFinal;
            await UpdateAsync(equipo);
            return "Clasificación actualizada\n";
        }
    }
}
