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
    public class GroupesController : ControllerBase
    {
        private readonly ClasseContext _context;

        public GroupesController(ClasseContext context)
        {
            _context = context;
        }

        // GET: api/Groupes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Groupe>>> Getgroupe()
        {
          if (_context.groupe == null)
          {
              return NotFound();
          }
            return await _context.groupe.ToListAsync();
        }

        // GET: api/Groupes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Groupe>> GetGroupe(int id)
        {
          if (_context.groupe == null)
          {
              return NotFound();
          }
            var groupe = await _context.groupe.FindAsync(id);

            if (groupe == null)
            {
                return NotFound();
            }

            return groupe;
        }

        // PUT: api/Groupes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupe(int id, Groupe groupe)
        {
            if (id != groupe.Id)
            {
                return BadRequest();
            }

            _context.Entry(groupe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupeExists(id))
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

        // POST: api/Groupes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Groupe>> PostGroupe(Groupe groupe)
        {
          if (_context.groupe == null)
          {
              return Problem("Entity set 'ClasseContext.groupe'  is null.");
          }
            _context.groupe.Add(groupe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupe", new { id = groupe.Id }, groupe);
        }

        // DELETE: api/Groupes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupe(int id)
        {
            if (_context.groupe == null)
            {
                return NotFound();
            }
            var groupe = await _context.groupe.FindAsync(id);
            if (groupe == null)
            {
                return NotFound();
            }

            _context.groupe.Remove(groupe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroupeExists(int id)
        {
            return (_context.groupe?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
