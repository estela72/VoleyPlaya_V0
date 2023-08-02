using Azure.Core;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Temporadas.Commands.AddTemporada;
using VoleyPlaya.Organization.Application.Features.Temporadas.Commands.DeleteTemporada;
using VoleyPlaya.Organization.Application.Features.Temporadas.Commands.UpdateTemporada;
using VoleyPlaya.Organization.Application.Features.Temporadas.Queries.GetTemporada;
using VoleyPlaya.Organization.Application.Features.Temporadas.Queries.GetTemporadas;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VoleyPlaya.Organization.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemporadasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TemporadasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<TemporadasController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            return Ok(await _mediator.Send(new GetTemporadasQuery()));
        }

        // GET api/<TemporadasController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TemporadaDto>> Get(int id)
        {
            var temporada = await _mediator.Send(new GetTemporadaQuery(id));
            if (temporada == null)
            {
                return NotFound();
            }
            return Ok(temporada);
        }

        // POST api/<TemporadasController>
        [HttpPost]
        public async Task<ActionResult<TemporadaDto>> Post([FromBody, Bind("Nombre")] AddTemporadaCommand request)
        {
            TemporadaDto temporada = await _mediator.Send(request);
            if (temporada == null)
                return NotFound();
            return CreatedAtAction("PostTemporada", new { id = temporada.Nombre }, temporada);
        }

        // PUT api/<TemporadasController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody, Bind("Nombre")] UpdateTemporadaCommand request)
        {
            request.Id = id;
            var temporada = await _mediator.Send(request);
            if (temporada == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/<TemporadasController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var temporada = await _mediator.Send(new DeleteTemporadaCommand(id));
            if (!temporada)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
