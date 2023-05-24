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
    public class CoordinateursController : ControllerBase
    {
        private readonly ClasseContext _context;

        public CoordinateursController(ClasseContext context)
        {
            _context = context;
        }

        // GET: api/Coordinateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coordinateur>>> Getcoordinateur()
        {
          if (_context.coordinateur == null)
          {
              return NotFound();
          }
            return await _context.coordinateur.ToListAsync();
        }

        // GET: api/Coordinateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coordinateur>> GetCoordinateur(int id)
        {
          if (_context.coordinateur == null)
          {
              return NotFound();
          }
            var coordinateur = await _context.coordinateur.FindAsync(id);

            if (coordinateur == null)
            {
                return NotFound();
            }

            return coordinateur;
        }

        // PUT: api/Coordinateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoordinateur(int id, Coordinateur coordinateur)
        {
            if (id != coordinateur.Id)
            {
                return BadRequest();
            }

            _context.Entry(coordinateur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoordinateurExists(id))
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

        // POST: api/Coordinateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Coordinateur>> PostCoordinateur(Coordinateur coordinateur)
        {
          if (_context.coordinateur == null)
          {
              return Problem("Entity set 'ClasseContext.coordinateur'  is null.");
          }
            _context.coordinateur.Add(coordinateur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoordinateur", new { id = coordinateur.Id }, coordinateur);
        }

        // DELETE: api/Coordinateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoordinateur(int id)
        {
            if (_context.coordinateur == null)
            {
                return NotFound();
            }
            var coordinateur = await _context.coordinateur.FindAsync(id);
            if (coordinateur == null)
            {
                return NotFound();
            }

            _context.coordinateur.Remove(coordinateur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoordinateurExists(int id)
        {
            return (_context.coordinateur?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
