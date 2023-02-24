using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LigamaniaCoreApp.Data;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using LigamaniaCoreApp.Models;
using LigamaniaCoreApp.Models.AccountViewModels;
using LigamaniaCoreApp.Models.GlobalViewModels;
using LigamaniaCoreApp.Models.InvitadoViewModels;
using LigamaniaCoreApp.Models.ManagerViewModels;
using LigamaniaCoreApp.Services;
using LigamaniaCoreApp.Services.Interfaces;
using LigamaniaCoreApp.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace LigamaniaCoreApp.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerCController : BaseController
    {
        private readonly IManagerService _managerService;
        private readonly ILigamaniaService _ligamaniaService;
        private readonly MenuMasterService _menuMasterService;
        private readonly ApplicationUserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private IHostingEnvironment _hostingEnvironment;
        private readonly IControlUsuarioRepository _controlUsuarioRepository;
        private readonly IInvitadoService _invitadoService;
        private readonly RoleManager<IdentityRole> _roleManager;

        public readonly ILogger _logger;
        public ManagerCController(IManagerService managerService
            , ILigamaniaService ligamaniaService
            , MenuMasterService menuMasterService
            , ILogger<ManagerCController> logger
            , ApplicationUserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager
            , IHostingEnvironment hostingEnvironment
            , IControlUsuarioRepository controlUsuarioRepository
            , IInvitadoService invitadoService
            , RoleManager<IdentityRole> roleManager
             )
        {
            _logger = logger;
            _managerService = managerService;
            _ligamaniaService = ligamaniaService;
            _menuMasterService = menuMasterService;
            _userManager = userManager;
            _signInManager = signInManager;
            _hostingEnvironment = hostingEnvironment;
            _controlUsuarioRepository = controlUsuarioRepository;
            _invitadoService = invitadoService;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Settings
        public async Task<IActionResult> Settings()
        {
            SettingsViewModel settings = await _ligamaniaService.GetSettings().ConfigureAwait(false);
            return View(settings);
        }
        [HttpPost]
        public async Task<IActionResult> SettingClasificaciones(/*[FromBody]*/ SettingsViewModel settings)
        {
            try
            {
                Response response = await _ligamaniaService.EstablecerConfiguracion(settings).ConfigureAwait(false);
                return View("Settings");
//                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[SettingClasificaciones] " + x);
                return Json("Error al almacenar la configuración");
            }
        }

        #region Carga de calendarios
        [HttpPost]
        public async Task<IActionResult> LoadCalendar(string nombre, int equipos)
        {
                return await OnPostImport(nombre,equipos).ConfigureAwait(false);
            //else if (handler.Equals("Export"))
            //    return await OnPostExport();
            //return View("Settings");
        }
        // EJEMPLO DE INTERNET (https://www.talkingdotnet.com/import-export-excel-asp-net-core-2-razor-pages/)
        public async Task<IActionResult> OnPostExport()
        {
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = @"demo.xlsx";
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            var memory = new MemoryStream();
            using (var fs = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook;
                workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Demo");
                IRow row = excelSheet.CreateRow(0);

                row.CreateCell(0).SetCellValue("ID");
                row.CreateCell(1).SetCellValue("Name");
                row.CreateCell(2).SetCellValue("Age");

                row = excelSheet.CreateRow(1);
                row.CreateCell(0).SetCellValue(1);
                row.CreateCell(1).SetCellValue("Kane Williamson");
                row.CreateCell(2).SetCellValue(29);

                row = excelSheet.CreateRow(2);
                row.CreateCell(0).SetCellValue(2);
                row.CreateCell(1).SetCellValue("Martin Guptil");
                row.CreateCell(2).SetCellValue(33);

                row = excelSheet.CreateRow(3);
                row.CreateCell(0).SetCellValue(3);
                row.CreateCell(1).SetCellValue("Colin Munro");
                row.CreateCell(2).SetCellValue(23);

                workbook.Write(fs);
            }
            using (var stream = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Open))
            {
                await stream.CopyToAsync(memory).ConfigureAwait(false);
            }
            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
        }
        public async Task<IActionResult> OnPostImport(string nombre, int equipos)
        {
            CalendarioDTO calendario = await _managerService.NuevoCalendario(nombre, equipos).ConfigureAwait(false);

            IFormFile file = Request.Form.Files[0];
            string folderName = "Upload";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            StringBuilder sb = new StringBuilder();
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {
                string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                ISheet sheet;
                string fullPath = Path.Combine(newPath, file.FileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    if (sFileExtension == ".xls")
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                    }
                    else
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                    }
                    IRow headerRow = sheet.GetRow(0); //Get Header Row
                    int cellCount = headerRow.LastCellNum;
                    sb.Append("<table class='table'><tr>");
                    for (int j = 0; j < cellCount; j++)
                    {
                        NPOI.SS.UserModel.ICell cell = headerRow.GetCell(j);
                        if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                        sb.Append("<th>" + cell.ToString() + "</th>");
                    }
                    sb.Append("</tr>");
                    sb.AppendLine("<tr>");
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                        int jornada = -1; string local = ""; string visitante = "";
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                            {
                                sb.Append("<td>" + row.GetCell(j).ToString() + "</td>");
                                if (j == 1) jornada = (int)row.GetCell(j).NumericCellValue;
                                if (j == 2) local = row.GetCell(j).ToString();
                                if (j == 3) visitante = row.GetCell(j).ToString();
                            }
                        }
                        if (jornada != -1 && !string.IsNullOrEmpty(local) && !string.IsNullOrEmpty(visitante))
                            await _managerService.NuevoCalendarioDetalle(calendario, jornada, local, visitante).ConfigureAwait(false);
                        sb.AppendLine("</tr>");
                    }
                    sb.Append("</table>");
                }
            }
            //return this.Content(sb.ToString());
            return RedirectToAction("Settings");
        }
        #endregion

        #region Carga de documentos
        [HttpPost]
        public async Task<IActionResult> LoadDocument(string descripcion)
        {
            if (string.IsNullOrEmpty(descripcion))
                descripcion = "Sin descripción";

            IFormFile file = Request.Form.Files[0];

            // Read the file and convert it to Byte Array
            string filename = Path.GetFileName(file.FileName);
            string contentType = file.ContentType;

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                byte[] fileBytes = ms.ToArray();
                Response response = await _invitadoService.SaveDocument(descripcion, filename, contentType, fileBytes).ConfigureAwait(false);
            }

            return RedirectToAction("Settings");
        }

        #endregion
        public async Task<IActionResult> BorrarDocumento([FromBody] ReglamentoViewModel reglamento)
        {
            var response = await _invitadoService.DeleteDocumento(reglamento.Id).ConfigureAwait(false);
            return Json(response);
        }
        #endregion

        #region Acceder como otro usuario y acciones de los usuarios
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme).ConfigureAwait(false);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            var userOriginal = User.Identity.Name;

            ViewData["ReturnUrl"] = returnUrl;
            var cadena = model.UserName.Split("#");
            var email = cadena[0];
            var equipo = cadena[1];

            var user = await _userManager.FindByEmailAsync(email).ConfigureAwait(false);
            if (user!=null)
            {
                await _signInManager.SignInAsync(user, true).ConfigureAwait(false);
                await _controlUsuarioRepository.AddAccionUsuario(email, "Entrar en sesión desde el usuario " + userOriginal, equipo).ConfigureAwait(false);
                return RedirectToLocal(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
        public async Task<IActionResult> AccionesUsuarios()
        {
            var acciones = await _userManager.GetAccionesUsuarios().ConfigureAwait(false);
            return View(acciones);
        }

        #endregion

        #region Cierre Temporada
        public async Task<IActionResult> CierreTemporada()
        {
            TemporadaViewModel temporadaActual = await _managerService.GetTemporadaViewModelActual().ConfigureAwait(false);
            TemporadaViewModel preTemporada = await _managerService.GetPreTemporadaViewModel().ConfigureAwait(false);
            InfoPreparacionTemporadaViewModel viewModel = new InfoPreparacionTemporadaViewModel
            {
                Actual = temporadaActual,
                Pretemporada = preTemporada
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> FinalizarTemporada([FromBody] TemporadaViewModel temporadaVM)
        {
            try
            {
                ResponseOfTReturn<TemporadaViewModel> response = await _managerService.FinalizarTemporada(temporadaVM.Id).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[FinalizarTemporada] " + x);
                return Json("Error al intentar finalizar la temporada");
            }
        }
        [HttpPost]
        public async Task<IActionResult> LimpiarBaseDatos([FromBody] TemporadaViewModel temporadaVM)
        {
            try
            {
                Response response = await _managerService.LimpiarBaseDatos(temporadaVM.Id).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[LimpiarBaseDatos] " + x);
                return Json("Error al intentar limpiar la base de datos");
            }
        }
        [HttpPost]
        public async Task<IActionResult> ConvertirAHistorica([FromBody] TemporadaViewModel temporadaVM)
        {
            try
            {
                Response response = await _managerService.ConvertirAHistorica(temporadaVM.Id).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[FinalizarTemporada] " + x);
                return Json("Error al intentar finalizar la temporada");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CrearTemporada([FromBody] TemporadaViewModel temporada)
        {
            try
            {
                Response response = await _managerService.CrearTemporada(temporada.Temporada).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[CrearTemporada] " + x);
                return Json("Error al intentar crear la temporada " + temporada);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AgregarLigaPretemporada()
        {
            try
            {
                Response response = await _managerService.AgregarLigaYEquiposPretemporada().ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[AgregarLigaPretemporada] " + x);
                return Json("Error al intentar agregar Liga a la pretemporada");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PreTemporadaToActual()
        {
            try
            {
                Response response = await _managerService.PreTemporadaToActual().ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[PreTemporadaToActual] " + x);
                return Json("Error al PreTemporadaToActual");
            }
        }
        public async Task<IActionResult> FinalizarCompeticion([FromBody] TemporadaCompeticionViewModel competicion)
        {
            try
            {
                Response response = await _managerService.FinalizarCompeticion(competicion).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[PreTemporadaToActual] " + x);
                return Json("Error al PreTemporadaToActual");
            }
        }
        #endregion

        #region Gestion de Equipos
        public async Task<IActionResult> AltaBajaEquipos()
        {
            // Equipos pretemporada
            ICollection<TemporadaEquipoViewModel> temporadaEquipos = await _managerService.GetEquiposViewModelPretemporada().ConfigureAwait(false);
            return View(temporadaEquipos);
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmarDesconfirmarTemporada([FromBody]TemporadaEquipoAccion equipo)
        {
            try
            {
                Response response = await _managerService.ConfirmarDesconfirmarTemporada(equipo).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[ConfirmarDesconfirmarTemporada] " + x);
                return Json("Error al confirmar/desconfirmar temporada");
            }
        }
        [HttpPost]
        public async Task<IActionResult> PagarTemporada([FromBody]TemporadaEquipoAccion equipo)
        {
            try
            {
                Response response = await _managerService.PagarTemporada(equipo).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[PagarTemporada] " + x);
                return Json("Error al pagar la temporada");
            }
        }
        public async Task<IActionResult> DarBajaTemporada([FromBody]TemporadaEquipoAccion equipo)
        {
            try
            {
                Response response = await _managerService.DarBajaTemporada(equipo).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[DarBajaTemporada] " + x);
                return Json("Error al dar baja temporada");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CheckNuevoEquipo([FromBody]RegisterViewModel menu)
        {
            try
            {
                int response = await _managerService.CheckNuevoEquipo(menu).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[CheckNuevoEquipo] " + x);
                return Json("Error al chequear nuevo equipo");
            }
        }
        [HttpPost]
        public async Task<IActionResult> NuevoEquipo([FromBody]RegisterViewModel equipo)
        {
            try
            {
                Response response = await _managerService.NuevoEquipo(equipo).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[NuevoEquipo] " + x);
                return Json("Error al crear un equipo");
            }
        }
        [HttpPost]
        public async Task<IActionResult> SustituirEquipo([FromBody]TemporadaEquipoAccion sustitucion)
        {
            try
            {
                Response response = await _managerService.SustituirEquipo(sustitucion).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[SustituirEquipo] " + x);
                return Json("Error al Sustituir un Equipo");
            }
        }
        public async Task<IActionResult> ActivarDesactivarEquipo([FromBody] TemporadaEquipoAccion equipo)
        {
            try
            {
                Response response = await _managerService.ActivarDesactivarEquipo(equipo).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[ActivarDesactivarEquipo] " + x);
                return Json("Error al ActivarDesactivarEquipo");
            }
        }
        public async Task<IActionResult> BotNoBotEquipo([FromBody] TemporadaEquipoAccion equipo)
        {
            try
            {
                Response response = await _managerService.BotNoBotEquipo(equipo).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[BotNoBotEquipo] " + x);
                return Json("Error al BotNoBotEquipo");
            }
        }

        public async Task<IActionResult> AccionSobreEntrenador([FromBody] AccionUsuarioViewModel accion)
        {
            try
            {
                Response response = await _managerService.AccionSobreEntrenador(accion).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[AccionSobreEntrenador] " + x);
                return Json("Error al AccionSobreEntrenador");
            }
        }
        #endregion

        #region Entrenadores
        public async Task<IActionResult> Entrenadores()
        {
            EntrenadorEquipoViewModel model = new EntrenadorEquipoViewModel();

            var inventario = await _userManager.GetInventarioEntrenadores().ConfigureAwait(false);
            model.InventarioEntrenadores = inventario;
            var entrenadores = inventario.Where(i => i.EsEntrenador && (i.UserState == eUserState.Confirmed)).OrderBy(i => i.Equipo).ToList();
            model.Entrenadores = entrenadores;
            model.Equipos = await _managerService.GetInventarioEquipos().ConfigureAwait(false);
            model.ExistingRoles = _roleManager.Roles.Select(x=>x.Name).ToList();
            return View(model);
        }
        public async Task<IActionResult>EditarEquipo([FromBody]RegisterViewModel equipoInfo)
        {
            try
            {
                Response response = await _userManager.EditarEquipo(equipoInfo).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[EditarEquipo] " + x);
                return Json("Error al intentar EditarEquipo");
            }
        }

        public async Task<IActionResult> AddRoleToUser ([FromBody] RegisterViewModel equipoInfo)
        {
            try
            {
                Response response = await _userManager.AddRoleToUser(equipoInfo).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[AddRoleToUser] " + x);
                return Json("Error al intentar AddRoleToUser");
            }
        }
        public async Task<IActionResult> RemoveRoleFromUser([FromBody] RegisterViewModel equipoInfo)
        {
            try
            {
                Response response = await _userManager.RemoveRoleFromUser(equipoInfo).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[RemoveRoleFromUser] " + x);
                return Json("Error al intentar RemoveRoleFromUser");
            }
        }
        #endregion

        #region Menu
        public async Task<IActionResult> ConfigMenu()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AgregarMenu([FromBody]MenuMasterViewModel menu)
        {
            try
            {
                Response response = await _menuMasterService.NuevoMenu(menu).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[AgregarMenu] " + x);
                return Json("Error al intentar AgregarMenu");
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditarMenu([FromBody] MenuMasterViewModel menu)
        {
            try
            {
                Response response = await _menuMasterService.EditarMenu(menu).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[EditarMenu] " + x);
                return Json("Error al intentar EditarMenu");
            }

        }
        [HttpPost]
        public async Task<IActionResult> BorrarMenu([FromBody] MenuMasterViewModel menu)
        {
            try
            {
                Response response = await _menuMasterService.BorrarMenu(menu).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[BorrarMenu] " + x);
                return Json("Error al intentar BorrarMenu");
            }

        }
        #endregion

        #region Noticias
        public async Task<IActionResult> Noticias()
        {
            ICollection<NoticiaViewModel> noticias = await _ligamaniaService.GetAllNews().ConfigureAwait(false);
            return View(noticias);
        }
        [HttpPost]
        public async Task<IActionResult> AgregarNoticia([FromBody]NoticiaViewModel noticiaVM)
        {
            try
            {
                Response response = await _managerService.AgregarNuevaNoticia(noticiaVM).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[AgregarNoticia] " + x);
                return Json("Error al intentar AgregarNoticia");
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditarNoticia([FromBody]NoticiaViewModel noticiaVM)
        {
            try
            {
                Response response = await _managerService.EditarNoticia(noticiaVM).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[EditarNoticia] " + x);
                return Json("Error al intentar EditarNoticia");
            }
        }
        [HttpPost]
        public async Task<IActionResult> BorrarNoticia([FromBody]NoticiaViewModel noticiaVM)
        {
            try
            {
                Response response = await _managerService.BorrarNoticia(noticiaVM).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[BorrarNoticia] " + x);
                return Json("Error al intentar BorrarNoticia");
            }
        }
        [HttpPost]
        public async Task<IActionResult> DesactivarTodasNoticias()
        {
            try
            {
                Response response = await _managerService.DesactivarTodasNoticias().ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[DesactivarTodasNoticias] " + x);
                return Json("Error al intentar DesactivarTodasNoticias");
            }
        }
        [HttpPost]
        public async Task<IActionResult> ActivarTodasNoticias()
        {
            try
            {
                Response response = await _managerService.ActivarTodasNoticias().ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[DesactivarTodasNoticias] " + x);
                return Json("Error al intentar DesactivarTodasNoticias");
            }
        }
        [HttpPost]
        public async Task<IActionResult> DesactivarNoticia([FromBody]NoticiaViewModel noticiaVM)
        {
            try
            {
                Response response = await _managerService.DesactivarNoticia(noticiaVM).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[DesactivarTodasNoticias] " + x);
                return Json("Error al intentar DesactivarTodasNoticias");
            }
        }
        #endregion

        #region Preparar competición
        public async Task<IActionResult> PrepararCompeticion()
        {
            TemporadaDTO preTemporada = await _managerService.GetPreTemporada().ConfigureAwait(false);
            TemporadaViewModel preTemporadaVM = await _managerService.GetPreTemporadaViewModel().ConfigureAwait(false);

            List<CompeticionCategoriaViewModel> allCompeticiones = await _managerService.GetAllCompeticiones().ConfigureAwait(false);
            List<TemporadaCompeticionCategoriaViewModel> competicionesActivas = await _managerService.GetCompeticionesActivas(preTemporada).ConfigureAwait(false);

            PreparacionTemporadaViewModel vm = new PreparacionTemporadaViewModel
            {
                Temporada = preTemporadaVM,
                AllCompeticiones = allCompeticiones.OrderBy(c=>c.OrdenCompeticion).ThenBy(c=>c.OrdenCategoria).ToList(),
                CompeticionesCategoriasActivas = competicionesActivas.OrderBy(c => c.OrdenCompeticion).ThenBy(c => c.OrdenCategoria).ToList()
            };

            return View(vm);
        }
        public async Task<IActionResult> ActivarCompeticion([FromBody] PreparacionTemporadaViewModel competicionToActivar)
        {
            try
            {
                Response response = await _managerService.ActivarCompeticion(competicionToActivar).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[ActivarCompeticion] " + x);
                return Json("Error al activar una competición");
            }
        }
        public async Task<IActionResult> DesactivarCompeticion([FromBody] PreparacionTemporadaViewModel competicionToActivar)
        {
            try
            {
                Response response = await _managerService.DesactivarCompeticion(competicionToActivar).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[DesactivarCompeticion] " + x);
                return Json("Error al desactivar una competición");
            }
        }
        public async Task<IActionResult> ActivarParaComenzarCompeticion([FromBody] PreparacionTemporadaViewModel competicionToActivar)
        {
            try
            {
                Response response = await _managerService.ActivarParaComenzarCompeticion(competicionToActivar).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[ActivarParaComenzarCompeticion] " + x);
                return Json("Error al Activar Para Comenzar Competicion");
            }
        }
        public async Task<IActionResult> EditarTemporadaCompeticion([FromBody] TemporadaCompeticionCategoriaViewModel competicion)
        {
            try
            {
                Response response = await _managerService.EditarCompeticion(competicion).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[EditarTemporadaCompeticion] " + x);
                return Json("Error al editar una competición");
            }
        }
        public async Task<IActionResult> PrepararCategoriaTemporada(int idCompeticion,int idCategoria)
        {
            try
            {
                TemporadaCompeticionCategoriaViewModel model = await _managerService.GetInfoCompeticionCategoria(idCompeticion, idCategoria).ConfigureAwait(false);
                return View(model);
            }
            catch (Exception x)
            {
                _logger.LogError("[PrepararCategoriaTemporada] " + x);
                return Json("Error al buscar información de una competición");
            }

        }
        public async Task<IActionResult> CopiarEquipos([FromBody] PreparacionTemporadaViewModel copiarEquipos)
        {
            try
            {
                Response response = await _managerService.CopiarEquipos(copiarEquipos).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[CopiarEquipos] " + x);
                return Json("Error al Copiar Equipos");
            }
        }
        public async Task<IActionResult> AgregarEquipo([FromBody] PreparacionTemporadaViewModel equipo)
        {
            try
            {
                Response response = await _managerService.AgregarEquipo(equipo).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[CopiarEquipos] " + x);
                return Json("Error al Copiar Equipos");
            }
        }
        public async Task<IActionResult> AgregarEquiposSupercopa([FromBody] PreparacionTemporadaViewModel compCat)
        {
            try
            {
                Response response = await _managerService.AgregarEquiposSupercopa(compCat).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[AgregarEquiposSupercopa] " + x);
                return Json("Error al AgregarEquiposSupercopa");
            }
        }
        public async Task<IActionResult> AgregarPartidoSupercopa([FromBody] PreparacionTemporadaViewModel compCat)
        {
            try
            {
                Response response = await _managerService.AgregarPartidoSupercopa(compCat).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[AgregarPartidoSupercopa] " + x);
                return Json("Error al AgregarPartidoSupercopa");
            }
        }

        public async Task<IActionResult> BajaEquipo([FromBody]PreparacionTemporadaViewModel equipo)
        {
            try
            {
                Response response = await _managerService.BajaEquipo(equipo).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[DarBajaTemporada] " + x);
                return Json("Error al dar baja temporada");
            }
        }

        public async Task<IActionResult> AgregarJornada([FromBody] PreparacionTemporadaViewModel jornada)
        {
            try
            {
                Response response = await _managerService.AgregarJornada(jornada).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[AgregarJornada] " + x);
                return Json("Error al agregar jornada");
            }
        }
        public async Task<IActionResult> EditarJornada([FromBody] PreparacionTemporadaViewModel jornada)
        {
            try
            {
                Response response = await _managerService.EditarJornada(jornada).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[EditarJornada] " + x);
                return Json("Error al editar jornada");
            }
        }
        public async Task<IActionResult> BorrarJornada([FromBody] PreparacionTemporadaViewModel jornada)
        {
            try
            {
                Response response = await _managerService.BorrarJornada(jornada).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[CopiarEquipos] " + x);
                return Json("Error al Copiar Equipos");
            }
        }
        public async Task<IActionResult> SetJornadaActual([FromBody] PreparacionTemporadaViewModel jornada)
        {
            try
            {
                Response response = await _managerService.SetJornadaActual(jornada).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[SetJornadaActual] " + x);
                return Json("Error al SetJornadaActual");
            }
        }
        public async Task<IActionResult> RemoveAllJornadas([FromBody] PreparacionTemporadaViewModel compCat)
        {
            try
            {
                Response response = await _managerService.RemoveAllJornadas(compCat).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[RemoveAllJornadas] " + x);
                return Json("Error al borrar todas las jornadas");
            }
        }
        public async Task<IActionResult> GenerarPartidos([FromBody] PreparacionTemporadaViewModel generaPartidos)
        {
            try
            {
                Response response = await _managerService.GenerarPartidos(generaPartidos).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[CopiarEquipos] " + x);
                return Json("Error al Copiar Equipos");
            }
        }
        public async Task<IActionResult> GenerarPartidoLibre([FromBody] PreparacionTemporadaViewModel generaPartidos)
        {
            try
            {
                Response response = await _managerService.GenerarPartidoLibre(generaPartidos).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[CopiarEquipos] " + x);
                return Json("Error al Copiar Equipos");
            }
        }
        public async Task<IActionResult> RemoveAllPartidos([FromBody] PreparacionTemporadaViewModel compCat)
        {
            try
            {
                Response response = await _managerService.RemoveAllPartidos(compCat).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[RemoveAllJornadas] " + x);
                return Json("Error al borrar todas las jornadas");
            }
        }
        public async Task<IActionResult> ResetearCompeticion([FromBody] TemporadaCompeticionViewModel competicion)
        {
            try
            {
                Response response = await _managerService.ResetearCompeticion(competicion).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[ResetearCompeticion] " + x);
                return Json("Error al ResetearCompeticion");
            }
        }
        public async Task<IActionResult> ResetearAlineaciones([FromBody] TemporadaCompeticionViewModel competicion)
        {
            try
            {
                Response response = await _managerService.ResetearAlineaciones(competicion).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[ResetearAlineaciones] " + x);
                return Json("Error al ResetearAlineaciones");
            }
        }
        public async Task<IActionResult> AddDiasJornada([FromBody] PreparacionTemporadaViewModel jornada)
        {
            try
            {
                Response response = await _managerService.AddDiasJornada(jornada).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[AddDiasJornada] " + x);
                return Json("Error al AddDiasJornada");
            }
        }

        #endregion

        #region Configuración de las clasificaciones
        public async Task<IActionResult> ConfigClasificaciones()
        {
            ICollection<CompeticionCategoriaViewModel> model = await _managerService.GetReferenciaClasificaciones().ConfigureAwait(false);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditarReferenciaCompeticion([FromBody] AccionCambiarReferencia referencia)
        {
            try
            {
                Response response = await _managerService.EditarReferenciaCompeticion(referencia).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[EditarReferenciaCompeticion] " + x);
                return Json("Error al intentar Editar Referencia Competicion");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AgregarReferenciaCompeticion([FromBody] AccionCambiarReferencia referencia)
        {
            try
            {
                Response response = await _managerService.AgregarReferenciaCompeticion(referencia).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[AgregarReferenciaCompeticion] " + x);
                return Json("Error al intentar Agregar Referencia Competicion");
            }
        }
       
        #endregion

        #region Configuración de la COPA
        public async Task<IActionResult> EstablecerEquiposCopa([FromBody] PreparacionTemporadaViewModel competicion)
        {
            try
            {
                Response response = await _managerService.EstablecerEquiposCopa(competicion).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[EstablecerEquiposCopa] " + x);
                return Json("Error al EstablecerEquiposCopa");
            }
        }
        public async Task<IActionResult> EstablecerRondasJornadasCopa([FromBody] PreparacionTemporadaViewModel competicion)
        {
            try
            {
                Response response = await _managerService.EstablecerRondasJornadasCopa(competicion).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[EstablecerRondasJornadasCopa] " + x);
                return Json("Error al EstablecerRondasJornadasCopa");
            }
        }
        
        public async Task<IActionResult> NuevaJornadaFinalCopa([FromBody] PreparacionTemporadaViewModel competicion)
        {
            try
            {
                Response response = await _managerService.NuevaJornadaFinalCopa(competicion).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[NuevaJornadaFinalCopa] " + x);
                return Json("Error al NuevaJornadaFinalCopa");
            }
        }
        public async Task<IActionResult> AgregarPartidosCopa([FromBody] PreparacionTemporadaViewModel competicion)
        {
            try
            {
                Response response = await _managerService.AgregarPartidosCopa(competicion).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[AgregarPartidosCopa] " + x);
                return Json("Error al AgregarPartidosCopa");
            }
        }

        public Task<IActionResult> Login(LoginViewModel model, Uri returnUrl)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Premios de la temporada
        [AllowAnonymous]
        public async Task<IActionResult> PremiosTemporada(string temporada)
        {
            PremiosViewModel premiosTemporada = await _invitadoService.GetPremiosTemporada(temporada).ConfigureAwait(false);
            premiosTemporada.Editable = false;
            if (User.IsInRole(LigamaniaEnum.ERol.Manager.ToString()))
                premiosTemporada.Editable = true;

            return View(premiosTemporada);
        }
        [HttpPost]
        public async Task<IActionResult> NuevoConceptoContabilidad([FromBody] ContabilidadViewModel concepto)
        {
            try
            {
                Response response = await _managerService.NuevoConceptoContabilidad(concepto).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[NuevoConceptoContabilidad] " + x);
                return Json("Error al agregar un Nuevo Concepto Contabilidad");
            }
        }
        [HttpPost]
        public async Task<IActionResult> NuevoPremio([FromBody] PremioPuestoViewModel premio)
        {
            try
            {
                Response response = await _managerService.NuevoPremio(premio).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[NuevoPremio] " + x);
                return Json("Error al agregar un Nuevo Premio");
            }
        }
        [HttpPost]
        public async Task<IActionResult> NuevoPorcentaje([FromBody] PremioCompeticionViewModel premio)
        {
            try
            {
                Response response = await _managerService.NuevaCompeticionPremio(premio).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[NuevoPorcentaje] " + x);
                return Json("Error al agregar un Nuevo Porcentaje");
            }
        }
        [HttpPost]
        public async Task<IActionResult> GetCategoriasByCompeticion(string competicion)
        {
            var categorias = await _ligamaniaService.GetAllCategorias(competicion).ConfigureAwait(false);
            return Json(categorias);
        }
        #endregion

    }

}