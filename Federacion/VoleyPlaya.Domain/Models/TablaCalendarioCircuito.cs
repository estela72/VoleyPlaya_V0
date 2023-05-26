using AutoMapper;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

using NPOI.OpenXmlFormats.Dml.Chart;

using OfficeOpenXml;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Repository.Services;

namespace VoleyPlaya.Domain.Models
{
    public class PartidoCalendarioCircuito
    {
        public int NumEquipos { get; set; }
        public int NumPartido { get; set; }
        public string Ronda { get; set; }
        public string Equipo1 { get; set; }
        public string Equipo2 { get; set; }
        public int Jornada { get; set; }
        public int NumGrupos { get; set; }
        public string Nombre { get; set; }
    }
    public class TablaCalendarioCircuito
    {
        private readonly IVoleyPlayaService _service;
        private readonly IMapper _mapper;
        public TablaCalendarioCircuito(IVoleyPlayaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task LoadAsync()
        {
            List<PartidoCalendarioCircuito> partidos = new List<PartidoCalendarioCircuito>();
            // Ruta de destino del archivo Excel
            string filePath = "wwwroot/excel/calendarios.xlsx";

            // Cargar el archivo Excel existente
            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                // recorremos todas las hojas
                foreach (ExcelWorksheet sheet in package.Workbook.Worksheets)
                {
                    var nombre = sheet.Name;
                    int numequipos = -1;
                    int numgrupos = 1;
                    if (nombre.Contains("EQUIPOS"))
                    {
                        numequipos = Convert.ToInt32(nombre.Split(' ').First());
                    }
                    else if (nombre.Contains("GRUPOS")) // para cargar cruces y fase final de las competiciones con grupos
                    {
                        numgrupos = Convert.ToInt32(nombre.Split(' ').First());
                    }
                    for (int i = 2; i <= sheet.Dimension.Rows; i++)
                    {
                        try
                        {
                            int numPartido = Convert.ToInt32(sheet.Cells[i, 1].Value);
                            string ronda = sheet.Cells[i, 2].Value.ToString();
                            string local = sheet.Cells[i, 3].Value.ToString();
                            string visitante = sheet.Cells[i, 4].Value.ToString();
                            int jornada = Convert.ToInt32(sheet.Cells[i, 5].Value);
                            partidos.Add(new PartidoCalendarioCircuito
                            {
                                NumEquipos = numequipos,
                                NumPartido = numPartido,
                                Ronda = ronda,
                                Equipo1 = local,
                                Equipo2 = visitante,
                                Jornada = jornada,
                                NumGrupos = numgrupos,
                                Nombre = nombre+"-Partido"+numPartido
                            });
                        }
                        catch (Exception x)
                        {

                        }
                    }
                }
            }
            // Guardar en base de datos las tablas

            await _service.SaveTablaCalendarios(_mapper.Map<List<VoleyPlaya.Repository.Models.TablaCalendario>>(partidos));
            
        }
        
        public async Task<List<PartidoCalendarioCircuito>> GetPartidosByNumGrupo(int numGrupos)
        {
            var partidos = await _service.GetCalendarioPartidosCircuitoByNumGrupos(numGrupos);

            return _mapper.Map<List<PartidoCalendarioCircuito>>(partidos);
        }
    }
}
