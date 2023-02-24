using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Models.AdminViewModels;
using LigamaniaCoreApp.Models.HerramientasViewModels;
using LigamaniaCoreApp.Models.ManagerViewModels;
using LigamaniaCoreApp.Services;
using LigamaniaCoreApp.Services.Interfaces;
using LigamaniaCoreApp.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using static LigamaniaCoreApp.Data.LigamaniaEnum;

namespace LigamaniaCoreApp.Controllers
{
    [Authorize(Roles = "Manager")]
    public class HerramientasController : BaseController
    {
        private const string XlsxContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IHerramientasService _herramientasService;
        private readonly ILigamaniaService _ligamaniaService;

        private readonly ILogger<HerramientasController> _logger;

        public HerramientasController(IHerramientasService herramientasService
            , ILigamaniaService ligamaniaService
            , ILogger<HerramientasController> logger,
            IHostingEnvironment hostingEnvironment
            )
        {
            _herramientasService = herramientasService;
            _ligamaniaService = ligamaniaService;
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }
        public async Task<IActionResult> Alineaciones(string competicion)
        {
            if (!string.IsNullOrEmpty(competicion))
            {
                ViewBag.Equipos = await _ligamaniaService.GetEquiposTemporadaActual(competicion).ConfigureAwait(false);
                var alineaciones = await _herramientasService.GetAlineacionesCompeticion(competicion).ConfigureAwait(false);
                return View(alineaciones);
            }
            ViewBag.Equipos = await _ligamaniaService.GetEquiposTemporadaActual(LigamaniaConst.Competicion_Liga).ConfigureAwait(false);
            return View();
        }
        public async Task<IActionResult> RevisarClubAlineaciones()
        {
            try
            {
                Response response = await _herramientasService.RevisarClubsAlineaciones().ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[RevisarClubAlineaciones] " + x);
                return Json("Error al intentar RevisarClubAlineaciones");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AgregarJugador([FromBody] AlineacionCompeticionJornadaViewModel alineacion)
        {
            try
            {
                Response response = await _herramientasService.AgregarAlineacion(alineacion).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[AgregarJugador] " + x);
                return Json("Error al intentar AgregarJugador");
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditarJugador([FromBody] AlineacionCompeticionJornadaViewModel alineacion)
        {
            try
            {
                Response response = await _herramientasService.EditarAlineacion(alineacion).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[EditarJugador] " + x);
                return Json("Error al intentar EditarJugador");
            }
        }
        [HttpPost]
        public async Task<IActionResult> BorrarJugador([FromBody] AlineacionCompeticionJornadaViewModel alineacion)
        {
            try
            {
                Response response = await _herramientasService.BorrarAlineacion(alineacion).ConfigureAwait(false);
                return Json(response);
            }
            catch (Exception x)
            {
                _logger.LogError("[BorrarJugador] " + x);
                return Json("Error al intentar BorrarJugador");
            }
        }
        public async Task<IActionResult> CambiosEquipo()
        {
            var model = await _herramientasService.GetCambiosEquipos().ConfigureAwait(false);
            return View(model);
        }
        public async Task<IActionResult> Jugadores()
        {
            var model = await _herramientasService.GetAllJugadoresLigamania().ConfigureAwait(false);
            return View(model);
        }
        public async Task<IActionResult> SaveJugadoresInExcelFile()
        {
            List<JugadorRepositoryViewModel> model = await _herramientasService.GetAllJugadoresLigamania().ConfigureAwait(false);

            string fileDownloadName = "jugadores.xlsx";
            string reportsFolder = "ExcelFiles";

            var fileInfo = new FileInfo(Path.Combine(_hostingEnvironment.WebRootPath, reportsFolder, fileDownloadName));

            using (ExcelPackage package = new ExcelPackage())
            {
                try
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Jugadores");
                    worksheet.Cells["A1"].LoadFromCollection(model, PrintHeaders: true);
                    for (var col = 1; col < worksheet.Dimension.End.Column + 1; col++)
                    {
                        worksheet.Column(col).AutoFit();
                    }
                    var file = File(package.GetAsByteArray(), XlsxContentType, fileDownloadName);
                    package.SaveAs(fileInfo);

                    //Copy the package in memory
                    //byte[] data = package.GetAsByteArray();

                    ////Write to file   
                    //string filename = Path.Combine(_hostingEnvironment.WebRootPath, reportsFolder, fileDownloadName);
                    ////path = @"C:\temp\" + filename + ";";
                    //FileContentResult fileContentResult = File(data, XlsxContentType, filename);
                    //return fileContentResult;
                    ////var stream = File.Create(filename);
                    ////stream.Write(data, 0, data.Length);
                    ////stream.Close();
                }
                catch(Exception x)
                {
                    _logger.LogError(x.ToString());
                    return null;
                }
            }
            return Content(readExcelPackage(fileInfo, worksheetName: "Employee"));
            //return File($"~/{reportsFolder}/{fileDownloadName}", XlsxContentType, fileDownloadName);
        }
        private string readExcelPackage(FileInfo fileInfo, string worksheetName)
        {
            using (var package = new ExcelPackage(fileInfo))
            {
                return readExcelPackageToString(package, package.Workbook.Worksheets[worksheetName]);
            }
        }
        private string readExcelPackageToString(ExcelPackage package, ExcelWorksheet worksheet)
        {
            var rowCount = worksheet.Dimension?.Rows;
            var colCount = worksheet.Dimension?.Columns;

            if (!rowCount.HasValue || !colCount.HasValue)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            for (int row = 1; row <= rowCount.Value; row++)
            {
                for (int col = 1; col <= colCount.Value; col++)
                {
                    sb.AppendFormat("{0}\t", worksheet.Cells[row, col].Value);
                }
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        /////// <summary>
        /////// /Home/DataTableReport
        /////// Crea un excel con el formato que previamente se genera en DataTable
        /////// </summary>
        ////public IActionResult DataTableReport()
        ////{
        ////    var dataTable = new DataTable("Users");
        ////    dataTable.Columns.Add("Name", typeof(string));
        ////    dataTable.Columns.Add("Age", typeof(int));
        ////    var rnd = new Random();
        ////    for (var i = 0; i < 100; i++)
        ////    {
        ////        var row = dataTable.NewRow();
        ////        row["Name"] = $"User {i}";
        ////        row["Age"] = rnd.Next(20, 100);
        ////        dataTable.Rows.Add(row);
        ////    }

        ////    using (var package = new ExcelPackage())
        ////    {
        ////        var worksheet = package.Workbook.Worksheets.Add("Excel Test");
        ////        worksheet.Cells["A1"].LoadFromDataTable(dataTable, PrintHeaders: true);
        ////        for (var col = 1; col < dataTable.Columns.Count + 1; col++)
        ////        {
        ////            worksheet.Column(col).AutoFit();
        ////        }
        ////        return File(package.GetAsByteArray(), XlsxContentType, "report.xlsx");
        ////    }
        ////}
    }
}