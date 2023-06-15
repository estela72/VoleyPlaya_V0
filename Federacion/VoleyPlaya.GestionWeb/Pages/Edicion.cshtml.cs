using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;
using VoleyPlaya.Domain.Enums;
using VoleyPlaya.Domain.Models;
using VoleyPlaya.Domain.Services;
using VoleyPlaya.GestionWeb.Infrastructure;

namespace VoleyPlaya.GestionWeb.Pages
{
    [Authorize(Policy = "CompeticionesOnly")]
    public class EdicionModel : VPPageModel
    {
        [BindProperty]
        public string EdicionName { get; set; }

        [BindProperty]
        public Edicion Edicion { get; set; }
        [BindProperty]
        public List<EdicionGrupo> GruposLiga { get; set; }
        [BindProperty]
        public List<EdicionGrupo> GruposFF { get; set; }
        public SelectList Competiciones { get; set; }
        public SelectList Categorias { get; set; }
        public SelectList Generos { get; set; }
        public SelectList TipoCalendarios { get; set; }
        public SelectList ModelosCompeticion { get; set; }

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

        [BindProperty]
        public List<Equipo> EquiposCF { get; set; }

        [BindProperty]
        public string PistaGrupo { get; set; }
        [BindProperty]
        public bool SobreescribirPistasGrupo { get; set; }

        [BindProperty]
        public DateTime FechaFaseFinal { get; set; } = DateTime.Today;
        [BindProperty]
        public int IntervaloMinutosFaseFinal { get; set; } = 20;

        private readonly IConfiguracionService _configuracionService;

        public EdicionModel (IEdicionService service, IConfiguracionService configuracionService) : base(service)
        {
            Competiciones = new SelectList(EnumCompeticiones.Competiciones.Values);
            Categorias = new SelectList(Enum.GetValues(typeof(EnumCategorias)).OfType<EnumCategorias>().ToList());
            Generos = new SelectList(Enum.GetValues(typeof(EnumGeneros)).OfType<EnumGeneros>().ToList());
            ModelosCompeticion = new SelectList(Enum.GetValues(typeof(EnumModeloCompeticion)).OfType<EnumModeloCompeticion>().ToList());
            PasoActual = 1;
            _configuracionService = configuracionService;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                Edicion = new Edicion();
                await Fill();
                return Page();
            }
            try
            {
                await GetEdicion(id);
                await Fill();

                if (Edicion == null)
                {
                    return NotFound();
                }
            }
            catch(Exception x)
            {
                ErrorMessage = "Error cargando la competición: "+x.Message;
            }
            return Page();
        }
        private async Task GetEdicion(int? id)
        {
            Arguments.Check(new object[] { id });
            try
            {
                Edicion = await _service.GetEdicionByIdAsync(id.Value);
            }
            catch(Exception x)
            {
                throw new Exception("No se puede obtener la competición con id " + id);
            }
        }
        private async Task GetEdicion(string nombre)
        {
            try
            {
                Arguments.Check(new object[] { nombre });
                Edicion = await _service.GetEdicionByName(nombre);
            }
            catch (Exception x)
            {
                throw new Exception("No se puede obtener la competición con nombre " + nombre);
            }
        }
        private async Task Fill()
        {
            try
            {
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
                if (NumJornadas > 0 && Edicion.FechasJornadas.Count == 0)
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
                GruposLiga = Edicion.Grupos.Where(g => g.TipoGrupo.Equals(EnumTipoGrupo.Liga)).ToList();
                GruposFF = Edicion.Grupos.Where(g => g.TipoGrupo.Equals(EnumTipoGrupo.Final)).ToList();
                EquiposCF = Edicion.Equipos.OrderBy(e=>e.ClasificacionFinal==0).ThenBy(e => e.ClasificacionFinal).ToList();

                if (Edicion.Id != 0)
                    PasoActual = 1;
                if (Edicion.Equipos.Count > 0)
                    PasoActual = 2;
                if (Edicion.Grupos!.Count > 0)
                    PasoActual = 3;
                if (Edicion.Grupos!.Count > 0 && Edicion.Grupos.First().Partidos.Count > 0)
                    PasoActual = 4;
                if (Edicion.Grupos!.Exists(g => g.TipoGrupo.Equals(EnumTipoGrupo.Final)))
                    PasoActual = 5;
                if (Edicion.Grupos!.Exists(g => g.TipoGrupo.Equals(EnumTipoGrupo.Final))
                    && Edicion.Grupos.Where(g => g.TipoGrupo.Equals(EnumTipoGrupo.Final)).FirstOrDefault().Equipos.Exists(e => e.ClasificacionFinal > 0))
                    PasoActual = 6;

            }
            catch (Exception x)
            {
                throw new Exception("No se pueden completar los datos de la competición");
            }
        }
        public async Task<IActionResult> OnPostCompeticionAsync()
        {
            try
            {
                _ = await _service.UpdateEdicionGenericoAsync(Edicion);
                EdicionName = EdicionService.GetNombreEdicion(Edicion.Temporada, Edicion.Prueba, Edicion.Competicion, Edicion.CategoriaStr, Edicion.GeneroStr);
                await GetEdicion(EdicionName);
                await Fill();
            }
            catch (Exception x)
            {
                ErrorMessage = "Error guardando los datos generales de la competición: " + x.Message;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostEquiposAsync(IFormFile file, int id)
        {
            try
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

                await GetEdicion(id);
                await Fill();
            }
            catch (Exception x)
            {
                ErrorMessage = "Error guardando los equipos de la competición: " + x.Message;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostFaseAsync()
        {
            try
            {
                if (Edicion.Id == 0 && !string.IsNullOrEmpty(EdicionName))
                    await GetEdicion(EdicionName);
                if (Edicion.Id == 0 && !string.IsNullOrEmpty(Edicion.Nombre))
                    await GetEdicion(EdicionName);
                if (TipoCalendarioSeleccionado != null)
                {
                    dynamic datos = await TablaCalendario.GetInfoTipo(TipoCalendarioSeleccionado);
                    NumJornadas = await TablaCalendario.NumJornadas(datos.Equipos, datos.Vueltas);
                }
                else
                {
                    TipoCalendarioSeleccionado = "1 vueltas - 5 equipos";
                    NumJornadas = await TablaCalendario.NumJornadas(5, 1);
                }
                Edicion = await _service.GetEdicionByIdAsync(Edicion.Id);
                if (await Edicion.GenerarFaseGruposAsync(TipoCalendarioSeleccionado))
                {
                    for (int i = 0; i < NumJornadas; i++)
                    {
                        Edicion.FechasJornadas.Add(new FechaJornada
                        {
                            Jornada = i + 1,
                            Fecha = DateTime.Today
                        });
                    }
                    await _service.UpdateGruposAsync(Edicion);
                }
                await Fill();
            }
            catch (Exception x)
            {
                ErrorMessage = "Error generando y guardando los grupos de la competición: " + x.Message;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostGuardarPosicionEquiposAsync(int grupoId)
        {
            try
            {
                var equipos = GruposLiga.FirstOrDefault(g => g.Id.Equals(grupoId))?.Equipos;
                await _service.UpdatePosicionEquiposAsync(equipos??null,grupoId);
                await GetEdicion(Edicion.Nombre);
                await Fill();
            }
            catch (Exception x)
            {
                ErrorMessage = "Error guardando los grupos de la competición: " + x.Message;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostDeleteEquipoAsync(int id)
        {
            try
            {
                var str = await _service.DeleteEquipoAsync(id);
                ErrorMessage = str;
            }
            catch (Exception x)
            {
                ErrorMessage = "Error eliminando un equipo de la competición: " + x.Message;
            }
            finally
            {
                await GetEdicion(Edicion.Nombre);
                await Fill();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostRetirarEquipoAsync(int id)
        {
            try
            {
                var str = await _service.RetirarEquipoASync(id);
                ErrorMessage = str;
            }
            catch(Exception x)
            {
                ErrorMessage = "Error retirando un equipo de la competición: " + x.Message;
            }
            finally
            {
                await GetEdicion(Edicion.Nombre);
                await Fill();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostDeleteGrupoAsync(int id)
        {
            try
            {
                await _service.DeleteGrupoAsync(id);
            }
            catch (Exception x)
            {
                ErrorMessage = "Error eliminando un grupo de la competición: " + x.Message;
            }
            finally
            {
                await GetEdicion(Edicion.Nombre);
                await Fill();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostGenerarJornadasAsync()
        {
            try
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
            }
            catch (Exception x)
            {
                ErrorMessage = "Error generando las jornadas de la competición: " + x.Message;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostGenerarPartidosAsync()
        {
            try
            {
                var jornadas = Edicion.FechasJornadas;
                if (Edicion.Id == 0 && !string.IsNullOrEmpty(EdicionName))
                    await GetEdicion(EdicionName);
                if (Edicion.Id == 0 && !string.IsNullOrEmpty(Edicion.Nombre))
                    await GetEdicion(EdicionName);

                if (Edicion.TipoCalendario == null)
                    Edicion.TipoCalendario = await GetTipoCalendarioEdicion(Edicion.Id);
                if (Edicion.ModeloCompeticion == null)
                    Edicion.ModeloCompeticion = await GetModeloCompeticionEdicion(Edicion.Id);

                Edicion.FechasJornadas = jornadas;

                // lo primero guardar las jornadas
                await _service.UpdateJornadasAsync(Edicion);
                int numEquipos = Edicion.Grupos.Max(g => g.Equipos.Count);
                foreach (EdicionGrupo grupo in Edicion.Grupos)
                {
                    await grupo.GenerarPartidosAsync(Edicion.ModeloCompeticion, Edicion.TipoCalendario, Edicion.FechasJornadas, grupo.Equipos);
                    await _service.UpdatePartidosAsync(grupo);
                }
                await GetEdicion(Edicion.Nombre);
                await Fill();
            }
            catch (Exception x)
            {
                ErrorMessage = "Error generando los partidos de la competición: " + x.Message;
            }
            return Page();
        }

        private async Task<EnumModeloCompeticion> GetModeloCompeticionEdicion(int id)
        {
            return await _service.GetModeloCompeticionAsyn(id);
        }

        private async Task<string> GetTipoCalendarioEdicion(int id)
        {
            return await _service.GetTipoCalendarioEdicion(id);
        }

        public async Task<IActionResult> OnPostGuardarPartidosAsync()
        {
            try
            {
                await ActualizarDatosPartidosAsync(GruposLiga);
            }
            catch (Exception x)
            {
                ErrorMessage = "Error guardando los partidos de la competición: " + x.Message;
            }
            finally
            {
                await GetEdicion(Edicion.Nombre);
                await Fill();
            }
            return Page();
        }

        private async Task ActualizarDatosPartidosAsync(List<EdicionGrupo> grupos)
        {
            if (Edicion.Id == 0 && !string.IsNullOrEmpty(EdicionName))
                await GetEdicion(EdicionName);
            if (Edicion.Id == 0 && !string.IsNullOrEmpty(Edicion.Nombre))
                await GetEdicion(EdicionName);
            foreach (var grupo in grupos)
                await _service.UpdateDatosPartidosAsync(grupo);
        }
        public async Task<IActionResult> OnPostActualizarClasificacionAsync()
        {
            try
            {
                await _service.UpdateClasificacionGrupos(Edicion.Id);
            }
            catch(Exception x)
            {
                ErrorMessage = "Ha habido un error actualizando la clasificación de los grupos";
            }
            finally
            {
                await GetEdicion(Edicion.Nombre);
                await Fill();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostGenerarFaseFinalAsync()
        {
            try
            {
                if (Edicion.Id == 0 && !string.IsNullOrEmpty(EdicionName))
                    await GetEdicion(EdicionName);
                if (Edicion.Id == 0 && !string.IsNullOrEmpty(Edicion.Nombre))
                    await GetEdicion(EdicionName);

                if (!await _service.GenerarFaseFinal(Edicion.Id, FechaFaseFinal, IntervaloMinutosFaseFinal))
                    ErrorMessage = "Se ha producido un error generando la fase final";

                await GetEdicion(Edicion.Nombre);
                await Fill();
            }
            catch (Exception x)
            {
                ErrorMessage = "Error guardando los partidos de la competición: " + x.Message;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostGuardarPartidosFaseFinalAsync()
        {
            try
            {
                await ActualizarDatosPartidosAsync(GruposFF);
                await GetEdicion(Edicion.Nombre);
                await Fill();
            }
            catch (Exception x)
            {
                ErrorMessage = "Error guardando los partidos de la competición: " + x.Message;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostDeletePartidoAsync(int id)
        {
            try
            {
                var str = await _service.DeletePartidoAsync(id);
                ErrorMessage = str;
            }
            catch (Exception x)
            {
                ErrorMessage = "Error eliminando un partido de la competición: " + x.Message;
            }
            finally
            {
                await GetEdicion(Edicion.Nombre);
                await Fill();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostValidarPartidoAsync(int idPartido, bool activo, int set1L, int set1V, int set2L, int set2V, int set3L, int set3V)
        {
            try
            {
                var str = await _service.ValidarPartidoAsync(idPartido, activo, set1L, set1V, set2L, set2V, set3L, set3V);
                ErrorMessage = str;
                return new JsonResult(str);
            }
            catch(Exception x)
            {
                ErrorMessage = "Error eliminando un partido de la competición: " + x.Message;
                return new JsonResult(ErrorMessage);
            }
        }
        public async Task<IActionResult> OnPostClasificacionFinalAsync()
        {
            try
            {
                var str = await _service.ActualizarClasificacionFinal(Edicion.Id, EquiposCF);
                ErrorMessage = str;
            }
            catch (Exception x)
            {
                ErrorMessage = "Error actualizando la clasificación final: " + x.Message;
            }
            finally
            {
                await GetEdicion(Edicion.Nombre);
                await Fill();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsignarPistaGrupoAsync(int id, string pista, bool sobreescribir)
        {
            try
            {
                if (string.IsNullOrEmpty(pista))
                {
                    ErrorMessage = "Se debe asignar una pista válida";
                    await GetEdicion(Edicion.Nombre);
                    await Fill();
                    return Page();
                }
                var str = await _service.ActualizarPistaGrupo(id, pista, sobreescribir);
                ErrorMessage = str;
            }
            catch (Exception x)
            {
                ErrorMessage = "Error actualizando la clasificación final: " + x.Message;
            }
            finally
            {
                await GetEdicion(Edicion.Nombre);
                await Fill();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAdd10Minutes(int id)
        {
            try
            {
                //var str = await _service.ActualizarPistaGrupo(id, PistaGrupo, SobreescribirPistasGrupo);
                //ErrorMessage = str;
            }
            catch (Exception x)
            {
                ErrorMessage = "Error actualizando la clasificación final: " + x.Message;
            }
            finally
            {
                await GetEdicion(Edicion.Nombre);
                await Fill();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAdd60Minutes(int id)
        {
            try
            {
                //var str = await _service.ActualizarPistaGrupo(id, PistaGrupo, SobreescribirPistasGrupo);
                //ErrorMessage = str;
            }
            catch (Exception x)
            {
                ErrorMessage = "Error actualizando la clasificación final: " + x.Message;
            }
            finally
            {
                await GetEdicion(Edicion.Nombre);
                await Fill();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostGenerarClasificacionFinalAsync()
        {
            try
            {
                var str = await _service.GenerarClasificacionFinal(Edicion.Id);
            }
            catch (Exception x)
            {
                ErrorMessage = "Error actualizando la clasificación final: " + x.Message;
            }
            finally
            {
                await GetEdicion(Edicion.Nombre);
                await Fill();
            }
            return Page();
        }
    }
}
