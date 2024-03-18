using GMAO.Models.Entities;
using ServerTemplateAPI.Models.Connection;
using ServerTemplateAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GMAO.Models.DAL
{
    public class DAL_Clients
    {
        public static int Add(Clients clients)
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                string strSql = "INSERT INTO Clients (Nom, Prenom, Email, Telephone, Adresse, CodePostal, Ville, Rue) " +
                                "VALUES (@Nom, @Prenom, @Email, @Telephone, @Adresse, @CodePostal, @Ville, @Rue)";

                SqlCommand cmd = new SqlCommand(strSql, connection);
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

        public static List<Clients> GetAllClients()
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                string strSql = "SELECT * FROM Clients";
                SqlCommand cmd = new SqlCommand(strSql, connection);
                SqlDataReader reader = DataBaseAccessUtilities.ReaderRequest(cmd);

                List<Clients> clientsList = new List<Clients>();
                while (reader.Read())
                {
                    Clients client = new Clients
                    {
                        // Assurez-vous d'ajuster les noms des colonnes en fonction de votre schéma de base de données
                        IdClient = Convert.ToInt32(reader["IdClient"]),
                        Nom = reader["Nom"].ToString(),
                        Prenom = reader["Prenom"].ToString(),
                        Email = reader["Email"].ToString(),
                        Telephone = reader["Telephone"].ToString(),
                        Adresse = reader["Adresse"].ToString(),
                        CodePostal = reader["CodePostal"].ToString(),
                        Ville = reader["Ville"].ToString(),
                        Rue = reader["Rue"].ToString()
                    };

                    clientsList.Add(client);
                }
                connection.Close();
                return clientsList;
            }
        }

        public static Clients GetClientById(int id)
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                string strSql = "SELECT * FROM Clients WHERE IdClient = @IdClient";
                SqlCommand cmd = new SqlCommand(strSql, connection);
                cmd.Parameters.AddWithValue("@IdClient", id);

                SqlDataReader reader = DataBaseAccessUtilities.ReaderRequest(cmd);

                if (reader.Read())
                {
                    Clients client = new Clients
                    {
                        IdClient = Convert.ToInt32(reader["IdClient"]),
                        Nom = reader["Nom"].ToString(),
                        Prenom = reader["Prenom"].ToString(),
                        Email = reader["Email"].ToString(),
                        Telephone = reader["Telephone"].ToString(),
                        Adresse = reader["Adresse"].ToString(),
                        CodePostal = reader["CodePostal"].ToString(),
                        Ville = reader["Ville"].ToString(),
                        Rue = reader["Rue"].ToString()
                    };

                    return client;
                }

                return null;
            }
        }

        public static void Update(Clients clients)
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                string strSql = "UPDATE Clients SET Nom = @Nom, Prenom = @Prenom, " +
                                "Email = @Email, Telephone = @Telephone, Adresse = @Adresse, " +
                                "CodePostal = @CodePostal, Ville = @Ville, Rue = @Rue " +
                                "WHERE IdClient = @IdClient";

                SqlCommand cmd = new SqlCommand(strSql, connection);
                cmd.Parameters.AddWithValue("@IdClient", clients.IdClient);
                cmd.Parameters.AddWithValue("@Nom", clients.Nom);
                cmd.Parameters.AddWithValue("@Prenom", clients.Prenom);
                cmd.Parameters.AddWithValue("@Email", clients.Email);
                cmd.Parameters.AddWithValue("@Telephone", clients.Telephone);
                cmd.Parameters.AddWithValue("@Adresse", clients.Adresse);
                cmd.Parameters.AddWithValue("@CodePostal", clients.CodePostal);
                cmd.Parameters.AddWithValue("@Ville", clients.Ville);
                cmd.Parameters.AddWithValue("@Rue", clients.Rue);

                DataBaseAccessUtilities.NonQueryRequest(cmd);
            }
        }

        public static void Delete(int id)
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                string strSql = "DELETE FROM Clients WHERE IdClient = @IdClient";
                SqlCommand cmd = new SqlCommand(strSql, connection);
                cmd.Parameters.AddWithValue("@IdClient", id);

                DataBaseAccessUtilities.NonQueryRequest(cmd);
            }
        }
    }
}






/*





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
*/