using Azure.Core;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Tablas.Commands.AddTabla;
using VoleyPlaya.Organization.Application.Features.Tablas.Commands.DeleteTabla;
using VoleyPlaya.Organization.Application.Features.Tablas.Commands.UpdateTabla;
using VoleyPlaya.Organization.Application.Features.Tablas.Queries.GetTabla;
using VoleyPlaya.Organization.Application.Features.Tablas.Queries.GetTablas;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VoleyPlaya.Organization.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TablasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<TablasController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            return Ok(await _mediator.Send(new GetTablasQuery()));
        }

        // GET api/<TablasController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TablaDto>> Get(int id)
        {
            var tabla = await _mediator.Send(new GetTablaQuery(id));
            if (tabla == null) return NotFound();
            return Ok(tabla);
        }

        // POST api/<TablasController>
        [HttpPost]
        public async Task<ActionResult<TablaDto>> Post([FromBody, Bind("Nombre")] AddTablaCommand request)
        {
            TablaDto tabla = await _mediator.Send(request);
            if (tabla == null)
                return NotFound();
            return CreatedAtAction("Get", new { id = tabla.Nombre }, tabla);
        }

        // PUT api/<TablasController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody, Bind("Nombre")] UpdateTablaCommand request)
        {
            request.Id = id;
            var tabla = await _mediator.Send(request);
            if (tabla == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/<TablasController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tabla = await _mediator.Send(new DeleteTablaCommand(id));
            if (!tabla)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
