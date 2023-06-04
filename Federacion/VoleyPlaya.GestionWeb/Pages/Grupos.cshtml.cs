using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.Identity.Client;

using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using NPOI.XWPF.UserModel;

using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

using VoleyPlaya.Domain.Models;
using VoleyPlaya.Domain.Services;
using VoleyPlaya.GestionWeb.Infrastructure;

namespace VoleyPlaya.GestionWeb.Pages
{
    [AllowAnonymous]
    public class GruposModel : VPPageModel
    {
        public List<EdicionGrupo> Grupos { get; set; }        

        public GruposModel(IEdicionService service) : base(service)
        {
        }

        public async Task<IActionResult> OnGetAsync(string prueba, int? competicion, int? categoria, string genero)
        {
            await FilterSelection(prueba, competicion, categoria, genero, 0);

            await GetGruposAsync();
            return Page();
        }

        private async Task GetGruposAsync()
        {
            if (string.IsNullOrEmpty(PruebaSelected) || PruebaSelected.Equals("0") || CompeticionSelected==null||CategoriaSelected==null||GeneroSelected==null||GeneroSelected=="0")
                return;
            var categoria = 0;
            var grupo = 0;
            int.TryParse(CategoriaSelected, out categoria);
            Grupos = await _service.GetAllGruposAsync(PruebaSelected,int.Parse(CompeticionSelected), categoria, GeneroSelected);
        }
        public async Task<IActionResult> OnPostExportarAsync(string pruebaId, int? competicionId, int? categoriaId, string generoId)
        {
            try
            {
                if (pruebaId == null)
                {
                    ErrorMessage = "Se debe indicar, al menos, la prueba";
                    await FilterSelection(pruebaId, competicionId, categoriaId, generoId, 0);
                    return Page();
                }
                if (competicionId==null)
                {
                    ErrorMessage = "Se debe indicar, al menos, la competición";
                    await FilterSelection(pruebaId, competicionId, categoriaId, generoId, 0);
                    return Page();
                }
                PruebaSelected = pruebaId;
                int categoria = categoriaId !=null ? categoriaId.Value:0;
                CompeticionSelected = competicionId is not null and > 0 ? competicionId.ToString() : null;
                CategoriaSelected = categoriaId is not null and > 0 ? categoria.ToString() : null;
                GeneroSelected = generoId;
                await GetGruposAsync();

                // Exportar a excel la información de los grupos
                //var data = await _service.ExportarGruposAsync(competicionId.Value, categoria, generoId);

                // Obtén la ruta del directorio personal del usuario
                string personalFolder = Environment.CurrentDirectory;
                // Nombre del fichero
                string fName = $"InfoGrupos_" + Grupos.First().Edicion.Nombre + ".xlsx";
                // Concatena el nombre de la carpeta "Descargas" en la ruta
                string fileName = System.IO.Path.Combine(personalFolder, fName);
                // Nombre de la hoja
                string sheetName = "grupos";

                // Escribir el libro de Excel en un MemoryStream
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    IWorkbook workbook = GenerarExcelFile(fileName, sheetName, Grupos.First().Edicion.Alias, Grupos.First().Edicion.CategoriaStr + " " + Grupos.First().Edicion.GeneroStr);
                    workbook.Write(fs, true);
                    workbook.Close();
                }
                byte[] fileByteArray = System.IO.File.ReadAllBytes(fileName);
                System.IO.File.Delete(fileName);
                return File(fileByteArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fName);
            }
            catch (Exception x)
            {
                ErrorMessage= "Se ha producido un error: "+x.Message;
                return Page();
            }
        }

        private IWorkbook GenerarExcelFile(string fileName, string sheetName, string competicion, string categoria)
        {
            // Crear un nuevo libro de Excel
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet(categoria);

            #region Grupo
            // Estilo para el titulo de cada grupo
            var cellStyleGrupo = workbook.CreateCellStyle();
            cellStyleGrupo.Alignment = HorizontalAlignment.Center;
            cellStyleGrupo.VerticalAlignment = VerticalAlignment.Center;
            cellStyleGrupo.BorderLeft = cellStyleGrupo.BorderRight = cellStyleGrupo.BorderTop = cellStyleGrupo.BorderBottom = BorderStyle.None;
            // Obtener la fuente y aplicar estilos
            var fontGrupo = workbook.CreateFont();
            fontGrupo.FontHeightInPoints = 16; // Tamaño de letra más grande
            fontGrupo.Boldweight = (short)FontBoldWeight.Bold; // Negrita
            cellStyleGrupo.SetFont(fontGrupo);

            // Estilo para la cabecera de los equipos
            var cellStyleHeader = workbook.CreateCellStyle();
            cellStyleHeader.Alignment = HorizontalAlignment.Center;
            cellStyleHeader.VerticalAlignment = VerticalAlignment.Center;
            cellStyleHeader.BorderLeft = cellStyleHeader.BorderRight = cellStyleHeader.BorderTop = cellStyleHeader.BorderBottom = BorderStyle.Thin;
            // Obtener la fuente y aplicar estilos
            var fontHeader = workbook.CreateFont();
            fontHeader.FontHeightInPoints = 12; // Tamaño de letra más grande
            fontHeader.Boldweight = (short)FontBoldWeight.Normal; // Negrita
            cellStyleHeader.SetFont(fontHeader);

            // Estilo para los equipos
            var cellStyleEquipo = workbook.CreateCellStyle();
            cellStyleEquipo.Alignment = HorizontalAlignment.Center;
            cellStyleEquipo.VerticalAlignment = VerticalAlignment.Center;
            cellStyleEquipo.BorderLeft = cellStyleEquipo.BorderRight = cellStyleEquipo.BorderTop = cellStyleEquipo.BorderBottom = BorderStyle.Thin;
            // Obtener la fuente y aplicar estilos
            var fontEquipo = workbook.CreateFont();
            fontEquipo.FontHeightInPoints = 11; // Tamaño de letra más grande
            fontEquipo.Boldweight = (short)FontBoldWeight.Normal; // Negrita
            cellStyleEquipo.SetFont(fontEquipo);
            #endregion

            IRow row = sheet.CreateRow(0);

            int j = 0;
            row.CreateCell(1).SetCellValue(competicion);
            int indexRow = 3;
            foreach(var grupo in Grupos)
            {
                row = sheet.CreateRow(indexRow++);
                row.CreateCell(2).SetCellValue("Grupo "+grupo.Name);
                row.GetCell(2).CellStyle = cellStyleGrupo;

                row = sheet.CreateRow(indexRow++);
                row.CreateCell(1).SetCellValue("POS");
                row.CreateCell(2).SetCellValue("Equipo");
                row.CreateCell(3).SetCellValue("JUG");
                row.CreateCell(4).SetCellValue("GAN");
                row.CreateCell(5).SetCellValue("PER");
                row.CreateCell(6).SetCellValue("PF");
                row.CreateCell(7).SetCellValue("PC");
                row.CreateCell(8).SetCellValue("PUNTOS");
                row.CreateCell(9).SetCellValue("COEF");
                for (int i = 1; i <= 9; i++)
                    row.GetCell(i).CellStyle = cellStyleHeader;

                foreach (var equipo in grupo.Equipos)
                {
                    row = sheet.CreateRow(indexRow++);
                    row.CreateCell(1).SetCellValue(equipo.Posicion);
                    row.CreateCell(2).SetCellValue(equipo.Nombre);
                    row.CreateCell(3).SetCellValue(equipo.Jugados);
                    row.CreateCell(4).SetCellValue(equipo.Ganados);
                    row.CreateCell(5).SetCellValue(equipo.Perdidos);
                    row.CreateCell(6).SetCellValue(equipo.PuntosFavor);
                    row.CreateCell(7).SetCellValue(equipo.PuntosContra);
                    row.CreateCell(8).SetCellValue(equipo.Puntos);
                    row.CreateCell(9).SetCellValue(equipo.Coeficiente.ToString("0.000"));
                    for (int i = 1; i <= 9; i++)
                        row.GetCell(i).CellStyle = cellStyleEquipo;
                }
                indexRow += 2;
            }
            // Ajustar el ancho de todas las columnas al contenido
            for (int i = 0; i < 10; i++)
            {
                sheet.AutoSizeColumn(i);
            }
            SetCellStyles(workbook, sheet);
            return workbook;
        }
        void SetCellStyles(IWorkbook workbook,ISheet sheet)
        {
            #region Titulo de competición
            // Agrupar las celdas
            var cellRange = new CellRangeAddress(0, 0, 1, 9);
            sheet.AddMergedRegion(cellRange);

            // Obtener el estilo de celda para combinar y centrar
            var cellStyleTit = workbook.CreateCellStyle();
            cellStyleTit.Alignment = HorizontalAlignment.Center;
            cellStyleTit.VerticalAlignment = VerticalAlignment.Center;
            cellStyleTit.BorderLeft = cellStyleTit.BorderRight = cellStyleTit.BorderTop = cellStyleTit.BorderBottom = BorderStyle.Medium;
            // Obtener la fuente y aplicar estilos
            var fontTit = workbook.CreateFont();
            fontTit.FontHeightInPoints = 18; // Tamaño de letra más grande
            fontTit.Boldweight = (short)FontBoldWeight.Bold; // Negrita
            cellStyleTit.SetFont(fontTit);

            // Aplicar el estilo a las celdas combinadas
            for (int i = cellRange.FirstRow; i <= cellRange.LastRow; i++)
            {
                var rr = sheet.GetRow(i);
                for (int xx = cellRange.FirstColumn; xx <= cellRange.LastColumn; xx++)
                {
                    var cell = rr.GetCell(xx);
                    if (cell == null)
                        cell = rr.CreateCell(xx);
                    cell.CellStyle = cellStyleTit;
                }
            }
            #endregion
        }
    }
}
