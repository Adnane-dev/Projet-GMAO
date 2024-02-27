using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GMAO.Models.Entities;
using Microsoft.EntityFrameworkCore;
using GMAO.Models.Connection;

namespace GMAO.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]
    public class DevisController : ControllerBase
    {
        private readonly GMAOContext _context;

        public DevisController(GMAOContext context)
        {
            _context = context;
        }

        // GET: api/Devis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Devis>>> GetDevis()
        {
            return await _context.Devis.ToListAsync();
        }

        // GET: api/Devis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Devis>> GetDevis(int id)
        {
            var devis = await _context.Devis.FindAsync(id);

            if (devis == null)
            {
                return NotFound();
            }

            return devis;
        }

        // PUT: api/Devis/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevis(int id, Devis devis)
        {
            if (id != devis.IdDevis)
            {
                return BadRequest();
            }

            _context.Entry(devis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DevisExists(id))
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

        // POST: api/Devis
        [HttpPost]
        public async Task<ActionResult<Devis>> PostDevis(Devis devis)
        {
            _context.Devis.Add(devis);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDevis), new { id = devis.IdDevis }, devis);
        }

        // DELETE: api/Devis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevis(int id)
        {
            var devis = await _context.Devis.FindAsync(id);

            if (devis == null)
            {
                return NotFound();
            }

            _context.Devis.Remove(devis);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DevisExists(int id)
        {
            return _context.Devis.Any(e => e.IdDevis == id);
        }
    }


    /*// GET: api/Devis/ValeurTotale
[HttpGet("ValeurTotale")]
public async Task<ActionResult<decimal>> GetValeurTotaleDevis()
{
    return await _context.Devis.Select(d => d.Prix).SumAsync();
}

// GET: api/Devis/EnCours
[HttpGet("EnCours")]
public async Task<ActionResult<IEnumerable<Devis>>> GetDevisEnCours()
{
    return await _context.Devis.Where(d => d.DateDevis >= DateTime.Today).ToListAsync();
}
*/
}
