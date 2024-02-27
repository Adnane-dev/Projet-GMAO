using GMAO.Models.BLL;
using GMAO.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GMAO.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientsController : Controller
    {
      /*  // GET: api/Clients
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                List<Clients> Clients = BLL_Clients.Get();
                return Json(new { success = true, message = "Clientss found", data = Clients });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
      
        }*/


        // POST: api/Clients
        [HttpPost]
        public JsonResult Post([FromBody] Clients Clients)
        {
            try
            {
                Clients.IdClient = BLL_Clients.Add(Clients);
                return Json(new { success = true, message = "Successfully added", data = Clients });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

    }
}
