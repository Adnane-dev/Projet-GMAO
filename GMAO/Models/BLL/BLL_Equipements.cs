using GMAO.Models.DAL;
using GMAO.Models.Entities;

namespace GMAO.Models.BLL
{
    public class BLL_Equipements
    {
        public static int Add(Equipements Equipements) => DAL_Equipements.Add(Equipements);

        public static void Update(int id, Equipements Equipements) => DAL_Equipements.Update(id, Equipements);
        public static void Delete(int id) => DAL_Equipements.Delete(id);
        public static Equipements Get(int id) => DAL_Equipements.SelectById(id);
        public static List<Equipements> Get() => DAL_Equipements.SelectAll();

    }
}
