using AutoMapper;
using LigamaniaCoreApp.Data;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.AdminViewModels;
using LigamaniaCoreApp.Models.ManagerViewModels;
using LigamaniaCoreApp.Services;
using LigamaniaCoreApp.Services.Interfaces;
using LigamaniaCoreApp.Utils;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ADMINTController : BaseController
    {
        private readonly IManagerService _managerService;
        //private readonly ILigamaniaService _ligamaniaService;
        //private readonly IAdministradorService _administradorService;
        private readonly IPanelControlService _panelControlService;
        //private readonly IMapper _mapper;

        public readonly ILogger _logger;
        public ADMINTController(
            //IAdministradorService administradorService,
            IManagerService managerService
            //, ILigamaniaService ligamaniaService
            , IPanelControlService panelControlService
            , ILogger<ADMINTController> logger
            //, IMapper mapper
            )
        {
            _logger = logger;
            //_mapper = mapper;
            //_administradorService = administradorService;
            _managerService = managerService;
            //_ligamaniaService = ligamaniaService;
            _panelControlService = panelControlService;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region Panel de Control
        public async Task<IActionResult> PanelControl()
        {
            TemporadaDTO temporada = await _managerService.GetTemporadaActual().ConfigureAwait(false);
            TemporadaViewModel temporadaVM = await _managerService.GetTemporadaViewModelActual().ConfigureAwait(false);

            List<CompeticionCategoriaViewModel> allCompeticiones = await _managerService.GetAllCompeticiones().ConfigureAwait(false);
            //List<TemporadaCompeticionCategoriaViewModel> competicionesActivas = await _managerService.GetCompeticionesActivas(temporada);
            ICollection<TemporadaCompeticionViewModel> competicionesActivas = await _panelControlService.GetCompeticionesActivas().ConfigureAwait(false);
            //List<TemporadaCompeticionViewModel> competicionesActivas = _mapper.Map<List<TemporadaCompeticion_DTO>, List<TemporadaCompeticionViewModel>>(tempCompActivas.ToList());

            PreparacionTemporadaViewModel vm = new PreparacionTemporadaViewModel
            {
                Temporada = temporadaVM,
                AllCompeticiones = allCompeticiones!=null? allCompeticiones.OrderBy(c => c.OrdenCompeticion).ThenBy(c => c.OrdenCategoria).ToList() : new List<CompeticionCategoriaViewModel>(),
                CompeticionesActivas = competicionesActivas!=null? competicionesActivas.OrderBy(c => c.OrdenCompeticion).ToList(): new List<TemporadaCompeticionViewModel>()
            };

            return View(vm);
        }
        public async Task<IActionResult> PanelControlCompeticion(int idCompeticion, string competicion)
        {
            PanelControlCompeticionViewModel vm = new PanelControlCompeticionViewModel
            {
                Competicion = competicion
            };
            TemporadaCompeticionViewModel competicionVm = null;
            if (idCompeticion==0)
                competicionVm = await _panelControlService.GetTemporadaCompeticionByNombre(competicion).ConfigureAwait(false);
            else
                competicionVm = await _panelControlService.GetTemporadaCompeticion(idCompeticion).ConfigureAwait(false);
    
            if (competicionVm.TipoCompeticion == Data.LigamaniaEnum.eTipoCompeticion.Liga)
                return View("PanelControlCompeticionLiga", competicionVm);
            else if (competicionVm.TipoCompeticion == Data.LigamaniaEnum.eTipoCompeticion.Supercopa)
                return View("PanelControlCompeticionSupercopa", competicionVm);
            else if (competicionVm.TipoCompeticion == Data.LigamaniaEnum.eTipoCompeticion.Copa)
                return View("PanelControlCompeticionCopa", competicionVm);

            return View(competicionVm);
        }
        public async Task<IActionResult> AbrirAlineaciones([FromBody] TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                Response response = await _panelControlService.AbrirAlineaciones(competicionPC).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[AbrirAlineaciones] " + x);
                return Json("Error al abrir alineaciones");
            }
        }
        public async Task<IActionResult> CerrarAlineaciones([FromBody] TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                Response response = await _panelControlService.CerrarAlineaciones(competicionPC).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[CerrarAlineaciones] " + x);
                return Json("Error al cerrar alineaciones");
            }
        }
        public async Task<IActionResult> CalcularPreeliminados([FromBody] TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                Response response = await _panelControlService.CalcularPreeliminados(competicionPC).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[CalcularPreeliminados] " + x);
                return Json("Error al Calcular Preeliminados");
            }
        }
        public async Task<IActionResult> PublicarCarrusel([FromBody] TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                Response response = await _panelControlService.PublicarCarrusel(competicionPC).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[PublicarCarrusel] " + x);
                return Json("Error al Publicar Carrusel");
            }
        }
        public async Task<IActionResult> CalcularResultados([FromBody] TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                Response response = await _panelControlService.CalcularResultados(competicionPC).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[CalcularResultados] " + x);
                return Json("Error al Calcular Resultados");
            }
        }
        public async Task<IActionResult> ActualizarClasificacion([FromBody] TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                Response response = await _panelControlService.ActualizarClasificacion(competicionPC).ConfigureAwait(false);
                if (competicionPC.Competicion.Equals(LigamaniaConst.Competicion_Copa))
                    await _managerService.EstablecerEquiposCopa(new PreparacionTemporadaViewModel { CompeticionDestino = competicionPC.Competicion }).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[ActualizarClasificacion] " + x);
                return Json("Error al Actualizar Clasificacion");
            }
        }
        public async Task<IActionResult> ActualizarEliminados([FromBody] TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                Response response = await _panelControlService.ActualizarEliminados(competicionPC).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[ActualizarEliminados] " + x);
                return Json("Error al Actualizar Eliminados");
            }
        }
        public async Task<IActionResult> RescatarEliminados([FromBody] TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                Response response = await _panelControlService.RescatarEliminados(competicionPC).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[RescatarEliminados] " + x);
                return Json("Error al Rescatar Eliminados");
            }
        }
        public async Task<IActionResult> CambiarJornada([FromBody] TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                Response response = await _panelControlService.CambiarJornada(competicionPC).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[CambiarJornada] " + x);
                return Json("Error al Cambiar Jornada");
            }
        }
        public async Task<IActionResult> AbrirCambios([FromBody] TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                Response response = await _panelControlService.AbrirCambios(competicionPC).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[AbrirCambios] " + x);
                return Json("Error al Abrir Cambios");
            }
        }
        public async Task<IActionResult> CerrarCambios([FromBody] TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                Response response = await _panelControlService.CerrarCambios(competicionPC).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[CerrarCambios] " + x);
                return Json("Error al Cerrar Cambios");
            }
        }
        public async Task<IActionResult> CerrarJornada([FromBody] TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                Response response = await _panelControlService.CerrarJornada(competicionPC).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[CerrarJornada] " + x);
                return Json("Error al Cerrar Jornada");
            }
        }
        public async Task<IActionResult> GuardarAlineaciones([FromBody] TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                Response response = await _panelControlService.GuardarAlineaciones(competicionPC).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[GuardarAlineaciones] " + x);
                return Json("Error al Guardar Alineaciones");
            }
        }
        public async Task<IActionResult> SetAlineacionLibre([FromBody] TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                Response response = await _panelControlService.SetAlineacionLibre(competicionPC).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[SetAlineacionLibre] " + x);
                return Json("Error al establecer alineaciones libres");
            }
        }
        public async Task<IActionResult> ActualizarClasificacionForzado([FromBody] TemporadaCompeticionViewModel operacionForzada)
        {
            try
            {
                Response response = await _panelControlService.ActualizarClasificacion(operacionForzada).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[ActualizarClasificacionForzado] " + x);
                return Json("Error al ActualizarClasificacionForzado");
            }
        }

        public async Task<IActionResult> RecalcularClasificacionForzado([FromBody] TemporadaCompeticionViewModel operacionForzada)
        {
            try
            {
                Response response = await _panelControlService.RecalcularResultados(operacionForzada).ConfigureAwait(false);
                response = await _panelControlService.RecalcularClasificacion(operacionForzada).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[ActualizarClasificacionForzado] " + x);
                return Json("Error al ActualizarClasificacionForzado");
            }
        }
        public async Task<IActionResult> ActualizarGolesForzado([FromBody] TemporadaCompeticionViewModel operacionForzada)
        {
            try
            {
                Response response = new Response { Message = "Operación realizada con éxito", Result = true, Status = EResponseStatus.Success };
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[ActualizarClasificacionForzado] " + x);
                return Json("Error al ActualizarClasificacionForzado");
            }
        }

        public async Task<IActionResult> CalcularResultadosForzado([FromBody] TemporadaCompeticionViewModel operacionForzada)
        {
            try
            {
                Response response = await _panelControlService.CalcularResultados(operacionForzada).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[CalcularResultadosForzado] " + x);
                return Json("Error al CalcularResultadosForzado");
            }
        }
        public async Task<IActionResult> ActualizarEliminadosForzado([FromBody] TemporadaCompeticionViewModel operacionForzada)
        {
            try
            {
                Response response = await _panelControlService.ActualizarEliminados(operacionForzada).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[ActualizarEliminadosForzado] " + x);
                return Json("Error al ActualizarEliminadosForzado");
            }
        }
        public async Task<IActionResult> RescatarEliminadosForzado([FromBody] TemporadaCompeticionViewModel operacionForzada)
        {
            try
            {
                Response response = await _panelControlService.RescatarEliminados(operacionForzada).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[RescatarEliminadosForzado] " + x);
                return Json("Error al RescatarEliminadosForzado");
            }
        }
        public async Task<IActionResult> AbrirCambiosForzado([FromBody] TemporadaCompeticionViewModel operacionForzada)
        {
            try
            {
                Response response = await _panelControlService.AbrirCambiosForzado(operacionForzada).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[AbrirCambiosForzado] " + x);
                return Json("Error al AbrirCambiosForzado");
            }
        }
        public async Task<IActionResult> CerrarCambiosForzado([FromBody] TemporadaCompeticionViewModel operacionForzada)
        {
            try
            {
                Response response = await _panelControlService.CerrarCambios(operacionForzada).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[CerrarCambiosForzado] " + x);
                return Json("Error al CerrarCambiosForzado");
            }
        }

        public async Task<IActionResult> ActivarRondaCopa([FromBody] TemporadaCompeticionViewModel competicionPC)
        {
            try
            {
                Response response = await _panelControlService.ActivarRondaCopa(competicionPC).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[ActivarRondaCopa] " + x);
                return Json("Error al ActivarRondaCopa");
            }
        }
        public async Task<IActionResult> AgregarPartidosCopa([FromBody] PreparacionTemporadaViewModel competicion)
        {
            try
            {
                //if (competicion.CompeticionDestino.Equals(LigamaniaConst.Competicion_Copa))
                await _managerService.EstablecerEquiposCopa(competicion).ConfigureAwait(false);

                Response response = await _managerService.AgregarPartidosCopa(competicion).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[AgregarPartidosCopa] " + x);
                return Json("Error al AgregarPartidosCopa");
            }
        }
        public async Task<IActionResult> EstablecerGanadoresPartidosCopa([FromBody] TemporadaCompeticionViewModel competicion)
        {
            try
            {
                Response response = await _panelControlService.EstablecerGanadoresPartidosCopa(competicion).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[AgregarPartidosCopa] " + x);
                return Json("Error al AgregarPartidosCopa");
            }
        }

        public async Task<IActionResult> GanadoresPartidosCopa([FromForm] TemporadaCompeticionViewModel competicion)
        {
            //return Json(new
            //    {
            //        newUrl = Url.Action("GanadoresPartidosCopa", "ADMINT") //Payment as Action; Process as Controller
            //    }
            //);

            var responseRondaPartidosSinGanador = await _panelControlService.GetPartidosRondaSinGanador().ConfigureAwait(false);
            if (responseRondaPartidosSinGanador.Result)
            {
                return View(responseRondaPartidosSinGanador.ResultDTO);
            }
            return RedirectToAction("PanelControl");
        }
        //public async Task<IActionResult> SetGanadorPartidoRonda([FromBody] TemporadaPartidoRondaViewModel partido)
        //{
        //    //TemporadaPartidoRondaViewModel partidoRonda = await _panelControlService.GetPartidoRonda(partido.Id).ConfigureAwait(false);
        //    return Json(new { partido = partido });
        //    //return View("_SetGanadorPartidoRonda", partidoRonda);
        //    //return Json(new
        //    //    {
        //    //        newUrl = Url.Action("_SetGanadorPartidoRonda", "ADMINT", partidoRonda)
        //    //    }
        //    //);

        //    //return View("_SetGanadorPartidoRonda", partidoRonda);
        //}
        public async Task<IActionResult> GanadorPartidoCopa(int partidoId)
        {
            TemporadaPartidoRondaViewModel partidoRonda = await _panelControlService.GetPartidoRonda(partidoId).ConfigureAwait(false);
            return View(partidoRonda);
        }
        public async Task<IActionResult> EditarJugador([FromBody] AlineacionViewModel jugador)
        {
            try
            {
                if (jugador.NumeroJornada==0)
                {
                    return Json(new Response { Message = "No se especificó la jornada", Result = false, Status = EResponseStatus.Warning });
                }
                Response response = await _panelControlService.EditarJugador(jugador).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[EditarJugador] " + x);
                return Json("Error al EditarJugador");
            }
        }
        
        public async Task<IActionResult> SetCriterioGanadorPartido([FromBody] TemporadaPartidoRondaViewModel infoRonda)
        {
            try
            {
                Response response = await _panelControlService.SetCriterioGanadorPartido(infoRonda).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[SetCriterioGanadorPartido] " + x);
                return Json("Error al SetCriterioGanadorPartido");
            }
        }
        public async Task<IActionResult> SetGanadorPartidoManual([FromBody] TemporadaPartidoRondaViewModel infoRonda)
        {
            try
            {
                Response response = await _panelControlService.SetGanadorPartidoManual(infoRonda).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[SetGanadorPartidoManual] " + x);
                return Json("Error al SetGanadorPartidoManual");
            }
        }
        public async Task<IActionResult> Prueba([FromBody] TemporadaCompeticionViewModel competicionPC)
        {
            for (int i = 0; i < 100; i++)
                System.Threading.Thread.SpinWait(100);

            return Json(new Response { Message = "PRUEBA REALIZADA CON ÉXITO", Result = true, Status = EResponseStatus.Success });
        }
        //[Authorize(Roles = "Manager")]
        //public async Task<IActionResult> ResetearCompeticion([FromBody] TemporadaCompeticionViewModel competicion)
        //{
        //    try
        //    {
        //        Response response = await _panelControlService.ResetearCompeticion(competicion);
        //        return Json(response);
        //    }
        //    catch (Exception x)
        //    {
        //        _logger.LogError("[ResetearCompeticion] " + x);
        //        return Json("Error al ResetearCompeticion");
        //    }
        //}

        #endregion

        #region Goleadores
        public async Task<IActionResult> Goleadores()
        {
            GoleadoresViewModel goleadoresVm = new GoleadoresViewModel
            {
                Club = string.Empty,
                Fecha = DateTime.MinValue,
                Jugadores = new List<TemporadaJornadaJugadorViewModel>()
            };
            return View();
        }
        public async Task<IActionResult> GoleadoresClubJornada(string club, DateTime fecha)
        {
            try
            {
                GoleadoresViewModel goleadoresVm = await _panelControlService.GetGoleadores(club,fecha).ConfigureAwait(false);
                return View("Goleadores", goleadoresVm);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return View("Goleadores");
            }
        }
        public async Task<IActionResult> GolesJugador([FromBody] GolesJugador goles)
        {
            try
            {
                Response response = await _panelControlService.ActualizarGoles(goles).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[GolesJugador] " + x);
                return Json("Error al actualizar goles");
            }
        }

        public async Task<IActionResult> ActualizarGoles()
        {
            GoleadoresViewModel goleadoresVm = new GoleadoresViewModel
            {
                Club = string.Empty,
                Fecha = DateTime.MinValue,
                Jugadores = new List<TemporadaJornadaJugadorViewModel>()
            };
            return View();
        }
        public async Task<IActionResult> ActualizarGolesClubJornada(string club, DateTime fecha)
        {
            try
            {
                GoleadoresViewModel goleadoresVm = await _panelControlService.GetGoleadores(club, fecha).ConfigureAwait(false);
                return View("ActualizarGoles", goleadoresVm);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message);
                return View("Goleadores");
            }
        }
        public async Task<IActionResult> ActualizarGolesJugador([FromBody] GolesJugador goles)
        {
            try
            {
                Response response = await _panelControlService.ActualizarGoles(goles).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[GolesJugador] " + x);
                return Json("Error al actualizar goles");
            }
        }
        #endregion
    }
}