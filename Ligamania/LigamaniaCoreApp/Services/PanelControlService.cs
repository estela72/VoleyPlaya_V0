using AutoMapper;
using LigamaniaCoreApp.Data;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using LigamaniaCoreApp.Helpers;
using LigamaniaCoreApp.Models.AdminViewModels;
using LigamaniaCoreApp.Models.GlobalViewModels;
using LigamaniaCoreApp.Models.ManagerViewModels;
using LigamaniaCoreApp.Services.Interfaces;
using LigamaniaCoreApp.Utils;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Services
{
    public class PanelControlService : IPanelControlService
    {
        private readonly IOptions<AppSettings> _appSettings;
        private readonly int maxJornada = 34;
        private readonly int jornadasEliminado = 5;
        private readonly int maxVecesEliminado = 3;

        private readonly IMapper _mapper;
        private readonly ILogger<PanelControlService> _logger;
        private readonly ITemporadaRepository _temporadaRepository;
        private readonly ITemporadaCompeticionRepository _temporadaCompeticionRepository;
        private readonly ITemporadaCompeticionJornadaRepository _temporadaCompeticionJornadaRepository;
        private readonly IEstadoCompeticionRepository _estadoCompeticionRepository;
        private readonly IOperacionCompeticionRepository _operacionCompeticionRepository;
        private readonly IAlineacionRepository _alineacionRepository;
        private readonly IAlineacionPreviaRepository _alineacionPreviaRepository;
        private readonly IAlineacionCambiosRepository _alineacionCambiosRepository;
        private readonly ITemporadaEquipoRepository _temporadaEquipoRepository;
        private readonly ITemporadaClasificacionRepository _temporadaClasificacionRepository;
        private readonly ITemporadaJugadorRepository _temporadaJugadorRepository;
        private readonly ITemporadaJornadaJugadorRepository _temporadaJornadaJugadorRepository;
        private readonly ITemporadaPartidoRepository _temporadaPartidoRepository;
        private readonly ITemporadaCompeticionCategoriaRepository _temporadaCompeticionCategoriaRepository;
        private readonly ITemporadaRondaRepository _temporadaRondaRepository;
        private readonly ITemporadaCuadroRepository _temporadaCuadroRepository;
        private readonly IEquipoRepository _equipoRepository;

        public int MaxJornada => maxJornada;

        public int JornadasEliminado => jornadasEliminado;

        public int MaxVecesEliminado => maxVecesEliminado;

        public PanelControlService(
              IOptions<AppSettings> appSettings
            , IMapper mapper
            , ILogger<PanelControlService> logger
            , ITemporadaRepository temporadaRepository
            , ITemporadaCompeticionRepository temporadaCompeticionRepository
            , ITemporadaCompeticionJornadaRepository temporadaCompeticionJornadaRepository
            , IEstadoCompeticionRepository estadoCompeticionRepository
            , IOperacionCompeticionRepository operacionCompeticionRepository
            , IAlineacionRepository alineacionRepository
            , IAlineacionPreviaRepository alineacionPreviaRepository
            , IAlineacionCambiosRepository alineacionCambiosRepository
            , ITemporadaEquipoRepository temporadaEquipoRepository
            , ITemporadaClasificacionRepository temporadaClasificacionRepository
            , ITemporadaJugadorRepository temporadaJugadorRepository
            , ITemporadaJornadaJugadorRepository temporadaJornadaJugadorRepository
            , ITemporadaPartidoRepository temporadaPartidoRepository
            , ITemporadaCompeticionCategoriaRepository temporadaCompeticionCategoriaRepository
            , ITemporadaRondaRepository temporadaRondaRepository
            , ITemporadaCuadroRepository temporadaCuadroRepository
            , IEquipoRepository equipoRepository
            )
        {
            _appSettings = appSettings;
            maxJornada = _appSettings.Value.JornadaMaximaLiga;
            jornadasEliminado = _appSettings.Value.JornadasEliminado;
            maxVecesEliminado = _appSettings.Value.MaxVecesEliminado;

            _mapper = mapper;
            _logger = logger;
            _temporadaRepository = temporadaRepository;
            _temporadaCompeticionRepository = temporadaCompeticionRepository;
            _temporadaCompeticionJornadaRepository = temporadaCompeticionJornadaRepository;
            _estadoCompeticionRepository = estadoCompeticionRepository;
            _operacionCompeticionRepository = operacionCompeticionRepository;
            _alineacionCambiosRepository = alineacionCambiosRepository;
            _alineacionPreviaRepository = alineacionPreviaRepository;
            _alineacionRepository = alineacionRepository;
            _temporadaEquipoRepository = temporadaEquipoRepository;
            _temporadaClasificacionRepository = temporadaClasificacionRepository;
            _temporadaJugadorRepository = temporadaJugadorRepository;
            _temporadaJornadaJugadorRepository = temporadaJornadaJugadorRepository;
            _temporadaPartidoRepository = temporadaPartidoRepository;
            _temporadaCompeticionCategoriaRepository = temporadaCompeticionCategoriaRepository;
            _temporadaRondaRepository = temporadaRondaRepository;
            _temporadaCuadroRepository = temporadaCuadroRepository;
            _equipoRepository = equipoRepository;
        }
        public async Task<TemporadaCompeticionViewModel> GetTemporadaCompeticion(int idCompeticion)
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                TemporadaCompeticionDTO temporadaCompeticion = await GetTemporadaCompeticion(temporada, idCompeticion).ConfigureAwait(false);
                TemporadaCompeticionViewModel vm = _mapper.Map<TemporadaCompeticionViewModel>(temporadaCompeticion);
                TemporadaCompeticionJornadaDTO jornadaCarrusel = await _temporadaCompeticionJornadaRepository.GetJornadaCarrusel(idCompeticion).ConfigureAwait(false);
                TemporadaCompeticionJornadaDTO jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaActual(idCompeticion).ConfigureAwait(false);
                if (jornadaActual != null)
                {
                    vm.JornadaActual = (int)jornadaActual?.NumeroJornada;
                    vm.AlineacionLibre = (bool)jornadaActual?.AlineacionLibre;
                }
                if (jornadaCarrusel != null)
                {
                    vm.JornadaCarrusel = (int)jornadaCarrusel?.NumeroJornada;
                    //vm.AlineacionLibre = (bool)jornadaCarrusel?.AlineacionLibre;
                }
                if (temporadaCompeticion.Competicion.EsCopa)
                    await GetDatosCopa(vm).ConfigureAwait(false);

                return vm;
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return null;
            }
        }
        public async Task<TemporadaCompeticionViewModel> GetTemporadaCompeticionByNombre(string competicion)
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                TemporadaCompeticionDTO temporadaCompeticion = await GetTemporadaCompeticionByName(temporada, competicion).ConfigureAwait(false);
                TemporadaCompeticionViewModel vm = _mapper.Map<TemporadaCompeticionViewModel>(temporadaCompeticion);
                TemporadaCompeticionJornadaDTO jornadaCarrusel = await _temporadaCompeticionJornadaRepository.GetJornadaCarrusel(temporadaCompeticion.Competicion.Id).ConfigureAwait(false);
                TemporadaCompeticionJornadaDTO jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaActual(temporadaCompeticion.Competicion.Id).ConfigureAwait(false);
                if (jornadaActual != null)
                {
                    vm.JornadaActual = (int)jornadaActual?.NumeroJornada;
                    vm.AlineacionLibre = (bool)jornadaActual?.AlineacionLibre;
                }
                if (jornadaCarrusel != null)
                {
                    vm.JornadaCarrusel = (int)jornadaCarrusel?.NumeroJornada;
                    //vm.AlineacionLibre = (bool)jornadaCarrusel?.AlineacionLibre;
                }
                if (temporadaCompeticion.Competicion.EsCopa)
                    await GetDatosCopa(vm).ConfigureAwait(false);

                return vm;
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return null;
            }
        }
        private async Task GetDatosCopa(TemporadaCompeticionViewModel vm)
        {
            TemporadaRondaDTO infoRonda = await _temporadaRondaRepository.FindIncludingAsync(tr => tr.Temporada.Actual
                && tr.Competicion.Nombre.Equals(vm.Competicion) && tr.Activa, tr => tr.JornadaIda, tr => tr.JornadaVuelta).ConfigureAwait(false);
            if (infoRonda != null)
            {
                vm.RondaActiva = true;
                vm.RondaActual = infoRonda.NumRonda;
                vm.JornadaIdaActiva = infoRonda.JornadaIdaActiva;
                vm.RondaFinal = infoRonda.RondaFinal;
                vm.JornadaIda = infoRonda.JornadaIda.NumeroJornada;
                //fix: 11/07/2020 - No abría el panel de control
                if (infoRonda.JornadaVuelta!=null)
                    vm.JornadaVuelta = infoRonda.JornadaVuelta.NumeroJornada;
                vm.GenerarJornadaFinal = infoRonda.GenerarJornadaFinal;
                vm.PartidosCopa = await GetPartidos(infoRonda).ConfigureAwait(false);
            }
        }

        private async Task<List<TemporadaPartidoViewModel>> GetPartidos(TemporadaRondaDTO temporadaRonda)
        {
            int jornada = (int)(temporadaRonda.JornadaIdaActiva ? temporadaRonda.JornadaIdaID : temporadaRonda.RondaFinal? 0 : temporadaRonda.JornadaVueltaID);

            if (jornada==0 && temporadaRonda.RondaFinal && temporadaRonda.JornadasFinal.Any())
            {
                jornada = temporadaRonda.JornadasFinal.Last().Id;
            }
            if (jornada == 0) return null;
            ICollection<TemporadaPartidoDTO> partidos = await _temporadaPartidoRepository.FindAllIncludingAsync
                (tp => tp.Temporada.Actual && tp.CompeticionId.Equals(temporadaRonda.CompeticionID) && tp.JornadaId.Equals(jornada),
                tp => tp.Jornada, tp => tp.EquipoA, tp => tp.EquipoB).ConfigureAwait(false);

            List<TemporadaPartidoViewModel> lista =
                _mapper.Map<List<TemporadaPartidoDTO>, List<TemporadaPartidoViewModel>>(partidos.ToList());
            return lista;
        }

        public async Task<ICollection<TemporadaCompeticionViewModel>> GetCompeticionesActivas()
        {
            var tempComp = await _temporadaCompeticionRepository.GetCompeticionesActivas().ConfigureAwait(false);
            ICollection<TemporadaCompeticionViewModel> lista = new List<TemporadaCompeticionViewModel>();
            foreach (var tc in tempComp)
                lista.Add(await GetTemporadaCompeticion(tc.CompeticionId).ConfigureAwait(false));
            return lista;
        }

        #region Operaciones del panel de control
        public async Task<Response> AbrirAlineaciones(TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return new Response { Message = "No existe temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await GetTemporadaCompeticion(temporada, competicionPC).ConfigureAwait(false);
                if (temporadaCompeticion == null)
                    return new Response { Message = "No existe la competición en la temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionJornadaDTO jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaActual(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                if (jornadaActual == null)
                    return new Response { Message = "No existe jornada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                // si la competición está configurada para copiar la alineación inicial desde otra competición, 
                // se debe realizar aquí
                if (temporadaCompeticion.Competicion.CopiarAlineacionInicial)
                {
                    Response response = await SetAlineacionJornada(temporada, temporadaCompeticion).ConfigureAwait(false);
                    if (!response.Result)
                        return response;
                }

                await NuevoEstadoCompeticion(temporadaCompeticion, LigamaniaConst.Estado_Jornada_Inicial,
                    LigamaniaConst.Operacion_Abrir_Alineacion,
                        "Alineaciones abiertas para la Jornada " + jornadaActual.NumeroJornada).ConfigureAwait(false);
                //GuardarAccion("Abrir alineación inicial - " + temporadaCompeticion.Competicion.Nombre);

                return new Response { Message = "Operación realizada con éxito", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
            }
        }

        private async Task<Response> SetAlineacionJornada(TemporadaDTO temporada, TemporadaCompeticionDTO temporadaCompeticion)
        {
            try
            {
                // Limpiar las tablas de alineaciones previas y cambios
                await LimpiarTablaAliPrevia(temporada, temporadaCompeticion).ConfigureAwait(false);
                // primero: vaciar cambios
                await LimpiarTablaAliCambios(temporada, temporadaCompeticion).ConfigureAwait(false);
                // lista de equipos para los que hay que copiar la alineación
                List<string> equipos = await _temporadaRondaRepository.GetEquiposRondaActiva(temporadaCompeticion).ConfigureAwait(false);

                TemporadaCompeticionDTO temporadaCompeticionCopia =
                    await _temporadaCompeticionRepository.GetCompeticion(temporada.Id, temporadaCompeticion.Competicion.CompeticionCopiarAliIni).ConfigureAwait(false);
                if (temporadaCompeticionCopia == null)
                    return new Response { Message = "No existe la competición para copiar las alineaciones. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionJornadaDTO jornadaCopia = await _temporadaCompeticionJornadaRepository
                    .GetJornadaCarrusel(temporadaCompeticionCopia.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                if (jornadaCopia == null)
                    return new Response { Message = "No existe jornada de la que copiar. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                var categorias = await _temporadaCompeticionCategoriaRepository.GetCategorias(temporadaCompeticion).ConfigureAwait(false);
                var categoria = categorias.First().Categoria;

                // Obtener las alineaciones de la jornada copia, solo d los equipos que participan en la ronda actual
                ICollection<AlineacionDTO> alineaciones = await _alineacionRepository.GetAlineaciones(temporada, temporadaCompeticionCopia, jornadaCopia, equipos).ConfigureAwait(false);
                await CopiarAlineacionToAlineacionPrevia(alineaciones, temporadaCompeticion, categoria).ConfigureAwait(false);
                await CopiarAlineacionToAlineacionCambio(alineaciones, temporadaCompeticion, categoria).ConfigureAwait(false);


                return new Response { Message = "Alineaciones copiadas correctamente", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al copiar alineación desde otra competición", Status = EResponseStatus.Error, Result = false };
            }
        }

        public async Task<Response> AbrirCambios(TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return new Response { Message = "No existe temporada actual. No se pueden abrir cambios", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await GetTemporadaCompeticion(temporada, competicionPC).ConfigureAwait(false);
                if (temporadaCompeticion == null)
                    return new Response { Message = "No existe la competición en la temporada actual. No se pueden abrir cambios", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionJornadaDTO jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaActual(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                if (jornadaActual == null)
                    return new Response { Message = "No existe jornada actual. No se pueden abrir cambios", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionJornadaDTO jornadaCarrusel = await _temporadaCompeticionJornadaRepository.GetJornadaCarrusel(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                if (jornadaCarrusel == null)
                    return new Response { Message = "No existe jornada previa (carrusel). No se pueden abrir cambios", Result = false, Status = EResponseStatus.Warning };

                bool operacionForzada = false;
                TemporadaCompeticionJornadaDTO jornadaTrabajo = jornadaCarrusel;
                if (competicionPC.Jornada != 0)
                {
                    operacionForzada = true;
                    jornadaTrabajo = await _temporadaCompeticionJornadaRepository.GetJornada(temporada.Id, temporadaCompeticion.CompeticionId, competicionPC.Jornada).ConfigureAwait(false);
                    if (jornadaTrabajo == null)
                        return new Response { Message = "No existe jornada " + competicionPC.Jornada + ". No se puede realizar la operación", Result = false, Status = EResponseStatus.Warning };
                }


                // Copiar Alineaciones de la jornada carrusel a AliPrevia
                await LimpiarTablaAliPrevia(temporada, temporadaCompeticion).ConfigureAwait(false);
                // primero: vaciar cambios
                await LimpiarTablaAliCambios(temporada, temporadaCompeticion).ConfigureAwait(false);
                // segundo: lo que hay en alineaciones de jornada carrusel copiar en alicambios y copiar en AliPrevia
                ICollection<AlineacionDTO> alineaciones = await _alineacionRepository.GetAlineaciones(temporada, temporadaCompeticion, jornadaTrabajo).ConfigureAwait(false);
                await CopiarAlineacionToAlineacionPrevia(alineaciones).ConfigureAwait(false);
                await CopiarAlineacionToAlineacionCambio(alineaciones).ConfigureAwait(false);

                //if (!operacionForzada)
                await NuevoEstadoCompeticion(temporadaCompeticion, LigamaniaConst.Estado_Abrir_Jornada,
                    LigamaniaConst.Operacion_Abrir_Cambios,
                        "Cambios Abiertos para la Jornada " + (jornadaTrabajo.NumeroJornada + 1).ToString()).ConfigureAwait(false);

                return new Response { Message = "Operación realizada con éxito", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
            }
        }
        public async Task<Response> AbrirCambiosForzado(TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return new Response { Message = "No existe temporada actual. No se pueden abrir cambios", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await GetTemporadaCompeticion(temporada, competicionPC).ConfigureAwait(false);
                if (temporadaCompeticion == null)
                    return new Response { Message = "No existe la competición en la temporada actual. No se pueden abrir cambios", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionJornadaDTO jornadaCarrusel = await _temporadaCompeticionJornadaRepository.GetJornadaCarrusel(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                if (jornadaCarrusel == null)
                    return new Response { Message = "No existe jornada previa (carrusel). No se pueden abrir cambios", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionJornadaDTO jornadaTrabajo = jornadaCarrusel;

                await NuevoEstadoCompeticion(temporadaCompeticion, LigamaniaConst.Estado_Abrir_Jornada,
                LigamaniaConst.Operacion_Abrir_Cambios,
                    "Cambios Abiertos para la Jornada " + (jornadaTrabajo.NumeroJornada + 1).ToString()).ConfigureAwait(false);

                return new Response { Message = "Operación realizada con éxito", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
            }
        }
        public async Task<Response> ActualizarClasificacion(TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                if (competicionPC==null)
                    return new Response { Message = "Parámetros incorrectos. No se pueden realizar la operación", Result = false, Status = EResponseStatus.Warning };
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return new Response { Message = "No existe temporada actual. No se pueden realizar la operación", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await GetTemporadaCompeticion(temporada, competicionPC).ConfigureAwait(false);
                if (temporadaCompeticion == null)
                    return new Response { Message = "No existe la competición en la temporada actual. No se puede realizar la operación", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionJornadaDTO jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaActual(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                if (jornadaActual == null)
                    return new Response { Message = "No existe jornada actual. No se puede realizar la operación", Result = false, Status = EResponseStatus.Warning };
                TemporadaCompeticionJornadaDTO jornadaCarrusel = await _temporadaCompeticionJornadaRepository.GetJornadaCarrusel(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                if (jornadaCarrusel == null)
                    return new Response { Message = "No existe jornada previa (carrusel). No se puede realizar la operación", Result = false, Status = EResponseStatus.Warning };
                bool operacionForzada = false;
                TemporadaCompeticionJornadaDTO jornadaClasificacion = jornadaCarrusel;
                if (competicionPC.Jornada != 0)
                {
                    operacionForzada = true;
                    jornadaClasificacion = await _temporadaCompeticionJornadaRepository.GetJornada(temporada.Id, temporadaCompeticion.CompeticionId, competicionPC.Jornada).ConfigureAwait(false);
                    if (jornadaClasificacion == null)
                        return new Response { Message = "No existe jornada " + competicionPC.Jornada + ". No se puede realizar la operación", Result = false, Status = EResponseStatus.Warning };
                }

                TemporadaDTO temporadaClasificacion = temporada;
                if (temporadaCompeticion.Competicion.EsSupercopa)
                    temporadaClasificacion = await _temporadaRepository.GetTemporadaAnteriorAsync(temporada).ConfigureAwait(false);

                ICollection<TemporadaEquipoDTO> equipos = await _temporadaEquipoRepository.FindAllIncludingAsync(te => te.TemporadaId.Equals(temporada.Id)
                    && te.CompeticionId.Equals(temporadaCompeticion.CompeticionId) && !te.Baja, te => te.Equipo, te => te.Categoria).ConfigureAwait(false);

                foreach (var equipo in equipos)
                {
                    await ActualizaClasificacionEquipo(equipo, temporada, temporadaClasificacion, temporadaCompeticion, jornadaClasificacion).ConfigureAwait(false);
                }
                await _temporadaClasificacionRepository.SaveAsync().ConfigureAwait(false);

                if (!operacionForzada)
                    await NuevoEstadoCompeticion(temporadaCompeticion, LigamaniaConst.Estado_Cerrar_Jornada,
                        LigamaniaConst.Operacion_Clasificacion,
                            "Clasificación actualizada para la Jornada " + jornadaClasificacion.NumeroJornada).ConfigureAwait(false);

                return new Response { Message = "Operación realizada con éxito", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
            }
        }

        /// <summary>
        /// Calcular resultados desde la jornada 1 hasta la jornada Carrusel
        /// </summary>
        /// <param name="competicionPC"></param>
        /// <returns></returns>
        public async Task<Response> RecalcularResultados(TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return new Response { Message = "No existe temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await GetTemporadaCompeticion(temporada, competicionPC).ConfigureAwait(false);
                if (temporadaCompeticion == null)
                    return new Response { Message = "No existe la competición en la temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionJornadaDTO jornadaCarrusel = await _temporadaCompeticionJornadaRepository.GetJornadaCarrusel(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                if (jornadaCarrusel == null)
                    return new Response { Message = "No existe jornada previa (carrusel). No se pueden abrir cambios", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionJornadaDTO jornadaClasificacion = jornadaCarrusel;
                for (int jornada = 1; jornada <= jornadaCarrusel.NumeroJornada; jornada++)
                {
                    jornadaClasificacion = await _temporadaCompeticionJornadaRepository.GetJornada(temporada.Id, temporadaCompeticion.CompeticionId, jornada).ConfigureAwait(false);
                    if (jornadaClasificacion == null)
                        return new Response { Message = "No existe jornada " + jornada + ". No se puede realizar la operación", Result = false, Status = EResponseStatus.Warning };
                    TemporadaRondaDTO infoRonda = null;
                    ICollection<TemporadaCuadroDTO> partidosRonda = null;
                    if (temporadaCompeticion.Competicion.EsCopa)
                    {
                        infoRonda = await _temporadaRondaRepository
                            .FindIncludingAsync(tr => tr.Temporada.Actual
                                && tr.Competicion.Nombre.Equals(temporadaCompeticion.Competicion.Nombre) && tr.Activa,
                                tr => tr.JornadaIda, tr => tr.JornadaVuelta).ConfigureAwait(false);

                        if (infoRonda != null && infoRonda.Activa)
                        {
                            partidosRonda = await _temporadaCuadroRepository
                                .FindAllAsync(tc => tc.TemporadaId.Equals(infoRonda.TemporadaID) &&
                                        tc.Ronda.Equals(infoRonda.NumRonda)).ConfigureAwait(false);

                            // recorrer todos los partidos de la ronda y establecer el ganador en los partidos donde un rival sea BAY
                            if (!infoRonda.JornadaIdaActiva)
                            {
                                foreach (var partidoRonda in partidosRonda)
                                {
                                    await CheckAndUpdatePartidoBAY(partidoRonda).ConfigureAwait(false);
                                }
                                await _temporadaCuadroRepository.SaveAsync().ConfigureAwait(false);
                            }
                        }
                    }
                    // Actualizamos el resultado de todos los partidos de la jornada
                    ICollection<TemporadaPartidoDTO> partidos = await _temporadaPartidoRepository.GetPartidos(temporada, temporadaCompeticion, jornadaClasificacion).ConfigureAwait(false);
                    ICollection<TemporadaJornadaJugadorDTO> goleadores = await _temporadaJornadaJugadorRepository.GetGoleadores(jornadaClasificacion).ConfigureAwait(false);
                    bool generarRondaFinal = false;
                    foreach (var partido in partidos)
                    {
                        await ActualizarResultadoPartido(partido, jornadaClasificacion, goleadores).ConfigureAwait(false);
                        await _temporadaPartidoRepository.UpdateAsyn(partido, partido.Id).ConfigureAwait(false);

                        // si es Copa y la jornada es Vuelta o es Ronda Final, actualizamos el ganador del partido en el cuadro de copa
                        if (temporadaCompeticion.Competicion.EsCopa && infoRonda != null)
                        {
                            if (infoRonda.Activa && (!infoRonda.JornadaIdaActiva || infoRonda.RondaFinal))
                            {
                                generarRondaFinal = generarRondaFinal || await EstableceGanadorPartidoRonda(infoRonda, partido, partidosRonda).ConfigureAwait(false);
                            }
                        }
                    }
                    if (temporadaCompeticion.Competicion.EsCopa && infoRonda != null)
                    {
                        infoRonda.GenerarJornadaFinal = generarRondaFinal;
                        await _temporadaRondaRepository.UpdateAsyn(infoRonda, infoRonda.Id).ConfigureAwait(false);
                    }
                }

                await _temporadaEquipoRepository.SaveAsync().ConfigureAwait(false);
                await _temporadaPartidoRepository.SaveAsync().ConfigureAwait(false);
                await _temporadaCuadroRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Operación realizada con éxito", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
            }
        }


        public async Task<Response> RecalcularClasificacion(TemporadaCompeticionViewModel competicionPC)
        {
            //Recalcular la clasificación desde la jornada 1 hasta la jornada CARRUSEL
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return new Response { Message = "No existe temporada actual. No se pueden realizar la operación", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await GetTemporadaCompeticion(temporada, competicionPC).ConfigureAwait(false);
                if (temporadaCompeticion == null)
                    return new Response { Message = "No existe la competición en la temporada actual. No se puede realizar la operación", Result = false, Status = EResponseStatus.Warning };

                TemporadaDTO temporadaClasificacion = temporada;
                if (temporadaCompeticion.Competicion.EsSupercopa)
                    temporadaClasificacion = await _temporadaRepository.GetTemporadaAnteriorAsync(temporada).ConfigureAwait(false);

                TemporadaCompeticionJornadaDTO jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaActual(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                if (jornadaActual == null)
                    return new Response { Message = "No existe jornada actual. No se puede realizar la operación", Result = false, Status = EResponseStatus.Warning };
                TemporadaCompeticionJornadaDTO jornadaCarrusel = await _temporadaCompeticionJornadaRepository.GetJornadaCarrusel(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                if (jornadaCarrusel == null)
                    return new Response { Message = "No existe jornada previa (carrusel). No se puede realizar la operación", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionJornadaDTO jornadaClasificacion = jornadaCarrusel;
                for (int jornada = 1; jornada <= jornadaCarrusel.NumeroJornada; jornada++)
                {
                    jornadaClasificacion = await _temporadaCompeticionJornadaRepository.GetJornada(temporada.Id, temporadaCompeticion.CompeticionId, jornada).ConfigureAwait(false);
                    if (jornadaClasificacion == null)
                        return new Response { Message = "No existe jornada " + jornada + ". No se puede realizar la operación", Result = false, Status = EResponseStatus.Warning };

                    ICollection<TemporadaEquipoDTO> equipos = await _temporadaEquipoRepository.FindAllIncludingAsync(te => te.TemporadaId.Equals(temporada.Id)
                        && te.CompeticionId.Equals(temporadaCompeticion.CompeticionId) && !te.Baja, te => te.Equipo, te => te.Categoria).ConfigureAwait(false);

                    foreach (var equipo in equipos)
                    {
                        await ActualizaClasificacionEquipo(equipo, temporada, temporadaClasificacion, temporadaCompeticion, jornadaClasificacion).ConfigureAwait(false);
                    }
                }
                await _temporadaClasificacionRepository.SaveAsync().ConfigureAwait(false);


                return new Response { Message = "Operación realizada con éxito", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
            }
        }

        public async Task<Response> ActualizarEliminados(TemporadaCompeticionViewModel competicionPC)
        {
            // De preEliminados a Eliminados
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return new Response { Message = "No existe temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await GetTemporadaCompeticion(temporada, competicionPC).ConfigureAwait(false);
                if (temporadaCompeticion == null)
                    return new Response { Message = "No existe la competición en la temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionJornadaDTO jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaActual(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                if (jornadaActual == null)
                    return new Response { Message = "No existe jornada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };
                TemporadaCompeticionJornadaDTO jornadaCarrusel = await _temporadaCompeticionJornadaRepository.GetJornadaCarrusel(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                if (jornadaCarrusel == null)
                    return new Response { Message = "No existe jornada previa (carrusel). No se pueden abrir cambios", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionJornadaDTO jornadaPreeliminados = jornadaCarrusel;
                TemporadaCompeticionJornadaDTO jornadaEliminacion = jornadaActual;

                bool operacionForzada = false;
                if (competicionPC.Jornada != 0)
                {
                    operacionForzada = true;
                    jornadaEliminacion = await _temporadaCompeticionJornadaRepository.GetJornada(temporadaCompeticion.TemporadaId, temporadaCompeticion.CompeticionId, competicionPC.Jornada).ConfigureAwait(false);
                    jornadaPreeliminados = await _temporadaCompeticionJornadaRepository.GetJornada(temporadaCompeticion.TemporadaId, temporadaCompeticion.CompeticionId, competicionPC.Jornada - 1).ConfigureAwait(false);
                }

                // obtener los jugadores preEliminados
                ICollection<TemporadaJornadaJugadorDTO> jugadores = await _temporadaJornadaJugadorRepository.GetJugadoresPreEliminados(jornadaPreeliminados).ConfigureAwait(false);

                // convertirlos en jugadores Eliminados
                foreach (var tempjugador in jugadores)
                {
                    // buscar el jugador preeliminado en la jornadaCarrusel y eliminarlo en la jornada actual
                    var tempJorJug = await _temporadaJornadaJugadorRepository.FindAsync(tjj => tjj.Temporada.Actual
                        && tjj.JornadaId.Equals(jornadaEliminacion.Id)).ConfigureAwait(false);
                    if (tempJorJug == null)
                    {
                        TemporadaJornadaJugadorDTO newTempJorJug = new TemporadaJornadaJugadorDTO
                        {
                            Eliminado = true,
                            Jornada = jornadaEliminacion,
                            Jugador = tempjugador.Jugador,
                            PreEliminado = false,
                            Temporada = tempjugador.Temporada
                        };
                        await _temporadaJornadaJugadorRepository.AddAsyn(newTempJorJug).ConfigureAwait(false);
                    }
                    else
                    {
                        tempJorJug.Eliminado = true;
                        await _temporadaJornadaJugadorRepository.UpdateAsyn(tempJorJug, tempJorJug.Id).ConfigureAwait(false);
                    }

                    var jugador = await _temporadaJugadorRepository.GetJugador(temporada, tempjugador.Jugador).ConfigureAwait(false);
                    if (jugador != null)
                    {
                        jugador.Eliminado = true;
                        jugador.LastJornadaEliminacion = jornadaEliminacion;
                        jugador.VecesEliminado++;
                        jugador.PreEliminado = false;
                        await _temporadaJugadorRepository.UpdateAsyn(jugador, jugador.Id).ConfigureAwait(false);
                    }
                }
                await _temporadaJugadorRepository.SaveAsync().ConfigureAwait(false);

                if (!operacionForzada)
                    await NuevoEstadoCompeticion(temporadaCompeticion, LigamaniaConst.Estado_Abrir_Jornada,
                        LigamaniaConst.Operacion_Actualizar_Eliminados,
                             "Preparando Jornada " + jornadaEliminacion.NumeroJornada.ToString()).ConfigureAwait(false);
                //GuardarAccion("Abrir alineación inicial - " + temporadaCompeticion.Competicion.Nombre);

                return new Response { Message = "Operación realizada con éxito", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
            }
        }

        public async Task<Response> CalcularPreeliminados(TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return new Response { Message = "No existe temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await GetTemporadaCompeticion(temporada, competicionPC).ConfigureAwait(false);
                if (temporadaCompeticion == null)
                    return new Response { Message = "No existe la competición en la temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionJornadaDTO jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaActual(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                if (jornadaActual == null)
                    return new Response { Message = "No existe jornada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };
                //TemporadaCompeticionJornada_DTO jornadaCarrusel = await _temporadaCompeticionJornadaRepository.GetJornadaCarrusel(temporadaCompeticion.Competicion.Id, temporada.Nombre);
                //if (jornadaCarrusel == null)
                //    return new Response { Message = "No existe jornada previa (carrusel). No se pueden abrir cambios", Result = false, Status = EResponseStatus.Warning };

                ICollection<TemporadaJugadorDTO> jugadoresEliminados = await _temporadaJugadorRepository.GetJugadoresEliminados().ConfigureAwait(false);
                List<string> jugadoresAEliminar = new List<string>();
                // agrupamos los jugadores alineados por categoría
                ICollection<JugadoresAlineadosCategoriaViewModel> jugadoresAlineadosPorCategoria = await GetJugadoresAlineadosPorCategoria(temporadaCompeticion, jornadaActual).ConfigureAwait(false);

                // nos quedamos con los jugadores que están alineados más veces de lo permitido en todas las categorias
                var categorias = await GetTemporadaCompeticionCategorias(temporadaCompeticion.Temporada, temporadaCompeticion).ConfigureAwait(false);
                foreach (var categoria in categorias)
                {
                    var maxAlineaciones = categoria.NumeroMaximoJugadorEliminar;
                    var jugadores = jugadoresAlineadosPorCategoria
                        .FirstOrDefault(ja => ja.Categoria.Equals(categoria.Categoria.Nombre))
                        .Jugadores
                        .Where(j => !jugadoresAEliminar.Contains(j.Key) && j.Value >= maxAlineaciones).Select(j => j.Key).ToList();
                    jugadoresAEliminar.AddRange(jugadores);
                }

                //quitamos de estos jugadoresAEliminar los que ya están eliminados
                List<string> jugadoresYaEliminados = jugadoresEliminados.Select(j => j.Jugador.Nombre).ToList();
                var nuevaListaAEliminar = jugadoresAEliminar.Where(j => !jugadoresYaEliminados.Contains(j)).ToList();

                // marcamos los jugadore a eliminar como jugadores preeliminados. Serán eliminados en la próxima jornada
                foreach (var jug in nuevaListaAEliminar)
                {
                    TemporadaJugadorDTO temporadaJugador = await _temporadaJugadorRepository.FindAsync(tj => tj.Temporada_ID.Equals(temporada.Id) && tj.Jugador.Nombre.Equals(jug) && tj.Activo).ConfigureAwait(false);
                    TemporadaJornadaJugadorDTO temporadaJornadaJugador = await _temporadaJornadaJugadorRepository
                        .FindAsync(tjj => tjj.TemporadaId.Equals(temporada.Id) && tjj.Jugador.Nombre.Equals(jug) && tjj.JornadaId.Equals(jornadaActual.Id)).ConfigureAwait(false);

                    if (temporadaJugador != null)
                    {
                        temporadaJugador.PreEliminado = true;
                        temporadaJugador.VecesPreEliminado++;
                        await _temporadaJugadorRepository.UpdateAsyn(temporadaJugador, temporadaJugador.Id).ConfigureAwait(false);
                    }
                    if (temporadaJornadaJugador != null)
                    {
                        temporadaJornadaJugador.PreEliminado = true;
                        await _temporadaJornadaJugadorRepository.UpdateAsyn(temporadaJornadaJugador, temporadaJornadaJugador.Id).ConfigureAwait(false);
                    }
                    else
                    {
                        TemporadaJornadaJugadorDTO newTempoJorJug = new TemporadaJornadaJugadorDTO
                        {
                            Temporada = temporada,
                            Jornada = jornadaActual,
                            Jugador = temporadaJugador.Jugador,
                            PreEliminado = true
                        };
                        await _temporadaJornadaJugadorRepository.AddAsyn(newTempoJorJug).ConfigureAwait(false);
                    }
                }
                await _temporadaJornadaJugadorRepository.SaveAsync().ConfigureAwait(false);
                if (competicionPC.EstadoCompeticion.Equals(LigamaniaConst.JI_CerrarAli))
                    await NuevoEstadoCompeticion(temporadaCompeticion, LigamaniaConst.Estado_Jornada_Inicial,
                        LigamaniaConst.Operacion_Calcular_Preeliminados,
                            "Jugadores eliminados para la jornada " + jornadaActual.NumeroJornada).ConfigureAwait(false);
                else
                    await NuevoEstadoCompeticion(temporadaCompeticion, LigamaniaConst.Estado_Cerrar_Jornada,
                        LigamaniaConst.Operacion_Calcular_Preeliminados,
                            "Jugadores eliminados para la jornada " + jornadaActual.NumeroJornada).ConfigureAwait(false);

                //GuardarAccion("Abrir alineación inicial - " + temporadaCompeticion.Competicion.Nombre);

                return new Response { Message = "Operación realizada con éxito", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
            }
        }

        public async Task<Response> CalcularResultados(TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return new Response { Message = "No existe temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await GetTemporadaCompeticion(temporada, competicionPC).ConfigureAwait(false);
                if (temporadaCompeticion == null)
                    return new Response { Message = "No existe la competición en la temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                //TemporadaCompeticionJornada_DTO jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaActual(temporadaCompeticion.Competicion.Id, temporada.Nombre);
                //if (jornadaActual == null)
                //    return new Response { Message = "No existe jornada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionJornadaDTO jornadaCarrusel = await _temporadaCompeticionJornadaRepository.GetJornadaCarrusel(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                if (jornadaCarrusel == null)
                    return new Response { Message = "No existe jornada previa (carrusel). No se pueden abrir cambios", Result = false, Status = EResponseStatus.Warning };

                bool operacionForzada = false;
                TemporadaCompeticionJornadaDTO jornadaClasificacion = jornadaCarrusel;
                if (competicionPC.Jornada != 0)
                {
                    operacionForzada = true;
                    jornadaClasificacion = await _temporadaCompeticionJornadaRepository.GetJornada(temporada.Id, temporadaCompeticion.CompeticionId, competicionPC.Jornada).ConfigureAwait(false);
                    if (jornadaClasificacion == null)
                        return new Response { Message = "No existe jornada " + competicionPC.Jornada + ". No se puede realizar la operación", Result = false, Status = EResponseStatus.Warning };
                }
                TemporadaRondaDTO infoRonda = null;
                ICollection<TemporadaCuadroDTO> partidosRonda = null;
                if (temporadaCompeticion.Competicion.EsCopa)
                {
                    infoRonda = await _temporadaRondaRepository
                        .FindIncludingAsync(tr => tr.Temporada.Actual
                            && tr.Competicion.Nombre.Equals(temporadaCompeticion.Competicion.Nombre) && tr.Activa,
                            tr => tr.JornadaIda, tr => tr.JornadaVuelta).ConfigureAwait(false);

                    if (infoRonda != null && infoRonda.Activa)
                    {
                        partidosRonda = await _temporadaCuadroRepository
                            .FindAllAsync(tc => tc.TemporadaId.Equals(infoRonda.TemporadaID) &&
                                    tc.Ronda.Equals(infoRonda.NumRonda)).ConfigureAwait(false);

                        // recorrer todos los partidos de la ronda y establecer el ganador en los partidos donde un rival sea BAY
                        if (!infoRonda.JornadaIdaActiva)
                        {
                            foreach (var partidoRonda in partidosRonda)
                            {
                                await CheckAndUpdatePartidoBAY(partidoRonda).ConfigureAwait(false);
                            }
                            await _temporadaCuadroRepository.SaveAsync().ConfigureAwait(false);
                        }
                    }
                }
                // Actualizamos el resultado de todos los partidos de la jornada
                ICollection<TemporadaPartidoDTO> partidos = await _temporadaPartidoRepository.GetPartidos(temporada, temporadaCompeticion, jornadaClasificacion).ConfigureAwait(false);
                ICollection<TemporadaJornadaJugadorDTO> goleadores = await _temporadaJornadaJugadorRepository.GetGoleadores(jornadaClasificacion).ConfigureAwait(false);
                bool generarRondaFinal = false;
                foreach (var partido in partidos)
                {
                    await ActualizarResultadoPartido(partido, jornadaClasificacion, goleadores).ConfigureAwait(false);
                    await _temporadaPartidoRepository.UpdateAsyn(partido, partido.Id).ConfigureAwait(false);

                    // si es Copa y la jornada es Vuelta o es Ronda Final, actualizamos el ganador del partido en el cuadro de copa
                    if (temporadaCompeticion.Competicion.EsCopa && infoRonda != null)
                    {
                        if (infoRonda.Activa && (!infoRonda.JornadaIdaActiva || infoRonda.RondaFinal))
                        {
                            generarRondaFinal = generarRondaFinal || await EstableceGanadorPartidoRonda(infoRonda, partido, partidosRonda).ConfigureAwait(false);
                        }
                    }
                }
                if (temporadaCompeticion.Competicion.EsCopa && infoRonda != null)
                {
                    infoRonda.GenerarJornadaFinal = generarRondaFinal;
                    await _temporadaRondaRepository.UpdateAsyn(infoRonda, infoRonda.Id).ConfigureAwait(false);
                }
                await _temporadaEquipoRepository.SaveAsync().ConfigureAwait(false);
                await _temporadaPartidoRepository.SaveAsync().ConfigureAwait(false);
                await _temporadaCuadroRepository.SaveAsync().ConfigureAwait(false);
                if (!operacionForzada)
                    await NuevoEstadoCompeticion(temporadaCompeticion, LigamaniaConst.Estado_Abrir_Jornada,
                        LigamaniaConst.Operacion_Resultados,
                            "Actualizados los resultados de la jornada " + jornadaClasificacion.NumeroJornada).ConfigureAwait(false);

                return new Response { Message = "Operación realizada con éxito", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
            }
        }
        public async Task<Response> EstablecerGanadoresPartidosCopa(TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return new Response { Message = "No existe temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await GetTemporadaCompeticion(temporada, competicionPC).ConfigureAwait(false);
                if (temporadaCompeticion == null)
                    return new Response { Message = "No existe la competición en la temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionJornadaDTO jornadaCarrusel = await _temporadaCompeticionJornadaRepository.GetJornadaCarrusel(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                if (jornadaCarrusel == null)
                    return new Response { Message = "No existe jornada previa (carrusel). No se pueden abrir cambios", Result = false, Status = EResponseStatus.Warning };

                // buscar en la ronda actual y jornada actual si todos los partidos tienen un ganador, si hay algún partido que no tenga ganador,
                // habrá que mostrar la ventana con los partidos sin ganador, y establecer el ganador de cada uno de ellos, según el orden de criterio establecido
                bool operacionForzada = false;
                TemporadaCompeticionJornadaDTO jornadaClasificacion = jornadaCarrusel;
                if (competicionPC.Jornada != 0)
                {
                    operacionForzada = true;
                    jornadaClasificacion = await _temporadaCompeticionJornadaRepository.GetJornada(temporada.Id, temporadaCompeticion.CompeticionId, competicionPC.Jornada).ConfigureAwait(false);
                    if (jornadaClasificacion == null)
                        return new Response { Message = "No existe jornada " + competicionPC.Jornada + ". No se puede realizar la operación", Result = false, Status = EResponseStatus.Warning };
                }
                TemporadaRondaDTO infoRonda = null;
                ICollection<TemporadaCuadroDTO> partidosRonda = null;
                if (temporadaCompeticion.Competicion.EsCopa)
                {
                    infoRonda = await _temporadaRondaRepository
                        .FindIncludingAsync(tr => tr.Temporada.Actual
                            && tr.Competicion.Nombre.Equals(temporadaCompeticion.Competicion.Nombre) && tr.Activa,
                            tr => tr.JornadaIda, tr => tr.JornadaVuelta).ConfigureAwait(false);

                    if (infoRonda != null && infoRonda.Activa)
                    {
                        partidosRonda = await _temporadaCuadroRepository
                            .FindAllAsync(tc => tc.TemporadaId.Equals(infoRonda.TemporadaID) &&
                                    tc.Ronda.Equals(infoRonda.NumRonda)).ConfigureAwait(false);
                    }
                }
                if (infoRonda != null && partidosRonda != null && partidosRonda.Any())
                {
                    bool existenPartidosSinGanador = partidosRonda.Any(p => p.NombreGanador == null || string.IsNullOrEmpty(p.NombreGanador) || p.NombreGanador.Equals(LigamaniaConst.SinDefinir));
                    if (!existenPartidosSinGanador)
                    {
                        await NuevoEstadoCompeticion(temporadaCompeticion, LigamaniaConst.Estado_Abrir_Jornada, LigamaniaConst.Operacion_EstablecerGanadores,
                            "Actualizados los ganadores de la ronda").ConfigureAwait(false);

                        return new Response { Message = "Todos los partidos tienen GANADOR. Operación realizada con éxito", Result = true, Status = EResponseStatus.Success };
                    }
                    else
                    {
                        return new Response { Message = "Es necesario establecer el GANADOR de algunos partidos.", Result = true, Status = EResponseStatus.Warning };
                    }
                }
                _logger.LogError("Operación incorrecta. Consultar con el administrador");
                return new Response { Message = "Operación incorrecta. Consultar con el administrador", Status = EResponseStatus.Error, Result = false };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
            }
        }
        public async Task<List<TemporadaRondaPartidos>> GetAllRondasConPartidos()
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return null;

                TemporadaCompeticionDTO temporadaCompeticion = await _temporadaCompeticionRepository.GetCompeticion(temporada.Id, LigamaniaConst.Competicion_Copa).ConfigureAwait(false);
                if (temporadaCompeticion == null)
                    return null;

                List<TemporadaRondaPartidos> allRondasConPartidos = new List<TemporadaRondaPartidos>();
                ICollection<TemporadaCuadroDTO> partidosRonda = null;
                // información de la ronda
                var infoRonda = await _temporadaRondaRepository.FindAllIncludingAsync(tr => tr.Temporada.Actual && tr.Competicion.Nombre.Equals(temporadaCompeticion.Competicion.Nombre),
                            tr => tr.JornadaIda, tr => tr.JornadaVuelta, tr=>tr.JornadasFinal).ConfigureAwait(false);

                // partidos del cuadro correspondientes a la ronda activa
                if (infoRonda != null && infoRonda.Any())
                {
                    foreach (var ronda in infoRonda)
                    {
                        partidosRonda = await _temporadaCuadroRepository.FindAllAsync(tc => tc.TemporadaId.Equals(ronda.TemporadaID) && tc.Ronda.Equals(ronda.NumRonda)).ConfigureAwait(false);
                        if (infoRonda != null && partidosRonda != null && partidosRonda.Any())
                        {
                            var cuadroConEquipos = _mapper.Map<List<TemporadaCuadroDTO>, List<TemporadaCuadroViewModel>>(partidosRonda.ToList());

                            TemporadaRondaPartidos temporadaRondaPartidos = new TemporadaRondaPartidos
                            {
                                Ronda = ronda.NumRonda,
                                JornadaIda = ronda.JornadaIda.NumeroJornada,
                                FechaIda = ronda.JornadaIda.Fecha,
                                JornadaVuelta = ronda.JornadaVuelta != null ? ronda.JornadaVuelta.NumeroJornada : 0,
                                FechaVuelta = ronda.JornadaVuelta != null ? ronda.JornadaVuelta.Fecha : new DateTime(1900, 1, 1),
                                RondaFinal = ronda.RondaFinal,
                                JornadasFinales = new List<int>(),
                                FechasFinales = new List<DateTime>(),
                                Partidos = new List<TemporadaPartidoRondaViewModel>()
                            };

                            if (ronda.JornadasFinal != null && ronda.JornadasFinal.Any())
                            {
                                temporadaRondaPartidos.JornadasFinales = ronda.JornadasFinal.Select(j => j.NumeroJornada).OrderBy(j => j).ToList();
                                temporadaRondaPartidos.FechasFinales = ronda.JornadasFinal.Select(j => j.Fecha).OrderBy(j => j).ToList();
                            }
                            List<TemporadaPartidoDTO> partidos = new List<TemporadaPartidoDTO>();
                            if (partidosRonda.Any())
                            {
                                foreach (var partido in partidosRonda.ToList())
                                {
                                    List<TemporadaPartidoDTO> temporadaPartidos = await GetPartidosRonda(ronda, partido.NombreEquipoA, partido.NombreEquipoB).ConfigureAwait(false);
                                    List<TemporadaPartidoViewModel> partidosVM = _mapper.Map<List<TemporadaPartidoViewModel>>(temporadaPartidos);
                                    //if (!ronda.RondaFinal)
                                    //{
                                        var cuadroConEquipo = cuadroConEquipos.First(c => c.NumPartido.Equals(partido.NumeroPartido));
                                        temporadaRondaPartidos.Partidos.Add(new TemporadaPartidoRondaViewModel
                                        {
                                            Id = partido.Id,
                                            NumeroPartido = (int)partido.NumeroPartido,
                                            EquipoA = partido.NombreEquipoA != null ? partido.NombreEquipoA : cuadroConEquipo.EquipoA,
                                            EquipoB = partido.NombreEquipoB != null ? partido.NombreEquipoB : cuadroConEquipo.EquipoB,
                                            Ganador = partido.NombreGanador,
                                            Criterio = partido.Criterio,
                                            PartidoIda = partidosVM.Any() ? partidosVM.First() : null,
                                            PartidoVuelta = partidosVM.Any() ? partidosVM.Last() : null
                                        });
                                    //}
                                    //else 
                                    if (ronda.JornadasFinal != null && ronda.JornadasFinal.Any())
                                    {
                                        foreach(var p in partidosVM)
                                        {
                                            temporadaRondaPartidos.Partidos.Add(new TemporadaPartidoRondaViewModel
                                            {
                                                Id = partido.Id,
                                                NumeroPartido = (int)p.NumeroPartido,
                                                EquipoA = partido.NombreEquipoA != null ? partido.NombreEquipoA : p.EquipoA,
                                                EquipoB = partido.NombreEquipoB != null ? partido.NombreEquipoB : p.EquipoB,
                                                Ganador = partido.NombreGanador,
                                                Criterio = partido.Criterio,
                                                PartidoIda = p
                                                //PartidoVuelta = partidosVM.Any() ? partidosVM.Last() : null
                                            });
                                        }
                                    }
                                }
                            }
                            else
                            {

                            }
                            allRondasConPartidos.Add(temporadaRondaPartidos);
                        }
                    }
                }
                return allRondasConPartidos;
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return null;
            }
        }

        public async Task<ResponseOfTReturn<TemporadaRondaPartidos>> GetPartidosRondaSinGanador()
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return new ResponseOfTReturn<TemporadaRondaPartidos> { Message = "No existe temporada actual", Result = false, Status = EResponseStatus.Warning, ResultDTO = null };

                TemporadaCompeticionDTO temporadaCompeticion = await _temporadaCompeticionRepository.GetCompeticion(temporada.Id, LigamaniaConst.Competicion_Copa).ConfigureAwait(false);
                if (temporadaCompeticion == null)
                    return new ResponseOfTReturn<TemporadaRondaPartidos> { Message = "No existe la competición en la temporada actual.", Result = false, Status = EResponseStatus.Warning, ResultDTO = null };

                TemporadaCompeticionJornadaDTO jornadaCarrusel = await _temporadaCompeticionJornadaRepository.GetJornadaCarrusel(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                if (jornadaCarrusel == null)
                    return new ResponseOfTReturn<TemporadaRondaPartidos> { Message = "No existe jornada carrusel.", Result = false, Status = EResponseStatus.Warning, ResultDTO = null };

                TemporadaRondaDTO infoRonda = null;
                ICollection<TemporadaCuadroDTO> partidosRonda = null;
                if (temporadaCompeticion.Competicion.EsCopa)
                {
                    // información de la ronda
                    infoRonda = await _temporadaRondaRepository
                        .FindIncludingAsync(tr => tr.Temporada.Actual
                            && tr.Competicion.Nombre.Equals(temporadaCompeticion.Competicion.Nombre) && tr.Activa,
                            tr => tr.JornadaIda, tr => tr.JornadaVuelta).ConfigureAwait(false);

                    // partidos del cuadro correspondientes a la ronda activa
                    if (infoRonda != null && infoRonda.Activa)
                    {
                        partidosRonda = await _temporadaCuadroRepository
                            .FindAllAsync(tc => tc.TemporadaId.Equals(infoRonda.TemporadaID) &&
                                    tc.Ronda.Equals(infoRonda.NumRonda)).ConfigureAwait(false);
                    }
                }
                if (infoRonda != null && partidosRonda != null && partidosRonda.Any())
                {
                    IEnumerable<TemporadaCuadroDTO> partidosRondaSinGanador = partidosRonda
                        .Where(p => p.NombreGanador == null || string.IsNullOrEmpty(p.NombreGanador) || p.NombreGanador.Equals(LigamaniaConst.SinDefinir));

                    TemporadaRondaPartidos temporadaRondaPartidos = new TemporadaRondaPartidos
                    {
                        Ronda = infoRonda.NumRonda,
                        JornadaIda = infoRonda.JornadaIda.NumeroJornada,
                        JornadaVuelta = infoRonda.JornadaVuelta != null ? infoRonda.JornadaVuelta.NumeroJornada : 0,
                        Partidos = new List<TemporadaPartidoRondaViewModel>()
                    };

                    List<TemporadaPartidoDTO> partidos = new List<TemporadaPartidoDTO>();
                    //foreach (var partido in partidosRondaSinGanador.ToList())
                    foreach (var partido in partidosRonda.ToList())
                    {
                        List<TemporadaPartidoDTO> temporadaPartidos = await GetPartidosRonda(infoRonda, partido.NombreEquipoA, partido.NombreEquipoB).ConfigureAwait(false);
                        List<TemporadaPartidoViewModel> partidosVM = _mapper.Map<List<TemporadaPartidoViewModel>>(temporadaPartidos);
                        temporadaRondaPartidos.Partidos.Add(new TemporadaPartidoRondaViewModel
                        {
                            Id = partido.Id,
                            EquipoA = partido.NombreEquipoA,
                            EquipoB = partido.NombreEquipoB,
                            Ganador = partido.NombreGanador,
                            Criterio = partido.Criterio,
                            PartidoIda = partidosVM.Any() ? partidosVM.First() : null,
                            PartidoVuelta = partidosVM.Any() ? partidosVM.Last() : null
                        });
                    }
                    if (partidosRondaSinGanador.Any())
                        return new ResponseOfTReturn<TemporadaRondaPartidos> { Message = "Es necesario establecer el GANADOR de algunos partidos.", Result = true, Status = EResponseStatus.Warning,
                            ResultDTO = temporadaRondaPartidos };
                    else
                        return new ResponseOfTReturn<TemporadaRondaPartidos>
                        {
                            Message = "Todos los partidos tienen ganador.",
                            Result = true,
                            Status = EResponseStatus.Success,
                            ResultDTO = temporadaRondaPartidos
                        };

                }
                _logger.LogError("Operación incorrecta. Consultar con el administrador");
                return new ResponseOfTReturn<TemporadaRondaPartidos> { Message = "Operación incorrecta. Consultar con el administrador", Status = EResponseStatus.Error, Result = false };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new ResponseOfTReturn<TemporadaRondaPartidos> { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
            }
        }
        public async Task<TemporadaPartidoRondaViewModel> GetPartidoRonda(int partidoId)
        {
            try
            {
                TemporadaCuadroDTO partidoRonda = await _temporadaCuadroRepository.GetByIdIncludingAsync(partidoId, tc => tc.Competicion).ConfigureAwait(false);
                TemporadaRondaDTO infoRonda = await _temporadaRondaRepository.FindIncludingAsync(tr => tr.Temporada.Actual && tr.NumRonda==partidoRonda.Ronda, tr => tr.JornadaIda, tr => tr.JornadaVuelta, tr => tr.Temporada).ConfigureAwait(false);
                List<TemporadaPartidoDTO> temporadaPartidos = await GetPartidosRonda(infoRonda, partidoRonda.NombreEquipoA, partidoRonda.NombreEquipoB).ConfigureAwait(false);
                List<TemporadaPartidoViewModel> partidosVM = _mapper.Map<List<TemporadaPartidoViewModel>>(temporadaPartidos);
                foreach (var partido in partidosVM)
                {
                    ICollection<AlineacionDTO> aliactualA = await _alineacionRepository
                            .FindAllIncludingAsync(
                            ap => ap.Competicion.Nombre.Equals(partido.Competicion) && ap.Equipo.Equipo.Nombre.Equals(partido.EquipoA) && ap.Jornada.NumeroJornada.Equals(partido.Jornada),
                            ap => ap.Jugador, ap => ap.Club, ap => ap.Puesto).ConfigureAwait(false);
                    ICollection<AlineacionDTO> aliactualB = await _alineacionRepository
                        .FindAllIncludingAsync(
                        ap => ap.Competicion.Nombre.Equals(partido.Competicion) && ap.Equipo.Equipo.Nombre.Equals(partido.EquipoB) && ap.Jornada.NumeroJornada.Equals(partido.Jornada),
                        ap => ap.Jugador, ap => ap.Club, ap => ap.Puesto).ConfigureAwait(false);
                    partido.AlineacionEquipoA = _mapper.Map<List<AlineacionDTO>, List<AlineacionViewModel>>(aliactualA.ToList());
                    partido.AlineacionEquipoB = _mapper.Map<List<AlineacionDTO>, List<AlineacionViewModel>>(aliactualB.ToList());

                    TemporadaCompeticionJornadaDTO jornadaComp = await _temporadaCompeticionJornadaRepository.GetJornada(infoRonda.Temporada.Id, infoRonda.CompeticionID, partido.Jornada).ConfigureAwait(false);
                    ICollection<TemporadaJornadaJugadorDTO> goleadores = await _temporadaJornadaJugadorRepository.GetGoleadores(jornadaComp).ConfigureAwait(false);
                    ICollection<TemporadaJornadaJugadorDTO> infoJugadoresA = await _temporadaJornadaJugadorRepository.GetInfoJugadoresJornada(jornadaComp, aliactualA.Select(a => a.Jugador.Nombre).ToList()).ConfigureAwait(false);
                    ICollection<TemporadaJornadaJugadorDTO> infoJugadoresB = await _temporadaJornadaJugadorRepository.GetInfoJugadoresJornada(jornadaComp, aliactualB.Select(a => a.Jugador.Nombre).ToList()).ConfigureAwait(false);

                    LigamaniaUtils.CheckJugadoresAlineacion(partido.AlineacionEquipoA, null, goleadores, null, null, null, infoJugadoresA);
                    LigamaniaUtils.CheckJugadoresAlineacion(partido.AlineacionEquipoB, null, goleadores, null, null, null, infoJugadoresB);
                }
                TemporadaPartidoRondaViewModel partidoVM = new TemporadaPartidoRondaViewModel
                {
                    Id = partidoRonda.Id,
                    EquipoA = partidoRonda.NombreEquipoA,
                    EquipoB = partidoRonda.NombreEquipoB,
                    Ganador = partidoRonda.NombreGanador,
                    Criterio = partidoRonda.Criterio,
                    PartidoIda = partidosVM.Any() ? partidosVM.First() : null,
                    PartidoVuelta = partidosVM.Any() ? partidosVM.Last() : null
                };
                return partidoVM;
            }
            catch(Exception x)
            {
                _logger.LogError("Error obteniendo información del partido. " + x.Message);
                return null;
            }
        }
        private async Task CheckAndUpdatePartidoBAY(TemporadaCuadroDTO partidoRonda)
        {
            if (partidoRonda == null) return;
            if (partidoRonda.NombreEquipoA.Equals(LigamaniaConst.Equipo_Bay) || partidoRonda.NombreEquipoB.Equals(LigamaniaConst.Equipo_Bay))
            {
                if (partidoRonda.NombreEquipoA.Equals(LigamaniaConst.Equipo_Bay))
                {
                    partidoRonda.NombreGanador = partidoRonda.NombreEquipoB;
                    partidoRonda.Criterio = LigamaniaEnum.eCriteriosGanador.EquipoBOT.ToString();
                }
                if (partidoRonda.NombreEquipoB.Equals(LigamaniaConst.Equipo_Bay))
                {
                    partidoRonda.NombreGanador = partidoRonda.NombreEquipoA;
                    partidoRonda.Criterio = LigamaniaEnum.eCriteriosGanador.EquipoBOT.ToString();
                }
                await _temporadaCuadroRepository.UpdateAsyn(partidoRonda, partidoRonda.Id).ConfigureAwait(false);
            }
        }
        private async Task<bool> EstableceGanadorPartidoRonda(TemporadaRondaDTO infoRonda, TemporadaPartidoDTO partidoVuelta, ICollection<TemporadaCuadroDTO> partidosRonda)
        {
            bool generar = false;
            // si la ronda no es ronda final, se busca el partido de ida
            // si es ronda final, si el resultado es empate, hay que añadir nueva jornada a la ronda final
            List<TemporadaPartidoDTO> partidos = await GetPartidosRonda(infoRonda, partidoVuelta.EquipoA, partidoVuelta.EquipoB).ConfigureAwait(false);

            // en partidoVuelta está el partido jugado en la jornada actual (partido de vuelta)
            // en partidos está el partido jugado en la jornada de ida
            EquipoDTO ganador = null;
            if (!infoRonda.RondaFinal)
            {
                partidos.Add(partidoVuelta);
                TemporadaPartidoDTO partidoIda = partidos.First();

                int resultado_A = partidoIda.ResultadoA + partidoVuelta.ResultadoB;
                int resultado_B = partidoIda.ResultadoB + partidoVuelta.ResultadoA;

                if (resultado_A > resultado_B)
                    ganador = partidoIda.EquipoA;
                else if (resultado_B > resultado_A)
                    ganador = partidoIda.EquipoB;
            }
            else
            // es ronda final, por tanto, si el partido jugado terminó en empate, hay que generar una nueva jornada y añadirla a las rondas finales de TemporadaRonda
            {
                if (partidoVuelta.ResultadoA > partidoVuelta.ResultadoB)
                    ganador = partidoVuelta.EquipoA;
                else if (partidoVuelta.ResultadoB > partidoVuelta.ResultadoA)
                    ganador = partidoVuelta.EquipoB;
            }
            TemporadaCuadroDTO partidoCuadro = partidosRonda
                .FirstOrDefault(pr => (pr.NombreEquipoA.Equals(partidoVuelta.EquipoA.Nombre) && pr.NombreEquipoB.Equals(partidoVuelta.EquipoB.Nombre)) ||
                                      (pr.NombreEquipoA.Equals(partidoVuelta.EquipoB.Nombre) && pr.NombreEquipoB.Equals(partidoVuelta.EquipoA.Nombre)));
            if (partidoCuadro != null)
            {
                if (ganador != null)
                {
                    partidoCuadro.NombreGanador = ganador.Nombre;
                    partidoCuadro.Criterio = LigamaniaEnum.eCriteriosGanador.NumeroGoles.ToString();
                }
                else
                {
                    partidoCuadro.NombreGanador = LigamaniaConst.SinDefinir;
                    partidoCuadro.Criterio = LigamaniaEnum.eCriteriosGanador.Ninguno.ToString();
                    if (infoRonda.RondaFinal) generar = true;
                }
                await _temporadaCuadroRepository.UpdateAsyn(partidoCuadro, partidoCuadro.Id).ConfigureAwait(false);
            }
            return generar;
        }
        private async Task<List<TemporadaPartidoDTO>> GetPartidosRonda(TemporadaRondaDTO infoRonda, string nombreEquipoA, string nombreEquipoB)
        {
            var equipoA = await _equipoRepository.FindAsync(e => e.Nombre.Equals(nombreEquipoA)).ConfigureAwait(false);
            var equipoB = await _equipoRepository.FindAsync(e => e.Nombre.Equals(nombreEquipoB)).ConfigureAwait(false);
            //var partidos = await GetPartidosRonda(infoRonda, equipoA, equipoB).ConfigureAwait(false);
            List<TemporadaPartidoDTO> partidos = new List<TemporadaPartidoDTO>();
            if (equipoA == null || equipoB == null) return partidos;
            if (/*!infoRonda.RondaFinal && */infoRonda.JornadaIdaID != null)
            {
                TemporadaPartidoDTO partido = await GetPartidoRondaJornada((int)infoRonda.JornadaIdaID, equipoA, equipoB).ConfigureAwait(false);
                if (partido != null)
                {
                    partidos.Add(partido);
                }
            }
            if (!infoRonda.RondaFinal && infoRonda.JornadaVuelta != null)
            {
                TemporadaPartidoDTO partido = await GetPartidoRondaJornada((int)infoRonda.JornadaVueltaID, equipoB, equipoA).ConfigureAwait(false);
                if (partido != null)
                {
                    partidos.Add(partido);
                }
            }
            else if (infoRonda.RondaFinal)
            {
                if (infoRonda.JornadaVuelta != null && infoRonda.JornadaVueltaID != null)
                {
                    TemporadaPartidoDTO partido = await GetPartidoRondaJornada((int)infoRonda.JornadaVueltaID, equipoA, equipoB).ConfigureAwait(false);
                    if (partido != null) partidos.Add(partido);
                }
                if (infoRonda.JornadasFinal != null)
                {
                    foreach (TemporadaCompeticionJornadaDTO jornada in infoRonda.JornadasFinal)
                    {
                        TemporadaPartidoDTO partido = await GetPartidoRondaJornada((int)jornada.Id, equipoA, equipoB).ConfigureAwait(false);
                        if (partido != null) partidos.Add(partido);
                    }
                }
            }
            return partidos;
        }
        private async Task<List<TemporadaPartidoDTO>> GetPartidosRonda(TemporadaRondaDTO infoRonda, EquipoDTO equipoA, EquipoDTO equipoB)
        {
            List<TemporadaPartidoDTO> partidos = new List<TemporadaPartidoDTO>();
            if (!infoRonda.RondaFinal && infoRonda.JornadaIdaID != null)
            {
                TemporadaPartidoDTO partido = await GetPartidoRondaJornada((int)infoRonda.JornadaIdaID, equipoA, equipoB).ConfigureAwait(false);
                if (partido != null)
                {
                    partidos.Add(partido);
                }
            }
            else if (infoRonda.RondaFinal)
            {
                if (infoRonda.JornadaVuelta != null && infoRonda.JornadaVueltaID != null)
                {
                    TemporadaPartidoDTO partido = await GetPartidoRondaJornada((int)infoRonda.JornadaVueltaID, equipoA, equipoB).ConfigureAwait(false);
                    if (partido != null) partidos.Add(partido);
                }
                if (infoRonda.JornadasFinal != null)
                {
                    foreach (TemporadaCompeticionJornadaDTO jornada in infoRonda.JornadasFinal)
                    {
                        TemporadaPartidoDTO partido = await GetPartidoRondaJornada((int)jornada.Id, equipoA, equipoB).ConfigureAwait(false);
                        if (partido != null) partidos.Add(partido);
                    }
                }
            }
            return partidos;
        }

        private async Task<TemporadaPartidoDTO> GetPartidoRondaJornada(int jornadaId, EquipoDTO equipoA, EquipoDTO equipoB)
        {
            var partido = await _temporadaPartidoRepository
                .FindIncludingAsync(tp => tp.JornadaId.Equals(jornadaId)
                    && ((tp.EquipoAId.Equals(equipoA.Id) && tp.EquipoBId.Equals(equipoB.Id)) || (tp.EquipoAId.Equals(equipoB.Id) && tp.EquipoBId.Equals(equipoA.Id))),
                    tp => tp.Competicion, tp => tp.EquipoA, tp => tp.EquipoB, tp => tp.Jornada)
                .ConfigureAwait(false);
            return partido;
        }

        public async Task<Response> CambiarJornada(TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return new Response { Message = "No existe temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await GetTemporadaCompeticion(temporada, competicionPC).ConfigureAwait(false);
                if (temporadaCompeticion == null)
                    return new Response { Message = "No existe la competición en la temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionJornadaDTO jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaActual(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                if (jornadaActual == null)
                    return new Response { Message = "No existe jornada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                bool esUltimaJornada = false;
                TemporadaCompeticionJornadaDTO lastJornada = await _temporadaCompeticionJornadaRepository.GetLastJornada(temporadaCompeticion.Competicion.Id).ConfigureAwait(false);
                if (lastJornada != null && lastJornada.NumeroJornada == jornadaActual.NumeroJornada)
                {
                    // Estamos en la última jornada, deja de ser actual, pero sigue siendo la Jornada Carrusel
                    jornadaActual.Actual = false;
                    await _temporadaCompeticionJornadaRepository.UpdateAsyn(jornadaActual, jornadaActual.Id).ConfigureAwait(false);
                    esUltimaJornada = true;
                }
                else
                    await _temporadaCompeticionJornadaRepository.IncrementarJornadaActual(temporadaCompeticion, jornadaActual).ConfigureAwait(false);

                await _temporadaCompeticionJornadaRepository.SaveAsync().ConfigureAwait(false);

                if (temporadaCompeticion.Competicion.EsCopa && !esUltimaJornada)
                {
                    // actualizar la tabla TemporadaRonda (JornadaIDAActiva)
                    TemporadaRondaDTO infoRonda = await _temporadaRondaRepository
                        .FindIncludingAsync(tr => tr.Temporada.Actual
                            && tr.Competicion.Nombre.Equals(temporadaCompeticion.Competicion.Nombre) && tr.Activa,
                            tr => tr.JornadaIda, tr => tr.JornadaVuelta).ConfigureAwait(false);
                    if (!infoRonda.RondaFinal)
                    {
                        if (infoRonda.JornadaIdaActiva)
                            infoRonda.JornadaIdaActiva = false;
                        else
                        {
                            // obtener siguiente ronda
                            TemporadaRondaDTO infoRondaSiguiente = await _temporadaRondaRepository
                                .FindIncludingAsync(tr => tr.Temporada.Actual
                                    && tr.Competicion.Nombre.Equals(temporadaCompeticion.Competicion.Nombre) && tr.NumRonda == infoRonda.NumRonda + 1,
                                    tr => tr.JornadaIda, tr => tr.JornadaVuelta).ConfigureAwait(false);
                            if (infoRondaSiguiente != null)
                            {
                                infoRonda.Activa = false;
                                infoRondaSiguiente.Activa = true;
                                infoRondaSiguiente.JornadaIdaActiva = true;
                                await _temporadaRondaRepository.UpdateAsyn(infoRondaSiguiente, infoRondaSiguiente.Id).ConfigureAwait(false);
                            }
                        }
                        await _temporadaRondaRepository.UpdateAsyn(infoRonda, infoRonda.Id).ConfigureAwait(false);
                    }
                }
                if (!esUltimaJornada)
                {
                    await NuevoEstadoCompeticion(temporadaCompeticion, LigamaniaConst.Estado_Abrir_Jornada,
                        LigamaniaConst.Operacion_Cambiar_Jornada,
                            "Preparando Jornada " + (jornadaActual.NumeroJornada + 1).ToString()).ConfigureAwait(false);
                }
                else
                {
                    await NuevoEstadoCompeticion(temporadaCompeticion, LigamaniaConst.Estado_Temporada_Finalizada,
                        LigamaniaConst.Operacion_TemporadaVisible,
                            "Temporada Finalizada").ConfigureAwait(false);
                }
                return new Response { Message = "Operación realizada con éxito", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
            }
        }

        public async Task<Response> CerrarAlineaciones(TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return new Response { Message = "No existe temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await GetTemporadaCompeticion(temporada, competicionPC).ConfigureAwait(false);
                if (temporadaCompeticion == null)
                    return new Response { Message = "No existe la competición en la temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionJornadaDTO jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaActual(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                if (jornadaActual == null)
                    return new Response { Message = "No existe jornada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                await CopiarAlineacionCambioToAlineaciones(temporadaCompeticion, jornadaActual).ConfigureAwait(false);

                await NuevoEstadoCompeticion(temporadaCompeticion, LigamaniaConst.Estado_Jornada_Inicial,
                    LigamaniaConst.Operacion_Cerrar_Alineacion,
                        "Cerradas Alineaciones Iniciales Jornada " + jornadaActual.NumeroJornada).ConfigureAwait(false);
                //GuardarAccion("Abrir alineación inicial - " + temporadaCompeticion.Competicion.Nombre);

                return new Response { Message = "Operación realizada con éxito", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
            }
        }

        public async Task<Response> CerrarCambios(TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return new Response { Message = "No existe temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await GetTemporadaCompeticion(temporada, competicionPC).ConfigureAwait(false);
                if (temporadaCompeticion == null)
                    return new Response { Message = "No existe la competición en la temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionJornadaDTO jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaActual(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                if (jornadaActual == null)
                    return new Response { Message = "No existe jornada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };
                await NuevoEstadoCompeticion(temporadaCompeticion, LigamaniaConst.Estado_Cerrar_Jornada,
                        LigamaniaConst.Operacion_Cerrar_Cambios,
                            "Cambios cerrados para la Jornada " + jornadaActual.NumeroJornada).ConfigureAwait(false);

                return new Response { Message = "Operación realizada con éxito", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
            }
        }
        public async Task<Response> CerrarJornada(TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return new Response { Message = "No existe temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await GetTemporadaCompeticion(temporada, competicionPC).ConfigureAwait(false);
                if (temporadaCompeticion == null)
                    return new Response { Message = "No existe la competición en la temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionJornadaDTO jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaActual(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                if (jornadaActual == null)
                    return new Response { Message = "No existe jornada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };


                bool temporadaFinalizada = false;
                if (temporadaCompeticion.Competicion.EsCopa)
                {
                    // actualizar la tabla TemporadaRonda (JornadaIDAActiva)
                    TemporadaRondaDTO infoRonda = await _temporadaRondaRepository
                        .FindIncludingAsync(tr => tr.Temporada.Actual
                            && tr.Competicion.Nombre.Equals(temporadaCompeticion.Competicion.Nombre) && tr.Activa,
                            tr => tr.JornadaIda, tr => tr.JornadaVuelta).ConfigureAwait(false);
                    if (infoRonda.RondaFinal)
                    {
                        var lTemporadaCuadro = await _temporadaCuadroRepository.FindAllAsync(tc => tc.Temporada.Actual && tc.Ronda.Equals(infoRonda.NumRonda)).ConfigureAwait(false);
                        var lTCuadroConGanador = lTemporadaCuadro.Where(tc => !string.IsNullOrEmpty(tc.NombreGanador));
                        if (lTCuadroConGanador.Count() == 1)
                            temporadaFinalizada = true;
                    }
                    if (temporadaFinalizada)
                    {
                        await NuevoEstadoCompeticion(temporadaCompeticion, LigamaniaConst.Estado_Temporada_Finalizada,
                            LigamaniaConst.Operacion_TemporadaVisible,
                                "Temporada Finalizada").ConfigureAwait(false);
                    }
                    else
                    {
                        await NuevoEstadoCompeticion(temporadaCompeticion, LigamaniaConst.Estado_Cerrar_Jornada,
                            LigamaniaConst.Operacion_Cerrar_Jornada,
                                "Jornada " + jornadaActual.NumeroJornada + " cerrada").ConfigureAwait(false);
                    }
                }
                else
                    await NuevoEstadoCompeticion(temporadaCompeticion, LigamaniaConst.Estado_Cerrar_Jornada,
                        LigamaniaConst.Operacion_Cerrar_Jornada,
                        "Jornada " + jornadaActual.NumeroJornada + " cerrada").ConfigureAwait(false);

                return new Response { Message = "Operación realizada con éxito", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
            }
        }

        public async Task<Response> GuardarAlineaciones(TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return new Response { Message = "No existe temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await GetTemporadaCompeticion(temporada, competicionPC).ConfigureAwait(false);
                if (temporadaCompeticion == null)
                    return new Response { Message = "No existe la competición en la temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionJornadaDTO jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaActual(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                if (jornadaActual == null)
                    return new Response { Message = "No existe jornada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                // es lo mismo que CerrarAlineaciones
                await CopiarAlineacionCambioToAlineaciones(temporadaCompeticion, jornadaActual).ConfigureAwait(false);

                // revisar que todos los equipos que tuvieran alineacion libre, les quede anulado
                await RevisarEquipos(temporadaCompeticion).ConfigureAwait(false);

                await NuevoEstadoCompeticion(temporadaCompeticion, LigamaniaConst.Estado_Cerrar_Jornada,
                    LigamaniaConst.Operacion_Guardar_Alineacion,
                        "Alineaciones guardadas para la Jornada " + jornadaActual.NumeroJornada).ConfigureAwait(false);
                //GuardarAccion("Abrir alineación inicial - " + temporadaCompeticion.Competicion.Nombre);

                return new Response { Message = "Operación realizada con éxito", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
            }
        }

        public async Task<Response> PublicarCarrusel(TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return new Response { Message = "No existe temporada actual. No se puede publicar el carrusel", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await GetTemporadaCompeticion(temporada, competicionPC).ConfigureAwait(false);
                if (temporadaCompeticion == null)
                    return new Response { Message = "No existe la competición en la temporada actual. No se puede publicar el carrusel", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionJornadaDTO jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaActual(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                if (jornadaActual == null)
                    return new Response { Message = "No existe jornada actual. No se puede publicar el carrusel", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionJornadaDTO jornadaCarrusel = await _temporadaCompeticionJornadaRepository.GetJornadaCarrusel(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                //if (jornadaCarrusel == null)
                //    return new Response { Message = "No existe jornada previa (carrusel). No se pueden abrir cambios", Result = false, Status = EResponseStatus.Warning };

                if (jornadaCarrusel != null)
                {
                    jornadaCarrusel.Carrusel = false;
                    await _temporadaCompeticionJornadaRepository.UpdateAsyn(jornadaCarrusel, jornadaCarrusel.Id).ConfigureAwait(false);
                }
                jornadaActual.Carrusel = true;
                await _temporadaCompeticionJornadaRepository.UpdateAsyn(jornadaActual, jornadaActual.Id).ConfigureAwait(false);
                await _temporadaCompeticionJornadaRepository.SaveAsync().ConfigureAwait(false);

                if (competicionPC.EstadoCompeticion.Equals(LigamaniaConst.JI_CerrarAli))
                    await NuevoEstadoCompeticion(temporadaCompeticion, LigamaniaConst.Estado_Jornada_Inicial,
                    LigamaniaConst.Operacion_Publicar_Carrusel,
                        "Jornada " + jornadaActual.NumeroJornada + " en Juego!").ConfigureAwait(false);
                else
                    await NuevoEstadoCompeticion(temporadaCompeticion, LigamaniaConst.Estado_Cerrar_Jornada,
                        LigamaniaConst.Operacion_Publicar_Carrusel,
                            "Jornada " + jornadaActual.NumeroJornada + " en Juego!").ConfigureAwait(false);

                //GuardarAccion("Abrir alineación inicial - " + temporadaCompeticion.Competicion.Nombre);

                return new Response { Message = "Operación realizada con éxito", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
            }
        }

        public async Task<Response> RescatarEliminados(TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return new Response { Message = "No existe temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await GetTemporadaCompeticion(temporada, competicionPC).ConfigureAwait(false);
                if (temporadaCompeticion == null)
                    return new Response { Message = "No existe la competición en la temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionJornadaDTO jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaActual(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                if (jornadaActual == null)
                    return new Response { Message = "No existe jornada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

                //TemporadaCompeticionJornada_DTO jornadaPreeliminados = jornadaCarrusel;
                TemporadaCompeticionJornadaDTO jornadaRescate = jornadaActual;

                bool operacionForzada = false;
                if (competicionPC.Jornada != 0)
                {
                    operacionForzada = true;
                    jornadaRescate = await _temporadaCompeticionJornadaRepository.GetJornada(temporadaCompeticion.TemporadaId, temporadaCompeticion.CompeticionId, competicionPC.Jornada).ConfigureAwait(false);
                    //jornadaPreeliminados = await _temporadaCompeticionJornadaRepository.GetJornada(temporadaCompeticion.TemporadaId, temporadaCompeticion.CompeticionId, competicionPC.Jornada - 1);
                }

                // todos los jugadores eliminados en este momento
                ICollection<TemporadaJugadorDTO> jugadoresEliminados = await _temporadaJugadorRepository.GetJugadoresEliminados().ConfigureAwait(false);
                List<TemporadaJugadorDTO> jugadoresEliminadosMaxVeces = jugadoresEliminados.Where(j => j.VecesEliminado >= MaxVecesEliminado).ToList();
                List<TemporadaJugadorDTO> listaRescatar = jugadoresEliminados.Where(j => j.LastJornadaEliminacion.NumeroJornada.Equals(jornadaRescate.NumeroJornada - JornadasEliminado)).ToList();

                foreach (var jugador in listaRescatar)
                {
                    if (jugadoresEliminadosMaxVeces.Contains(jugador)) continue; // no lo rescatamos, ya fue eliminado 3 veces o más
                    jugador.Eliminado = false;
                    await _temporadaJugadorRepository.UpdateAsyn(jugador, jugador.Id).ConfigureAwait(false);
                }
                await _temporadaJugadorRepository.SaveAsync().ConfigureAwait(false);

                if (!operacionForzada)
                    await NuevoEstadoCompeticion(temporadaCompeticion, LigamaniaConst.Estado_Abrir_Jornada,
                        LigamaniaConst.Operacion_Rescatar_Eliminados,
                             "Preparando Jornada " + jornadaRescate.NumeroJornada.ToString()).ConfigureAwait(false);
                //GuardarAccion("Abrir alineación inicial - " + temporadaCompeticion.Competicion.Nombre);

                return new Response { Message = "Operación realizada con éxito", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
            }
        }
        public async Task<Response> ActivarRondaCopa(TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return new Response { Message = "No existe temporada actual. No se puede activar ronda de Copa", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await GetTemporadaCompeticion(temporada, competicionPC).ConfigureAwait(false);
                if (temporadaCompeticion == null)
                    return new Response { Message = "No existe la competición en la temporada actual. No se puede activar ronda de Copa", Result = false, Status = EResponseStatus.Warning };

                int ronda = await _temporadaRondaRepository.ActivarSiguienteRonda(temporadaCompeticion).ConfigureAwait(false);
                await _temporadaRondaRepository.SaveAsync().ConfigureAwait(false);

                TemporadaCompeticionJornadaDTO jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaActual(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                if (jornadaActual == null)
                    return new Response { Message = "No existe jornada actual. No se puede activar ronda de Copa", Result = false, Status = EResponseStatus.Warning };

                await NuevoEstadoCompeticion(temporadaCompeticion, LigamaniaConst.Estado_Jornada_Inicial,
                    LigamaniaConst.Operacion_Inicial,
                        "Preparando Ronda de Copa " + ronda + " - Jornada " + (jornadaActual.NumeroJornada).ToString()).ConfigureAwait(false);

                return new Response { Message = "Operación realizada con éxito", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
            }
        }
        public async Task<Response> EditarJugador(AlineacionViewModel jugadorInfo)
        {
            try
            {
                TemporadaCompeticionJornadaDTO jornada = await _temporadaCompeticionJornadaRepository.GetByIdIncludingAsync(jugadorInfo.NumeroJornada).ConfigureAwait(false);
                if (jornada == null)
                    return new Response { Message = "No existe jornada", Result = false, Status = EResponseStatus.Warning };

                TemporadaJornadaJugadorDTO jugadorJornada = await _temporadaJornadaJugadorRepository.FindAsync(tjj => tjj.Jugador.Nombre.Equals(jugadorInfo.Jugador) && tjj.JornadaId.Equals(jornada.Id)).ConfigureAwait(false);
                if (jugadorJornada == null)
                {
                    TemporadaJugadorDTO jugador = await _temporadaJugadorRepository.FindIncludingAsync(tj => tj.Temporada.Actual && tj.Jugador.Nombre.Equals(jugadorInfo.Jugador) && tj.Activo, tj => tj.Jugador, tj => tj.Temporada).ConfigureAwait(false);
                    jugadorJornada = new TemporadaJornadaJugadorDTO
                    {
                        Eliminado = false,
                        GolesContra = 0,
                        GolesFavor = 0,
                        Jornada = jornada,
                        Jugador = jugador.Jugador,
                        MinutosJugados = jugadorInfo.MinutosJugados,
                        TarjetasAmarillas = jugadorInfo.TarjetasAmarillas,
                        TarjetasRojas = jugadorInfo.TarjetasRojas,
                        PreEliminado = false,
                        Temporada = jugador.Temporada
                    };
                    await _temporadaJornadaJugadorRepository.AddAsyn(jugadorJornada).ConfigureAwait(false);
                }
                else
                {
                    jugadorJornada.MinutosJugados = jugadorInfo.MinutosJugados;
                    jugadorJornada.TarjetasRojas = jugadorInfo.TarjetasRojas;
                    jugadorJornada.TarjetasAmarillas = jugadorInfo.TarjetasAmarillas;
                    await _temporadaJornadaJugadorRepository.UpdateAsyn(jugadorJornada, jugadorJornada.Id).ConfigureAwait(false);
                }
                await _temporadaJornadaJugadorRepository.SaveAsync().ConfigureAwait(false);


                return new Response { Message = "Operación realizada con éxito", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
            }
        }

        public async Task<Response> SetCriterioGanadorPartido(TemporadaPartidoRondaViewModel infoRondaVm)
        {
            try
            {
                TemporadaRondaDTO infoRonda = await _temporadaRondaRepository.FindIncludingAsync(tr => tr.Temporada.Actual && tr.Activa, tr => tr.JornadaIda, tr => tr.JornadaVuelta, tr => tr.Temporada).ConfigureAwait(false);
                TemporadaCuadroDTO partidoRonda = await _temporadaCuadroRepository.GetByIdIncludingAsync(infoRondaVm.Id, tc => tc.Competicion).ConfigureAwait(false);
                List<TemporadaPartidoDTO> temporadaPartidos = await GetPartidosRonda(infoRonda, partidoRonda.NombreEquipoA, partidoRonda.NombreEquipoB).ConfigureAwait(false);
                InfoPartidoRonda infoPartidoIda = await GetInfoPartido(temporadaPartidos.First()).ConfigureAwait(false);
                InfoPartidoRonda infoPartidoVuelta = await GetInfoPartido(temporadaPartidos.Last()).ConfigureAwait(false);

                // NumeroGolesCampoContrario
                var golesEquipoA = infoPartidoVuelta.AlineacionEquipoB.Sum(j => j.GF) + infoPartidoVuelta.AlineacionEquipoA.Sum(j => j.GC);
                var golesEquipoB = infoPartidoIda.AlineacionEquipoB.Sum(j => j.GF) + infoPartidoIda.AlineacionEquipoA.Sum(j => j.GC);
                Response response = await CriterioGanador(LigamaniaEnum.eCriteriosGanador.NumeroGolesCampoContrario, partidoRonda, golesEquipoA, golesEquipoB,false).ConfigureAwait(false);
                if (response.Result)
                {
                    await CheckResultadoPartidos().ConfigureAwait(false);
                    return response;
                }

                // NumeroGolesExtra
                golesEquipoA = infoPartidoIda.AlineacionEquipoB.Sum(j => j.GC) + infoPartidoVuelta.AlineacionEquipoA.Sum(j => j.GC);
                golesEquipoB = infoPartidoIda.AlineacionEquipoA.Sum(j => j.GC) + infoPartidoVuelta.AlineacionEquipoB.Sum(j => j.GC);
                response = await CriterioGanador(LigamaniaEnum.eCriteriosGanador.NumeroGolesExtra, partidoRonda, golesEquipoA, golesEquipoB, true).ConfigureAwait(false);
                if (response.Result)
                {
                    await CheckResultadoPartidos().ConfigureAwait(false);
                    return response;
                }

                // NumeroGoleadoresDistintos
                golesEquipoA = infoPartidoIda.AlineacionEquipoA.Where(j => j.GF > 0).Concat(infoPartidoVuelta.AlineacionEquipoB.Where(j => j.GF > 0))
                        .GroupBy(j => j.Jugador).Select(grp => grp.First()).Count(j => j.GF > 0);
                golesEquipoB = infoPartidoIda.AlineacionEquipoB.Where(j => j.GF > 0).Concat(infoPartidoVuelta.AlineacionEquipoA.Where(j => j.GF > 0))
                    .GroupBy(j => j.Jugador).Select(grp => grp.First()).Count(j => j.GF > 0);
                response = await CriterioGanador(LigamaniaEnum.eCriteriosGanador.NumeroGoleadoresDistintos, partidoRonda, golesEquipoA, golesEquipoB, false).ConfigureAwait(false);
                if (response.Result)
                {
                    await CheckResultadoPartidos().ConfigureAwait(false);
                    return response;
                }

                // NumeroPorteros
                golesEquipoA = infoPartidoIda.AlineacionEquipoA.Where(j => j.Puesto.Equals(LigamaniaConst.Puesto_Portero)).Sum(j => j.GF)
                         + infoPartidoVuelta.AlineacionEquipoB.Where(j => j.Puesto.Equals(LigamaniaConst.Puesto_Portero)).Sum(j => j.GF);
                golesEquipoB = infoPartidoIda.AlineacionEquipoB.Where(j => j.Puesto.Equals(LigamaniaConst.Puesto_Portero)).Sum(j => j.GF)
                    + infoPartidoVuelta.AlineacionEquipoA.Where(j => j.Puesto.Equals(LigamaniaConst.Puesto_Portero)).Sum(j => j.GF);
                response = await CriterioGanador(LigamaniaEnum.eCriteriosGanador.NumeroPorteros, partidoRonda, golesEquipoA, golesEquipoB, false).ConfigureAwait(false);
                if (response.Result)
                {
                    await CheckResultadoPartidos().ConfigureAwait(false);
                    return response;
                }

                // NumeroDefensas
                golesEquipoA = infoPartidoIda.AlineacionEquipoA.Where(j => j.Puesto.Equals(LigamaniaConst.Puesto_Defensa)).Sum(j => j.GF)
                     + infoPartidoVuelta.AlineacionEquipoB.Where(j => j.Puesto.Equals(LigamaniaConst.Puesto_Defensa)).Sum(j => j.GF);
                golesEquipoB = infoPartidoIda.AlineacionEquipoB.Where(j => j.Puesto.Equals(LigamaniaConst.Puesto_Defensa)).Sum(j => j.GF)
                    + infoPartidoVuelta.AlineacionEquipoA.Where(j => j.Puesto.Equals(LigamaniaConst.Puesto_Defensa)).Sum(j => j.GF);
                response = await CriterioGanador(LigamaniaEnum.eCriteriosGanador.NumeroDefensas, partidoRonda, golesEquipoA, golesEquipoB, false).ConfigureAwait(false);
                if (response.Result)
                {
                    await CheckResultadoPartidos().ConfigureAwait(false);
                    return response;
                }

                // NumeroMedios
                golesEquipoA = infoPartidoIda.AlineacionEquipoA.Where(j => j.Puesto.Equals(LigamaniaConst.Puesto_Medio)).Sum(j => j.GF)
                     + infoPartidoVuelta.AlineacionEquipoB.Where(j => j.Puesto.Equals(LigamaniaConst.Puesto_Medio)).Sum(j => j.GF);
                golesEquipoB = infoPartidoIda.AlineacionEquipoB.Where(j => j.Puesto.Equals(LigamaniaConst.Puesto_Medio)).Sum(j => j.GF)
                    + infoPartidoVuelta.AlineacionEquipoA.Where(j => j.Puesto.Equals(LigamaniaConst.Puesto_Medio)).Sum(j => j.GF);
                response = await CriterioGanador(LigamaniaEnum.eCriteriosGanador.NumeroMedios, partidoRonda, golesEquipoA, golesEquipoB, false).ConfigureAwait(false);
                if (response.Result)
                {
                    await CheckResultadoPartidos().ConfigureAwait(false);
                    return response;
                }

                // MinutosJugados
                golesEquipoA = infoPartidoIda.AlineacionEquipoA.Sum(j => j.MinutosJugados) + infoPartidoVuelta.AlineacionEquipoB.Sum(j => j.MinutosJugados);
                golesEquipoB = infoPartidoIda.AlineacionEquipoB.Sum(j => j.MinutosJugados) + infoPartidoVuelta.AlineacionEquipoA.Sum(j => j.MinutosJugados);
                response = await CriterioGanador(LigamaniaEnum.eCriteriosGanador.MinutosJugados, partidoRonda, golesEquipoA, golesEquipoB, false).ConfigureAwait(false);
                if (response.Result)
                {
                    await CheckResultadoPartidos().ConfigureAwait(false);
                    return response;
                }

                // TarjetasAmarillas
                golesEquipoA = infoPartidoIda.AlineacionEquipoA.Sum(j => j.TarjetasAmarillas) + infoPartidoVuelta.AlineacionEquipoB.Sum(j => j.TarjetasAmarillas);
                golesEquipoB = infoPartidoIda.AlineacionEquipoB.Sum(j => j.TarjetasAmarillas) + infoPartidoVuelta.AlineacionEquipoA.Sum(j => j.TarjetasAmarillas);
                response = await CriterioGanador(LigamaniaEnum.eCriteriosGanador.TarjetasAmarillas, partidoRonda, golesEquipoA, golesEquipoB, true).ConfigureAwait(false);
                if (response.Result)
                {
                    await CheckResultadoPartidos().ConfigureAwait(false);
                    return response;
                }

                // TarjetasRojas
                golesEquipoA = infoPartidoIda.AlineacionEquipoA.Sum(j => j.TarjetasRojas) + infoPartidoVuelta.AlineacionEquipoB.Sum(j => j.TarjetasRojas);
                golesEquipoB = infoPartidoIda.AlineacionEquipoB.Sum(j => j.TarjetasRojas) + infoPartidoVuelta.AlineacionEquipoA.Sum(j => j.TarjetasRojas);
                response = await CriterioGanador(LigamaniaEnum.eCriteriosGanador.TarjetasRojas, partidoRonda, golesEquipoA, golesEquipoB, true).ConfigureAwait(false);
                if (response.Result)
                {
                    await CheckResultadoPartidos().ConfigureAwait(false);
                    return response;
                }

                //PromedioGoles
                List<AlineacionDTO> alineacionesA = await _alineacionRepository.GetAllAlineacionesEquipo(partidoRonda.CompeticionId, partidoRonda.NombreEquipoA).ConfigureAwait(false);
                List<AlineacionDTO> alineacionesB = await _alineacionRepository.GetAllAlineacionesEquipo(partidoRonda.CompeticionId, partidoRonda.NombreEquipoB).ConfigureAwait(false);

                // jornadas jugadas
                var numJornadas = alineacionesA.GroupBy(a => a.Jornada.Id).Count();

                var numGolesEA = alineacionesA.Sum(a => a.Jugador.TemporadaJornadaJugador.Where(j => j.Temporada.Actual && j.Jornada.Id.Equals(a.Jornada_ID) && j.JugadorId.Equals(a.Jugador_ID)).Sum(j => j.GolesFavor));
                var numGolesEB = alineacionesB.Sum(a => a.Jugador.TemporadaJornadaJugador.Where(j => j.Temporada.Actual && j.Jornada.Id.Equals(a.Jornada_ID) && j.JugadorId.Equals(a.Jugador_ID)).Sum(j => j.GolesFavor));

                numGolesEA += alineacionesB.Sum(a => a.Jugador.TemporadaJornadaJugador.Where(j => j.Temporada.Actual && j.Jornada.Id.Equals(a.Jornada_ID) && j.JugadorId.Equals(a.Jugador_ID)).Sum(j => j.GolesContra));
                numGolesEB += alineacionesA.Sum(a => a.Jugador.TemporadaJornadaJugador.Where(j => j.Temporada.Actual && j.Jornada.Id.Equals(a.Jornada_ID) && j.JugadorId.Equals(a.Jugador_ID)).Sum(j => j.GolesContra));
                if (numJornadas > 0)
                {
                    golesEquipoA = numGolesEA / numJornadas;
                    golesEquipoB = numGolesEB / numJornadas;
                    response = await CriterioGanador(LigamaniaEnum.eCriteriosGanador.PromedioGoles, partidoRonda, golesEquipoA, golesEquipoB, true).ConfigureAwait(false);
                    if (response.Result)
                    {
                        await CheckResultadoPartidos().ConfigureAwait(false);
                        return response;
                    }
                }
                return new Response { Message = "No se puede establecer el ganador por ningún criterio conocido", Result = false, Status = EResponseStatus.Warning };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
            }
        }

        public async Task<Response> CheckResultadoPartidos()
        {
            TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
            if (temporada == null)
                return new Response { Message = "No existe temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

            TemporadaCompeticionDTO temporadaCompeticion = await _temporadaCompeticionRepository.GetCompeticion(temporada.Id, LigamaniaConst.Competicion_Copa).ConfigureAwait(false);
            if (temporadaCompeticion == null)
                return new Response { Message = "No existe la competición en la temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

            TemporadaCompeticionJornadaDTO jornadaCarrusel = await _temporadaCompeticionJornadaRepository.GetJornadaCarrusel(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
            if (jornadaCarrusel == null)
                return new Response { Message = "No existe jornada previa (carrusel). No se pueden abrir cambios", Result = false, Status = EResponseStatus.Warning };

            TemporadaRondaDTO infoRonda = null;
            ICollection<TemporadaCuadroDTO> partidosRonda = null;
            infoRonda = await _temporadaRondaRepository
                .FindIncludingAsync(tr => tr.Temporada.Actual
                    && tr.Competicion.Nombre.Equals(temporadaCompeticion.Competicion.Nombre) && tr.Activa,
                    tr => tr.JornadaIda, tr => tr.JornadaVuelta).ConfigureAwait(false);

            if (infoRonda != null && infoRonda.Activa)
            {
                partidosRonda = await _temporadaCuadroRepository
                    .FindAllAsync(tc => tc.TemporadaId.Equals(infoRonda.TemporadaID) &&
                            tc.Ronda.Equals(infoRonda.NumRonda)).ConfigureAwait(false);
            }
            if (infoRonda != null && partidosRonda != null && partidosRonda.Any())
            {
                bool existenPartidosSinGanador = partidosRonda.Any(p => p.NombreGanador == null || string.IsNullOrEmpty(p.NombreGanador) || p.NombreGanador.Equals(LigamaniaConst.SinDefinir));
                if (!existenPartidosSinGanador)
                {
                    await NuevoEstadoCompeticion(temporadaCompeticion, LigamaniaConst.Estado_Abrir_Jornada, LigamaniaConst.Operacion_EstablecerGanadores,
                        "Actualizados los ganadores de la ronda").ConfigureAwait(false);

                    return new Response { Message = "Todos los partidos tienen GANADOR. Operación realizada con éxito", Result = true, Status = EResponseStatus.Success };
                }
                else
                {
                    return new Response { Message = "Es necesario establecer el GANADOR de algunos partidos.", Result = false, Status = EResponseStatus.Warning };
                }
            }
            return new Response { Result = false };
        }

        private async Task<Response> CriterioGanador(LigamaniaEnum.eCriteriosGanador criterio, TemporadaCuadroDTO partidoRonda, int valorEquipoA, int valorEquipoB, bool menor=false)
        {
            if (!menor)
            {
                if (valorEquipoA > valorEquipoB)
                {
                    partidoRonda.NombreGanador = partidoRonda.NombreEquipoA;
                    partidoRonda.Criterio = criterio.ToString();
                    await _temporadaCuadroRepository.UpdateAsyn(partidoRonda, partidoRonda.Id).ConfigureAwait(false);
                    await _temporadaRondaRepository.SaveAsync().ConfigureAwait(false);
                    return new Response { Message = "Ganador " + partidoRonda.NombreGanador + " con criterio " + partidoRonda.Criterio, Result = true, Status = EResponseStatus.Success };
                }
                else if (valorEquipoA < valorEquipoB)
                {
                    partidoRonda.NombreGanador = partidoRonda.NombreEquipoB;
                    partidoRonda.Criterio = criterio.ToString();
                    await _temporadaCuadroRepository.UpdateAsyn(partidoRonda, partidoRonda.Id).ConfigureAwait(false);
                    await _temporadaRondaRepository.SaveAsync().ConfigureAwait(false);
                    return new Response { Message = "Ganador " + partidoRonda.NombreGanador + " con criterio " + partidoRonda.Criterio, Result = true, Status = EResponseStatus.Success };
                }
            }
            else
            {
                if (valorEquipoA < valorEquipoB)
                {
                    partidoRonda.NombreGanador = partidoRonda.NombreEquipoA;
                    partidoRonda.Criterio = criterio.ToString();
                    await _temporadaCuadroRepository.UpdateAsyn(partidoRonda, partidoRonda.Id).ConfigureAwait(false);
                    await _temporadaRondaRepository.SaveAsync().ConfigureAwait(false);
                    return new Response { Message = "Ganador " + partidoRonda.NombreGanador + " con criterio " + partidoRonda.Criterio, Result = true, Status = EResponseStatus.Success };
                }
                else if (valorEquipoA > valorEquipoB)
                {
                    partidoRonda.NombreGanador = partidoRonda.NombreEquipoB;
                    partidoRonda.Criterio = criterio.ToString();
                    await _temporadaCuadroRepository.UpdateAsyn(partidoRonda, partidoRonda.Id).ConfigureAwait(false);
                    await _temporadaRondaRepository.SaveAsync().ConfigureAwait(false);
                    return new Response { Message = "Ganador " + partidoRonda.NombreGanador + " con criterio " + partidoRonda.Criterio, Result = true, Status = EResponseStatus.Success };
                }
            }
            return new Response { Result = false };
        }
        public async Task<Response> SetGanadorPartidoManual(TemporadaPartidoRondaViewModel infoRondaVm)
        {
            try
            {
                TemporadaRondaDTO infoRonda = await _temporadaRondaRepository.FindIncludingAsync(tr => tr.Temporada.Actual && tr.Activa, tr => tr.JornadaIda, tr => tr.JornadaVuelta, tr => tr.Temporada).ConfigureAwait(false);
                TemporadaCuadroDTO partidoRonda = await _temporadaCuadroRepository.GetByIdIncludingAsync(infoRondaVm.Id, tc => tc.Competicion).ConfigureAwait(false);

                partidoRonda.NombreGanador = infoRondaVm.Ganador;
                partidoRonda.Criterio = !string.IsNullOrEmpty(infoRondaVm.Criterio) ? infoRondaVm.Criterio : LigamaniaEnum.eCriteriosGanador.Manual.ToString();
                await _temporadaCuadroRepository.UpdateAsyn(partidoRonda, partidoRonda.Id).ConfigureAwait(false);
                await _temporadaRondaRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Ganador " + partidoRonda.NombreGanador + " con criterio " + partidoRonda.Criterio, Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
            }
        }

        private async Task<InfoPartidoRonda> GetInfoPartido(TemporadaPartidoDTO temporadaPartidoDTO)
        {
            ICollection<AlineacionDTO> aliactualA = await _alineacionRepository
                        .FindAllIncludingAsync(
                        ap => ap.Competicion.Nombre.Equals(temporadaPartidoDTO.Competicion.Nombre) && ap.Equipo.Equipo.Nombre.Equals(temporadaPartidoDTO.EquipoA.Nombre) && ap.Jornada.NumeroJornada.Equals(temporadaPartidoDTO.Jornada.NumeroJornada),
                        ap => ap.Jugador, ap => ap.Club, ap => ap.Puesto).ConfigureAwait(false);
            ICollection<AlineacionDTO> aliactualB = await _alineacionRepository
                    .FindAllIncludingAsync(
                    ap => ap.Competicion.Nombre.Equals(temporadaPartidoDTO.Competicion.Nombre) && ap.Equipo.Equipo.Nombre.Equals(temporadaPartidoDTO.EquipoB.Nombre) && ap.Jornada.NumeroJornada.Equals(temporadaPartidoDTO.Jornada.NumeroJornada),
                    ap => ap.Jugador, ap => ap.Club, ap => ap.Puesto).ConfigureAwait(false);

            List<AlineacionViewModel> alineacionEquipoA = _mapper.Map<List<AlineacionDTO>, List<AlineacionViewModel>>(aliactualA.ToList());
            List<AlineacionViewModel> alineacionEquipoB = _mapper.Map<List<AlineacionDTO>, List<AlineacionViewModel>>(aliactualB.ToList());


            TemporadaCompeticionJornadaDTO jornadaComp = await _temporadaCompeticionJornadaRepository.GetJornada(temporadaPartidoDTO.Temporada.Id, temporadaPartidoDTO.CompeticionId, temporadaPartidoDTO.Jornada.NumeroJornada).ConfigureAwait(false);
            ICollection<TemporadaJornadaJugadorDTO> goleadores = await _temporadaJornadaJugadorRepository.GetGoleadores(jornadaComp).ConfigureAwait(false);
            ICollection<TemporadaJornadaJugadorDTO> infoJugadoresA = await _temporadaJornadaJugadorRepository.GetInfoJugadoresJornada(jornadaComp, aliactualA.Select(a => a.Jugador.Nombre).ToList()).ConfigureAwait(false);
            ICollection<TemporadaJornadaJugadorDTO> infoJugadoresB = await _temporadaJornadaJugadorRepository.GetInfoJugadoresJornada(jornadaComp, aliactualB.Select(a => a.Jugador.Nombre).ToList()).ConfigureAwait(false);

            LigamaniaUtils.CheckJugadoresAlineacion(alineacionEquipoA, null, goleadores, null, null, null, infoJugadoresA);
            LigamaniaUtils.CheckJugadoresAlineacion(alineacionEquipoB, null, goleadores, null, null, null, infoJugadoresB);

            InfoPartidoRonda info = new InfoPartidoRonda {
                AlineacionEquipoA = alineacionEquipoA,
                AlineacionEquipoB = alineacionEquipoB
                //Goleadores = goleadores,
                //InfoJugadoresEquipoA = infoJugadoresA,
                //InfoJugadoresEquipoB = infoJugadoresB
            };
            return info;
        }

        //public async Task<Response> ResetearCompeticion(TemporadaCompeticionViewModel competicionPC)
        //{
        //    try
        //    {
        //        Temporada_DTO temporada = await _temporadaRepository.GetActualAsync();
        //        if (temporada == null)
        //            return new Response { Message = "No existe temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

        //        TemporadaCompeticion_DTO temporadaCompeticion = await GetTemporadaCompeticion(temporada, competicionPC);
        //        if (temporadaCompeticion == null)
        //            return new Response { Message = "No existe la competición en la temporada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

        //        TemporadaCompeticionJornada_DTO jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaActual(temporadaCompeticion.Competicion.Id, temporada.Nombre);
        //        if (jornadaActual == null)
        //            return new Response { Message = "No existe jornada actual. No se pueden abrir alineaciones", Result = false, Status = EResponseStatus.Warning };

        //        // Eliminar todos los registros de TemporadaJornadaJugador de las jornadas de la competicion elegida
        //        var temJorJug = await _temporadaJornadaJugadorRepository.FindAllAsync(
        //            tjj => tjj.Temporada.Actual && tjj.Jornada.CompeticionId.Equals(temporadaCompeticion.CompeticionId));
        //        await _temporadaJornadaJugadorRepository.DeleteRangeAsyn(temJorJug);

        //        // TemporadaCompeticionJornada, desmarcar jornada carrusel y jornada actual
        //        var temCompJor = await _temporadaCompeticionJornadaRepository.FindAllAsync(
        //            tcj => tcj.Temporada.Actual && tcj.CompeticionId.Equals(temporadaCompeticion.CompeticionId));
        //        foreach(var temcom in temCompJor)
        //        {
        //            temcom.Actual = false;
        //            temcom.Carrusel = false;
        //            await _temporadaCompeticionJornadaRepository.UpdateAsyn(temcom, temcom.Id);
        //        }

        //        // TemporadaJugador, eliminado, preeliminado, veceseliminado, vecespreeliminado, lastjornadaeliminacion
        //        if (temporadaCompeticion.Competicion.EsLiga)
        //        {
        //            var temjug = await _temporadaJugadorRepository.FindAllAsync(tj => tj.Temporada.Actual && tj.Activo
        //                  && (tj.VecesEliminado > 0 || tj.VecesPreEliminado > 0 || tj.LastJornadaEliminacion != null || tj.PreEliminado || tj.Eliminado));
        //            foreach(var jug in temjug)
        //            {
        //                jug.VecesPreEliminado = 0;
        //                jug.VecesEliminado = 0;
        //                jug.LastJornadaEliminacion = null;
        //                jug.PreEliminado = false;
        //                jug.Eliminado = false;
        //                await _temporadaJugadorRepository.UpdateAsyn(jug, jug.Id);
        //            }
        //        }
        //        // TemporadaCompeticion, estadoActual, operacionActual y descripcion estado
        //        var estado = await _estadoCompeticionRepository.FindAsync(e => e.Estado.Equals(LigamaniaConst.Estado_Jornada_Inicial));
        //        var operacion = await _operacionCompeticionRepository.FindAsync(o => o.Operacion.Equals(LigamaniaConst.Operacion_Inicial));
        //        temporadaCompeticion.EstadoActual = estado;
        //        temporadaCompeticion.OperacionActual = operacion;
        //        temporadaCompeticion.DescripcionEstado = string.Empty;
        //        await _temporadaCompeticionRepository.UpdateAsyn(temporadaCompeticion, temporadaCompeticion.Id);

        //        await _temporadaCompeticionRepository.SaveAsync();

        //        return new Response { Message = "Competición "+competicionPC.Competicion+" RESETEADA", Result = true, Status = EResponseStatus.Success };
        //    }
        //    catch (Exception x)
        //    {
        //        _logger.LogError(x.Message);
        //        return new Response { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
        //    }
        //}
        #endregion

        #region Métodos auxiliares del panel de control
        private async Task RevisarEquipos(TemporadaCompeticionDTO temporadaCompeticion)
        {
            var temporadaEquipos = await _temporadaEquipoRepository.GetEquiposCompeticion(temporadaCompeticion).ConfigureAwait(false);
            foreach (var tempEqui in temporadaEquipos)
            {
                if (tempEqui.AlineacionLibre)
                {
                    tempEqui.AlineacionLibre = false;
                    await _temporadaEquipoRepository.UpdateAsyn(tempEqui, tempEqui.Id).ConfigureAwait(false);
                }
            }
            await _temporadaEquipoRepository.SaveAsync().ConfigureAwait(false);
        }

        private async Task<TemporadaCompeticionDTO> GetTemporadaCompeticion(TemporadaDTO temporada, TemporadaCompeticionViewModel competicionPC)
        {
            var tempcomp = await _temporadaCompeticionRepository
                    .FindIncludingAsync(tc => tc.TemporadaId.Equals(temporada.Id) && tc.Competicion.Nombre.Equals(competicionPC.Competicion),
                    tc => tc.Competicion, tc => tc.EstadoActual, tc => tc.OperacionActual).ConfigureAwait(false);
            return tempcomp;
        }
        private async Task<TemporadaCompeticionDTO> GetTemporadaCompeticion(TemporadaDTO temporada, int idcompeticion)
        {
            var tempcomp = await _temporadaCompeticionRepository
                    .FindIncludingAsync(tc => tc.TemporadaId.Equals(temporada.Id) && tc.CompeticionId.Equals(idcompeticion),
                    tc => tc.Competicion, tc => tc.EstadoActual, tc => tc.OperacionActual).ConfigureAwait(false);
            return tempcomp;
        }
        private async Task<TemporadaCompeticionDTO> GetTemporadaCompeticionByName(TemporadaDTO temporada, string competicion)
        {
            var tempcomp = await _temporadaCompeticionRepository
                    .FindIncludingAsync(tc => tc.TemporadaId.Equals(temporada.Id) && tc.Competicion.Nombre.Equals(competicion),
                    tc => tc.Competicion, tc => tc.EstadoActual, tc => tc.OperacionActual).ConfigureAwait(false);
            return tempcomp;
        }
        private async Task<ICollection<TemporadaCompeticionCategoriaDTO>> GetTemporadaCompeticionCategorias(TemporadaDTO temporada, TemporadaCompeticionDTO temporadaCompeticion)
        {
            var tempcompcat = await _temporadaCompeticionCategoriaRepository
                    .FindAllIncludingAsync(tcc => tcc.TemporadaId.Equals(temporada.Id) && tcc.CompeticionId.Equals(temporadaCompeticion.CompeticionId),
                    tc => tc.Competicion, tc => tc.Categoria).ConfigureAwait(false);
            return tempcompcat;
        }

        private async Task NuevoEstadoCompeticion(TemporadaCompeticionDTO temporadaCompeticion, string nuevoEstado, string nuevaOperacion, string descripcion)
        {
            EstadoCompeticionDTO regEstado = await _estadoCompeticionRepository.FindAsync(ec => ec.Estado.Equals(nuevoEstado)).ConfigureAwait(false);
            OperacionCompeticionDTO regOperacion = await _operacionCompeticionRepository.FindAsync(oc => oc.Operacion.Equals(nuevaOperacion)).ConfigureAwait(false);
            await _temporadaCompeticionRepository.SetEstadoActualAsync(temporadaCompeticion, regEstado, regOperacion, descripcion).ConfigureAwait(false);
        }
        private async Task CopiarAlineacionToAlineacionPrevia(ICollection<AlineacionDTO> alineaciones, TemporadaCompeticionDTO compDestino = null, CategoriaDTO catDestino = null)
        {
            var aliPrevias = alineaciones.Select(ali => new AlineacionPreviaDTO
            {
                Temporada = ali.Temporada,
                Competicion = compDestino == null ? ali.Competicion : compDestino.Competicion,
                Categoria = catDestino ?? ali.Categoria,
                Equipo = GetEquipo(compDestino, ali.Equipo),
                Jugador = ali.Jugador,
                Club = ali.Club,
                Puesto = ali.Puesto,
            }).ToList();
            await _alineacionPreviaRepository.AddRangeAsyn(aliPrevias).ConfigureAwait(false);
            await _alineacionPreviaRepository.SaveAsync().ConfigureAwait(false);
        }

        private TemporadaEquipoDTO GetEquipo(TemporadaCompeticionDTO compDestino, TemporadaEquipoDTO equipo)
        {
            if (compDestino == null) return equipo;

            var tempequipo = _temporadaEquipoRepository.Find(te => te.TemporadaId.Equals(compDestino.TemporadaId) && te.CompeticionId.Equals(compDestino.CompeticionId) && te.EquipoId.Equals(equipo.EquipoId));
            return tempequipo;
        }

        private async Task CopiarAlineacionToAlineacionCambio(ICollection<AlineacionDTO> alineaciones, TemporadaCompeticionDTO compDestino = null, CategoriaDTO catDestino = null)
        {
            var aliCambios = alineaciones.Select(ali => new AlineacionCambioDTO
            {
                Temporada = ali.Temporada,
                Competicion = compDestino == null ? ali.Competicion : compDestino.Competicion,
                Categoria = catDestino ?? ali.Categoria,
                Equipo = GetEquipo(compDestino, ali.Equipo),
                Jugador = ali.Jugador,
                Club = ali.Club,
                Puesto = ali.Puesto,
            }).ToList();
            await _alineacionCambiosRepository.AddRangeAsyn(aliCambios).ConfigureAwait(false);
            await _alineacionCambiosRepository.SaveAsync().ConfigureAwait(false);
        }

        private async Task CopiarAlineacionCambioToAlineaciones(TemporadaCompeticionDTO temporadaCompeticion, TemporadaCompeticionJornadaDTO jornada)
        {
            var alineacionesCambios = await _alineacionCambiosRepository.FindAllIncludingAsync(ac => ac.Temporada_ID.Equals(temporadaCompeticion.TemporadaId)
                    && ac.Competicion_ID.Equals(temporadaCompeticion.Competicion.Id), ac => ac.Categoria, ac => ac.Club, ac => ac.Equipo, ac => ac.Jugador, ac => ac.Puesto).ConfigureAwait(false);

            // cogemos las alineaciones que estén completas (con 11 jugadores)
            var alineacionesCambiosCompletas = alineacionesCambios
                .GroupBy(ac => ac.Equipo.Id)
                .Where(grp => grp.ToList().Count == 11);
            //.Select(grp=>grp.ToList());

            List<AlineacionCambioDTO> alineacionesAGuardar = new List<AlineacionCambioDTO>();
            foreach (var equipo in alineacionesCambiosCompletas)
                alineacionesAGuardar.AddRange(equipo);

            var alineaciones = alineacionesAGuardar.Select(ali => new AlineacionDTO
            {
                Temporada = ali.Temporada,
                Competicion = ali.Competicion,
                Categoria = ali.Categoria,
                Equipo = ali.Equipo,
                Jugador = ali.Jugador,
                Club = ali.Club,
                Puesto = ali.Puesto,
                Jornada = jornada
            });
            await _alineacionRepository.AddRangeAsyn(alineaciones.ToList()).ConfigureAwait(false);
            await _alineacionRepository.SaveAsync().ConfigureAwait(false);
        }

        private async Task LimpiarTablaAliCambios(TemporadaDTO temporada, TemporadaCompeticionDTO temporadaCompeticion)
        {
            var alineacionesToClean = await _alineacionCambiosRepository.FindAllAsync(ac => ac.Temporada_ID.Equals(temporada.Id)
                && ac.Competicion_ID.Equals(temporadaCompeticion.Competicion.Id)).ConfigureAwait(false);
            await _alineacionCambiosRepository.DeleteRangeAsyn(alineacionesToClean).ConfigureAwait(false);
            await _alineacionCambiosRepository.SaveAsync().ConfigureAwait(false);
        }

        private async Task LimpiarTablaAliPrevia(TemporadaDTO temporada, TemporadaCompeticionDTO temporadaCompeticion)
        {
            var alineacionesToClean = await _alineacionPreviaRepository.FindAllAsync(ac => ac.Temporada_ID.Equals(temporada.Id)
                && ac.Competicion_ID.Equals(temporadaCompeticion.Competicion.Id)).ConfigureAwait(false);
            await _alineacionPreviaRepository.DeleteRangeAsyn(alineacionesToClean).ConfigureAwait(false);
            await _alineacionPreviaRepository.SaveAsync().ConfigureAwait(false);
        }

        private async Task ActualizaClasificacionEquipo(TemporadaEquipoDTO equipo, TemporadaDTO temporada, TemporadaDTO temporadaClasificacion, TemporadaCompeticionDTO temporadaCompeticion, TemporadaCompeticionJornadaDTO jornadaCarrusel)
        {
            var clasificacion = await _temporadaClasificacionRepository.FindAsync(tc => tc.TemporadaId.Equals(temporada.Id)
                && tc.CompeticionId.Equals(temporadaCompeticion.CompeticionId) && tc.CategoriaId.Equals(equipo.CategoriaId)
                && tc.EquipoId.Equals(equipo.EquipoId) && tc.JornadaId.Equals(jornadaCarrusel.Id)).ConfigureAwait(false);

            if (clasificacion == null)
            {
                TemporadaClasificacionDTO newClasificacionEquipo = new TemporadaClasificacionDTO
                {
                    Temporada = temporadaClasificacion,
                    Competicion = temporadaCompeticion.Competicion,
                    Categoria = equipo.Categoria,
                    Equipo = equipo.Equipo,
                    Jornada = jornadaCarrusel,

                    Diferencia = equipo.Diferencia,
                    Empatados = equipo.PartidosEmpatados,
                    Ganados = equipo.PartidosGanados,
                    GolesContra = equipo.GolesContra,
                    GolesFavor = equipo.GolesFavor,
                    GolesExtraFavor = equipo.GolesExtraFavor,
                    GolesExtraContra = equipo.GolesExtraContra,
                    Jugados = equipo.PartidosJugados,
                    Perdidos = equipo.PartidosPerdidos,
                    Puntos = equipo.Puntos,

                    FechaIns = DateTime.Now
                };
                await _temporadaClasificacionRepository.AddAsyn(newClasificacionEquipo).ConfigureAwait(false);
            }
            else
            {
                clasificacion.Diferencia = equipo.Diferencia;
                clasificacion.Empatados = equipo.PartidosEmpatados;
                clasificacion.Ganados = equipo.PartidosGanados;
                clasificacion.GolesContra = equipo.GolesContra;
                clasificacion.GolesFavor = equipo.GolesFavor;
                clasificacion.GolesExtraContra = equipo.GolesExtraContra;
                clasificacion.GolesExtraFavor = equipo.GolesExtraFavor;
                clasificacion.Jugados = equipo.PartidosJugados;
                clasificacion.Perdidos = equipo.PartidosPerdidos;
                clasificacion.Puntos = equipo.Puntos;
                await _temporadaClasificacionRepository.UpdateAsyn(clasificacion, clasificacion.Id).ConfigureAwait(false);
            }
        }

        private async Task<ICollection<JugadoresAlineadosCategoriaViewModel>> GetJugadoresAlineadosPorCategoria(TemporadaCompeticionDTO temporadaCompeticion, TemporadaCompeticionJornadaDTO jornadaActual)
        {
            ICollection<JugadoresAlineadosCategoriaViewModel> jugadoresAlineadosPorCategoria = new List<JugadoresAlineadosCategoriaViewModel>();
            //var categorias = temporadaCompeticion.Competicion.CompeticionCategoria;
            var categorias = await GetTemporadaCompeticionCategorias(temporadaCompeticion.Temporada, temporadaCompeticion).ConfigureAwait(false);

            foreach (var categoria in categorias)
            {
                var jugadoresAlineados = await _alineacionRepository.FindAllIncludingAsync(a => a.Temporada_ID.Equals(temporadaCompeticion.TemporadaId)
                    && a.Competicion_ID.Equals(temporadaCompeticion.CompeticionId) && a.Categoria_ID.Equals(categoria.CategoriaId) && a.Jornada_ID.Equals(jornadaActual.Id),
                    a => a.Jugador).ConfigureAwait(false);
                JugadoresAlineadosCategoriaViewModel jugadoresAlineadosCategoriaVm = new JugadoresAlineadosCategoriaViewModel
                {
                    Categoria = categoria.Categoria.Nombre,
                    Jugadores = new Dictionary<string, int>()
                };

                var listaJugadores = jugadoresAlineados.GroupBy(ja => ja.Jugador.Nombre).Select(grp => grp.First()).Select(j => j.Jugador.Nombre);
                foreach (var jugador in listaJugadores)
                {
                    var cantidad = jugadoresAlineados.Count(a => a.Jugador.Nombre.Equals(jugador));
                    jugadoresAlineadosCategoriaVm.Jugadores.Add(jugador, cantidad);
                }
                jugadoresAlineadosPorCategoria.Add(jugadoresAlineadosCategoriaVm);
            }
            return jugadoresAlineadosPorCategoria;
        }

        private async Task ActualizarResultadoPartido(TemporadaPartidoDTO partido, TemporadaCompeticionJornadaDTO jornada, ICollection<TemporadaJornadaJugadorDTO> goleadores)
        {
            TemporadaEquipoDTO temporadaEquipoA = await _temporadaEquipoRepository.GetEquipoTemporada(partido.TemporadaId, partido.CompeticionId, partido.CategoriaId, partido.EquipoAId).ConfigureAwait(false);
            TemporadaEquipoDTO temporadaEquipoB = await _temporadaEquipoRepository.GetEquipoTemporada(partido.TemporadaId, partido.CompeticionId, partido.CategoriaId, partido.EquipoBId).ConfigureAwait(false);

            ICollection<AlineacionDTO> alineacionEquipoA = await _alineacionRepository.GetAlineacionesEquipo(jornada, temporadaEquipoA.Id).ConfigureAwait(false);
            ICollection<AlineacionDTO> alineacionEquipoB = await _alineacionRepository.GetAlineacionesEquipo(jornada, temporadaEquipoB.Id).ConfigureAwait(false);

            TemporadaClasificacionDTO clasificacionEquipoA = new TemporadaClasificacionDTO();
            TemporadaClasificacionDTO clasificacionEquipoB = new TemporadaClasificacionDTO();
            if (jornada.NumeroJornada > 1) // partimos de la clasificación de la jornada anterior
            {
                TemporadaCompeticionJornadaDTO jornadaPrevia = await _temporadaCompeticionJornadaRepository.GetJornada(jornada.TemporadaId, jornada.CompeticionId, jornada.NumeroJornada - 1).ConfigureAwait(false);
                clasificacionEquipoA = await _temporadaClasificacionRepository.FindAsync(tc => tc.JornadaId.Equals(jornadaPrevia.Id) && tc.EquipoId.Equals(partido.EquipoAId)).ConfigureAwait(false);
                clasificacionEquipoB = await _temporadaClasificacionRepository.FindAsync(tc => tc.JornadaId.Equals(jornadaPrevia.Id) && tc.EquipoId.Equals(partido.EquipoBId)).ConfigureAwait(false);
            }
            var resultado = LigamaniaUtils.ResultadoPartido(clasificacionEquipoA, clasificacionEquipoB, alineacionEquipoA, alineacionEquipoB, goleadores);
            await ActualizaTemporadaEquipoResultado(jornada.TemporadaId, jornada.CompeticionId, partido.EquipoA, resultado.Item2, resultado.Item1.puntos1, resultado.Item1.dif1).ConfigureAwait(false);
            await ActualizaTemporadaEquipoResultado(jornada.TemporadaId, jornada.CompeticionId, partido.EquipoB, resultado.Item3, resultado.Item1.puntos2, resultado.Item1.dif2).ConfigureAwait(false);

            partido.ResultadoA = resultado.Item1.p1;
            partido.ResultadoB = resultado.Item1.p2;
            if (resultado.Item1.p1 > resultado.Item1.p2) partido.EquipoGanador = partido.EquipoA;
            if (resultado.Item1.p2 > resultado.Item1.p1) partido.EquipoGanador = partido.EquipoB;
        }

        private async Task ActualizaTemporadaEquipoResultado(int temporadaId, int competicionId, EquipoDTO equipo, TemporadaClasificacionDTO newClasificacion, int resultadoPartido, int dif)
        {
            TemporadaEquipoDTO temporadaEquipo = await _temporadaEquipoRepository.FindAsync(te => te.TemporadaId.Equals(temporadaId)
                && te.CompeticionId.Equals(competicionId) && te.EquipoId.Equals(equipo.Id) && !te.Baja).ConfigureAwait(false);
            temporadaEquipo.PartidosJugados = newClasificacion.Jugados;
            temporadaEquipo.PartidosGanados = newClasificacion.Ganados;
            temporadaEquipo.PartidosEmpatados = newClasificacion.Empatados;
            temporadaEquipo.PartidosPerdidos = newClasificacion.Perdidos;
            temporadaEquipo.GolesFavor = newClasificacion.GolesFavor;
            temporadaEquipo.GolesContra = newClasificacion.GolesContra;
            temporadaEquipo.GolesExtraFavor = newClasificacion.GolesExtraFavor;
            temporadaEquipo.GolesExtraContra = newClasificacion.GolesExtraContra;
            temporadaEquipo.Puntos = resultadoPartido;
            temporadaEquipo.Diferencia = dif;
            await _temporadaEquipoRepository.UpdateAsyn(temporadaEquipo, temporadaEquipo.Id).ConfigureAwait(false);
        }

        #endregion

        #region Goleadores
        public async Task<GoleadoresViewModel> GetGoleadores(string club, DateTime fecha)
        {
            //ICollection<TemporadaCompeticionViewModel> competicionesActivas = await GetCompeticionesActivas().ConfigureAwait(false);
            //ICollection<TemporadaCompeticionJornadaDTO> jornadas;
            //if (fecha.Equals(DateTime.MinValue))
            //{
            //    jornadas = await GetJornadasActivas(competicionesActivas).ConfigureAwait(false);
            //}
            //else
            //    jornadas = await GetJornadasFecha(competicionesActivas, fecha).ConfigureAwait(false);
            Tuple<Dictionary<string, int>, List<TemporadaCompeticionJornadaDTO>> compJorActivasEnJuego =
                await GetCompeticionesJornadasActivasEnJuego(fecha).ConfigureAwait(false);

            List<TemporadaCompeticionJornadaDTO> jornadas = compJorActivasEnJuego.Item2;

            ICollection<TemporadaJornadaJugadorViewModel> jugadores = await GetJugadoresClub(club, jornadas).ConfigureAwait(false);
            GoleadoresViewModel goleadores = new GoleadoresViewModel
            {
                Club = club,
                //Jornada = numjornada,
                Fecha = fecha==DateTime.MinValue ? jornadas.First().Fecha:fecha,
                Jugadores = jugadores,
                CompeticionJornada = compJorActivasEnJuego.Item1
            };

            return goleadores;
        }

        private async Task<Tuple<Dictionary<string, int>, List<TemporadaCompeticionJornadaDTO>>> GetCompeticionesJornadasActivasEnJuego(DateTime fecha)
        {
            var tempComp = await _temporadaCompeticionRepository.GetCompeticionesActivas().ConfigureAwait(false);
            ICollection<TemporadaCompeticionViewModel> competicionesActivas = new List<TemporadaCompeticionViewModel>();
            foreach (var tc in tempComp)
                competicionesActivas.Add(await GetTemporadaCompeticion(tc.CompeticionId).ConfigureAwait(false));
            List<TemporadaCompeticionViewModel> competicionesEnJuego;
            List<string> competiciones;

            if (fecha.Equals(DateTime.MinValue))
            {
                competicionesEnJuego = competicionesActivas.Where(ca => ca.EstadoCompeticion.Contains(LigamaniaConst.Operacion_Publicar_Carrusel)).ToList();
                competiciones = competicionesEnJuego.Select(c => c.Competicion).ToList();
            }
            else
            {
                competiciones = competicionesActivas.Select(c => c.Competicion).ToList();
            }
            ICollection<TemporadaCompeticionJornadaDTO> jornadas = new List<TemporadaCompeticionJornadaDTO>();
            if (fecha.Equals(DateTime.MinValue))
                jornadas = await _temporadaCompeticionJornadaRepository.FindAllAsync(
                    tcj => tcj.Temporada.Actual
                            && competiciones.Contains(tcj.Competicion.Nombre)
                            && (tcj.Carrusel && tcj.Actual))
                .ConfigureAwait(false);
            else
                jornadas = await _temporadaCompeticionJornadaRepository.FindAllAsync(
                    tcj => tcj.Temporada.Actual
                            && competiciones.Contains(tcj.Competicion.Nombre)
                            && tcj.Fecha.ToUniversalTime().Equals(fecha.ToUniversalTime()))
                .ConfigureAwait(false);

            Dictionary<string, int> compJor = new Dictionary<string, int>();
            foreach (var jornada in jornadas) compJor.Add(jornada.Competicion.Nombre, jornada.NumeroJornada);

            Tuple<Dictionary<string, int>, List<TemporadaCompeticionJornadaDTO>> tupla =
                new Tuple<Dictionary<string, int>, List<TemporadaCompeticionJornadaDTO>>(compJor,jornadas.ToList());
            return tupla;
        }

        private async Task<ICollection<TemporadaCompeticionJornadaDTO>> GetJornadasFecha(ICollection<TemporadaCompeticionViewModel> competicionesActivas, DateTime fecha)
        {
            var competiciones = competicionesActivas.Select(c => c.Competicion).ToList();
            var jornadas = await _temporadaCompeticionJornadaRepository.FindAllAsync(
                tcj => tcj.Temporada.Actual && competiciones.Contains(tcj.Competicion.Nombre) && tcj.Fecha.ToUniversalTime().Equals(fecha.ToUniversalTime())).ConfigureAwait(false);
            return jornadas;
        }

        private async Task<ICollection<TemporadaCompeticionJornadaDTO>> GetJornadasActivas(ICollection<TemporadaCompeticionViewModel> competicionesActivas)
        {
            var competiciones = competicionesActivas.Select(c => c.Competicion).ToList();
            var jornadas = await _temporadaCompeticionJornadaRepository.FindAllAsync(
                tcj =>  tcj.Temporada.Actual 
                        && competiciones.Contains(tcj.Competicion.Nombre) 
                        && tcj.Carrusel && tcj.Actual)
                .ConfigureAwait(false);
            return jornadas;
        }

        public async Task<Response> ActualizarGoles(GolesJugador goles)
        {
            try
            {
                var fecha = goles.Fecha;
                //ICollection<TemporadaCompeticionViewModel> competicionesActivas = await GetCompeticionesActivas().ConfigureAwait(false);
                //ICollection<TemporadaCompeticionJornadaDTO> jornadas = null;
                //if (fecha.Equals(DateTime.MinValue))
                //{
                //    jornadas = await GetJornadasActivas(competicionesActivas).ConfigureAwait(false);
                //}
                //else
                //    jornadas = await GetJornadasFecha(competicionesActivas, fecha).ConfigureAwait(false);
                Tuple<Dictionary<string, int>, List<TemporadaCompeticionJornadaDTO>> compJorActivasEnJuego =
                    await GetCompeticionesJornadasActivasEnJuego(fecha).ConfigureAwait(false);

                List<TemporadaCompeticionJornadaDTO> jornadas = compJorActivasEnJuego.Item2;

                var temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                foreach (var jornada in jornadas)
                {
                    bool crear = false;
                    TemporadaJornadaJugadorDTO jugador = await _temporadaJornadaJugadorRepository
                        .FindAsync(j => j.Temporada.Actual && j.JornadaId.Equals(jornada.Id) && j.Jugador.Nombre.Equals(goles.Jugador)).ConfigureAwait(false);
                    if (jugador == null)
                    {
                        var jug = await _temporadaJugadorRepository
                            .FindIncludingAsync(j => j.Temporada.Actual && j.Jugador.Nombre.Equals(goles.Jugador) && j.Activo, j => j.Jugador).ConfigureAwait(false);
                        jugador = new TemporadaJornadaJugadorDTO
                        {
                            Jornada = jornada,
                            Temporada = temporada,
                            Jugador = jug.Jugador
                        };
                        crear = true;
                    }
                    if (goles.Favor && goles.Mas) jugador.GolesFavor++;
                    else if (goles.Favor && !goles.Mas) jugador.GolesFavor--;
                    else if (!goles.Favor && goles.Mas) jugador.GolesContra++; 
                    else if (!goles.Favor && !goles.Mas) jugador.GolesContra--;
                    if (crear)
                        await _temporadaJornadaJugadorRepository.AddAsyn(jugador).ConfigureAwait(false);
                    else
                        await _temporadaJornadaJugadorRepository.UpdateAsyn(jugador, jugador.Id).ConfigureAwait(false);
                }
                await _temporadaJornadaJugadorRepository.SaveAsync().ConfigureAwait(false);
                return new Response { Message = "Goles actualizados", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al actualizar goles", Status = EResponseStatus.Error, Result = false };
            }
        }
        private async Task<ICollection<TemporadaJornadaJugadorViewModel>> GetJugadoresClub(string club, ICollection<TemporadaCompeticionJornadaDTO> jornadas)
        {
            try
            {
                var idJornadas = jornadas.Select(j => j.Id).ToList();

                var temporadajugadores = await _temporadaJugadorRepository.FindAllIncludingAsync(tj => tj.Temporada.Actual && tj.Club.Nombre.Equals(club) && tj.Activo,
                    tj => tj.Jugador, tj => tj.Puesto, tj => tj.Club).ConfigureAwait(false);
                var temporadajornadajugadores = await _temporadaJornadaJugadorRepository.FindAllIncludingAsync
                    (tjj => tjj.Temporada.Actual && idJornadas.Contains(tjj.JornadaId), tjj => tjj.Jugador).ConfigureAwait(false);
                temporadajornadajugadores = temporadajornadajugadores.GroupBy(j => j.Jugador.Nombre).Select(grp => grp.FirstOrDefault()).ToList();

                IEnumerable<TemporadaJornadaJugadorViewModel> union = temporadajugadores
                    .GroupJoin(temporadajornadajugadores, p => p.Jugador_ID, c => c.JugadorId,
                    (p, c) => new { p, c }).SelectMany(x => x.c.DefaultIfEmpty(), (x, c) => new TemporadaJornadaJugadorViewModel
                    {
                        Activo = x.p.Activo,
                        Club = x.p.Club.Nombre,
                        ClubActivo = !x.p.Club.Baja,
                        Eliminado = x.p?.Eliminado,
                        GolesContra = c?.GolesContra,
                        GolesFavor = c?.GolesFavor,
                        IdJugador = x.p.Jugador.Id,
                        IdTemporadaJornadaJugador = c?.Id,
                        Jugador = x.p.Jugador.Nombre,
                        Puesto = x.p.Puesto.Nombre,
                        OrdenPuesto = x.p.Puesto.Orden
                    });

                List<TemporadaJornadaJugadorViewModel> lista = union.ToList();
                for (int i = 0; i < lista.Count; i++)
                    lista[i].VecesPorCompeticionCategoria = await GetVecesAlineado(jornadas, lista[i].Jugador).ConfigureAwait(false);

                return lista;
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return null;
            }
        }

        private async Task<Dictionary<string, int>> GetVecesAlineado(ICollection<TemporadaCompeticionJornadaDTO> jornadas, string jugador)
        {
            var idJornadas = jornadas.Select(j => j.Id).ToList();


            ICollection<AlineacionDTO> jugadoresAlineadosJornada = await _alineacionRepository
                .FindAllIncludingAsync(a => a.Temporada.Actual && idJornadas.Contains(a.Jornada_ID),
                a => a.Competicion, a => a.Categoria, a => a.Jugador, a => a.Club, a => a.Puesto).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(jugador))
                jugadoresAlineadosJornada = jugadoresAlineadosJornada.Where(a => a.Jugador.Nombre.Equals(jugador)).ToList();

            Dictionary<string, int> jugadoresGroupByCompeticionCategoria = jugadoresAlineadosJornada
                .GroupBy(j => new { Competicion = j.Competicion.Nombre, Categoria = j.Categoria.Nombre })
                .ToDictionary(grp => grp.Key.Competicion + "." + grp.Key.Categoria, grp => grp.Count());

            return jugadoresGroupByCompeticionCategoria;
        }

        public async Task<int> GetRondaActiva()
        {
            var infoRonda = await _temporadaRondaRepository
                                    .FindIncludingAsync(tr => tr.Temporada.Actual
                                        && tr.Competicion.Nombre.Equals(LigamaniaConst.Competicion_Copa) && tr.Activa,
                                        tr => tr.JornadaIda, tr => tr.JornadaVuelta).ConfigureAwait(false);

            if (infoRonda != null && infoRonda.Activa)
            {
                return infoRonda.NumRonda;
            }
            return -1;
        }
        public async Task<Response> SetAlineacionLibre(TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                TemporadaDTO temporada = await _temporadaRepository.GetActualAsync().ConfigureAwait(false);
                if (temporada == null)
                    return new Response { Message = "No existe temporada actual. ", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionDTO temporadaCompeticion = await GetTemporadaCompeticion(temporada, competicionPC).ConfigureAwait(false);
                if (temporadaCompeticion == null)
                    return new Response { Message = "No existe la competición en la temporada actual. ", Result = false, Status = EResponseStatus.Warning };

                TemporadaCompeticionJornadaDTO jornadaActual = await _temporadaCompeticionJornadaRepository.GetJornadaActual(temporadaCompeticion.Competicion.Id, temporada.Nombre).ConfigureAwait(false);
                if (jornadaActual == null)
                    return new Response { Message = "No existe jornada actual. ", Result = false, Status = EResponseStatus.Warning };

                // Obtener todos los equipos activos en la competición
                ICollection<TemporadaEquipoDTO> equipos = await _temporadaEquipoRepository.FindAllIncludingAsync(te => te.TemporadaId.Equals(temporada.Id)
                     && te.CompeticionId.Equals(temporadaCompeticion.CompeticionId) && !te.Baja, te => te.Equipo, te => te.Categoria).ConfigureAwait(false);

                jornadaActual.AlineacionLibre = !jornadaActual.AlineacionLibre;
                foreach (var equipo in equipos)
                {
                    // Asignar AlineacionLibre al valor que viene por parámetro en competicionPC.AlineacionLibre
                    equipo.AlineacionLibre = jornadaActual.AlineacionLibre;
                    await _temporadaEquipoRepository.UpdateAsyn(equipo, equipo.Id).ConfigureAwait(false);
                }
                await _temporadaCompeticionJornadaRepository.UpdateAsyn(jornadaActual, jornadaActual.Id);

                await _temporadaEquipoRepository.SaveAsync();

                return new Response { Message = "Operación realizada con éxito", Result = true, Status = EResponseStatus.Success };
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return new Response { Message = "Error al realizar la operación", Status = EResponseStatus.Error, Result = false };
            }
        }
        //private async Task<TemporadaCompeticionDTO> GetCompeticionLiga()   // de la temporada actual
        //{
        //    var temporadaCompeticion = await _temporadaCompeticionRepository
        //        .FindAsync(tc => tc.Temporada.Actual && tc.Activa && tc.Competicion.Nombre.Equals(LigamaniaConst.Competicion_Liga)).ConfigureAwait(false);
        //    if (temporadaCompeticion == null)
        //        temporadaCompeticion = await _temporadaCompeticionRepository
        //        .FindAsync(tc => tc.Temporada.Actual && tc.Activa && tc.Competicion.Nombre.Equals(LigamaniaConst.Competicion_Pretemporada)).ConfigureAwait(false);
        //    return temporadaCompeticion;
        //}
        #endregion
    }
}

