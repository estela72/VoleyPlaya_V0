using Ejemplo.WebAPI.Model;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Net.Mime;

namespace Ejemplo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DummiesController : ControllerBase
    {
        // GET: api/dummies
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public Dummy GetDummy()
        {
            return new Dummy { Text = "New Dummy Object" };
        }
        // POST: api/dummies
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public Dummy PostDummy(Dummy dummy)
        {
            dummy.Text += " created";
            return dummy;
        }
        // GET: api/Dummies/{name}
        [HttpGet("{name}")]
        [Produces(MediaTypeNames.Application.Json)]
        public Dummy GetDummy(string name)
        {
            return new Dummy { Text = name };
        }

    }
}
