using Azure.Core;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Equipos.Commands.AddEquipo;
using VoleyPlaya.Organization.Application.Features.Equipos.Commands.DeleteEquipo;
using VoleyPlaya.Organization.Application.Features.Equipos.Commands.UpdateEquipo;
using VoleyPlaya.Organization.Application.Features.Equipos.Queries.GetEquipo;
using VoleyPlaya.Organization.Application.Features.Equipos.Queries.GetEquipos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VoleyPlaya.Organization.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EquiposController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<EquiposController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            return Ok(await _mediator.Send(new GetEquiposQuery()));
        }

        // GET api/<EquiposController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipoDto>> Get(int id)
        {
            var equipo = await _mediator.Send(new GetEquipoQuery(id));
            if (equipo == null) return NotFound();
            return Ok(equipo);
        }

        // POST api/<EquiposController>
        [HttpPost]
        public async Task<ActionResult<EquipoDto>> Post([FromBody, Bind("Nombre")] AddEquipoCommand request)
        {
            EquipoDto equipo = await _mediator.Send(request);
            if (equipo == null)
                return NotFound();
            return CreatedAtAction("Get", new { id = equipo.Nombre }, equipo);
        }

        // PUT api/<EquiposController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody, Bind("Nombre")] UpdateEquipoCommand request)
        {
            request.Id = id;
            var equipo = await _mediator.Send(request);
            if (equipo == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/<EquiposController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var equipo = await _mediator.Send(new DeleteEquipoCommand(id));
            if (!equipo)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
