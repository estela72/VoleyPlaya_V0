using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using VoleyPlaya.Domain.Models;
using VoleyPlaya.Domain.Services;

namespace VoleyPlaya.GestionWeb.Pages
{
    public class EdicionModel : PageModel
    {
        IEdicionService _service;

        [BindProperty]
        public Edicion Edicion { get; set; }
        public SelectList Competiciones { get; set; }
        public SelectList Categorias { get; set; }
        public SelectList Generos { get; set; }

        [BindProperty]
        public List<int> AddedPos { get;set; }
        [BindProperty]
        public List<string> AddedEquipos { get; set; }
        [BindProperty]
        public List<int> AddedJor { get; set; }
        [BindProperty]
        public List<DateTime> AddedFechas { get; set; }

        public EdicionModel(IEdicionService service)
        {
            _service = service;
            Competiciones = new SelectList(EnumCompeticiones.Competiciones.Values);
            Categorias = new SelectList(Enum.GetValues(typeof(EnumCategorias)).OfType<EnumCategorias>().ToList());
            Generos = new SelectList(Enum.GetValues(typeof(EnumGeneros)).OfType<EnumGeneros>().ToList());
        }
        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
            {
                Edicion = new Edicion();
                return Page();
            }

            var jsonEdicion = await _service.GetEdicionByName(id);
            Edicion = _service.FromJson(jsonEdicion);
            
            if (Edicion == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Edicion != null)
            {
                // añadir equipos
                for (int i = 0; i < AddedEquipos.Count(); i++)
                    Edicion.Equipos.Add(new Equipo() { Posicion = AddedPos[i], Nombre = AddedEquipos[i] });

                // borrar equipos
                if (Edicion.NumEquipos < Edicion.Equipos.Count())
                    Edicion.UpdateEquipos(Edicion.NumEquipos);

                // añadir jornadas
                for (int i = 0; i < AddedFechas.Count(); i++)
                    Edicion.FechasJornadas.Add(new FechaJornada() { Jornada = AddedJor[i], Fecha = AddedFechas[i] });

                // borrar jornadas
                if (Edicion.NumJornadas < Edicion.FechasJornadas.Count())
                    Edicion.UpdateJornadas(Edicion.NumJornadas);

                await _service.UpdateEdicionAsync(Edicion);
            }
            return RedirectToPage("./Ediciones");
        }

        public async Task<IActionResult> OnPostUpdateEquipos(int id, int numEquipos)
        {
            if (id != 0)
            {
                var json = await _service.GetEdicionById(id);
                Edicion = _service.FromJson(json);
            }
            int equiActual = Edicion.Equipos.Count();
            Edicion.UpdateEquipos(numEquipos);
            int equiNuevo = Edicion.Equipos.Count();
            var response = new {equiActual, equiNuevo};
            return new JsonResult(response);
        }
        public async Task<IActionResult> OnPostUpdateJornadas(int id, int numJornadas)
        {
            if (id != 0)
            {
                var json = await _service.GetEdicionById(id);
                Edicion = _service.FromJson(json);
            }
            int jorActual = Edicion.FechasJornadas.Count();
            Edicion.UpdateJornadas(numJornadas);
            int jorNuevo = Edicion.FechasJornadas.Count();
            var response = new { jorActual, jorNuevo };
            return new JsonResult(response);
        }
    }
}
