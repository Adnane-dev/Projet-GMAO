using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GMAO.Models.Connection;
using GMAO.Models.Entities;
using MessagePack;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace GMAO.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class FacturesController : ControllerBase
    {
        private readonly GMAOContext _context;

        public FacturesController(GMAOContext context)
        {
            _context = context;
        }

        // GET: api/Factures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factures>>> GetFactures()
        {
            return await _context.Factures.ToListAsync();
        }

        // GET: api/Factures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Factures>> GetFacture(int id)
        {
            var facture = await _context.Factures.FindAsync(id);

            if (facture == null)
            {
                return NotFound();
            }

            return facture;
        }

        // PUT: api/Factures/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacture(int id, Factures facture)
        {
            if (id != facture.IdFacture)
            {
                return BadRequest();
            }

            _context.Entry(facture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactureExists(id))
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

        // POST: api/Factures
        [HttpPost]
        public async Task<ActionResult<Factures>> PostFacture(Factures facture)
        {
            _context.Factures.Add(facture);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFacture), new { id = facture.IdFacture }, facture);
        }

        // DELETE: api/Factures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacture(int id)
        {
            var facture = await _context.Factures.FindAsync(id);

            if (facture == null)
            {
                return NotFound();
            }

            _context.Factures.Remove(facture);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FactureExists(int id)
        {
            return _context.Factures.Any(e => e.IdFacture == id);
        }
        /*/
       // Sérialisation MessagePack
       [HttpPost("SerializeMessagePack")]
       public async Task<IActionResult> SerializeMessagePack(int id)
       {
           var facture = await _context.Factures.FindAsync(id);

           if (facture == null)
           {
               return NotFound();
           }


           // Inside your controller method
           var messagePackSerializer = MessagePackSerializer.Get<Factures>();
           var serializedFacture = messagePackSerializer.Serialize(facture);

           return File(serializedFacture, "application/octet-stream", $"facture-{id}.msgpack");
       }
   }
  / GET: api/Factures/ValeurTotale
[HttpGet("ValeurTotale")]
public async Task<ActionResult<decimal>> GetValeurTotaleFactures()
{
   return await _context.Factures.Select(f => f
*/

    }
}
