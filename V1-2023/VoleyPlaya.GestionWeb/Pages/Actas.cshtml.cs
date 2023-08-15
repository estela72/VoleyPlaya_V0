using OfficeOpenXml;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VoleyPlaya.Domain.Enums;
using VoleyPlaya.Domain.Models;
using VoleyPlaya.Domain.Services;
using iText.Kernel.Geom;
using iText.Layout.Properties;

namespace VoleyPlaya.GestionWeb.Pages
{
    [Authorize(Policy = "CompeticionesOnly")]
    public class ActasModel : VPPageModel
    {
        public List<Partido> Partidos { get; set; }

        public ActasModel(IEdicionService service) : base(service)
        {
        }

        public async Task OnGetAsync(string prueba, int? competicion, int? categoria, string genero, int? grupo)
        {
            await FilterSelection(prueba, competicion, categoria, genero, grupo);

            await GetPartidosAsync();
        }

        private async Task GetPartidosAsync()
        {
            if (PruebaSelected == null || PruebaSelected.Equals("0"))
                return;
            if (CompeticionSelected == null)
                return;
            var categoria = 0;
            var grupo = 0;
            int.TryParse(CategoriaSelected, out categoria);
            int.TryParse(GrupoSelected, out grupo);
            Partidos = await _service.GetPartidosFiltradosAsync(PruebaSelected, int.Parse(CompeticionSelected), categoria, GeneroSelected, grupo);
        }
        public async Task<IActionResult> OnPostAsync(string pruebaId, int? competicionId, int? categoriaId, string generoId, int? grupoId)
        {
            try
            {
                if (string.IsNullOrEmpty(pruebaId) || pruebaId.Equals("0"))
                {
                    ErrorMessage = "Se debe indicar, al menos, la prueba";
                    await FilterSelection(pruebaId, competicionId,categoriaId,generoId,grupoId);
                    return Page();
                }
                if (competicionId == null)
                {
                    ErrorMessage = "Se debe indicar, al menos, la competición";
                    await FilterSelection(pruebaId, competicionId, categoriaId, generoId, grupoId);
                    return Page();
                }
                PruebaSelected = pruebaId;
                int categoria = categoriaId != null ? categoriaId.Value : 0;
                int grupo = grupoId != null ? grupoId.Value : 0;
                CompeticionSelected = competicionId is not null and > 0 ? competicionId.ToString() : null;
                CategoriaSelected = categoriaId is not null and > 0 ? categoria.ToString() : null;
                GeneroSelected = generoId;
                GrupoSelected = grupoId is not null and > 0 ? grupoId.ToString() : null;
                await GetPartidosAsync();

                var edicion = await _service.GetEdicionAsync(pruebaId, competicionId, categoriaId, generoId);
                if (edicion.ModeloCompeticion.Equals(EnumModeloCompeticion.JuegosDeportivos))
                    return await RellenarActasJuegosDeportivos(competicionId, categoriaId, generoId);
                else if (edicion.ModeloCompeticion.Equals(EnumModeloCompeticion.Circuito))
                    return await RellenarActasCircuito(competicionId, categoriaId, generoId);

            }
            catch (Exception x)
            {
                ErrorMessage = "Se ha producido un error: " + x.Message;
            }
            finally
            {
                
            }
            await FilterSelection(pruebaId, competicionId, categoriaId, generoId, grupoId);
            return Page();
        }

        private async Task<FileContentResult> RellenarActasCircuito(int? competicionId, int? categoriaId, string generoId)
        {
            var prueba = Partidos.First().Prueba;
            var comp = Partidos.First().Competicion;
            var cat = Partidos.First().Categoria;
            var gen = Partidos.First().Genero;
            var ronda = Partidos.First().Ronda.Equals("I") ? "GRUPOS" : "FINALES";

            var fName = $"ActasCircuito_" + prueba + "_" + comp + "_" + " " + cat + "_" + gen + "_" + ronda;
            var fileName = fName + ".xlsx";
            var fileNamePdf = fName + ".pdf";
            GenerarExcelCircuito(Partidos.Count, fileName, fileNamePdf);

            // Escribir el libro de Excel en un MemoryStream
            // Obtén la ruta del directorio personal del usuario
            string personalFolder = Environment.CurrentDirectory;

            byte[] fileByteArray = System.IO.File.ReadAllBytes(fileName);
            System.IO.File.Delete(fileName);
            return File(fileByteArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

        
        private async Task<FileContentResult> RellenarActasJuegosDeportivos(int? competicionId, int? categoriaId, string generoId)
        {
            var fileName = $"Actas_" + competicionId + " " + categoriaId + " " + generoId + ".xlsx";
            GenerarExcelJuegosDeportivos(Partidos.Count, fileName);

            // Escribir el libro de Excel en un MemoryStream
            // Obtén la ruta del directorio personal del usuario
            string personalFolder = Environment.CurrentDirectory;

            byte[] fileByteArray = System.IO.File.ReadAllBytes(fileName);
            System.IO.File.Delete(fileName);
            return File(fileByteArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

        public void GenerarExcelJuegosDeportivos(int numeroHojas, string destinationFilePath)
        {
            // Ruta de destino del archivo Excel
            string filePath = "wwwroot/excel/actaVPJuegosDeportivos.xlsx";

            System.IO.File.Copy(filePath, destinationFilePath, true);

            // Cargar el archivo Excel existente
            using (ExcelPackage package = new ExcelPackage(new FileInfo(destinationFilePath)))
            {
                // Obtener la primera hoja
                ExcelWorksheet primeraHoja = package.Workbook.Worksheets[0];
                
                // Crear copias de la primera hoja según el número de hojas especificado
                for (int i = 0; i < numeroHojas; i++)
                {
                    // Crear una nueva hoja en el archivo Excel
                    ExcelWorksheet nuevaHoja = package.Workbook.Worksheets.Add("Acta" + (i + 1), primeraHoja);
                    RellenarActaJD(Partidos[i], nuevaHoja);

                    // Ajustar el tamaño de las columnas para que coincidan con la primera hoja
                    //nuevaHoja.Cells.AutoFitColumns();
                }

                // Guardar los cambios en el archivo Excel
                package.Save();
            }
        }
        private void GenerarExcelCircuito(int numeroHojas, string destinationFilePath, string destinationFilePathPdf)
        {
            // Ruta de destino del archivo Excel
            string filePath = "wwwroot/excel/actaVoleyPlayaCircuito1Set.xlsx";

            System.IO.File.Copy(filePath, destinationFilePath, true);

            // Cargar el archivo Excel existente
            using (ExcelPackage package = new ExcelPackage(new FileInfo(destinationFilePath)))
            {
                // Obtener la primera hoja
                ExcelWorksheet primeraHoja = package.Workbook.Worksheets[0];

                // Crear copias de la primera hoja según el número de hojas especificado
                for (int i = 0; i < numeroHojas; i++)
                {
                    // Crear una nueva hoja en el archivo Excel
                    ExcelWorksheet nuevaHoja = package.Workbook.Worksheets.Add("Acta" + (i + 1), primeraHoja);
                    RellenarActaCircuito(Partidos[i], nuevaHoja);

                    // Ajustar el tamaño de las columnas para que coincidan con la primera hoja
                    //nuevaHoja.Cells.AutoFitColumns();
                }

                // Guardar los cambios en el archivo Excel
                package.Save();
            }
            ConvertExcelToPdf(destinationFilePath, destinationFilePathPdf);
        }

        private void RellenarActaJD(Partido partido, ExcelWorksheet nuevaHoja)
        {
            nuevaHoja.Cells["B4"].Value = partido.Competicion;
            nuevaHoja.Cells["F4"].Value = partido.Categoria;
            nuevaHoja.Cells["J4"].Value = partido.Genero;
            nuevaHoja.Cells["P4"].Value = partido.Grupo;
            nuevaHoja.Cells["E6"].Value = partido.FechaHora.ToString("dd/MM/yyyy");
            nuevaHoja.Cells["H6"].Value = partido.FechaHora.ToString("HH:mm");
            nuevaHoja.Cells["J6"].Value = partido.Pista;
            nuevaHoja.Cells["L6"].Value = partido.Label;
            nuevaHoja.Cells["P6"].Value = partido.Ronda;

            nuevaHoja.Cells["D9"].Value = partido.Local;
            nuevaHoja.Cells["J9"].Value = partido.Visitante;

            if (partido.Local==null)
                nuevaHoja.Cells["E10"].Value = "("+partido.NombreLocal+")";
            if (partido.Visitante == null)
                nuevaHoja.Cells["K10"].Value = "("+partido.NombreVisitante+")";

            nuevaHoja.Cells["F42"].Value = partido.Prueba;
        }

        private void RellenarActaCircuito(Partido partido, ExcelWorksheet nuevaHoja)
        {
            nuevaHoja.Cells["A7"].Value = "Asturias      " + partido.Prueba + "            " + partido.Competicion + "            " + partido.Categoria + "             " + partido.Genero;
            nuevaHoja.Cells["A10"].Value = "Nº de partido: "+partido.Label;
            nuevaHoja.Cells["G10"].Value = "Pista "+partido.Pista;
            nuevaHoja.Cells["O10"].Value = "Fecha: "+partido.FechaHora.ToString("dd/MM/yyyy");
            nuevaHoja.Cells["AA10"].Value = "Hora: "+ partido.FechaHora.ToString("HH:mm");
            nuevaHoja.Cells["AE10"].Value = partido.Ronda;
            nuevaHoja.Cells["AH10"].Value = "GRUPO " + partido.Grupo;

            nuevaHoja.Cells["D12"].Value = partido.Local;
            nuevaHoja.Cells["Z12"].Value = partido.Visitante;

            nuevaHoja.Cells["D30"].Value = partido.Local;
            nuevaHoja.Cells["R30"].Value = partido.Visitante;

            if (!string.IsNullOrEmpty(partido.Local))
            {
                var locales = partido.Local.Split('-');
                if (locales.Count() > 1)
                {
                    nuevaHoja.Cells["D32"].Value = locales[0].Trim();
                    nuevaHoja.Cells["D33"].Value = locales[1].Trim();
                }
            }
            if (!string.IsNullOrEmpty(partido.Visitante))
            {
                var visitantes = partido.Visitante.Split('-');
                if (visitantes.Count() > 1)
                {
                    nuevaHoja.Cells["Q32"].Value = visitantes[0].Trim();
                    nuevaHoja.Cells["Q33"].Value = visitantes[1].Trim();
                }
            }
        }
        public void ConvertExcelToPdf(string excelFilePath, string pdfFilePath)
        {
            //OfficeConverter.convertOfficeSpreadsheetToPdf(new FileInputStream(excelFilePath),
            // new FileOutputStream(pdfFilePath));

            //// Crear un documento PDF utilizando iText 7
            ////PdfWriter writer = new PdfWriter(pdfFilePath);
            //WriterProperties wp = new WriterProperties().UseSmartMode();
            //PdfWriter writer = new PdfWriter(pdfFilePath,wp);
            //PdfDocument pdfDocument = new PdfDocument(writer);
            //Document document = new Document(pdfDocument);
            //// Establecer la orientación del documento como horizontal (apaisada)
            ////document.SetDefaultPageSize(PageSize.A4.Rotate());

            //// Recorrer cada hoja del archivo Excel
            //foreach (var worksheet in excelPackage.Workbook.Worksheets)
            //{
            //    // Crear una tabla para la hoja actual
            //    Table table = new Table(worksheet.Dimension.Columns);

            //    // Recorrer cada celda de la hoja y agregarla a la tabla
            //    for (int row = worksheet.Dimension.Start.Row; row <= worksheet.Dimension.End.Row; row++)
            //    {
            //        for (int col = worksheet.Dimension.Start.Column; col <= worksheet.Dimension.End.Column; col++)
            //        {
            //            var cellValue = worksheet.Cells[row, col].Value;
            //            table.AddCell(cellValue?.ToString() ?? "");
            //        }
            //    }

            //    // Agregar la tabla al documento PDF
            //    document.Add(table);
            //}

            //// Cerrar el documento PDF
            //document.Close();
        }
    }
}
