using GMAO.Models.Entities;
using ServerTemplateAPI.Models.Connection;
using ServerTemplateAPI.Utilities;
using System.Data.SqlClient;

namespace GMAO.Models.DAL
{
    public class DAL_Clients
    {


        public static int Add(Clients clients)
        {

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                string StrAQL = "Insert Into Clients  (Nom,Prenom,Email,Telephone,Adresse,CodePostal,Ville,Rue) ";

                SqlCommand cmd = new SqlCommand(StrAQL, connection);
                cmd.Parameters.AddWithValue("@Nom", clients.Nom);
                cmd.Parameters.AddWithValue("@Prenom", clients.Prenom);
                cmd.Parameters.AddWithValue("@Email", clients.Email);
                cmd.Parameters.AddWithValue("@Telephone", clients.Telephone);
                cmd.Parameters.AddWithValue("@Adresse", clients.Adresse);
                cmd.Parameters.AddWithValue("@CodePostal", clients.CodePostal);
                cmd.Parameters.AddWithValue("@Ville", clients.Ville);
                cmd.Parameters.AddWithValue("@Rue", clients.Rue);

                return Convert.ToInt32(DataBaseAccessUtilities.ScalarRequest(cmd));

            }
        }

    }
}
