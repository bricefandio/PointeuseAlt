using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevesController : ControllerBase
    {
        private readonly ClasseContext _context;

        public ElevesController(ClasseContext context)
        {
            _context = context;
        }

        // GET: api/Eleves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Eleve>>> Geteleve()
        {
          if (_context.eleve == null)
          {
              return NotFound();
          }
            return await _context.eleve.ToListAsync();
        }

        // GET: api/Eleves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Eleve>> GetEleve(int id)
        {
          if (_context.eleve == null)
          {
              return NotFound();
          }
            var eleve = await _context.eleve.FindAsync(id);

            if (eleve == null)
            {
                return NotFound();
            }

            return eleve;
        }

        // PUT: api/Eleves/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEleve(int id, Eleve eleve)
        {
            if (id != eleve.Id)
            {
                return BadRequest();
            }

            _context.Entry(eleve).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EleveExists(id))
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

        // POST: api/Eleves
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Eleve>> PostEleve(Eleve eleve)
        {
          if (_context.eleve == null)
          {
              return Problem("Entity set 'ClasseContext.eleve'  is null.");
          }
            _context.eleve.Add(eleve);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEleve", new { id = eleve.Id }, eleve);
        }

        // DELETE: api/Eleves/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEleve(int id)
        {
            if (_context.eleve == null)
            {
                return NotFound();
            }
            var eleve = await _context.eleve.FindAsync(id);
            if (eleve == null)
            {
                return NotFound();
            }

            _context.eleve.Remove(eleve);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EleveExists(int id)
        {
            return (_context.eleve?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
