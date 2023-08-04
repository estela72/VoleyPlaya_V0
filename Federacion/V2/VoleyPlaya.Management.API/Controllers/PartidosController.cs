using Azure.Core;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using VoleyPlaya.Management.Application.Contracts.Persistence;
using VoleyPlaya.Management.Application.DTOs;
using VoleyPlaya.Management.Application.Features.Partidos.Queries.GetPartido;
using VoleyPlaya.Management.Application.Features.Partidos.Queries.GetPartidoes;
using VoleyPlaya.Management.Application.Features.Partidos.Commands.AddPartido;
using VoleyPlaya.Management.Application.Features.Partidos.Commands.UpdatePartido;
using VoleyPlaya.Management.Application.Features.Partidos.Commands.DeletePartido;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VoleyPlaya.Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PartidosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PartidosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            return Ok(await _mediator.Send(new GetPartidosQuery()));
        }

        // GET api/<PartidosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartidoDto>> Get(int id)
        {
            var partido = await _mediator.Send(new GetPartidoQuery(id));
            if (partido == null) return NotFound();
            return Ok(partido);
        }

        // POST api/<PartidosController>
        [HttpPost]
        public async Task<ActionResult<PartidoDto>> Post([FromBody, Bind("Nombre")] AddPartidoCommand request)
        {
            PartidoDto partido = await _mediator.Send(request);
            if (partido == null)
                return NotFound();
            return CreatedAtAction("Get", new { id = partido.Id }, partido);
        }

        // PUT api/<PartidosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody, Bind("Nombre")] UpdatePartidoCommand request)
        {
            request.Id = id;
            var partido = await _mediator.Send(request);
            if (partido == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/<PartidosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var partido = await _mediator.Send(new DeletePartidoCommand(id));
            if (!partido)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
