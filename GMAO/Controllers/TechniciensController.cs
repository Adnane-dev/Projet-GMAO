using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GMAO.Controllers
{
    using GMAO.Models.Connection;
    using GMAO.Models.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]")]
    [ApiController]
    public class TechniciensController : ControllerBase
    {
        private readonly GMAOContext _context;

        public TechniciensController(GMAOContext context)
        {
            _context = context; 
        }

        // GET: api/Techniciens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Techniciens>>> GetTechniciens()
        {
            return await _context.Techniciens.ToListAsync();
        }

        // GET: api/Techniciens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Techniciens>> GetTechnicien(int id)
        {
            var technicien = await _context.Techniciens.FindAsync(id);

            if (technicien == null)
            {
                return NotFound();
            }

            return technicien;
        }

        // PUT: api/Techniciens/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTechnicien(int id, Techniciens technicien)
        {
            if (id != technicien.IdTechnicien)
            {
                return BadRequest();
            }

            _context.Entry(technicien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechnicienExists(id))
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

        // POST: api/Techniciens
        [HttpPost]
        public async Task<ActionResult<Techniciens>> PostTechnicien(Techniciens technicien)
        {
            _context.Techniciens.Add(technicien);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTechnicien), new { id = technicien.IdTechnicien }, technicien);
        }

        // DELETE: api/Techniciens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechnicien(int id)
        {
            var technicien = await _context.Techniciens.FindAsync(id);

            if (technicien == null)
            {
                return NotFound();
            }

            _context.Techniciens.Remove(technicien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TechnicienExists(int id)
        {
            return _context.Techniciens.Any(e => e.IdTechnicien == id);
        }
    }
    /*
     * // GET: api/Techniciens/ParSpecialisation/plomberie
    [HttpGet("ParSpecialisation/{specialisation}")]
    public async Task<ActionResult<IEnumerable<Techniciens>>> GetTechniciensParSpecialisation(string specialisation)
    {
        return await _context.Techniciens.Where(t => t.Specialisation == specialisation).ToListAsync();
    }

     */
}
