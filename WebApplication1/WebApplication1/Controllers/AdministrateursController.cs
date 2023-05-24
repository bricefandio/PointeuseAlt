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
    public class AdministrateursController : ControllerBase
    {
        private readonly ClasseContext _context;

        public AdministrateursController(ClasseContext context)
        {
            _context = context;
        }

        // GET: api/Administrateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrateur>>> Getadministrateur()
        {
          if (_context.administrateur == null)
          {
              return NotFound();
          }
            return await _context.administrateur.ToListAsync();
        }

        // GET: api/Administrateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrateur>> GetAdministrateur(int id)
        {
          if (_context.administrateur == null)
          {
              return NotFound();
          }
            var administrateur = await _context.administrateur.FindAsync(id);

            if (administrateur == null)
            {
                return NotFound();
            }

            return administrateur;
        }

        // PUT: api/Administrateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrateur(int id, Administrateur administrateur)
        {
            if (id != administrateur.Id)
            {
                return BadRequest();
            }

            _context.Entry(administrateur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministrateurExists(id))
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

        // POST: api/Administrateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Administrateur>> PostAdministrateur(Administrateur administrateur)
        {
          if (_context.administrateur == null)
          {
              return Problem("Entity set 'ClasseContext.administrateur'  is null.");
          }
            _context.administrateur.Add(administrateur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdministrateur", new { id = administrateur.Id }, administrateur);
        }

        // DELETE: api/Administrateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrateur(int id)
        {
            if (_context.administrateur == null)
            {
                return NotFound();
            }
            var administrateur = await _context.administrateur.FindAsync(id);
            if (administrateur == null)
            {
                return NotFound();
            }

            _context.administrateur.Remove(administrateur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdministrateurExists(int id)
        {
            return (_context.administrateur?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
