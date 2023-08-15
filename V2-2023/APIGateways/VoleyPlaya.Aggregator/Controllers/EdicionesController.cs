using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using VoleyPlaya.Aggregator.Model;
using VoleyPlaya.Aggregator.Services;

namespace VoleyPlaya.Aggregator.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EdicionesController : ControllerBase
{
    private readonly IEdicionesServices _edicionesService;
    private readonly ITemporadasService _temporadasService;
    private readonly ICompeticionesService _competicionesService;
    private readonly ICategoriasService _categoriasService;

    public EdicionesController(IEdicionesServices edicionesService, 
        ITemporadasService temporadasService, ICompeticionesService competicionesService, ICategoriasService categoriasService) 
    {
        this._edicionesService = edicionesService;
        this._temporadasService = temporadasService;
        this._competicionesService = competicionesService;
        this._categoriasService = categoriasService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Edicion>> GetEdicion(int id)
    {
        var edicion = await _edicionesService.GetEdicion(id);
        if (edicion == null)
            return NotFound();

        var temporada = await _temporadasService.GetTemporada(edicion.TemporadaId);
        if (temporada != null)
            edicion.Temporada = temporada.Nombre;

        var competicion = await _competicionesService.GetCompeticion(edicion.CompeticionId);
        if (competicion != null)
            edicion.Competicion = competicion.Nombre;

        var categoria = await _categoriasService.GetCategoria(edicion.CategoriaId);
        if (categoria != null)
            edicion.Categoria= categoria.Nombre;

        return Ok(edicion);
    }
}
