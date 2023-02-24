using AutoMapper;
using LigamaniaCoreApp.Data;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using LigamaniaCoreApp.Models;
using LigamaniaCoreApp.Models.AccountViewModels;
using LigamaniaCoreApp.Models.GlobalViewModels;
using LigamaniaCoreApp.Models.InvitadoViewModels;
using LigamaniaCoreApp.Models.ManagerViewModels;
using LigamaniaCoreApp.Services.Interfaces;
using LigamaniaCoreApp.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LigamaniaCoreApp.Data.LigamaniaEnum;

namespace LigamaniaCoreApp.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IMapper _mapper;
        private readonly ITemporadaRepository _temporadaRepository;
        private readonly ITemporadaCompeticionRepository _temporadaCompeticionRepository;
        private readonly ITemporadaCompeticionCategoriaRepository _temporadaCompeticionCategoriaRepository;
        private readonly ITemporadaEquipoRepository _temporadaEquipoRepository;
        private readonly IAlineacionCambiosRepository _alineacionCambiosRepository;
        private readonly IAlineacionHistoricoRepository _alineacionHistoricoRepository;
        private readonly IAlineacionPreviaRepository _alineacionPreviaRepository;
        private readonly IAlineacionRepository _alineacionRepository;
        private readonly IControlUsuarioRepository _controlUsuarioRepository;
        private readonly INoticiaRepository _noticiaRepository;
        private readonly ApplicationUserManager<ApplicationUser> _userManager;
        private readonly IEquipoRepository _equipoRepository;
        private readonly ICompeticionRepository _competicionRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICompeticionCategoriaRepository _competicionCategoriaRepository;
        private readonly ILogger<ManagerService> _logger;
        private readonly ITemporadaPartidoRepository _temporadaPartidoRepository;
        private readonly ITemporadaCompeticionJornadaRepository _temporadaCompeticionJornadaRepository;
        private readonly ICalendarioRepository _calendarioRepository;
        private readonly IEstadoCompeticionRepository _estadoCompeticionRepository;
        private readonly IOperacionCompeticionRepository _operacionCompeticionRepository;
        private readonly ICalendarioDetalleRepository _calendarioDetalleRepository;
        private readonly IHistoricoRepository _historicoRepository;
        private readonly ITemporadaCuadroRepository _temporadaCuadroRepository;
        private readonly ITemporadaClasificacionRepository _temporadaClasificacionRepository;
        private readonly ITemporadaJornadaJugadorRepository _temporadaJornadaJugadorRepository;
        private readonly ITemporadaJugadorRepository _temporadaJugadorRepository;
        private readonly ITemporadaCompeticionCategoriaReferenciaRepository _temporadaCompeticionCategoriaReferenciaRepository;
        private readonly ICuadroCopaRepository _cuadroCopaRepository;
        private readonly ITemporadaRondaRepository _temporadaRondaRepository;
        private readonly ITemporadaPremiosRepository _temporadaPremiosRepository;
        private readonly ITemporadaPremiosPuestoRepository _temporadaPremiosPuestoRepository;
        private readonly ITemporadaContabilidadRepository _temporadaConabilidadRepository;
        private readonly IEmailSender _emailService;

        public ManagerService(IMapper mapper
            , ILogger<ManagerService> logger
            , ITemporadaRepository temporadaRepository
            , ITemporadaCompeticionRepository temporadaCompeticionRepository
            , ITemporadaCompeticionCategoriaRepository temporadaCompeticionCategoriaRepository
            , ITemporadaEquipoRepository temporadaEquipoRepository
            , IAlineacionCambiosRepository aliCambiosRepository
            , IAlineacionHistoricoRepository alineacionHistoricoRepository
            , IAlineacionPreviaRepository alineacionPreviaRepository
            , IAlineacionRepository alineacionRepository
            , IControlUsuarioRepository controlUsuarioRepository
            , INoticiaRepository noticiaRepository
            , ApplicationUserManager<ApplicationUser> userManager
            , IEquipoRepository equipoRepository
            , ICompeticionRepository competicionRepository
            , ICategoriaRepository categoriaRepository
            , ICompeticionCategoriaRepository competicionCategoriaRepository
            , ITemporadaPartidoRepository temporadaPartidoRepository
            , ITemporadaCompeticionJornadaRepository temporadaCompeticionJornadaRepository
            , ICalendarioRepository calendarioRepository
            , IEstadoCompeticionRepository estadoCompeticionRepository
            , IOperacionCompeticionRepository operacionCompeticionRepository
            , ICalendarioDetalleRepository calendarioDetalleRepository
            , IHistoricoRepository historicoRepository
            , ITemporadaCuadroRepository temporadaCuadroRepository
            , ITemporadaClasificacionRepository temporadaClasificacionRepository
            , ITemporadaJornadaJugadorRepository temporadaJornadaJugadorRepository
            , ITemporadaJugadorRepository temporadaJugadorRepository
            , ITemporadaCompeticionCategoriaReferenciaRepository temporadaCompeticionCategoriaReferenciaRepository
            , ICuadroCopaRepository cuadroCopaRepository
            , ITemporadaRondaRepository temporadaRondaRepository
            , ITemporadaPremiosRepository temporadaPremiosRepository
            , ITemporadaPremiosPuestoRepository temporadaPremiosPuestoRepository
            , ITemporadaContabilidadRepository temporadaContabilidadRepository
            , IEmailSender emailSender
            )
        {
            _mapper = mapper;
            _logger = logger;
            _temporadaRepository = temporadaRepository;
            _temporadaCompeticionRepository = temporadaCompeticionRepository;
            _temporadaCompeticionCategoriaRepository = temporadaCompeticionCategoriaRepository;
            _temporadaEquipoRepository = temporadaEquipoRepository;
            _alineacionCambiosRepository = aliCambiosRepository;
            _alineacionHistoricoRepository = alineacionHistoricoRepository;
            _alineacionPreviaRepository = alineacionPreviaRepository;
            _alineacionRepository = alineacionRepository;
            _controlUsuarioRepository = controlUsuarioRepository;
            _noticiaRepository = noticiaRepository;
            _userManager = userManager;
            _equipoRepository = equipoRepository;
            _competicionRepository = competicionRepository;
            _categoriaRepository = categoriaRepository;
            _competicionCategoriaRepository = competicionCategoriaRepository;
            _temporadaPartidoRepository = temporadaPartidoRepository;
            _temporadaCompeticionJornadaRepository = temporadaCompeticionJornadaRepository;
            _calendarioRepository = calendarioRepository;
            _estadoCompeticionRepository = estadoCompeticionRepository;
            _operacionCompeticionRepository = operacionCompeticionRepository;
            _calendarioDetalleRepository = calendarioDetalleRepository;
            _historicoRepository = historicoRepository;
            _temporadaCuadroRepository = temporadaCuadroRepository;
            _temporadaClasificacionRepository = temporadaClasificacionRepository;
            _temporadaJornadaJugadorRepository = temporadaJornadaJugadorRepository;
            _temporadaJugadorRepository = temporadaJugadorRepository;
            _temporadaCompeticionCategoriaReferenciaRepository = temporadaCompeticionCategoriaReferenciaRepository;
            _cuadroCopaRepository = cuadroCopaRepository;
            _temporadaRondaRepository = temporadaRondaRepository;
            _temporadaPremiosRepository = temporadaPremiosRepository;
            _temporadaPremiosPuestoRepository = temporadaPremiosPuestoRepository;
            _temporadaConabilidadRepository = temporadaContabilidadRepository;
            _emailService = emailSender;
        }
        public async Task<TemporadaViewModel> GetTemporadaViewModelActual()
        {
            TemporadaDTO temporada = await GetTemporadaActual().ConfigureAwait(false);
            if (temporada != null)
            {
                TemporadaViewModel temporadaVM = _mapper.Map<TemporadaViewModel>(temporada);
                return temporadaVM;
            }
            _logger.LogError("No se encuentra la temporada actual");
            return null;
        }
        public async Task<TemporadaViewModel> GetTemporadaViewModelFinalizada()
        {
            TemporadaDTO temporada = await GetTemporadaFinalizada().ConfigureAwait(false);
            if (temporada != null)
            {
                TemporadaViewModel temporadaVM = _mapper.Map<TemporadaViewModel>(temporada);
                return temporadaVM;
            }
            _logger.LogError("No se encuentra la última temporada finalizada (vm)");
            return null;
        }
        public async Task<TemporadaViewModel> GetPreTemporadaViewModel()
        {
            TemporadaDTO temporada = await GetPreTemporada().ConfigureAwait(false);
            if (temporada != null)
            {
                TemporadaViewModel temporadaVM = _mapper.Map<TemporadaViewModel>(temporada);
                return temporadaVM;
            }
            _logger.LogError("No se encuentra una pretemporada");
            return null;
        }
        public async Task<ICollection<TemporadaEquipoViewModel>> GetEquiposViewModelPretemporada()
        {
            ICollection<TemporadaEquipoDTO> temporadaEquipos = await GetEquiposPretemporada().ConfigureAwait(false);
            TemporadaCompeticionDTO liga = await GetCompeticionLigaActiva().ConfigureAwait(false);
            temporadaEquipos = temporadaEquipos.Where(te => te.Competicion.Nombre.Equals(liga.Competicion.Nombre)).ToList();
            ICollection<TemporadaEquipoViewModel> viewModels = new List<TemporadaEquipoViewModel>();
            if (temporadaEquipos.Any())
            {
                foreach (var tempEquipo in temporadaEquipos)
                {
                    TemporadaEquipoViewModel temporadaEquipoVM = _mapper.Map<TemporadaEquipoViewModel>(tempEquipo);
                    viewModels.Add(temporadaEquipoVM);
                }
            }
            // Equipos que están activos pero no tienen categoría asignada
            var equiposAsignados = temporadaEquipos.Select(e => e.Equipo).ToList();

            var equiposActivos = await _equipoRepository.FindAllAsync(e => !e.Baja).ConfigureAwait(false);
            var equiposSinCompeticion = equiposActivos.Except(equiposAsignados).ToList();
            if (equiposSinCompeticion.Any())
            {
                foreach (var equipo in equiposSinCompeticion)
                {
                    TemporadaEquipoViewModel temporadaEquipoVM = new TemporadaEquipoViewModel
                    {
                        Id = equipo.Id,
                        Baja = equipo.Baja,
                        Equipo = equipo.Nombre,
                        Categoria = LigamaniaConst.Categoria_SinCategoria,
                        Confirmada=false,
                        OrdenCategoria = -1,
                        OrdenCompeticion=-1,
                        Pagada=false
                    };
                    viewModels.Add(temporadaEquipoVM);
                }
            }

            return viewModels;
            //_logger.LogError("No hay equipos en la pretemporada(vm)");
            //return null;
        }
        public async Task<TemporadaDTO> GetTemporadaActual()
        {
            IQueryable<TemporadaDTO> temporadas = _temporadaRepository.FindAllQueryable(t => t.Actual);
            temporadas = temporadas.Include(t => t.TemporadaCompeticion).ThenInclude(tc => tc.Competicion);
            temporadas = temporadas.Include(t => t.TemporadaCompeticion).ThenInclude(tc => tc.EstadoActual);
            temporadas = temporadas.Include(t => t.TemporadaCompeticion).ThenInclude(tc => tc.OperacionActual);
            if (temporadas.Any())
            {
                return await temporadas.FirstOrDefaultAsync().ConfigureAwait(false);
            }
            _logger.LogError("No se encuentra la temporada actual");
            return null;
        }
        public async Task<TemporadaCompeticionDTO> GetCompeticionLigaActiva()
        {
            var temporadaActual = await GetTemporadaActual().ConfigureAwait(false);
            if (temporadaActual == null)
                temporadaActual = await GetPreTemporada().ConfigureAwait(false);
            var competicionLiga = await _temporadaCompeticionRepository.GetCompeticion(temporadaActual.Id, LigamaniaConst.Competicion_Liga).ConfigureAwait(false);
            return competicionLiga;
        }
        public async Task<TemporadaDTO> GetTemporada(int temporadaId)
        {
            IQueryable<TemporadaDTO> temporadas = _temporadaRepository.FindAllQueryable(t => t.Id.Equals(temporadaId));
            if (temporadas.Any())
            {
                return await temporadas.FirstOrDefaultAsync().ConfigureAwait(false);
            }
            _logger.LogError("No se encuentra la temporada con id " + temporadaId);
            return null;
        }
        public async Task<TemporadaDTO> GetTemporadaFinalizada()
        {
            IQueryable<TemporadaDTO> temporadas = _temporadaRepository.FindAllQueryable(t => t.Estado.Equals(EEstadoTemporada.Finalizada.ToString()));
            if (temporadas.Any())  // temporadas 'Finalizadas'
            {
                IQueryable<TemporadaDTO> temporadasActuales = _temporadaRepository.FindAllQueryable(t => t.Actual);
                if (temporadasActuales.Any())
                {
                    temporadasActuales = temporadasActuales.Include(t => t.TemporadaCompeticion).ThenInclude(tc => tc.Competicion);
                    if (temporadasActuales.Any())
                    {
                        return await temporadasActuales.FirstOrDefaultAsync().ConfigureAwait(false);
                    }
                }
                else
                    return await temporadas.LastOrDefaultAsync().ConfigureAwait(false);   // de las 'Finalizadas', la última
            }
            else
            {
                temporadas = _temporadaRepository.FindAllQueryable(t => t.Estado.Equals(EEstadoTemporada.Cerrada.ToString()));
                return await temporadas.LastOrDefaultAsync().ConfigureAwait(false);   // de las 'Finalizadas', la última
            }
            _logger.LogError("No se encuentra una temporada finalizada");
            return null;
        }
        public async Task<TemporadaDTO> GetPreTemporada()
        {
            return await _temporadaRepository.GetPreTemporada().ConfigureAwait(false);
        }

        public async Task<ICollection<TemporadaEquipoDTO>> GetEquiposPretemporada()
        {
            TemporadaDTO pretemporada = await GetPreTemporada().ConfigureAwait(false);
            if (pretemporada != null)
            {
                ICollection<TemporadaEquipoDTO> temporadaEquipos = await _temporadaEquipoRepository.GetEquiposTemporada(pretemporada.Id).ConfigureAwait(false);
                return temporadaEquipos;
            }
            _logger.LogError("No hay pretemporada");
            return null;
        }
        public async Task<ICollection<TemporadaEquipoDTO>> GetEquiposEnTemporada(int temporadaId)
        {
            TemporadaDTO temporada = await GetTemporada(temporadaId).ConfigureAwait(false);
            if (temporada != null)
            {
                ICollection<TemporadaEquipoDTO> temporadaEquipos = await _temporadaEquipoRepository.GetEquiposTemporada(temporada.Id).ConfigureAwait(false);
                return temporadaEquipos;
            }
            _logger.LogError("No hay temporada");
            return null;
        }
        public async Task<ResponseOfTReturn<TemporadaViewModel>> FinalizarTemporada(int temporadaId)
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetAsync(temporadaId).ConfigureAwait(false);
                if (temporada == null)
                {
                    ResponseOfTReturn<TemporadaViewModel> warnResponse = new ResponseOfTReturn<TemporadaViewModel>
                    {
                        Message = "No se encuentra la temporada con id " + temporadaId,
                        Result = false,
                        ResultDTO = null,
                        Status = EResponseStatus.Warning
                    };
                    return warnResponse;
                }
                temporada.Estado = EEstadoTemporada.Cerrada.ToString();
                temporada = await _temporadaRepository.UpdateAsyn(temporada, temporadaId).ConfigureAwait(false);
                if (temporada == null)
                {
                    ResponseOfTReturn<TemporadaViewModel> errorResponse = new ResponseOfTReturn<TemporadaViewModel>
                    {
                        Message = "Error al finalizar la temporada con id " + temporadaId,
                        Result = false,
                        ResultDTO = null,
                        Status = EResponseStatus.Error
                    };
                    return errorResponse;
                }
                await _temporadaRepository.SaveAsync().ConfigureAwait(false);
                ResponseOfTReturn<TemporadaViewModel> response = new ResponseOfTReturn<TemporadaViewModel>
                {
                    Message = "Temporada " + temporada.Nombre + " FINALIZADA ",
                    Result = true,
                    ResultDTO = _mapper.Map<TemporadaViewModel>(temporada),
                    Status = EResponseStatus.Success
                };
                return response;
            }
            catch (Exception x)
            {
                _logger.LogError("Error al finalizar una temporada: " + x);
                ResponseOfTReturn<TemporadaViewModel> response = new ResponseOfTReturn<TemporadaViewModel>
                {
                    Message = "Error al finalizar la temporada",
                    Result = false,
                    ResultDTO = null,
                    Status = EResponseStatus.Error
                };
                return response;
            }
        }
        public async Task<Response> CrearTemporada(string nuevaTemporada)
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetByNameAsync(nuevaTemporada).ConfigureAwait(false);
                if (temporada != null)
                {
                    Response warnResponse = new Response
                    {
                        Message = "Ya existe una temporada con nombre " + nuevaTemporada,
                        Result = false,
                        Status = EResponseStatus.Warning
                    };
                    return warnResponse;
                }
                TemporadaDTO newTemp = new TemporadaDTO
                {
                    Actual = false,
                    Estado = EEstadoTemporada.EnPretemporada.ToString(),
                    Nombre = nuevaTemporada
                };

                newTemp = await _temporadaRepository.AddAsyn(newTemp).ConfigureAwait(false);
                if (newTemp == null)
                {
                    Response errorResponse = new Response
                    {
                        Message = "Error al crear la temporada " + nuevaTemporada,
                        Result = false,
                        Status = EResponseStatus.Error
                    };
                    return errorResponse;
                }
                await _temporadaRepository.SaveAsync().ConfigureAwait(false);
                Response response = new Response
                {
                    Message = "Temporada " + newTemp.Nombre + " CREADA en estado PRETEMPORADA",
                    Result = true,
                    Status = EResponseStatus.Success
                };
                return response;
            }
            catch (Exception x)
            {
                _logger.LogError("Error al crear una temporada: " + x);
                Response response = new Response
                {
                    Message = "Error al crear la temporada",
                    Result = false,
                    Status = EResponseStatus.Error
                };
                return response;
            }
        }
        public async Task<Response> PreTemporadaToActual()
        {
            try
            {
                TemporadaDTO pretemporada = await _temporadaRepository.GetPreTemporada().ConfigureAwait(false);
                pretemporada.Actual = true;
                pretemporada.Estado = EEstadoTemporada.EnJuego.ToString();
                await _temporadaRepository.UpdateAsyn(pretemporada, pretemporada.Id).ConfigureAwait(false);
                await _temporadaRepository.SaveAsync().ConfigureAwait(false);
                Response response = new Response
                {
                    Message = "Temporada " + pretemporada.Nombre + " ES ACTUAL y YA ESTÁ EN JUEGO!",
                    Result = true,
                    Status = EResponseStatus.Success
                };
                return response;
            }
            catch (Exception x)
            {
                _logger.LogError("Error PreTemporadaToActual: " + x);
                Response response = new Response
                {
                    Message = "Error PreTemporadaToActual",
                    Result = false,
                    Status = EResponseStatus.Error
                };
                return response;
            }
        }

        public async Task<Response> AgregarLigaYEquiposPretemporada()
        {
            try
            {
                // obtener la temporada actual (o última en juego) y la competición Liga asociada
                TemporadaDTO temporada = await _temporadaRepository.GetUltimaTemporadaEnJuego().ConfigureAwait(false);
                if (temporada == null)
                    return new Response { Message = "No se encuentra temporada actual o última en juego", Result = false, Status = EResponseStatus.Warning };

                // obtener la competicion liga
                TemporadaCompeticionDTO temporadaCompeticion = await _temporadaCompeticionRepository.GetCompeticion(temporada.Id, LigamaniaConst.Competicion_Liga).ConfigureAwait(false);
                if (temporadaCompeticion == null)
                    return new Response { Message = "No se encuentra la competición Liga de la última temporada", Result = false, Status = EResponseStatus.Warning };

                // obtener las categorias asociadas a la liga en la temporada actual
                ICollection<TemporadaCompeticionCategoriaDTO> temporadaCompeticionCategorias = await _temporadaCompeticionCategoriaRepository.GetCategorias(temporadaCompeticion).ConfigureAwait(false);
                if (!temporadaCompeticionCategorias.Any())
                    return new Response { Message = "No se encuentran las categorías de la competición Liga de la última temporada", Result = false, Status = EResponseStatus.Warning };

                // obtener todos los equipos de la temporada actual asociados a la liga
                ICollection<TemporadaEquipoDTO> temporadaEquipos = await _temporadaEquipoRepository.GetEquiposCompeticion(temporadaCompeticion).ConfigureAwait(false);
                if (!temporadaEquipos.Any())
                    return new Response { Message = "No se encuentran los equipos de la competición Liga de la última temporada", Result = false, Status = EResponseStatus.Warning };

                // obtener la pretemporada
                TemporadaDTO pretemporada = await _temporadaRepository.FindAsync(t => t.Estado.Equals(EEstadoTemporada.EnPretemporada.ToString())).ConfigureAwait(false);
                if (pretemporada == null)
                    return new Response { Message = "No existe una PRETEMPORADA. No se puede copiar la Liga y equipos", Result = false, Status = EResponseStatus.Error };

                // crear la competición liga en la pretemporada
                TemporadaCompeticionDTO newTemporadaCompeticion = CopyTemporadaCompeticion(temporadaCompeticion, pretemporada);
                if (!await _temporadaCompeticionRepository.ExistsAsync(tc => tc.TemporadaId.Equals(pretemporada.Id) && tc.CompeticionId.Equals(temporadaCompeticion.CompeticionId)).ConfigureAwait(false))
                {
                    newTemporadaCompeticion = await _temporadaCompeticionRepository.AddAsyn(newTemporadaCompeticion).ConfigureAwait(false);
                    if (newTemporadaCompeticion == null)
                        return new Response { Message = "No se pudo insertar la competición Liga de la última temporada", Result = false, Status = EResponseStatus.Error };
                }
                //// crear las categorias liga en la pretemporada
                ICollection<TemporadaCompeticionCategoriaDTO> newTemporadaCompeticionCategorias = CopyTemporadaCompeticionCategoria(temporadaCompeticionCategorias, pretemporada);
                foreach (var newTempCompCat in newTemporadaCompeticionCategorias)
                {
                    if (!await _temporadaCompeticionCategoriaRepository.ExistsAsync(tcc => tcc.TemporadaId.Equals(pretemporada.Id) && tcc.CompeticionId.Equals(newTempCompCat.Competicion.Id)
                        && tcc.CategoriaId.Equals(newTempCompCat.Categoria.Id)).ConfigureAwait(false))
                    {
                        var insertada = await _temporadaCompeticionCategoriaRepository.AddAsyn(newTempCompCat).ConfigureAwait(false);
                        if (insertada == null)
                            return new Response { Message = "No se pudo insertar la categoría de la competición Liga de la última temporada", Result = false, Status = EResponseStatus.Error };
                    }
                }

                //// crear los mismos equipos en la pretemporada con una indicación de que son 'PROVISIONALES'
                ICollection<TemporadaEquipoDTO> newTemporadaEquipos = CopyTemporadaEquipo(temporadaEquipos, pretemporada);
                foreach (var newTempEquipo in newTemporadaEquipos)
                {
                    if (!await _temporadaEquipoRepository.ExistsAsync(te => te.TemporadaId.Equals(pretemporada.Id) && te.EquipoId.Equals(newTempEquipo.Equipo.Id)).ConfigureAwait(false))
                    {
                        var insertada = await _temporadaEquipoRepository.AddAsyn(newTempEquipo).ConfigureAwait(false);
                        if (insertada == null)
                            return new Response { Message = "No se pudo insertar el equipo de la última temporada", Result = false, Status = EResponseStatus.Error };
                    }
                }

                await _temporadaEquipoRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Liga, categorías y equipos copiados correctamente", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al agregar liga y equipos a la pretemporada: " + x);
                return new Response { Message = "Error al agregar liga y equipos a la pretemporada", Result = false, Status = EResponseStatus.Error };
            }
        }
        private TemporadaCompeticionDTO CreateTemporadaCompeticion(CompeticionDTO competicion, TemporadaDTO pretemporada)
        {
            TemporadaCompeticionDTO newTemporadaCompeticion = new TemporadaCompeticionDTO
            {
                Temporada = pretemporada,
                Activa = false,

                DescripcionEstado = string.Empty,
                EstadoActual = null,// new EstadoCompeticion_DTO();
                OperacionActual = null,// new OperacionCompeticion_DTO();

                CambiosFijos = 0,
                Competicion = competicion,
                TemporadaCompeticionOperacion = null
            };
            return newTemporadaCompeticion;
        }
        private TemporadaCompeticionDTO CopyTemporadaCompeticion(TemporadaCompeticionDTO temporadaCompeticion, TemporadaDTO pretemporada)
        {
            // ega - con mapper no funciona el addasync
            //TemporadaCompeticion_DTO newTemporadaCompeticion = _mapper.Map<TemporadaCompeticion_DTO>(temporadaCompeticion);
            TemporadaCompeticionDTO newTemporadaCompeticion = new TemporadaCompeticionDTO
            {
                Temporada = pretemporada,
                Activa = false,

                DescripcionEstado = string.Empty,
                EstadoActual = null,// new EstadoCompeticion_DTO();
                OperacionActual = null,// new OperacionCompeticion_DTO();

                CambiosFijos = temporadaCompeticion.CambiosFijos,
                Competicion = temporadaCompeticion.Competicion,
                TemporadaCompeticionOperacion = temporadaCompeticion.TemporadaCompeticionOperacion
            };
            return newTemporadaCompeticion;
        }
        private TemporadaCompeticionCategoriaDTO CreateTemporadaCompeticionCategoria(CompeticionDTO competicion, CategoriaDTO categoria, TemporadaDTO preTemporada)
        {
            TemporadaCompeticionCategoriaDTO newTempCompCat = new TemporadaCompeticionCategoriaDTO
            {
                Temporada = preTemporada,
                CompeticionId = competicion.Id,
                CategoriaId = categoria.Id,
                MarcarPichichi = false,
                NumeroMaximoJugadorEliminar = 0,
                TemporadaCompeticionCategoriaReferencia = null
            };
            return newTempCompCat;
        }
        private TemporadaCompeticionCategoriaDTO CopyTemporadaCompeticionCategoria(TemporadaCompeticionCategoriaDTO temporadaCompeticionCategoria, TemporadaDTO preTemporada)
        {
            TemporadaCompeticionCategoriaDTO newTempCompCat = new TemporadaCompeticionCategoriaDTO
            {
                Temporada = preTemporada,
                CompeticionId = temporadaCompeticionCategoria.CompeticionId,
                CategoriaId = temporadaCompeticionCategoria.CategoriaId,
                MarcarPichichi = temporadaCompeticionCategoria.MarcarPichichi,
                NumeroMaximoJugadorEliminar = temporadaCompeticionCategoria.NumeroMaximoJugadorEliminar,
                TemporadaCompeticionCategoriaReferencia = temporadaCompeticionCategoria.TemporadaCompeticionCategoriaReferencia
            };
            return newTempCompCat;
        }
        private ICollection<TemporadaCompeticionCategoriaDTO> CopyTemporadaCompeticionCategoria(ICollection<TemporadaCompeticionCategoriaDTO> temporadaCompeticionCategorias, TemporadaDTO pretemporada)
        {
            ICollection<TemporadaCompeticionCategoriaDTO> lista = new List<TemporadaCompeticionCategoriaDTO>();
            foreach (var tempCompCat in temporadaCompeticionCategorias)
            {
                //TemporadaCompeticionCategoria_DTO newTemporadaCompeticionCategoria = _mapper.Map<TemporadaCompeticionCategoria_DTO>(tempCompCat);
                TemporadaCompeticionCategoriaDTO newTemporadaCompeticionCategoria = new TemporadaCompeticionCategoriaDTO
                {
                    //newTemporadaCompeticionCategoria.Id = 0;
                    Historico = null,
                    Temporada = pretemporada,
                    TemporadaId = pretemporada.Id,
                    Categoria = tempCompCat.Categoria,
                    Competicion = tempCompCat.Competicion,
                    MarcarPichichi = tempCompCat.MarcarPichichi,
                    NumeroMaximoJugadorEliminar = tempCompCat.NumeroMaximoJugadorEliminar,
                    TemporadaCompeticionCategoriaReferencia = tempCompCat.TemporadaCompeticionCategoriaReferencia
                };

                lista.Add(newTemporadaCompeticionCategoria);
            }
            return lista;
        }
        private ICollection<TemporadaEquipoDTO> CopyTemporadaEquipo(ICollection<TemporadaEquipoDTO> temporadaEquipos, TemporadaDTO pretemporada)
        {
            ICollection<TemporadaEquipoDTO> lista = new List<TemporadaEquipoDTO>();
            foreach (var tempEquipo in temporadaEquipos)
            {
                TemporadaEquipoDTO newTemporadaEquipo = new TemporadaEquipoDTO
                {
                    //newTemporadaEquipo.Id = 0;
                    Temporada = pretemporada,
                    ConfirmadaTemporada = false,
                    PagadaTemporada = false,

                    Baja = tempEquipo.Baja,
                    Categoria = tempEquipo.Categoria,
                    Competicion = tempEquipo.Competicion,
                    Equipo = tempEquipo.Equipo,

                    Alineacion = null,
                    AlineacionCambio = null,
                    AlineacionPrevia = null,
                    Historico = null,
                    Diferencia = 0,
                    GolesContra = 0,
                    GolesFavor = 0,
                    GolesExtraContra=0,
                    GolesExtraFavor=0,
                    PartidosEmpatados = 0,
                    PartidosGanados = 0,
                    PartidosJugados = 0,
                    PartidosPerdidos = 0,
                    Puntos = 0
                };

                lista.Add(newTemporadaEquipo);
            }
            return lista;
        }

        public async Task<Response> ConfirmarDesconfirmarTemporada(TemporadaEquipoAccion equipo)
        {
            try
            {
                if (equipo == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };

                TemporadaEquipoDTO temporadaEquipo = await _temporadaEquipoRepository.GetByIdIncludingAsync(equipo.Id, te => te.Categoria, te => te.Temporada).ConfigureAwait(false);
                if (temporadaEquipo == null || (equipo.Categoria != null && equipo.Categoria.Equals(LigamaniaConst.Categoria_SinCategoria))) // viene de no tener categoría asignada, por tanto hay que crearlo en la temporada actual
                {
                    if (equipo.Accion)
                    {
                        EquipoDTO equipoDto = _equipoRepository.GetById(equipo.Id);
                        if (equipoDto == null)
                            return new Response { Message = "No se encuentra equipo con id " + equipo.Id, Result = false, Status = EResponseStatus.Warning };
                        var temporadaActual = await GetTemporadaActual().ConfigureAwait(false);
                        if (temporadaActual == null) temporadaActual = await GetPreTemporada().ConfigureAwait(false);
                        var competicion = await _competicionRepository.GetByNameAsync(LigamaniaConst.Competicion_Liga).ConfigureAwait(false);
                        CategoriaDTO categoria = await GetCategoria(equipo.NuevaCategoria).ConfigureAwait(false);//, temporadaEquipo.Temporada);
                        temporadaEquipo = new TemporadaEquipoDTO
                        {
                            Baja = false,
                            Equipo = equipoDto,
                            Temporada = temporadaActual,
                            Competicion = competicion,
                            Categoria = categoria
                        };
                        temporadaEquipo = await _temporadaEquipoRepository.AddAsyn(temporadaEquipo).ConfigureAwait(false);
                        await _temporadaEquipoRepository.SaveAsync().ConfigureAwait(false);
                    }
                }
                temporadaEquipo.ConfirmadaTemporada = equipo.Accion;
                if (temporadaEquipo.ConfirmadaTemporada)
                {
                    // chequear si la categoría cambió
                    if (!equipo.NuevaCategoria.Equals(temporadaEquipo.Categoria.Nombre))
                    {
                        //Categoria_DTO categoria = await GetCategoria(equipo.NuevaCategoria, temporadaEquipo.Temporada);
                        CategoriaDTO categoria = await GetCategoria(equipo.NuevaCategoria).ConfigureAwait(false);//, temporadaEquipo.Temporada);
                        temporadaEquipo.Categoria = categoria;
                    }
                }

                await _temporadaEquipoRepository.UpdateAsyn(temporadaEquipo, temporadaEquipo.Id).ConfigureAwait(false);
                await _temporadaEquipoRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = equipo.Accion ? "Equipo Confirmado" : "Equipo Desconfirmado", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al confirmar/desconfirmar temporada: " + x);
                return new Response { Message = "Error al confirmar/desconfirmar temporada", Result = false, Status = EResponseStatus.Error };
            }
        }

        private async Task<CategoriaDTO> GetCategoria(string nuevaCategoria)
        {
            var categoria = await _categoriaRepository.GetByNameAsync(nuevaCategoria).ConfigureAwait(false);
            return categoria;
        }

        //private async Task<CategoriaDTO> GetCategoria(string nuevaCategoria, TemporadaDTO temporada)
        //{
        //    //var temporada = _temporadaRepository.GetActual();
        //    var competicion = await _temporadaCompeticionRepository.GetCompeticion(temporada.Id, eTipoCompeticion.Liga).ConfigureAwait(false);
        //    var categorias = await _temporadaCompeticionCategoriaRepository.GetCategorias(competicion).ConfigureAwait(false);
        //    var categoria = categorias.FirstOrDefault(c => c.Categoria.Nombre.Equals(nuevaCategoria));
        //    return categoria.Categoria;
        //}
        public async Task<Response> PagarTemporada(TemporadaEquipoAccion equipo)
        {
            try
            {
                if (equipo == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };

                TemporadaEquipoDTO temporadaEquipo = await _temporadaEquipoRepository.GetAsync(equipo.Id).ConfigureAwait(false);
                if (temporadaEquipo == null)
                    return new Response { Message = "No se encuentra equipo con id " + equipo.Id, Result = false, Status = EResponseStatus.Warning };

                temporadaEquipo.PagadaTemporada = equipo.Accion;
                if (temporadaEquipo.PagadaTemporada) temporadaEquipo.ConfirmadaTemporada = true;
                await _temporadaEquipoRepository.UpdateAsyn(temporadaEquipo, temporadaEquipo.Id).ConfigureAwait(false);
                await _temporadaEquipoRepository.SaveAsync().ConfigureAwait(false);
                return new Response
                {
                    Message = equipo.Accion ? "Pagada temporada del equipo " + temporadaEquipo.Id : "NO Pagada temporada del equipo " + temporadaEquipo.Id,
                    Result = true,
                    Status = EResponseStatus.Success
                };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al pagar temporada: " + x);
                return new Response { Message = "Error al pagar la temporada", Result = false, Status = EResponseStatus.Error };
            }
        }
        public async Task<Response> DarBajaTemporada(TemporadaEquipoAccion equipo)
        {
            try
            {
                if (equipo == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };

                TemporadaEquipoDTO temporadaEquipo = null;
                temporadaEquipo = await _temporadaEquipoRepository.GetByIdIncludingAsync(equipo.Id, te => te.Equipo).ConfigureAwait(false);

                if (temporadaEquipo == null)
                    return new Response { Message = "No se encuentra equipo con id " + equipo.Id, Result = false, Status = EResponseStatus.Warning };

                temporadaEquipo.Baja = equipo.Accion;
                await _temporadaEquipoRepository.UpdateAsyn(temporadaEquipo, temporadaEquipo.Id).ConfigureAwait(false);
                temporadaEquipo.Equipo.Baja = true;
                await _temporadaEquipoRepository.SaveAsync().ConfigureAwait(false);
                return new Response
                {
                    Message = equipo.Accion ? "Baja del equipo " + temporadaEquipo.Id : "Alta del equipo " + temporadaEquipo.Id,
                    Result = true,
                    Status = EResponseStatus.Success
                };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al dar de baja en la temporada: " + x);
                return new Response { Message = "Error al dar de baja en la temporada", Result = false, Status = EResponseStatus.Error };
            }
        }
        public async Task<Response> LimpiarBaseDatos(int id)
        {
            try
            {
                // limpiar tabla alineacionCambio
                var alicambios = _alineacionCambiosRepository.GetAll();
                await _alineacionCambiosRepository.DeleteRangeAsyn(alicambios.ToList()).ConfigureAwait(false);

                // limpiar tabla alineacionPrevia
                var aliprevias = _alineacionPreviaRepository.GetAll();
                await _alineacionPreviaRepository.DeleteRangeAsyn(aliprevias.ToList()).ConfigureAwait(false);

                // insertar en historico lo que hay en alineaciones
                var alineaciones = _alineacionRepository.GetAll();
                List<AlineacionHistoricoDTO> aliHists = new List<AlineacionHistoricoDTO>();
                foreach (var ali in alineaciones)
                {
                    AlineacionHistoricoDTO aliHist = _mapper.Map<AlineacionHistoricoDTO>(ali);
                    aliHists.Add(aliHist);
                }
                await _alineacionHistoricoRepository.InsertHistorico(aliHists).ConfigureAwait(false);

                await _alineacionRepository.DeleteRangeAsyn(alineaciones.ToList()).ConfigureAwait(false);

                var controlusuarios = _controlUsuarioRepository.GetAll();
                await _controlUsuarioRepository.DeleteRangeAsyn(controlusuarios.ToList()).ConfigureAwait(false);

                //foreach (var cu in controlusuarios)
                //    await _controlUsuarioRepository.DeleteAsyn(cu);

                await _alineacionRepository.SaveAsync().ConfigureAwait(false);

                return new Response()
                {
                    Message = "Base de datos actualizada con la temporada finalizada",
                    Result = true,
                    Status = EResponseStatus.Success
                };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al limpiar los datos de la temporada anterior: " + x);
                return new Response { Message = "Error al limpiar los datos de la temporada anterior", Result = false, Status = EResponseStatus.Error };
            }
        }
        public async Task<Response> ConvertirAHistorica(int id)
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetAsync(id).ConfigureAwait(false);
                if (temporada != null)
                {
                    temporada.Actual = false;
                    await _temporadaRepository.UpdateAsyn(temporada, id).ConfigureAwait(false);
                    await _temporadaRepository.SaveAsync().ConfigureAwait(false);
                }
                return new Response()
                {
                    Message = string.Empty,
                    Result = true,
                    Status = EResponseStatus.Success
                };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al convertir la temporada a histórica: " + x);
                return new Response { Message = "Error al convertir la temporada a histórica", Result = false, Status = EResponseStatus.Error };
            }
        }
        public async Task<Response> AgregarNuevaNoticia(NoticiaViewModel noticiaVM)
        {
            try
            {
                NoticiaDTO noticia = new NoticiaDTO
                {
                    Activa = true,
                    Fecha = DateTime.UtcNow,
                    Texto = noticiaVM.Noticia
                };
                noticia = await _noticiaRepository.AddAsyn(noticia).ConfigureAwait(false);
                await _noticiaRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Noticia agregada", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al agregar una noticia: " + x);
                return new Response { Message = "Error al agregar la noticia", Result = false, Status = EResponseStatus.Error };
            }
        }
        public async Task<NoticiaViewModel> GetNoticia(int id)
        {
            NoticiaDTO noticia = await _noticiaRepository.GetAsync(id).ConfigureAwait(false);
            NoticiaViewModel noticiaVM = _mapper.Map<NoticiaViewModel>(noticia);
            return noticiaVM;
        }
        public async Task<Response> EditarNoticia(NoticiaViewModel noticiaVM)
        {
            try
            {
                if (noticiaVM == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };
                NoticiaDTO noticia = await _noticiaRepository.GetAsync(noticiaVM.Id).ConfigureAwait(false);
                if (noticia != null)
                {
                    noticia.Activa = true;
                    noticia.Fecha = DateTime.UtcNow;
                    noticia.Texto = noticiaVM.Noticia;
                    await _noticiaRepository.UpdateAsyn(noticia, noticia.Id).ConfigureAwait(false);
                    await _noticiaRepository.SaveAsync().ConfigureAwait(false);
                    return new Response { Message = "Noticia modificada", Result = true, Status = EResponseStatus.Success };
                }
                return new Response { Message = "Error al modificar la noticia", Result = false, Status = EResponseStatus.Error };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al editar una noticia: " + x);
                return new Response { Message = "Error al editar la noticia", Result = false, Status = EResponseStatus.Error };
            }
        }
        public async Task<Response> BorrarNoticia(NoticiaViewModel noticiaVM)
        {
            try
            {
                if (noticiaVM == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };

                NoticiaDTO noticia = await _noticiaRepository.GetAsync(noticiaVM.Id).ConfigureAwait(false);
                if (noticia != null)
                {
                    await _noticiaRepository.DeleteAsyn(noticia).ConfigureAwait(false);
                    await _noticiaRepository.SaveAsync().ConfigureAwait(false);
                    return new Response { Message = "Noticia eliminada", Result = true, Status = EResponseStatus.Success };
                }
                return new Response { Message = "Error al borrar la noticia", Result = false, Status = EResponseStatus.Error };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al borrar una noticia: " + x);
                return new Response { Message = "Error al borrar la noticia", Result = false, Status = EResponseStatus.Error };
            }
        }
        public async Task<Response> DesactivarTodasNoticias()
        {
            try
            {
                ICollection<NoticiaDTO> noticias = await _noticiaRepository.GetAllAsyn().ConfigureAwait(false);
                foreach (var noticia in noticias)
                {
                    noticia.Activa = false;
                    await _noticiaRepository.UpdateAsyn(noticia, noticia.Id).ConfigureAwait(false);
                }
                await _noticiaRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Noticias desactivadas", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al desactivar todas las noticias: " + x);
                return new Response { Message = "Error al desactivar todas las noticias", Result = false, Status = EResponseStatus.Error };
            }
        }
        public async Task<Response> ActivarTodasNoticias()
        {
            try
            {
                ICollection<NoticiaDTO> noticias = await _noticiaRepository.GetAllAsyn().ConfigureAwait(false);
                foreach (var noticia in noticias)
                {
                    noticia.Activa = true;
                    await _noticiaRepository.UpdateAsyn(noticia, noticia.Id).ConfigureAwait(false);
                }
                await _noticiaRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Noticias desactivadas", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al activar todas las noticias: " + x);
                return new Response { Message = "Error al activar todas las noticias", Result = false, Status = EResponseStatus.Error };
            }
        }
        public async Task<Response> DesactivarNoticia(NoticiaViewModel noticiaVM)
        {
            try
            {
                if (noticiaVM == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };
                NoticiaDTO noticia = await _noticiaRepository.GetAsync(noticiaVM.Id).ConfigureAwait(false);
                if (noticia != null)
                {
                    noticia.Activa = false;
                    await _noticiaRepository.UpdateAsyn(noticia, noticia.Id).ConfigureAwait(false);
                    await _noticiaRepository.SaveAsync().ConfigureAwait(false);
                    return new Response { Message = "Noticia desactivada", Result = true, Status = EResponseStatus.Success };
                }
                return new Response { Message = "Error al desactivar la noticia", Result = false, Status = EResponseStatus.Error };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al desactivar una noticia: " + x);
                return new Response { Message = "Error al desactivar la noticia", Result = false, Status = EResponseStatus.Error };
            }
        }
        public async Task<int> CheckNuevoEquipo(RegisterViewModel equipo)
        {
            if (equipo == null) return 0;

            if (!equipo.CheckSoloEquipo)
            {
                var user = await _userManager.FindByNameAsync(equipo.UserName).ConfigureAwait(false);
                if (user != null) return 1;

                user = await _userManager.FindByEmailAsync(equipo.Email).ConfigureAwait(false);
                if (user != null) return 2;
            }

            bool existEquipo = await _userManager.FindByEquipoAsync(equipo.Equipo).ConfigureAwait(false);
            if (existEquipo) return 3;

            return 0;
        }
        public async Task<Response> NuevoEquipo(RegisterViewModel equipo)
        {
            try
            {
                var message = string.Empty;
                ApplicationUser user;
                if (!equipo.CheckSoloEquipo)
                {
                    user = await CrearNuevoEntrenador(equipo).ConfigureAwait(false);
                    message = "Entrenador creado y ";
                }
                else
                    user = await _userManager.FindByNameAsync(equipo.UserName).ConfigureAwait(false);

                if (user != null)
                {
                    EquipoDTO nuevoEquipo = new EquipoDTO
                    {
                        Baja = false,
                        ApplicationUser = user,
                        EsBot = equipo.EsBot,
                        Nombre = equipo.Equipo
                    };
                    await _equipoRepository.AddAsyn(nuevoEquipo).ConfigureAwait(false);
                    await _equipoRepository.SaveAsync().ConfigureAwait(false);
                    //TemporadaDTO pretemporada = await GetPreTemporada().ConfigureAwait(false);
                    //CompeticionDTO competicion = await _competicionRepository.GetByNameAsync(LigamaniaConst.Competicion_Liga).ConfigureAwait(false);
                    //CategoriaDTO categoria = await _categoriaRepository.GetByNameAsync(equipo.CategoriaPreferida).ConfigureAwait(false);
                    //if (categoria == null) categoria = await _categoriaRepository.GetByNameAsync(LigamaniaConst.Categoria_SilverB).ConfigureAwait(false);
                    //TemporadaEquipoDTO temporadaEquipo = new TemporadaEquipoDTO
                    //{
                    //    Equipo = nuevoEquipo,
                    //    Baja = false,
                    //    Temporada = pretemporada,
                    //    Categoria = categoria,
                    //    Competicion = competicion,
                    //    ConfirmadaTemporada = false,
                    //    PagadaTemporada = false
                    //};
                    //await _temporadaEquipoRepository.AddAsyn(temporadaEquipo).ConfigureAwait(false);

                    //await _temporadaEquipoRepository.SaveAsync().ConfigureAwait(false);

                    return new Response { Message = message + "Equipo creado", Result = true, Status = EResponseStatus.Success };
                }
                return new Response { Message = "Error al crear el equipo", Result = false, Status = EResponseStatus.Error };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al registrar un nuevo equipo: " + x);
                return new Response { Message = "Error al registar un nuevo equipo", Result = false, Status = EResponseStatus.Error };
            }
        }
        public async Task<Response> SustituirEquipo(TemporadaEquipoAccion sustitucion)
        {
            try
            {
                if (sustitucion == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };
                EquipoDTO equipoActual = await _equipoRepository.GetByNameAsync(sustitucion.Equipo).ConfigureAwait(false);
                EquipoDTO equipoNuevo = await _equipoRepository.GetByNameAsync(sustitucion.NuevoEquipo).ConfigureAwait(false);

                if (equipoActual == null) return new Response { Message = "Equipo actual no encontrado", Result = false, Status = EResponseStatus.Warning };
                if (equipoNuevo == null) return new Response { Message = "Equipo nuevo no encontrado", Result = false, Status = EResponseStatus.Warning };

                ICollection<TemporadaEquipoDTO> temporadaEquipoActuales = await _temporadaEquipoRepository.FindAllIncludingAsync(
                    te => te.Temporada.Actual && te.EquipoId.Equals(equipoActual.Id), te => te.Equipo, te => te.Temporada, te => te.Competicion, te => te.Categoria).ConfigureAwait(false);
                ICollection<TemporadaEquipoDTO> temporadaEquipoNuevos = await _temporadaEquipoRepository.FindAllIncludingAsync(
                    te => te.Temporada.Actual && te.EquipoId.Equals(equipoNuevo.Id), te => te.Equipo).ConfigureAwait(false);

                if (temporadaEquipoActuales == null) return new Response { Message = "Equipos actuales no encontrado en la temporada actual", Result = false, Status = EResponseStatus.Warning };
                if (temporadaEquipoNuevos == null) return new Response { Message = "Equipos nuevos no encontrado en la temporada actual", Result = false, Status = EResponseStatus.Warning };

                ICollection<TemporadaClasificacionDTO> clasificaciones = await _temporadaClasificacionRepository.FindAllIncludingAsync(
                    tc => tc.Temporada.Actual && tc.EquipoId.Equals(equipoActual.Id), tc => tc.Equipo).ConfigureAwait(false);
                ICollection<TemporadaPartidoDTO> partidos = await _temporadaPartidoRepository.FindAllIncludingAsync(
                    tp => tp.Temporada.Actual && tp.EquipoAId.Equals(equipoActual.Id) || tp.EquipoBId.Equals(equipoActual.Id), tp => tp.EquipoA, tp => tp.EquipoB).ConfigureAwait(false);


                // copiar los datos del equipoActual en el nuevo
                foreach (var tempEquiActual in temporadaEquipoActuales)
                {
                    tempEquiActual.Baja = true;
                    await _temporadaEquipoRepository.UpdateAsyn(tempEquiActual, tempEquiActual.Id).ConfigureAwait(false);

                    // si no existe el equipo nuevo, lo creamos, sino, lo editamos
                    TemporadaEquipoDTO equiNuevo = await _temporadaEquipoRepository.FindAsync(te => te.Temporada.Actual &&
                        te.EquipoId.Equals(equipoNuevo.Id) && te.CompeticionId.Equals(tempEquiActual.CompeticionId)
                        && te.CategoriaId.Equals(tempEquiActual.CategoriaId)).ConfigureAwait(false);
                    if (equiNuevo == null)
                    {
                        TemporadaEquipoDTO tempEquipoNuevo = new TemporadaEquipoDTO
                        {
                            Temporada = tempEquiActual.Temporada,
                            Equipo = equipoNuevo,
                            CategoriaId = tempEquiActual.CategoriaId,
                            CompeticionId = tempEquiActual.CompeticionId,
                            ConfirmadaTemporada = tempEquiActual.ConfirmadaTemporada,
                            Diferencia = tempEquiActual.Diferencia,
                            GolesContra = tempEquiActual.GolesContra,
                            GolesFavor = tempEquiActual.GolesFavor,
                            GolesExtraFavor = tempEquiActual.GolesExtraFavor,
                            GolesExtraContra = tempEquiActual.GolesExtraContra,
                            PagadaTemporada = tempEquiActual.PagadaTemporada,
                            PartidosEmpatados = tempEquiActual.PartidosEmpatados,
                            PartidosGanados = tempEquiActual.PartidosGanados,
                            PartidosJugados = tempEquiActual.PartidosJugados,
                            PartidosPerdidos = tempEquiActual.PartidosPerdidos,
                            Puntos = tempEquiActual.Puntos,
                            AlineacionLibre = true
                        };
                        equiNuevo = await _temporadaEquipoRepository.AddAsyn(tempEquipoNuevo).ConfigureAwait(false);
                    }
                    else
                    {
                        equiNuevo.CategoriaId = tempEquiActual.CategoriaId;
                        equiNuevo.CompeticionId = tempEquiActual.CompeticionId;
                        equiNuevo.ConfirmadaTemporada = tempEquiActual.ConfirmadaTemporada;
                        equiNuevo.Diferencia = tempEquiActual.Diferencia;
                        equiNuevo.GolesContra = tempEquiActual.GolesContra;
                        equiNuevo.GolesFavor = tempEquiActual.GolesFavor;
                        equiNuevo.GolesExtraContra = tempEquiActual.GolesExtraContra;
                        equiNuevo.GolesExtraFavor = tempEquiActual.GolesExtraFavor;
                        equiNuevo.PagadaTemporada = tempEquiActual.PagadaTemporada;
                        equiNuevo.PartidosEmpatados = tempEquiActual.PartidosEmpatados;
                        equiNuevo.PartidosGanados = tempEquiActual.PartidosGanados;
                        equiNuevo.PartidosJugados = tempEquiActual.PartidosJugados;
                        equiNuevo.PartidosPerdidos = tempEquiActual.PartidosPerdidos;
                        equiNuevo.Puntos = tempEquiActual.Puntos;
                        equiNuevo.AlineacionLibre = true;
                        await _temporadaEquipoRepository.UpdateAsyn(equiNuevo, equiNuevo.Id).ConfigureAwait(false);
                    }
                    ICollection<AlineacionCambioDTO> alineacionCambios = await _alineacionCambiosRepository.FindAllAsync
                        (ac => ac.Temporada.Actual && ac.Equipo_ID.Equals(tempEquiActual.Id)).ConfigureAwait(false);
                    ICollection<AlineacionPreviaDTO> alineacionPrevias = await _alineacionPreviaRepository.FindAllAsync
                        (ap => ap.Temporada.Actual && ap.Equipo_ID.Equals(tempEquiActual.Id)).ConfigureAwait(false);
                    ICollection<AlineacionDTO> alineaciones = await _alineacionRepository.FindAllAsync
                        (a => a.Temporada.Actual && a.Equipo_ID.Equals(tempEquiActual.Id)).ConfigureAwait(false);

                    foreach (var ali in alineacionCambios)
                    {
                        ali.Equipo_ID = equiNuevo.Id;
                        await _alineacionCambiosRepository.UpdateAsyn(ali, ali.Id).ConfigureAwait(false);
                    }

                    foreach (var ali in alineacionPrevias)
                    {
                        ali.Equipo_ID = equiNuevo.Id;
                        await _alineacionPreviaRepository.UpdateAsyn(ali, ali.Id).ConfigureAwait(false);
                    }

                    foreach (var ali in alineaciones)
                    {
                        ali.Equipo_ID = equiNuevo.Id;
                        await _alineacionRepository.UpdateAsyn(ali, ali.Id).ConfigureAwait(false);
                    }
                }

                foreach (var clasi in clasificaciones)
                {
                    clasi.EquipoId = equipoNuevo.Id;
                    await _temporadaClasificacionRepository.UpdateAsyn(clasi, clasi.Id).ConfigureAwait(false);
                }

                foreach (var partido in partidos)
                {
                    if (partido.EquipoAId.Equals(equipoActual.Id)) partido.EquipoAId = equipoNuevo.Id;
                    if (partido.EquipoBId.Equals(equipoActual.Id)) partido.EquipoBId = equipoNuevo.Id;
                    await _temporadaPartidoRepository.UpdateAsyn(partido, partido.Id).ConfigureAwait(false);
                }


                await _alineacionRepository.SaveAsync().ConfigureAwait(false);

                return new Response { Message = "Equipo sustituido correctamente", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al sustituir un equipo por otro: " + x);
                return new Response { Message = "Error al sustituir un equipo por otro", Result = false, Status = EResponseStatus.Error };
            }
        }

        public async Task<ApplicationUser> CrearNuevoUsuarioSinConfirmar(RegisterViewModel registro)
        {
            try
            {
                var user = new ApplicationUser
                {
                    UserName = registro.UserName,
                    Email = registro.Email,
                    City = registro.City,
                    CompartirGrupo = registro.CategoriaPreferida,
                    Conocimiento = registro.Conocimiento,
                    IsBot = registro.EsBot,
                    PhoneNumber = registro.PhoneNumber,
                    Whatsap = registro.Whatsapp,
                    IsEntrenador = true,
                    UserState = eUserState.Registered,
                    Equipo = registro.Equipo
                };
                registro.CheckSoloEquipo = true;
                var checkEquipo = await CheckNuevoEquipo(registro).ConfigureAwait(false);
                if (checkEquipo != 0)
                {
                    _logger.LogError("Error al chequear el nombre de equipo: " + registro.Equipo);
                    return null;
                }

                var result = await _userManager.CreateAsync(user, registro.Password).ConfigureAwait(false);
                if (result.Succeeded)
                {
                    // el equipo hay que crearlo cuando se confirme el registro (Desde la operación Confirmar)
                    //var respEquipo = await NuevoEquipo(registro).ConfigureAwait(false);
                    //if (!respEquipo.Result)
                    //{
                    //    _logger.LogError("Error al crear el equipo: " + registro.Equipo);
                    //    return null;
                    //}

                    // asignar rol de invitado y entrenador
                    //await _userManager.AddToRoleAsync(user, "Entrenador").ConfigureAwait(false);
                    await _userManager.AddToRoleAsync(user, "Invitado").ConfigureAwait(false);
                    return user;
                }
                _logger.LogError("Error al registrar un nuevo usuario");
                return null;
            }
            catch (Exception x)
            {
                _logger.LogError("Error al registrar un nuevo usuario: " + x);
                return null;
            }
        }
        public async Task SendVerificationEmail(ApplicationUser user)
        {
            string message;
            message = "Ya has sido registrado en Ligamanía.";
            await _emailService.Send(
                to: user.Email,
                subject: "Registro en Ligamania",
                html: $@"{message}
                         <p>Gracias! </p>
                         <p>En breve recibirás un email de confirmación y podrás acceder a tu zona privada</p>
                         <p>No responda a este email. Es un correo automático</p>"
            ).ConfigureAwait(false);

            message = $"<p>Se ha registrado un nuevo usuario en Ligamanía, que está pendiente de confirmación: </p>";
            message += $"<p> Usuario: "+ user.UserName+"</p>";
            message += $"<p> Email: " + user.Email + "</p>";
            message += $"<p> Teléfono: " + user.PhoneNumber + "</p>";
            message += $"<p> Nombre de equipo: " + user.Equipo + "</p>";
            message += $"<p> Categoría preferida: " + user.CompartirGrupo + "</p>";
            message += $"<p> Ciudad: " + user.City + "</p>";
            message += $"<p> Como nos conoció: " + user.Conocimiento + "</p>";
            message += $"<p> Quiere recibir whatsapp: ";
            message += user.Whatsap ? "SI" : "NO";
            message += "</p>";

            await _emailService.SendRegistrationEmail(
                subject:"Nuevo registro en Ligamanía", 
                html:$@"<h4>Registro en Ligamanía - Pendiente de confirmación!</h4>
                        {message}
                        <p>Correo automático de Ligamanía. Por favor, no responda a este email</p>")
                .ConfigureAwait(false);
        }
        public async Task SendConfirmationEmail(ApplicationUser user)
        {
            string message;
            message = "Enhorabuena! Ya eres nuevo entrenador en Ligamanía. Ahora solo queda que prepares tu equipo y A JUGAR!!!";
            await _emailService.Send(
                to: user.Email,
                subject: "Confirmación en Ligamania",
                html: $@"<h4>Confirmación en Ligamania</h4>
                         {message}
                         <p>Un saludo!</p>"
            ).ConfigureAwait(false);
        }
        private async Task<ApplicationUser> CrearNuevoEntrenador(RegisterViewModel equipo)
        {
            try
            {
                var user = new ApplicationUser
                {
                    UserName = equipo.UserName,
                    Email = equipo.Email,
                    City = equipo.City,
                    CompartirGrupo = equipo.CategoriaPreferida,
                    Conocimiento = equipo.Conocimiento,
                    IsBot = equipo.EsBot,
                    PhoneNumber = equipo.PhoneNumber,
                    Whatsap = equipo.Whatsapp,
                    IsEntrenador = true,
                    UserState = eUserState.Confirmed
                };
                var result = await _userManager.CreateAsync(user, equipo.Password).ConfigureAwait(false);
                if (result.Succeeded)
                {
                    // asignar rol de invitado y entrenador
                    await _userManager.AddToRoleAsync(user, "Entrenador").ConfigureAwait(false);
                    await _userManager.AddToRoleAsync(user, "Invitado").ConfigureAwait(false);
                    return user;
                }
                _logger.LogError("Error al registrar un nuevo entrenador");
                return null;
            }
            catch (Exception x)
            {
                _logger.LogError("Error al registrar un nuevo entrenador: " + x);
                return null;
            }
        }

        public async Task<Response> AccionSobreEntrenador(AccionUsuarioViewModel accion)
        {
            try
            {
                var entrenador = await _userManager.FindByNameAsync(accion.Entrenador).ConfigureAwait(false);
                if (entrenador == null)
                    return new Response { Message = "No se encuentra el entrenador", Result = false, Status = EResponseStatus.Warning };
                var nuevoEstado = accion.Accion;
                switch (nuevoEstado)
                {
                    case "confirmar": await ConfirmarEntrenador(entrenador).ConfigureAwait(false); break;
                    case "registrar": entrenador.UserState = eUserState.Registered; break;
                    case "baja": entrenador.UserState = eUserState.Removed; break;
                    case "noEsEntrenador": entrenador.IsEntrenador = false; break;
                    case "esEntrenador": entrenador.IsEntrenador = true; break;
                    case "noEsBot": entrenador.IsBot = false; break;
                    case "esBot": entrenador.IsBot = true; break;
                    default: break;
                }
                var setModificar = await _userManager.UpdateAsync(entrenador).ConfigureAwait(false);
                if (!setModificar.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting UserState parameters for user with ID '{entrenador.Id}'.");
                }
                return new Response { Message = "Entrenador modificado", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                return new Response { Message = "Error al editar entrenador", Result = false, Status = EResponseStatus.Error };
            }
        }

        private async Task ConfirmarEntrenador(ApplicationUser entrenador)
        {
            RegisterViewModel equipo = new RegisterViewModel
            {
                UserName = entrenador.UserName,
                CategoriaPreferida = entrenador.CompartirGrupo,
                CheckSoloEquipo = true,
                Equipo = entrenador.Equipo,
                EsBot = entrenador.IsBot
            };
            var response = await NuevoEquipo(equipo).ConfigureAwait(false);
            if (response.Result)
            {
                var user = await _userManager.FindByNameAsync(equipo.UserName).ConfigureAwait(false);
                await _userManager.AddToRoleAsync(user, "Entrenador").ConfigureAwait(false);
                entrenador.UserState = eUserState.Confirmed;
                await SendConfirmationEmail(user).ConfigureAwait(false);
            }
            else
                throw new Exception("Error al crear el equipo");
        }

        public async Task<List<CompeticionCategoriaViewModel>> GetAllCompeticiones()
        {
            var l = await _competicionCategoriaRepository.GetAllIncludingAsync(c => c.Competicion, c => c.Categoria).ConfigureAwait(false);
            ICollection<CompeticionCategoriaDTO> compCatList = l.ToList();
            List<CompeticionCategoriaViewModel> lista =
                _mapper.Map<List<CompeticionCategoriaDTO>, List<CompeticionCategoriaViewModel>>(compCatList.ToList());
            return lista;
        }
        public async Task<List<TemporadaCompeticionCategoriaViewModel>> GetCompeticionesActivas(TemporadaDTO temporada)
        {
            if (temporada == null) return null;
            List<TemporadaCompeticionCategoriaViewModel> lista = new List<TemporadaCompeticionCategoriaViewModel>();
            var competicionesActivas = await _temporadaCompeticionRepository.GetCompeticionesActivas(temporada).ConfigureAwait(false);
            foreach (var comp in competicionesActivas)
            {
                var categoriasActivas = await _temporadaCompeticionCategoriaRepository.GetCategorias(comp).ConfigureAwait(false);
                foreach (var cat in categoriasActivas)
                {
                    TemporadaCompeticionCategoriaViewModel vm = _mapper.Map<TemporadaCompeticionCategoriaViewModel>(cat);
                    vm.CambiosFijos = comp.CambiosFijos;
                    //TemporadaCompeticionCategoriaViewModel vm = new TemporadaCompeticionCategoriaViewModel
                    //{
                    //    Categoria = cat.Categoria.Nombre,
                    //    Competicion = comp.Competicion.Nombre,
                    //    IdCategoria = cat.Categoria.Id,
                    //    IdCompeticion = comp.Competicion.Id
                    //};
                    lista.Add(vm);
                }
            }
            return lista;
        }
        public async Task<Response> ActivarCompeticion(PreparacionTemporadaViewModel competicionToActivar)
        {
            try
            {
                if (competicionToActivar == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };

                // Copiar los datos de la competición que se quiere activar de la temporada pasada a ésta
                TemporadaDTO ultimaTemporada = await GetTemporadaFinalizada().ConfigureAwait(false);

                TemporadaDTO preTemporada = await GetPreTemporada().ConfigureAwait(false);

                TemporadaCompeticionDTO temporadaCompeticion = await _temporadaCompeticionRepository
                    .GetCompeticion(ultimaTemporada.Id, competicionToActivar.IdCompeticion).ConfigureAwait(false);

                TemporadaCompeticionCategoriaDTO temporadaCompeticionCategoria = await _temporadaCompeticionCategoriaRepository
                    .GetCategoria(ultimaTemporada.Id, competicionToActivar.IdCompeticion, competicionToActivar.IdCategoria).ConfigureAwait(false);

                // copiar la competición en la pretemporada si no existe, activar si ya existe
                TemporadaCompeticionDTO newTemporadaCompeticion = await _temporadaCompeticionRepository
                    .FindAsync(tc => tc.TemporadaId.Equals(preTemporada.Id) && tc.CompeticionId.Equals(competicionToActivar.IdCompeticion)).ConfigureAwait(false);
                TemporadaCompeticionCategoriaDTO newTemporadaCompeticionCategoria = await _temporadaCompeticionCategoriaRepository
                    .FindAsync(tcc => tcc.TemporadaId.Equals(preTemporada.Id) && tcc.CompeticionId.Equals(competicionToActivar.IdCompeticion) && tcc.CategoriaId.Equals(competicionToActivar.IdCategoria)).ConfigureAwait(false);

                CompeticionDTO competicion = _competicionRepository.Get(competicionToActivar.IdCompeticion);
                CategoriaDTO categoria = _categoriaRepository.Get(competicionToActivar.IdCategoria);

                if (newTemporadaCompeticion == null)
                {
                    if (temporadaCompeticion != null)
                        newTemporadaCompeticion = CopyTemporadaCompeticion(temporadaCompeticion, preTemporada);
                    else
                        newTemporadaCompeticion = CreateTemporadaCompeticion(competicion, preTemporada);
                    newTemporadaCompeticion.Activa = true; // y activarla
                    await _temporadaCompeticionRepository.AddAsyn(newTemporadaCompeticion).ConfigureAwait(false);
                }
                else
                {
                    newTemporadaCompeticion.Activa = true; // y activarla
                    await _temporadaCompeticionRepository.UpdateAsyn(newTemporadaCompeticion, newTemporadaCompeticion.Id).ConfigureAwait(false);
                }
                // copiar la categoria en la pretemporada
                if (newTemporadaCompeticionCategoria == null)
                {
                    if (temporadaCompeticionCategoria != null)
                        newTemporadaCompeticionCategoria = CopyTemporadaCompeticionCategoria(temporadaCompeticionCategoria, preTemporada);
                    else
                        newTemporadaCompeticionCategoria = CreateTemporadaCompeticionCategoria(competicion, categoria, preTemporada);
                    await _temporadaCompeticionCategoriaRepository.AddAsyn(newTemporadaCompeticionCategoria).ConfigureAwait(false);
                }
                else
                {
                    newTemporadaCompeticionCategoria.UpdatedDate = DateTime.Now;
                    await _temporadaCompeticionCategoriaRepository.UpdateAsyn(newTemporadaCompeticionCategoria, newTemporadaCompeticionCategoria.Id).ConfigureAwait(false);
                }
                await _temporadaCompeticionCategoriaRepository.SaveAsync().ConfigureAwait(false);

                return new Response { Message = "Competición y Categoría activada para la temporada", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("[ActivandoCompeticion]: " + x);
                return new Response { Message = "Error activando competición: " + x, Status = EResponseStatus.Error, Result = false };
            }
        }
        public async Task<Response> DesactivarCompeticion(PreparacionTemporadaViewModel competicionToActivar)
        {
            try
            {
                if (competicionToActivar == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };

                // Copiar los datos de la competición que se quiere activar de la temporada pasada a ésta
                TemporadaDTO temporada = await GetTemporadaActual().ConfigureAwait(false);
                if (temporada == null) temporada = await GetPreTemporada().ConfigureAwait(false);
                TemporadaCompeticionDTO temporadaCompeticion = await _temporadaCompeticionRepository
                    .GetCompeticion(temporada.Id, competicionToActivar.IdCompeticion).ConfigureAwait(false);

                await DesactivarCompeticion(temporadaCompeticion).ConfigureAwait(false);

                return new Response { Message = "Competición desactivada para la temporada", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("[DesactivandoCompeticion]: " + x);
                return new Response { Message = "Error desactivando competición: " + x, Status = EResponseStatus.Error, Result = false };
            }
        }
        private async Task DesactivarCompeticion(TemporadaCompeticionDTO temporadaCompeticion)
        {
            temporadaCompeticion.Activa = false;

            await _temporadaCompeticionRepository.UpdateAsyn(temporadaCompeticion, temporadaCompeticion.Id).ConfigureAwait(false);

            await _temporadaCompeticionCategoriaRepository.SaveAsync().ConfigureAwait(false);
        }
        public async Task<Response> ActivarParaComenzarCompeticion(PreparacionTemporadaViewModel competicionToActivar)
        {
            try
            {
                if (competicionToActivar == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };
                TemporadaDTO preTemporada = await GetPreTemporada().ConfigureAwait(false);
                TemporadaCompeticionDTO temporadaCompeticion = await _temporadaCompeticionRepository
                    .GetCompeticion(preTemporada.Id, competicionToActivar.IdCompeticion).ConfigureAwait(false);

                //establecer estado actual en JORNADA INICIAL-INICIAL
                await NuevoEstadoCompeticion(temporadaCompeticion, LigamaniaConst.Estado_Jornada_Inicial, LigamaniaConst.Operacion_Inicial, "Temporada lista para arrancar").ConfigureAwait(false);

                return new Response { Message = "Competición modificada", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("[ActivarParaComenzarCompeticion]: " + x);
                return new Response { Message = "Error ActivarParaComenzarCompeticion", Status = EResponseStatus.Error, Result = false };
            }

        }
        private async Task NuevoEstadoCompeticion(TemporadaCompeticionDTO temporadaCompeticion, string nuevoEstado, string nuevaOperacion, string descripcion)
        {
            EstadoCompeticionDTO regEstado = await _estadoCompeticionRepository.FindAsync(ec => ec.Estado.Equals(nuevoEstado)).ConfigureAwait(false);
            OperacionCompeticionDTO regOperacion = await _operacionCompeticionRepository.FindAsync(oc => oc.Operacion.Equals(nuevaOperacion)).ConfigureAwait(false);
            await _temporadaCompeticionRepository.SetEstadoActualAsync(temporadaCompeticion, regEstado, regOperacion, descripcion).ConfigureAwait(false);
        }
        public async Task<Response> EditarCompeticion(TemporadaCompeticionCategoriaViewModel competicionToModificar)
        {
            try
            {
                if (competicionToModificar == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };

                TemporadaDTO preTemporada = await GetPreTemporada().ConfigureAwait(false);
                TemporadaCompeticionDTO temporadaCompeticion = await _temporadaCompeticionRepository
                    .GetCompeticion(preTemporada.Id, competicionToModificar.IdCompeticion).ConfigureAwait(false);
                TemporadaCompeticionCategoriaDTO temporadaCompeticionCategoria = await _temporadaCompeticionCategoriaRepository
                    .GetCategoria(preTemporada.Id, competicionToModificar.IdCompeticion, competicionToModificar.IdCategoria).ConfigureAwait(false);
                CompeticionDTO competicion = _competicionRepository.Get(competicionToModificar.IdCompeticion);
                CategoriaDTO categoria = _categoriaRepository.Get(competicionToModificar.IdCategoria);

                if (temporadaCompeticion.CambiosFijos != competicionToModificar.CambiosFijos)
                {
                    temporadaCompeticion.CambiosFijos = competicionToModificar.CambiosFijos;
                    await _temporadaCompeticionRepository.UpdateAsyn(temporadaCompeticion, temporadaCompeticion.Id).ConfigureAwait(false);
                }
                temporadaCompeticionCategoria.MarcarPichichi = competicionToModificar.MarcarPichichi;
                temporadaCompeticionCategoria.NumeroMaximoJugadorEliminar = competicionToModificar.NumMaxJugEliminar;
                await _temporadaCompeticionCategoriaRepository.UpdateAsyn(temporadaCompeticionCategoria, temporadaCompeticionCategoria.Id).ConfigureAwait(false);

                competicion.RepetirClubAliIni = competicionToModificar.RepetirClubAliIni;
                competicion.CompeticionCopiarAliIni = competicionToModificar.CompeticionCopiarAliIni;
                competicion.CopiarAlineacionInicial = competicionToModificar.CopiarAlineacionInicial;
                competicion.JornadaCuadro = competicionToModificar.JornadaCuadro;
                await _competicionRepository.UpdateAsyn(competicion, competicion.Id).ConfigureAwait(false);

                await _competicionCategoriaRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Competición modificada", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("[EditarCompeticion]: " + x);
                return new Response { Message = "Error modificando competición", Status = EResponseStatus.Error, Result = false };
            }
        }
        public async Task<TemporadaCompeticionCategoriaViewModel> GetInfoCompeticionCategoria(int idCompeticion, int idCategoria)
        {
            try
            {
                TemporadaDTO preTemporada = await GetPreTemporada().ConfigureAwait(false);
                TemporadaCompeticionDTO temporadaCompeticion = await _temporadaCompeticionRepository
                    .GetCompeticion(preTemporada.Id, idCompeticion).ConfigureAwait(false);
                TemporadaCompeticionCategoriaDTO temporadaCompeticionCategoria = await _temporadaCompeticionCategoriaRepository
                    .GetCategoria(preTemporada.Id,
                                  idCompeticion,
                                  idCategoria).ConfigureAwait(false);
                CompeticionDTO competicion = _competicionRepository.Get(idCompeticion);
                CategoriaDTO categoria = _categoriaRepository.Get(idCategoria);

                TemporadaCompeticionCategoriaViewModel vm = _mapper.Map<TemporadaCompeticionCategoriaViewModel>(temporadaCompeticionCategoria);
                vm.CambiosFijos = temporadaCompeticion.CambiosFijos;

                var equipos = await GetEquipos(preTemporada.Id, idCompeticion, idCategoria).ConfigureAwait(false);
                vm.Equipos = _mapper.Map<List<TemporadaEquipoDTO>, List<TemporadaEquipoViewModel>>(equipos.ToList());

                var partidos = await GetPartidos(preTemporada.Id, idCompeticion, idCategoria).ConfigureAwait(false);
                partidos = partidos.OrderBy(p => p.Jornada.NumeroJornada).ThenBy(p => p.NumeroPartido).ToList();
                vm.Partidos = _mapper.Map<List<TemporadaPartidoDTO>, List<TemporadaPartidoViewModel>>(partidos.ToList());

                var jornadas = await GetJornadas(preTemporada.Id, idCompeticion).ConfigureAwait(false);
                vm.Jornadas = _mapper.Map<List<TemporadaCompeticionJornadaDTO>, List<TemporadaCompeticionJornadaViewModel>>(jornadas.ToList());

                if (competicion.EsCopa)
                {
                    var cuadro = await GetCuadroCopa().ConfigureAwait(false);
                    var cuadroConEquipos = await GetCuadroCopaConEquipos(preTemporada, temporadaCompeticion).ConfigureAwait(false);
                    var rondas = await GetRondasTemporadaCompeticion(preTemporada, temporadaCompeticion).ConfigureAwait(false);
                    vm.Cuadro = _mapper.Map<List<CuadroCopaDTO>, List<CuadroViewModel>>(cuadro.ToList());
                    vm.CuadroConEquipos = _mapper.Map<List<TemporadaCuadroDTO>, List<TemporadaCuadroViewModel>>(cuadroConEquipos.ToList());
                    vm.Rondas = _mapper.Map<List<TemporadaRondaDTO>, List<TemporadaRondaViewModel>>(rondas);
                }

                return vm;
            }
            catch (Exception x)
            {
                _logger.LogError("[EditarCompeticion]: " + x);
                throw x;
            }

        }

        private async Task<List<TemporadaRondaDTO>> GetRondasTemporadaCompeticion(TemporadaDTO temporada, TemporadaCompeticionDTO temporadaCompeticion)
        {
            var rondas = await _temporadaRondaRepository.GetRondas(temporada, temporadaCompeticion).ConfigureAwait(false);
            return rondas;
        }

        private async Task<List<TemporadaCuadroDTO>> GetCuadroCopaConEquipos(TemporadaDTO temporada, TemporadaCompeticionDTO temporadaCompeticion)
        {
            var cuadro = await _temporadaCuadroRepository.GetCuadro(temporada.Id,temporadaCompeticion.Id).ConfigureAwait(false);
            return cuadro;
        }
        private async Task<List<CuadroCopaDTO>> GetCuadroCopa()
        {
            var cuadro = await _cuadroCopaRepository.GetCuadro().ConfigureAwait(false);
            return cuadro;
        }

        private async Task<ICollection<TemporadaPartidoDTO>> GetPartidos(int idTemporada, int idCompeticion, int idCategoria)
        {
            var partidos = await _temporadaPartidoRepository
                .FindAllIncludingAsync(tp => tp.TemporadaId.Equals(idTemporada) &&
                        tp.CompeticionId.Equals(idCompeticion) &&
                        tp.CategoriaId.Equals(idCategoria),
                        tp => tp.Temporada, tp => tp.Competicion, tp => tp.Categoria, tp => tp.Jornada, tp => tp.EquipoA, tp => tp.EquipoB, tp => tp.EquipoGanador).ConfigureAwait(false);
            return partidos;
        }
        private async Task<ICollection<TemporadaCompeticionJornadaDTO>> GetJornadas(int temporadaId, int competicionId)
        {
            var jornadas = await _temporadaCompeticionJornadaRepository
                .FindAllIncludingAsync(tcj => tcj.TemporadaId.Equals(temporadaId) && tcj.CompeticionId.Equals(competicionId),
                tcj => tcj.Temporada, tcj => tcj.Competicion).ConfigureAwait(false);
            return jornadas;
        }
        private async Task<ICollection<TemporadaEquipoDTO>> GetEquipos(int temporadaId, int competicionId, int categoriaId)
        {
            var equipos = await _temporadaEquipoRepository
                .FindAllIncludingAsync(te => te.TemporadaId.Equals(temporadaId) && te.CompeticionId.Equals(competicionId)
                && te.CategoriaId.Equals(categoriaId) && !te.Baja,
                te => te.Temporada, te => te.Competicion, te => te.Categoria, te => te.Equipo).ConfigureAwait(false);
            return equipos;
        }
        private async Task<TemporadaEquipoDTO> GetEquipo(int temporadaId, int competicionId, int categoriaId, string nombre)
        {
            var equipo = await _temporadaEquipoRepository
                .FindIncludingAsync(te => te.TemporadaId.Equals(temporadaId) && te.CompeticionId.Equals(competicionId)
                && te.CategoriaId.Equals(categoriaId) && !te.Baja && te.Equipo.Nombre.Equals(nombre),
                te => te.Temporada, te => te.Competicion, te => te.Categoria, te => te.Equipo).ConfigureAwait(false);
            return equipo;
        }
        public async Task<Response> CopiarEquipos(PreparacionTemporadaViewModel copiarEquipos)
        {
            try
            {
                TemporadaDTO preTemporada = await GetPreTemporada().ConfigureAwait(false);
                var competicionOrigen = _competicionCategoriaRepository.Find(cc => cc.Competicion.Nombre.Equals(copiarEquipos.CompeticionOrigen) && cc.Categoria.Nombre.Equals(copiarEquipos.Categoria));
                var competicionDestino = await _competicionCategoriaRepository.FindIncludingAsync(cc => cc.Competicion.Nombre.Equals(copiarEquipos.CompeticionDestino)
                    && cc.Categoria.Nombre.Equals(copiarEquipos.Categoria), cc => cc.Competicion).ConfigureAwait(false);

                var equipos = await _temporadaEquipoRepository.FindAllIncludingAsync(
                    te => te.TemporadaId.Equals(preTemporada.Id) && te.CompeticionId.Equals(competicionOrigen.Competicion_Id) && te.Categoria.Id.Equals(competicionOrigen.Categoria_Id) && !te.Baja,
                    te => te.Temporada, te => te.Competicion, te => te.Categoria, te => te.Equipo).ConfigureAwait(false);

                ICollection<TemporadaEquipoDTO> newTemporadaEquipos = CopyTemporadaEquipo(equipos, preTemporada, competicionDestino);
                foreach (var newTempEquipo in newTemporadaEquipos)
                {
                    var insertada = await _temporadaEquipoRepository.AddAsyn(newTempEquipo).ConfigureAwait(false);
                    if (insertada == null)
                        return new Response { Message = "No se pudo copiar el equipo " + newTempEquipo.Equipo.Nombre, Result = false, Status = EResponseStatus.Error };
                }

                await _temporadaEquipoRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Equipos copiados correctamente", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al copiar equipos: " + x);
                return new Response { Message = "Error al copiar equipos", Result = false, Status = EResponseStatus.Error };
            }
        }
        private ICollection<TemporadaEquipoDTO> CopyTemporadaEquipo(ICollection<TemporadaEquipoDTO> equipos, TemporadaDTO preTemporada, CompeticionCategoriaDTO competicionDestino)
        {
            ICollection<TemporadaEquipoDTO> lista = new List<TemporadaEquipoDTO>();
            foreach (var tempEquipo in equipos)
            {
                TemporadaEquipoDTO newTemporadaEquipo = new TemporadaEquipoDTO
                {
                    //newTemporadaEquipo.Id = 0;
                    Temporada = preTemporada,
                    ConfirmadaTemporada = false,
                    PagadaTemporada = false,

                    Baja = tempEquipo.Baja,
                    Categoria = competicionDestino.Categoria,
                    Competicion = competicionDestino.Competicion,
                    Equipo = tempEquipo.Equipo,

                    Alineacion = null,
                    AlineacionCambio = null,
                    AlineacionPrevia = null,
                    Historico = null,
                    Diferencia = 0,
                    GolesContra = 0,
                    GolesFavor = 0,

                    GolesExtraFavor = 0,
                    GolesExtraContra = 0,

                    PartidosEmpatados = 0,
                    PartidosGanados = 0,
                    PartidosJugados = 0,
                    PartidosPerdidos = 0,
                    Puntos = 0
                };

                lista.Add(newTemporadaEquipo);
            }
            return lista;
        }
        public async Task<Response> AgregarEquipo(PreparacionTemporadaViewModel equipo)
        {
            try
            {
                if (equipo == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };
                TemporadaDTO preTemporada = await GetPreTemporada().ConfigureAwait(false);
                var competicionDestinos = await _competicionCategoriaRepository
                    .FindAllIncludingAsync(cc => cc.Competicion.Nombre.Equals(equipo.CompeticionDestino,StringComparison.OrdinalIgnoreCase) && cc.Categoria.Nombre.Equals(equipo.Categoria),
                    cc => cc.Competicion, cc => cc.Categoria).ConfigureAwait(false);
                var competicionDestino = competicionDestinos.FirstOrDefault();

                var equipoReg = await _equipoRepository.GetByNameAsync(equipo.Equipo).ConfigureAwait(false);
                equipoReg.Baja = false;
                await _equipoRepository.UpdateAsyn(equipoReg, equipoReg.Id).ConfigureAwait(false);

                TemporadaEquipoDTO newEquipo = new TemporadaEquipoDTO
                {
                    Baja = false,
                    Categoria = competicionDestino.Categoria,
                    Competicion = competicionDestino.Competicion,
                    ConfirmadaTemporada = true,
                    Equipo = equipoReg,
                    Temporada = preTemporada
                };
                var temporadaEquipo = await _temporadaEquipoRepository.FindAsync(te => te.Temporada.Id.Equals(preTemporada.Id) && te.Equipo.Id.Equals(equipoReg.Id)
                    && te.CompeticionId.Equals(competicionDestino.Competicion_Id))
                    .ConfigureAwait(false);
                if (temporadaEquipo == null)
                {
                    var insertada = await _temporadaEquipoRepository.AddAsyn(newEquipo).ConfigureAwait(false);
                    if (insertada == null)
                        return new Response { Message = "No se pudo copiar el equipo " + newEquipo.Equipo.Nombre, Result = false, Status = EResponseStatus.Error };
                }
                else
                {
                    temporadaEquipo.Baja = false;
                    await _temporadaEquipoRepository.UpdateAsyn(temporadaEquipo, temporadaEquipo.Id).ConfigureAwait(false);
                }
                await _temporadaEquipoRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Equipo agregado correctamente", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al agregar equipo: " + x);
                return new Response { Message = "Error al agregar equipo", Result = false, Status = EResponseStatus.Error };
            }
        }
        public async Task<Response> AgregarEquiposSupercopa(PreparacionTemporadaViewModel compCat)
        {
            try
            {
                if (compCat == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };

                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                TemporadaDTO temporadaAnterior = await _temporadaRepository.GetTemporadaAnteriorAsync(temporada).ConfigureAwait(false);

                if (temporada == null)
                    return new Response { Message = "No se encuentra la temporada actual", Result = false, Status = EResponseStatus.Error };
                if (temporadaAnterior == null)
                    return new Response { Message = "No se encuentra la temporada anterior", Result = false, Status = EResponseStatus.Error };

                var competicionDestinos = await _competicionCategoriaRepository
                    .FindAllIncludingAsync(cc => cc.Competicion.Nombre.Equals(compCat.CompeticionDestino) && cc.Categoria.Nombre.Equals(compCat.Categoria),
                    cc => cc.Competicion, cc => cc.Categoria).ConfigureAwait(false);
                var competicionDestino = competicionDestinos.FirstOrDefault();

                if (competicionDestino == null)
                    return new Response { Message = "No se encuentra la competición " + compCat.CompeticionDestino, Result = false, Status = EResponseStatus.Error };

                var competicionLiga = await _competicionCategoriaRepository
                    .FindIncludingAsync(cc => cc.Competicion.Nombre.Equals(LigamaniaConst.Competicion_Liga) && cc.Categoria.Nombre.Equals(LigamaniaConst.Categoria_Golden),
                    cc => cc.Competicion, cc => cc.Categoria).ConfigureAwait(false);

                var competicionCopa = await _competicionCategoriaRepository
                    .FindIncludingAsync(cc => cc.Competicion.Nombre.Equals(LigamaniaConst.Competicion_Copa) && cc.Categoria.Nombre.Equals(LigamaniaConst.Categoria_SinCategoria),
                    cc => cc.Competicion, cc => cc.Categoria).ConfigureAwait(false);

                if (competicionLiga == null)
                    return new Response { Message = "No se encuentra la Liga", Result = false, Status = EResponseStatus.Error };
                if (competicionCopa == null)
                    return new Response { Message = "No se encuentra la Copa", Result = false, Status = EResponseStatus.Error };

                // buscar la temporadacompeticioncategoria
                var tempCompCatLiga = await _temporadaCompeticionCategoriaRepository.GetCategoria(temporadaAnterior.Id, competicionLiga.Competicion_Id, competicionLiga.Categoria_Id).ConfigureAwait(false);
                var tempCompCatCopa = await _temporadaCompeticionCategoriaRepository.GetCategoria(temporadaAnterior.Id, competicionCopa.Competicion_Id, competicionCopa.Categoria_Id).ConfigureAwait(false);

                if (tempCompCatLiga == null)
                    return new Response { Message = "No se encuentra la Liga en la temporada anterior", Result = false, Status = EResponseStatus.Error };
                if (tempCompCatCopa == null)
                    return new Response { Message = "No se encuentra la Copa en la temporada anterior", Result = false, Status = EResponseStatus.Error };

                // equipo ganador de liga en temporadaAnterior
                var ganadorLiga = await _historicoRepository
                    .FindIncludingAsync(h => h.Temporada_ID.Equals(temporadaAnterior.Id) && h.Categoria_ID.Equals(tempCompCatLiga.Id) && h.Puesto.Equals(1),
                    h => h.TemporadaEquipo).ConfigureAwait(false);

                EquipoDTO equipoCopa = null;
                TemporadaCuadroDTO cuadro = await _temporadaCuadroRepository.GetLastPartidoCuadro(temporadaAnterior.Id, competicionCopa.Competicion_Id).ConfigureAwait(false);
                if (cuadro != null) equipoCopa = await _equipoRepository.GetByNameAsync(cuadro.NombreGanador).ConfigureAwait(false);

                if (ganadorLiga == null)
                    return new Response { Message = "No se encuentra el ganador de la Liga en la temporada anterior", Result = false, Status = EResponseStatus.Error };

                var equipoLiga = _equipoRepository.Get(ganadorLiga.TemporadaEquipo.EquipoId);
                if (equipoLiga == null)
                    return new Response { Message = "No se encuentra el equipo ganador de Liga", Result = false, Status = EResponseStatus.Error };
                if (equipoCopa == null)
                    return new Response { Message = "No se encuentra el equipo ganador de Copa", Result = false, Status = EResponseStatus.Error };

                var existeEquipoLiga = await _temporadaEquipoRepository.ExistsAsync(te => te.TemporadaId.Equals(temporada.Id) && te.CompeticionId.Equals(competicionDestino.Competicion_Id) && te.EquipoId.Equals(equipoLiga.Id)).ConfigureAwait(false);
                if (!existeEquipoLiga)
                {
                    TemporadaEquipoDTO newEquipoLiga = new TemporadaEquipoDTO
                    {
                        Baja = false,
                        Categoria = competicionDestino.Categoria,
                        Competicion = competicionDestino.Competicion,
                        ConfirmadaTemporada = true,
                        Equipo = equipoLiga,
                        Temporada = temporada
                    };
                    var insertada = await _temporadaEquipoRepository.AddAsyn(newEquipoLiga).ConfigureAwait(false);
                    if (insertada == null)
                        return new Response { Message = "No se pudo agregar el equipo ganador de Liga " + newEquipoLiga.Equipo.Nombre, Result = false, Status = EResponseStatus.Error };
                }
                else
                {
                    var temporadaEquipoLiga = await _temporadaEquipoRepository.FindAsync(te => te.TemporadaId.Equals(temporada.Id) && te.CompeticionId.Equals(competicionDestino.Competicion_Id) && te.EquipoId.Equals(equipoLiga.Id)).ConfigureAwait(false);
                    temporadaEquipoLiga.Baja = false;
                    await _temporadaEquipoRepository.UpdateAsyn(temporadaEquipoLiga, temporadaEquipoLiga.Id).ConfigureAwait(false);
                }
                var existeEquipoCopa = await _temporadaEquipoRepository.ExistsAsync(te => te.TemporadaId.Equals(temporada.Id) && te.CompeticionId.Equals(competicionDestino.Competicion_Id) && te.EquipoId.Equals(equipoCopa.Id)).ConfigureAwait(false);
                if (!existeEquipoCopa)
                {
                    TemporadaEquipoDTO newEquipoCopa = new TemporadaEquipoDTO
                    {
                        Baja = false,
                        Categoria = competicionDestino.Categoria,
                        Competicion = competicionDestino.Competicion,
                        ConfirmadaTemporada = true,
                        Equipo = equipoCopa,
                        Temporada = temporada
                    };
                    var insertada = await _temporadaEquipoRepository.AddAsyn(newEquipoCopa).ConfigureAwait(false);
                    if (insertada == null)
                        return new Response { Message = "No se pudo agregar el equipo ganador de Copa " + newEquipoCopa.Equipo.Nombre, Result = false, Status = EResponseStatus.Error };
                }
                else
                {
                    var temporadaEquipoCopa = await _temporadaEquipoRepository.FindAsync(te => te.TemporadaId.Equals(temporada.Id) && te.CompeticionId.Equals(competicionDestino.Competicion_Id) && te.EquipoId.Equals(equipoCopa.Id)).ConfigureAwait(false);
                    temporadaEquipoCopa.Baja = false;
                    await _temporadaEquipoRepository.UpdateAsyn(temporadaEquipoCopa, temporadaEquipoCopa.Id).ConfigureAwait(false);
                }

                await _temporadaEquipoRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Equipos de Supercopa agregados correctamente", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al agregar equipos Supercopa: " + x);
                return new Response { Message = "Error al agregar equipos Supercopa", Result = false, Status = EResponseStatus.Error };
            }
        }
        public async Task<Response> AgregarPartidoSupercopa(PreparacionTemporadaViewModel compCat)
        {
            try
            {
                TemporadaDTO temporada = await GetTemporadaActual().ConfigureAwait(false);
                var competicionCategoriaDestino = await _competicionCategoriaRepository.FindAsync(
                    cc => cc.Competicion.Nombre.Equals(compCat.CompeticionDestino) && cc.Categoria.Nombre.Equals(compCat.Categoria)).ConfigureAwait(false);
                //var calendario = await _calendarioRepository.GetByNameIncludingAsync(generaPartidos.Calendario, c => c.CalendarioDetalle);
                //var calDetalles = calendario.CalendarioDetalle;
                var equipos = await GetEquipos(temporada.Id, competicionCategoriaDestino.Competicion_Id, competicionCategoriaDestino.Categoria_Id).ConfigureAwait(false);
                if (equipos.Count != 2)
                    return new Response { Message = "Para agregar un partido de Supercopa tiene que haber 2 equipos únicamente", Result = false, Status = EResponseStatus.Warning };
                var jornadas = await _temporadaCompeticionJornadaRepository.FindAllAsync(
                    tcj => tcj.Temporada.Actual && tcj.CompeticionId.Equals(competicionCategoriaDestino.Competicion_Id) && tcj.NumeroJornada.Equals(compCat.Jornada)).ConfigureAwait(false);
                if (jornadas == null)
                    return new Response { Message = "No existe en Supercopa la jornada " + compCat.Jornada, Result = false, Status = EResponseStatus.Warning };
                var partidosExistentes = await _temporadaPartidoRepository.FindAllAsync(
                    tp => tp.Temporada.Actual && tp.CompeticionId.Equals(competicionCategoriaDestino.Competicion_Id)).ConfigureAwait(false);
                int numPartidos = 0;
                if (partidosExistentes.Any()) numPartidos = partidosExistentes.Count;
                // generar los partidos de forma aleatoria
                //var partidos = await GeneraPartidosFromCalendario(calendario, calDetalles, equipos);
                var partidos = await GeneraPartidoSupercopa(equipos, compCat.Jornada, numPartidos).ConfigureAwait(false);

                foreach (var partido in partidos)
                {
                    await CreaPartido(partido, equipos, jornadas, competicionCategoriaDestino).ConfigureAwait(false);
                }
                await _temporadaPartidoRepository.SaveAsync().ConfigureAwait(false);

                return new Response { Message = "Partido generado correctamente", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al generar partido supercopa: " + x);
                return new Response { Message = "Error al generar partido Supercopa", Result = false, Status = EResponseStatus.Error };
            }
        }

        public async Task<Response> AgregarJornada(PreparacionTemporadaViewModel jornada)
        {
            try
            {
                TemporadaDTO preTemporada = await GetPreTemporada().ConfigureAwait(false);
                var competicionDestino = await _competicionRepository.GetByNameAsync(jornada.CompeticionDestino).ConfigureAwait(false);

                TemporadaCompeticionJornadaDTO newJornada = new TemporadaCompeticionJornadaDTO
                {
                    Temporada = preTemporada,
                    Competicion = competicionDestino,
                    Fecha = jornada.Fecha,
                    NumeroJornada = jornada.Jornada
                };
                var insertada = await _temporadaCompeticionJornadaRepository.AddAsyn(newJornada).ConfigureAwait(false);
                if (insertada == null)
                    return new Response { Message = "No se pudo agregar la jornada", Result = false, Status = EResponseStatus.Error };

                await _temporadaCompeticionJornadaRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Jornada agregada correctamente", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al agregar jornada: " + x);
                return new Response { Message = "Error al agregar jornada", Result = false, Status = EResponseStatus.Error };
            }
        }
        public async Task<Response> BorrarJornada(PreparacionTemporadaViewModel jornada)
        {
            try
            {
                if (jornada == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };

                TemporadaDTO preTemporada = await GetPreTemporada().ConfigureAwait(false);
                var competicionDestino = await _competicionRepository.GetByNameAsync(jornada.CompeticionDestino).ConfigureAwait(false);

                TemporadaCompeticionJornadaDTO jornadaborrar = await _temporadaCompeticionJornadaRepository
                    .FindAsync(j => j.Competicion.Nombre.Equals(jornada.CompeticionDestino)
                            && j.NumeroJornada.Equals(jornada.Jornada) && j.TemporadaId.Equals(preTemporada.Id)).ConfigureAwait(false);
                var borrada = await _temporadaCompeticionJornadaRepository.DeleteAsyn(jornadaborrar).ConfigureAwait(false);

                await _temporadaCompeticionJornadaRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Jornada borrada correctamente", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al borrar jornada: " + x);
                return new Response { Message = "Error al borrar jornada", Result = false, Status = EResponseStatus.Error };
            }
        }
        public async Task<Response> SetJornadaActual(PreparacionTemporadaViewModel jornada)
        {
            try
            {
                if (jornada == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };

                TemporadaDTO preTemporada = await GetPreTemporada().ConfigureAwait(false);
                var competicionDestino = await _competicionRepository.GetByNameAsync(jornada.CompeticionDestino).ConfigureAwait(false);

                TemporadaCompeticionJornadaDTO jornadaModificar = await _temporadaCompeticionJornadaRepository
                    .FindAsync(j => j.Competicion.Nombre.Equals(jornada.CompeticionDestino)
                            && j.NumeroJornada.Equals(jornada.Jornada) && j.TemporadaId.Equals(preTemporada.Id)).ConfigureAwait(false);

                jornadaModificar.Actual = true;

                var modificada = await _temporadaCompeticionJornadaRepository.UpdateAsyn(jornadaModificar, jornadaModificar.Id).ConfigureAwait(false);

                await _temporadaCompeticionJornadaRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Jornada modificada correctamente (ACTUAL)", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al modificar jornada(ACTUAL): " + x);
                return new Response { Message = "Error al modificar jornada(ACTUAL)", Result = false, Status = EResponseStatus.Error };
            }
        }

        public async Task<Response> AddDiasJornada(PreparacionTemporadaViewModel jornada)
        {
            try
            {
                if (jornada == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };

                TemporadaDTO preTemporada = await GetPreTemporada().ConfigureAwait(false);
                var competicionDestino = await _competicionRepository.GetByNameAsync(jornada.CompeticionDestino).ConfigureAwait(false);

                TemporadaCompeticionJornadaDTO jornadaModificar = await _temporadaCompeticionJornadaRepository
                    .FindAsync(j => j.Competicion.Nombre.Equals(jornada.CompeticionDestino)
                            && j.NumeroJornada.Equals(jornada.Jornada) && j.TemporadaId.Equals(preTemporada.Id)).ConfigureAwait(false);

                TemporadaCompeticionJornadaDTO jornadaAnterior = await _temporadaCompeticionJornadaRepository
                    .FindAsync(j => j.Competicion.Nombre.Equals(jornada.CompeticionDestino)
                    && j.NumeroJornada.Equals(jornada.Jornada-1) && j.TemporadaId.Equals(preTemporada.Id)).ConfigureAwait(false);

                jornadaModificar.Fecha = jornadaAnterior.Fecha.AddDays(jornada.Dias);

                var modificada = await _temporadaCompeticionJornadaRepository.UpdateAsyn(jornadaModificar, jornadaModificar.Id).ConfigureAwait(false);

                await _temporadaCompeticionJornadaRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Jornada modificada correctamente", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al modificar jornada: " + x);
                return new Response { Message = "Error al modificar jornada", Result = false, Status = EResponseStatus.Error };
            }
        }

        public async Task<Response> EditarJornada(PreparacionTemporadaViewModel jornada)
        {
            try
            {
                if (jornada == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };

                TemporadaDTO preTemporada = await GetPreTemporada().ConfigureAwait(false);
                var competicionDestino = await _competicionRepository.GetByNameAsync(jornada.CompeticionDestino).ConfigureAwait(false);

                TemporadaCompeticionJornadaDTO jornadaeditar = await _temporadaCompeticionJornadaRepository
                    .FindAsync(j => j.Competicion.Nombre.Equals(jornada.CompeticionDestino)
                            && j.NumeroJornada.Equals(jornada.Jornada) && j.TemporadaId.Equals(preTemporada.Id)).ConfigureAwait(false);
                jornadaeditar.Fecha = jornada.Fecha;
                var editada = await _temporadaCompeticionJornadaRepository.UpdateAsyn(jornadaeditar, jornadaeditar.Id).ConfigureAwait(false);

                await _temporadaCompeticionJornadaRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Jornada actualizada correctamente", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al editar jornada: " + x);
                return new Response { Message = "Error al editar jornada", Result = false, Status = EResponseStatus.Error };
            }
        }
        public async Task<Response> RemoveAllJornadas(PreparacionTemporadaViewModel compCat)
        {
            try
            {
                TemporadaDTO preTemporada = await GetPreTemporada().ConfigureAwait(false);
                var jornadas = await _temporadaCompeticionJornadaRepository.FindAllAsync(
                    tcj => tcj.TemporadaId.Equals(preTemporada.Id) && tcj.Competicion.Nombre.Equals(compCat.CompeticionDestino)).ConfigureAwait(false);
                await _temporadaCompeticionJornadaRepository.DeleteRangeAsyn(jornadas).ConfigureAwait(false);

                await _temporadaCompeticionJornadaRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Jornadas eliminadas correctamente", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al eliminar jornadas: " + x);
                return new Response { Message = "Error al eliminar jornadas", Result = false, Status = EResponseStatus.Error };
            }
        }
        public async Task<Response> RemoveAllPartidos(PreparacionTemporadaViewModel compCat)
        {
            try
            {
                TemporadaDTO preTemporada = await GetPreTemporada().ConfigureAwait(false);
                // limpiar la tabla de partidos para la competición, categoría y temporada
                var partidos = await _temporadaPartidoRepository.FindAllAsync(
                    tp => tp.TemporadaId.Equals(preTemporada.Id) && tp.Competicion.Nombre.Equals(compCat.CompeticionDestino)
                    && tp.Categoria.Nombre.Equals(compCat.Categoria)).ConfigureAwait(false);
                await _temporadaPartidoRepository.DeleteRangeAsyn(partidos).ConfigureAwait(false);

                await _temporadaPartidoRepository.SaveAsync().ConfigureAwait(false);

                return new Response { Message = "Partidos eliminados correctamente", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al eliminar partidos: " + x);
                return new Response { Message = "Error al eliminar partidos", Result = false, Status = EResponseStatus.Error };
            }
        }

        public async Task<Response> BajaEquipo(PreparacionTemporadaViewModel equipo)
        {
            try
            {
                if (equipo == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };

                TemporadaDTO preTemporada = await GetPreTemporada().ConfigureAwait(false);
                var competicionDestino = await _competicionRepository.GetByNameAsync(equipo.CompeticionDestino).ConfigureAwait(false);

                TemporadaEquipoDTO temporadaEquipo = await _temporadaEquipoRepository
                        .FindAsync(e => e.TemporadaId.Equals(preTemporada.Id)
                                        && e.CompeticionId.Equals(competicionDestino.Id)
                                        && e.Equipo.Nombre.Equals(equipo.Equipo)).ConfigureAwait(false);
                temporadaEquipo.Baja = true;
                var borrado = await _temporadaEquipoRepository.UpdateAsyn(temporadaEquipo, temporadaEquipo.Id).ConfigureAwait(false);

                await _temporadaEquipoRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Equipo dado de baja correctamente", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al dar de baja equipo: " + x);
                return new Response { Message = "Error al dar de baja equipo", Result = false, Status = EResponseStatus.Error };
            }
        }
        public async Task<Response> ActivarDesactivarEquipo(TemporadaEquipoAccion equipoAccion)
        {
            try
            {
                if (equipoAccion == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };

                var equipo = await _equipoRepository.GetByNameAsync(equipoAccion.Equipo).ConfigureAwait(false);
                if (equipo==null) return new Response { Message = "No se encuentra el equipo", Result = false, Status = EResponseStatus.Warning};

                equipo.Baja = !equipoAccion.Accion;

                var borrado = await _equipoRepository.UpdateAsyn(equipo, equipo.Id).ConfigureAwait(false);

                await _equipoRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Equipo modificado correctamente", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al modificar equipo: " + x);
                return new Response { Message = "Error al modificar equipo", Result = false, Status = EResponseStatus.Error };
            }
        }
        public async Task<Response> BotNoBotEquipo(TemporadaEquipoAccion equipoAccion)
        {
            try
            {
                if (equipoAccion == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };

                var equipo = await _equipoRepository.GetByNameAsync(equipoAccion.Equipo).ConfigureAwait(false);
                if (equipo == null) return new Response { Message = "No se encuentra el equipo", Result = false, Status = EResponseStatus.Warning };

                equipo.EsBot = equipoAccion.Accion;

                var borrado = await _equipoRepository.UpdateAsyn(equipo, equipo.Id).ConfigureAwait(false);

                await _equipoRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Equipo modificado correctamente", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al modificar equipo: " + x);
                return new Response { Message = "Error al modificar equipo", Result = false, Status = EResponseStatus.Error };
            }
        }
        public async Task<Response> GenerarPartidos(PreparacionTemporadaViewModel generaPartidos)
        {
            try
            {
                if (generaPartidos == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };
                TemporadaDTO preTemporada = await GetPreTemporada().ConfigureAwait(false);
                var competicionCategoriaDestino = await _competicionCategoriaRepository.FindAsync(
                    cc => cc.Competicion.Nombre.Equals(generaPartidos.CompeticionDestino) && cc.Categoria.Nombre.Equals(generaPartidos.Categoria)).ConfigureAwait(false);
                var calendario = await _calendarioRepository.GetByNameIncludingAsync(generaPartidos.Calendario, c => c.CalendarioDetalle).ConfigureAwait(false);
                var calDetalles = calendario.CalendarioDetalle;
                var equipos = await GetEquipos(preTemporada.Id, competicionCategoriaDestino.Competicion_Id, competicionCategoriaDestino.Categoria_Id).ConfigureAwait(false);

                // generar los partidos de forma aleatoria
                var partidos = await GeneraPartidosFromCalendario(calendario, calDetalles, equipos).ConfigureAwait(false);

                // generar las jornadas
                var jornadasAGenerar = partidos.Max(p => p.Jornada);
                var jornadas = await _temporadaCompeticionJornadaRepository.FindAllAsync(
                    tcj => tcj.TemporadaId.Equals(preTemporada.Id) && tcj.CompeticionId.Equals(competicionCategoriaDestino.Competicion_Id)).ConfigureAwait(false);
                if (jornadas.Count < jornadasAGenerar)
                    await GeneraJornadas(preTemporada, competicionCategoriaDestino.Competicion, jornadas, jornadasAGenerar).ConfigureAwait(false);
                jornadas = await _temporadaCompeticionJornadaRepository.FindAllAsync(
                    tcj => tcj.TemporadaId.Equals(preTemporada.Id) && tcj.CompeticionId.Equals(competicionCategoriaDestino.Competicion_Id)).ConfigureAwait(false);

                // limpiar la tabla de partidos para la competición, categoría y temporada
                var existentes = await _temporadaPartidoRepository.FindAllAsync(
                    tp => tp.TemporadaId.Equals(preTemporada.Id) && tp.CompeticionId.Equals(competicionCategoriaDestino.Competicion_Id)
                    && tp.CategoriaId.Equals(competicionCategoriaDestino.Categoria_Id)).ConfigureAwait(false);
                await _temporadaPartidoRepository.DeleteRangeAsyn(existentes).ConfigureAwait(false);

                await _temporadaPartidoRepository.SaveAsync().ConfigureAwait(false);

                foreach (var partido in partidos)
                {
                    await CreaPartido(partido, equipos, jornadas, competicionCategoriaDestino).ConfigureAwait(false);
                }
                await _temporadaPartidoRepository.SaveAsync().ConfigureAwait(false);

                return new Response { Message = "Partidos generados correctamente", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al generar partidos: " + x);
                return new Response { Message = "Error al generar partidos", Result = false, Status = EResponseStatus.Error };
            }
        }
        public async Task<Response> GenerarPartidoLibre(PreparacionTemporadaViewModel generaPartidos)
        {
            try
            {
                if (generaPartidos == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };
                TemporadaDTO preTemporada = await GetPreTemporada().ConfigureAwait(false);
                var competicionCategoriaDestino = await _competicionCategoriaRepository.FindAsync(
                    cc => cc.Competicion.Nombre.Equals(generaPartidos.CompeticionDestino) && cc.Categoria.Nombre.Equals(generaPartidos.Categoria)).ConfigureAwait(false);
                //var equipos = await GetEquipos(preTemporada.Id, competicionCategoriaDestino.Competicion_Id, competicionCategoriaDestino.Categoria_Id).ConfigureAwait(false);
                var local = await GetEquipo(preTemporada.Id, competicionCategoriaDestino.Competicion_Id, competicionCategoriaDestino.Categoria_Id, generaPartidos.Local).ConfigureAwait(false);
                var visitante = await GetEquipo(preTemporada.Id, competicionCategoriaDestino.Competicion_Id, competicionCategoriaDestino.Categoria_Id, generaPartidos.Visitante).ConfigureAwait(false);

                // generar las jornadas
                var jornadasAGenerar = 1;
                var jornadas = await _temporadaCompeticionJornadaRepository.FindAllAsync(
                    tcj => tcj.TemporadaId.Equals(preTemporada.Id) && tcj.CompeticionId.Equals(competicionCategoriaDestino.Competicion_Id)).ConfigureAwait(false);
                if (jornadas.Count < jornadasAGenerar)
                    await GeneraJornadas(preTemporada, competicionCategoriaDestino.Competicion, jornadas, jornadasAGenerar).ConfigureAwait(false);
                jornadas = await _temporadaCompeticionJornadaRepository.FindAllAsync(
                    tcj => tcj.TemporadaId.Equals(preTemporada.Id) && tcj.CompeticionId.Equals(competicionCategoriaDestino.Competicion_Id)).ConfigureAwait(false);

                //// limpiar la tabla de partidos para la competición, categoría y temporada
                var existentes = await _temporadaPartidoRepository.FindAllAsync(
                    tp => tp.TemporadaId.Equals(preTemporada.Id) && tp.CompeticionId.Equals(competicionCategoriaDestino.Competicion_Id)
                    && tp.CategoriaId.Equals(competicionCategoriaDestino.Categoria_Id)).ConfigureAwait(false);

                var jornada = jornadas.FirstOrDefault(j => j.NumeroJornada.Equals(generaPartidos.Jornada));

                // si el partido no existe, lo añadimos
                TemporadaPartidoDTO newPartido = new TemporadaPartidoDTO
                {
                    Competicion = competicionCategoriaDestino.Competicion,
                    Categoria = competicionCategoriaDestino.Categoria,
                    EquipoA = local.Equipo,
                    EquipoB = visitante.Equipo,
                    Jornada = jornada,
                    Temporada = local.Temporada,
                    NumeroPartido = existentes.Count+1
                };
                await _temporadaPartidoRepository.AddAsyn(newPartido).ConfigureAwait(false);

                await _temporadaPartidoRepository.SaveAsync().ConfigureAwait(false);

                return new Response { Message = "Partido generado correctamente", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("Error al generar partidos: " + x);
                return new Response { Message = "Error al generar partidos", Result = false, Status = EResponseStatus.Error };
            }
        }
        private async Task GeneraJornadas(TemporadaDTO preTemporada, CompeticionDTO competicion,
            ICollection<TemporadaCompeticionJornadaDTO> jornadas, int jornadasAGenerar)
        {
            var numJorExistentes = jornadas.Select(j => j.NumeroJornada).ToList();
            var fecha = jornadas.Max(j => j.Fecha);
            for (int j = 0; j < jornadasAGenerar; j++)
            {
                if (!numJorExistentes.Contains(j + 1))
                {
                    fecha = fecha.AddDays(7);
                    TemporadaCompeticionJornadaDTO newJornada = new TemporadaCompeticionJornadaDTO
                    {
                        NumeroJornada = j + 1,
                        Fecha = fecha,
                        Temporada = preTemporada,
                        Competicion = competicion
                    };
                    await _temporadaCompeticionJornadaRepository.AddAsyn(newJornada).ConfigureAwait(false);
                }
            }
            await _temporadaCompeticionJornadaRepository.SaveAsync().ConfigureAwait(false);
        }

        private async Task CreaPartido(TemporadaPartidoViewModel partido, ICollection<TemporadaEquipoDTO> equipos,
            ICollection<TemporadaCompeticionJornadaDTO> jornadas, CompeticionCategoriaDTO competicionCategoriaDestino)
        {
            var equipoA = equipos.FirstOrDefault(e => e.Equipo.Nombre.Equals(partido.EquipoA));
            var equipoB = equipos.FirstOrDefault(e => e.Equipo.Nombre.Equals(partido.EquipoB));

            var jornada = jornadas.FirstOrDefault(j => j.NumeroJornada.Equals(partido.Jornada));

            // si el partido no existe, lo añadimos
            TemporadaPartidoDTO newPartido = new TemporadaPartidoDTO
            {
                Competicion = competicionCategoriaDestino.Competicion,
                Categoria = competicionCategoriaDestino.Categoria,
                EquipoA = equipoA.Equipo,
                EquipoB = equipoB.Equipo,
                Jornada = jornada,
                Temporada = equipoA.Temporada,
                NumeroPartido = partido.NumeroPartido
            };
            await _temporadaPartidoRepository.AddAsyn(newPartido).ConfigureAwait(false);
        }

        private async Task<List<TemporadaPartidoViewModel>> GeneraPartidosFromCalendario(CalendarioDTO calendario,
            ICollection<CalendarioDetalleDTO> calDetalles, ICollection<TemporadaEquipoDTO> equipos)
        {
            List<TemporadaPartidoViewModel> partidos = new List<TemporadaPartidoViewModel>();
            Random random = new Random(calendario.NumEquipos + 1);
            Hashtable listaAsignacion = new Hashtable();

            // asignar a cada equipo un número aleatorio entre 1 y NumEquipos
            int num = random.Next(1, calendario.NumEquipos + 1);
            int numPartidos = 1;
            foreach (var equi in equipos)
            {
                var asignacion = new { equipo = equi.Equipo.Nombre, numero = num };
                listaAsignacion.Add(asignacion.numero, asignacion.equipo);
                while (listaAsignacion.Count < calendario.NumEquipos && listaAsignacion.ContainsKey(num))
                    num = random.Next(1, calendario.NumEquipos + 1);
            }
            // generar la lista de partidos con las jornadas y nombres según el calendario y número asignado
            foreach (var calDet in calDetalles)
            {
                int local = GetNumEquipo(calDet.Local);
                int visi = GetNumEquipo(calDet.Visitante);
                partidos.Add(new TemporadaPartidoViewModel
                {
                    Jornada = calDet.Jornada,
                    NumeroPartido = numPartidos++,
                    EquipoA = listaAsignacion[local].ToString(),
                    EquipoB = listaAsignacion[visi].ToString()
                });
            }

            return await Task.FromResult(partidos).ConfigureAwait(false);
        }
        private async Task<List<TemporadaPartidoViewModel>> GeneraPartidoSupercopa(ICollection<TemporadaEquipoDTO> equipos, int numJornada, int numPartidos)
        {
            List<TemporadaPartidoViewModel> partidos = new List<TemporadaPartidoViewModel>
            {
                new TemporadaPartidoViewModel
                {
                    Jornada = numJornada,
                    NumeroPartido = numPartidos + 1,
                    EquipoA = equipos.First().Equipo.Nombre,
                    EquipoB = equipos.Last().Equipo.Nombre
                }
            };

            return await Task.FromResult(partidos).ConfigureAwait(false);
        }

        private int GetNumEquipo(string locVis)
        {
            int numChar = LigamaniaConst.Jugador_Calendario.Length;
            string equipoLocal = locVis.Substring(numChar);
            int equiLoc = int.Parse(equipoLocal);
            return equiLoc;
        }
        public async Task<CalendarioDTO> NuevoCalendario(string nombre, int numequipos)
        {
            CalendarioDTO newCalendario = new CalendarioDTO
            {
                Nombre = nombre,
                NumEquipos = numequipos
            };
            CalendarioDTO calendario = await _calendarioRepository.GetByNameAsync(nombre).ConfigureAwait(false);
            if (calendario == null)
            {
                newCalendario = await _calendarioRepository.AddAsyn(newCalendario).ConfigureAwait(false);
                await _calendarioRepository.SaveAsync().ConfigureAwait(false);
                return newCalendario;
            }
            return calendario;
        }
        public async Task<Response> NuevoCalendarioDetalle(CalendarioDTO calendario, int jornada, string local, string visitante)
        {
            CalendarioDetalleDTO calendarioDetalle = new CalendarioDetalleDTO
            {
                Calendario_ID = calendario.Id,
                Jornada = jornada,
                Local = local,
                Visitante = visitante
            };
            CalendarioDetalleDTO detalle = await _calendarioDetalleRepository.FindAsync(cd => cd.Calendario_ID.Equals(calendario.Id)
                && cd.Jornada.Equals(jornada) && cd.Local.Equals(local) && cd.Visitante.Equals(visitante)).ConfigureAwait(false);
            if (detalle == null)
            {
                await _calendarioDetalleRepository.AddAsyn(calendarioDetalle).ConfigureAwait(false);
                await _calendarioDetalleRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "", Result = true, Status = EResponseStatus.Success };
            }
            return new Response { Message = "El registro ya existe", Status = EResponseStatus.Warning, Result = false };
        }
        public async Task<List<EquipoViewModel>> GetInventarioEquipos()
        {
            try
            {
                var equipos = await _equipoRepository.GetAllIncludingAsync(e => e.ApplicationUser).ConfigureAwait(false);
                List<EquipoViewModel> lista = equipos.Select(e => new EquipoViewModel
                {
                    Baja = e.Baja,
                    EsBOT = e.EsBot,
                    Equipo = e.Nombre,
                    Id = e.Id,
                    Entrenador = e.ApplicationUser.UserName
                }).ToList();
                return lista;
            }
            catch (Exception x)
            {
                _logger.LogError("Error recuperando inventario de equipos: " + x);
                return new List<EquipoViewModel>();
            }
        }
        public async Task<Response> ResetearCompeticion(TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                if (competicionPC == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };

                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return new Response { Message = "No existe temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await _temporadaCompeticionRepository
                        .FindIncludingAsync(tc => tc.TemporadaId.Equals(temporada.Id) && tc.Competicion.Nombre.Equals(competicionPC.Competicion),
                        tc => tc.Competicion, tc => tc.EstadoActual, tc => tc.OperacionActual).ConfigureAwait(false);
                if (temporadaCompeticion == null)
                    return new Response { Message = "No existe la competición en la temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                //TemporadaCompeticionJornada_DTO jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaActual(temporadaCompeticion.Competicion.Id, temporada.Nombre);
                //if (jornadaActual == null)
                //    return new Response { Message = "No existe jornada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                // Eliminar todos los registros de TemporadaJornadaJugador de las jornadas de la competicion elegida
                var temJorJug = await _temporadaJornadaJugadorRepository.FindAllAsync(
                    tjj => tjj.Temporada.Actual && tjj.Jornada.CompeticionId.Equals(temporadaCompeticion.CompeticionId)).ConfigureAwait(false);
                await _temporadaJornadaJugadorRepository.DeleteRangeAsyn(temJorJug).ConfigureAwait(false);

                // TemporadaCompeticionJornada, desmarcar jornada carrusel y jornada actual
                var temCompJor = await _temporadaCompeticionJornadaRepository.FindAllAsync(
                    tcj => tcj.Temporada.Actual && tcj.CompeticionId.Equals(temporadaCompeticion.CompeticionId)).ConfigureAwait(false);
                foreach (var temcom in temCompJor)
                {
                    temcom.Actual = false;
                    temcom.Carrusel = false;
                    await _temporadaCompeticionJornadaRepository.UpdateAsyn(temcom, temcom.Id).ConfigureAwait(false);
                }

                // TemporadaJugador, eliminado, preeliminado, veceseliminado, vecespreeliminado, lastjornadaeliminacion
                if (temporadaCompeticion.Competicion.EsLiga)
                {
                    var temjug = await _temporadaJugadorRepository.FindAllAsync(tj => tj.Temporada.Actual && tj.Activo
                          && (tj.VecesEliminado > 0 || tj.VecesPreEliminado > 0 || tj.LastJornadaEliminacion != null || tj.PreEliminado || tj.Eliminado)).ConfigureAwait(false);
                    foreach (var jug in temjug)
                    {
                        jug.VecesPreEliminado = 0;
                        jug.VecesEliminado = 0;
                        jug.LastJornadaEliminacion = null;
                        jug.PreEliminado = false;
                        jug.Eliminado = false;
                        await _temporadaJugadorRepository.UpdateAsyn(jug, jug.Id).ConfigureAwait(false);
                    }
                }

                // Eliminar resultados de partidos
                ICollection<TemporadaPartidoDTO> partidos = await _temporadaPartidoRepository.GetPartidos(temporada, temporadaCompeticion).ConfigureAwait(false);
                foreach(var partido in partidos)
                {
                    partido.EquipoGanador = null;
                    partido.ResultadoA = 0;
                    partido.ResultadoB = 0;
                    await _temporadaPartidoRepository.UpdateAsyn(partido, partido.Id).ConfigureAwait(false);
                }

                // Eliminar datos de TemporadaEquipos
                var equipos = await _temporadaEquipoRepository.GetEquiposCompeticion(temporadaCompeticion).ConfigureAwait(false);
                foreach (var equipo in equipos)
                {
                    equipo.AlineacionLibre = false;
                    equipo.Diferencia = 0;
                    equipo.GolesContra = 0;
                    equipo.GolesFavor = 0;
                    equipo.GolesExtraContra = 0;
                    equipo.GolesExtraFavor = 0;
                    equipo.PartidosEmpatados = 0;
                    equipo.PartidosGanados = 0;
                    equipo.PartidosJugados = 0;
                    equipo.PartidosPerdidos = 0;
                    equipo.Puntos = 0;
                    await _temporadaEquipoRepository.UpdateAsyn(equipo, equipo.Id).ConfigureAwait(false);
                } 

                // Eliminar clasificaciones
                var clasificaciones = await _temporadaClasificacionRepository.FindAllAsync(tc => tc.TemporadaId.Equals(temporada.Id)
                        && tc.CompeticionId.Equals(temporadaCompeticion.CompeticionId)).ConfigureAwait(false);
                await _temporadaClasificacionRepository.DeleteRangeAsyn(clasificaciones).ConfigureAwait(false);

                // TemporadaCompeticion, estadoActual, operacionActual y descripcion estado
                var estado = await _estadoCompeticionRepository.FindAsync(e => e.Estado.Equals(LigamaniaConst.Estado_Jornada_Inicial)).ConfigureAwait(false);
                var operacion = await _operacionCompeticionRepository.FindAsync(o => o.Operacion.Equals(LigamaniaConst.Operacion_Inicial)).ConfigureAwait(false);
                temporadaCompeticion.EstadoActual = estado;
                temporadaCompeticion.OperacionActual = operacion;
                temporadaCompeticion.DescripcionEstado = string.Empty;
                await _temporadaCompeticionRepository.UpdateAsyn(temporadaCompeticion, temporadaCompeticion.Id).ConfigureAwait(false);

                await _temporadaCompeticionRepository.SaveAsync().ConfigureAwait(false);

                return new Response { Message = "Competición " + competicionPC.Competicion + " RESETEADA", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
            }
        }
        public async Task<Response> ResetearAlineaciones(TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return new Response { Message = "No existe temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await _temporadaCompeticionRepository
                        .FindIncludingAsync(tc => tc.TemporadaId.Equals(temporada.Id) && tc.Competicion.Nombre.Equals(competicionPC.Competicion),
                        tc => tc.Competicion, tc => tc.EstadoActual, tc => tc.OperacionActual).ConfigureAwait(false);
                if (temporadaCompeticion == null)
                    return new Response { Message = "No existe la competición en la temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                //TemporadaCompeticionJornada_DTO jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaActual(temporadaCompeticion.Competicion.Id, temporada.Nombre);
                //if (jornadaActual == null)
                //    return new Response { Message = "No existe jornada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                // Eliminar todos los registros de TemporadaJornadaJugador de las jornadas de la competicion elegida
                var temJorJug = await _temporadaJornadaJugadorRepository.FindAllAsync(
                    tjj => tjj.Temporada.Actual && tjj.Jornada.CompeticionId.Equals(temporadaCompeticion.CompeticionId)).ConfigureAwait(false);
                await _temporadaJornadaJugadorRepository.DeleteRangeAsyn(temJorJug).ConfigureAwait(false);

                // Eliminar todas las alineaciones de una competición en la temporada actual
                var alineacionesCambios = await _alineacionCambiosRepository.FindAllAsync(ac => ac.Temporada_ID.Equals(temporadaCompeticion.TemporadaId)
                   && ac.Competicion_ID.Equals(temporadaCompeticion.Competicion.Id)).ConfigureAwait(false);
                var alineacionesPrevias = await _alineacionPreviaRepository.FindAllAsync(ac => ac.Temporada_ID.Equals(temporadaCompeticion.TemporadaId)
                   && ac.Competicion_ID.Equals(temporadaCompeticion.Competicion.Id)).ConfigureAwait(false);
                var alineaciones = await _alineacionRepository.FindAllAsync(ac => ac.Temporada_ID.Equals(temporadaCompeticion.TemporadaId)
                   && ac.Competicion_ID.Equals(temporadaCompeticion.Competicion.Id)).ConfigureAwait(false);

                await _alineacionCambiosRepository.DeleteRangeAsyn(alineacionesCambios).ConfigureAwait(false);
                await _alineacionPreviaRepository.DeleteRangeAsyn(alineacionesPrevias).ConfigureAwait(false);
                await _alineacionRepository.DeleteRangeAsyn(alineaciones).ConfigureAwait(false);

                await _alineacionCambiosRepository.SaveAsync().ConfigureAwait(false);

                return new Response { Message = "Competición " + competicionPC.Competicion + " RESETEADAS ALINEACIONES", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
            }

        }

        public async Task<ICollection<CompeticionCategoriaViewModel>> GetReferenciaClasificaciones()
        {
            var referencias = await _temporadaCompeticionCategoriaReferenciaRepository
                .GetAllIncludingAsync(r => r.Competicion, r => r.Categoria).ConfigureAwait(false);

            var referenciasDict = referencias.GroupBy(r => new { Competicion=r.Competicion.Nombre, Categoria=r.Categoria.Nombre })
                .ToDictionary(rd => rd.Key, rd => rd.ToList());

            List<CompeticionCategoriaViewModel> lista = new List<CompeticionCategoriaViewModel>();
            lista = referenciasDict.Select(r => new CompeticionCategoriaViewModel
            {
                Categoria = r.Key.Categoria,
                Competicion = r.Key.Competicion,
                Referencias = r.Value.Select(refe => new ReferenciaCompeticionViewModel
                {
                    Id = refe.Id,
                    Color = refe.Color,
                    Descripcion = refe.Descripcion,
                    EsPremio = refe.EsPremio,
                    Marca = refe.Marca,
                    OrdenCategoria = refe.Categoria.Orden,
                    OrdenCompeticion = refe.Competicion.Orden,
                    PosicionFinal = refe.PosicionFinal,
                    PosicionInicial = refe.PosicionInicial,
                    UsarColor = refe.UsarColor,
                    UsarMarca = refe.UsarMarca

                }).ToList()
            }).ToList();
            return lista;
        }
        public async Task<Response> EditarReferenciaCompeticion(AccionCambiarReferencia referencia)
        {
            try
            {
                if (referencia == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };
                var refeToEdit = await _temporadaCompeticionCategoriaReferenciaRepository.GetAsync(referencia.Id).ConfigureAwait(false);
                if (refeToEdit!=null)
                {
                    refeToEdit.Color = referencia.Color;
                    //refeToEdit.Argb = referencia.Argb;
                    refeToEdit.Descripcion = referencia.Descripcion;
                    refeToEdit.EsPremio = referencia.EsPremio;
                    refeToEdit.Marca = referencia.Marca;
                    refeToEdit.PosicionFinal = referencia.PosicionFinal;
                    refeToEdit.PosicionInicial = referencia.PosicionInicial;
                    refeToEdit.UsarColor = referencia.UsarColor;
                    refeToEdit.UsarMarca = referencia.UsarMarca;

                    await _temporadaCompeticionCategoriaReferenciaRepository.UpdateAsyn(refeToEdit,refeToEdit.Id).ConfigureAwait(false);
                    await _temporadaCompeticionCategoriaReferenciaRepository.SaveAsync().ConfigureAwait(false);
                }
                return new Response { Message = "Modificación realizada correctamente", Result = true, Status = EResponseStatus.Success };
            }
            catch(Exception x)
            {
                _logger.LogError("[EditarReferenciaCompeticion]: " + x);
                return new Response { Message = "Errores al realizar la modificación", Result = false, Status = EResponseStatus.Error};
            }
        }
        public async Task<Response> AgregarReferenciaCompeticion(AccionCambiarReferencia referencia)
        {
            try
            {
                if (referencia == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };
                var existsEdit = await _temporadaCompeticionCategoriaReferenciaRepository.ExistsAsync(r=>r.Competicion.Nombre.Equals(referencia.Competicion)
                    && r.Categoria.Nombre.Equals(referencia.Categoria)&&r.PosicionInicial.Equals(referencia.PosicionInicial)&&r.PosicionFinal.Equals(referencia.PosicionFinal)).ConfigureAwait(false);
                if (existsEdit) return new Response { Message = "Ya existe una referencia en la competición con esas posiciones", Result = false, Status = EResponseStatus.Warning };

                var comp = await _competicionRepository.GetByNameAsync(referencia.Competicion).ConfigureAwait(false);
                var cate = await _categoriaRepository.GetByNameAsync(referencia.Categoria).ConfigureAwait(false);
                var refeToEdit = new TemporadaCompeticionCategoriaReferenciaDTO();
                refeToEdit.Competicion = comp;
                refeToEdit.Categoria = cate;
                refeToEdit.Color = referencia.Color;
                refeToEdit.Descripcion = referencia.Descripcion;
                refeToEdit.EsPremio = referencia.EsPremio;
                refeToEdit.Marca = referencia.Marca;
                refeToEdit.PosicionFinal = referencia.PosicionFinal;
                refeToEdit.PosicionInicial = referencia.PosicionInicial;
                refeToEdit.UsarColor = referencia.UsarColor;
                refeToEdit.UsarMarca = referencia.UsarMarca;

                await _temporadaCompeticionCategoriaReferenciaRepository.AddAsyn(refeToEdit).ConfigureAwait(false);
                await _temporadaCompeticionCategoriaReferenciaRepository.SaveAsync().ConfigureAwait(false);

                return new Response { Message = "Referencia añadida correctamente", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError("[AgregarReferenciaCompeticion]: " + x);
                return new Response { Message = "Errores al realizar la modificación", Result = false, Status = EResponseStatus.Error };
            }
        }
        public async Task<Response> FinalizarCompeticion(TemporadaCompeticionViewModel competicion)
        {
            try
            {
                if (competicion == null) return new Response { Message = "El parámetro es null", Result = false, Status = EResponseStatus.Warning };
                // Guardar en tabla de histórico los puestos 
                await GuardarCompeticionEnHistorico(competicion).ConfigureAwait(false);

                // Desactivar la competición
                await DesactivarCompeticion(competicion).ConfigureAwait(false);

                return new Response { Message = "Competición finalizada", Result = true, Status = EResponseStatus.Success};
            }
            catch (Exception x)
            {
                _logger.LogError("[FinalizarCompeticion]: " + x);
                return new Response { Message = "Error finalizando competición", Result = false, Status = EResponseStatus.Error };
            }
        }

        private async Task GuardarCompeticionEnHistorico(TemporadaCompeticionViewModel competicionVM) //Temporada temporada, string competicion)
        {
            TemporadaCompeticionDTO temporadaCompeticion = await _temporadaCompeticionRepository.GetByIdIncludingAsync(competicionVM.Id,
                tc=>tc.Competicion).ConfigureAwait(false);

            TemporadaDTO temporadaActual = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
            TemporadaDTO temporadaHistorico = temporadaActual;
            if (temporadaCompeticion.Competicion.Nombre.Equals(LigamaniaConst.Competicion_Supercopa))
                temporadaHistorico = await _temporadaRepository.GetTemporadaAnteriorAsync(temporadaHistorico).ConfigureAwait(false);

            // Obtener la competicion y categorías
            var lCompeticionCategorias= await _competicionCategoriaRepository.FindAllIncludingAsync
                (cc => cc.Competicion.Nombre.Equals(temporadaCompeticion.Competicion.Nombre) && (cc.Categoria.Activa.HasValue && cc.Categoria.Activa.Value),
                cc => cc.Competicion, cc => cc.Categoria).ConfigureAwait(false);

            foreach (var competicionCategoria in lCompeticionCategorias)
            {
                // Obtener la última jornada de la competicion
                var jornadas = await _temporadaCompeticionJornadaRepository.FindAllAsync
                    (j => j.Temporada.Actual && j.CompeticionId.Equals(competicionCategoria.Competicion_Id)).ConfigureAwait(false);
                var ultimaJornada = jornadas.First(j => j.NumeroJornada == jornadas.Max(jj => jj.NumeroJornada));

                //// Obtener la clasificación de la última jornada ordenada por puntos
                //var clasificacion = await _temporadaClasificacionRepository.GetClasificaciones(competicionCategoria.Competicion_Id, competicionCategoria.Categoria_Id,ultimaJornada.Id);
                //var clasificaciones = clasificacion.ToList();

                TemporadaCompeticionCategoriaDTO temporadaCompeticionCategoria = await _temporadaCompeticionCategoriaRepository.GetCategoria(
                    temporadaActual.Id, competicionCategoria.Competicion_Id, competicionCategoria.Categoria_Id).ConfigureAwait(false);

                ICollection<TemporadaCompeticionCategoriaReferenciaDTO> referencias = new List<TemporadaCompeticionCategoriaReferenciaDTO>();
                ICollection<TemporadaClasificacionDTO> clasificaciones = await _temporadaClasificacionRepository
                    .GetClasificaciones(competicionCategoria.Competicion_Id, competicionCategoria.Categoria_Id, ultimaJornada.Id).ConfigureAwait(false);
                ICollection<TemporadaClasificacionDTO> clasificacionesSinBot = await _temporadaClasificacionRepository
                    .GetClasificacionesSinBot(competicionCategoria.Competicion_Id, competicionCategoria.Categoria_Id, ultimaJornada.Id).ConfigureAwait(false);
                var lclasificacionesSinBot = clasificacionesSinBot.ToList();
                ClasificacionViewModel clasificacionVM = LigamaniaUtils.SetClasificacionViewModel(_mapper, competicionCategoria.Competicion, competicionCategoria, 
                    referencias, clasificaciones, clasificacionesSinBot, temporadaCompeticionCategoria);

                // Obtener el equipo que hizo más goles
                EquipoClasificacionViewModel equipoPichichi = null;
                if (competicionCategoria.Competicion.EsLiga)
                {
                    var equiposParaPichichi = clasificacionVM.Equipos.Where(e => e.PuestoSinBot > 3);
                    var maxGolesFavor = equiposParaPichichi.Max(e => e.GolesFavor);
                    equipoPichichi = equiposParaPichichi.First(e => e.GolesFavor == maxGolesFavor);
                }
                // Por cada equipo, actualizar la clasificación histórica
                for(int i = 0; i< clasificacionVM.Equipos.Count; i++)
                {
                    var equipo = clasificacionVM.Equipos[i];
                    var temporadaEquipo = await _temporadaEquipoRepository
                        .FindAsync(te=>te.Temporada.Id.Equals(temporadaActual.Id)
                        && te.CompeticionId.Equals(competicionCategoria.Competicion.Id) && te.CategoriaId.Equals(competicionCategoria.Categoria_Id)
                        && te.Equipo.Nombre.Equals(equipo.Equipo)).ConfigureAwait(false);
                    int puesto = await GetPuesto(equipo, temporadaEquipo).ConfigureAwait(false);
                    HistoricoDTO historico = new HistoricoDTO
                    {
                        Temporada = temporadaHistorico,
                        TemporadaCompeticionCategoria = temporadaCompeticionCategoria,
                        TemporadaEquipo = temporadaEquipo,
                        Puesto = puesto,
                        Pichichi = (equipoPichichi!=null && equipo.Equipo == equipoPichichi.Equipo)
                    };
                    if (!ExisteRegistroHistorico(historico))
                        await _historicoRepository.AddAsyn(historico).ConfigureAwait(false);
                    else
                    {
                        var registro = GetRegistroHistorico(historico);
                        registro.Puesto = historico.Puesto;
                        registro.Pichichi = historico.Pichichi;
                        await _historicoRepository.UpdateAsyn(registro, registro.Id).ConfigureAwait(false);
                    }
                }
                await _historicoRepository.SaveAsync().ConfigureAwait(false);
            }
        }

        private async Task<int> GetPuesto(EquipoClasificacionViewModel equipo, TemporadaEquipoDTO temporadaEquipo)
        {
            if (!temporadaEquipo.Competicion.EsCopa)
                return equipo.PuestoSinBot;

            // si es copa, hay que mirar hasta que ronda llegó para determinar el puesto
            int rondaEliminado = await GetRondaCuadroEliminado(temporadaEquipo.Temporada.Id, temporadaEquipo.Equipo.Nombre).ConfigureAwait(false);
            EPremio puesto = GetPuestoPremio(rondaEliminado);
            if (puesto == EPremio.Desconocido)
                puesto = await GetPremioCuadro(temporadaEquipo.Temporada.Id, temporadaEquipo.Equipo.Nombre, rondaEliminado).ConfigureAwait(false);
            return (int)puesto;
        }
        private EPremio GetPuestoPremio(int rondaEliminado)
        {
            switch (rondaEliminado)
            {
                case 1: return EPremio.PrimeraRonda;
                case 2: return EPremio.SegundaRonda;
                case 3: return EPremio.Dieciseisavos;
                case 4: return EPremio.Octavos;
                case 5: return EPremio.Cuartos;
                case 6: return EPremio.Semifinales;
                case 7: return EPremio.Desconocido;
                default: return EPremio.Previa;
            }
        }
        private async Task<EPremio> GetPremioCuadro(int temporadaId, string equipo, int maxRonda)
        {
            var partido = await _temporadaCuadroRepository.FindAsync(tc => tc.TemporadaId.Equals(temporadaId) && (tc.NombreEquipoA.Equals(equipo) || tc.NombreEquipoB.Equals(equipo)) && tc.Ronda == maxRonda).ConfigureAwait(false);
            if (string.IsNullOrEmpty(partido.NombreGanador)) return EPremio.Desconocido;
            if (partido.NombreGanador.Equals(equipo)) return EPremio.Campeon;
            return EPremio.Subcampeon;
        }

        //Devuelve la ronda en la que fue eliminado. De todas las rondas en las que participó, la última
        private async Task<int> GetRondaCuadroEliminado(int temporadaId, string equipo)
        {
            var rondas = await _temporadaCuadroRepository.FindAllAsync(tc => tc.TemporadaId.Equals(temporadaId) && (tc.NombreEquipoA.Equals(equipo) || tc.NombreEquipoB.Equals(equipo))).ConfigureAwait(false);
            if (rondas.Any())
            {
                var maxRonda = rondas.Max(r => r.Ronda);
                return maxRonda;
            }
            return 0;
        }
        private bool ExisteRegistroHistorico(HistoricoDTO historico)
        {
            var existe = _historicoRepository.Exists(h => h.Temporada.Id.Equals(historico.Temporada.Id)
                 && h.Categoria_ID.Equals(historico.TemporadaCompeticionCategoria.Id) && h.Equipo_ID.Equals(historico.TemporadaEquipo.Id));
            return existe;
        }
        private HistoricoDTO GetRegistroHistorico(HistoricoDTO historico)
        {
            var registro = _historicoRepository.Find(h => h.Temporada.Id.Equals(historico.Temporada.Id)
                 && h.Categoria_ID.Equals(historico.TemporadaCompeticionCategoria.Id) && h.Equipo_ID.Equals(historico.TemporadaEquipo.Id));
            return registro;
        }
        private async Task DesactivarCompeticion(TemporadaCompeticionViewModel competicion)
        {
            TemporadaDTO temporadaActual = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
            TemporadaCompeticionDTO temporadaCompeticion = await _temporadaCompeticionRepository.GetByIdIncludingAsync(competicion.Id,
                tc => tc.Competicion).ConfigureAwait(false);

            //TemporadaCompeticion_DTO temporadaCompeticion = await _temporadaCompeticionRepository.GetCompeticion(temporadaActual.Id, temporadaCompeticion.Competicion.Id);
            await DesactivarCompeticion(temporadaCompeticion).ConfigureAwait(false);
        }

        public async Task<Response> EstablecerEquiposCopa(PreparacionTemporadaViewModel competicion)
        {
            try
            {
                if (competicion==null)
                    return new Response { Message = "Error estableciendo equipos: no se encuentra la competición", Result = false, Status = EResponseStatus.Warning};

                // a partir del cuadro de copa y de la jornada seleccionada de Liga, establecer los equipos del cuadro según la clasificación de dicha jornada
                TemporadaDTO temporadaActual = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporadaActual==null)
                    return new Response { Message = "Error estableciendo equipos: no se encuentra la temporada actual", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await _temporadaCompeticionRepository
                    .GetCompeticion(temporadaActual.Id, competicion.CompeticionDestino).ConfigureAwait(false);

                if (temporadaCompeticion==null)
                    return new Response { Message = "Error estableciendo equipos: no se encuentra la competición en la temporada actual", Result = false, Status = EResponseStatus.Warning };

                // obtener el cuadro
                List<CuadroCopaDTO> cuadroCopa = await GetCuadroCopa().ConfigureAwait(false);

                Response response = await SetEquiposCopa(temporadaActual, temporadaCompeticion, cuadroCopa).ConfigureAwait(false);

                return response;
            }
            catch (Exception x)
            {
                _logger.LogError(x.ToString());
                return new Response { Message = "Error estableciendo equipos de COPA", Result = false, Status = EResponseStatus.Error };
            }
        }

        private async Task<Response> SetEquiposCopa(TemporadaDTO temporadaActual, TemporadaCompeticionDTO competicionCopa, List<CuadroCopaDTO> cuadroCopa)
        {
            try
            {
                if (temporadaActual==null || competicionCopa==null || cuadroCopa==null)
                {
                    _logger.LogError("Parámetros incorrectos");
                    return new Response { Message = "Parámetros incorrectos.", Result = false, Status = EResponseStatus.Error };
                }

                TemporadaCompeticionDTO competicionLiga = await _temporadaCompeticionRepository
                    .GetCompeticion(temporadaActual.Id, competicionCopa.Competicion.CompeticionCopiarAliIni).ConfigureAwait(false);
                if (competicionLiga==null)
                    return new Response { Message = "Competición Liga no encontrada.", Result = false, Status = EResponseStatus.Warning };

                // Obtener las clasificaciones de la jornada establecida
                TemporadaCompeticionJornadaDTO jornada = await _temporadaCompeticionJornadaRepository.GetJornada(temporadaActual.Id, competicionLiga.CompeticionId, competicionCopa.Competicion.JornadaCuadro).ConfigureAwait(false);
                if (jornada==null)
                    return new Response { Message = "Jornada de Liga no encontrada.", Result = false, Status = EResponseStatus.Warning };

                ICollection<CompeticionCategoriaDTO> categorias = await _competicionCategoriaRepository.GetByCompeticion(competicionLiga.Competicion.Nombre).ConfigureAwait(false);
                if (categorias==null ||!categorias.Any())
                    return new Response { Message = "Categorías de Liga no encontradas.", Result = false, Status = EResponseStatus.Warning };

                List<ClasificacionViewModel> listaClasificaciones = new List<ClasificacionViewModel>();
                foreach (var categoria in categorias)
                {
                    var temporadaCompCat = await _temporadaCompeticionCategoriaRepository.GetCategoria(temporadaActual.Id, competicionLiga.CompeticionId, categoria.Categoria_Id).ConfigureAwait(false);
                    ICollection<TemporadaCompeticionCategoriaReferenciaDTO> referencias = 
                        await _temporadaCompeticionCategoriaReferenciaRepository.GetReferencias(competicionLiga.CompeticionId, categoria.Categoria_Id).ConfigureAwait(false);
                    ICollection<TemporadaClasificacionDTO> clasificaciones = 
                        await _temporadaClasificacionRepository.GetClasificaciones(competicionLiga.CompeticionId, categoria.Categoria.Id, jornada.Id).ConfigureAwait(false);
                    ICollection<TemporadaClasificacionDTO> clasificacionesSinBot = 
                        await _temporadaClasificacionRepository.GetClasificacionesSinBot(competicionLiga.CompeticionId, categoria.Categoria.Id, jornada.Id).ConfigureAwait(false);
                    ClasificacionViewModel clasificacionVM = LigamaniaUtils.SetClasificacionViewModel(_mapper,
                                                                                                      competicionLiga.Competicion,
                                                                                                      categoria,
                                                                                                      referencias,
                                                                                                      clasificaciones,
                                                                                                      clasificacionesSinBot,
                                                                                                      temporadaCompCat);
                    listaClasificaciones.Add(clasificacionVM);
                }

                var categoriaCopa = await _categoriaRepository.GetByNameAsync(LigamaniaConst.Categoria_SinCategoria).ConfigureAwait(false);
                // por cada fila del cuadro, busco el equipo y añado la fila a TemporadaCuadro, según la temporada actual
                foreach (var filaCuadro in cuadroCopa)
                {
                    string equipoA = await GetEquipoSegunCuadro(temporadaActual, filaCuadro.CompeticionCategoriaEquipoA, filaCuadro.PuestoPartidoEquipoA, listaClasificaciones).ConfigureAwait(false);
                    string equipoB = await GetEquipoSegunCuadro(temporadaActual, filaCuadro.CompeticionCategoriaEquipoB, filaCuadro.PuestoPartidoEquipoB, listaClasificaciones).ConfigureAwait(false);

                    // Verificar que los equipos existan en la temporada actual en la tabla TemporadaEquipo
                    if (!string.IsNullOrEmpty(equipoA)) await AgregaEquipoTemporada(temporadaActual, competicionCopa, categoriaCopa, equipoA).ConfigureAwait(false);
                    if (!string.IsNullOrEmpty(equipoB)) await AgregaEquipoTemporada(temporadaActual, competicionCopa, categoriaCopa, equipoB).ConfigureAwait(false);

                    await AgregaEquipoTemporadaCuadroAsync(filaCuadro, temporadaActual, competicionCopa, equipoA, equipoB).ConfigureAwait(false);
                }
                await _temporadaCuadroRepository.SaveAsync().ConfigureAwait(false);
                await _temporadaEquipoRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Equipos de COPA establecidos", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.ToString());
                return new Response { Message = "Error estableciendo equipos de COPA", Result = false, Status = EResponseStatus.Error };
            }
        }

        private async Task AgregaEquipoTemporadaCuadroAsync(CuadroCopaDTO filaCuadro, TemporadaDTO temporadaActual, TemporadaCompeticionDTO competicionCopa, string equipoA, string equipoB)
        {
            TemporadaCompeticionCategoriaDTO temporadaCompeticionCategoriaEquipoA =
                await _temporadaCompeticionCategoriaRepository.GetCategoria(temporadaActual.Id,
                                                                            filaCuadro.CompeticionCategoriaEquipoA.Competicion_Id,
                                                                            filaCuadro.CompeticionCategoriaEquipoA.Categoria_Id)
                .ConfigureAwait(false);
            TemporadaCompeticionCategoriaDTO temporadaCompeticionCategoriaEquipoB =
                await _temporadaCompeticionCategoriaRepository.GetCategoria(temporadaActual.Id,
                                                                            filaCuadro.CompeticionCategoriaEquipoB.Competicion_Id,
                                                                            filaCuadro.CompeticionCategoriaEquipoB.Categoria_Id)
                .ConfigureAwait(false);

            TemporadaCompeticionDTO temporadaCompeticionEquipoA = await _temporadaCompeticionRepository.GetCompeticion(temporadaActual.Id, filaCuadro.CompeticionCategoriaEquipoA.Competicion.Nombre).ConfigureAwait(false);
            TemporadaCompeticionDTO temporadaCompeticionEquipoB = await _temporadaCompeticionRepository.GetCompeticion(temporadaActual.Id, filaCuadro.CompeticionCategoriaEquipoB.Competicion.Nombre).ConfigureAwait(false);

            TemporadaCuadroDTO temporadaCuadro = GetTemporadaCuadro(temporadaActual.Id, filaCuadro.Ronda, filaCuadro.NumPartido);
            if (temporadaCuadro == null)
            {
                // Agregar el partido de cuadro a la temporada actual
                temporadaCuadro = new TemporadaCuadroDTO
                {
                    Temporada = temporadaActual,
                    Competicion = competicionCopa,
                    EquipoACategoria = temporadaCompeticionCategoriaEquipoA,
                    EquipoACompeticion = temporadaCompeticionEquipoA,
                    EquipoAPuesto = filaCuadro.PuestoPartidoEquipoA,
                    EquipoBCategoria = temporadaCompeticionCategoriaEquipoB,
                    EquipoBCompeticion = temporadaCompeticionEquipoB,
                    EquipoBPuesto = filaCuadro.PuestoPartidoEquipoB,
                    NombreEquipoA = equipoA,
                    NombreEquipoB = equipoB,
                    NumeroPartido = filaCuadro.NumPartido,
                    Ronda = filaCuadro.Ronda,
                    Orden = filaCuadro.Orden
                };
                await _temporadaCuadroRepository.AddAsyn(temporadaCuadro).ConfigureAwait(false);
            }
            else
            {
                temporadaCuadro.NombreEquipoA = equipoA;
                temporadaCuadro.NombreEquipoB = equipoB;
                await _temporadaCuadroRepository.UpdateAsyn(temporadaCuadro, temporadaCuadro.Id).ConfigureAwait(false);
            }
        }
        public async Task<Response> EstablecerRondasJornadasCopa(PreparacionTemporadaViewModel competicion)
        {
            try
            {
                if (competicion == null)
                    return new Response { Message = "Error estableciendo rondas y jornadas de copa: no se encuentra la competición", Result = false, Status = EResponseStatus.Warning };

                // a partir del cuadro de copa y de la jornada seleccionada de Liga, establecer los equipos del cuadro según la clasificación de dicha jornada
                TemporadaDTO temporadaActual = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporadaActual == null)
                    return new Response { Message = "Error estableciendo rondas y jornadas de copa: no se encuentra la temporada actual", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await _temporadaCompeticionRepository
                    .GetCompeticion(temporadaActual.Id, competicion.CompeticionDestino).ConfigureAwait(false);

                if (temporadaCompeticion == null)
                    return new Response { Message = "Error estableciendo rondas y jornadas de copa: no se encuentra la competición en la temporada actual", Result = false, Status = EResponseStatus.Warning };

                // obtener el cuadro
                var cuadroCopa = await GetCuadroCopa().ConfigureAwait(false);

                var response = await SetRondasJornadasCopa(temporadaActual, temporadaCompeticion, cuadroCopa,competicion.Fecha).ConfigureAwait(false);

                return response;
            }
            catch (Exception x)
            {
                _logger.LogError(x.ToString());
                return new Response { Message = "Error estableciendo rondas y jornadas de COPA", Result = false, Status = EResponseStatus.Error };
            }
        }

        private async Task<Response> SetRondasJornadasCopa(TemporadaDTO temporada, TemporadaCompeticionDTO temporadaCompeticion,
            List<CuadroCopaDTO> cuadroCopa, DateTime fechaInicial)
        {
            try
            {
                DateTime fecha = fechaInicial;
                int jornada = 1;
                var listaRondas = cuadroCopa.GroupBy(cc => cc.Ronda).Select(grp => grp.FirstOrDefault()).Select(cc => cc.Ronda).OrderBy(r => r).ToList();
                var lastRonda = cuadroCopa.Max(cc => cc.Ronda);
                for (int i = 0; i < listaRondas.Count; i++)
                {
                    int ronda = listaRondas[i];
                    // Agregar la ronda si no existe
                    var existeRonda = await _temporadaRondaRepository
                        .ExistsAsync(tr => tr.TemporadaID.Equals(temporada.Id)
                            && tr.CompeticionID.Equals(temporadaCompeticion.CompeticionId)
                            && tr.NumRonda.Equals(ronda)).ConfigureAwait(false);
                    bool nuevaRonda = false;
                    TemporadaRondaDTO temporadaRondaDTO = new TemporadaRondaDTO();
                    if (!existeRonda)
                    {
                        temporadaRondaDTO = new TemporadaRondaDTO
                        {
                            Competicion = temporadaCompeticion.Competicion,
                            NumRonda = ronda,
                            RondaFinal = ronda == lastRonda,
                            Temporada = temporada
                        };
                        nuevaRonda = true;
                    }
                    else
                    {
                        temporadaRondaDTO = await _temporadaRondaRepository
                            .FindAsync(tr => tr.TemporadaID.Equals(temporada.Id) && tr.NumRonda.Equals(ronda)).ConfigureAwait(false);
                    }
                    // Agregar la jornada de ida
                    if (nuevaRonda || temporadaRondaDTO.JornadaIda == null)
                    {
                        TemporadaCompeticionJornadaDTO jornadaIdaCreada = await CreateJornada(temporada, temporadaCompeticion, fecha, jornada, null).ConfigureAwait(false);
                        temporadaRondaDTO.JornadaIda = jornadaIdaCreada;
                    }
                    jornada++;
                    fecha = fecha.AddDays(7);
                    // Agregar la jornada de vuelta
                    if (!temporadaRondaDTO.RondaFinal && (nuevaRonda || temporadaRondaDTO.JornadaVuelta == null))
                    {
                        TemporadaCompeticionJornadaDTO jornadaVueltaCreada = await CreateJornada(temporada, temporadaCompeticion, fecha, jornada, null).ConfigureAwait(false);
                        temporadaRondaDTO.JornadaVuelta = jornadaVueltaCreada;
                    }
                    jornada++;
                    fecha = fecha.AddDays(7);
                    if (nuevaRonda)
                        await _temporadaRondaRepository.AddAsyn(temporadaRondaDTO).ConfigureAwait(false);
                }
                await _temporadaCompeticionJornadaRepository.SaveAsync().ConfigureAwait(false);
                await _temporadaRondaRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Rondas y jornadas de copa actualizadas", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error estableciendo rondas y jornadas de copa", Result = false, Status = EResponseStatus.Error };
            }
        }

        private async Task<TemporadaCompeticionJornadaDTO> CreateJornada(TemporadaDTO temporada, 
            TemporadaCompeticionDTO temporadaCompeticion, 
            DateTime fecha, 
            int jornada,
            TemporadaRondaDTO ronda)
        {
            TemporadaCompeticionJornadaDTO jornadaIda = new TemporadaCompeticionJornadaDTO
            {
                Temporada = temporada,
                Competicion = temporadaCompeticion.Competicion,
                Fecha = fecha,
                NumeroJornada = jornada,
                Ronda = ronda
            };
            var jornadaIdaCreada = await _temporadaCompeticionJornadaRepository.AddAsyn(jornadaIda).ConfigureAwait(false);
            return jornadaIdaCreada;
        }

        private async Task AgregaEquipoTemporada(TemporadaDTO temporadaActual, TemporadaCompeticionDTO competicion, CategoriaDTO categoria, string equipo)
        {
            var existeEquipo = await _temporadaEquipoRepository.ExistsAsync(te => te.TemporadaId.Equals(temporadaActual.Id) 
                && te.CompeticionId.Equals(competicion.CompeticionId)
                && te.CategoriaId.Equals(categoria.Id)
                && te.Equipo.Nombre.Equals(equipo)).ConfigureAwait(false);
            if (!existeEquipo)
            {
                EquipoDTO regEquipo = await _equipoRepository.GetByNameAsync(equipo).ConfigureAwait(false);
                if (regEquipo != null)
                {
                    TemporadaEquipoDTO temporadaEquipo = new TemporadaEquipoDTO
                    {
                        Temporada = temporadaActual,
                        Equipo = regEquipo,
                        Baja = false,
                        Categoria = categoria,
                        Competicion = competicion.Competicion,
                        ConfirmadaTemporada = true,
                        PagadaTemporada = true
                    };
                    await _temporadaEquipoRepository.AddAsyn(temporadaEquipo).ConfigureAwait(false);
                }
            }
        }

        private bool ExisteTemporadaCuadro(ref TemporadaCuadroDTO temporadaCuadro)
        {
            var tempId = temporadaCuadro.Temporada.Id;
            var ronda = temporadaCuadro.Ronda;
            var numPar = temporadaCuadro.NumeroPartido;

            var temCua = _temporadaCuadroRepository.Find(tc => tc.TemporadaId.Equals(tempId)
                && tc.Ronda.Equals(ronda) && tc.NumeroPartido.Equals(numPar));

            if (temCua != null)
            {
                temporadaCuadro.Id = temCua.Id;
            }
            return temCua != null;
        }
        private TemporadaCuadroDTO GetTemporadaCuadro(int tempId, int ronda, int numPar)
        {
            var temCua = _temporadaCuadroRepository.Find(tc => tc.TemporadaId.Equals(tempId)
                && tc.Ronda.Equals(ronda) && tc.NumeroPartido.Equals(numPar));

            return temCua;
        }
        private async Task<string> GetEquipoSegunCuadro(TemporadaDTO temporadaActual, CompeticionCategoriaDTO competicionCategoriaEquipo, int puestoPartidoEquipo, List<ClasificacionViewModel> listaClasificaciones)
        {
            if (competicionCategoriaEquipo.Competicion.Nombre.Equals(LigamaniaConst.Competicion_Liga))
            {
                var compCategoria = competicionCategoriaEquipo.Competicion.Nombre + " - " + competicionCategoriaEquipo.Categoria.Nombre;
                var clasiCategoria = listaClasificaciones.FirstOrDefault(c => c.Categoria.Equals(compCategoria));

                var equipoClasi = clasiCategoria.Equipos.FirstOrDefault(e => e.PuestoSinBot.Equals(puestoPartidoEquipo));

                if (equipoClasi == null) return LigamaniaConst.Equipo_Bay;
                var equipo = await _equipoRepository.GetByNameAsync(equipoClasi.Equipo).ConfigureAwait(false);
                return equipo.Nombre;
            }
            else
            {
                var tempCuadro = await _temporadaCuadroRepository.FindAsync(tc => tc.TemporadaId.Equals(temporadaActual.Id) && tc.NumeroPartido.Equals(puestoPartidoEquipo)).ConfigureAwait(false);
                if (tempCuadro!=null && !string.IsNullOrEmpty(tempCuadro.NombreGanador))
                {
                    var equipo = await _equipoRepository.GetByNameAsync(tempCuadro.NombreGanador).ConfigureAwait(false);
                    return equipo.Nombre;
                }
            }
            return null;
        }
        public async Task<Response> NuevaJornadaFinalCopa(PreparacionTemporadaViewModel competicion)
        {
            try
            {
                if (competicion == null)
                    return new Response { Message = "Error estableciendo rondas y jornadas de copa: no se encuentra la competición", Result = false, Status = EResponseStatus.Warning };

                // a partir del cuadro de copa y de la jornada seleccionada de Liga, establecer los equipos del cuadro según la clasificación de dicha jornada
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return new Response { Message = "Error estableciendo rondas y jornadas de copa: no se encuentra la temporada actual", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await _temporadaCompeticionRepository
                    .GetCompeticion(temporada.Id, competicion.CompeticionDestino).ConfigureAwait(false);

                if (temporadaCompeticion == null)
                    return new Response { Message = "Error estableciendo rondas y jornadas de copa: no se encuentra la competición en la temporada actual", Result = false, Status = EResponseStatus.Warning };

                // obtener el cuadro
                var cuadroCopa = await GetCuadroCopa().ConfigureAwait(false);

                //DateTime fecha = competicion.Fecha;
                var listaRondas = cuadroCopa.GroupBy(cc => cc.Ronda).Select(grp => grp.FirstOrDefault()).Select(cc => cc.Ronda).OrderBy(r => r).ToList();
                var lastRonda = cuadroCopa.Max(cc => cc.Ronda);
                int ronda = lastRonda;
                TemporadaRondaDTO temporadaRondaDTO = await _temporadaRondaRepository
                        .FindIncludingAsync(tr => tr.TemporadaID.Equals(temporada.Id) && tr.NumRonda.Equals(ronda),
                            tr=>tr.JornadaIda, tr=>tr.JornadaVuelta).ConfigureAwait(false);

                TemporadaCompeticionJornadaDTO ultimaJornada;
                int lastJornada = GetLastJornada(temporadaRondaDTO,out ultimaJornada);
                int jornada = lastJornada + 1;
                DateTime fecha = ultimaJornada.Fecha.AddDays(7);

                TemporadaCompeticionJornadaDTO jornadaCreada = await CreateJornada(temporada, temporadaCompeticion, fecha, jornada,temporadaRondaDTO).ConfigureAwait(false);
                jornadaCreada.Actual = true;
                temporadaRondaDTO.JornadasFinal.Add(jornadaCreada);
                
                temporadaRondaDTO.GenerarJornadaFinal = false;
                //temporadaRondaDTO.JornadaIdaActiva = true;
                ultimaJornada.Actual = false;

                var response = await AgregarPartidoRondaFinal(competicion, temporadaRondaDTO, jornadaCreada).ConfigureAwait(false);
                if (!response.Result) return response;

                await _temporadaCompeticionJornadaRepository.SaveAsync().ConfigureAwait(false);
                await _temporadaRondaRepository.SaveAsync().ConfigureAwait(false);
                await _temporadaPartidoRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Nueva jornada final añadida", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error añadiendo nueva jornada final", Result = false, Status = EResponseStatus.Error };
            }
        }

        private async Task<Response> AgregarPartidoRondaFinal(PreparacionTemporadaViewModel competicion, TemporadaRondaDTO temporadaRondaDTO, TemporadaCompeticionJornadaDTO jornadaCreada)
        {
            try
            {
                // a partir del cuadro de copa y de la jornada seleccionada de Liga, establecer los equipos del cuadro según la clasificación de dicha jornada
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return new Response { Message = "Error añadiendo partidos de copa: no se encuentra la temporada actual", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await _temporadaCompeticionRepository
                    .GetCompeticion(temporada.Id, competicion.CompeticionDestino).ConfigureAwait(false);

                if (temporadaCompeticion == null)
                    return new Response { Message = "EError añadiendo partidos de copa: no se encuentra la competición en la temporada actual", Result = false, Status = EResponseStatus.Warning };

                // obtener el cuadro
                //var cuadroCopa = await GetCuadroCopa().ConfigureAwait(false);
                var competicionCategoriaDestino = await _competicionCategoriaRepository.FindAsync(
                    cc => cc.Competicion.Nombre.Equals(competicion.CompeticionDestino) && cc.Categoria.Nombre.Equals(competicion.Categoria)).ConfigureAwait(false);
                var partidosExistentes = await _temporadaPartidoRepository.FindAllAsync(
                       tp => tp.Temporada.Actual && tp.CompeticionId.Equals(competicionCategoriaDestino.Competicion_Id)).ConfigureAwait(false);
                int numPartidos = 0;
                if (partidosExistentes.Any()) numPartidos = partidosExistentes.Count;
                var equipos = await GetEquipos(temporada.Id, competicionCategoriaDestino.Competicion_Id, competicionCategoriaDestino.Categoria_Id).ConfigureAwait(false);
                var equipoA = equipos.First(e => e.EquipoId.Equals(temporadaRondaDTO.JornadaIda.TemporadaPartido.First().EquipoA.Id));
                var equipoB = equipos.First(e => e.EquipoId.Equals(temporadaRondaDTO.JornadaIda.TemporadaPartido.First().EquipoB.Id));
                TemporadaPartidoViewModel partido = new TemporadaPartidoViewModel
                {
                    Jornada = jornadaCreada.NumeroJornada,
                    NumeroPartido = numPartidos++,
                    EquipoA = equipoA.Equipo.Nombre,
                    EquipoB = equipoB.Equipo.Nombre
                };
                var jornadas = new List<TemporadaCompeticionJornadaDTO>() { jornadaCreada };
                await CreaPartido(partido, equipos, jornadas, competicionCategoriaDestino).ConfigureAwait(false);
                return new Response { Message = "", Result = true, Status = EResponseStatus.Success };
            }
            catch(Exception x)
            {
                return new Response { Message = "Error generando partido", Result = false, Status = EResponseStatus.Error };
            }
        }

        private int GetLastJornada(TemporadaRondaDTO temporadaRondaDTO, out TemporadaCompeticionJornadaDTO ultimaJornada)
        {
            ultimaJornada = temporadaRondaDTO.JornadaIda;
            int lastJornada = temporadaRondaDTO.JornadaIda.NumeroJornada;
            if (temporadaRondaDTO.JornadasFinal.Any())
            {
                lastJornada = temporadaRondaDTO.JornadasFinal.Max(jf => jf.NumeroJornada);
                ultimaJornada = temporadaRondaDTO.JornadasFinal.FirstOrDefault(jf => jf.NumeroJornada == lastJornada);
            }
            else if (temporadaRondaDTO.JornadaVuelta != null)
            {
                lastJornada = temporadaRondaDTO.JornadaVuelta.NumeroJornada;
                ultimaJornada = temporadaRondaDTO.JornadaVuelta;
            }
            return lastJornada;
        }

        public async Task<Response> AgregarPartidosCopa(PreparacionTemporadaViewModel competicion)
        {
            try
            {
                if (competicion == null)
                    return new Response { Message = "Error añadiendo partidos de copa: no se encuentra la competición", Result = false, Status = EResponseStatus.Warning };

                // a partir del cuadro de copa y de la jornada seleccionada de Liga, establecer los equipos del cuadro según la clasificación de dicha jornada
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return new Response { Message = "Error añadiendo partidos de copa: no se encuentra la temporada actual", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await _temporadaCompeticionRepository
                    .GetCompeticion(temporada.Id, competicion.CompeticionDestino).ConfigureAwait(false);

                if (temporadaCompeticion == null)
                    return new Response { Message = "EError añadiendo partidos de copa: no se encuentra la competición en la temporada actual", Result = false, Status = EResponseStatus.Warning };

                // obtener el cuadro
                //var cuadroCopa = await GetCuadroCopa().ConfigureAwait(false);
                var competicionCategoriaDestino = await _competicionCategoriaRepository.FindAsync(
                    cc => cc.Competicion.Nombre.Equals(competicion.CompeticionDestino) && cc.Categoria.Nombre.Equals(competicion.Categoria)).ConfigureAwait(false);

                var equipos = await GetEquipos(temporada.Id, competicionCategoriaDestino.Competicion_Id, competicionCategoriaDestino.Categoria_Id).ConfigureAwait(false);

                // obtener la ronda con las jornadas
                var rondaCuadro = await _temporadaRondaRepository
                    .FindIncludingAsync(tr => tr.Temporada.Id.Equals(temporada.Id) && tr.NumRonda.Equals(competicion.Ronda), tr => tr.JornadaIda, tr => tr.JornadaVuelta).ConfigureAwait(false);

                ICollection<TemporadaCompeticionJornadaDTO> jornadas = await GetJornadasCuadro(rondaCuadro).ConfigureAwait(false);

                var partidosRonda = await _temporadaCuadroRepository.FindAllAsync(tc => tc.TemporadaId.Equals(temporada.Id) && tc.Ronda.Equals(competicion.Ronda)).ConfigureAwait(false);
                // generar los partidos de forma aleatoria
                var partidos = await GeneraPartidosFromCuadro(partidosRonda, rondaCuadro).ConfigureAwait(false);

                foreach (var partido in partidos)
                {
                    await CreaPartido(partido, equipos, jornadas, competicionCategoriaDestino).ConfigureAwait(false);
                }
                await _temporadaPartidoRepository.SaveAsync().ConfigureAwait(false);

                return new Response { Message = "Partidos de copa añadidos", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error añadiendo partidos de copa", Result = false, Status = EResponseStatus.Error };
            }
        }

        private async Task<ICollection<TemporadaCompeticionJornadaDTO>> GetJornadasCuadro(TemporadaRondaDTO rondaCuadro)
        {
            List<TemporadaCompeticionJornadaDTO> jornadas = new List<TemporadaCompeticionJornadaDTO>();
            if (rondaCuadro.JornadaIda != null)
                jornadas.Add(rondaCuadro.JornadaIda);
            if (rondaCuadro.JornadaVuelta != null)
                jornadas.Add(rondaCuadro.JornadaVuelta);
            if (rondaCuadro.JornadasFinal.Any())
                jornadas.AddRange(rondaCuadro.JornadasFinal);
            return await Task.FromResult(jornadas).ConfigureAwait(false);
        }

        private async Task<List<TemporadaPartidoViewModel>> GeneraPartidosFromCuadro(ICollection<TemporadaCuadroDTO> partidosRonda, TemporadaRondaDTO rondaCuadro)
        {
            List<TemporadaPartidoViewModel> partidos = new List<TemporadaPartidoViewModel>();
            foreach (var partidoCuadro in partidosRonda)
            {
                // jornada de ida 
                if (rondaCuadro.JornadaIda != null)
                {
                    if (partidoCuadro.NombreEquipoA != LigamaniaConst.Equipo_Bay
                        && partidoCuadro.NombreEquipoB != LigamaniaConst.Equipo_Bay)
                    {
                        partidos.Add(new TemporadaPartidoViewModel
                        {
                            Jornada = rondaCuadro.JornadaIda.NumeroJornada,
                            NumeroPartido = partidoCuadro.NumeroPartido != null ? (int)partidoCuadro.NumeroPartido : 0,
                            EquipoA = partidoCuadro.NombreEquipoA,
                            EquipoB = partidoCuadro.NombreEquipoB
                        });
                    }
                }
                // jornada de vuelta
                if (rondaCuadro.JornadaVuelta != null)
                {
                    if (partidoCuadro.NombreEquipoA != LigamaniaConst.Equipo_Bay
                        && partidoCuadro.NombreEquipoB != LigamaniaConst.Equipo_Bay)
                    {
                        partidos.Add(new TemporadaPartidoViewModel
                        {
                            Jornada = rondaCuadro.JornadaVuelta.NumeroJornada,
                            NumeroPartido = partidoCuadro.NumeroPartido != null ? (int)partidoCuadro.NumeroPartido : 0,
                            EquipoA = partidoCuadro.NombreEquipoB,
                            EquipoB = partidoCuadro.NombreEquipoA
                        });
                    }
                }
                // otras jornadas que se puedan haber añadido (para la final)
                if (rondaCuadro.JornadasFinal.Any())
                {
                    foreach(var jornada in rondaCuadro.JornadasFinal)
                    {
                        if (partidoCuadro.NombreEquipoA != LigamaniaConst.Equipo_Bay
                            && partidoCuadro.NombreEquipoB != LigamaniaConst.Equipo_Bay)
                        {
                            partidos.Add(new TemporadaPartidoViewModel
                            {
                                Jornada = jornada.NumeroJornada,
                                NumeroPartido = partidoCuadro.NumeroPartido != null ? (int)partidoCuadro.NumeroPartido : 0,
                                EquipoA = partidoCuadro.NombreEquipoB,
                                EquipoB = partidoCuadro.NombreEquipoA
                            });
                        }
                    }
                }
            }
            return await Task.FromResult(partidos).ConfigureAwait(false);
        }
        public async Task<Response> NuevoConceptoContabilidad(ContabilidadViewModel concepto)
        {
            try
            {
                if (concepto == null)
                    throw new ArgumentNullException("Debe introducir un concepto");

                if (string.IsNullOrEmpty(concepto.Temporada))
                    throw new ArgumentException("Debe introducir un valor para la Temporada");

                if (string.IsNullOrEmpty(concepto.Concepto))
                    throw new ArgumentException("Debe introducir un Concepto");

                if (concepto.Valor <= 0)
                    throw new ArgumentException("El valor debe ser una cantidad mayor que 0");

                var temporada = await _temporadaRepository.GetByNameAsync(concepto.Temporada).ConfigureAwait(false);
                if (temporada == null)
                    throw new NullReferenceException("No se encuentra la temporada indicada");

                TemporadaContabilidadDTO temporadaContabilidadDTO = new TemporadaContabilidadDTO
                {
                    Concepto = concepto.Concepto,
                    Valor = concepto.Valor,
                    Gasto = concepto.Gasto,
                    Equipo = concepto.Equipo,
                    Temporada = temporada
                };
                var added = await _temporadaConabilidadRepository.AddAsyn(temporadaContabilidadDTO).ConfigureAwait(false);
                if (added == null)
                    throw new NullReferenceException("Problemas al agregar el nuevo concepto");

                var saved = await _temporadaConabilidadRepository.SaveAsync().ConfigureAwait(false);
                if (saved==0)
                    throw new Exception("Problemas al almacenar el nuevo concepto");

                return new Response { Message = "Concepto añadido", Result = true, Status = EResponseStatus.Success };
            }
            catch(Exception x)
            {
                return new Response { Message = x.Message, Result = false, Status = EResponseStatus.Error };
            }
        }

        public async Task<Response> NuevaCompeticionPremio(PremioCompeticionViewModel porcentaje)
        {
            try
            {
                if (porcentaje == null)
                    throw new ArgumentNullException("Debe introducir una competición y su porcentaje");

                if (string.IsNullOrEmpty(porcentaje.Temporada))
                    throw new ArgumentException("Debe introducir un valor para la Temporada");

                if (string.IsNullOrEmpty(porcentaje.NombreCompeticion))
                    throw new ArgumentException("Debe introducir una Competición");

                if (string.IsNullOrEmpty(porcentaje.NombreCategoria))
                    throw new ArgumentException("Debe introducir una Categoría");

                //if (porcentaje.Porcentaje <= 0 || porcentaje.Porcentaje>100)
                //    throw new ArgumentException("El % debe ser una cantidad mayor que 0 y menor igual que 100");

                var temporada = await _temporadaRepository.GetByNameAsync(porcentaje.Temporada).ConfigureAwait(false);
                if (temporada == null)
                    throw new NullReferenceException("No se encuentra la temporada indicada");

                var tempCompCat = await _temporadaCompeticionCategoriaRepository.FindAsync(tcc => tcc.Temporada.Id.Equals(temporada.Id)
                    && tcc.Competicion.Nombre.Equals(porcentaje.NombreCompeticion) && tcc.Categoria.Nombre.Equals(porcentaje.NombreCategoria)).ConfigureAwait(false);
                if (tempCompCat == null)
                    throw new NullReferenceException("No se encuentra la competición indicada");

                TemporadaPremiosDTO nuevoPremio = new TemporadaPremiosDTO
                {
                    Categoria = tempCompCat,
                    Porcentaje = 0,
                    PorcentajeAjustado = 0
                };
                var added = await _temporadaPremiosRepository.AddAsyn(nuevoPremio).ConfigureAwait(false);
                if (added == null)
                    throw new NullReferenceException("Problemas al agregar la competición");

                var saved = await _temporadaPremiosRepository.SaveAsync().ConfigureAwait(false);
                if (saved == 0)
                    throw new Exception("Problemas al almacenar la competición");

                return new Response { Message = "Competición añadida", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                return new Response { Message = x.Message, Result = false, Status = EResponseStatus.Error };
            }
        }
        public async Task<Response> NuevoPremio(PremioPuestoViewModel premio)
        {
            try
            {
                if (premio == null)
                    throw new ArgumentNullException("Debe introducir un premio");

                if (string.IsNullOrEmpty(premio.Temporada))
                    throw new ArgumentException("Debe introducir un valor para la Temporada");

                if (string.IsNullOrEmpty(premio.Competicion))
                    throw new ArgumentException("Debe introducir una Competición");

                if (string.IsNullOrEmpty(premio.Categoria))
                    throw new ArgumentException("Debe introducir una Categoría");

                if (premio.Puesto < 0)
                    throw new ArgumentException("Debe introducir un Puesto");

                if (premio.Importe <= 0)
                    throw new ArgumentException("El importe debe ser una cantidad mayor que 0");

                var temporada = await _temporadaRepository.GetByNameAsync(premio.Temporada).ConfigureAwait(false);
                if (temporada == null)
                    throw new NullReferenceException("No se encuentra la temporada indicada");

                var tempCompCat = await _temporadaCompeticionCategoriaRepository.FindAsync(tcc => tcc.Temporada.Id.Equals(temporada.Id)
                    && tcc.Competicion.Nombre.Equals(premio.Competicion) && tcc.Categoria.Nombre.Equals(premio.Categoria)).ConfigureAwait(false);
                if (tempCompCat == null)
                    throw new NullReferenceException("No se encuentra la competición indicada");

                var porcentajeCompeticion = await _temporadaPremiosRepository.FindAsync(tp => tp.CategoriaId.Equals(tempCompCat.Id)).ConfigureAwait(false);
                if (porcentajeCompeticion == null)
                    throw new NullReferenceException("No se encuentra la competición indicada con el %");


                TemporadaPremiosPuestoDTO nuevoPremio = new TemporadaPremiosPuestoDTO
                {
                    PremioCategoria = porcentajeCompeticion,
                    Puesto = (int)premio.Puesto,
                    Porcentaje = 0,
                    PorcentajeAjustado = 0,
                    Importe = premio.Importe
                };
                var added = await _temporadaPremiosPuestoRepository.AddAsyn(nuevoPremio).ConfigureAwait(false);
                if (added == null)
                    throw new NullReferenceException("Problemas al agregar el nuevo premio");

                var saved = await _temporadaPremiosPuestoRepository.SaveAsync().ConfigureAwait(false);
                if (saved == 0)
                    throw new Exception("Problemas al almacenar el nuevo premio");

                return new Response { Message = "Premio añadido", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                return new Response { Message = x.Message, Result = false, Status = EResponseStatus.Error };
            }
        }
    }
}
