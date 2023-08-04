using Azure.Core;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using VoleyPlaya.Management.Application.Contracts.Persistence;
using VoleyPlaya.Management.Application.DTOs;
using VoleyPlaya.Management.Application.Features.Ediciones.Commands.AddEdicion;
using VoleyPlaya.Management.Application.Features.Ediciones.Commands.DeleteEdicion;
using VoleyPlaya.Management.Application.Features.Ediciones.Commands.UpdateEdicion;
using VoleyPlaya.Management.Application.Features.Ediciones.Queries.GetEdicion;
using VoleyPlaya.Management.Application.Features.Ediciones.Queries.GetEdiciones;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VoleyPlaya.Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EdicionesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EdicionesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<EdicionesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            return Ok(await _mediator.Send(new GetEdicionesQuery()));
        }

        // GET api/<EdicionesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EdicionDto>> Get(int id)
        {
            var edicion = await _mediator.Send(new GetEdicionQuery(id));
            if (edicion == null) return NotFound();
            return Ok(edicion);
        }

        // POST api/<EdicionesController>
        [HttpPost]
        public async Task<ActionResult<EdicionDto>> Post([FromBody, Bind("Nombre")] AddEdicionCommand request)
        {
            EdicionDto edicion = await _mediator.Send(request);
            if (edicion == null)
                return NotFound();
            return CreatedAtAction("Get", new { id = edicion.Id }, edicion);
        }

        // PUT api/<EdicionesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody, Bind("Nombre")] UpdateEdicionCommand request)
        {
            request.Id = id;
            var edicion = await _mediator.Send(request);
            if (edicion == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/<EdicionesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var edicion = await _mediator.Send(new DeleteEdicionCommand(id));
            if (!edicion)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
