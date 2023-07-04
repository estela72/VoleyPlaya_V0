using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ejemplo.EFWebAPI.Data;
using Ejemplo.EFWebAPI.Model;
using System.Net.Mime;

namespace Ejemplo.EFWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DummiesController : ControllerBase
    {
        private readonly DataContext _context;

        public DummiesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Dummies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dummy>>> GetDummies()
        {
          if (_context.Dummies == null)
          {
              return NotFound();
          }
            return await _context.Dummies.ToListAsync();
        }

        // GET: api/Dummies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dummy>> GetDummy(long id)
        {
          if (_context.Dummies == null)
          {
              return NotFound();
          }
            var dummy = await _context.Dummies.FindAsync(id);

            if (dummy == null)
            {
                return NotFound();
            }

            return dummy;
        }

        // PUT: api/Dummies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDummy(long id, Dummy dummy)
        {
            if (id != dummy.Id)
            {
                return BadRequest();
            }

            _context.Entry(dummy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DummyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Creates a Dummy
        /// </summary>
        /// <param name="dummy"></param>
        /// <returns>A newly created Dummy</returns>
        /// <remarks>
        ///     POST api/dummies
        ///     {
        ///         "text": "New dummy"
        ///     }
        /// </remarks>
        /// <response code="201">Returns the newly created dummy</response>
        /// <response code="400">If the item is null</response>
        /// POST: api/Dummies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dummy>> PostDummy(Dummy dummy)
        {
            if (_context.Dummies == null)
            {
                return Problem("Entity set 'DataContext.Dummies'  is null.");
            }
            _context.Dummies.Add(dummy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDummy", new { id = dummy.Id }, dummy);
        }

        // DELETE: api/Dummies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDummy(long id)
        {
            if (_context.Dummies == null)
            {
                return NotFound();
            }
            var dummy = await _context.Dummies.FindAsync(id);
            if (dummy == null)
            {
                return NotFound();
            }

            _context.Dummies.Remove(dummy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DummyExists(long id)
        {
            return (_context.Dummies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
