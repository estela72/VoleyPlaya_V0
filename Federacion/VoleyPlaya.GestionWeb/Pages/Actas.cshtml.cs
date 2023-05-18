using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.Identity.Client;

using NPOI.HPSF;
using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.XWPF.UserModel;

using OfficeOpenXml;

using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

using VoleyPlaya.Domain.Models;
using VoleyPlaya.Domain.Services;
using VoleyPlaya.GestionWeb.Infrastructure;

using ICell = NPOI.SS.UserModel.ICell;

namespace VoleyPlaya.GestionWeb.Pages
{
    [Authorize(Policy = "CompeticionesOnly")]
    public class ActasModel : VPPageModel
    {
        public List<Partido> Partidos { get; set; }

        public ActasModel(IEdicionService service) : base(service)
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
        public async Task<IActionResult> OnPostAsync(int? competicionId, int? categoriaId, string generoId, int? grupoId)
        {
            try
            {
                if (competicionId == null)
                {
                    ErrorMessage = "Se debe indicar, al menos, la competición";
                    return Page();
                }
                int categoria = categoriaId != null ? categoriaId.Value : 0;
                int grupo = grupoId != null ? grupoId.Value : 0;
                CompeticionSelected = competicionId is not null and > 0 ? competicionId.ToString() : null;
                CategoriaSelected = categoriaId is not null and > 0 ? categoria.ToString() : null;
                GeneroSelected = generoId;
                GrupoSelected = grupoId is not null and > 0 ? grupoId.ToString() : null;
                await GetPartidosAsync();

                var fileName = $"Actas_" + competicionId + " " + categoriaId + " " + generoId + " " + grupoId + ".xlsx";
                GenerarExcel(Partidos.Count, fileName);

                // Escribir el libro de Excel en un MemoryStream
                // Obtén la ruta del directorio personal del usuario
                string personalFolder = Environment.CurrentDirectory;

                byte[] fileByteArray = System.IO.File.ReadAllBytes(fileName);
                System.IO.File.Delete(fileName);
                return File(fileByteArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
            catch (Exception x)
            {
                ErrorMessage = "Se ha producido un error: " + x.Message;
                return Page();
            }
        }
        public void GenerarExcel(int numeroHojas, string destinationFilePath)
        {
            // Ruta de destino del archivo Excel
            string filePath = "wwwroot/excel/actaVPJuegosDeportivos.xlsx";
            //string destinationFilePath = "wwwroot/excel/temporal.xlsx";

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
                    RellenarActa(Partidos[i], nuevaHoja);

                    // Ajustar el tamaño de las columnas para que coincidan con la primera hoja
                    nuevaHoja.Cells.AutoFitColumns();
                }

                // Guardar los cambios en el archivo Excel
                package.Save();
            }
        }

        private void RellenarActa(Partido partido, ExcelWorksheet nuevaHoja)
        {
            nuevaHoja.Cells["B4"].Value = partido.Competicion;
            nuevaHoja.Cells["G4"].Value = partido.Categoria;
            nuevaHoja.Cells["J4"].Value = partido.Genero;
            nuevaHoja.Cells["P4"].Value = partido.Grupo;
            nuevaHoja.Cells["E6"].Value = partido.FechaHora.ToString("dd/MM/yyyy");
            nuevaHoja.Cells["H6"].Value = partido.FechaHora.ToString("HH:mm");
            nuevaHoja.Cells["J6"].Value = partido.Pista;
            nuevaHoja.Cells["L6"].Value = partido.Label;

            nuevaHoja.Cells["D9"].Value = partido.Local;
            nuevaHoja.Cells["J9"].Value = partido.Visitante;

            nuevaHoja.Cells["F42"].Value = partido.Lugar;
        }
    }
}
