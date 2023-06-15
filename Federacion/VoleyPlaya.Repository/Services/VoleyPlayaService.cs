using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using Org.BouncyCastle.Utilities.Collections;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Markup;

using VoleyPlaya.Repository.Enums;
using VoleyPlaya.Repository.Models;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VoleyPlaya.Repository.Services
{
    public class VoleyPlayaService : IVoleyPlayaService
    {
        private IVoleyPlayaUnitOfWork _voleyPlayaUoW;
        public VoleyPlayaService(IVoleyPlayaUnitOfWork unitOfWork) => _voleyPlayaUoW= unitOfWork;

        public async Task<bool> DeleteEdicionAsync(string edicionName)
        {
            bool val = await _voleyPlayaUoW.EdicionRepository.Remove(edicionName);
            await _voleyPlayaUoW.SaveEntitiesAsync();
            return val;
        }
        public async Task<bool> DeleteEdicionAsync(int id)
        {
            // obtener la edición
            var edi = await _voleyPlayaUoW.EdicionRepository.GetFullEdicionAsync(id);
            if (edi == null) return true;
            foreach (var jor in edi.Jornadas)
                await _voleyPlayaUoW.JornadaRepository.DeleteAsync(jor.Id);
            foreach (var equi in edi.Equipos)
                await _voleyPlayaUoW.EquipoRepository.DeleteAsync(equi.Id);
            foreach (var grupo in edi.Grupos)
                await DeleteGrupoWithPartidos(grupo.Id);

            bool res = await _voleyPlayaUoW.EdicionRepository.Remove(id);
            await _voleyPlayaUoW.SaveEntitiesAsync();
            return res;
        }
        public async Task<List<Edicion>> GetAllEdicionesAsync()
        {
            var dto = await _voleyPlayaUoW.EdicionRepository.GetFullAsync();
            return dto.OrderByDescending(c=>c.CreatedDate).ToList();
        }

        public async Task<Edicion> GetEdicionAsync(string edicionName) => await _voleyPlayaUoW.EdicionRepository.GetFullEdicionAsync(edicionName);
        public async Task<Edicion> GetEdicionAsync(int id) => await _voleyPlayaUoW.EdicionRepository.GetFullEdicionAsync(id);
        public async Task<Edicion> GetEdicionByIdAsync(int id) => await _voleyPlayaUoW.EdicionRepository.GetFullEdicionAsync(id);
        public async Task<Edicion> GetBasicEdicionAsync(int id) => await _voleyPlayaUoW.EdicionRepository.GetBasicAsync(id);
        public Edicion GetEdicion(string edicionName) => _voleyPlayaUoW.EdicionRepository.GetByName(edicionName);
        public async Task<bool> UpdateDatosPartidosAsync(EdicionGrupo grupo)
        {
            EdicionGrupo edicionGrupoDto = await _voleyPlayaUoW.EdicionGrupoRepository.GetWithEquiposYPartidosAsync(grupo.Id);
            if (edicionGrupoDto != null)
            {
                var partidos = grupo.Partidos;
                await UpdateDatosPartidosGrupo(edicionGrupoDto, partidos);
            }
            return true;
        }

        public async Task<EdicionGrupo> UpdateResultadosPartidosAsync(IEnumerable<Partido> partidos)
        {
            int grupoId = await UpdateResultadoPartidos(partidos); 
            await _voleyPlayaUoW.SaveEntitiesAsync();

            var grupoDto = await _voleyPlayaUoW.EdicionGrupoRepository.FindIncludingAsync(g => g.Id.Equals(grupoId), g => g.Equipos, g => g.Partidos);
            return grupoDto;
        }
        private async Task<int> UpdateResultadoPartidos(IEnumerable<Partido> partidos)
        {
            int grupoId = 0;
            var user = _voleyPlayaUoW.GetCurrentUser();
            foreach (var partido in partidos)
            {
                var partidoDto = await _voleyPlayaUoW.PartidoRepository.FindIncludingAsync(p => p.Id.Equals(partido.Id), p => p.Grupo);
                if (partidoDto == null) continue;

                grupoId = partidoDto.Grupo.Id;
                var set1 = partido.Parciales.First();
                var set2 = partido.Parciales.Skip(1).First();
                var set3 = partido.Parciales.Last();
                partidoDto!.AddResultado(partido.ResultadoLocal.GetValueOrDefault(0), partido.ResultadoVisitante.GetValueOrDefault(0), 
                    set1.ResultadoLocal.GetValueOrDefault(0), set1.ResultadoVisitante.GetValueOrDefault(0), 
                    set2.ResultadoLocal.GetValueOrDefault(0), set2.ResultadoVisitante.GetValueOrDefault(0), 
                    set3.ResultadoLocal.GetValueOrDefault(0), set3.ResultadoVisitante.GetValueOrDefault(0), user);
            }
            return grupoId;
        }
        public static string GetNombreEdicion(string temporada, string prueba, string competicion, string categoria, string genero)
        {
            return temporada + "_" + prueba + "_" + competicion + "_" + categoria + "_" + genero;
        }
        public static string GetGroupName(int groupNumber)
        {
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int alphabetLength = alphabet.Length;
            int index = groupNumber - 1;
            int firstLetterIndex = index / alphabetLength;
            int secondLetterIndex = index % alphabetLength;
            string groupName = "";

            if (firstLetterIndex > 0)
            {
                groupName += alphabet[firstLetterIndex - 1];
            }

            groupName += alphabet[secondLetterIndex];

            return groupName;
        }
        public async Task<EdicionGrupo> GetGrupoAsync(int id) => await _voleyPlayaUoW.EdicionGrupoRepository.GetByIdAsync(id);
        public async Task<bool> UpdateEquiposAsync(int idGrupo, IEnumerable<Equipo> equipos)
        {
            var grupoDto = await _voleyPlayaUoW.EdicionGrupoRepository.GetByIdAsync(idGrupo);
            await UpdateListaEquipos(grupoDto, equipos);
            await _voleyPlayaUoW.SaveEntitiesAsync();
            return true;
        }
        public async Task<bool> DeleteGrupoAsync(int id)
        {
            await DeleteGrupoWithPartidos(id);
            return await _voleyPlayaUoW.SaveEntitiesAsync();
        }
        public async Task<bool> DeleteGrupoWithPartidos(int id)
        {
            var grupo = await _voleyPlayaUoW.EdicionGrupoRepository.GetWithPartidosAsync(id);
            if (grupo == null) return false;
            foreach (var par in grupo.Partidos)
                await _voleyPlayaUoW.PartidoRepository.DeleteAsync(par.Id);

            await _voleyPlayaUoW.EdicionGrupoRepository.DeleteAsync(id);
            return await _voleyPlayaUoW.SaveEntitiesAsync();
        }
        public async Task<string> DeleteEquipoAsync(int id)
        {
            bool deleted = await _voleyPlayaUoW.EquipoRepository.DeleteAsync(id);
            var str = (await _voleyPlayaUoW.SaveEntitiesAsync()) ? "": "Se ha producido un error al borrar el equipo. Revise si el equipo está incluido en algún partido";
            return str;
        }
        public async Task<string> DeletePartidoAsync(int partidoId)
        {
            await _voleyPlayaUoW.PartidoRepository.DeleteAsync(partidoId);
            await _voleyPlayaUoW.SaveEntitiesAsync();
            return "El partido ha sido borrado";
        }
        public async Task<bool> UpdateTipoCalendarioEdicionAsync(int id, string tipoCalendario)
        {
            var edicionDto = await _voleyPlayaUoW.EdicionRepository.GetByIdAsync(id);
            edicionDto.TipoCalendario = tipoCalendario;
            await _voleyPlayaUoW.EdicionRepository.UpdateAsync(edicionDto);
            return await _voleyPlayaUoW.SaveEntitiesAsync();
        }
        public async Task<string> GetTipoCalendarioEdicion(int id)
        {
            var edicionDto = await _voleyPlayaUoW.EdicionRepository.GetByIdAsync(id);
            return edicionDto?.TipoCalendario??"";
        }

        public async Task<string> GetModeloCompeticionAsync(int id)
        {
            var edicionDto = await _voleyPlayaUoW.EdicionRepository.GetByIdAsync(id);
            return edicionDto?.ModeloCompeticion ?? "";
        }
        public async Task<List<EdicionGrupo>> GetAllGruposAsync(int? edicionId)
        {
            var grupos = await _voleyPlayaUoW.EdicionGrupoRepository.FindAllAsync(g => g.EdicionId.Equals(edicionId));
            return grupos.ToList();
        }
        public async Task<List<PartidoVis>> GetPartidosFiltradosAsync(int edicionSelected, int grupoSelected)
        {
            if (grupoSelected != 0)
            {
                var partidosG = await _voleyPlayaUoW.PartidoRepository.FindAllIncludingAsync(p=>p.Grupo.Id.Equals(grupoSelected),
                    p=>p.Grupo, p=>p.Grupo.Edicion, p=>p.Grupo.Edicion.Competicion, p=>p.Grupo.Edicion.Categoria);
                var part = partidosG.Select(p => new PartidoVis(p)).ToList();
                return part;// json;
            }
            var partidos = await _voleyPlayaUoW.PartidoRepository.FindAllIncludingAsync(p=>p.Grupo.Edicion.Id.Equals(edicionSelected),
                                    p => p.Grupo, p => p.Grupo.Edicion, p => p.Grupo.Edicion.Competicion, p => p.Grupo.Edicion.Categoria);

            var partis = partidos.Select(p => new PartidoVis(p)).ToList();
            return partis;
        }
        public async Task<Edicion> GetBasicAsync(int id)
        {
            var edicion = await _voleyPlayaUoW.EdicionRepository.GetBasicAsync(id);
            return edicion;  
        }
        public async Task<EdicionGrupo> GetBasicGrupoAsync(int id)
        {
            var grupo = await _voleyPlayaUoW.EdicionGrupoRepository.GetBasicAsync(id);
            return grupo;
        }
        public async Task<EdicionGrupo> GetGrupoWithEquiposYPartidosAsync(int grupoId)
        {
            var grupo = await _voleyPlayaUoW.EdicionGrupoRepository.GetWithEquiposYPartidosAsync(grupoId);
            return grupo; 
        }
        public async Task<bool> AddEquipo(int edicionId, string equipo)
        {
            var edicion = await _voleyPlayaUoW.EdicionRepository.GetBasicAsync(edicionId);
            await _voleyPlayaUoW.EquipoRepository.CheckAddUpdate(edicion, 0, 0, equipo, 0, 0, 0, 0, 0, 0, 0,0);
            return await _voleyPlayaUoW.SaveEntitiesAsync();
        }
        public async Task<IList<(int id, string nombre)>> GetAllCompeticionesAsync(string idPrueba)
        {
            var dtos = await _voleyPlayaUoW.EdicionRepository.FindAllIncludingAsync(e => e.Prueba.Equals(idPrueba), e => e.Competicion);
            var competiciones = dtos.Select(e => new { Id = e.Competicion.Id, Nombre = e.Competicion.Nombre }).ToList();
            var comp = competiciones.Distinct();
            return comp.Select(c => (c.Id, c.Nombre)).ToList();
        }
        public async Task<IList<(int id, string nombre)>> GetAllCategoriasByEdicionAsync(string idPrueba, int idCompeticion)
        {
            var ediciones = await _voleyPlayaUoW.EdicionRepository.FindAllIncludingAsync(e => e.Prueba.Equals(idPrueba) && e.Competicion.Id.Equals(idCompeticion), e => e.Categoria);
            var categorias = ediciones.Select(e => new { Id = e.Categoria.Id, Nombre = e.Categoria.Nombre }).ToList();
            var cat = categorias.Distinct();
            return cat.Select(c => (c.Id, c.Nombre)).ToList();
        }
        public async Task<IList<(string id, string nombre)>> GetAllGenerosAsync(string idPrueba, int idCompeticion, int idCategoria)
        {
            var ediciones = await _voleyPlayaUoW.EdicionRepository.FindAllAsync(e => e.Prueba.Equals(idPrueba) && e.Competicion.Id.Equals(idCompeticion) && e.Categoria.Id.Equals(idCategoria));
            var generos = ediciones.Select(e => new { Id = e.Genero, Nombre = e.Genero }).ToList();
            return generos.Select(g => (g.Id, g.Nombre)).ToList();
        }

        public async Task<IList<(int id, string nombre)>> GetAllGruposAsync(string idPrueba, int idCompeticion, int idCategoria, string genero)
        {
            var ediciones = await _voleyPlayaUoW.EdicionRepository.FindAllIncludingAsync(e => e.Prueba.Equals(idPrueba) && e.Competicion.Id.Equals(idCompeticion) && e.Categoria.Id.Equals(idCategoria) && e.Genero.Equals(genero), e => e.Grupos);
            var grupos = ediciones.SelectMany(e => e.Grupos).Select(g => new { Id = g.Id, Nombre = g.Nombre }).ToList();
            return grupos.Select(g => (g.Id, g.Nombre)).ToList();
        }
        public async Task<List<EdicionGrupo>> GetClasificacionesAsync(string prueba, int competicionSelected, int categoriaSelected, string generoSelected, string grupoSelected)
        {
            var grupos = await _voleyPlayaUoW.EdicionGrupoRepository.GetWithEquiposAsync(prueba, competicionSelected, categoriaSelected, generoSelected, grupoSelected);
            return grupos;
        }
        public async Task<EdicionGrupo> RetirarEquipoAsync(int id)
        {
            var equipo = await _voleyPlayaUoW.EquipoRepository.GetByIdAsync(id);
            equipo.Retirado = true;
            await _voleyPlayaUoW.EquipoRepository.UpdateAsync(equipo);
            // buscar todos los partidos donde jugo este equipo y dejar el resultado como 0-0
            var partidos = await _voleyPlayaUoW.PartidoRepository.FindAllAsync(p => p.Local.Id.Equals(id) || p.Visitante.Id.Equals(id));
            foreach (var partido in partidos)
            {
                bool retiLocal = partido.Local.Id.Equals(id) ? true : false;
                partido.ResultadoLocal = retiLocal ? 0 : 1;
                partido.ResultadoVisitante = retiLocal ? 1 : 0;
                foreach (var parcial in partido.Parciales)
                {
                    var resPar = await _voleyPlayaUoW.ParcialPartidoRepository.GetByIdAsync(parcial.Id);
                    if (parcial.Nombre.Equals("Set1"))
                    {
                        resPar.ResultadoLocal = retiLocal ? 0 : 21;
                        resPar.ResultadoVisitante = retiLocal ? 21 : 0;
                    }
                    else
                    { resPar.ResultadoLocal = resPar.ResultadoVisitante = 0; }
                    await _voleyPlayaUoW.ParcialPartidoRepository.UpdateAsync(resPar);
                }
                await _voleyPlayaUoW.PartidoRepository.UpdateAsync(partido);
            }
            // actualizar la clasificacion (desde dominio)
            await _voleyPlayaUoW.SaveEntitiesAsync();
            var grupo = await _voleyPlayaUoW.EdicionGrupoRepository.FindIncludingAsync(e => e.Id.Equals(equipo.EdicionGrupoId.Value), e => e.Equipos, e => e.Partidos);
            return grupo;
        }
        public async Task<List<Partido>> GetPartidosAsync(string pruebaSelected, int competicionSelected, int categoriaSelected, string generoSelected, int grupoSelected)
        {
            var partidos = await _voleyPlayaUoW.PartidoRepository.GetListaPartidosAsync(pruebaSelected, competicionSelected, categoriaSelected, generoSelected, grupoSelected);
            return partidos;
        }
        public async Task<int> GetEdicionByIdAsync(string prueba, int competicion, int categoria, string genero)
        {
            var edicion = await _voleyPlayaUoW.EdicionRepository.FindAsync(e => e.Prueba.Equals(prueba) && e.Competicion.Id.Equals(competicion)
                                && e.Categoria.Id.Equals(categoria) && e.Genero.Equals(genero));
            return edicion.Id;
        }
        public async Task<string> UpdatePartidosFromExcelAsync(List<Partido> lista)
        {
            foreach(var partido in lista)
            {
                await _voleyPlayaUoW.PartidoRepository.UpdateHoraYPista(partido);
            }
            var msg = "Partidos actualizados";
            await _voleyPlayaUoW.SaveEntitiesAsync();
            return msg;
        }
        public async Task<List<EdicionGrupo>> GetAllGruposFiltradosAsync(string prueba, int idCompeticion, int idCategoria, string genero)
        {
            var edi = await _voleyPlayaUoW.EdicionRepository.FindAsync(e => e.Prueba.Equals(prueba) && e.Competicion.Id.Equals(idCompeticion) && e.Categoria.Id.Equals(idCategoria) && e.Genero.Equals(genero));
            if (edi != null)
            {
                var edicion = await _voleyPlayaUoW.EdicionRepository.GetFullEdicionAsync(edi.Id);
                var grupos = edicion.Grupos.ToList();
                return grupos;
            }
            return null;
        }
        public async Task<bool> SaveTablaCalendarios(List<TablaCalendario> partidos)
        {
            foreach (var partido in partidos)
            {
                try
                {
                    var par = await _voleyPlayaUoW.TablaCalendarioRepository.FindAsync(p => p.Nombre.Equals(partido.Nombre));
                    if (par == null)
                        await _voleyPlayaUoW.TablaCalendarioRepository.CreateAsync(partido);
                    else
                    {
                        par.Equipo1 = partido.Equipo1;
                        par.Equipo2 = partido.Equipo2;
                        par.Jornada = partido.Jornada;
                        par.Ronda = partido.Ronda;
                        par.NumPartido = partido.NumPartido;
                        await _voleyPlayaUoW.TablaCalendarioRepository.UpdateAsync(partido);
                    }
                }
                catch (Exception x)
                { }
            }
            return await _voleyPlayaUoW.SaveEntitiesAsync();
        }
        public async Task<List<TablaCalendario>> GetCalendarioPartidosCircuito(int numEquipos)
        {
            var partidos = await _voleyPlayaUoW.TablaCalendarioRepository.FindAllAsync(t => t.NumEquipos == numEquipos);
            return partidos.ToList();
        }
        public async Task<List<TablaCalendario>> GetCalendarioPartidosCircuitoByNumGrupos(int numGrupos)
        {
            var partidos = await _voleyPlayaUoW.TablaCalendarioRepository.FindAllAsync(t => t.NumEquipos == -1 && t.NumGrupos==numGrupos);
            return partidos.ToList();
        }
        public async Task<bool> AddUpdateGrupoYPartidosFaseFinalAsync(int edicionId, EdicionGrupo grupo)
        {
            var edicionDto = await _voleyPlayaUoW.EdicionRepository.GetByIdAsync(edicionId);
            if (edicionDto == null) return false;
            var grupoDto = await _voleyPlayaUoW.EdicionGrupoRepository.CheckAddUpdate(edicionDto, grupo.Nombre, grupo.Tipo);
            await _voleyPlayaUoW.SaveEntitiesAsync();

            await UpdateListaEquipos(grupoDto, grupo.Equipos);
            await UpdateGrupoPartidosAsync(grupo);

            await _voleyPlayaUoW.SaveEntitiesAsync();
            return true;
        }
        public async Task<Edicion> GetEdicion(string pruebaId, int? competicionId, int? categoriaId, string generoId)
        {
            if (pruebaId ==null|| pruebaId.Equals("0") || competicionId == null || categoriaId == null || string.IsNullOrEmpty(generoId) || generoId.Equals("0"))
                return null;
            var edicion = await _voleyPlayaUoW.EdicionRepository.FindAsync(e => e.Prueba.Equals(pruebaId) && e.Competicion.Id.Equals(competicionId)
                            && e.Categoria.Id.Equals(categoriaId) && e.Genero.Equals(generoId));
            return edicion;
        }
        public async Task<string> ValidarPartidoAsync(int idPartido, bool activo, int set1L, int set1V, int set2L, int set2V, int set3L, int set3V)
        {
            var partido = await _voleyPlayaUoW.PartidoRepository.GetByIdAsync(idPartido);
            partido.Validado = activo;
            var local = 0;
            var visi = 0;
            local += set1L != 0 && set1L > set1V ? 1 : 0;
            local += set2L != 0 && set2L > set2V ? 1 : 0;
            local += set3L != 0 && set3L > set3V ? 1 : 0;
            visi += set1V != 0 && set1L < set1V ? 1 : 0;
            visi += set2V != 0 && set2L < set2V ? 1 : 0;
            visi += set3V != 0 && set3L < set3V ? 1 : 0;

            partido.AddResultado(local, visi, set1L, set1V, set2L, set2V, set3L, set3V, _voleyPlayaUoW.GetCurrentUser());
            partido.UserValidador = _voleyPlayaUoW.GetCurrentUser();
            await _voleyPlayaUoW.SaveEntitiesAsync();
            return "Partido validado";
        }
        public async Task ArreglarGruposEquipos()
        {
            var ediciones = await _voleyPlayaUoW.EdicionRepository.GetAllIncludingAsync(e => e.Equipos);
            foreach (var edicion in ediciones)
            {
                foreach (var equipo in edicion.Equipos)
                {
                    var idGrupo = equipo.EdicionGrupoId ?? equipo.EdicionGrupoId.Value;
                    if (idGrupo != 0)
                    {
                        var ediGrupo = await _voleyPlayaUoW.EdicionGrupoRepository.GetByIdAsync(idGrupo);
                        equipo.Grupos.Add(ediGrupo);
                    }
                }
            }
            await _voleyPlayaUoW.SaveEntitiesAsync();
        }
        public async Task<string> ActualizarClasificacionFinal(int edicionId, List<Equipo> equipos)
        {
            string str = "";
            foreach(var equipo in equipos)
            {
                str += await _voleyPlayaUoW.EquipoRepository.UpdateClasificacionFinal(edicionId, equipo.Id, equipo.ClasificacionFinal);
            }
            await _voleyPlayaUoW.SaveEntitiesAsync();
            return str;
        }
        public async Task<IList<(int id, string nombre)>> GetListaPruebasAsync()
        {
            List<(int id, string nombre)> pruebas = new List<(int id, string nombre)>();
            var dtos = await _voleyPlayaUoW.EdicionRepository.GetAllPruebasAsync();
            pruebas = dtos.Select(d => (d.Id, d.Prueba)).ToList();
            return pruebas;
        }
        public async Task<string> ActualizarPistaGrupo(int id, string pistaGrupo, bool sobreescribirPistasGrupo)
        {
            var grupo = await _voleyPlayaUoW.EdicionGrupoRepository.FindIncludingAsync(g => g.Id.Equals(id), g => g.Partidos);
            foreach (var partido in grupo.Partidos)
            {
                if (string.IsNullOrEmpty(partido.Pista) || (!string.IsNullOrEmpty(partido.Pista) && sobreescribirPistasGrupo))
                {
                    partido.Pista = pistaGrupo;
                    await _voleyPlayaUoW.PartidoRepository.UpdateAsync(partido);
                }
            }
            await _voleyPlayaUoW.SaveEntitiesAsync();
            return "Pistas actualizadas";
        }
        public async Task CambiarEstadoEdicion(int idEdicion, string nuevoEstado)
        {
            var edicion = await _voleyPlayaUoW.EdicionRepository.GetByIdAsync(idEdicion);
            edicion.Estado = Enum.Parse<EnumEstadoEdicion>(nuevoEstado);
            await _voleyPlayaUoW.EdicionRepository.UpdateAsync(edicion);
            await _voleyPlayaUoW.SaveEntitiesAsync();
        }
        public async Task<bool> UpdateEdicionGenericoAsync(Edicion edi, string temporadaStr, string competicionStr, string categoriaStr)
        {
            var temporada = await SaveTemporadaAsync(temporadaStr ?? "");
            var competicion = await SaveCompeticionAsync(competicionStr ?? "");
            var categoria = await SaveCategoriaAsync(categoriaStr ?? "");
            await _voleyPlayaUoW.EdicionRepository.CheckAddUpdate(temporada, competicion, categoria, edi.Genero, edi.TipoCalendario ?? "", edi.Prueba, edi.ModeloCompeticion ?? "");
            await _voleyPlayaUoW.SaveEntitiesAsync();
            return true;
        }
        private async Task<Temporada> SaveTemporadaAsync(string temporada) => await _voleyPlayaUoW.TemporadaRepository.CheckAddUpdate(temporada);
        private async Task<Competicion> SaveCompeticionAsync(string competicion) => await _voleyPlayaUoW.CompeticionRepository.CheckAddUpdate(competicion);
        private async Task<Categoria> SaveCategoriaAsync(string categoria) => await _voleyPlayaUoW.CategoriaRepository.CheckAddUpdate(categoria);
        public async Task<bool> UpdateEquiposEdicionAsync(int edicionId, List<Equipo> equiposToAdd, List<Equipo> equiposToRemove)
        {
            var edicion = await _voleyPlayaUoW.EdicionRepository.FindIncludingAsync(e=>e.Id.Equals(edicionId), e=>e.Equipos);
            foreach(var equipo in equiposToAdd)
                await _voleyPlayaUoW.EquipoRepository.CheckAddUpdate(edicion, equipo.Id, equipo.OrdenCalendario, equipo.Nombre, equipo.Jugados, equipo.Ganados, equipo.Perdidos, equipo.PuntosFavor, 
                    equipo.PuntosContra, equipo.Coeficiente, equipo.Puntos, equipo.OrdenEntrada);
            foreach (var equipo in equiposToRemove)
                await _voleyPlayaUoW.EquipoRepository.DeleteAsync(equipo.Id);
            await _voleyPlayaUoW.SaveEntitiesAsync();

            return true;
        }
        public async Task<bool> UpdateGruposAsync(int id, HashSet<EdicionGrupo> grupos)
        {
            var edicion = await _voleyPlayaUoW.EdicionRepository.FindIncludingAsync(e => e.Id.Equals(id), e => e.Grupos, e => e.Equipos);

            // almaceno grupos
            foreach (var grupo in grupos)
            {
                var grupoDto = await _voleyPlayaUoW.EdicionGrupoRepository.CheckAddUpdate(edicion, grupo.Nombre, grupo.Tipo);
                if (grupo.Equipos == null) continue;
                foreach(var equipo in grupo.Equipos)
                {
                    var equipoDto = await _voleyPlayaUoW.EquipoRepository.GetByIdAsync(equipo.Id);
                    if (equipoDto == null) continue;
                    if (equipoDto.Grupos == null) equipoDto.Grupos = new HashSet<EdicionGrupo>();
                    Debug.Assert(equipoDto.Grupos != null);
                    equipoDto.Grupos.Add(grupoDto);
                    equipoDto.OrdenCalendario = equipo.OrdenCalendario;
                    await _voleyPlayaUoW.EquipoRepository.UpdateAsync(equipoDto);
                }
            }
            await _voleyPlayaUoW.SaveEntitiesAsync();

            return true;
        }
        public async Task<bool> UpdateJornadasAsync(int id, HashSet<Jornada> jornadas)
        {
            var edicionDto = await _voleyPlayaUoW.EdicionRepository.GetByIdAsync(id);
            foreach (var jornada in jornadas)
            {
                var jornadaDto = await _voleyPlayaUoW.JornadaRepository.CheckAddUpdate(edicionDto, jornada.Numero, jornada.Fecha, jornada.Nombre);
            }
            await _voleyPlayaUoW.SaveEntitiesAsync();
            return true;
        }
        public async Task<bool> UpdatePosicionEquiposAsync(List<Equipo> equipos, int grupoId)
        {
            var grupo = await _voleyPlayaUoW.EdicionGrupoRepository.FindIncludingAsync(g => g.Id.Equals(grupoId), g => g.Equipos);
            foreach(var equipo in equipos)
            {
                var dto = grupo.Equipos.FirstOrDefault(e => e.Id.Equals(equipo.Id));
                if (dto == null) return false;
                dto.OrdenCalendario = equipo.OrdenCalendario;
                await _voleyPlayaUoW.EquipoRepository.UpdateAsync(dto);
            }
            await _voleyPlayaUoW.SaveEntitiesAsync();
            return true;
        }
        public async Task<bool> UpdateEquiposEdicionAsync(int edicionId, List<Equipo> equipos)
        {
            var edicion = await _voleyPlayaUoW.EdicionRepository.GetByIdAsync(edicionId);
            await UpdateListaEquipos(edicion, equipos);
            await _voleyPlayaUoW.SaveEntitiesAsync();
            return true;
        }
        private async Task UpdateListaEquipos(Edicion edicion, IEnumerable<Equipo> equipos)
        { 
            foreach (var equipo in equipos)
            {
                await _voleyPlayaUoW.EquipoRepository.CheckAddUpdate(edicion, equipo.Id, equipo.OrdenCalendario, equipo.Nombre, equipo.Jugados, equipo.Ganados, equipo.Perdidos, equipo.PuntosFavor,
                        equipo.PuntosContra, equipo.Coeficiente, equipo.Puntos, equipo.OrdenEntrada);
            }
        }
        private async Task UpdateListaEquipos(EdicionGrupo grupo, IEnumerable<Equipo> equipos)
        {
            foreach (var equipo in equipos)
            {
                var dto = await _voleyPlayaUoW.EquipoRepository.CheckAddUpdate(grupo, equipo.Id, equipo.OrdenCalendario, equipo.Nombre, equipo.Jugados, equipo.Ganados, equipo.Perdidos, equipo.PuntosFavor,
                        equipo.PuntosContra, equipo.Coeficiente, equipo.Puntos, equipo.OrdenEntrada, equipo.ClasificacionFinal);
                grupo.Equipos.Add(dto);
            }
        }
        public async Task<bool> UpdateGrupoPartidosAsync(EdicionGrupo grupo)
        {
            var gr = await _voleyPlayaUoW.EdicionGrupoRepository.GetByIdAsync(grupo.Id);
            return await UpdateDatosPartidosGrupo(gr, grupo.Partidos);
        }
        private async Task<bool> UpdateDatosPartidosGrupo(EdicionGrupo gr, IEnumerable<Partido> partidos)
        { 
            foreach (var partido in partidos)
            {
                var local = await _voleyPlayaUoW.EquipoRepository.GetByIdAsync(partido.Local.Id);
                var visitante = await _voleyPlayaUoW.EquipoRepository.GetByIdAsync(partido.Visitante.Id);

                var partidoDto = await _voleyPlayaUoW.PartidoRepository.CheckAddUpdate(gr, local, visitante, partido.Id, partido.Jornada ?? 0, partido.NumPartido ?? 0, partido.FechaHora ?? DateTime.Now,
                    partido.Pista ?? "", partido.Label ?? "", partido.Validado, partido.NombreLocal ?? "", partido.NombreVisitante ?? "", partido.Ronda??"");

                partidoDto!.AddResultado(partido.ResultadoLocal.GetValueOrDefault(0), partido.ResultadoVisitante.GetValueOrDefault(0), 
                    partido.Parciales.First().ResultadoLocal.GetValueOrDefault(0),
                    partido.Parciales.First().ResultadoVisitante.GetValueOrDefault(0),
                    partido.Parciales.Skip(1).First().ResultadoLocal.GetValueOrDefault(0),
                    partido.Parciales.Skip(1).First().ResultadoVisitante.GetValueOrDefault(0),
                    partido.Parciales.Last().ResultadoLocal.GetValueOrDefault(0),
                    partido.Parciales.Last().ResultadoVisitante.GetValueOrDefault(0),
                    _voleyPlayaUoW.GetCurrentUser());


            }
            await _voleyPlayaUoW.SaveEntitiesAsync();

            return true;
        }
        public async Task<string> ConfirmarResultadoAsync(int idPartido, bool activo, int set1L, int set1V, int set2L, int set2V, int set3L, int set3V)
        {
            var partido = await _voleyPlayaUoW.PartidoRepository.GetByIdAsync(idPartido);
            var local = 0;
            var visi = 0;
            local += set1L != 0 && set1L > set1V ? 1 : 0;
            local += set2L != 0 && set2L > set2V ? 1 : 0;
            local += set3L != 0 && set3L > set3V ? 1 : 0;
            visi += set1V != 0 && set1L < set1V ? 1 : 0;
            visi += set2V != 0 && set2L < set2V ? 1 : 0;
            visi += set3V != 0 && set3L < set3V ? 1 : 0;
            partido.ConResultado = activo;

            partido.AddResultado(local, visi, set1L, set1V, set2L, set2V, set3L, set3V, _voleyPlayaUoW.GetCurrentUser());
            partido.UserResultado = _voleyPlayaUoW.GetCurrentUser();
            await _voleyPlayaUoW.SaveEntitiesAsync();
            return "Confirmado resultado del partido "+partido.Label;
        }
    }
}
