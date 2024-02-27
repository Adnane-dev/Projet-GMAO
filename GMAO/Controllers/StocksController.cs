using Microsoft.AspNetCore.Mvc;
using GMAO.Models.Entities;
using static GMAO.Models.DAL.DAL_Stocks;

[Route("api/[controller]")]
[ApiController]
public class StocksController : ControllerBase
{
    private readonly StocksRepository _stocksRepository;

    public StocksController()
    {
        _stocksRepository = new StocksRepository();
    }

    // GET: api/Stocks
    [HttpGet]
    public IActionResult Get()
    {
        var stocks = _stocksRepository.GetAllStocks();
        return Ok(stocks);
    }

    // GET: api/Stocks/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var stock = _stocksRepository.GetStockById(id);

        if (stock == null)
            return NotFound();

        return Ok(stock);
    }

    // POST: api/Stocks
    [HttpPost]
    public IActionResult Post([FromBody] Stocks stock)
    {
        if (stock == null)
            return BadRequest();

        _stocksRepository.AddStock(stock);

        return CreatedAtAction(nameof(Get), new { id = stock.IdStock }, stock);
    }

    // PUT: api/Stocks/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Stocks stock)
    {
        if (stock == null || id != stock.IdStock)
            return BadRequest();

        var existingStock = _stocksRepository.GetStockById(id);

        if (existingStock == null)
            return NotFound();

        _stocksRepository.UpdateStock(stock);

        return NoContent();
    }

    // DELETE: api/Stocks/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var stock = _stocksRepository.GetStockById(id);

        if (stock == null)
            return NotFound();

        _stocksRepository.DeleteStock(id);

        return NoContent();
    }
}













































/*using GMAO.Models.BLL;
using GMAO.Models.Connection;
using GMAO.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMAO.Controllers
{
   
    [Route("[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly GMAOContext _context;

        public StocksController(GMAOContext context)
        {
            _context = context;
        }

        // GET: api/Stocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stocks>>> GetStocks()
        {
            return await _context.Stocks.ToListAsync();
        }

        // GET: api/Stocks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stocks>> GetStock(int id)
        {
            var stock = await _context.Stocks.FindAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return stock;
        }

        // PUT: api/Stocks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStock(int id, Stocks stock)
        {
            if (id != stock.IdStock)
            {
                return BadRequest();
            }

            _context.Entry(stock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockExists(id))
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

        // POST: api/Stocks
        [HttpPost]
        public async Task<ActionResult<Stocks>> PostStock(Stocks stock)
        {
          //  stock.IdStock = BLL_Stocks.Add(stock);

            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStock), new { id = stock.IdStock }, stock);
        }

        // DELETE: api/Stocks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            var stock = await _context.Stocks.FindAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StockExists(int id)
        {
            return _context.Stocks.Any(e => e.IdStock == id);
        }
    }

}*/
