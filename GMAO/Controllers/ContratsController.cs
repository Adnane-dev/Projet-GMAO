using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GMAO.Models.Entities;
using Microsoft.EntityFrameworkCore;
using GMAO.Models.Connection;

namespace GMAO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratsController : ControllerBase
    {
        private readonly GMAOContext _context;

        public ContratsController(GMAOContext context)
        {
            _context = context;
        }

        // GET: api/Contrats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contrats>>> GetContrats()
        {
            return await _context.Contrats.ToListAsync();
        }

        // GET: api/Contrats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contrats>> GetContrat(int id)
        {
            var contrat = await _context.Contrats.FindAsync(id);

            if (contrat == null)
            {
                return NotFound();
            }

            return contrat;
        }

        // PUT: api/Contrats/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContrat(int id, Contrats contrat)
        {
            if (id != contrat.IdContrat)
            {
                return BadRequest();
            }

            _context.Entry(contrat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContratExists(id))
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

        // POST: api/Contrats
        [HttpPost]
        public async Task<ActionResult<Contrats>> PostContrat(Contrats contrat)
        {
            _context.Contrats.Add(contrat);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContrat), new { id = contrat.IdContrat }, contrat);
        }

        // DELETE: api/Contrats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContrat(int id)
        {
            var contrat = await _context.Contrats.FindAsync(id);

            if (contrat == null)
            {
                return NotFound();
            }

            _context.Contrats.Remove(contrat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContratExists(int id)
        {
            return _context.Contrats.Any(e => e.IdContrat == id);
        }
    }

    /*/ GET: api/Contrats/ValeurTotale
    [HttpGet("ValeurTotale")]
    public async Task<ActionResult<decimal>> GetValeurTotaleContrats()
    {
        return await _context.Contrats.Select(c => c.Prix).SumAsync();
    }

    // GET: api/Contrats/EnCours
    [HttpGet("EnCours")]
    public async Task<ActionResult<IEnumerable<Contrats>>> GetContratsEnCours()
    {
        return await _context.Contrats.Where(c => c.DateFin >= DateTime.Today).ToListAsync();
    }


    */
}
