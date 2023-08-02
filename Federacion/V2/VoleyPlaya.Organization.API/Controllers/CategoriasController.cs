using Azure.Core;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Categorias.Commands.AddCategoria;
using VoleyPlaya.Organization.Application.Features.Categorias.Commands.DeleteCategoria;
using VoleyPlaya.Organization.Application.Features.Categorias.Commands.UpdateCategoria;
using VoleyPlaya.Organization.Application.Features.Categorias.Queries.GetCategoria;
using VoleyPlaya.Organization.Application.Features.Categorias.Queries.GetCategorias;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VoleyPlaya.Organization.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CategoriasController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            return Ok(await _mediator.Send(new GetCategoriasQuery()));
        }

        // GET api/<CategoriasController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDto>> Get(int id)
        {
            var categoria = await _mediator.Send(new GetCategoriaQuery(id));
            if (categoria == null) return NotFound();
            return Ok(categoria);
        }

        // POST api/<CategoriasController>
        [HttpPost]
        public async Task<ActionResult<CategoriaDto>> Post([FromBody, Bind("Nombre")] AddCategoriaCommand request)
        {
            CategoriaDto categoria = await _mediator.Send(request);
            if (categoria == null)
                return NotFound();
            return CreatedAtAction("PostCategoria", new { id = categoria.Nombre}, categoria);
        }

        // PUT api/<CategoriasController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody, Bind("Nombre")] UpdateCategoriaCommand request)
        {
            request.Id = id;
            var categoria = await _mediator.Send(request);
            if (categoria == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/<CategoriasController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _mediator.Send(new DeleteCategoriaCommand(id));
            if (!categoria)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
