using Azure.Core;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Competiciones.Commands.AddCompeticion;
using VoleyPlaya.Organization.Application.Features.Competiciones.Commands.DeleteCompeticion;
using VoleyPlaya.Organization.Application.Features.Competiciones.Commands.UpdateCompeticion;
using VoleyPlaya.Organization.Application.Features.Competiciones.Queries.GetCompeticion;
using VoleyPlaya.Organization.Application.Features.Competiciones.Queries.GetCompeticiones;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VoleyPlaya.Organization.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompeticionesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CompeticionesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CompeticionesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            return Ok(await _mediator.Send(new GetCompeticionesQuery()));
        }

        // GET api/<CompeticionesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompeticionDto>> Get(int id)
        {
            var competicion = await _mediator.Send(new GetCompeticionQuery(id));
            if (competicion == null)
                return NotFound();
            return Ok(competicion);
        }

        // POST api/<CompeticionesController>
        [HttpPost]
        public async Task<ActionResult<CompeticionDto>> Post([FromBody, Bind("Nombre")] AddCompeticionCommand request)
        {
            CompeticionDto competicion = await _mediator.Send(request);
            if (competicion == null)
                return NotFound();
            return CreatedAtAction("Get", new { id = competicion.Nombre }, competicion);
        }

        // PUT api/<CompeticionesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody, Bind("Nombre")] UpdateCompeticionCommand request)
        {
            request.Id = id;
            var competicion = await _mediator.Send(request);
            if (competicion == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/<CompeticionesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var competicion = await _mediator.Send(new DeleteCompeticionCommand(id));
            if (!competicion)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
