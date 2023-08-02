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
        Task<IEnumerable<ContabilidadDto>> GetContabilidadTemporadaAsync();
        Task<IEnumerable<ContabilidadDto>> GetContabilidades();
        Task<string> UpdateConceptoContabilidad(ContabilidadDto concepto);
        Task<string> RemoveConceptoContabilidad(int id);
        Task<IEnumerable<PremioDto>> GetPremiosTemporadaAsync(string temporada);
        Task<string> UpdatePremioTemporadaAsync(PremioDto premioDto);
        Task<string> RemovePremioTemporadaAsynd(int id);
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

            //var prueba1 = jugadores.Where(j => j.Jugador.Equals("Nolito")).ToList();
            //var prueba2 = jugRepo.Where(j => j.Nombre.Equals("Nolito")).ToList();


            //var prueba3 = jugadores.Where(j => !j.Activo).ToList();
            //var prueba4 = jugadores.Where(j => j.Activo).ToList();

            // todos los jugadores de la temporada actual (activos y no activos)
            var jTemporada = _mapper.Map<List<Jugador>>(jugadores);
            // todos los jugadores del repositorio (baja y no baja)
            var jRepositorio = _mapper.Map<List<Jugador>>(jugRepo);


            // todos los jugadores de la temporada actual ACTIVOS
            jTemporada = jTemporada.Where(j => j.Activo).ToList();

            // metemos en list todos los jugadores del repositorio (baja y no baja)
            var list = jRepositorio;
            // recorro todos los jugadores activos de la temporada actual
            foreach(var jugA in jTemporada)
            {
                // busco el jugador en el repositorio
                var v = jRepositorio.Find(j => j.Nombre.Equals(jugA.Nombre));
                // si no está de baja lo cambio por el jugador activo de la temporada
                if (!jugA.Baja)
                {
                    list.Remove(v);
                    list.Add(jugA);
                }
            }

            return list;
        }

        public async Task<string> UpdateJugadores(List<Jugador> listJugadores)
        {
            bool alta = false;
            var temporada = await GetTemporadaEnCurso();
            if (temporada == null)
                return "No hay temporada en curso";

            if (listJugadores.Count == 0)
                return "No hay jugadores para dar de alta";

            // club y puesto al que queremos mover todos los jugadores de la lista dándolos de alta en la temporada actual
            // si ya existen en la temporada actual, se les activa únicamente
            var clubDto = await _ligamaniaUnitOfWork.ClubRepository.GetByAliasAsync(listJugadores.First().Club);
            var puestoDto = await _ligamaniaUnitOfWork.PuestoRepository.GetByNameAsync(listJugadores.First().Puesto);
            foreach (var jug in listJugadores)
            {
                var jugadorDto = await _ligamaniaUnitOfWork.JugadorRepository.GetByNameAsync(jug.Nombre);
                var existentes = await ExisteJugadorTemporada(jugadorDto, temporada);
                bool encontrado = false;
                foreach(var j in existentes)
                {
                    if (jug.Activo && (clubDto == null || puestoDto == null))
                        return "No se seleccionó club y puesto para realizar la operación";

                    if (jug.Activo && j.Club.Id.Equals(clubDto.Id) && j.Puesto.Id.Equals(puestoDto.Id))
                    {
                        alta = true;
                        j.Activo = true;
                        encontrado = true;
                        if (j.Activo) await _ligamaniaUnitOfWork.JugadorRepository.Alta(jugadorDto);
                        else await _ligamaniaUnitOfWork.JugadorRepository.Baja(jugadorDto);
                    }
                    else
                    {
                        alta = false;
                        j.Activo = false;
                        //if (j.Activo) await _ligamaniaUnitOfWork.JugadorRepository.Alta(jugadorDto);
                        //else 
                            await _ligamaniaUnitOfWork.JugadorRepository.Baja(jugadorDto);
                    }
                }
                if (!encontrado)
                {
                    if (jug.Activo)
                    {
                        alta = true;
                        await _ligamaniaUnitOfWork.TemporadaJugadorRepository.Alta(jugadorDto, clubDto, puestoDto, temporada);
                        await _ligamaniaUnitOfWork.JugadorRepository.Alta(jugadorDto);
                    }
                    else
                    {
                        alta = false;
                        await _ligamaniaUnitOfWork.JugadorRepository.Baja(jugadorDto);
                    }
                }
            }

            await _ligamaniaUnitOfWork.SaveEntitiesAsync();
            string response = alta ? "Jugadores dados de alta": "Jugadores dados de baja";
            return response;
        }

        private async Task<IEnumerable<TemporadaJugadorDTO>> ExisteJugadorTemporada(JugadorDTO jugadorDto, TemporadaDTO temporada)
        {
            //var existe = await _ligamaniaUnitOfWork.TemporadaJugadorRepository.ExistsAsync(tj => tj.Temporada_ID.Equals(temporada.Id) && tj.Jugador_ID.Equals(jugadorDto.Id));
            //if (existe)
                return await _ligamaniaUnitOfWork.TemporadaJugadorRepository
                    .FindAllIncludingAsync(tj => tj.Temporada_ID.Equals(temporada.Id) && tj.Jugador_ID.Equals(jugadorDto.Id), tj=>tj.Club, tj=>tj.Puesto);
            //return null;
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
                            Pichichi = pichichi != null && pichichi.Equipo.Nombre.Equals(tempEquipo.Equipo.Nombre) ? true : false
                        };
                        var existe = await _ligamaniaUnitOfWork.HistoricoRepository.FindAsync(h=>h.Temporada_ID.Equals(historico.Temporada.Id)
                            && h.Categoria_ID.Equals(historico.TemporadaCompeticionCategoria.Id) 
                            && h.Equipo_ID.Equals(historico.TemporadaEquipo.Id)
                            && h.Puesto.Equals(historico.Puesto));
                        if (existe == null)
                            await _ligamaniaUnitOfWork.HistoricoRepository.AddAsyn(historico);
                        else
                        {
                            historico.Id = existe.Id;
                            await _ligamaniaUnitOfWork.HistoricoRepository.UpdateAsync(historico);
                        }
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
                var tempJug = await _ligamaniaUnitOfWork.TemporadaJugadorRepository
                    .FindAllIncludingAsync(tj => tj.Temporada.Actual && tj.Jugador_ID.Equals(jugadorExistente.Id), tj=>tj.Club, tj=>tj.Puesto);

                // club y puesto al que se quiere cambiar el jugador
                var club = await _ligamaniaUnitOfWork.ClubRepository.GetByAliasAsync(jug.Club);
                var puesto = await _ligamaniaUnitOfWork.PuestoRepository.GetByNameAsync(jug.Puesto);

                // todos los jugadores que encuentre, si ninguno es del club y puesto al que se quiere cambiar, los damos de baja
                // y si es del mismo club y puesto lo activamos nuevamente
                bool encontrado = false;
                foreach (var tjug in tempJug)
                {
                    if (tjug.Club.Id.Equals(club.Id) && tjug.Puesto.Id.Equals(puesto.Id))
                    {
                        tjug.Activo = true;
                        encontrado = true;
                    }
                    else
                        tjug.Activo = false;
                }
                jugadorExistente.Baja = false;
                // si no lo encontramos en la temporada actual, lo damos de alta
                if (!encontrado)
                {
                    // creamos el alta del jugador con el nuevo club y/o puesto en la temporada actual
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
            }
            if (await _ligamaniaUnitOfWork.SaveEntitiesAsync() > 0)
                response = "Jugador " + jug.Nombre + " actualizado";
            else
                response = "Error al cambiar el jugador " + jug.Nombre;
            return response;
        }

        public async Task<IEnumerable<ContabilidadDto>> GetContabilidadTemporadaAsync()
        {
            var contabilidades = await _ligamaniaUnitOfWork.TemporadaContabilidadRepository.FindAllAsync(tc => tc.Temporada.Actual);
            return _mapper.Map<IEnumerable<ContabilidadDto>>(contabilidades);
        }

        public async Task<IEnumerable<ContabilidadDto>> GetContabilidades()
        {
            var contabilidades = await _ligamaniaUnitOfWork.TemporadaContabilidadRepository.GetContabilidades();
            var lista = _mapper.Map<List<ContabilidadDto>>(contabilidades.ToList());
            var temporadas = contabilidades.Select(c => c.Temporada.Nombre).Distinct();

            foreach (var temp in temporadas)
            {
                var temporada = contabilidades.FirstOrDefault(c => c.Temporada.Nombre.Equals(temp)).Temporada;
                var equipos = temporada.TemporadaEquipo.DistinctBy(te=>te.Id)
                    .Where(te => te.CompeticionId==1 && !te.Equipo.EsBot && !te.Baja)
                    .Count();
                UpdateNumEquipos(lista.Where(c=>c.Temporada.Equals(temp)).ToList(), equipos);
            }
            return lista;
        }
        public async Task<IEnumerable<PremioDto>> GetPremiosTemporadaAsync(string temporada)
        {

            var temp = await _ligamaniaUnitOfWork.TemporadaRepository.GetTemporadaClasificacionAsync(temporada);
            var premios = await _ligamaniaUnitOfWork.TemporadaPremiosRepository.GetPremiosByTemporada(temp.Id);
            premios = premios.DistinctBy(p => p.Id).ToList();
            var lista = new List<PremioDto>();

            foreach(var premio in premios)
            {
                lista.AddRange(_mapper.Map<List<PremioDto>>(premio.TemporadaPremiosPuesto.DistinctBy(pp=>pp.Id)));
            }
            lista.ForEach(async l => l.Equipo = await GetEquipo(temp, l.Competicion, l.Categoria, l.Puesto));
            return lista;
        }
        private async Task<string> GetEquipo(TemporadaDTO temporada, string competicion, string categoria, PuestoCompeticion puesto)
        {
           string equipo = string.Empty;
            var jornadaId = temporada.TemporadaCompeticionJornada.Where(tcj => tcj.Competicion.Nombre.Equals(competicion)).OrderByDescending(tcj=>tcj.NumeroJornada).First().Id;
            var equi = temporada.TemporadaClasificacion.Where(tc => tc.Competicion.Nombre.Equals(competicion)
                && tc.Categoria.Nombre.Equals(categoria) && tc.JornadaId.Equals(jornadaId) && tc.Puesto.Equals((int)puesto+1)).FirstOrDefault();
            if (equi!=null) equipo = equi.Equipo.Nombre;
            return equipo;
        }
        private void UpdateNumEquipos(List<ContabilidadDto> lista,int equipos)
        {
            lista.ForEach(cont =>
                cont.Equipos = equipos
            );
        }

        public async Task<string> UpdateConceptoContabilidad(ContabilidadDto concepto)
        {
            var item = await _ligamaniaUnitOfWork.TemporadaContabilidadRepository.GetByIdAsync(concepto.Id);
            if (item == null)
                return await AddConceptoContabilidad(concepto);
            
            item.Concepto = concepto.Concepto;
            item.Equipo = concepto.PorEquipo;
            item.Gasto = concepto.Gasto;
            item.Valor = concepto.Valor;
            await _ligamaniaUnitOfWork.TemporadaContabilidadRepository.UpdateAsync(item);
            if (await _ligamaniaUnitOfWork.SaveEntitiesAsync()>0)
                return "Concepto actualizado";
            return "No se pudo actualizar el concepto";
        }
        private async Task<string> AddConceptoContabilidad(ContabilidadDto concepto)
        {
            var temporada = await _ligamaniaUnitOfWork.TemporadaRepository.GetByNameAsync(concepto.Temporada);
            var id = temporada.Id;
            var item = new TemporadaContabilidadDTO
            {
                TemporadaId = id,
                Concepto = concepto.Concepto,
                Equipo = concepto.PorEquipo,
                Gasto = concepto.Gasto,
                Valor = concepto.Valor
            };
            await _ligamaniaUnitOfWork.TemporadaContabilidadRepository.AddAsyn(item);
            if (await _ligamaniaUnitOfWork.SaveEntitiesAsync() > 0)
                return "Concepto añadido";
            return "No se pudo añadir el nuevo concepto";
        }
        public async Task<string> RemoveConceptoContabilidad(int id)
        {
            await _ligamaniaUnitOfWork.TemporadaContabilidadRepository.DeleteAsync(id);
            if (await _ligamaniaUnitOfWork.SaveEntitiesAsync() > 0)
                return "Concepto eliminado";
            return "No se pudo eliminar el concepto";
        }

        public async Task<string> UpdatePremioTemporadaAsync(PremioDto premioDto)
        {
            var premio = await _ligamaniaUnitOfWork.TemporadaPremiosPuestoRepository.GetByIdAsync(premioDto.Id);
            premio.Importe = premioDto.Premio;
            await _ligamaniaUnitOfWork.TemporadaPremiosPuestoRepository.UpdateAsync(premio);
            if (await _ligamaniaUnitOfWork.SaveEntitiesAsync() > 0)
                return "Premio actualizado";
            return "El premio no se pudo actualizar debido a algún error";
        }

        public async Task<string> RemovePremioTemporadaAsynd(int id)
        {
            await _ligamaniaUnitOfWork.TemporadaPremiosPuestoRepository.DeleteAsync(id);
            if (await _ligamaniaUnitOfWork.SaveEntitiesAsync() > 0)
                return "Premio eliminado";
            return "El premio no se pudo eliminar debido a algún error";
        }
    }
}
