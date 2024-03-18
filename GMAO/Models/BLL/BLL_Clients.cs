
using GMAO.Models.Entities;
using GMAO.Models.DAL;
using System;
using System.Collections.Generic;

namespace GMAO.Models.BLL
{
    public class BLL_Clients
    {
        public static int AddClient(Clients client)
        {
            // Vous pouvez ajouter des logiques métier ici si nécessaire
            // Par exemple, valider les données du client avant l'ajout

            return DAL_Clients.Add(client);
        }

        public static List<Clients> GetAllClients()
        {
            return DAL_Clients.GetAllClients();
        }

        public static Clients GetClientById(int id)
        {
            return DAL_Clients.GetClientById(id);
        }

        public static void UpdateClient(Clients client)
        {
            // Vous pouvez ajouter des logiques métier ici si nécessaire
            // Par exemple, valider les données du client avant la mise à jour

            DAL_Clients.Update(client);
        }

        public static void DeleteClient(int id)
        {
            // Vous pouvez ajouter des logiques métier ici si nécessaire
            // Par exemple, vérifier si le client peut être supprimé avant de le supprimer

            DAL_Clients.Delete(id);
        }
    }
}
