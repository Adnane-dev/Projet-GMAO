using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GMAO.Models.Entities;
using Microsoft.EntityFrameworkCore;
using GMAO.Models.Connection;

namespace GMAO.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]
    public class InterventionsController : ControllerBase
    {
        private readonly GMAOContext _context;

        public InterventionsController(GMAOContext context)
        {
            _context = context;
        }

        // GET: api/Interventions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interventions>>> GetInterventions()
        {
            return await _context.Interventions.ToListAsync();
        }

        // GET: api/Interventions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Interventions>> GetIntervention(int id)
        {
            var intervention = await _context.Interventions.FindAsync(id);

            if (intervention == null)
            {
                return NotFound();
            }

            return intervention;
        }

        // PUT: api/Interventions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIntervention(int id, Interventions intervention)
        {
            if (id != intervention.IdIntervention)
            {
                return BadRequest();
            }

            _context.Entry(intervention).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterventionExists(id))
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

        // POST: api/Interventions
        [HttpPost]
        public async Task<ActionResult<Interventions>> PostIntervention(Interventions intervention)
        {
            _context.Interventions.Add(intervention);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetIntervention), new { id = intervention.IdIntervention }, intervention);
        }

        // DELETE: api/Interventions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIntervention(int id)
        {
            var intervention = await _context.Interventions.FindAsync(id);

            if (intervention == null)
            {
                return NotFound();
            }

            _context.Interventions.Remove(intervention);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InterventionExists(int id)
        {
            return _context.Interventions.Any(e => e.IdIntervention == id);
        }
    }
    /*// GET: api/Interventions/EnCours
[HttpGet("EnCours")]
public async Task<ActionResult<IEnumerable<Interventions>>> GetInterventionsEnCours()
{
    return await _context.Interventions.Where(i => i.Statut == "En cours").ToListAsync();
}

// GET: api/Interventions/ParClient/5
[HttpGet("ParClient/{idClient}")]
public async Task<ActionResult<IEnumerable<Interventions>>> GetInterventionsParClient(int idClient)
{
    return await _context.Interventions.Where(i => i.ClientId == idClient).ToListAsync();
}
*/
}
