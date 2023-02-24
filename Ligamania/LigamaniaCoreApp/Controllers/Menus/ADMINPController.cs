using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.AdminViewModels;
using LigamaniaCoreApp.Models.ManagerViewModels;
using LigamaniaCoreApp.Services.Interfaces;
using LigamaniaCoreApp.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using static LigamaniaCoreApp.Data.LigamaniaEnum;

namespace LigamaniaCoreApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ADMINPController : BaseController
    {
        private const string CLUBS_ACTIVOS = "CLUBS ACTIVOS";
        private const string CLUBS_BAJA = "CLUBS BAJA";
        private const string JUGADORES_BAJA = "JUGADORES BAJA";
        private const string FORMAT_CLUBS_ACTIVOS = "CLUBS_ACTIVOS";
        private const string FORMAT_CLUBS_BAJA = "CLUBS_BAJA";
        private const string FORMAT_JUGADORES_BAJA = "JUGADORES_BAJA";
        private readonly IAdministradorService _administradorService;
        private readonly IManagerService _managerService;
        private readonly ILogger<ADMINPController> _logger;
        private readonly IMapper _mapper;

        public ADMINPController(IAdministradorService administradorService
            , IManagerService managerService
            , ILogger<ADMINPController> logger, IMapper mapper)
        {
            _administradorService = administradorService;
            _managerService = managerService;
            _logger = logger;
            _mapper = mapper;
        }
        #region Carga de datos
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Clubs()
        {
            ICollection<ClubViewModel> clubs = await _administradorService.GetClubsViewModel().ConfigureAwait(false);
            return View(clubs);
        }
        public async Task<IActionResult> Jugadores()
        {
            TemporadaViewModel temporadaActual = await _managerService.GetTemporadaViewModelFinalizada().ConfigureAwait(false);
            TemporadaViewModel preTemporada = await _managerService.GetPreTemporadaViewModel().ConfigureAwait(false);
            var temporada = await _managerService.GetTemporadaActual().ConfigureAwait(false);
            if (temporada == null) temporada = await _managerService.GetPreTemporada().ConfigureAwait(false);
            ViewBag.Temporada = temporada.Nombre;
            ViewBag.ActivarMensaje = false;

            var allJugadores = await _administradorService.GetAllJugadoresWithTemporada().ConfigureAwait(false);
            allJugadores = allJugadores.OrderBy(j => j.Jugador).ThenBy(j => j.Temporada).ToList();

            InfoPreparacionTemporadaViewModel viewModel = new InfoPreparacionTemporadaViewModel
            {
                Actual = temporadaActual,
                Pretemporada = preTemporada,
                Jugadores = allJugadores
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<PartialViewResult> JugadoresGrid()
        {
            ICollection<JugadorViewModel> jugadores = await _administradorService.GetJugadoresViewModel().ConfigureAwait(false);
            jugadores = jugadores.OrderBy(j => j.Activo).ThenBy(j => j.Jugador).ToList();
            // Only grid query values will be available here.
            return PartialView("JugadoresGrid", jugadores);
        }
        [HttpGet]
        public async Task<PartialViewResult> TemporadaActualJugadoresGrid()
        {
            TemporadaViewModel temporadaActual = await _managerService.GetTemporadaViewModelFinalizada().ConfigureAwait(false);
            ICollection<TemporadaJugadorViewModel> jugadores = await _administradorService.GetJugadoresViewModelFromTemporada(temporadaActual.Id).ConfigureAwait(false);
            jugadores = jugadores.OrderBy(j=>j.Club).ThenBy(j => j.Activo).ThenBy(j => j.Jugador).ToList();
            // Only grid query values will be available here.
            return PartialView("TemporadaActualJugadoresGrid", jugadores);
        }
        [HttpGet]
        public async Task<PartialViewResult> PretemporadaJugadoresGrid()
        {
            TemporadaViewModel preTemporada = await _managerService.GetPreTemporadaViewModel().ConfigureAwait(false);
            ICollection<TemporadaJugadorViewModel> jugadores = await _administradorService.GetJugadoresViewModelFromTemporada(preTemporada.Id).ConfigureAwait(false);
            jugadores = jugadores.Where(j=>j.Activo).OrderBy(j => j.Club).ThenBy(j => j.Jugador).ToList();
            // Only grid query values will be available here.
            return PartialView("PretemporadaJugadoresGrid", jugadores);
        }
        #endregion
        #region Operaciones
        [HttpPost]
        public async Task<IActionResult> AltaClub([FromBody] ClubViewModel clubInfo)
        {
            try
            {
                ResponseOfTReturn<ClubViewModel> response = await _administradorService.AltaClub(clubInfo.Id).ConfigureAwait(false);
                return Json(response);
            }
            catch(Exception x)
            {
                _logger.LogError("[AltaClub] " + x);
                return Json("Error al intentar hacer un alta de Club" );
            }
        }
        [HttpPost]
        public async Task<IActionResult> BajaClub([FromBody] ClubViewModel clubInfo)
        {
            try
            {
                ResponseOfTReturn<ClubViewModel> response = await _administradorService.BajaClub(clubInfo.Id).ConfigureAwait(false);

                return Json(response);
            }
            catch(Exception x)
            {
                _logger.LogError("[BajaClub] " + x);
                return Json("Error al intentar hacer una baja de Club");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CopiarJugadoresAPretemporada()
        {
            try
            {
                TemporadaDTO temporadaActual = await _managerService.GetTemporadaFinalizada().ConfigureAwait(false);
                TemporadaDTO preTemporada = await _managerService.GetPreTemporada().ConfigureAwait(false);

                Response response = await _administradorService.CopiarJugadoresEntreTemporadas(temporadaActual.Id,preTemporada.Id).ConfigureAwait(false);
                return Json(response);
            }
            catch(Exception x)
            {
                _logger.LogError("[CopiarJugadoresAPretemporada] " + x);
                return Json("Error al copiar jugadores de una temporada a otra");
            }
        }
        [HttpPost]
        public JsonResult CheckNombreJugador([FromBody] string jugadorName)
        {
            eCheckJugadorResponse checkJugadorResponse = _administradorService.CheckNombreJugador(jugadorName);
            return Json(checkJugadorResponse);
        }
        [HttpPost]
        public async Task<IActionResult> NuevoJugador([FromBody] TemporadaJugadorViewModel jugadorInfo)
        {
            try
            {
                TemporadaDTO preTemporada = await _managerService.GetPreTemporada().ConfigureAwait(false);

                Response response = await _administradorService.AltaJugador(jugadorInfo, preTemporada).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[NuevoJugador] " + x);
                return Json("Error al intentar hacer un alta de Jugador: "+x);
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditJugador([FromBody] TemporadaJugadorViewModel jugadorInfo)
        {
            try
            {
                Response response = await _administradorService.EditarJugador(jugadorInfo).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[EditJugador] " + x);
                return Json("Error al intentar hacer un alta de Club");
            }
        }

        [HttpPost]
        public async Task<IActionResult> BorrarJugador([FromBody] JugadorViewModel jugadorInfo)
        {
            try
            {
                Response response = await _administradorService.BorrarJugador(jugadorInfo.IdJugador).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[BorrarJugador] " + x);
                return Json("Error al intentar hacer una baja de Club");
            }
        }
        [HttpPost]
        public async Task<IActionResult> DesactivarJugador([FromBody] TemporadaJugadorViewModel jugadorInfo)
        {
            try
            {
                Response response = await _administradorService.BajaJugador(jugadorInfo.IdJugador).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[DesactivarJugador] " + x);
                return Json("Error al intentar hacer una baja de Club");
            }
        }
        [HttpPost]
        public async Task<IActionResult> BorrarTemporadaJugador([FromBody] TemporadaJugadorViewModel jugadorInfo)
        {
            try
            {
                Response response = await _administradorService.BorrarTemporadaJugador(jugadorInfo.IdTemporadaJugador).ConfigureAwait(false);

                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[BorrarTemporadaJugador] " + x);
                return Json("Error al intentar hacer una baja de Club");
            }
        }
        [HttpPost]
        public async Task<IActionResult> DesactivarTemporadaJugador([FromBody] TemporadaJugadorViewModel jugadorInfo)
        {
            try
            {
                Response response = await _administradorService.BajaTemporadaJugador(jugadorInfo.IdTemporadaJugador).ConfigureAwait(false);

                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[DesactivarTemporadaJugador] " + x);
                return Json("Error al intentar hacer una baja de Club");
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditTemporadaJugador([FromBody] TemporadaJugadorViewModel jugadorInfo)
        {
            try
            {
                Response response = await _administradorService.EditarTemporadaJugador(jugadorInfo).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[EditTemporadaJugador] " + x);
                return Json("Error al intentar hacer un alta de Club");
            }
        }

        [HttpPost]
        public JsonResult CheckNuevoClub([FromBody] ClubViewModel club)
        {
            eCheckClubResponse checkClubResponse = _administradorService.CheckNuevoClub(club);
            return Json(checkClubResponse);
        }
        [HttpPost]
        public async Task<IActionResult> NuevoClub([FromBody] ClubViewModel club)
        {
            try
            {
                Response response = await _administradorService.NuevoClub(club).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[NuevoClub] " + x);
                return Json("Error al intentar hacer un alta de un club: " + x);
            }
        }
        #endregion
        #region Exportación y carga desde Excel
        //[HttpGet]
        //public async Task<IActionResult> TablaJugadores()
        //{
        //    var temporada = await _managerService.GetTemporadaActual().ConfigureAwait(false);
        //    if (temporada == null) temporada = await _managerService.GetPreTemporada().ConfigureAwait(false);
        //    ViewBag.Temporada = temporada.Nombre;
        //    ViewBag.ActivarMensaje = false;

        //    var allJugadores = await _administradorService.GetAllJugadoresWithTemporada().ConfigureAwait(false);
        //    allJugadores = allJugadores.OrderBy(j => j.Jugador).ThenBy(j => j.Temporada).ToList();
        //    return View(allJugadores);
        //}

        public async Task<IActionResult> DesactivarTodosJugadores()
        {
            // Desactivar todos los jugadores que existen actualmente
            Response response = await _administradorService.DesactivarAllJugadores().ConfigureAwait(false);
            ViewBag.Message = response.Message;
            ViewBag.ActivarMensaje = true;

            //var allJugadores = await _administradorService.GetAllJugadoresWithTemporada().ConfigureAwait(false);
            //allJugadores = allJugadores.OrderBy(j => j.Jugador).ThenBy(j => j.Temporada).ToList();
            //return View("TablaJugadores", allJugadores);
            TemporadaViewModel temporadaActual = await _managerService.GetTemporadaViewModelFinalizada().ConfigureAwait(false);
            TemporadaViewModel preTemporada = await _managerService.GetPreTemporadaViewModel().ConfigureAwait(false);
            var temporada = await _managerService.GetTemporadaActual().ConfigureAwait(false);
            if (temporada == null) temporada = await _managerService.GetPreTemporada().ConfigureAwait(false);

            ViewBag.Temporada = temporada.Nombre;
            ViewBag.Message = new List<string> { response.Message };
            ViewBag.ActivarMensaje = !string.IsNullOrEmpty(response.Message);

            var allJugadores = await _administradorService.GetAllJugadoresWithTemporada().ConfigureAwait(false);
            allJugadores = allJugadores.OrderBy(j => j.Jugador).ThenBy(j => j.Temporada).ToList();

            InfoPreparacionTemporadaViewModel viewModel = new InfoPreparacionTemporadaViewModel
            {
                Actual = temporadaActual,
                Pretemporada = preTemporada,
                Jugadores = allJugadores
            };

            return View("Jugadores", viewModel);
        }

        public async Task<IActionResult> ExportarExcel()
        {
            string excelContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            var allJugadores = await _administradorService.GetAllJugadoresWithTemporada().ConfigureAwait(false);
            var jugadoresActivosPorClub = allJugadores.Where(j => !j.Baja && j.Activo).OrderBy(j => j.Club).GroupBy(j => j.Club);
            var jugadoresBaja = allJugadores.Where(j => j.Baja || !j.Activo).GroupBy(j => j.Jugador).Select(grp=>grp.First());
            var clubs = await _administradorService.GetClubsViewModel().ConfigureAwait(false);
            var clubsActivos = clubs.Where(c => c.Activo).OrderBy(c => c.Club);
            var clubsBaja = clubs.Where(c => !c.Activo).OrderBy(c => c.Club);

            using (var libro = new ExcelPackage())
            {
                ClubsActivosToExcel(clubsActivos, libro);

                ClubsBajaToExcel(clubsBaja, libro);

                JugadoresBajaToExcel(jugadoresBaja, libro);

                foreach (IGrouping<string, TemporadaJugadorViewModel> jugadoresClub in jugadoresActivosPorClub)
                {
                    JugadoresClubToExcel(libro, jugadoresClub);
                }

                return File(libro.GetAsByteArray(), excelContentType, "JugadoresLigamania.xlsx");
            }
        }

        private void ClubsActivosToExcel(IOrderedEnumerable<ClubViewModel> clubsActivos, ExcelPackage libro)
        {
            var clubsExcel = _mapper.Map<List<ClubViewModel>, List<ClubExcelDto>>(clubsActivos.ToList());
            var worksheetB = libro.Workbook.Worksheets.Add(CLUBS_ACTIVOS);
            worksheetB.Cells["A1"].LoadFromCollection(clubsExcel, PrintHeaders: true);
            for (var col = 1; col < clubsExcel.Count + 1; col++)
            {
                worksheetB.Column(col).AutoFit();
            }
            // Agregar formato de tabla
            var tablaB = worksheetB.Tables.Add(new ExcelAddressBase(fromRow: 1, fromCol: 1, toRow: clubsExcel.Count + 1, toColumn: 1), FORMAT_CLUBS_ACTIVOS);
            tablaB.ShowHeader = true;
            tablaB.TableStyle = TableStyles.Light6;
            tablaB.ShowTotal = false;
        }
        private void ClubsBajaToExcel(IOrderedEnumerable<ClubViewModel> clubsBaja, ExcelPackage libro)
        {
            var clubsExcel = _mapper.Map<List<ClubViewModel>, List<ClubExcelDto>>(clubsBaja.ToList());
            var worksheetB = libro.Workbook.Worksheets.Add(CLUBS_BAJA);
            worksheetB.Cells["A1"].LoadFromCollection(clubsExcel, PrintHeaders: true);
            for (var col = 1; col < clubsExcel.Count + 1; col++)
            {
                worksheetB.Column(col).AutoFit();
            }
            // Agregar formato de tabla
            var tablaB = worksheetB.Tables.Add(new ExcelAddressBase(fromRow: 1, fromCol: 1, toRow: clubsExcel.Count + 1, toColumn: 1), FORMAT_CLUBS_BAJA);
            tablaB.ShowHeader = true;
            tablaB.TableStyle = TableStyles.Light6;
            tablaB.ShowTotal = false;
        }
        private void JugadoresBajaToExcel(IEnumerable<TemporadaJugadorViewModel> jugadoresBaja, ExcelPackage libro)
        {
            var jugBaja = jugadoresBaja.OrderBy(j => j.Jugador);
            var jugExcel = _mapper.Map<List<TemporadaJugadorViewModel>, List<JugadorBajaExcelDto>>(jugBaja.ToList());
            var worksheetB = libro.Workbook.Worksheets.Add(JUGADORES_BAJA);
            worksheetB.Cells["A1"].LoadFromCollection(jugExcel, PrintHeaders: true);
            for (var col = 1; col < jugExcel.Count + 1; col++)
            {
                worksheetB.Column(col).AutoFit();
            }
            // Agregar formato de tabla
            var tablaB = worksheetB.Tables.Add(new ExcelAddressBase(fromRow: 1, fromCol: 1, toRow: jugExcel.Count + 1, toColumn: 1), FORMAT_JUGADORES_BAJA);
            tablaB.ShowHeader = true;
            tablaB.TableStyle = TableStyles.Light6;
            tablaB.ShowTotal = false;
        }
        private void JugadoresClubToExcel(ExcelPackage libro, IGrouping<string, TemporadaJugadorViewModel> jugadoresClub)
        {
            var jugadoresActivos = jugadoresClub.OrderBy(j => j.OrdenPuesto).ThenBy(j => j.Jugador).ThenBy(j => j.Temporada);
            var jugadoresExcel = _mapper.Map<List<TemporadaJugadorViewModel>, List<JugadorActivoExcelDto>>(jugadoresActivos.ToList());

            var worksheet = libro.Workbook.Worksheets.Add(jugadoresClub.Key);
            worksheet.Cells["A1"].LoadFromCollection(jugadoresExcel, PrintHeaders: true);
            for (var col = 1; col < jugadoresExcel.Count + 1; col++)
            {
                worksheet.Column(col).AutoFit();
            }
            // Agregar formato de tabla
            var tabla = worksheet.Tables.Add(new ExcelAddressBase(fromRow: 1, fromCol: 1, toRow: jugadoresExcel.Count + 1, toColumn: 2), jugadoresClub.Key.Replace(' ', '_'));
            tabla.ShowHeader = true;
            tabla.TableStyle = TableStyles.Light6;
            tabla.ShowTotal = false;
        }

        public async Task<IActionResult> CargarJugadores(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("TablaJugadores");
            }

            IDictionary<string, List<string>> listErrors = new Dictionary<string, List<string>>();
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream).ConfigureAwait(false);

                using (var package = new ExcelPackage(memoryStream))
                {
                    foreach (var worksheet in package.Workbook.Worksheets)
                    {
                        var errors = await readExcelPackage(package, worksheet).ConfigureAwait(false);
                        listErrors.Add(worksheet.Name, errors);
                    }
                }
            }
            //return Content(listErrors.ToString());

            TemporadaViewModel temporadaActual = await _managerService.GetTemporadaViewModelFinalizada().ConfigureAwait(false);
            TemporadaViewModel preTemporada = await _managerService.GetPreTemporadaViewModel().ConfigureAwait(false);
            var temporada = await _managerService.GetTemporadaActual().ConfigureAwait(false);
            if (temporada == null) temporada = await _managerService.GetPreTemporada().ConfigureAwait(false);

            ViewBag.Temporada = temporada.Nombre;
            var lista = ConvertToListString(listErrors);
            ViewBag.ActivarMensaje = lista.Any();
            ViewBag.Message = lista;

            var allJugadores = await _administradorService.GetAllJugadoresWithTemporada().ConfigureAwait(false);
            allJugadores = allJugadores.OrderBy(j => j.Jugador).ThenBy(j => j.Temporada).ToList();

            InfoPreparacionTemporadaViewModel viewModel = new InfoPreparacionTemporadaViewModel
            {
                Actual = temporadaActual,
                Pretemporada = preTemporada,
                Jugadores = allJugadores
            };

            return View("Jugadores",viewModel);
        }

        private List<string> ConvertToListString(IDictionary<string, List<string>> listErrors)
        {
            List<string> lista = new List<string>();
            var mensaje = string.Empty;
            foreach(KeyValuePair<string,List<string>> message in listErrors)
            {
                if (message.Value.Any())
                {
                    foreach (var msg in message.Value)
                    {
                        mensaje = message.Key + ": " + msg + "\n";
                        lista.Add(mensaje);
                    }
                }
            }
            return lista;
        }

        // Devolver una lista de errores encontrados al leer el libro de excel
        private async Task<List<string>> readExcelPackage(ExcelPackage package, ExcelWorksheet worksheet)
        {
            List<string> lErrors = new List<string>();

            var rowCount = worksheet.Dimension?.Rows;
            var colCount = worksheet.Dimension?.Columns;

            if (!rowCount.HasValue || !colCount.HasValue)
            {
                return lErrors;
            }
            var name = worksheet.Name;
            switch (name)
            {
                case JUGADORES_BAJA:
                case CLUBS_ACTIVOS:
                case CLUBS_BAJA:
                    return lErrors;
                default:
                    lErrors = await TrataLibroJugadores(rowCount.Value, colCount.Value, worksheet).ConfigureAwait(false);
                    return lErrors;
            }
        }

        private async Task<List<string>> TrataLibroJugadores(int rowCount, int colCount, ExcelWorksheet worksheet)
        {
            var club = worksheet.Name;
            var jugadores = await LoadJugadores(rowCount, worksheet).ConfigureAwait(false);
            ResponseOfTReturn<List<string>> response = await _administradorService.LoadJugadoresFromExcel(club, jugadores).ConfigureAwait(false);
            return response.ResultDTO;
        }

        private async Task<List<JugadorActivoExcelDto>> LoadJugadores(int rowCount, ExcelWorksheet worksheet)
        {
            List<JugadorActivoExcelDto> jugadores = new List<JugadorActivoExcelDto>();
            for (int row = 2; row <= rowCount; row++)
            {
                if (worksheet.Cells[row, 1].Value != null && worksheet.Cells[row, 2].Value != null)
                {
                    JugadorActivoExcelDto jugador = new JugadorActivoExcelDto();
                    jugador.Jugador = worksheet.Cells[row, 1].Value.ToString();
                    jugador.Puesto = worksheet.Cells[row, 2].Value.ToString();
                    jugadores.Add(jugador);
                }
            }
            return await Task.FromResult(jugadores).ConfigureAwait(false);
        }

        #endregion
    }
}