using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;

using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

using VoleyPlaya.Domain.Models;
using VoleyPlaya.Domain.Services;
using VoleyPlaya.GestionWeb.Infrastructure;

namespace VoleyPlaya.GestionWeb.Pages
{
    public class CalendariosModel : VPPageModel
    {
        IEdicionService _service;

        //public string ErrorMessage { get; set; }

        [BindProperty]
        public int EdicionSelected { get; set; }

        public SelectList Ediciones { get; set; } = default!;

        [BindProperty]
        public int GrupoSelected { get; set; }

        public SelectList Grupos { get; set; } = default!;

        [BindProperty]
        public List<Partido> Partidos { get; set; }        

        public CalendariosModel(IEdicionService service)
        {
            _service = service;
            Ediciones = new SelectList(new List<Edicion>(), "Id", "Item");
            Grupos = new SelectList(new List<EdicionGrupo>(), "Id", "Item");
        }
        public async Task OnGetAsync(int EdicionSelected, int GrupoSelected)
        {
            this.EdicionSelected = EdicionSelected;
            this.GrupoSelected = GrupoSelected;
            await GetLists();
            await GetPartidosAsync();
        }

        private async Task GetLists()
        {
            await GetListaEdiciones();
            await GetListaGrupos();
        }

        private async Task GetListaGrupos()
        {
            var grupos = await _service.GetListaGrupos(EdicionSelected);
            Grupos = new SelectList(grupos, "Id", "Item", GrupoSelected);
        }

        private async Task GetListaEdiciones()
        {
            var ediciones = await _service.GetListaEdiciones();
            Ediciones = new SelectList(ediciones, "Id", "Item", EdicionSelected);
        }

        public async Task GetPartidosAsync()
        {

            Partidos = await _service.GetPartidosFiltradosAsync(EdicionSelected, GrupoSelected);
        }
        public async Task<IActionResult> OnGetGruposAsync(int competicionId)
        {
            EdicionSelected = competicionId;
            await GetListaGrupos();
            return new JsonResult(Grupos);
        }
        public async Task<IActionResult> OnPostExportarAsync(int competicionId, int grupoId)
        {
            competicionId = EdicionSelected;
            grupoId = GrupoSelected;

            // Exportar a excel el calendario seleccionado
            var data = await _service.ExportarCalendarioAsync(competicionId, grupoId);

            // Obtén la ruta del directorio personal del usuario
            string personalFolder = Environment.CurrentDirectory;
            // Nombre del fichero
            string fName = $"Calendario_" + data.edicion.Nombre + "Grupo" + data.grupo.Name + ".xlsx";
            // Concatena el nombre de la carpeta "Descargas" en la ruta
            string fileName = System.IO.Path.Combine(personalFolder, fName);
            // Nombre de la hoja
            string sheetName = "calendario";

            // Escribir el libro de Excel en un MemoryStream
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook = GenerarExcelFile(fileName, sheetName, data.partidos, data.edicion, data.grupo);
                workbook.Write(fs, true);
                workbook.Close();
            }
            byte[] fileByteArray = System.IO.File.ReadAllBytes(fileName);
            System.IO.File.Delete(fileName);
            return File(fileByteArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fName);
        }

        private IWorkbook GenerarExcelFile(string fileName, string sheetName, List<Partido> partidos, Edicion edicion, EdicionGrupo grupo)
        {
            // Crear un nuevo libro de Excel
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Hoja1");

            IRow row = sheet.CreateRow(0);

            int j = 0;
            row.CreateCell(j++).SetCellValue("Competición");
            row.CreateCell(j++).SetCellValue("Categoria");
            row.CreateCell(j++).SetCellValue("Género");
            row.CreateCell(j++).SetCellValue("Grupo");
            row.CreateCell(j++).SetCellValue("Jornada");
            row.CreateCell(j++).SetCellValue("PN");
            row.CreateCell(j++).SetCellValue("Fecha");
            row.CreateCell(j++).SetCellValue("Hora");
            row.CreateCell(j++).SetCellValue("Pista");
            row.CreateCell(j++).SetCellValue("Local");
            row.CreateCell(j++).SetCellValue("R. local");
            row.CreateCell(j++).SetCellValue("R. visitante");
            row.CreateCell(j++).SetCellValue("Visitante");

            // Escribir los datos en las celdas del libro de Excel
            for (int i = 1; i <= partidos.Count; i++)
            {
                row = sheet.CreateRow(i);
                j = 0;

                row.CreateCell(j++).SetCellValue(edicion.Competicion);
                row.CreateCell(j++).SetCellValue(edicion.CategoriaStr);
                row.CreateCell(j++).SetCellValue(edicion.GeneroStr);
                row.CreateCell(j++).SetCellValue(grupo.Name);
                row.CreateCell(j++).SetCellValue(partidos[i - 1].Jornada);
                row.CreateCell(j++).SetCellValue(partidos[i - 1].Label);
                row.CreateCell(j++).SetCellValue(partidos[i - 1].FechaHora.ToString("dd/MM/yyyy"));
                row.CreateCell(j++).SetCellValue(partidos[i - 1].FechaHora.ToString("HH:mm"));
                row.CreateCell(j++).SetCellValue(partidos[i - 1].Pista);
                row.CreateCell(j++).SetCellValue(partidos[i - 1].Local);
                row.CreateCell(j++).SetCellValue(partidos[i - 1].Resultado.Local);
                row.CreateCell(j++).SetCellValue(partidos[i - 1].Resultado.Visitante);
                row.CreateCell(j++).SetCellValue(partidos[i - 1].Visitante);
            }

            // Obtener el arreglo de bytes del MemoryStream
            return workbook;
        }
    }
}
