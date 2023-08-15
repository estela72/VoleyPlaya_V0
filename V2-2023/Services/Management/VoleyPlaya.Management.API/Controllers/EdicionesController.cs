using Azure.Core;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using VoleyPlaya.Management.Application.Contracts.Persistence;
using VoleyPlaya.Management.Application.DTOs;
using VoleyPlaya.Management.Application.Features.EdicionGrupos.Commands.AddEdicionGrupo;
using VoleyPlaya.Management.Application.Features.EdicionGrupos.Commands.DeleteEdicionGrupo;
using VoleyPlaya.Management.Application.Features.EdicionGrupos.Commands.UpdateEdicionGrupo;
using VoleyPlaya.Management.Application.Features.EdicionGrupos.Queries.GetEdicionGrupo;
using VoleyPlaya.Management.Application.Features.EdicionGrupos.Queries.GetEdicionesGrupo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VoleyPlaya.Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EdicionesGrupoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EdicionesGrupoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<EdicionesGrupoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            return Ok(await _mediator.Send(new GetEdicionesGrupoQuery()));
        }

        // GET api/<EdicionesGrupoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EdicionGrupoDto>> Get(int id)
        {
            var edicionGrupo = await _mediator.Send(new GetEdicionGrupoQuery(id));
            if (edicionGrupo == null) return NotFound();
            return Ok(edicionGrupo);
        }

        // POST api/<EdicionesGrupoController>
        [HttpPost]
        public async Task<ActionResult<EdicionGrupoDto>> Post([FromBody, Bind("Nombre")] AddEdicionGrupoCommand request)
        {
            EdicionGrupoDto edicionGrupo = await _mediator.Send(request);
            if (edicionGrupo == null)
                return NotFound();
            return CreatedAtAction("Get", new { id = edicionGrupo.Id }, edicionGrupo);
        }

        // PUT api/<EdicionesGrupoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody, Bind("Nombre")] UpdateEdicionGrupoCommand request)
        {
            request.Id = id;
            var edicionGrupo = await _mediator.Send(request);
            if (edicionGrupo == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/<EdicionesGrupoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var edicionGrupo = await _mediator.Send(new DeleteEdicionGrupoCommand(id));
            if (!edicionGrupo)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
