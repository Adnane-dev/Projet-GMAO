using Microsoft.AspNetCore.Mvc;
using GMAO.Models.Entities;
using GMAO.Models.DAL;
using System;
using System.Collections.Generic;

namespace GMAO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        // GET: api/Clients
        [HttpGet]
        public ActionResult<IEnumerable<Clients>> GetAllClients()
        {
            return DAL_Clients.GetAllClients();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public ActionResult<Clients> GetClientById(int id)
        {
            var client = DAL_Clients.GetClientById(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // POST: api/Clients
        [HttpPost]
        public ActionResult<int> AddClient([FromBody] Clients client)
        {
            var result = DAL_Clients.Add(client);
            return Ok(result);
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, [FromBody] Clients client)
        {
            if (id != client.IdClient)
            {
                return BadRequest();
            }

            try
            {
                DAL_Clients.Update(client);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var client = DAL_Clients.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }

            DAL_Clients.Delete(id);

            return NoContent();
        }
    }
}
