using GMAO.Models.DAL;
using GMAO.Models.Entities;

namespace GMAO.Models.BLL
{
    public class BLL_Clients
    {
          public static int Add(Clients clients) => DAL_Clients.Add(clients);
    //   public static List<Clients> Get() => DAL_Clients.SelectAll();


    }
}
