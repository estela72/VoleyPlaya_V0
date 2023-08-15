using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using VoleyPlaya.Aggregator.Model;
using VoleyPlaya.Aggregator.Services;

namespace VoleyPlaya.Aggregator.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PartidosController : ControllerBase
{
    private readonly IPartidosServices _partidosService;
    private readonly IJornadasServices _jornadasService;
    private readonly IEdicionGruposServices _edicionGrupoService;
    private readonly IEdicionesServices _edicionesService;

    public PartidosController(IPartidosServices partidosServices, IJornadasServices jornadasServices, IEdicionGruposServices edicionGrupoServices, IEdicionesServices edicionesService)
    {
        this._partidosService = partidosServices;
        this._jornadasService = jornadasServices;
        this._edicionGrupoService = edicionGrupoServices;
        _edicionesService = edicionesService;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Partido>> GetPartido(int id)
    {
        var partido = await _partidosService.GetPartido(id);
        if (partido == null)
            return NotFound();

        var jornada = await _jornadasService.GetJornada(partido.JornadaId);
        if (jornada != null)
        {
            var edicion = await _edicionesService.GetEdicion(jornada.EdicionId);
            if (edicion != null) jornada.Edicion = edicion;
            partido.Jornada = jornada;
        }

        var edicionGrupo = await _edicionGrupoService.GetEdicionGrupo(partido.EdicionGrupoId);
        if (edicionGrupo != null)
        {
            var edicion = await _edicionesService.GetEdicion(edicionGrupo.EdicionId);
            if (edicion != null) edicionGrupo.Edicion = edicion;
            partido.EdicionGrupo = edicionGrupo;
        }

        return Ok(jornada);
    }
}
