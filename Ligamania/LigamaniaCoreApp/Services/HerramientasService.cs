using AutoMapper;
using LigamaniaCoreApp.Data;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using LigamaniaCoreApp.Models.HerramientasViewModels;
using LigamaniaCoreApp.Services.Interfaces;
using LigamaniaCoreApp.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Services
{
    public class HerramientasService : IHerramientasService
    {
        private readonly IAlineacionRepository _alineacionRepository;
        private readonly IAlineacionPreviaRepository _alineacionPreviaRepository;
        private readonly IAlineacionCambiosRepository _alineacionCambioRepository;
        private readonly ITemporadaJugadorRepository _temporadaJugadorRepository;
        private readonly ITemporadaCompeticionRepository _temporadaCompeticionRepository;
        private readonly ITemporadaRepository _temporadaRepository;
        private readonly ITemporadaCompeticionJornadaRepository _temporadaCompeticionJornadaRepository;
        private readonly ILogger<HerramientasService> _logger;
        private readonly ITemporadaEquipoRepository _temporadaEquipoRepository;
        private readonly ICambiosEquipoRepository _cambiosEquipoRepository;
        private readonly IJugadorRepository _jugadorRepository;
        private readonly ITemporadaJornadaJugadorRepository _temporadaJornadaJugadorRepository;
        private readonly IAlineacionHistoricoRepository _alineacionHistoricoRepository;
        private readonly IMapper _mapper;

        public HerramientasService(
              IAlineacionRepository alineacionRepository
            , IAlineacionPreviaRepository alineacionPreviaRepository
            , IAlineacionCambiosRepository alineacionCambiosRepository
            , ITemporadaJugadorRepository temporadaJugadorRepository
            , ITemporadaCompeticionRepository temporadaCompeticionRepository
            , ITemporadaRepository temporadaRepository
            , ITemporadaCompeticionJornadaRepository temporadaCompeticionJornadaRepository
            , ILogger<HerramientasService> logger
            , ITemporadaEquipoRepository temporadaEquipoRepository
            , ICambiosEquipoRepository cambiosEquipoRepository
            , IJugadorRepository jugadorRepository
            , ITemporadaJornadaJugadorRepository temporadaJornadaJugadorRepository
            , IAlineacionHistoricoRepository alineacionHistoricoRepository
            , IMapper mapper
            )
        {
            _alineacionCambioRepository = alineacionCambiosRepository;
            _alineacionPreviaRepository = alineacionPreviaRepository;
            _alineacionRepository = alineacionRepository;
            _temporadaJugadorRepository = temporadaJugadorRepository;
            _temporadaCompeticionRepository = temporadaCompeticionRepository;
            _temporadaRepository = temporadaRepository;
            _temporadaCompeticionJornadaRepository = temporadaCompeticionJornadaRepository;
            _temporadaEquipoRepository = temporadaEquipoRepository;
            _cambiosEquipoRepository = cambiosEquipoRepository;
            _jugadorRepository = jugadorRepository;
            _temporadaJornadaJugadorRepository = temporadaJornadaJugadorRepository;
            _alineacionHistoricoRepository = alineacionHistoricoRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response> RevisarClubsAlineaciones()
        {
            try
            {
                var alineacionesCambios = await _alineacionCambioRepository.GetAllIncludingAsync(ac => ac.Jugador, ac => ac.Club).ConfigureAwait(false);
                foreach(var ali in alineacionesCambios)
                {
                    var tempJug = await _temporadaJugadorRepository.FindIncludingAsync(tj => tj.Temporada.Actual && tj.Jugador_ID.Equals(ali.Jugador_ID) && tj.Activo ,tj=>tj.Club).ConfigureAwait(false);
                    if (ali.Club_ID != tempJug.Club.Id)
                    {
                        ali.Club = tempJug.Club;
                        await _alineacionCambioRepository.UpdateAsyn(ali, ali.Id).ConfigureAwait(false);
                    }
                }
                await _alineacionCambioRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Revisados los clubs de los jugadores alineados", Result = true, Status = EResponseStatus.Success};
            }
            catch (Exception x)
            {
                return new Response { Message = "Error al revisar los clubs de los jugadores alineados", Result = false, Status = EResponseStatus.Error };
            }
        }

        async Task<ICollection<AlineacionCompeticionJornadaViewModel>> GetAllAlineacionesJornada(TemporadaCompeticionDTO temporadaCompeticion)
        {
            var jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaCarrusel(temporadaCompeticion.CompeticionId).ConfigureAwait(false);
            if (jornadaActual == null) jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaActual(temporadaCompeticion.CompeticionId).ConfigureAwait(false);
            List<AlineacionCompeticionJornadaViewModel> lista = new List<AlineacionCompeticionJornadaViewModel>();
            ICollection<AlineacionDTO> alineaciones = await _alineacionRepository.GetAlineaciones(jornadaActual.Temporada, temporadaCompeticion, jornadaActual).ConfigureAwait(false);

            foreach (var ali in alineaciones)
            {
                AlineacionCompeticionJornadaViewModel aliVm = new AlineacionCompeticionJornadaViewModel
                {
                    Club = ali.Club.Nombre,
                    Equipo = ali.Equipo.Equipo.Nombre,
                    Jugador = ali.Jugador.Nombre,
                    OrdenPuesto = ali.Puesto.Orden,
                    Puesto = ali.Puesto.Nombre,
                    Categoria = ali.Categoria.Nombre,
                    OrdenCategoria = ali.Categoria.Orden,
                    IdAlineacion = ali.Id
                };
                lista.Add(aliVm);
            }
            return lista;
        }

        async Task<ICollection<AlineacionCompeticionJornadaViewModel>> GetAllAlineacionesPrevias(CompeticionDTO competicion)
        {

            List<AlineacionCompeticionJornadaViewModel> lista = new List<AlineacionCompeticionJornadaViewModel>();
            ICollection<AlineacionPreviaDTO> alineaciones = await _alineacionPreviaRepository.GetAllAlineacionesCompeticion(competicion.Id).ConfigureAwait(false);
            var temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
            alineaciones = alineaciones.Where(a => a.Temporada_ID.Equals(temporada.Id)).ToList();
            foreach (var ali in alineaciones)
            {
                AlineacionCompeticionJornadaViewModel aliVm = new AlineacionCompeticionJornadaViewModel
                {
                    Club = ali.Club.Nombre,
                    Equipo = ali.Equipo.Equipo.Nombre,
                    Jugador = ali.Jugador.Nombre,
                    OrdenPuesto = ali.Puesto.Orden,
                    Puesto = ali.Puesto.Nombre, 
                    Categoria = ali.Categoria.Nombre,
                    OrdenCategoria = ali.Categoria.Orden,
                    IdAlineacion = ali.Id
                };
                lista.Add(aliVm);
            }
            return lista;
        }
        async Task<ICollection<AlineacionCompeticionJornadaViewModel>> GetAllAlineacionesCambios(CompeticionDTO competicion)
        {
            List<AlineacionCompeticionJornadaViewModel> lista = new List<AlineacionCompeticionJornadaViewModel>();
            ICollection<AlineacionCambioDTO> alineaciones = await _alineacionCambioRepository.GetAllAlineacionesCompeticion(competicion.Id).ConfigureAwait(false);
            var temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
            alineaciones = alineaciones.Where(a => a.Temporada_ID.Equals(temporada.Id)).ToList();
            foreach (var ali in alineaciones)
            {
                AlineacionCompeticionJornadaViewModel aliVm = new AlineacionCompeticionJornadaViewModel
                {
                    Club = ali.Club.Nombre,
                    Equipo = ali.Equipo.Equipo.Nombre,
                    Jugador = ali.Jugador.Nombre,
                    OrdenPuesto = ali.Puesto.Orden,
                    Puesto = ali.Puesto.Nombre,
                    Categoria = ali.Categoria.Nombre,
                    OrdenCategoria = ali.Categoria.Orden,
                    IdAlineacion = ali.Id
                };
                lista.Add(aliVm);
            }
            return lista;
        }

        public async Task<AlineacionCompeticionViewModel> GetAlineacionesCompeticion(string competicion)
        {
            var temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
            var tempComp = await _temporadaCompeticionRepository.GetCompeticion(temporada.Id, competicion).ConfigureAwait(false);
            ICollection<AlineacionCompeticionJornadaViewModel> alineacionesPrevias = await GetAllAlineacionesPrevias(tempComp.Competicion).ConfigureAwait(false);
            var alineacionesCambios = await GetAllAlineacionesCambios(tempComp.Competicion).ConfigureAwait(false);
            var alineacionesActual = await GetAllAlineacionesJornada(tempComp).ConfigureAwait(false);

            AlineacionCompeticionViewModel ali = new AlineacionCompeticionViewModel
            {
                AlineacionesCambios = alineacionesCambios,
                AlineacionesPrevias = alineacionesPrevias,
                AlineacionesActual = alineacionesActual,
                Competicion = competicion
            };
            return ali;
        }

        public async Task<Response> AgregarAlineacion(AlineacionCompeticionJornadaViewModel alineacion)
        {
            try
            {
                TemporadaEquipoDTO equipo = await _temporadaEquipoRepository.FindIncludingAsync(
                    te => te.Temporada.Actual && te.Competicion.Nombre.Equals(alineacion.Competicion) && te.Equipo.Nombre.Equals(alineacion.Equipo),
                    te => te.Temporada, te => te.Competicion, te => te.Categoria, te => te.Equipo).ConfigureAwait(false);
                if (equipo==null)
                    return new Response { Message = "No se encuentra el equipo "+alineacion.Equipo +" en "+alineacion.Competicion, Result = false, Status = EResponseStatus.Warning};

                string[] clubJug = alineacion.Jugador.Split(" - ");
                string club = clubJug[0];
                string jugador = clubJug[1];

                TemporadaJugadorDTO temporadaJugadorNuevo = null;
                if (alineacion.Jugador != LigamaniaConst.JugadorAlineacion)
                {
                    temporadaJugadorNuevo = await _temporadaJugadorRepository
                            .FindIncludingAsync(tj => tj.Temporada.Actual && tj.Jugador.Nombre.Equals(jugador) && tj.Activo,
                            tj => tj.Club, tj => tj.Puesto, tj => tj.Jugador).ConfigureAwait(false);
                }
                if (temporadaJugadorNuevo == null)
                    return new Response { Message = "No se encuentra el jugador por el que realizar el cambio", Result = false, Status = EResponseStatus.Warning };

                if (alineacion.Tipo.Equals("aliCambios"))
                {
                    AlineacionCambioDTO ali = new AlineacionCambioDTO
                    {
                        Temporada = equipo.Temporada,
                        Competicion = equipo.Competicion,
                        Categoria = equipo.Categoria,
                        Equipo = equipo,
                        Club = temporadaJugadorNuevo.Club,
                        Puesto = temporadaJugadorNuevo.Puesto,
                        Jugador = temporadaJugadorNuevo.Jugador
                    };
                    await _alineacionCambioRepository.AddAsyn(ali).ConfigureAwait(false);
                    await _alineacionCambioRepository.SaveAsync().ConfigureAwait(false);
                }
                else
                {
                    var jornadaCarrusel = await _temporadaCompeticionJornadaRepository.GetJornadaCarrusel(equipo.CompeticionId).ConfigureAwait(false);
                    AlineacionDTO ali = new AlineacionDTO
                    {
                        Temporada = equipo.Temporada,
                        Competicion = equipo.Competicion,
                        Categoria = equipo.Categoria,
                        Equipo = equipo,
                        Jornada = jornadaCarrusel,
                        Club = temporadaJugadorNuevo.Club,
                        Puesto = temporadaJugadorNuevo.Puesto,
                        Jugador = temporadaJugadorNuevo.Jugador
                    };
                    await _alineacionRepository.AddAsyn(ali).ConfigureAwait(false);
                    await _alineacionRepository.SaveAsync().ConfigureAwait(false);

                }
                return new Response { Message = "Jugador agregado correctamente", Result = true, Status = EResponseStatus.Success };
            }
            catch(Exception x)
            {
                _logger.LogError(x.ToString());
                return new Response { Message = "Error al agregar un jugador", Result = false, Status = EResponseStatus.Error};
            }
        }
        public async Task<Response> EditarAlineacion(AlineacionCompeticionJornadaViewModel alineacion)
        {
            try
            {
                string[] clubJug = alineacion.JugadorCambio.Split(" - ");
                string club = clubJug[0];
                string jugador = clubJug[1];

                TemporadaJugadorDTO temporadaJugadorNuevo = null;
                if (alineacion.JugadorCambio != LigamaniaConst.JugadorAlineacion)
                {
                    temporadaJugadorNuevo = await _temporadaJugadorRepository
                            .FindIncludingAsync(tj => tj.Temporada.Actual && tj.Jugador.Nombre.Equals(jugador) && tj.Activo,
                            tj => tj.Club, tj => tj.Puesto, tj => tj.Jugador).ConfigureAwait(false);
                }
                if (temporadaJugadorNuevo == null)
                    return new Response { Message = "No se encuentra el jugador por el que realizar el cambio", Result = false, Status = EResponseStatus.Warning };

                if (alineacion.Tipo.Equals("aliCambios"))
                {
                    AlineacionCambioDTO aliCambio = await _alineacionCambioRepository.GetAsync(alineacion.IdAlineacion).ConfigureAwait(false);
                    aliCambio.Jugador = temporadaJugadorNuevo.Jugador;
                    aliCambio.Club = temporadaJugadorNuevo.Club;
                    await _alineacionCambioRepository.UpdateAsyn(aliCambio, aliCambio.Id).ConfigureAwait(false);
                    await _alineacionCambioRepository.SaveAsync().ConfigureAwait(false);
                } 
                else
                {
                    AlineacionDTO aliActual = await _alineacionRepository.GetAsync(alineacion.IdAlineacion).ConfigureAwait(false);
                    aliActual.Jugador = temporadaJugadorNuevo.Jugador;
                    aliActual.Club = temporadaJugadorNuevo.Club;
                    await _alineacionRepository.UpdateAsyn(aliActual, aliActual.Id).ConfigureAwait(false);
                    await _alineacionRepository.SaveAsync().ConfigureAwait(false);
                }
                return new Response { Message = "Jugador modificado correctamente", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.ToString());
                return new Response { Message = "Error al modificar un jugador", Result = false, Status = EResponseStatus.Error };
            }
        }
        public async Task<Response> BorrarAlineacion(AlineacionCompeticionJornadaViewModel alineacion)
        {
            try
            {
                if (alineacion.Tipo.Equals("aliCambios"))
                {
                    AlineacionCambioDTO aliCambio = await _alineacionCambioRepository.GetAsync(alineacion.IdAlineacion).ConfigureAwait(false);
                    await _alineacionCambioRepository.DeleteAsyn(aliCambio).ConfigureAwait(false);
                    await _alineacionCambioRepository.SaveAsync().ConfigureAwait(false);
                }
                else
                {
                    AlineacionDTO aliActual = await _alineacionRepository.GetAsync(alineacion.IdAlineacion).ConfigureAwait(false);
                    await _alineacionRepository.DeleteAsyn(aliActual).ConfigureAwait(false);
                    await _alineacionRepository.SaveAsync().ConfigureAwait(false);
                }
                return new Response { Message = "Jugador borrado correctamente", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.ToString());
                return new Response { Message = "Error al borrar un jugador", Result = false, Status = EResponseStatus.Error };
            }
        }
        public async Task<ICollection<CambioEquipoViewModel>> GetCambiosEquipos()
        {
            var cambios = await _cambiosEquipoRepository.GetAllIncludingAsync(c => c.Temporada, c => c.EquipoDestino, c => c.EquipoOrigen).ConfigureAwait(false);

            var lista = _mapper.Map<ICollection<CambioEquipoViewModel>>(cambios);
            return lista;
        }
        public async Task<List<JugadorRepositoryViewModel>> GetAllJugadoresLigamania()
        {
            try
            {
                List<JugadorRepositoryViewModel> allJugadores = new List<JugadorRepositoryViewModel>();

                // todos los jugadores que han pasado por ligamania
                ICollection<TemporadaJugadorDTO> jugadoresPorTemporada = await _temporadaJugadorRepository
                    .GetAllListIncludingAsync(tj => tj.Temporada, tj => tj.Club, tj => tj.Puesto, tj => tj.Jugador)
                    .ConfigureAwait(false);

                foreach(var jugador in jugadoresPorTemporada)
                {
                    int usadoEnAlineaciones = await _alineacionRepository.CountMatchAsync(a => a.Jugador_ID.Equals(jugador.Jugador.Id)).ConfigureAwait(false);
                    int usadoEnAliHistorico = await _alineacionHistoricoRepository.CountMatchAsync(a => a.Jugador_ID.Equals(jugador.Jugador.Id)).ConfigureAwait(false);
                    int usadoAli = usadoEnAlineaciones + usadoEnAliHistorico;
                    int usadoEnJornadas = await _temporadaJornadaJugadorRepository.CountMatchAsync(tjj => tjj.JugadorId.Equals(jugador.Jugador.Id)).ConfigureAwait(false);
                    JugadorRepositoryViewModel jugadorRepo = new JugadorRepositoryViewModel
                    {
                        Id = jugador.Jugador.Id,
                        Activo = !jugador.Jugador.Baja,
                        ActivoTemporada = jugador.Activo,
                        Club = jugador.Club.Nombre,
                        IdTemporada = jugador.Id,
                        Jugador = jugador.Jugador.Nombre,
                        Puesto = jugador.Puesto.Nombre,
                        Temporada = jugador.Temporada.Nombre,
                        FechaJugador = jugador.Jugador.UpdatedDate,
                        FechaTemporada = jugador.UpdatedDate,
                        UsadoEnAlineaciones = usadoAli,
                        UsadoEnJornadas = usadoEnJornadas
                    };
                    allJugadores.Add(jugadorRepo);
                }

                return allJugadores;
            }
            catch(Exception x)
            {
                _logger.LogError(x.ToString());
                return null;
            }
        }

    }
}
