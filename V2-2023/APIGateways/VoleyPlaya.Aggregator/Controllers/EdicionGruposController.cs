using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using VoleyPlaya.Aggregator.Model;
using VoleyPlaya.Aggregator.Services;

namespace VoleyPlaya.Aggregator.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EdicionGruposController : ControllerBase
{
    private readonly IEdicionGruposServices _edicionGruposService;
    private readonly IEdicionesServices _edicionesService;

    public EdicionGruposController(IEdicionGruposServices edicionGruposService, IEdicionesServices edicionesService)
    {
        _edicionGruposService = edicionGruposService ?? throw new ArgumentNullException(nameof(edicionGruposService));
        _edicionesService = edicionesService ?? throw new ArgumentNullException(nameof(edicionesService));
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<EdicionGrupo>> GetEdicionGrupo(int id)
    {
        var edicionGrupo = await _edicionGruposService.GetEdicionGrupo(id);
        if (edicionGrupo == null)
            return NotFound();

        var edicion = await _edicionesService.GetEdicion(edicionGrupo.EdicionId);
        if (edicion != null)
            edicionGrupo.Edicion = edicion;

        return Ok(edicionGrupo);
    }
}
