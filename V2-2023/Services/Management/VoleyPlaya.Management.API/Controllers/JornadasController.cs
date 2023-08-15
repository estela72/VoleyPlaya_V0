using Azure.Core;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using VoleyPlaya.Management.Application.Contracts.Persistence;
using VoleyPlaya.Management.Application.DTOs;
using VoleyPlaya.Management.Application.Features.Jornadas.Queries.GetJornada;
using VoleyPlaya.Management.Application.Features.Jornadas.Queries.GetJornadaes;
using VoleyPlaya.Management.Application.Features.Jornadas.Commands.AddJornada;
using VoleyPlaya.Management.Application.Features.Jornadas.Commands.UpdateJornada;
using VoleyPlaya.Management.Application.Features.Jornadas.Commands.DeleteJornada;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VoleyPlaya.Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JornadasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public JornadasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<JornadasController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            return Ok(await _mediator.Send(new GetJornadasQuery()));
        }

        // GET api/<JornadasController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JornadaDto>> Get(int id)
        {
            var jornada = await _mediator.Send(new GetJornadaQuery(id));
            if (jornada == null) return NotFound();
            return Ok(jornada);
        }

        // POST api/<JornadasController>
        [HttpPost]
        public async Task<ActionResult<JornadaDto>> Post([FromBody, Bind("Nombre")] AddJornadaCommand request)
        {
            JornadaDto jornada = await _mediator.Send(request);
            if (jornada == null)
                return NotFound();
            return CreatedAtAction("Get", new { id = jornada.Id }, jornada);
        }

        // PUT api/<JornadasController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody, Bind("Nombre")] UpdateJornadaCommand request)
        {
            request.Id = id;
            var jornada = await _mediator.Send(request);
            if (jornada == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/<JornadasController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var jornada = await _mediator.Send(new DeleteJornadaCommand(id));
            if (!jornada)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
