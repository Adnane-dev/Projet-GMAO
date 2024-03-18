using GMAO.Models.Entities;
using GMAO.Models.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GMAO.Models.BLL;

namespace GMAO.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class EquipementsController : Controller
    {
        
        // GET: api/Equipements
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                List<Equipements> equipements = BLL_Equipements.Get();
                return Json(new { success = true, message = "Equipementss found", data = equipements });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // GET: api/Equipements/{id}
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                Equipements equipements = BLL_Equipements.Get(id);
                return Json(new { success = true, message = "Equipements found", data = equipements });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // POST: api/Equipements
        [HttpPost]
        public JsonResult Post([FromBody] Equipements equipements)
        {
            try
            {
                equipements.IdEquipement = BLL_Equipements.Add(equipements);
                return Json(new { success = true, message = "Successfully added", data = equipements });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // PUT: api/Equipements/{id}
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] Equipements equipements)
        {
            try
            {
                BLL_Equipements.Update(id, equipements);
                return Json(new { success = true, message = "Successfully modified", data = equipements });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // DELETE: api/Equipements/{id}
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                BLL_Equipements.Delete(id);
                return Json(new { success = true, message = "Successfully deleted" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}



