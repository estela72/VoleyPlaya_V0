using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.Identity.Client;

using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.SS.UserModel;
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
    [Authorize(Policy = "EquiposOnly")]
    public class CalendariosModel : VPPageModel
    {
        public List<Partido> Partidos { get; set; }        

        public CalendariosModel(IEdicionService service) : base(service)
        {
        }

        public async Task OnGetAsync(int? competicion, int? categoria, string genero, int? grupo)
        {
            CompeticionSelected = competicion is not null and > 0 ? competicion.ToString() : null;
            CategoriaSelected = categoria is not null and > 0 ? categoria.ToString() : null;
            GeneroSelected = genero;
            GrupoSelected = grupo is not null and > 0 ? grupo.ToString() : null;

            Competiciones = await GetCompeticiones();
            Categorias = await GetCategorias();
            Generos = await GetGeneros();
            Grupos = await GetGrupos();

            await GetPartidosAsync();
        }

        private async Task GetPartidosAsync()
        {
            if (CompeticionSelected == null)
                return;
            var categoria = 0;
            var grupo = 0;
            int.TryParse(CategoriaSelected, out categoria);
            int.TryParse(GrupoSelected, out grupo);
            Partidos = await _service.GetPartidosFiltradosAsync(int.Parse(CompeticionSelected), categoria, GeneroSelected, grupo);
        }
        public async Task<IActionResult> OnPostExportarAsync(int? competicionId, int? categoriaId, string generoId, int? grupoId)
        {
            try
            {
                if (competicionId==null)
                {
                    ErrorMessage = "Se debe indicar, al menos, la competición";
                    return Page();
                }
                int categoria = categoriaId !=null ? categoriaId.Value:0;
                int grupo = grupoId !=null? grupoId.Value:0;

                // Exportar a excel el calendario seleccionado
                var data = await _service.ExportarCalendarioAsync(competicionId.Value, categoria, generoId, grupo);

                // Obtén la ruta del directorio personal del usuario
                string personalFolder = Environment.CurrentDirectory;
                // Nombre del fichero
                string fName = $"Calendario_" + data.edicion + "Grupo" + data.grupo + ".xlsx";
                // Concatena el nombre de la carpeta "Descargas" en la ruta
                string fileName = System.IO.Path.Combine(personalFolder, fName);
                // Nombre de la hoja
                string sheetName = "calendario";

                // Escribir el libro de Excel en un MemoryStream
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    IWorkbook workbook = GenerarExcelFile(fileName, sheetName, data.partidos);//, data.edicion, data.grupo);
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

        private IWorkbook GenerarExcelFile(string fileName, string sheetName, List<Partido> partidos)//, Edicion edicion, EdicionGrupo grupo)
        {
            // Crear un nuevo libro de Excel
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Hoja1");

            IRow row = sheet.CreateRow(0);

            int j = 0;
            row.CreateCell(j++).SetCellValue("Id");
            row.CreateCell(j++).SetCellValue("Competición");
            row.CreateCell(j++).SetCellValue("Categoria");
            row.CreateCell(j++).SetCellValue("Género");
            row.CreateCell(j++).SetCellValue("Grupo");
            row.CreateCell(j++).SetCellValue("Jornada");
            row.CreateCell(j++).SetCellValue("Nº Partido");
            row.CreateCell(j++).SetCellValue("Fecha");
            row.CreateCell(j++).SetCellValue("Hora");
            row.CreateCell(j++).SetCellValue("Pista");
            row.CreateCell(j++).SetCellValue("Local");
            row.CreateCell(j++).SetCellValue("R. local");
            row.CreateCell(j++).SetCellValue("R. visitante");
            row.CreateCell(j++).SetCellValue("Visitante");
            row.CreateCell(j).SetCellValue("Set1");
            row.CreateCell(j+=2).SetCellValue("Set2");
            row.CreateCell(j+=2).SetCellValue("Set3");

            // Escribir los datos en las celdas del libro de Excel
            for (int i = 1; i <= partidos.Count; i++)
            {
                row = sheet.CreateRow(i);
                j = 0;
                row.CreateCell(j++).SetCellValue(partidos[i - 1].Id);
                row.CreateCell(j++).SetCellValue(partidos[i - 1].Competicion);
                row.CreateCell(j++).SetCellValue(partidos[i - 1].Categoria);
                row.CreateCell(j++).SetCellValue(partidos[i - 1].Genero);
                row.CreateCell(j++).SetCellValue(partidos[i - 1].Grupo);
                row.CreateCell(j++).SetCellValue(partidos[i - 1].Jornada);
                row.CreateCell(j++).SetCellValue(partidos[i - 1].Label);
                row.CreateCell(j++).SetCellValue(partidos[i - 1].FechaHora.ToString("dd/MM/yyyy"));
                row.CreateCell(j++).SetCellValue(partidos[i - 1].FechaHora.ToString("HH:mm"));
                row.CreateCell(j++).SetCellValue(partidos[i - 1].Pista);
                row.CreateCell(j++).SetCellValue(partidos[i - 1].Local);
                row.CreateCell(j++).SetCellValue(partidos[i - 1].Resultado.Local);
                row.CreateCell(j++).SetCellValue(partidos[i - 1].Resultado.Visitante);
                row.CreateCell(j++).SetCellValue(partidos[i - 1].Visitante);
                row.CreateCell(j++).SetCellValue(partidos[i - 1].Resultado.Set1.Local);
                row.CreateCell(j++).SetCellValue(partidos[i - 1].Resultado.Set1.Visitante);
                row.CreateCell(j++).SetCellValue(partidos[i - 1].Resultado.Set2.Local);
                row.CreateCell(j++).SetCellValue(partidos[i - 1].Resultado.Set2.Visitante);
                row.CreateCell(j++).SetCellValue(partidos[i - 1].Resultado.Set3.Local);
                row.CreateCell(j++).SetCellValue(partidos[i - 1].Resultado.Set3.Visitante);
            }
            // Establecer el estilo de las columnas que se pueden modificar:
            // - Columna 8: DateTime (hora)
            // - Columna 9: String   (pista)
            SetCellStyles(workbook, sheet);
            return workbook;
        }
        void SetCellStyles(IWorkbook workbook,ISheet sheet)
        {
            int columnIndexPista = 9; // Índice de la columna que deseas modificar
            int columnIndexHora = 8; 

            int startRow = 1; // Fila de inicio (puedes ajustarlo según tus necesidades)
            int endRow = sheet.LastRowNum; // Fila final (puedes ajustarlo según tus necesidades)

            for (int rowIndex = startRow; rowIndex <= endRow; rowIndex++)
            {
                IRow row = sheet.GetRow(rowIndex);
                if (row != null)
                {
                    NPOI.SS.UserModel.ICell cellPista = row.GetCell(columnIndexPista);
                    cellPista.SetCellType(CellType.String); // Establece el tipo de celda como String

                    NPOI.SS.UserModel.ICell cellHora = row.GetCell(columnIndexHora);
                    ICellStyle cellStyle = workbook.CreateCellStyle();
                    cellStyle.DataFormat = workbook.CreateDataFormat().GetFormat("HH:mm"); // Establece el formato de hora
                    cellHora.CellStyle = cellStyle;
                }
            }

        }
        public async Task<IActionResult> OnPostImportarAsync(IFormFile file, int? competicionId, int? categoriaId, string generoId, int? grupoId)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    // Manejar el caso en que no se seleccionó ningún archivo
                    ModelState.AddModelError("file", "Por favor selecciona un archivo Excel.");
                    return Page();
                }

                if (competicionId == null)
                {
                    ErrorMessage = "Se debe indicar, al menos, la competición";
                    return Page();
                }
                CompeticionSelected = competicionId.ToString();
                int categoria = categoriaId != null ? categoriaId.Value : 0;
                int grupo = grupoId != null ? grupoId.Value : 0;
                List<Partido> partidos = new List<Partido>();
                using (var stream = file.OpenReadStream())
                {
                    IWorkbook workbook = new XSSFWorkbook(stream); // Crea un nuevo workbook de Excel

                    ISheet sheet = workbook.GetSheetAt(0); // Obtén la primera hoja de cálculo
                                                           // Obtener los datos existentes en la base de datos

                    for (int row = 1; row <= sheet.LastRowNum; row++)
                    {
                        try
                        {
                            IRow excelRow = sheet.GetRow(row); // Obtén la fila actual

                            if (excelRow != null)
                            {
                                int id = Convert.ToInt32(excelRow.GetCell(0)?.ToString()); // Obtén el valor de la primera columna
                                                                                           //DateTime hora = Convert.ToDateTime(excelRow.GetCell(8)?.ToString()); // Obtén el valor de la segunda columna
                                DateTime hora = new DateTime(1989, 1, 1, 10, 0, 0);
                                if (excelRow.GetCell(8).CellType == CellType.Numeric && DateUtil.IsCellDateFormatted(excelRow.GetCell(8)))
                                {
                                    hora = excelRow.GetCell(8).DateCellValue;
                                }
                                else
                                    hora = Convert.ToDateTime(excelRow.GetCell(8).ToString());

                                string pista = "";
                                if (excelRow.GetCell(9).CellType == CellType.Numeric)
                                    pista = excelRow.GetCell(9)?.ToString();
                                else if (excelRow.GetCell(9).CellType == CellType.String)
                                    pista = excelRow.GetCell(9).StringCellValue;

                                partidos.Add(new Partido { Id = id, FechaHora = hora, Pista = pista });
                            }
                        }
                        catch(Exception x)
                        {
                            ErrorMessage += "Error al actualizar la fila " + row + "\n\r";
                        }
                    }
                }
                await _service.UpdatePartidosFromExcelAsync(partidos);
                GetPartidosAsync();
                return Page();
            }
            catch (Exception x)
            {
                ErrorMessage += "Se ha producido un error: " + x.Message;
                return Page();
            }
        }
    }
}
