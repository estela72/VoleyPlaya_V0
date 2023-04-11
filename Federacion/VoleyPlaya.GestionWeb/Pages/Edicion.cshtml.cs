using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;

using VoleyPlaya.Domain.Models;
using VoleyPlaya.Domain.Services;

namespace VoleyPlaya.GestionWeb.Pages
{
    public class EdicionModel : PageModel
    {
        IEdicionService _service;

        [BindProperty]
        public string EdicionName { get; set; }

        [BindProperty]
        public Edicion Edicion { get; set; }
        public SelectList Competiciones { get; set; }
        public SelectList Categorias { get; set; }
        public SelectList Generos { get; set; }
        public SelectList TipoCalendarios { get; set; }

        [BindProperty]
        public string TipoCalendarioSeleccionado { get; set; }
        [BindProperty]
        public int PasoActual { get; set; }

        [BindProperty]
        public int NumEquiposGrupo { get; set; }

        public SelectList ListaEquipos { get; set; } = default;

        [BindProperty]
        public int NumVueltas { get; set; }

        [BindProperty]
        public int NumJornadas { get; set; }

        public EdicionModel (IEdicionService service)
        {
            _service = service;
            Competiciones = new SelectList(EnumCompeticiones.Competiciones.Values);
            Categorias = new SelectList(Enum.GetValues(typeof(EnumCategorias)).OfType<EnumCategorias>().ToList());
            Generos = new SelectList(Enum.GetValues(typeof(EnumGeneros)).OfType<EnumGeneros>().ToList());
            PasoActual = 1;
        }
        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
            {
                Edicion = new Edicion();
                await Fill();
                return Page();
            }
            EdicionName = id;

            await GetEdicion(id);
            await Fill();

            if (Edicion == null)
            {
                return NotFound();
            }
            return Page();
        }
        private async Task GetEdicion(string? id)
        {
            var jsonEdicion = await _service.GetEdicionByName(id);
            Edicion = Edicion.FromJson(JsonNode.Parse(jsonEdicion)!);
        }
        private async Task Fill()
        { 
            if (Edicion.Id != 0)
                PasoActual = 1;
            if (Edicion.Equipos.Count > 0)
                PasoActual = 2;
            if (Edicion.Grupos!.Count > 0)
                PasoActual = 3;
            if (Edicion.Grupos!.Count > 0 && Edicion.Grupos.First().Partidos.Count>0)
                PasoActual = 4;

            ListaEquipos = new SelectList(Edicion.Equipos.OrderBy(e => e.Nombre).Select(e => e.Nombre).ToList());
            TipoCalendarios = new SelectList(await TablaCalendario.LoadTipos());
            if (string.IsNullOrEmpty(Edicion.TipoCalendario))
                TipoCalendarioSeleccionado = TipoCalendarios.First().Text;
            else
                TipoCalendarioSeleccionado = Edicion.TipoCalendario;
            EdicionName = Edicion.Nombre;
            if (Edicion.Grupos.Count > 0)
            {
                int maxEquipos = Edicion.Grupos.Max(g => g.Equipos.Count);
                NumVueltas = await TablaCalendario.NumVueltasPosibles(maxEquipos);
                NumJornadas = await TablaCalendario.NumJornadas(maxEquipos, NumVueltas);
            }
            else
            {
                NumVueltas = 0;
                NumJornadas = 0;
            }
            if (NumJornadas>0 && Edicion.FechasJornadas.Count==0)
            {
                for (int i = 0; i < NumJornadas; i++)
                {
                    Edicion.FechasJornadas.Add(new FechaJornada
                    {
                        Jornada = i + 1,
                        Fecha = DateTime.Today
                    });
                }
            }
        }
        public async Task<IActionResult> OnPostCompeticionAsync()
        {
            await _service.UpdateEdicionAsync(Edicion, "paso1");
            EdicionName = EdicionService.GetNombreEdicion(Edicion.Temporada, Edicion.Competicion, Edicion.CategoriaStr, Edicion.GeneroStr);
            await GetEdicion(EdicionName);
            await Fill();
            return Page();
        }
        public async Task<IActionResult> OnPostEquiposAsync(IFormFile file, int id)
        {
            if (file == null || file.Length == 0)
            {
                // Manejar el caso en que no se seleccionó ningún archivo
                ModelState.AddModelError("file", "Por favor selecciona un archivo Excel.");
                return Page();
            }

            // Leer excel de equipos y cargarlos en la edición
            await Edicion.ImportEquipos(file);
            await _service.UpdateEquiposEdicionAsync(id, Edicion);
            string json = await _service.GetEdicionById(id);
            Edicion = Edicion.FromJson(JsonNode.Parse(json)!);
            await Fill();
            return Page();
        }
        public async Task<IActionResult> OnPostFaseAsync()
        {
            if (Edicion.Id == 0 && !string.IsNullOrEmpty(EdicionName))
                await GetEdicion(EdicionName);
            if (Edicion.Id == 0 && !string.IsNullOrEmpty(Edicion.Nombre))
                await GetEdicion(EdicionName);

            dynamic datos = await TablaCalendario.GetInfoTipo(TipoCalendarioSeleccionado);
            NumJornadas = await TablaCalendario.NumJornadas(datos.Equipos, datos.Vueltas);
            await Edicion.GenerarFaseGruposAsync(TipoCalendarioSeleccionado);
            for (int i = 0; i < NumJornadas; i++)
            {
                Edicion.FechasJornadas.Add(new FechaJornada
                {
                    Jornada = i + 1,
                    Fecha = DateTime.Today
                });
            }
            await _service.UpdateGruposAsync(Edicion);
            await Fill();
            
            return Page();
        }
        public async Task<IActionResult> OnPostGuardarGruposAsync()
        {
            var grupos = Edicion.Grupos;
            if (Edicion.Id == 0 && !string.IsNullOrEmpty(EdicionName))
                await GetEdicion(EdicionName);
            if (Edicion.Id == 0 && !string.IsNullOrEmpty(Edicion.Nombre))
                await GetEdicion(EdicionName);

            Edicion.Grupos = grupos;

            await _service.UpdateGruposAsync(Edicion);
            await GetEdicion(Edicion.Nombre);
            await Fill();
            return Page();
        }
        public async Task<IActionResult> OnPostDeleteEquipoAsync(int id)
        {
            await _service.DeleteEquipoAsync(id);
            await GetEdicion(Edicion.Nombre);
            await Fill();
            return Page();
        }
        public async Task<IActionResult> OnPostGenerarJornadasAsync()
        {
            var fechas = Edicion.FechasJornadas;
            await GetEdicion(Edicion.Nombre);
            for (int i = 0; i < NumJornadas; i++)
            {
                Edicion.FechasJornadas.Add(new FechaJornada
                {
                    Jornada = i + 1,
                    Fecha = DateTime.Today
                });
            }
            await Fill();

            return Page();
        }
        public async Task<IActionResult> OnPostGenerarPartidosAsync()
        {
            var jornadas = Edicion.FechasJornadas;
            if (Edicion.Id == 0 && !string.IsNullOrEmpty(EdicionName))
                await GetEdicion(EdicionName);
            if (Edicion.Id == 0 && !string.IsNullOrEmpty(Edicion.Nombre))
                await GetEdicion(EdicionName);

            Edicion.FechasJornadas = jornadas;

            // lo primero guardar las jornadas
            await _service.UpdateJornadasAsync(Edicion);
            int numEquipos = Edicion.Grupos.Max(g => g.Equipos.Count);
            foreach (EdicionGrupo grupo in Edicion.Grupos)
                await grupo.GenerarPartidosAsync(Edicion.TipoCalendario, Edicion.FechasJornadas, grupo.Equipos);
            await Fill();

            return Page();
        }
        public async Task<IActionResult> OnPostGuardarPartidosAsync()
        {
            var grupos = Edicion.Grupos;
            if (Edicion.Id == 0 && !string.IsNullOrEmpty(EdicionName))
                await GetEdicion(EdicionName);
            if (Edicion.Id == 0 && !string.IsNullOrEmpty(Edicion.Nombre))
                await GetEdicion(EdicionName);
            for (int i= 0; i < Edicion.Grupos.Count;i++)
                Edicion.Grupos[i].Partidos = grupos[i].Partidos;

            foreach(var grupo in Edicion.Grupos)
                await _service.UpdatePartidosAsync(grupo);

            await GetEdicion(Edicion.Nombre);
            await Fill();
            return Page();

        }
    }
}
