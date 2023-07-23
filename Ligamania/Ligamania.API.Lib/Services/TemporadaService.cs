using AutoMapper;

using Azure;

using Ligamania.API.Lib.Models;
using Ligamania.Generic.Lib.Enums;
using Ligamania.Repository;
using Ligamania.Repository.Models;

using MailKit;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ligamania.API.Lib.Services
{
    public interface ITemporadaService
    {
        Task<IEnumerable<Temporada>> GetAllTemporadas();
        Task<byte[]> GetClasificacionById(int id);
        Task<Temporada> GetTemporadaById(int id);
        Task<Temporada> DeleteTemporadaById(int id);
        Task<Temporada> UpdateTemporada(int id, Temporada temporada);
        Task<Temporada> CreateTemporada(Temporada temp);
        Task<IEnumerable<Competicion>> GetCompeticiones(int idTemporada);
        Task<IEnumerable<Categoria>> GetCategorias(int idTemporada, int idCompeticion);
        Task<IEnumerable<Club>> GetAllClubs();
        Task<string> UpdateClubs(List<Club> listClubs);
        Task<IEnumerable<Jugador>> GetAllJugadores();
        Task<string> UpdateJugadores(List<Jugador> listJugadores);
        Task<string> CopiarJugadoresTemporada(string temporada);
        Task<string> CrearJugadorTemporada(Jugador jug);
        Task<string> HistorificarById(int id);
        Task<string> CambiarJugadorTemporada(Jugador jug);
    }
    internal class TemporadaService : ITemporadaService
    {
        private readonly IMapper _mapper;
        private readonly ILigamaniaUnitOfWork _ligamaniaUnitOfWork;

        public TemporadaService(ILigamaniaUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _ligamaniaUnitOfWork = unitOfWork;
        }

        public async Task<Temporada> CreateTemporada(Temporada temp)
        {
            var t = _mapper.Map<TemporadaDTO>(temp);
            var temporada = await _ligamaniaUnitOfWork.TemporadaRepository.CreateAsync(t);
            await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            return _mapper.Map<Temporada>(temporada);
        }

        public async Task<Temporada> DeleteTemporadaById(int id)
        {
            var deleted = await _ligamaniaUnitOfWork.TemporadaRepository.DeleteAsync(id);
            if (!deleted)
                return new Temporada("Se producido un error al borrar la temporada");
            await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            return new Temporada("Temporada eliminada");
        }

        public async Task<IEnumerable<Temporada>> GetAllTemporadas()
        {
            var temporadas = await _ligamaniaUnitOfWork.TemporadaRepository.GetAllAsync();
            return _mapper.Map<List<Temporada>>(temporadas);
        }

        public async Task<byte[]> GetClasificacionById(int id)
        {
            var image = await _ligamaniaUnitOfWork.TemporadaRepository.GetImg_Clasificacion(id);
            return image;
        }

        public async Task<IEnumerable<Competicion>> GetCompeticiones(int idTemporada)
        {
            var competiciones = await _ligamaniaUnitOfWork.TemporadaRepository.GetCompeticionesByTemporada(idTemporada);
            competiciones = _formatCompeticiones(competiciones);
            return _mapper.Map<List<Competicion>>(competiciones);
        }

        private static ICollection<TemporadaCompeticionDTO> _formatCompeticiones(ICollection<TemporadaCompeticionDTO> competiciones)
        {
            competiciones.ToList().ForEach(c =>
                 c.DescripcionEstado = c.GetEstadoOperacion()
                );
            return competiciones;
        }

        public async Task<Temporada> GetTemporadaById(int id)
        {
            var temp = await _ligamaniaUnitOfWork.TemporadaRepository.GetByIdAsync(id);
            return _mapper.Map<Temporada>(temp);
        }

        public async Task<Temporada> UpdateTemporada(int id, Temporada temporada)
        {
            var temp = _mapper.Map<TemporadaDTO>(temporada);
            var t = await _ligamaniaUnitOfWork.TemporadaRepository.UpdateAsync(temp);
            await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            return _mapper.Map<Temporada>(t);
        }

        public async Task<IEnumerable<Categoria>> GetCategorias(int idTemporada, int idCompeticion)
        {
            var categorias = await _ligamaniaUnitOfWork.TemporadaRepository.GetCategoriasByTemporadaAndCompeticion(idTemporada, idCompeticion);
            //categorias = _formatCategorias(categorias);
            return _mapper.Map<List<Categoria>>(categorias);
        }

        public async Task<IEnumerable<Club>> GetAllClubs()
        {
            var allClubs = await _ligamaniaUnitOfWork.ClubRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Club>>(allClubs);
            //var temporada = await GetTemporadaEnCurso();
            //if (temporada == null)
            //    return new List<Club>();
            //var allClubs = await _ligamaniaUnitOfWork.TemporadaRepository.GetAllClubs(temporada.Id);
            //return _mapper.Map<IEnumerable<Club>>(allClubs);
        }

        private async Task<TemporadaDTO> GetTemporadaEnCurso()
        {
            var ta = await _ligamaniaUnitOfWork.TemporadaRepository.GetActualAsync() ?? await _ligamaniaUnitOfWork.TemporadaRepository.GetPreTemporada();
            return ta;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listClubs"></param> Lista de clubs a dar de baja en la temporada
        /// <returns></returns>
        public async Task<string> UpdateClubs(List<Club> listClubs)
        {
            var response = string.Empty;
            foreach (var club in listClubs)
            {
                if (club.Baja)
                    await _ligamaniaUnitOfWork.ClubRepository.Baja(club.Alias);
                else
                    await _ligamaniaUnitOfWork.ClubRepository.Alta(club.Alias);
             };
            //var allClubs = await GetAllClubs();
            //foreach (var club in allClubs)
            //    if (listClubs.Select(c => c.Alias).Contains(club.Alias))
            //        await _ligamaniaUnitOfWork.ClubRepository.Baja(club.Alias);
            //    else
            //        await _ligamaniaUnitOfWork.ClubRepository.Alta(club.Alias);

            await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            response = "Clubs dados de baja correctamente";
            return response;
        }

        public async Task<IEnumerable<Jugador>> GetAllJugadores()
        {
            var temporada = await GetTemporadaEnCurso();
            if (temporada == null)
                return new List<Jugador>();
            var jugadores = await _ligamaniaUnitOfWork.TemporadaRepository.GetJugadoresByTemporada(temporada.Id);
            var jugRepo = await _ligamaniaUnitOfWork.JugadorRepository.GetAllAsync();
            var list1 = _mapper.Map<List<Jugador>>(jugadores);
            var list2 = _mapper.Map<List<Jugador>>(jugRepo);

            var list = list2;
            foreach(var jugA in list1)
            {
                var v = list.Find(j => j.Nombre.Equals(jugA.Nombre));
                list.Remove(v);
                list.Add(jugA);
            }

            return list;
        }

        public async Task<string> UpdateJugadores(List<Jugador> listJugadores)
        {
            var temporada = await GetTemporadaEnCurso();
            if (temporada == null)
                return "No hay temporada en curso";

            if (listJugadores.Count == 0)
                return "No hay jugadores para dar de alta";


            var clubDto = await _ligamaniaUnitOfWork.ClubRepository.GetByAliasAsync(listJugadores.First().Club);
            var puestoDto = await _ligamaniaUnitOfWork.PuestoRepository.GetByNameAsync(listJugadores.First().Puesto);
            foreach (var jug in listJugadores)
            {
                var jugadorDto = await _ligamaniaUnitOfWork.JugadorRepository.GetByNameAsync(jug.Nombre);
                var jugExiste = await ExisteJugadorTemporada(jugadorDto, temporada);
                if (jugExiste != null)
                    await _ligamaniaUnitOfWork.TemporadaJugadorRepository.Baja(jugExiste);

                if (jug.Activo)
                {
                    await _ligamaniaUnitOfWork.TemporadaJugadorRepository.Alta(jugadorDto, clubDto, puestoDto, temporada);
                    await _ligamaniaUnitOfWork.JugadorRepository.Alta(jugadorDto);
                }
                else
                {
                    await _ligamaniaUnitOfWork.JugadorRepository.Baja(jugadorDto);
                }
            }

            await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            string response = "Jugadores dados de alta correctamente";
            return response;
        }

        private async Task<TemporadaJugadorDTO> ExisteJugadorTemporada(JugadorDTO jugadorDto, TemporadaDTO temporada)
        {
            var existe = await _ligamaniaUnitOfWork.TemporadaJugadorRepository.ExistsAsync(tj => tj.Temporada_ID.Equals(temporada.Id) && tj.Jugador_ID.Equals(jugadorDto.Id));
            if (existe)
                return await _ligamaniaUnitOfWork.TemporadaJugadorRepository.FindAsync(tj => tj.Temporada_ID.Equals(temporada.Id) && tj.Jugador_ID.Equals(jugadorDto.Id));
            return null;
        }

        public async Task<string> CopiarJugadoresTemporada(string temporada)
        {
            var response = string.Empty;
            var temporadaActual = await GetTemporadaEnCurso();
            var jugadoresACopiar = await _ligamaniaUnitOfWork.TemporadaJugadorRepository
                .FindAllIncludingAsync(j => j.Temporada.Nombre.Equals(temporada) && j.Activo,
                j=>j.Jugador, j=>j.Club, j=>j.Puesto);
            jugadoresACopiar.ToList().ForEach(async j =>
            {
                var nuevoJug = new TemporadaJugadorDTO(j);
                nuevoJug.Temporada = temporadaActual;
                await _ligamaniaUnitOfWork.TemporadaJugadorRepository.AddAsyn(nuevoJug);
            });
            var njug = await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            response = njug + " Jugadores copiados";
            return response;
        }

        public async Task<string> CrearJugadorTemporada(Jugador jug)
        {
            string response;
            var temporada = await GetTemporadaEnCurso();
            //var jugador = _mapper.Map<TemporadaJugadorDTO>(jug);
            var jugadorExistente = await _ligamaniaUnitOfWork.JugadorRepository.GetByNameAsync(jug.Nombre);
            if (jugadorExistente != null)
            {
                return "Ya existe un jugador con el nombre " + jug.Nombre;
            }
            else
            {
                JugadorDTO jugador = new JugadorDTO { Baja = false, Nombre = jug.Nombre };
                var j = await _ligamaniaUnitOfWork.JugadorRepository.CreateAsync(jugador);

                var club = await _ligamaniaUnitOfWork.ClubRepository.GetByAliasAsync(jug.Club);
                var puesto = await _ligamaniaUnitOfWork.PuestoRepository.GetByNameAsync(jug.Puesto);
                var jt = new TemporadaJugadorDTO()
                {
                    Activo = true,
                    Club = club,
                    Puesto = puesto,
                    Jugador = jugador,
                    Eliminado = false,
                    LastJornadaEliminacion = null,
                    PreEliminado = false,
                    Temporada = temporada,
                    VecesEliminado = 0,
                    VecesPreEliminado = 0
                };
                jt = await _ligamaniaUnitOfWork.TemporadaJugadorRepository.AddAsyn(jt);
            }
            if (await _ligamaniaUnitOfWork.SaveEntitiesAsync() > 0)
                response = "Jugador " + jug.Nombre + " creado";
            else
                response = "Error al crear el jugador " + jug.Nombre;
            return response;
        }

        public async Task<string> HistorificarById(int id)
        {
            var temporada = await _ligamaniaUnitOfWork.TemporadaRepository.GetTemporadaHistorificarAsync(id);
            var competiciones = temporada.TemporadaCompeticion
                .DistinctBy(tc => tc.Id);
            // Necesitamos historificar todas las competiciones
            foreach (var comp in competiciones)
            {
                if (comp.Competicion.Tipo.Equals(TipoCompeticion.Supercopa))
                    continue;
                // obtener la última jornada
                var ultimaJornada = temporada.TemporadaCompeticionJornada
                    .DistinctBy(tcj=>tcj.Id)
                    .Where(tcj => tcj.CompeticionId.Equals(comp.CompeticionId))
                    .OrderBy(tcj => tcj.Fecha).Last();
                
                var categorias = temporada.TemporadaCompeticionCategoria
                    .DistinctBy(tcc=>tcc.Id)
                    .Where(tcc => tcc.CompeticionId.Equals(comp.CompeticionId))
                    ;
                foreach (var cat in categorias)
                {
                    // obtener las clasificaciones de los equipos en la categoría
                    var clasificaciones = ultimaJornada.TemporadaClasificacion
                        .DistinctBy(tc => tc.Id)
                        .Where(tc => tc.CategoriaId.Equals(cat.CategoriaId))
                        .ToList();

                    // no sé muy bien por qué, pero las clasificaciones no tienen puesto, así que antes de nada, calculo el puesto
                    await CalcularPuestoClasificacion(clasificaciones, temporada);

                    TemporadaClasificacionDTO pichichi = null;
                    // si es la Liga, obtener pichichi
                    if (comp.Competicion.Tipo.Equals(TipoCompeticion.Liga))
                    {
                        pichichi = clasificaciones
                            .Where(c=>!c.Equipo.EsBot)
                            .Where(c => c.Puesto > 3)
                            .OrderByDescending(c => c.GolesFavor)
                            .FirstOrDefault();
                    }

                    // para cada equipo, actualizar su historia
                    foreach(var clasificacion in clasificaciones)
                    {
                        var tempEquipo = temporada.TemporadaEquipo
                            .DistinctBy(te=>te.Id)
                            .Where(te => te.EquipoId.Equals(clasificacion.EquipoId))
                            .FirstOrDefault();
                        var historico = new HistoricoDTO
                        {
                            Temporada = temporada,
                            TemporadaCompeticionCategoria = cat,
                            TemporadaEquipo = tempEquipo,
                            Puesto = clasificacion.Puesto,
                            Pichichi = pichichi != null && pichichi.Equals(tempEquipo) ? true : false
                        };
                        var existe = await _ligamaniaUnitOfWork.HistoricoRepository.ExistsAsync(h=>h.Temporada_ID.Equals(historico.Temporada.Id)
                            && h.Categoria_ID.Equals(historico.TemporadaCompeticionCategoria.Id) 
                            && h.Equipo_ID.Equals(historico.TemporadaEquipo.Id)
                            && h.Puesto.Equals(historico.Puesto));
                        if (!existe)
                            await _ligamaniaUnitOfWork.HistoricoRepository.AddAsyn(historico);
                        else
                            await _ligamaniaUnitOfWork.HistoricoRepository.UpdateAsync(historico);
                    }
                    //await _ligamaniaUnitOfWork.SaveEntitiesAsync();
                }
                //await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            }
            await _ligamaniaUnitOfWork.SaveEntitiesAsync();

            return "Temporada historificada";
        }

        private Task CalcularPuestoClasificacion(List<TemporadaClasificacionDTO> clasificaciones, TemporadaDTO temporada)
        {
            var competiciones = clasificaciones.Select(c => c.CompeticionId).Distinct();
            foreach(var compId in competiciones)
            {
                var categorias = clasificaciones.Where(c => c.CompeticionId.Equals(compId)).Select(c => c.CategoriaId).Distinct();
                foreach(var catId in categorias)
                {
                    var equipos = clasificaciones
                        .Where(c => c.CompeticionId.Equals(compId) && c.CategoriaId.Equals(catId))
                        .Select(c => new { Equipo = c.Equipo, Clasificacion=c });
                    equipos = equipos.Where(e => !e.Equipo.EsBot)
                        .OrderByDescending(e=>e.Clasificacion.Puntos)
                        .ThenByDescending(e => e.Clasificacion.GolesFavor)
                        .ThenBy(e => e.Clasificacion.GolesExtraFavor)
                        .ThenBy(e => e.Clasificacion.GolesExtraContra)
                        .ThenByDescending(e => e.Clasificacion.GolesContra)
                        .ThenByDescending(e => e.Clasificacion.Ganados)
                        .ToList();
                    int puesto = 1;
                    for(int i=0; i < equipos.Count();i++)
                    {
                        equipos.ToArray()[i].Clasificacion.Puesto = puesto++;
                    }
                }
            }
            return Task.CompletedTask;
        }

        public async Task<string> CambiarJugadorTemporada(Jugador jug)
        {
            string response;
            var temporada = await GetTemporadaEnCurso();

            var jugadorExistente = await _ligamaniaUnitOfWork.JugadorRepository.GetByNameAsync(jug.Nombre);
            if (jugadorExistente == null)
            {
                return "El jugador " + jug.Nombre + " debe existir para poder cambiarlo";
            }
            else
            {
                // buscarlo en la temporada actual y darlo de baja del club y puesto donde esté
                var tempJug = await _ligamaniaUnitOfWork.TemporadaJugadorRepository.FindAsync(tj => tj.Temporada.Actual && tj.Jugador_ID.Equals(jugadorExistente.Id));
                if (tempJug != null)
                    tempJug.Activo = false;

                // creamos el alta del jugador con el nuevo club y/o puesto en la temporada actual
                var club = await _ligamaniaUnitOfWork.ClubRepository.GetByAliasAsync(jug.Club);
                var puesto = await _ligamaniaUnitOfWork.PuestoRepository.GetByNameAsync(jug.Puesto);
                var jt = new TemporadaJugadorDTO()
                {
                    Activo = true,
                    Club = club,
                    Puesto = puesto,
                    Jugador = jugadorExistente,
                    Eliminado = false,
                    LastJornadaEliminacion = null,
                    PreEliminado = false,
                    Temporada = temporada,
                    VecesEliminado = 0,
                    VecesPreEliminado = 0
                };
                jt = await _ligamaniaUnitOfWork.TemporadaJugadorRepository.AddAsyn(jt);
            }
            if (await _ligamaniaUnitOfWork.SaveEntitiesAsync() > 0)
                response = "Jugador " + jug.Nombre + " actualizado";
            else
                response = "Error al cambiar el jugador " + jug.Nombre;
            return response;
        }
    }
}
