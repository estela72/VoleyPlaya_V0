using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using VoleyPlaya.Aggregator.Model;
using VoleyPlaya.Aggregator.Services;

namespace VoleyPlaya.Aggregator.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JornadasController : ControllerBase
{
    private readonly IJornadasServices _jornadasService;
    private readonly IEdicionesServices _edicionesService;

    public JornadasController(IJornadasServices jornadasServices, IEdicionesServices edicionesServices)
    {
        this._jornadasService = jornadasServices;
        this._edicionesService = edicionesServices;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Jornada>> GetJornada(int id)
    {
        var jornada = await _jornadasService.GetJornada(id);
        if (jornada == null)
            return NotFound();

        var edicion = await _edicionesService.GetEdicion(jornada.EdicionId);
        if (edicion != null)
            jornada.Edicion = edicion;

        return Ok(jornada);
    }
}
