using Azure.Core;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Application.DTOs;
using VoleyPlaya.Organization.Application.Features.Categorias.Commands.AddCategoria;
using VoleyPlaya.Organization.Application.Features.Categorias.Queries.GetCategoria;
using VoleyPlaya.Organization.Application.Features.Categorias.Queries.GetCategorias;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VoleyPlaya.Organization.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public CategoriasController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }
        
        //[HttpPost]
        //public async Task<ActionResult<DepartmentDto>> PostDepartment([FromBody, Bind("Name")] AddDepartmentCommand request)
        //{
        //    var department = await _mediator.Send(request);
        //    if (department == null)
        //        return NotFound();
        //    return CreatedAtAction("GetDepartment", new { id = department.DepartmentId }, department);
        //}

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
            return Ok(await _mediator.Send(new GetCategoriaQuery(id)));
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
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
