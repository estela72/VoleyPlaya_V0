using Ligamania.Web.Models;

using Microsoft.AspNetCore.Http;

using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Web.Helpers
{
    public static class CalendarParser
    {
        public static bool Parse(CalendarioVM calendario, IFormFile file, string folderName, string webRootPath)
        {
            string newPath = Path.Combine(webRootPath, folderName);
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
                    for (int j = 0; j < cellCount; j++)
                    {
                        NPOI.SS.UserModel.ICell cell = headerRow.GetCell(j);
                        if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                    }
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
                                if (j == 1) jornada = (int)row.GetCell(j).NumericCellValue;
                                if (j == 2) local = row.GetCell(j).ToString();
                                if (j == 3) visitante = row.GetCell(j).ToString();
                            }
                        }
                        if (jornada != -1 && !string.IsNullOrEmpty(local) && !string.IsNullOrEmpty(visitante))
                            calendario.Partidos.Add(new CalendarioDetalleVM { Jornada = jornada, Local = local, Visitante = visitante });
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
