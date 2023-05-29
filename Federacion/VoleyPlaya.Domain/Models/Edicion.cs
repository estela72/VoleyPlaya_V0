
using MathNet.Numerics.LinearAlgebra.Solvers;
using MathNet.Numerics.Optimization.TrustRegion;

using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;

using NPOI.SS.Formula.Eval;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Nodes;

using VoleyPlaya.Domain.Services;
using VoleyPlaya.Repository.Models;
using VoleyPlaya.Repository.Services;

namespace VoleyPlaya.Domain.Models
{
    public class SelectionItem
    {
        public int Id { get; set; }
        public string Item { get; set; }
    }
    public class Edicion : IDomainDto
    {
        public int Id { get; set; }
        [Required]
        public string Temporada { get; set; }
        public string Nombre { get; set; }
        [Required]
        public string Competicion { get; set; }
        [Required]
        public EnumCategorias Categoria { get; set; }
        [Required]
        public EnumGeneros Genero { get; set; }
        [Display(Name = "Nº de Grupos")]
        public int NumGrupos { get { return Grupos.Count; } }
        [Display(Name = "Nº de Jornadas")]
        public int NumJornadas { get { return FechasJornadas.Count; }}
        [Display(Name = "Nº de Equipos")]
        public int NumEquipos { get { return Equipos.Count; } }
        [Required]
        public string Prueba { get; set; }
        public List<EdicionGrupo> Grupos { get; set; }
        public List<FechaJornada> FechasJornadas { get; set; }
        public List<Equipo> Equipos { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoCalendario { get; set; }

        public string CategoriaStr { get => Enum.GetName(typeof(EnumCategorias), Categoria); }
        public string GeneroStr { get => Enum.GetName(typeof(EnumGeneros), Genero); }
        public string Alias { get { return Competicion + " " + CategoriaStr + " " + GeneroStr; } }

        public List<Equipo> EquiposToAdd;
        public List<Equipo> EquiposToRemove;

        public EnumModeloCompeticion ModeloCompeticion { get; set; }
        public string ModeloCompeticionStr { get => Enum.GetName(typeof(EnumModeloCompeticion), ModeloCompeticion); }

        public Edicion()
        {
            Temporada = DateTime.Now.Year.ToString();
            Competicion = EnumCompeticiones.Competiciones[0];
            Categoria = EnumCategorias.None;
            Genero = EnumGeneros.None;
            Nombre = "";
            //NumJornadas = 0;
            FechasJornadas = new List<FechaJornada>();
            Fecha = DateTime.Now;
            Prueba = string.Empty;
            TipoCalendario = string.Empty;
            Grupos = new List<EdicionGrupo>();
            Equipos = new List<Equipo>();
            ModeloCompeticion = EnumModeloCompeticion.Circuito;
        }
        public static Edicion FromJson(JsonNode jsonEdicion, bool mapGrupos=true)
        {
            Edicion edicion = new Edicion();
            edicion.Id = jsonEdicion["Id"]!.GetValue<int>();
            edicion.Temporada = NombreFromJson(jsonEdicion["Temporada"]!);
            edicion.Competicion = NombreFromJson(jsonEdicion["Competicion"]!);
            Enum.TryParse(NombreFromJson(jsonEdicion["Categoria"]!), out EnumCategorias categoria);
            edicion.Categoria = categoria;
            Enum.TryParse(jsonEdicion["Genero"]!.GetValue<string>(), out EnumGeneros genero);
            edicion.Genero = genero;
            if (mapGrupos && jsonEdicion["Grupos"]!=null) edicion.Grupos = GruposFromJson(jsonEdicion["Grupos"]!.AsArray());
            //edicion.NumGrupos = edicion.Grupos.Count();
            edicion.Fecha = jsonEdicion["UpdatedDate"]!.GetValue<DateTime>();
            edicion.Nombre = jsonEdicion["Nombre"]!.GetValue<string>();
            edicion.FechasJornadas = JornadasFromJson(jsonEdicion["Jornadas"]!.AsArray());
            edicion.Equipos = EquiposFromJson(jsonEdicion["Equipos"]!.AsArray());
            //edicion.NumJornadas = edicion.FechasJornadas.Count();
            edicion.Prueba = jsonEdicion["Prueba"]!.GetValue<string>();
            edicion.TipoCalendario = jsonEdicion["TipoCalendario"]!.GetValue<string>();
            Enum.TryParse(NombreFromJson(jsonEdicion["ModeloCompeticion"]!), out EnumModeloCompeticion modeloCompeticion);
            edicion.ModeloCompeticion = modeloCompeticion;
            return edicion;
        }
        private static string NombreFromJson(JsonNode jsonNode)
        {
            if (jsonNode !=null)
                return jsonNode["Nombre"]!.GetValue<string>();
            return "";
        }
        
        private static List<FechaJornada> JornadasFromJson(JsonArray jsonJornadas)
        {
            List<FechaJornada> jornadas = new List<FechaJornada>();
            foreach (var jornada in jsonJornadas)
                jornadas.Add(FechaJornada.FromJson(jornada!));
            return jornadas;
        }
        private static List<EdicionGrupo> GruposFromJson(JsonArray jsonGrupos)
        {
            List<EdicionGrupo> grupos = new List<EdicionGrupo>();
            foreach (var grupo in jsonGrupos)
                grupos.Add(EdicionGrupo.FromJson(grupo!));
            return grupos;
        }
        private static List<Equipo> EquiposFromJson(JsonArray jsonEquipos)
        {
            List<Equipo> equipos = new List<Equipo>();
            foreach (var equipo in jsonEquipos)
                equipos.Add(Equipo.FromJson(equipo!));
            return equipos;
        }
        [Obsolete]
        public void UpdateJornadas(int numJornadas)
        {
            for (int i = FechasJornadas.Count; i < numJornadas; i++)
                FechasJornadas.Add(new FechaJornada(i + 1));
            if (FechasJornadas.Count > numJornadas)
                FechasJornadas.RemoveRange(numJornadas, FechasJornadas.Count - numJornadas);
            //NumJornadas = numJornadas;
        }

        [Obsolete]
        public void UpdateGrupos(int numGrupos)
        {
            for (int i = Grupos.Count; i < numGrupos; i++)
                Grupos.Add(new EdicionGrupo());
            if (Grupos.Count > numGrupos)
                Grupos.RemoveRange(numGrupos, Grupos.Count - numGrupos);
            //NumGrupos = numGrupos ;
        }
        [Obsolete]
        public void UpdateEquipos(int numEquipos)
        {
            for (int i = Equipos.Count; i < numEquipos; i++)
                Equipos.Add(new Equipo(i + 1, "Equipo " + (i + 1) + " a completar"));
            if (Equipos.Count > numEquipos)
                Equipos.RemoveRange(numEquipos, Equipos.Count - numEquipos);
            //NumEquipos = Equipos.Count;
        }

        private double obtenerPuntos(Equipo equipo)
        {
            return equipo.Puntos + equipo.Coeficiente;
        }

        private Dictionary<string, List<Equipo>> ClasificarEquipos()
        {
            // Generar grupos y clasificar equipos
            Dictionary<string, List<Equipo>> grupos = GenerarGrupos();
            Dictionary<string, List<Equipo>> clasificacion = new Dictionary<string, List<Equipo>>();

            foreach (var grupo in grupos.Keys)
            {
                List<Equipo> equiposGrupo = grupos[grupo];
                //equiposGrupo.Sort(); // Ordenar equipos alfabéticamente
                equiposGrupo.Sort((equipo1, equipo2) => Comparer<double>.Default.Compare(obtenerPuntos(equipo2), obtenerPuntos(equipo1)));
                clasificacion.Add(grupo, equiposGrupo);
            }

            return clasificacion;
        }

        private Dictionary<string, List<Equipo>> GenerarGrupos()
        {
            // Dividir los equipos en grupos en función del número de grupos especificado
            Dictionary<string, List<Equipo>> grupos = new Dictionary<string, List<Equipo>>();
            for (int i = 0; i < NumGrupos; i++)
            {
                string grupo = Grupos[i].Name;
                grupos.Add(grupo, new List<Equipo>());
                foreach (Equipo equipo in Grupos[i].Equipos)
                    grupos[grupo].Add(equipo);
            }
            return grupos;
        }

        public async Task<string> ImportEquipos(IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                IWorkbook workbook = new XSSFWorkbook(stream); // Crea un nuevo workbook de Excel

                ISheet sheet = workbook.GetSheetAt(0); // Obtén la primera hoja de cálculo
                                                       // Obtener los datos existentes en la base de datos
                var equiposExistentes = Equipos;
                List<Equipo> nuevosEquipos = new List<Equipo>();
                List<Equipo> equiposABorrar = new List<Equipo>();

                for (int row = 1; row <= sheet.LastRowNum; row++)
                {
                    IRow excelRow = sheet.GetRow(row); // Obtén la fila actual

                    if (excelRow != null)
                    {
                        int posicion = Convert.ToInt32(excelRow.GetCell(0)?.ToString()); // Obtén el valor de la primera columna
                        string nombre = excelRow.GetCell(1)?.ToString()!.ToUpper(); // Obtén el valor de la segunda columna

                        // Verificar si el equipo ya existe en la base de datos
                        var equipoExistente = equiposExistentes.FirstOrDefault(e => e.Nombre == nombre);

                        // Si el equipo no existe en la base de datos, agregarlo a la lista de nuevos equipos
                        if (equipoExistente == null)
                        {
                            nuevosEquipos.Add(new Equipo { OrdenEntrada = posicion, Nombre = nombre });
                        }
                        // Si el equipo existe en la base de datos, actualizar su nombre
                        else
                        {
                            equipoExistente.OrdenEntrada = posicion;
                        }
                    }
                }
                // Eliminar los equipos existentes en la base de datos que no se encuentren en el archivo Excel
                foreach (var equipoExistente in equiposExistentes)
                {
                    if (!nuevosEquipos.Any(e => e.Nombre == equipoExistente.Nombre))
                    {
                        equiposExistentes.Remove(equipoExistente);
                        equiposABorrar.Add(equipoExistente);
                    }
                }
                EquiposToAdd = nuevosEquipos;
                EquiposToRemove = equiposABorrar;
            }
            return "La importación del archivo Excel se completó con éxito.";
        }
        // devuelva el numero de jornadas
        public async Task<bool> GenerarFaseGruposAsync(string calendario)
        {
            TipoCalendario = calendario;

            if (ModeloCompeticion.Equals(EnumModeloCompeticion.JuegosDeportivos))
                return await GenerarFaseGruposJuegosDeportivosAsync(calendario);
            else
                return await GenerarFaseGruposCircuitoAsync(calendario);
        }

        private async Task<bool> GenerarFaseGruposCircuitoAsync(string calendario)
        {
            if (Equipos.Count > 24) return false;

            if (Equipos.Count <= 7)
                return await GenerarGrupoCircuitoUnicoAsync(calendario);
            else if (Equipos.Count >= 8 && Equipos.Count <= 12)
                return await GenerarGrupoCircuito2GruposAsync(calendario);
            else
                return await GenerarGrupoCircuito4GruposAsync(calendario);
            return false;
        }

        private async Task<bool> GenerarGrupoCircuito4GruposAsync(string calendario)
        {
            int numGrupos = 4;
            var numEquiposGrupo = Equipos.Count / numGrupos;
            int resto = Math.DivRem(Equipos.Count, 4, out int restoEquipos);

            bool impar = false;
            if (numEquiposGrupo % 2 != 0) impar = true;

            for (int i = 0; i < numGrupos; i++)
            {
                string nombre = VoleyPlayaService.GetGroupName(i + 1);
                EdicionGrupo grupo = NuevoGrupo(numEquiposGrupo, nombre);
                Grupos.Add(grupo);
            }
            DistribucionEquiposSerpiente(numEquiposGrupo);

            return true;
        }

        private void DistribucionEquiposSerpiente(int numEquiposGrupo)
        {
            // Los equipos se reparten por los dos grupos en orden A B, B A, ... si el número de equipos es impar, el último equipo se asigna al grupo B
            var equipos = Equipos.OrderBy(e => e.OrdenEntrada).ToList();
            int seed = 1; // para ver en qué equipo estoy
            int idxGrupo = 0; // tenemos 4 grupos: 0, 1, 2, 3
            int idxFila = 0; // para ver si sumamos o restamos el idxGrupo
            bool esUltimaFila = false;
            bool sumaGrupo = true;
            bool noEsFin = false;

            for (int i = 0; i < equipos.Count; i++)
            {
                Equipo equipo = equipos[i];
                EdicionGrupo grupo = Grupos[idxGrupo];
                equipo.Posicion = grupo.Equipos.Count + 1;
                grupo.Equipos.Add(equipo);
                seed++; // vamos sumando por cada equipo que añadimos
                if (idxFila % 2 == 0 && !noEsFin) // filas 0, 2, 4
                {
                    //idxGrupo++;
                    if (idxGrupo == Grupos.Count-1)
                    {
                        idxFila++;
                        sumaGrupo = false;
                    }
                    else
                    {
                        if (sumaGrupo) idxGrupo++;
                        else idxGrupo--;
                    }
                }
                else // filase 1, 3, 5
                {
                    //idxGrupo--;
                    if (idxGrupo == 0)
                    {
                        idxFila++;
                        sumaGrupo = true;
                    }
                    else
                    {
                        if (sumaGrupo) idxGrupo++;
                        else idxGrupo--;
                    }
                }
                if (idxFila == numEquiposGrupo) esUltimaFila = true;
                if (esUltimaFila && !noEsFin)
                {
                    noEsFin = true;
                    idxGrupo = Grupos.Count-1;
                    sumaGrupo = false;
                }
            }
        }

        private async Task<bool> GenerarGrupoCircuito2GruposAsync(string calendario)
        {
            int numGrupos = 2;
            var numEquiposGrupo = Equipos.Count / numGrupos;
            int resto = Math.DivRem(Equipos.Count, 2, out int restoEquipos);

            for (int i = 0; i < numGrupos; i++)
            {
                string nombre = VoleyPlayaService.GetGroupName(i + 1);
                int numEqui = numEquiposGrupo;
                if (restoEquipos > 0) numEqui = numEquiposGrupo + restoEquipos;
                EdicionGrupo grupo = NuevoGrupo(numEqui, nombre);
                Grupos.Add(grupo);
            }
            DistribucionEquiposSerpiente(numEquiposGrupo);
            //// Los equipos se reparten por los dos grupos en orden A B, B A, ... si el número de equipos es impar, el último equipo se asigna al grupo B
            //int idxEquipo = 0;
            //var equipos = Equipos.OrderBy(e => e.OrdenEntrada).ToList();

            //int idxGrupo = 0;
            //for (int i = 0; i < equipos.Count; i++)
            //{
            //    Equipo equipo = equipos[i];                
            //    EdicionGrupo grupo = Grupos[idxGrupo]; 
            //    equipo.Posicion = grupo.Equipos.Count + 1;
            //    grupo.Equipos.Add(equipo);
            //    if (idxGrupo == 0) idxGrupo = 1;
            //    else idxGrupo = 0;

            //    if (restoEquipos > 0 && i == equipos.Count - 2)
            //        idxGrupo = 1;
            //}
            return true;
        }

        private async Task<bool> GenerarGrupoCircuitoUnicoAsync(string calendario)
        {
            int numGrupos = 1;
            var numEquiposGrupo = Equipos.Count;

            for (int i = 0; i < numGrupos; i++)
            {
                string nombre = VoleyPlayaService.GetGroupName(i + 1);
                EdicionGrupo grupo = NuevoGrupo(numEquiposGrupo, nombre); 
                Grupos.Add(grupo);
            }
            // Meter todos los equipos al único grupo
            int idxEquipo = 0;
            var equipos = Equipos.OrderBy(e => e.OrdenEntrada).ToList();

            for (int i = 0; i < equipos.Count; i++)
            {
                Equipo equipo = equipos[i];
                EdicionGrupo grupo = Grupos[i % numGrupos]; // Asignación cíclica de equipos a grupos
                equipo.Posicion = grupo.Equipos.Count + 1;
                grupo.Equipos.Add(equipo);
            }
            return true;
        }

        private async Task<bool> GenerarFaseGruposJuegosDeportivosAsync(string calendario)
        { 
            TipoCalendario = calendario;
            var tabla = (await TablaCalendario.LoadCalendarios()).Where(t => t.Tipo.Equals(calendario)).FirstOrDefault();
            var numEquiposGrupo = tabla.NumEquipos;
            if (numEquiposGrupo == 0) return false;
            int numGrupos = Equipos.Count / numEquiposGrupo;
            int resto = Math.DivRem(Equipos.Count, numEquiposGrupo, out int restoEquipos);

            for (int i = 0; i < numGrupos; i++)
            {
                string nombre = VoleyPlayaService.GetGroupName(i+1);
                EdicionGrupo grupo = NuevoGrupo(numEquiposGrupo, nombre);
                Grupos.Add(grupo);
            }
            // Repartir los equipos en los diferentes grupos.
            // Los equipos están ordenados por nombre, por tanto están todos los del mismo colegio juntos
            // Vamos a asignar los equipos de la siguiente forma: equipo 1 -> grupo1, equipo 2 -> grupo2, equipo 3-> grupo3... hasta el numero de grupos
            int idxEquipo = 0;
            var equipos = Equipos.OrderBy(e => e.Nombre).ToList();

            for (int i = 0; i < equipos.Count; i++)
            {
                Equipo equipo = equipos[i];
                EdicionGrupo grupo = Grupos[i % numGrupos]; // Asignación cíclica de equipos a grupos
                equipo.Posicion = grupo.Equipos.Count + 1;
                grupo.Equipos.Add(equipo);
            }
            return true;
        }

        private EdicionGrupo NuevoGrupo(int numEquiposGrupo, string nombre)
        {
            var grupo = new EdicionGrupo()
            {
                Equipos = new List<Equipo>(),
                Name = nombre,
                NumEquipos = numEquiposGrupo,
                TipoGrupo = EnumTipoGrupo.Liga,
                Partidos = new List<Partido>()
            };

            return grupo;
        }

        internal async Task<bool> GenerarFaseFinal(TablaCalendarioCircuito calendario)
        {
            //if (ModeloCompeticion.Equals(EnumModeloCompeticion.Circuito))
                return await GenerarFaseFinalCircuito(calendario);

            return false;
        }

        private async Task<bool> GenerarFaseFinalCircuito(TablaCalendarioCircuito calendario)
        {
            // cuantos grupos tiene la edicion -> para poder seleccionar el calendario
            var numGrupos = Grupos.Where(g=>g.TipoGrupo.Equals(EnumTipoGrupo.Liga)).Count();
            if (numGrupos != 1 && numGrupos != 2 && numGrupos!=3 && numGrupos != 4)
                return false;

            // 4: 12 equipos, 3: 5 equipos, 2: 6 equipos, 1: 4 equipos
            var numEquipos = numGrupos == 4 ? 12 : numGrupos == 3 ? 10 : numGrupos == 2 ? 6 : numGrupos == 1 ? 4 : 0;
            if (numEquipos == 0)
                return false;
            EdicionGrupo grupo;
            if (Grupos.Exists(g => g.Name.Equals("FF")))
                grupo = Grupos.First(g => g.Name.Equals("FF"));
            else
                grupo = NuevoGrupo(numEquipos, "FF");

            grupo.TipoGrupo = EnumTipoGrupo.Final;

            var partidosCalendario = await calendario.GetPartidosByNumGrupo(numGrupos);
            foreach(var par in partidosCalendario)
            {
                var partido = grupo.Partidos.FirstOrDefault(p => p.NumPartido.Equals(par.NumPartido));
                if (partido.ConResultado && partido.Validado) continue;
                bool asignadoE1;
                bool asignadoE2;
                var equipo1 = GetEquipo(par.Equipo1, grupo, out asignadoE1);
                var equipo2 = GetEquipo(par.Equipo2, grupo, out asignadoE2);
                if (asignadoE1)
                {
                    var e1 = Equipos.Where(e => e.Nombre.Equals(equipo1)).FirstOrDefault();
                    var existeE1 = grupo.Equipos.FirstOrDefault(e => e.Nombre.Equals(equipo1));
                    if (existeE1==null)
                        grupo.Equipos.Add(e1);
                }
                if (asignadoE2)
                {
                    var e2 = Equipos.Where(e => e.Nombre.Equals(equipo2)).FirstOrDefault();
                    var existeE2 = grupo.Equipos.FirstOrDefault(e => e.Nombre.Equals(equipo2));
                    if (existeE2 == null)
                        grupo.Equipos.Add(e2);
                }
                if (partido == null)
                {
                    grupo.Partidos.Add(new Partido
                    {
                        Categoria = CategoriaStr,
                        Competicion = Competicion,
                        FechaHora = DateTime.Today,
                        Genero = GeneroStr,
                        Grupo = grupo.Name,
                        Jornada = par.Jornada,
                        Label = "P" + par.NumPartido.ToString(),
                        NumPartido = par.NumPartido,
                        Local = equipo1,
                        Visitante = equipo2,
                        Prueba = Prueba,
                        Pista = "",
                        RetiradoLocal = false,
                        RetiradoVisitante = false,
                        NombreLocal = equipo1,
                        NombreVisitante = equipo2,
                        Ronda = par.Ronda,
                        Resultado = new Resultado()
                    }) ;
                }
                else
                {
                    partido.Local = equipo1;
                    partido.Visitante = equipo2;
                    partido.NombreLocal = equipo1;
                    partido.NombreVisitante = equipo2;
                    partido.Ronda = par.Ronda;
                }
            }

            var existeGrupo = Grupos.Where(g => g.Name.Equals(grupo.Name)).FirstOrDefault();
            if (existeGrupo == null)
                Grupos.Add(grupo);
            else
            {
                Grupos.Remove(existeGrupo);
                Grupos.Add(grupo);// así lo tenemos siempre actualizado
            }
            return true;
        }

        private string GetEquipo(string equipo, EdicionGrupo grupoFF, out bool asignado)
        {
            asignado = false;
            if (char.IsDigit(equipo[0])) // vamos a buscar el equipo en una posición determinada del Grupo indicado
            {
                var posicion = Convert.ToInt32(Utilities.ObtenerDigitosContinuos(equipo));
                var grupoId = Utilities.ObtenerLetras(equipo);

                var grupo = Grupos.Where(g => g.Name.Equals(grupoId)).FirstOrDefault();
                if (grupo == null) return equipo;

                if (!grupo.TodosPartidosValidados())
                    return equipo;

                var equi = grupo.Equipos.OrderByDescending(e => e.Puntos)
                                .ThenByDescending(e => e.Coeficiente)
                                .Skip(posicion-1)
                                .FirstOrDefault();
                if (equi == null) return equipo;

                asignado = true;
                return equi.Nombre;
            }
            else if (equipo[0]=='M')    // hay que buscar el mejor 'n' de los grupos participantes
            {
                var posicion = Convert.ToInt32(Utilities.ObtenerDigitosContinuos(equipo));
                List<Equipo> mejoresPos = new List<Equipo>();
                var grupos = Grupos.Where(g => g.TipoGrupo.Equals(EnumTipoGrupo.Liga)).ToList();
                foreach (var grupo in grupos)
                {
                    if (!grupo.TodosPartidosValidados())
                        return equipo;
                    // me quedo con el mejor del puesto indicado (mejor 4º mejor 3º, etc)
                    var equi1 = grupo.Equipos.OrderByDescending(e => e.Puntos)
                        .ThenByDescending(e => e.Coeficiente)
                        .Skip(posicion - 1)
                        .FirstOrDefault();
                    mejoresPos.Add(equi1);
                }
                // nos quedamos con el mejor
                var equi = mejoresPos.OrderByDescending(e => e.Puntos)
                        .ThenByDescending(e => e.Coeficiente)
                        .FirstOrDefault();
                if (equi == null) return equipo;

                asignado = true;
                return equi.Nombre;
            }
            else // vamos a buscar el equipo ganador o perdedor de un partido determinado
            {
                var numPartido = Convert.ToInt32(Utilities.ObtenerDigitosContinuos(equipo));
                var partido = grupoFF.Partidos.Where(p => p.NumPartido.Equals(numPartido)).FirstOrDefault();
                if (partido == null) return equipo;
                if (equipo.StartsWith('G')) // buscamos el ganador
                    return GetEquipoGanador(partido, equipo, out asignado);
                else if (equipo.StartsWith('P'))
                    return GetEquipoPerdedor(partido, equipo, out asignado);
            }
            return equipo;
        }

        private string GetEquipoPerdedor(Partido partido, string equipo, out bool asignado)
        {
            asignado = false;
            if (partido.Resultado.Local > partido.Resultado.Visitante)
            {
                asignado = true;
                return partido.Visitante;
            }
            else if (partido.Resultado.Local < partido.Resultado.Visitante)
            {
                asignado = true;
                return partido.Local;
            }
            else
                return equipo;
        }

        private string GetEquipoGanador(Partido partido, string equipo, out bool asignado)
        {
            asignado = false;
            if (partido.Resultado.Local > partido.Resultado.Visitante)
            {
                asignado = true;
                return partido.Local;
            }
            else if (partido.Resultado.Local < partido.Resultado.Visitante)
            {
                asignado = true;
                return partido.Visitante;
            }
            else
                return equipo;
        }
    }
}
